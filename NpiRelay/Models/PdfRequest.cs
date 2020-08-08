using System.ComponentModel.DataAnnotations;

namespace NpiRelay.Models
{
	public class PdfRequest
	{
		public string FileName { get; set; }

		[Required]
		public string HtmlText { get; set; }
	}
}