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
    public class ProdutoBLL: BaseValidator<Produto>
    {
        private ProdutoDAO produtoDAO = new ProdutoDAO();
        public SingleResponse<Produto> GetById(int id)
        {
            return produtoDAO.GetById(id);
        }
        public Response Insert(Produto item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return produtoDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Produto item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return produtoDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Produto item)
        {
            return produtoDAO.Delete(item);
        }
    }
}
