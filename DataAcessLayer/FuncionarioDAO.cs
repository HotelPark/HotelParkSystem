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
  public  class FuncionarioDAO
    {
        public Response Insert(Funcionario funcionario)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
            "INSERT INTO FUNCIONARIOS (NOME, CPF, RG, TELEFONE, ENDEREÇO, EMAIL, SENHASISTEMA) VALUES (@NOME, @CPF, @RG, @TELEFONE, @ENDERECO, @EMAIL, @SENHASISTEMA)";

            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            command.Parameters.AddWithValue("@ENDERECO", funcionario.Endereco);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHASISTEMA", funcionario.Senha);

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
        public Response Update(Funcionario funcionario)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE CLIENTES SET NOME = @NOME, CPF = @CPF, RG = @RG WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            command.Parameters.AddWithValue("ENDERECO", funcionario.Endereco);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHASISTEMA", funcionario.Senha);
            command.Parameters.AddWithValue("@ID", funcionario.ID);
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
        public Response Delete(Funcionario funcionario)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM FUNCIONARIOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", funcionario.ID);

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
        public QueryResponse<Funcionario> GetAll()
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Funcionario> funcionario = new List<Funcionario>();

                while (reader.Read())
                {
                    Funcionario funcionarios = new Funcionario();
                    funcionarios.ID = (int)reader["ID"];
                    funcionarios.Nome = (string)reader["NOME"];
                    funcionarios.CPF = (string)reader["CPF"];
                    funcionarios.RG = (string)reader["RG"];
                    funcionarios.Telefone = (string)reader["TELEFONE"];
                    funcionarios.Email = (string)reader["EMAIL"];
                    funcionarios.Senha = (string)reader["SENHASISTEMA"];
                    funcionario.Add(funcionarios);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = funcionario;
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
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

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
        public SingleResponse<Funcionario> GetById(int id)
        {
            SingleResponse<Funcionario> response = new SingleResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Funcionario funcionarios = new Funcionario();
                    funcionarios.ID = (int)reader["ID"];
                    funcionarios.Nome = (string)reader["NOME"];
                    funcionarios.CPF = (string)reader["CPF"];
                    funcionarios.RG = (string)reader["RG"];
                    funcionarios.Telefone = (string)reader["TELEFONE"];
                    funcionarios.Email = (string)reader["EMAIL"];
                    funcionarios.Senha = (string)reader["SENHASISTEMA"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = funcionarios;
                    return response;
                }
                response.Message = "Funcionario não encontrado.";
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
        public Response IsEmailUnique(string email)
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID FROM CLIENTES WHERE EMAIL = @EMAIL";
            command.Parameters.AddWithValue("@EMAIL", email);
            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "Email já cadastrado.";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Email único.";
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

        public SingleResponse<Funcionario> Autentication(string email, string senhasistema)
        {
            SingleResponse<Funcionario> response = new SingleResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE EMAIL = @EMAIL AND SENHASISTEMA = @SENHASISTEMA";
            command.Parameters.AddWithValue("@EMAIL", email);
            command.Parameters.AddWithValue("@SENHASISTEMA", senhasistema);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Funcionario funcionarios = new Funcionario();
                    funcionarios.ID = (int)reader["ID"];
                    funcionarios.Nome = (string)reader["NOME"];
                    funcionarios.CPF = (string)reader["CPF"];
                    funcionarios.RG = (string)reader["RG"];
                    funcionarios.Telefone = (string)reader["TELEFONE"];
                    funcionarios.Email = (string)reader["EMAIL"];
                    funcionarios.Senha = (string)reader["SENHASISTEMA"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = funcionarios;
                    return response;
                }
                response.Message = "Funcionario não encontrado.";
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
