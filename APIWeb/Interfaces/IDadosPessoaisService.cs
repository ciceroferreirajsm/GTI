using WebApplicationSolution.APIWeb.Models;

namespace APIWeb.Interfaces
{
    public interface IDadosPessoaisService
    {
        DadosPessoaisResponse CriarDadosPessoais(DadosPessoais dadosPessoais);
        DadosPessoaisResponse AtualizarDadosPessoais(string cpf, string CEP, DadosPessoais dadosPessoais);
        DadosPessoaisResponse DeletarDadosPessoais(string cpf, string CEP);

        DadosPessoaisResponse ObterTodosOsDadosPessoais();
    }
}
