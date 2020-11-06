using System.Net;

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
					SearchDatabaseByNpi = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/search-db-by-npi-number?npi="),
					SearchNPPESApiByNpi = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/search-by-npi-number?npi="),
					SearchDatabaseByFirstAndLastName = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/search-db-by-name?firstName=&lastName=&state="),
					SearchNPPESApiByFirstAndLastName = UriHelper.BuildAbsolute(Request.Scheme, Request.Host, Request.PathBase, "/search-by-name?firstName=&lastName=")
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
