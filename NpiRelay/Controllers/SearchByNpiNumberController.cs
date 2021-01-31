using System.Collections.Generic;
using System.Threading.Tasks;

using Forcura.NPPES;
using Forcura.NPPES.Models;

using Microsoft.AspNetCore.Mvc;

using NpiRelay.Services;

namespace NpiRelay.Controllers
{
	[Route("api")]
	[ApiController]
	public class SearchByNpiNumberController : ControllerBase
	{
		private readonly INpiService _service;

		public SearchByNpiNumberController(INpiService service)
		{
			_service = service;
		}

		[HttpGet]
		[Route("search-by-npi-number")]
		public async Task<IEnumerable<NPPESResult>> Get(string npi)
		{
			var response = await NPPESApiClient.SearchAsync(new NPPESRequest
			{
				Number = npi
			});

			return response.Results;
		}

		[HttpGet]
		[Route("search-db-by-npi-number")]
		public async Task<IEnumerable<NpiData>> GetFromDb(string npi)
		{
			return await _service.SearchNpiByNumber(npi);
		}

		[HttpGet]
		[Route("search-cms-db-by-npi-number")]
		public async Task<IEnumerable<CmsData>> GetCmsFromDb(string npi)
		{
			return await _service.SearchCmsByNumber(npi);
		}
	}
}
