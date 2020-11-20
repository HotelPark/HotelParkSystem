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
    public class QuartoDAO
    {
        public Response Insert(Quarto quarto)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO QUARTOS (VALOR_BASE, RESERVA, NUMQUARTO, CATEGORIAS, ESTAOCUPADO) VALUES (@VALOR_BASE, @RESERVA, @NUMQUARTO, @CATEGORIAS, @ESTAOCUPADO)";
            command.Parameters.AddWithValue("@VALOR_BASE", quarto.Valor_Base);
            command.Parameters.AddWithValue("@RESERVA", quarto.Reserva);
            command.Parameters.AddWithValue("@NUMQUARTO", quarto.NumQuarto);
            command.Parameters.AddWithValue("@CATEGORIAS", quarto.Categoria);
            command.Parameters.AddWithValue("@OCUPADO", quarto.EstaOcupado);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Cadastrado com sucesso.";
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

        public Response Update(Quarto quarto)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE QUARTOS SET VALOR_BASE = @VALOR_BASE, RESERVA = @RESERVA, NUMQUARTO = @NUMQUARTO, CATEGORIAS = @CATEGORIAS, ESTAOCUPADO = @ESTAOCUPADO";
            command.Parameters.AddWithValue("@VALOR_BASE", quarto.Valor_Base);
            command.Parameters.AddWithValue("@RESERVA", quarto.Reserva);
            command.Parameters.AddWithValue("@NUMQUARTO", quarto.NumQuarto);
            command.Parameters.AddWithValue("@CATEGORIAS", quarto.Categoria);
            command.Parameters.AddWithValue("@ESTAOCUPADO", quarto.EstaOcupado);

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

        public Response Delete(Quarto quarto)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM QUARTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", quarto.ID);

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

        public QueryResponse<Quarto> GetAll()
        {
            QueryResponse<Quarto> response = new QueryResponse<Quarto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM QUARTOS";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Quarto> quartos = new List<Quarto>();

                while (reader.Read())
                {
                    Quarto quarto = new Quarto();
                    quarto.ID = (int)reader["ID"];
                    quarto.Valor_Base = (double)reader["VALOR_BASE"];
                    quarto.Reserva = (bool)reader["RESERVA"];
                    quarto.NumQuarto = (string)reader["NUMQUARTO"];
                    quarto.Categoria = (EnumCategoria)reader["CATEGORIAS"];
                    quarto.EstaOcupado = (bool)reader["ESTAOCUPADO"];
                    quartos.Add(quarto);
                }
                response.Success = true;
                response.Message = "Quartos selecionados com sucesso.";
                response.Data = quartos;
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

        public SingleResponse<Quarto> GetById(int id)
        {
            SingleResponse<Quarto> response = new SingleResponse<Quarto>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM QUARTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Quarto quarto = new Quarto();
                    quarto.ID = (int)reader["ID"];
                    quarto.Valor_Base = (double)reader["VALOR_BASE"];
                    quarto.Reserva = (bool)reader["RESERVA"];
                    quarto.NumQuarto = (string)reader["NUMQUARTO"];
                    quarto.Categoria = (EnumCategoria)reader["CATEGORIAS"];
                    quarto.EstaOcupado = (bool)reader["ESTAOCUPADO"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = quarto;
                    return response;
                }
                response.Message = "Quarto não encontrado.";
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
