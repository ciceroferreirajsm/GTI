using APIWeb.Data;
using APIWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationSolution.APIWeb.Models;

namespace APIWeb.Repository
{
    public class DadosPessoaisRepository : IDadosPessoaisRepository
    {
        private readonly ApiWebContext _context;

        public DadosPessoaisRepository(ApiWebContext context)
        {
            _context = context;
        }

        public DadosPessoais CriarDadosPessoais(DadosPessoais novosDadosPessoais)
        {
            Cliente clienteExistente = _context.Cliente.FirstOrDefault(x => x.CPF == novosDadosPessoais.DadosCliente.CPF);
            EnderecoCliente EnderecoExistente = _context.Endereco.FirstOrDefault(x => x.CEP == novosDadosPessoais.EnderecoCliente.CEP);
            try
            {
                if (clienteExistente == null && EnderecoExistente == null)
                {
                    clienteExistente = novosDadosPessoais.DadosCliente;
                    _context.Cliente.Add(clienteExistente);

                    EnderecoExistente = novosDadosPessoais.EnderecoCliente;
                    _context.Endereco.Add(EnderecoExistente);

                    _context.SaveChanges();

                    novosDadosPessoais.EnderecoCliente = EnderecoExistente;
                    novosDadosPessoais.DadosCliente = clienteExistente;

                    return novosDadosPessoais;
                }

                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cliente> ObterTodosClientes()
        {
            try
            {
                return _context.Cliente.OrderBy(x => x.IdCliente).ToList(); 
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public List<EnderecoCliente> ObterTodosEnderecos()
        {
            try
            {
                return _context.Endereco.OrderBy(x => x.Id).ToList();
            }
            catch (Exception)
            {
                return new List<EnderecoCliente>();
            }
        }

        public DadosPessoais AtualizarDadosPessoais(string CPF, string CEP, DadosPessoais novosDadosPessoais)
        {
            Cliente clienteExistente = _context.Cliente.FirstOrDefault(x => x.CPF.Equals(CPF));
            EnderecoCliente enderecoClienteExistente = _context.Endereco.FirstOrDefault(x => x.CEP.Equals(CEP));

            try
            {
                if (clienteExistente != null)
                {
                    clienteExistente.UF = novosDadosPessoais.DadosCliente.UF;
                    clienteExistente.CPF = novosDadosPessoais.DadosCliente.CPF;
                    clienteExistente.OrgaoExpeditor = novosDadosPessoais.DadosCliente.OrgaoExpeditor;
                    clienteExistente.RG = novosDadosPessoais.DadosCliente.RG;
                    clienteExistente.EstadoCivil = novosDadosPessoais.DadosCliente.EstadoCivil;
                    clienteExistente.DataNascimento = novosDadosPessoais.DadosCliente.DataNascimento;
                    clienteExistente.Nome = novosDadosPessoais.DadosCliente.Nome;
                    clienteExistente.Sexo = novosDadosPessoais.DadosCliente.Sexo;
                    clienteExistente.DataExpedicao = novosDadosPessoais.DadosCliente.DataExpedicao;                    

                    _context.Cliente.Update(clienteExistente);

                    enderecoClienteExistente.UF = novosDadosPessoais.EnderecoCliente.UF;
                    enderecoClienteExistente.CEP = novosDadosPessoais.EnderecoCliente.CEP;
                    enderecoClienteExistente.Cidade = novosDadosPessoais.EnderecoCliente.Cidade;
                    enderecoClienteExistente.Bairro = novosDadosPessoais.EnderecoCliente.Bairro;
                    enderecoClienteExistente.Numero = novosDadosPessoais.EnderecoCliente.Numero;
                    enderecoClienteExistente.Complemento = novosDadosPessoais.EnderecoCliente.Complemento;
                    enderecoClienteExistente.Logradouro = novosDadosPessoais.EnderecoCliente.Logradouro;

                    _context.Endereco.Update(enderecoClienteExistente);
                    _context.SaveChanges();

                    novosDadosPessoais.DadosCliente = clienteExistente;
                    novosDadosPessoais.EnderecoCliente = enderecoClienteExistente;

                    return novosDadosPessoais;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeletarDadosPessoais(string CPF, string CEP)
        {
            Cliente clienteExistente = _context.Cliente.FirstOrDefault(x => x.CPF.Equals(CPF));
            EnderecoCliente EnderecoExistente = _context.Endereco.FirstOrDefault(x => x.CEP.Equals(CEP));
            try
            {
                if (clienteExistente != null && EnderecoExistente != null)
                {
                    _context.Cliente.Remove(clienteExistente);
                    _context.Endereco.Remove(EnderecoExistente);

                    _context.SaveChanges();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
