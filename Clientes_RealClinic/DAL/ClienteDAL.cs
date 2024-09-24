using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace Clientes_RealClinic.DAL
{
    public class ClienteDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ClienteDB"].ConnectionString;

        public DataTable ObterTodosClientes()
        {
            DataTable dtClientes = new DataTable();
            try
            {    
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", conn);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtClientes);
                }

                return dtClientes;
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados. ", ex);
            }
            
        }

        public void AdicionarCliente(string nome, DateTime dataNascimento, bool ativo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Clientes (CLI_NOME, CLI_DATANASCIMENTO, CLI_ATIVO) VALUES (@Nome, @DataNascimento, @Ativo)", conn);
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                    cmd.Parameters.AddWithValue("@Ativo", ativo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados. ", ex);
            }

        }

        public void AtualizarCliente(int id, string nome, DateTime dataNascimento, bool ativo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Clientes SET CLI_NOME = @Nome, CLI_DATANASCIMENTO = @DataNascimento, CLI_ATIVO = @Ativo WHERE CLI_ID = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                    cmd.Parameters.AddWithValue("@Ativo", ativo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados. ", ex);
            }

        }

        public void DeletarCliente(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE CLI_ID = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados. ", ex);
            }

        }

        public DataRow ObterClientePorId(int id)
        {
            DataTable dtCliente = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes WHERE CLI_ID = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtCliente);
                }
                return dtCliente.Rows.Count > 0 ? dtCliente.Rows[0] : null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados.", ex);
            }
        }


        public DataTable BuscarClientesPorId(int id)
        {
            DataTable dtCliente = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes WHERE CLI_ID = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtCliente);
                }
                return dtCliente;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados.", ex);
            }
        }


        public DataTable BuscarClientesPorNome(string nome,string ordem,string coluna, string status)
        {
            DataTable dtCliente = new DataTable();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string query;
                    if (status.ToLower() != "true" && status.ToLower() != "false")
                    {
                        query = $"SELECT * FROM Clientes WHERE CLI_NOME COLLATE SQL_Latin1_General_CP1_CI_AI LIKE @Nome ORDER BY {coluna} {ordem}";
                    }
                    else
                    {
                        query = $"SELECT * FROM Clientes WHERE CLI_NOME COLLATE SQL_Latin1_General_CP1_CI_AI LIKE @Nome AND CLI_ATIVO = @Status ORDER BY {coluna} {ordem}";
                    }
                        

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nome", "%"+nome+"%");
                    cmd.Parameters.AddWithValue("@Status", status);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtCliente);
                }

                return dtCliente;

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao realizar a conexão com o banco de dados.", ex);
            }

        }
    }
}