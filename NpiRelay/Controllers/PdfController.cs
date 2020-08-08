using Microsoft.AspNetCore.Mvc;
using NpiRelay.Services;
using NpiRelay.Models;
using System.IO;

namespace NpiRelay.Controllers
{
	[Route("api/pdf")]
	[ApiController]
	public class PdfController : ControllerBase
	{
		private readonly IPdfService _pdfService;

		public PdfController(IPdfService pdfService)
		{
			_pdfService = pdfService;
		}

		[HttpPost("html")]
		public IActionResult ConvertHtml([FromBody] PdfRequest request)
		{
			if (this.ModelState.IsValid)
			{
				var stream = _pdfService.ConvertHtml(request.HtmlText);

				var fileName = string.IsNullOrEmpty(request.FileName)
					? string.Empty
					: Path.ChangeExtension(request.FileName, "pdf");

				return File(stream, "application/pdf", fileName);
			}

			return BadRequest(this.ModelState);
		}
	}
}