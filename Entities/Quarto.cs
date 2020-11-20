using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Quarto
    {
        public int ID { get; set; }
        public double Valor_Base { get; set; }
        [Browsable(false)]
        public bool Reserva { get; set; }
        public string NumQuarto { get; set; }
        public EnumCategoria Categoria { get; set; }
        [Browsable(false)]
        public bool EstaOcupado{ get; set; } 
    }
}
