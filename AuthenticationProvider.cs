using System;
using System.Configuration;
using System.Net;
//using log4net;
using Sdl.StudioServer.Api.Core;


namespace Supertext.GroupShare.AuthenticationProvider
{
    [CustomAuthenticationProviderExtention(CanValidateUserExistance = true)]
    public class AuthenticationProvider : ICustomAuthenticationProvider
    {
        public const string DefaultAuthenticationApi = "https://www.supertext.ch/api/v1/authenticate/";

        //private static readonly ILog log = LogManager.GetLogger(typeof(AuthenticationProvider));
        private readonly IHttpClient httpClient;
        private readonly string authenticationApi;


        public AuthenticationProvider() : this(new HttpClientWrapper())
        {
        }


        public AuthenticationProvider(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.authenticationApi = ConfigurationManager.AppSettings["SupertextAuthenticationApi"] ?? DefaultAuthenticationApi;
        }


        public bool UserExists(string userName)
        {
            try
            {
                var requestUri = new Uri(new Uri(authenticationApi), userName);
                var response = httpClient.GetAsync(requestUri).Result;

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ValidateCredentials(string userName, string password)
        {
            try
            {
                var requestUri = new Uri(new Uri(authenticationApi), userName+"/"+password);
                var response = httpClient.GetAsync(requestUri).Result;

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}