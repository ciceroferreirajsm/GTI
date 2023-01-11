using AppWebMVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWebMVC.Integration
{
    public class IntegrationService
    {
        private readonly RestClient _client = new RestClient("http://localhost:5001/");

        public async Task<DadosPessoaisResponse> ObterTodos()
        {
            var request = new RestRequest("Cliente");
            var response = await _client.ExecuteGetAsync<List<DadosPessoais>>(request);

            return JsonConvert.DeserializeObject<DadosPessoaisResponse>(response.Content);
        }

        public DadosPessoaisResponse FiltrarDados(int Id, string CEP)
        {
            var retorno = ObterTodos().Result;

            retorno.DadosPessoais = retorno.ListDadosPessoais.Find(x => x.EnderecoCliente.CEP == CEP && x.DadosCliente.IdUsuario == Id);

            return retorno;
        }

        public async Task<DadosPessoaisResponse> CriarDados(DadosPessoais dadosPessoais)
        {
            var request = new RestRequest("Cliente")
                  .AddJsonBody(dadosPessoais);
            var response = await _client.ExecutePostAsync<DadosPessoais>(request);

            return JsonConvert.DeserializeObject<DadosPessoaisResponse>(response.Content);
        }

        public async Task<DadosPessoaisResponse> AtualizarDadosAsync(DadosPessoais dadosPessoais)
        {
            var request = new RestRequest("Cliente")
                  .AddHeader("CPF", dadosPessoais.DadosCliente.CPF)
                  .AddHeader("CEP", dadosPessoais.EnderecoCliente.CEP)
                  .AddJsonBody(dadosPessoais);
            var response = await _client.ExecutePutAsync<DadosPessoais>(request);

            return JsonConvert.DeserializeObject<DadosPessoaisResponse>(response.Content);
        }

        public async Task<DadosPessoaisResponse> DeletarDados(DadosPessoais dadosPessoais)
        {
            var request = new RestRequest("Cliente")
                  .AddHeader("CPF", dadosPessoais.DadosCliente.CPF)
                  .AddHeader("CEP", dadosPessoais.EnderecoCliente.CEP);

            var response = await _client.ExecuteAsync<DadosPessoais>(request);

            return JsonConvert.DeserializeObject<DadosPessoaisResponse>(response.Content);
        }
    }
}
;