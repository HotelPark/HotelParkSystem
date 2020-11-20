using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class QueryResponse<T> : Response
    {
        public List<T> Data { get; set; }
        public void SuccessAction(List<T> data, string message)
        {
            Data = data;
            Message = message;
            Success = true;
        }
    }

    public class SingleResponse<T> : Response
    {
        public T Data { get; set; }
    }

}
