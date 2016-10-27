using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CicloEscolar
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public String FechaInicial { get; set; }
        public String FechaFinal { get; set; }
        public Boolean Estatus { get; set; }

    }
}
