using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class Empleado
    {
        public int ID { get; set; }
        public string ClaveISSEMYM { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string TipoEmpleado { get; set; }
    }

}