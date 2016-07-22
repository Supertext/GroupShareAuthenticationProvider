using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Supertext.GroupShare.AuthenticationProvider
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient httpClient;

        public HttpClientWrapper()
        {
            httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return await httpClient.GetAsync(requestUri);
        }
    }
}