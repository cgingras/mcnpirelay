using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.PdfViewer;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Microsoft.Extensions.Caching.Memory;
using NpiRelay.Services;
using Microsoft.AspNetCore.Cors;
using NpiRelay;

namespace MedCompli.Web.Controllers
{
	[ApiController]
	[Route("api/pdf-viewer")]
	[EnableCors(Startup.PdfViewerPolicy)]
	public class PdfViewerController : ControllerBase
	{
		private IMemoryCache _cache;
		private IPdfService _pdfService;

		public PdfViewerController(
			IMemoryCache cache,
			IPdfService pdfService)
		{
			_cache = cache;
			_pdfService = pdfService;
		}

		[HttpPost("Load")]
		//Post action for Loading the PDF documents   
		public async Task<IActionResult> Load([FromBody] Dictionary<string, string> jsonObject)
		{
			Console.WriteLine("Load called");
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			MemoryStream stream = new MemoryStream();
			object jsonResult = new object();
			if (jsonObject != null && jsonObject.ContainsKey("document"))
			{
				if (bool.Parse(jsonObject["isFileName"]))
				{
					if (!string.IsNullOrWhiteSpace(jsonObject["document"]))
					{
						stream = await _pdfService.DownloadFileAsync(jsonObject["document"]);
					}
					else
					{
						return this.Content(jsonObject["document"] + " is not found");
					}
				}
				else
				{
					byte[] bytes = Convert.FromBase64String(jsonObject["document"]);
					stream = new MemoryStream(bytes);
				}
			}
			jsonResult = pdfviewer.Load(stream, jsonObject);
			return Content(JsonConvert.SerializeObject(jsonResult));
		}

		[HttpPost("Bookmarks")]
		//Post action for processing the bookmarks from the PDF documents
		public IActionResult Bookmarks([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			var jsonResult = pdfviewer.GetBookmarks(jsonObject);
			return Content(JsonConvert.SerializeObject(jsonResult));
		}

		[HttpPost("RenderPdfPages")]
		//Post action for processing the PDF documents  
		public IActionResult RenderPdfPages([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			object jsonResult = pdfviewer.GetPage(jsonObject);
			return Content(JsonConvert.SerializeObject(jsonResult));
		}

		[HttpPost("RenderPdfTexts")]
		public object RenderPdfTexts(Dictionary<string, string> jsonObject)
		{
			PdfRenderer pdfviewer = new PdfRenderer();
			object result = pdfviewer.GetDocumentText(jsonObject);
			return (JsonConvert.SerializeObject(result));
		}

		[HttpPost("RenderThumbnailImages")]
		//Post action for rendering the ThumbnailImages
		public IActionResult RenderThumbnailImages([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			object result = pdfviewer.GetThumbnailImages(jsonObject);
			return Content(JsonConvert.SerializeObject(result));
		}

		[HttpPost("RenderAnnotationComments")]
		//Post action for rendering the annotations
		public IActionResult RenderAnnotationComments([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			object jsonResult = pdfviewer.GetAnnotationComments(jsonObject);
			return Content(JsonConvert.SerializeObject(jsonResult));
		}

		[HttpPost("ExportAnnotations")]
		//Post action to export annotations
		public IActionResult ExportAnnotations([FromBody] Dictionary<string, string> jsonObject)
		{
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			string jsonResult = pdfviewer.GetAnnotations(jsonObject);
			return Content(jsonResult);
		}

		[HttpPost("ImportAnnotations")]
		//Post action to import annotations
		public async Task<IActionResult> ImportAnnotations([FromBody] Dictionary<string, string> jsonObject)
		{
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			string jsonResult = string.Empty;
			if (jsonObject != null && jsonObject.ContainsKey("fileName"))
			{
				if (!string.IsNullOrWhiteSpace(jsonObject["document"]))
				{
					using (var stream = await _pdfService.DownloadFileAsync(jsonObject["document"]))
					using (var streamReader = new StreamReader(stream))
					{
						jsonResult = await streamReader.ReadToEndAsync();
					}
				}
				else
				{
					return this.Content(jsonObject["document"] + " is not found");
				}
			}
			return Content(jsonResult);
		}

		[HttpPost("ExportFormFields")]
		public IActionResult ExportFormFields([FromBody] Dictionary<string, string> jsonObject)

		{
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			string jsonResult = pdfviewer.ExportFormFields(jsonObject);
			return Content(jsonResult);
		}

		[HttpPost("ImportFormFields")]
		public IActionResult ImportFormFields([FromBody] Dictionary<string, string> jsonObject)
		{
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			object jsonResult = pdfviewer.ImportFormFields(jsonObject);
			return Content(JsonConvert.SerializeObject(jsonResult));
		}

		[HttpPost("Unload")]
		//Post action for unloading and disposing the PDF document resources  
		public IActionResult Unload([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			pdfviewer.ClearCache(jsonObject);
			return this.Content("Document cache is cleared");
		}


		[HttpPost("Download")]
		//Post action for downloading the PDF documents
		public IActionResult Download([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			string documentBase = pdfviewer.GetDocumentAsBase64(jsonObject);
			return Content(documentBase);
		}

		[HttpPost("PrintImages")]
		//Post action for printing the PDF documents
		public IActionResult PrintImages([FromBody] Dictionary<string, string> jsonObject)
		{
			//Initialize the PDF Viewer object with memory cache object
			PdfRenderer pdfviewer = new PdfRenderer(_cache);
			object pageImage = pdfviewer.GetPrintImage(jsonObject);
			return Content(JsonConvert.SerializeObject(pageImage));
		}
	}
}