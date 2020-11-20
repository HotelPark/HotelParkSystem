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
    public class RoomBLL: BaseValidator<Quarto>
    {
        private QuartoDAO quartoDAO = new QuartoDAO();
        public SingleResponse<Quarto> GetById(int id)
        {
            return quartoDAO.GetById(id);
        }
        public Response Insert(Quarto item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return quartoDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Quarto item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return quartoDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Quarto item)
        {
            return quartoDAO.Delete(item);
        }
        public QueryResponse<Quarto> GetAll()
        {
            QueryResponse<Quarto> responsequarto = quartoDAO.GetAll();
            List<Quarto> temp = responsequarto.Data;
            foreach (Quarto item in temp)
            {
                item.NumQuarto = item.NumQuarto.Insert(1, "N°");
            }
            return responsequarto;
        }
    }
}
