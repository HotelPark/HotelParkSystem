using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.TipoQuartos;

namespace Entities
{
    public class Quarto
    {
        public int ID { get; set; }
        public double ValorBase { get; set; }
        [Browsable(false)]
        public bool Reserva { get; set; }
        public string NumQuarto { get; set; }
        public EnumCategoria Categoria { get; set; }
        [Browsable(false)]
        public bool Ocupado{ get; set; } 
    }
}
