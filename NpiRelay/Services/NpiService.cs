using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace NpiRelay.Services
{
	public interface INpiService
	{
		Task<IEnumerable<NpiData>> SearchNpiByName(string firstName, string lastName, string state);
		Task<IEnumerable<CmsData>> SearchCmsByName(string firstName, string lastName, string state);

		Task<IEnumerable<NpiData>> SearchNpiByNumber(string npi);
		Task<IEnumerable<CmsData>> SearchCmsByNumber(string npi);
	}

	public class NpiService : INpiService
	{
		private readonly IRepository _repository;
		private readonly NpiRegistry _config;
		private readonly HttpClient _httpClient;

		public NpiService(
			IRepository repository, 
			IOptions<NpiRegistry> config,
			HttpClient httpClient)
		{
			_repository = repository;
			_config = config.Value;
			_httpClient = httpClient;
		}


		public async Task<IEnumerable<NpiData>> SearchNpiByName(string firstName, string lastName, string state)
		{
			var cmsResult = await SearchCmsByName(firstName, lastName, state);
			var npiResult = await this.SearchNpi(null, firstName, lastName, state);

			return MergeNpiAndCms(npiResult, cmsResult);
		}

		private async Task<IEnumerable<NpiData>> SearchNpi(string npi, string firstName = null, string lastName = null, string state = null)
		{
			try
			{
                var conditions = new List<string>();

                if (!string.IsNullOrWhiteSpace(npi))
                {
                    conditions.Add($"number={npi}");
                }
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    conditions.Add($"first_name={firstName}");
                }
                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    conditions.Add($"last_name={lastName}");
                }
                if (!string.IsNullOrWhiteSpace(state))
                {
                    conditions.Add($"state={state}");
                }

				var route = $"{_config.ApiUrl}{_config.ApiVersion}&{string.Join("&", conditions)}";

				using (var request = new HttpRequestMessage())
				{
					request.Method = HttpMethod.Get;
					request.RequestUri = new Uri(route, UriKind.Absolute);

					var response = await _httpClient.SendAsync(request);

					response.EnsureSuccessStatusCode();

					var json = await response.Content.ReadAsStringAsync();

					var nppesResult = JsonConvert.DeserializeObject<NppesResults>(json);
					
					var npiData = new List<NpiData>();

					foreach (var item in nppesResult.Results)
					{
						var mailingAddress = item.Addresses.Where(i => i.Address_purpose == "MAILING").FirstOrDefault();
						var locationAddress = item.Addresses.Where(i => i.Address_purpose == "LOCATION").FirstOrDefault();
						var taxonomy = item.Taxonomies.Where(i => i.Primary == true).FirstOrDefault();
						var otherName = item.Other_names.FirstOrDefault();
						var identifier = item.Identifiers.FirstOrDefault();

						npiData.Add(new NpiData{
							NPI = item.Number,
							ProviderType = item.Enumeration_type,
							EmployerIdentificationNumber = identifier?.Identifier,
							LastUpdateDate = item.Basic?.Last_updated,
							ProviderFirstName = item.Basic?.First_name,
							ProviderLastName = item.Basic?.Last_name,
							ProviderMiddleName = item.Basic?.Middle_name,
							ProviderCredentialText = item.Basic?.Credential,
							ProviderNamePrefixText = item.Basic?.Name_prefix,
							ProviderNameSuffixText = item.Basic?.Name_suffix,
							ProviderGenderCode = item.Basic?.Gender,
							HealthcareProviderTaxonomyCode = taxonomy?.Code,
							HealthcareProviderTaxonomyDescription = taxonomy?.Desc,
							ProviderLicenseNumber = taxonomy?.License,
							ProviderLicenseNumberStateCode  = taxonomy?.State,
							ProviderFirstLineBusinessMailingAddress = mailingAddress?.Address_1,
							ProviderSecondLineBusinessMailingAddress = mailingAddress?.Address_2,
							ProviderBusinessMailingAddressCityName = mailingAddress?.City,
							ProviderBusinessMailingAddressStateName = mailingAddress?.State,
							ProviderBusinessMailingAddressPostalCode = mailingAddress?.Postal_code,
							ProviderBusinessMailingAddressCountryCode = mailingAddress?.Country_code,
							ProviderBusinessMailingAddressTelephoneNumber = mailingAddress?.Telephone_number,
							ProviderFirstLineBusinessPracticeLocationAddress = locationAddress?.Address_1,
							ProviderSecondLineBusinessPracticeLocationAddress = locationAddress?.Address_2,
							ProviderBusinessPracticeLocationAddressCityName = locationAddress?.City,
							ProviderBusinessPracticeLocationAddressStateName = locationAddress?.State,
							ProviderBusinessPracticeLocationAddressPostalCode = locationAddress?.Postal_code,
							ProviderBusinessPracticeLocationAddressCountryCode = locationAddress?.Country_code,
							ProviderBusinessPracticeLocationAddressTelephoneNumber = locationAddress?.Telephone_number
						});
					}
					
					return npiData;
				}
			}
			catch
			{
				return await _repository.SearchNpi(npi, firstName, lastName, state);
			}
		}

		public async Task<IEnumerable<CmsData>> SearchCmsByName(string firstName, string lastName, string state)
		{
			return await _repository.SearchCms(null, firstName, lastName, state);
		}

		public async Task<IEnumerable<NpiData>> SearchNpiByNumber(string npi)
		{
			var cmsResult = await SearchCmsByNumber(npi);
			var npiResult = await SearchNpi(npi);

			return MergeNpiAndCms(npiResult, cmsResult);
		}

		public async Task<IEnumerable<CmsData>> SearchCmsByNumber(string npi)
		{
			return await _repository.SearchCms(npi);
		}


		private IEnumerable<NpiData> MergeNpiAndCms(IEnumerable<NpiData> npiSet, IEnumerable<CmsData> cmsSet)
		{
			if (npiSet == null || cmsSet == null)
			{
				return npiSet;
			}

			if (npiSet.Any())
			{
				foreach (var npi in npiSet)
				{
					foreach (var cms in cmsSet)
					{
						if (cms.Npi.Equals(npi.NPI, StringComparison.OrdinalIgnoreCase))
						{
							npi.HealthcareProviderTaxonomyCode = cms.ProviderTaxonomyCode;
							npi.ProviderLicenseNumber = cms.LicenseNumber;
							npi.ProviderLicenseNumberStateCode = cms.LicenseState;
							npi.ProviderFirstName = cms.ProviderFirstName;
							npi.ProviderLastName = cms.ProviderLastName;
							npi.ProviderType = cms.ProviderType;

							break;
						}
					}
				}
			}
			else
			{
				npiSet = cmsSet.Select(c => new NpiData
				{
					NPI = c.Npi,
					ProviderFirstName = c.ProviderFirstName,
					ProviderLastName = c.ProviderLastName,
					HealthcareProviderTaxonomyCode = c.ProviderTaxonomyCode,
					HealthcareProviderTaxonomyDescription = c.ProviderTaxonomyDescription,
					ProviderType = c.ProviderType,
					ProviderLicenseNumberStateCode = c.LicenseState,
					ProviderLicenseNumber = c.LicenseNumber
				});
			}

			return npiSet;
		}
	}

	public class NpiRegistry
    {
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
    }

	public class NppesResults
	{
		public long Result_count { get; set; }
    	public IList<NppesResult> Results { get; set; }
	}

	public class NppesResult
	{
		public string Created_epoch { get; set; }
		public string Enumeration_type { get; set; }
		public string Last_updated_epoch { get; set; }
		public string Number { get; set; }
		public NppesBasic Basic {get; set;}
		public IList<NppesAddress> Addresses { get; set; }
        public IList<NppesPracticeLocation> PracticeLocations { get; set; }
        public IList<NppesTaxonomy> Taxonomies { get; set; }
        public IList<NppesIdentifier> Identifiers { get; set; }
		public IList<NppesOtherName> Other_names { get; set; }
		public IList<NppesEndpoint> Endpoints { get; set; }
	}

	public class NppesBasic
	{
		public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Middle_name { get; set; }
        public string Credential { get; set; }
        public string Sole_proprietor { get; set; }
        public string Gender { get; set; }
        public DateTime? Enumeration_date { get; set; }
        public DateTime? Last_updated { get; set; }
        public string Status { get; set; }
        public string Name_prefix { get; set; }
        public string Name_suffix { get; set; }
	}

	public class NppesAddress
	{
		public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Address_purpose { get; set; }
        public string Address_type { get; set; }
        public string Address_1 { get; set; }
		public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_code { get; set; }
        public string Telephone_number { get; set; }
		public string Fax_number { get; set; }
	}

	public class NppesPracticeLocation
	{
		public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Address_purpose { get; set; }
        public string Address_type { get; set; }
        public string Address_1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_code { get; set; }
        public string Telephone_number { get; set; }
        public string Fax_number { get; set; }
	}

	public class NppesTaxonomy
	{
		public string Code { get; set; }
        public string Taxonomy_group { get; set; }
        public string Desc { get; set; }
        public string State { get; set; }
        public string License { get; set; }
        public bool Primary { get; set; }
	}

	public class NppesIdentifier
	{
		public string Code { get; set; }
        public string Desc { get; set; }
        public string Issuer { get; set; }
        public string Identifier { get; set; }
        public string State { get; set; }
	}
	
	public class NppesOtherName
	{
		public string Type { get; set; }
        public string Code { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Middle_name { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
	}
	
	public class NppesEndpoint
	{
		public string EndpointType { get; set; }
        public string EndpointTypeDescription { get; set; }
        public string Endpoint { get; set; }
        public string Affiliation { get; set; }
        public string UseDescription { get; set; }
        public string ContentTypeDescription { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Address_type { get; set; }
        public string Address_1 { get; set; }
		public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_code { get; set; }
	}
}
