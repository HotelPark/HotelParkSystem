using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
   public class ClienteBLL : BaseValidator<Cliente>
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        public SingleResponse<Cliente> GetById(int id)
        {
            return clienteDAO.GetById(id);
        }
        public Response Insert(Cliente item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return clienteDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Cliente item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return clienteDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Cliente item)
        {
            return clienteDAO.Delete(item);
        }
        public QueryResponse<Cliente> GetAll()
        {
            QueryResponse<Cliente> responseClientes = clienteDAO.GetAll();
            List<Cliente> temp = responseClientes.Data;
            foreach (Cliente item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
            }
            return responseClientes;
        }
        public override Response Validate(Cliente item)
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
