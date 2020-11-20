using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
   public class FuncionarioBLL : BaseValidator<Funcionario>
    {
        private FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        public SingleResponse<Funcionario> GetById(int id)
        {
            return funcionarioDAO.GetById(id);
        }
        public Response Insert(Funcionario item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return funcionarioDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Funcionario item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return funcionarioDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Funcionario item)
        {
            return funcionarioDAO.Delete(item);
        }
        public QueryResponse<Funcionario> GetAll()
        {
            QueryResponse<Funcionario> responseFuncionario = funcionarioDAO.GetAll();
            List<Funcionario> temp = responseFuncionario.Data;
            foreach (Funcionario item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
            }
            return responseFuncionario;
        }
        public override Response Validate(Funcionario item)
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
    }
}
