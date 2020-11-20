using Common;
using DataAcessLayer.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class ClienteDAO
    {
        public Response Insert(Cliente cliente)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
            "INSERT INTO CLIENTES (NOME, CPF, RG, TELEFONE_1, TELEFONE_2, ENDERECO, EMAIL, ESPECIAL) VALUES (@NOME, @CPF, @RG, @TELEFONE_1, @TELEFONE_2, @ENDERECO, @EMAIL, @ESPECIAL)";

            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@RG", cliente.RG);
            command.Parameters.AddWithValue("@TELEFONE_1", cliente.Telefone_1);
            command.Parameters.AddWithValue("@TELEFONE_2", cliente.Telefone_2);
            command.Parameters.AddWithValue("@ENDERECO", cliente.Endereco);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            command.Parameters.AddWithValue("@ESPECIAL", cliente.Especial);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Cadastrado com Sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_CLIENTES"))
                {
                    response.Message = "CPF já está em uso.";
                }
                else
                {
                    response.Message = "Erro no Banco de Dados, contate um ADM!";
                }
                response.Success = false;
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }
        public Response Update(Cliente cliente)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE INTO CLIENTES (NOME, TELEFONE_1, TELEFONE_2, ENDERECO, EMAIL, ESPECIAL,) VALUES (@NOME, @TELEFONE_1, @TELEFONE_2, @ENDERECO, @EMAIL, @ESPECIAL,";
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@TELEFONE_1", cliente.Telefone_1);
            command.Parameters.AddWithValue("@TELEFONE_2", cliente.Telefone_2);
            command.Parameters.AddWithValue("ENDERECO", cliente.Endereco);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            command.Parameters.AddWithValue("@ESPECIAL", cliente.Especial);

            command.Connection = connection;

            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }

                response.Success = true;
                response.Message = "Atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o administrador.";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }
        public Response Delete(Cliente cliente)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM CLIENTES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", cliente.ID);

            command.Connection = connection;

            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }

                response.Success = true;
                response.Message = "Excluído" +
                    " com sucesso.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o administrador.";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }
        public QueryResponse<Cliente> GetAll()
        {
            QueryResponse<Cliente> response = new QueryResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.ID = (int)reader["ID"];
                    cliente.Nome = (string)reader["NOME"];
                    cliente.CPF = (string)reader["CPF"];
                    cliente.RG = (string)reader["RG"];
                    cliente.Telefone_1 = (string)reader["TELEFONE_1"];
                    cliente.Telefone_2 = (string)reader["TELEFONE_2"];
                    cliente.Endereco = (string)reader["ENDERECO"];
                    cliente.Email = (string)reader["EMAIL"];
                    cliente.Especial = (bool)reader["ESPECIAL"];
                    clientes.Add(cliente);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = clientes;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }

        }
        public Response IsCpfUnique(string cpf)
        {
            QueryResponse<Cliente> response = new QueryResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID FROM CLIENTES WHERE CPF = @CPF";
            command.Parameters.AddWithValue("@CPF", cpf);
            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "CPF já cadastrado.";
                }
                else
                {
                    response.Success = true;
                    response.Message = "CPF único.";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }
        }
        public SingleResponse<Cliente> GetById(int id)
        {
            SingleResponse<Cliente> response = new SingleResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.ID = (int)reader["ID"];
                    cliente.Nome = (string)reader["NOME"];
                    cliente.CPF = (string)reader["CPF"];
                    cliente.RG = (string)reader["RG"];
                    cliente.Telefone_1 = (string)reader["TELEFONE_1"];
                    cliente.Telefone_2 = (string)reader["TELEFONE_2"];
                    cliente.Endereco = (string)reader["ENDERECO"];
                    cliente.Email = (string)reader["EMAIL"];
                    cliente.Especial = (bool)reader["ESPECIAL"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = cliente;
                    return response;
                }
                response.Message = "Cliente não encontrado.";
                response.Success = false;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
