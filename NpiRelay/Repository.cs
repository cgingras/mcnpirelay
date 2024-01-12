using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Microsoft.Extensions.Configuration;

namespace NpiRelay
{
	public interface IRepository
	{
		Task<IEnumerable<NpiData>> SearchNpi(string npi, string firstName = null, string lastName = null, string state = null);
		Task<IEnumerable<CmsData>> SearchCms(string npi, string firstName = null, string lastName = null, string state = null);
		Task<OpenPaymentProfile> GetOpenPaymentProfile(string npiNumber);
	}

	public class Repository : IRepository
	{
		public string ConnectionString { get; set; }

		public Repository(IConfiguration configuration)
		{
			ConnectionString = configuration.GetValue<string>("NpiDatabaseConnectionString");
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

		public async Task<IEnumerable<CmsData>> SearchCms(string npi, string firstName = null, string lastName = null, string state = null)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					var sql = "dbo.SearchCms";
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

					var result = await conn.QueryAsync<CmsData>(sql, parameters, commandType: CommandType.StoredProcedure);

					return result;
				}
			}
			catch
			{
				//TODO: Do something with Exception
				return null;
			}
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
