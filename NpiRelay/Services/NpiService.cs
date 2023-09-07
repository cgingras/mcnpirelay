using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		public NpiService(IRepository repository)
		{
			_repository = repository;
		}


		public async Task<IEnumerable<NpiData>> SearchNpiByName(string firstName, string lastName, string state)
		{
			var cmsResult = await SearchCmsByName(firstName, lastName, state);
			var npiResult = await _repository.SearchNpi(null, firstName, lastName, state);

			return MergeNpiAndCms(npiResult, cmsResult);
		}

		public async Task<IEnumerable<CmsData>> SearchCmsByName(string firstName, string lastName, string state)
		{
			return await _repository.SearchCms(null, firstName, lastName, state);
		}

		public async Task<IEnumerable<NpiData>> SearchNpiByNumber(string npi)
		{
			var cmsResult = await SearchCmsByNumber(npi);
			var npiResult = await _repository.SearchNpi(npi);

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
}
