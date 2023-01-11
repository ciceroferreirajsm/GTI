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
    public class IntegrationService
    {
        private readonly RestClient _client = new RestClient("http://localhost:5001/");
        //public async Task<DadosPessoais> CriarDados(DadosPessoais dadosPessoais)
        //{
        //    try
        //    {
        //        return await CreateRequest(dadosPessoais);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public async Task<DadosPessoais> CriarDados(DadosPessoais dadosPessoais)
        {
            try
            {
                var request = new RestRequest("Cliente")
                   .AddJsonBody(dadosPessoais);
                var response = await _client.ExecutePostAsync<DadosPessoais>(request);
                if (!response.IsSuccessful)
                {
                    //Logic for handling unsuccessful response
                }

                return dadosPessoais;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<DadosPessoais> CreateRequest(DadosPessoais dadosPessoais)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(dadosPessoais);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"http://localhost:5001/Cliente/", content, CancellationToken.None);
                var jsonString = await response.Content.ReadAsStringAsync();

                DadosPessoais jsonObject = JsonConvert.DeserializeObject<DadosPessoais>(jsonString);

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
