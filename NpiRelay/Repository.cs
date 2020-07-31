using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Dapper;

using Microsoft.Extensions.Configuration;

namespace NpiRelay
{
	public class Repository
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
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
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
			}
			catch
			{
				//TODO: Do something with Exception
				return null;
			}
		}
	}
}
