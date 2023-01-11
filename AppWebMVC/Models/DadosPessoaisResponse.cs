using AppWebMVC.Models;
using System.Collections.Generic;

namespace AppWebMVC.Models
{
    public class DadosPessoaisResponse
    {
        public string Mensagem { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public List<DadosPessoais> ListDadosPessoais { get; set; }
    }
}
