using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;

namespace Operaciones
{
    public class WebService
    {
        private List<Alumno> alumnos;
        private List<Empleado> empleados;
        private List<CicloEscolar> ciclosEscolares;
        private ProgressBar progreso;
        private Label estado;

        private CIdMatricula registro;

        private Peticion peticion = new Peticion();

        private string json = "";

        public WebService(ProgressBar progreso,Label estado)
        {
            this.progreso = progreso;
            this.estado = estado;
        }

        public bool Registrar()
        {
            peticion.PedirComunicacion("/CIdMatricula/add", "POST");
            peticion.IncrustarDatos(JsonConvertidor.Objeto_Json(registro));
            String resultado = peticion.ObtenerJson();
            registro = null;
            Confirmacion respuesta = JsonConvertidor.Json_Confirmacion(resultado);
            if(respuesta.Estado)
            {
                return true;
            }
            else
            {
                if(respuesta.Descripcion == "Duplicado")
                {
                    MessageBox.Show("Este ID de Tarjeta ya está asignada a un usuario","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                return false;
            }
        }

        public void Consumir()
        {
            estado.Text = "Cargando Alumnos...";
            peticion.PedirComunicacion("/alumnos/", "GET");
            json = peticion.ObtenerJson();
            if (json == null)
            {
                MessageBox.Show("Al parecer la conexión de internet no funciona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            alumnos = JsonConvertidor.Json_Alumno(json);
            progreso.PerformStep();

            estado.Text = "Cargando Empleados...";
            Thread.Sleep(1000);
            peticion.PedirComunicacion("/empleados/", "GET");
            json = peticion.ObtenerJson();
            if (json == null)
            {
                MessageBox.Show("Al parecer la conexión de internet no funciona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            empleados = JsonConvertidor.Json_Empleado(json);
            progreso.PerformStep();

            estado.Text = "Cargando Ciclos Escolares...";
            Thread.Sleep(1000);
            peticion.PedirComunicacion("/cicloescolar/all", "GET");
            json = peticion.ObtenerJson();
            if (json == null)
            {
                MessageBox.Show("Al parecer la conexión de internet no funciona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            ciclosEscolares = JsonConvertidor.Json_CicloEscolar(json);
            progreso.PerformStep();
        }

        public List<Alumno> GetAlumnos()
        {
            return alumnos;
        }

        public List<Empleado> GetEmpleados()
        {
            return empleados;
        }

        public List<CicloEscolar> GetCiclosEscolares()
        {
            return ciclosEscolares;
        }

        internal void SetRegistro(CIdMatricula registro)
        {
            this.registro = registro;
        }
    }
}
