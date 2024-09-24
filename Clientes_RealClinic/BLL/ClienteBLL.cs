using System;
using System.Data;
using Clientes_RealClinic.DAL;

namespace Clientes_RealClinic.BLL
{
    public class ClienteBLL
    {
        ClienteDAL clienteDAL = new ClienteDAL();

        
        public DataTable ObterTodosClientes()
        {
            try
            {
                return clienteDAL.ObterTodosClientes();
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar a lista de Clientes. ", ex);
            }
            
        }

        public void AdicionarCliente(string nome, DateTime dataNascimento, bool ativo)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    throw new ArgumentException("O nome não pode ser vazio.");
                }
                if (dataNascimento == default(DateTime) || dataNascimento > DateTime.Now)
                {
                    throw new ArgumentException("A data não está válida.");
                }
                clienteDAL.AdicionarCliente(nome, dataNascimento, ativo);
            }
            catch(ArgumentException ex)
            {
                throw new Exception("Erro ao validar cliente. ", ex);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar adicionar novo cliente. ", ex);
            }

            
        }

        public void AtualizarCliente(int id, string nome, DateTime dataNascimento, bool ativo)
        {

            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    throw new ArgumentException("O nome não pode ser vazio.");
                }
                if (dataNascimento > DateTime.Now || dataNascimento < new DateTime(1753, 01, 01))
                {
                    throw new ArgumentException("A data não está válida.");
                }
                clienteDAL.AtualizarCliente(id ,nome, dataNascimento, ativo);
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Erro ao validar novos dados do cliente. ", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar atualizar novo cliente. ", ex);
            }
        }

        public void DeletarCliente(int id)
        {
            try
            {
                clienteDAL.DeletarCliente(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir cadastro do cliente.", ex);
            }
            
        }


        public DataRow ObterClientePorId(int id)
        {
            try
            {
                return clienteDAL.ObterClientePorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar os dados do cliente.", ex);
            }
        }

        public DataTable BuscarClientesPorId(int id)
        {
            try
            {
                return clienteDAL.BuscarClientesPorId(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar os dados do cliente.", ex);
            }
        }

        public DataTable BuscarClientesPorNome(string nome, string ordem, string coluna, string status)
        {
            try
            {
                return clienteDAL.BuscarClientesPorNome(nome,ordem,coluna,status);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar os dados do cliente.", ex);
            }
        }
    }
}
