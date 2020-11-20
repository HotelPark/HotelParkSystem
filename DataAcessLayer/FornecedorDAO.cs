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
   public class FornecedorDAO
    {
        public Response Insert(Fornecedor fornecedor)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
            "INSERT INTO FORNECEDORES (RAZAO_SOCIAL, CNPJ, NOME_CONTATO, TELEFONE, EMAIL) VALUES (@RAZAO_SOCIAL, @CNPJ, @NOME_CONTATO, @TELEFONE, @EMAIL)";

            command.Parameters.AddWithValue("@RAZAO_SOCIAL", fornecedor.Razao_Social);
            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
            command.Parameters.AddWithValue("@NOME_CONTATO", fornecedor.Nome_Contato);
            command.Parameters.AddWithValue("@TELEFONE", fornecedor.Telefone);
            command.Parameters.AddWithValue("@EMAIL", fornecedor.Email);

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
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }
        public Response Update(Fornecedor fornecedor)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
            "UPDATE INTO FORNECEDORES (RAZAO_SOCIAL, CNPJ, NOME_CONTATO, TELEFONE, EMAIL) VALUES (@RAZAO_SOCIAL, @CNPJ, @NOME_CONTATO, @TELEFONE, @EMAIL)";

            command.Parameters.AddWithValue("@RAZAO_SOCIAL", fornecedor.Razao_Social);
            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
            command.Parameters.AddWithValue("@NOME_CONTATO", fornecedor.Nome_Contato);
            command.Parameters.AddWithValue("@TELEFONE", fornecedor.Telefone);
            command.Parameters.AddWithValue("@EMAIL", fornecedor.Email);

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
        public Response Delete(Fornecedor fornecedor)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM FORNECEDORES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", fornecedor.ID);

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
        public QueryResponse<Fornecedor> GetAll()
        {
            QueryResponse<Fornecedor> response = new QueryResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FORNECEDORES";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Fornecedor> fornecedores = new List<Fornecedor>();

                while (reader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.ID = (int)reader["ID"];
                    fornecedor.Razao_Social = (string)reader["RAZAO_SOCIAL"];
                    fornecedor.CNPJ = (string)reader["CNPJ"];
                    fornecedor.Nome_Contato = (string)reader["NOME_CONTATO"];
                    fornecedor.Telefone = (string)reader["TELEFONE"];
                    fornecedor.Email = (string)reader["EMAIL"];
                    fornecedores.Add(fornecedor);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = fornecedores;
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
        public Response IsCNPJUnique(string cnpj)
        {
            QueryResponse<Fornecedor> response = new QueryResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID FROM FORNECEDORES WHERE CPF = @CPF";
            command.Parameters.AddWithValue("@CNPJ", cnpj);
            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "CNPJ já cadastrado.";
                }
                else
                {
                    response.Success = true;
                    response.Message = "CNPJ único.";
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
        public SingleResponse<Fornecedor> GetById(int id)
        {
            SingleResponse<Fornecedor> response = new SingleResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FORNECEDORES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.ID = (int)reader["ID"];
                    fornecedor.Razao_Social = (string)reader["RAZAO_SOCIAL"];
                    fornecedor.CNPJ = (string)reader["CNPJ"];
                    fornecedor.Nome_Contato = (string)reader["NOME_CONTATO"];
                    fornecedor.Telefone = (string)reader["TELEFONE"];
                    fornecedor.Email = (string)reader["EMAIL"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = fornecedor;
                    return response;
                }
                response.Message = "Fornecedor não encontrado.";
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
