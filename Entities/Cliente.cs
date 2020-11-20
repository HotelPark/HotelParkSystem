using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone_1 { get; set; }
        public string Telefone_2 { get; set; }
        public string Endereco{ get; set; }
        public string Email { get; set; }
        public bool Especial { get; set; }
    }
}
