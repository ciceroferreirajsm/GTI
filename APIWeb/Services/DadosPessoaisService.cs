using APIWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebApplicationSolution.APIWeb.Models;

namespace APIWeb.Services
{
    public class DadosPessoaisService : IDadosPessoaisService
    {
        private readonly IDadosPessoaisRepository _dadosPessoaisRepository;

        public DadosPessoaisService(IDadosPessoaisRepository dadosPessoaisRepository)
        {
            _dadosPessoaisRepository = dadosPessoaisRepository;
        }

        public DadosPessoaisResponse AtualizarDadosPessoais(string cpf, string CEP, DadosPessoais dadosPessoais)
        {
            try
            {
                return new DadosPessoaisResponse
                {
                    Mensagem = "Dados adicionados com sucesso!",
                    DadosPessoais = _dadosPessoaisRepository.AtualizarDadosPessoais(cpf, CEP, dadosPessoais)
                };
            }
            catch (Exception ex)
            {
                return new DadosPessoaisResponse
                {
                    Mensagem = $"Erro ao adicionar os dados {ex.Message}!"
                };
            }
        }

        public DadosPessoaisResponse CriarDadosPessoais(DadosPessoais dadosPessoais)
        {
            try
            {
                dadosPessoais = ValidarFormato(dadosPessoais);

                return new DadosPessoaisResponse
                {
                    Mensagem = "Dados adicionados com sucesso!",
                    DadosPessoais = _dadosPessoaisRepository.CriarDadosPessoais(dadosPessoais)
                };

            }
            catch (Exception ex)
            {
                return new DadosPessoaisResponse
                {
                    Mensagem = $"Erro ao adicionar os dados {ex.Message}"
                };
            }
        }

        public DadosPessoaisResponse DeletarDadosPessoais(string cpf, string CEP)
        {
            try
            {
                if (_dadosPessoaisRepository.DeletarDadosPessoais(cpf, CEP))
                    return new DadosPessoaisResponse
                    {
                        Mensagem = "Dados deletados com sucesso!"
                    };

                return new DadosPessoaisResponse
                {
                    Mensagem = "Não foi possível deletar os dados!"
                };
            }
            catch (Exception ex)
            {
                return new DadosPessoaisResponse
                {
                    Mensagem = $"Erro ao deletar os dados {ex.Message}"
                };
            }
        }

        public DadosPessoaisResponse ObterTodosOsDadosPessoais()
        {
            try
            {
                var clientes = _dadosPessoaisRepository.ObterTodosClientes();
                var enderecos = _dadosPessoaisRepository.ObterTodosEnderecos();
                var dadosPessoais = new DadosPessoais();
                var listaDadosPessoais = new List<DadosPessoais>();

                if (clientes != null && clientes.Any())
                {
                    for (int x = 0; x < clientes.Count(); x++)
                    {
                        dadosPessoais.DadosCliente = clientes[x];
                        dadosPessoais.EnderecoCliente = enderecos[x];

                        listaDadosPessoais.Add(dadosPessoais);
                    }
                }

                return new DadosPessoaisResponse
                {
                    Mensagem = "Dados Obtidos com sucesso!",
                    ListDadosPessoais = listaDadosPessoais
                };
            }
            catch (Exception ex)
            {
                return new DadosPessoaisResponse
                {
                    Mensagem = $"Erro ao obter os dados {ex.Message}"
                };
            }
        }

        public DadosPessoais ValidarFormato(DadosPessoais dadosPessoais)
        {
            try
            {
                if (dadosPessoais.DadosCliente.CPF.Length == 11)
                {
                    var reg = new Regex(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/");

                    if (!reg.IsMatch(dadosPessoais.DadosCliente.CPF))
                    {
                        return dadosPessoais;
                    }
                    else
                    {
                        throw new Exception("Formato do CPF inválido");
                    }
                }
                else
                {
                    throw new Exception("Formato do CPF inválido");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
