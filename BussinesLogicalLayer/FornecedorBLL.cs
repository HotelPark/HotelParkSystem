﻿using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class FornecedorBLL : BaseValidator<Fornecedor>
    {
        private FornecedorDAO fornecedorDAO = new FornecedorDAO();
        public SingleResponse<Fornecedor> GetById(int id)
        {
            return fornecedorDAO.GetById(id);
        }
        public Response Insert(Fornecedor item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return fornecedorDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Fornecedor item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return fornecedorDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Fornecedor item)
        {
            return fornecedorDAO.Delete(item);
        }
        public QueryResponse<Fornecedor> GetAll()
        {
            QueryResponse<Fornecedor> responseFornecedor = fornecedorDAO.GetAll();
            List<Fornecedor> temp = responseFornecedor.Data;
            foreach (Fornecedor item in temp)
            {
                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(3, ".").Insert(3, "/").Insert(4, "-").Insert(2, ".");
            }
            return responseFornecedor;
        }
        public override Response Validate(Fornecedor item)
        {
            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Nome.Length < 3 || item.Nome.Length > 70)
            {
                AddError("O nome deve conter entre 3 e 70 caracteres.");
}
            AddError(item.CNPJ.IsValidCNPJ());
            if (!string.IsNullOrWhiteSpace(item.CNPJ))
            {
                item.CNPJ = item.CNPJ.Replace(".", "").Replace("-", "");
            }
            return base.Validate(item);
        }
    }
        
        
        
    
    

    
}
