
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NpiRelay.Models
{
    public class Taxonomy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}