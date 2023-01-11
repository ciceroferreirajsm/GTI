using System.Collections.Generic;
using WebApplicationSolution.APIWeb.Models;

namespace APIWeb.Interfaces
{
    public interface IDadosPessoaisRepository
    {
        DadosPessoais CriarDadosPessoais(DadosPessoais dadosPessoais);
        DadosPessoais AtualizarDadosPessoais(string CPF, string CEP, DadosPessoais dadosPessoais);
        bool DeletarDadosPessoais(string CPF, string CEP);

        List<EnderecoCliente> ObterTodosEnderecos();

        List<Cliente> ObterTodosClientes();
    }
}
