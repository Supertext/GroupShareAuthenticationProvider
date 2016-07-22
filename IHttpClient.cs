using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Supertext.GroupShare.AuthenticationProvider
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(Uri requestUri);
    }
}