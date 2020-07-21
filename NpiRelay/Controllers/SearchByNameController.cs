using System.Collections.Generic;
using System.Threading.Tasks;

using Forcura.NPPES;
using Forcura.NPPES.Models;

using Microsoft.AspNetCore.Mvc;
namespace NpiRelay.Controllers
{
	[Route("api")]
    [ApiController]
    public class SearchByNameController : ControllerBase
    {
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

	}
}
