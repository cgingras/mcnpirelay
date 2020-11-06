using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NpiRelay.Services
{
	public class PdfService : IPdfService
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly PdfConfig _config;
		private readonly HttpClient _httpClient;

		public PdfService(
			IWebHostEnvironment webHostEnvironment,
			IOptions<PdfConfig> config,
			HttpClient httpClient)
		{
			_webHostEnvironment = webHostEnvironment;
			_config = config.Value;
			_httpClient = httpClient;
		}

		private string GetWebKitPath()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				return Path.Combine(_webHostEnvironment.ContentRootPath, _config.WebKitLinuxPath);
			}

			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				return Path.Combine(_webHostEnvironment.ContentRootPath, _config.WebKitOsxPath);
			}

			// Defaults to Windows.
			return Path.Combine(_webHostEnvironment.ContentRootPath, _config.WebKitWindowsPath);
		}

		public MemoryStream ConvertHtml(string htmlText)
		{
			HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);

			WebKitConverterSettings settings = new WebKitConverterSettings
			{
				EnableJavaScript = false
			};

			string baseUrl = _webHostEnvironment.ContentRootPath.TrimEnd('/') + "/Temp/HTMLFiles/";

			//Set WebKit path
			settings.WebKitPath = GetWebKitPath();

			//Assign WebKit settings to HTML converter
			htmlConverter.ConverterSettings = settings;

			//Convert HTML string to PDF
			PdfDocument document = htmlConverter.Convert(htmlText, baseUrl);

			//Save the document into stream.
			MemoryStream stream = new MemoryStream();

			document.Save(stream);

			stream.Position = 0;

			//Close the document.
			document.Close(true);

			return stream;
		}

		public async Task<MemoryStream> DownloadFileAsync(string fileUrl)
		{
			if (fileUrl?.StartsWith(_config.BaseDownloadUrl) == true)
			{
				var fileContent = await _httpClient.GetByteArrayAsync(fileUrl);

				if (fileContent != null)
				{
					var memoryStream = new MemoryStream(fileContent);
					memoryStream.Seek(0, SeekOrigin.Begin);

					return memoryStream;
				}
			}

			return null;
		}
	}

	public interface IPdfService
	{
		MemoryStream ConvertHtml(string htmlText);

		Task<MemoryStream> DownloadFileAsync(string fileUrl);
	}

	public class PdfConfig
	{
		public string WebKitWindowsPath { get; set; }
		public string WebKitOsxPath { get; set; }
		public string WebKitLinuxPath { get; set; }
		public string BaseDownloadUrl { get; set; }
	}
}