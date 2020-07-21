using System.Collections.Generic;
using System.Threading.Tasks;

using Forcura.NPPES;
using Forcura.NPPES.Models;

using Microsoft.AspNetCore.Mvc;
namespace NpiRelay.Controllers
{
	[Route("api")]
	[ApiController]
	public class SearchByNpiNumberController : ControllerBase
	{
		[HttpGet]
		[Route("search-by-npi-number")]
		public async Task<IEnumerable<NPPESResult>> Get(string npiNumber)
		{
			var response = await NPPESApiClient.SearchAsync(new NPPESRequest
			{
				Number = npiNumber
			});

			return response.Results;
		}
	}
}
