using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.Rest
{
    public class RestService : IRestService
    {
        public Task<TResult> DeleteAsync<TResult>(string resource, object requestBody, Dictionary<string, string> additionalHeaders = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> GetAsync<TResult>(string resource, Dictionary<string, string> additionalHeaders = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> PostAsync<TResult>(string resource, object requestBody, Dictionary<string, string> additionalHeaders = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> PutAsync<TResult>(string resource, object requestBody, Dictionary<string, string> additionalHeaders = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
