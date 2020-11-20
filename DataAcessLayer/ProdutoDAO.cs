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
    public class ProdutoDAO
    {
        public Response Insert(Produto produto)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO PRODUTOS (NOME, PRECO, ESTOQUE, DATAVALIDADE, FORNECEDORID) VALUES (@NOME, @PRECO, @ESTOQUE, @DATAVALIDADE, @FORNECEDORID)";
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@PRECO", produto.Preco);
            command.Parameters.AddWithValue("@ESTOQUE", produto.Estoque);
            command.Parameters.AddWithValue("@DATAVALIDADE", produto.DataValidade);
            command.Parameters.AddWithValue("@FORNECEDORID", produto.Fornecedor_ID);
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
        public Response Update(Produto produto)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET NOME = @NOME, PRECO = @PRECO, ESTOQUE = @ESTOQUE, DATAVALIDADE = @DATAVALIDADE WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", produto.ID);
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@PRECO", produto.Preco);
            command.Parameters.AddWithValue("@ESTOQUE", produto.Estoque);
            command.Parameters.AddWithValue("@DATAVALIDADE", produto.DataValidade);
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
                response.Message = "Registrado com sucesso.";
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
        public Response Delete(Produto produto)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", produto.ID);
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
        public QueryResponse<Produto> GetAll()
        {
            QueryResponse<Produto> response = new QueryResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT P.ID 'ID', P.NOME 'NOME', P.DESCRICAO 'DESCRICAO', P.PRECO 'PRECO , P.QUANTIDADE_ESTOQUE 'QUANTIDADE_ESTOQUE',P.ATIVO 'ATIVO',P.IDFORNECEDOR 'IDFORNECEDOR', F.RAZAOSOCIAL 'RAZAOSOCIAL',F.CNPJ 'CNPJ',F.TELEFONE 'TELEFONE',F.EMAIL 'EMAIL',F.ATIVO 'ATIVO'FROM PRODUTOS P INNER JOIN FORNECEDORES F ON P.IDFORNECEDOR = F.ID";
            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Produto> produtos = new List<Produto>();

                while (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.ID = (int)reader["ID"];
                    produto.Nome = (string)reader["NOME"];
                    produto.Preco = (double)reader["PRECO"];
                    produto.Estoque = (int)reader["ESTOQUE"];
                    produto.DataValidade = (DateTime)reader["DATAVALIDADE"];
                    //produto.Fornecedor_ID =
                    produtos.Add(produto);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = produtos;
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
        public SingleResponse<Produto> GetById(int id)
        {
            SingleResponse<Produto> response = new SingleResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.ID = (int)reader["ID"];
                    produto.Nome = (string)reader["NOME"];
                    produto.Preco = (double)reader["PRECO"];
                    produto.Estoque = (int)reader["ESTOQUE"];
                    produto.DataValidade = (DateTime)reader["DATAVALIDADE"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = produto;
                    return response;
                }
                response.Message = "Produto não encontrado.";
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
