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
    public class SearchByNpiNumberController : ControllerBase
    {
        [HttpGet]
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
