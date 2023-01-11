using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationSolution.WebMVC.Models
{
    public class DadosPessoais
    {
        public Cliente DadosCliente { get; set; }
        public EnderecoCliente EnderecoCliente { get; set; }
    }
}
