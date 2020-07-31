using System.Collections.Generic;
using System.Threading.Tasks;

using Forcura.NPPES;
using Forcura.NPPES.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NpiRelay.Controllers
{
	[Route("api")]
	[ApiController]
	public class SearchByNpiNumberController : ControllerBase
	{
		private readonly Repository _repository;

		public SearchByNpiNumberController(IConfiguration configuration)
		{
			_repository = new Repository(configuration);
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
			return await _repository.SearchNpi(npi);
		}
	}
}
