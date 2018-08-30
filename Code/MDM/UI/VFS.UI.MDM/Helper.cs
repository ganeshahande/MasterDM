using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace VFS.UI.MDM
{
    public class APIClientHelper
    {
        private string _apiBaseURI = "http://localhost:51749";
        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            //Passing service base url  
            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }    
}
