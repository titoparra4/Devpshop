using Devpshop.Shared.Responses;

namespace Devpshop.API.Services
{
	public interface IApiService
	{
		Task<Response> GetListAsync<T>(string servicePrefix, string controller);
	}

}
