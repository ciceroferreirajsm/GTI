using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationSolution.WebMVC.Models;

namespace WebMVC.Integration
{
    public class Integration
    {        
        public class IntegrationDTO
        {
            public string Url { get; set; }
            public object Body { get; set; }
            public string Token { get; set; }
            public string KeyGateway { get; set; }
        }
    }
}
