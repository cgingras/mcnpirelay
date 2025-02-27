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
    public class SearchByNameController : ControllerBase
    {
        private readonly INpiService _service;
        private readonly NPPESApiClient _nppesApiClient;

        public SearchByNameController(INpiService service, NPPESApiClient nppesApiClient)
        {
            _service = service;
            _nppesApiClient = nppesApiClient;
        }

        [HttpGet]
        [Route("search-by-name")]
        public async Task<IEnumerable<NPPESResult>> Get(string firstName, string lastName)
        {
            var response = await _nppesApiClient.SearchAsync(new NPPESRequest
            {
                FirstName = firstName,
                LastName = lastName
            });

            return response.Results;
        }

        [HttpGet]
        [Route("search-db-by-name")]
        public async Task<IEnumerable<NpiData>> GetFromDb(string firstName, string lastName, string state, string pageNumber, string pageSize)
        {

            var pageNumberInt = int.Parse(pageNumber);
            var pageSizeInt = int.Parse(pageSize);

            pageNumberInt = pageNumberInt > 0 ? pageNumberInt : 1;
            pageSizeInt = pageSizeInt <= 2000 ? pageSizeInt : 20;
            
            return await _service.SearchNpiByName(firstName, lastName, state, pageNumberInt, pageSizeInt);
        }

        [HttpGet]
        [Route("search-cms-db-by-name")]
        public async Task<IEnumerable<CmsData>> GetCmsFromDb(string firstName, string lastName, string state, string pageNumber, string pageSize)
        {
            var pageNumberInt = int.Parse(pageNumber);
            var pageSizeInt = int.Parse(pageSize);

            pageNumberInt = pageNumberInt > 0 ? pageNumberInt : 1;
            pageSizeInt = pageSizeInt <= 2000 ? pageSizeInt : 20;

            return await _service.SearchCmsByName(firstName, lastName, state, pageNumberInt, pageSizeInt);
        }
    }
}