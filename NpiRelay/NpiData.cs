using System;

namespace NpiRelay
{
	public class NpiData
	{
		public string NPI { get; set; }

		public string EmployerIdentificationNumber { get; set; }

		public string ProviderOrganizationName { get; set; }

		public string ProviderLastName { get; set; }

		public string ProviderFirstName { get; set; }

		public string ProviderMiddleName { get; set; }

		public string ProviderNamePrefixText { get; set; }

		public string ProviderNameSuffixText { get; set; }

		public string ProviderCredentialText { get; set; }

		public string ProviderOtherOrganizationName { get; set; }

		public string ProviderOtherOrganizationNameTypeCode { get; set; }

		public string ProviderFirstLineBusinessMailingAddress { get; set; }

		public string ProviderSecondLineBusinessMailingAddress { get; set; }

		public string ProviderBusinessMailingAddressCityName { get; set; }

		public string ProviderBusinessMailingAddressStateName { get; set; }

		public string ProviderBusinessMailingAddressPostalCode { get; set; }

		public string ProviderBusinessMailingAddressCountryCode { get; set; }

		public string ProviderBusinessMailingAddressTelephoneNumber { get; set; }

		public string ProviderFirstLineBusinessPracticeLocationAddress { get; set; }

		public string ProviderSecondLineBusinessPracticeLocationAddress { get; set; }

		public string ProviderBusinessPracticeLocationAddressCityName { get; set; }

		public string ProviderBusinessPracticeLocationAddressStateName { get; set; }

		public string ProviderBusinessPracticeLocationAddressPostalCode { get; set; }

		public string ProviderBusinessPracticeLocationAddressCountryCode { get; set; }

		public string ProviderBusinessPracticeLocationAddressTelephoneNumber { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string HealthcareProviderTaxonomyCode_1 { get; set; }

		public string ProviderLicenseNumber_1 { get; set; }

		public string ProviderLicenseNumberStateCode_1 { get; set; }

		public string HealthcareProviderTaxonomyCode_2 { get; set; }

		public string ProviderLicenseNumber_2 { get; set; }

		public string ProviderLicenseNumberStateCode_2 { get; set; }
	}
}
