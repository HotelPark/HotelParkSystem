using BLL.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL : BaseValidator<Usuario>
    {
        private FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        public SingleResponse<Usuario> GetById(int id)
        {
            return funcionarioDAO.GetById(id);
        }
        public Response Insert(Usuario item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return funcionarioDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Usuario item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return funcionarioDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Usuario item)
        {
            return funcionarioDAO.Delete(item);
        }
        public QueryResponse<Usuario> GetAll()
        {
            QueryResponse<Usuario> responseFuncionario = funcionarioDAO.GetAll();
            List<Usuario> temp = responseFuncionario.Data;
            foreach (Usuario item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
            }
            return responseFuncionario;
        }
        public override Response Validate(Usuario item)
        {
            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Nome.Length < 3 || item.Nome.Length > 70)
            {
                AddError("O nome deve conter entre 3 e 70 caracteres.");
            }
            AddError(item.CPF.IsValidCPF());
            if (!string.IsNullOrWhiteSpace(item.CPF))
            {
                item.CPF = item.CPF.Replace(".", "").Replace("-", "");
            }
            return base.Validate(item);
        }
        
        public Response Autenticate(string email, string senhasistema)
        {
            Response r = new Response();
            r.Success = true;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senhasistema))
            {
                r.Success = false;
                r.Message = "Email/senha devem ser informados.";
            }
            else if (senhasistema.Length < 3 || senhasistema.Length > 12)
            {
                r.Success = false;
                r.Message = "Senha deve conter entre 5 e 12 caracteres.";
            }

            
            int nDigitos = 0;
            int nLetras = 0;
            int nSinais = 0;
            int nMaiuscula = 0;
            int nMinuscula = 0;
            for (int i = 0; i < senhasistema.Length; i++)
            {
                if (char.IsNumber(senhasistema[i]))
                {
                    nDigitos++;
                }
                else if (char.IsLetter(senhasistema[i]))
                {
                    nLetras++;
                    if (char.IsUpper(senhasistema[i]))
                    {
                        nMaiuscula++;
                    }
                    else
                    {
                        nMinuscula++;
                    }
                }
                else
                {
                    nSinais++;
                }
            }

            if (nSinais < 1 || nMaiuscula < 1 || nMinuscula < 1 || nLetras < 1 || nDigitos < 1)
            {
                r.Success = false;
                r.Message = "A senha deve conter ao menos um sinal, uma letra minúscula e uma letra maiúscula";
            }


            if (r.Success)
            {
                SingleResponse<Usuario> responseF = funcionarioDAO.Autentication(email, senhasistema);

                if (responseF.Success)
                {
                    SystemVariables.funcionariologado = responseF.Data;
                }
                return responseF;
            }
            return r;

        }
    }
    
}
