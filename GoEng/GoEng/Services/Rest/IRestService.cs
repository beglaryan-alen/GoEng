using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.Rest
{
    public interface IRestService
    {
        Task<TResult> GetAsync<TResult>(string resource, Dictionary<string, string> additionalHeaders = null);

        Task<TResult> PostAsync<TResult>(string resource, object requestBody, Dictionary<string, string> additionalHeaders = null);

        Task<TResult> PutAsync<TResult>(string resource, object requestBody, Dictionary<string, string> additionalHeaders = null);

        Task<TResult> DeleteAsync<TResult>(string resource, object requestBody, Dictionary<string, string> additionalHeaders = null);
    }
}
