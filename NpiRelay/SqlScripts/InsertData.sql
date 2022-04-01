-- CMS
INSERT INTO CmsRecords 
(
     [Npi]
    ,[CreatedAt]
    ,[ProviderFirstName]
    ,[ProviderLastName]
    ,[ProviderTaxonomyCode]
    ,[ProviderType]
    ,[LicenseState]
    ,[LicenseNumber]
)
VALUES 
(
     '1013432772'
    , GETDATE()
    ,'ROBERT'
    ,'GREEN'
    ,'207LC0200X'
    ,'Physician/Anesthesiology'
    ,'CA'
    ,'A45128'
)

-- NPI
INSERT INTO NpiRecords 
(
     [Npi]
    ,[CreatedAt]
    ,[EntityTypeCode]
    ,[EmployerIdentificationNumber]
    ,[ProviderOrganizationName]
    ,[ProviderLastName]
    ,[ProviderFirstName]
    ,[ProviderMiddleName]
    ,[ProviderNamePrefixText]
    ,[ProviderNameSuffixText]
    ,[ProviderCredentialText]
    ,[ProviderGenderCode]
    ,[ProviderOtherOrganizationName]
    ,[ProviderOtherOrganizationNameTypeCode]
    ,[ProviderFirstLineBusinessMailingAddress]
    ,[ProviderSecondLineBusinessMailingAddress]
    ,[ProviderBusinessMailingAddressCityName]
    ,[ProviderBusinessMailingAddressStateName]
    ,[ProviderBusinessMailingAddressPostalCode]
    ,[ProviderBusinessMailingAddressCountryCode]
    ,[ProviderBusinessMailingAddressTelephoneNumber]
    ,[ProviderFirstLineBusinessPracticeLocationAddress]
    ,[ProviderSecondLineBusinessPracticeLocationAddress]
    ,[ProviderBusinessPracticeLocationAddressCityName]
    ,[ProviderBusinessPracticeLocationAddressStateName]
    ,[ProviderBusinessPracticeLocationAddressPostalCode]
    ,[ProviderBusinessPracticeLocationAddressCountryCode]
    ,[ProviderBusinessPracticeLocationAddressTelephoneNumber]
    ,[HealthcareProviderTaxonomyCode]
    ,[ProviderLicenseNumber]
    ,[ProviderLicenseNumberStateCode]
)
VALUES 
(
     '1487992970'
    , GETDATE()
    , 13
    , null
    ,'CENTRAL HOSPITAL'
    ,'DAVIDSON'
    ,'JENIFER'
    ,'MONICA'
    ,'DR.'
    , null
    ,'D.P.M.'
    ,'F'
    , null
    , null
    ,'600 HIGHLAND AVENUE'
    ,'5275 F STREET'
    ,'NEW YORK'
    ,'NY'
    ,'100217117'
    ,'US'
    ,'2127343427'
    ,'6235 N FRESNO ST'
    ,'6235 N FRESNO ST'
    ,'NEW YORK'
    ,'NY'
    ,'100217117'
    ,'US'
    ,'985478658'
    ,'2084N0400X'
    ,'25MA09316000'
    ,'NJ'
)