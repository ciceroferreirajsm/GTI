using System.Collections.Generic;

namespace WebApplicationSolution.APIWeb.Models
{
    public class DadosPessoaisResponse
    {
        public string Mensagem { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public List<DadosPessoais> ListDadosPessoais { get; set; }
    }
}
