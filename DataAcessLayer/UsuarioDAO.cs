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
        public Response Insert(Usuario funcionario)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
            "INSERT INTO USUARIOS (NOME, CPF, RG, TELEFONE, ENDERECO, EMAIL, SENHA) VALUES (@NOME, @CPF, @RG, @TELEFONE, @ENDERECO, @EMAIL, @SENHA)";

            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            command.Parameters.AddWithValue("@ENDERECO", funcionario.Endereco);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);

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
        public Response Update(Usuario funcionario)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE USUARIOS SET NOME = @NOME, CPF = @CPF, RG = @RG, TELEFONE = @TELEFONE, ENDERECO = @ENDERECO, EMAIL = @EMAIL, SENHA = @SENHA, WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            command.Parameters.AddWithValue("ENDERECO", funcionario.Endereco);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);
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
        public Response Delete(Usuario funcionario)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM USUARIOS WHERE ID = @ID";
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
        public QueryResponse<Usuario> GetAll()
        {
            QueryResponse<Usuario> response = new QueryResponse<Usuario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM USUARIOS";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Usuario> funcionario = new List<Usuario>();

                while (reader.Read())
                {
                    Usuario funcionarios = new Usuario();
                    funcionarios.ID = (int)reader["ID"];
                    funcionarios.Nome = (string)reader["NOME"];
                    funcionarios.CPF = (string)reader["CPF"];
                    funcionarios.RG = (string)reader["RG"];
                    funcionarios.Telefone = (string)reader["TELEFONE"];
                    funcionarios.Email = (string)reader["EMAIL"];
                    funcionarios.Senha = (string)reader["SENHA"];
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
            QueryResponse<Usuario> response = new QueryResponse<Usuario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();


            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID FROM USUARIOS WHERE CPF = @CPF";
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
        public SingleResponse<Usuario> GetById(int id)
        {
            SingleResponse<Usuario> response = new SingleResponse<Usuario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM USUARIOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Usuario funcionarios = new Usuario();
                    funcionarios.ID = (int)reader["ID"];
                    funcionarios.Nome = (string)reader["NOME"];
                    funcionarios.CPF = (string)reader["CPF"];
                    funcionarios.RG = (string)reader["RG"];
                    funcionarios.Telefone = (string)reader["TELEFONE"];
                    funcionarios.Email = (string)reader["EMAIL"];
                    funcionarios.Senha = (string)reader["SENHA"];
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
            QueryResponse<Usuario> response = new QueryResponse<Usuario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID FROM USUARIOS WHERE EMAIL = @EMAIL";
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

        public SingleResponse<Usuario> Autentication(string email, string senhasistema)
        {
            SingleResponse<Usuario> response = new SingleResponse<Usuario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHASISTEMA = @SENHASISTEMA";
            command.Parameters.AddWithValue("@EMAIL", email);
            command.Parameters.AddWithValue("@SENHASISTEMA", senhasistema);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Usuario funcionarios = new Usuario();
                    funcionarios.ID = (int)reader["ID"];
                    funcionarios.Nome = (string)reader["NOME"];
                    funcionarios.CPF = (string)reader["CPF"];
                    funcionarios.RG = (string)reader["RG"];
                    funcionarios.Telefone = (string)reader["TELEFONE"];
                    funcionarios.Email = (string)reader["EMAIL"];
                    funcionarios.Senha = (string)reader["SENHA"];
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
