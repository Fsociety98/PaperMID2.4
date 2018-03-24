using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PaperMID.WebService
{
    public class ServicioAPI
    {
        public HttpClient Cliente;
        private MediaTypeWithQualityHeaderValue contentType;
        private string Url = "http://localhost:50949";
        public ServicioAPI()
        {
            contentType = new MediaTypeWithQualityHeaderValue("application/json");
            Cliente = new HttpClient()
            {
                BaseAddress = new Uri(Url)
            };
            Cliente.DefaultRequestHeaders.Accept.Add(contentType);
        }
    }
}