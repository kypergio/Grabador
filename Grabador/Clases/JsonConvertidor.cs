using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Utilidades
{
    public static class JsonConvertidor
    {
        //Convertir un JSON a un Alumno
        public static List<Alumno> Json_Alumno(string json)
        {
            return JsonConvert.DeserializeObject<List<Alumno>>(json);
        }
        //Convertir un JSON a un Empleado con sus datos de Usuario
        public static List<Empleado> Json_Empleado(string json)
        {
            return JsonConvert.DeserializeObject<List<Empleado>>(json);
        }

        //Convertir un JSON a una Confirmación
        public static Confirmacion Json_Confirmacion(string json)
        {
            return JsonConvert.DeserializeObject<Confirmacion>(json);
        }

        //Convertir un objeto de cualquier clase a un JSON
        public static string Objeto_Json(Object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        internal static List<CicloEscolar> Json_CicloEscolar(string json)
        {
            return JsonConvert.DeserializeObject<List<CicloEscolar>>(json);
        }
    }
}
