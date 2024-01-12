using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NpiRelay.Services;


namespace NpiRelay.Controllers
{
    [Route("api/open-payments")]
	[ApiController]
	public class OpenPaymentsController : ControllerBase
	{
        private readonly IOpenPaymentProfileService _service;
        public OpenPaymentsController(IOpenPaymentProfileService service)
        {
            _service = service;
        }

        [HttpGet]
		[Route("profiles")]
		public async Task<OpenPaymentProfile> GetOpenPaymentProfile(string npiNumber)
		{
			return await _service.GetOpenPaymentProfile(npiNumber);
		}
    }
}