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
    public class SearchByNameController : ControllerBase
    {
	    private readonly Repository _repository;

	    public SearchByNameController(IConfiguration configuration)
	    {
		    _repository = new Repository(configuration);
	    }

		[HttpGet]
		[Route("search-by-name")]
		public async Task<IEnumerable<NPPESResult>> Get(string firstName, string lastName)
		{
			var response = await NPPESApiClient.SearchAsync(new NPPESRequest
			{
				FirstName = firstName,
				LastName = lastName
			});

			return response.Results;
		}

		[HttpGet]
		[Route("search-db-by-name")]
		public async Task<IEnumerable<NpiData>> GetFromDb(string firstName, string lastName, string state)
		{
			return await _repository.SearchNpi(null, firstName, lastName, state);
		}

		[HttpGet]
		[Route("search-cms-db-by-name")]
		public async Task<IEnumerable<CmsData>> GetCmsFromDb(string firstName, string lastName, string state)
		{
			return await _repository.SearchCms(null, firstName, lastName, state);
		}
	}
}
