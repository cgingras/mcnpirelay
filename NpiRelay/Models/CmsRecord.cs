
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NpiRelay.Models
{
	public class CmsRecord
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(10)]
        public string Npi { get; set; }
        [MaxLength(50)]
        public string ProviderFirstName { get; set; }
        [MaxLength(50)]
        public string ProviderLastName { get; set; }
        [MaxLength(50)]
        public string ProviderTaxonomyCode { get; set; }
        [MaxLength(50)]
        public string ProviderType { get; set; }
        [MaxLength(10)]
        public string LicenseState { get; set; }
        [MaxLength(50)]
        public string LicenseNumber { get; set; }
	}
}