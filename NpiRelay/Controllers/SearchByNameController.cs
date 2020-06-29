using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Forcura.NPPES;
using Forcura.NPPES.Models;
namespace NpiRelay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchByNameController : ControllerBase
    {
		[HttpGet]
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
