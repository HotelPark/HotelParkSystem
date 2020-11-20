using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Infrastructure
{
    internal class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\entra21\Documents\William\Trabalho C# 10112020\DB\HotelDB.mdf';Integrated Security=True;Connect Timeout=30";
        }
    }
}
