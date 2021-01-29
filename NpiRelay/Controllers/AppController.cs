using System.Net;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

using NpiRelay.Configuration;

namespace NpiRelay.Controllers
{
	[Route("")]
	[ApiController]
	public class AppController : Controller
	{
		[HttpGet("/")]
		[HttpGet("/index.html")]
		public IActionResult Info()
		{
			var result = new
			{
				Application = "NpiRelayApi",
				MachineName = ApplicationProperties.Instance.Host,
				Version = new
				{
					ApplicationProperties.Instance.AssemblyName,
					ApplicationProperties.Instance.Version,
					ApplicationProperties.Instance.TargetFrameWork,
					ApplicationProperties.Instance.BuildHash,
					ApplicationProperties.Instance.BuildDate
				},
				Info = new
				{
					SearchDatabaseByNpi = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/api/search-db-by-npi-number", new QueryString("?npi=")),
					SearchDatabaseByFirstAndLastName = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/api/search-db-by-name", new QueryString("?firstName=&lastName=&state=")),
					SearchCmsDatabaseByNpi = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/api/search-cms-db-by-npi-number", new QueryString("?npi=")),
					SearchCmsDatabaseByFirstAndLastName = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/api/search-cms-db-by-name", new QueryString("?firstName=&lastName=&state=")),
					SearchNPPESApiByNpi = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/api/search-by-npi-number", new QueryString("?npi=")),
					SearchNPPESApiByFirstAndLastName = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/api/search-by-name", new QueryString("?firstName=&lastName="))
				},
				Tuning = new
				{
					HttpWebRequestConnectionLimit = ServicePointManager.DefaultConnectionLimit
				}
			};

			return Ok(result);
		}
	}
}
