using System;

namespace NpiRelay
{
	public class CmsData
	{
		public long Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Npi { get; set; }

		public string ProviderFirstName { get; set; }

		public string ProviderLastName { get; set; }

		public string ProviderTaxonomyCode { get; set; }

		public string ProviderType { get; set; }

		public string LicenseState { get; set; }

		public string LicenseNumber { get; set; }
	}
}
