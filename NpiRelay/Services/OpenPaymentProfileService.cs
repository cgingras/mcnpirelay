using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NpiRelay.Services
{
	public interface IOpenPaymentProfileService
	{
		Task<OpenPaymentProfile> GetOpenPaymentProfile(string npiNumber);
	}

	public class OpenPaymentProfileService : IOpenPaymentProfileService
	{
		private readonly IRepository _repository;

		public OpenPaymentProfileService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<OpenPaymentProfile> GetOpenPaymentProfile(string npiNumber)
		{
			return await _repository.GetOpenPaymentProfile(npiNumber);
		}
	}
}
