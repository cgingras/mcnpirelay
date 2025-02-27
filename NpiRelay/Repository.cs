using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using NpiRelay.Context;

namespace NpiRelay
{
	public interface IRepository
	{
		Task<IEnumerable<NpiData>> SearchNpi(string npi, string firstName = null, string lastName = null, string state = null);
		Task<IEnumerable<CmsData>> SearchCms(string? npi, string? firstName, string? lastName, string? state, int pageNumber, int pageSize);
		Task<OpenPaymentProfile> GetOpenPaymentProfile(string npiNumber);
	}

	public class Repository : IRepository
	{
		private readonly NpiRelayDbContext _context;
		public string ConnectionString { get; set; }

		public Repository(IConfiguration configuration, NpiRelayDbContext context)
		{
			ConnectionString = configuration.GetValue<string>("NpiDatabaseConnectionString");
			_context = context;
		}

		public async Task<IEnumerable<NpiData>> SearchNpi(string npi, string firstName = null, string lastName = null, string state = null)
		{
			try
			{
				await using SqlConnection conn = new SqlConnection(ConnectionString);
				var sql = "dbo.SearchNpi";
				var parameters = new DynamicParameters();

				if (!string.IsNullOrEmpty(npi))
				{
					parameters.Add("@NpiNumber", npi);
				}

				if (!string.IsNullOrEmpty(firstName))
				{
					parameters.Add("@FirstName", firstName);
				}

				if (!string.IsNullOrEmpty(lastName))
				{
					parameters.Add("@LastName", lastName);
				}

				if (!string.IsNullOrEmpty(state))
				{
					parameters.Add("@State", state);
				}

				var result = await conn.QueryAsync<NpiData>(sql, parameters, commandType: CommandType.StoredProcedure);

				return result;
			}
			catch
			{
				//TODO: Do something with Exception
				return null;
			}
		}

		public async Task<IEnumerable<CmsData>> SearchCms(string? npi, string? firstName, string? lastName, string? state, int pageNumber, int pageSize)
		{
			if (string.IsNullOrEmpty(npi) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(state))
			{
				throw new ArgumentException("At least one parameter should be passed.");
			}

			var query = from cms in _context.CmsRecords
						join tax in _context.Taxonomy
						on cms.ProviderTaxonomyCode equals tax.Code into taxJoin
						from tax in taxJoin.DefaultIfEmpty()
						where (string.IsNullOrEmpty(npi) || cms.Npi == npi)
							&& (string.IsNullOrEmpty(firstName) || cms.ProviderFirstName == firstName)
							&& (string.IsNullOrEmpty(lastName) || cms.ProviderLastName == lastName)
							&& (string.IsNullOrEmpty(state) || cms.LicenseState == state)
						select new CmsData
						{
							Id = cms.Id,
							CreatedAt = cms.CreatedAt,
							Npi = cms.Npi,
							ProviderFirstName = cms.ProviderFirstName,
							ProviderLastName = cms.ProviderLastName,
							ProviderTaxonomyCode = cms.ProviderTaxonomyCode,
							ProviderTaxonomyDescription = tax != null ? tax.Description : null,
							ProviderType = cms.ProviderType,
							LicenseState = cms.LicenseState,
							LicenseNumber = cms.LicenseNumber
						};

			return await query
				.OrderBy(cms => cms.Id)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<OpenPaymentProfile> GetOpenPaymentProfile(string npiNumber)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@NpiNumber", npiNumber);
				var sql = @"
					SELECT
						Covered_Recipient_NPI AS NpiNumber,
						Covered_Recipient_Profile_ID AS ProfileId
					FROM OpenPaymentProfiles
					WHERE Covered_Recipient_NPI = @NpiNumber";

				var result = await conn.QueryAsync<OpenPaymentProfile>(sql, parameters, commandType: CommandType.Text);

				return result.FirstOrDefault();
			}  
		}
	}
}
