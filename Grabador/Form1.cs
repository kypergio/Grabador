using DTO;
using Grabador.Clases;
using Grabador.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;

namespace Grabador
{
    public partial class Form1 : Form
    {
        private Peticion peticion = new Peticion();
        private List<Alumno> alumnos = new List<Alumno>();
        private List<Empleado> empleados = new List<Empleado>();
        private SerialPort serial = new SerialPort();
        private Thread hiloConexionWebService, hiloVerificarSerial, hiloRegistrarWebService;
        private CIdMatricula CIdMatricula = null;
        private Config config = new Config();

        public Form1()
        {
            InitializeComponent();
            config.nombre = "Alumnos";
            config.tab = tbAlumnos;
            config.LbEmergencia = lbEmergencia;
            config.txtIdTag = txtIdTarjetaAlumno;

        }

        private void __CargarFormulario(object sender, EventArgs e)
        {
            hiloConexionWebService = new Thread(new ThreadStart(ConectarWebService));
            hiloVerificarSerial = new Thread(new ThreadStart(VerificarSerial));
            hiloRegistrarWebService = new Thread(new ThreadStart(RegistrarWebService));
            hiloConexionWebService.Start();
            hiloVerificarSerial.Start();
            hiloRegistrarWebService.Start();
        }

        private void VerificarSerial()
        {
            while (true)
            {
                if (!serial.IsOpen)
                {
                    Invoke(new Action(() => lbConexion.BackColor = System.Drawing.Color.DarkRed));
                    Invoke(new Action(() => lbConexion.Text = "DESCONECTADO"));
                    try
                    {
                        serial.PortName = "COM5";
                        serial.BaudRate = 9600;
                        serial.DataReceived += RecibirDatos;
                        serial.Open();
                        Invoke(new Action(() => lbConexion.BackColor = System.Drawing.Color.Green));
                        Invoke(new Action(() => lbConexion.Text = serial.PortName));
                    }
                    catch (Exception)
                    {

                    }
                }

            }
        }

        private void RecibirDatos(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                String recibido = serial.ReadLine();
                String[] idCard = null;
                if (recibido.Contains("idCard"))
                {
                    idCard = recibido.Split(' ');
                    recibido = "puesta";

                }
                switch (recibido)
                {
                    case "untag\r":
                        Invoke(new Action(() => config.LbEmergencia.Text = ""));
                        break;
                    case "success\r":
                        Invoke(new Action(() => config.LbEmergencia.Text = "Por favor retire la tarjeta ahora."));
                        Invoke(new Action(() => config.LbEmergencia.BackColor = System.Drawing.Color.GreenYellow));
                        Thread.Sleep(3000);
                        break;
                    case "fail\r":
                        break;
                    case "puesta":
                        Invoke(new Action(() => config.LbEmergencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))))));
                        Invoke(new Action(() => config.LbEmergencia.Text = "Por favor no retire la tarjeta hasta que se le indique."));
                        Invoke(new Action(() => config.txtIdTag.Text = idCard[1]));
                        break;
                }
            }
            catch (Exception) { }
        }

        private void ConectarWebService()
        {
            peticion.PedirComunicacion("/alumnos/", "GET");
            String json = peticion.ObtenerJson();
            alumnos = JsonConvertidor.Json_Alumno(json);

            peticion.PedirComunicacion("/empleados/", "GET");
            json = peticion.ObtenerJson();
            empleados = JsonConvertidor.Json_Empleado(json);

            hiloConexionWebService.Abort();
        }

        private void _PresionarTecla(object sender, KeyEventArgs e)
        {
            if (tbMain.SelectedTab == tbAlumnos)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ReiniciarForm(false, 1);
                    String matricula = txtMatricula.Text;
                    String encripMat = Encriptacion.Encriptar(matricula);

                    if (matricula.Length < 11)
                    {
                        MessageBox.Show("Verifique la matrícula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    IEnumerable<Alumno> resultado = alumnos.Where(c => c.Matricula.Equals(encripMat));
                    if (resultado.Count() == 0)
                    {
                        MessageBox.Show("Ningún registro encontrado", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    Alumno alumno = resultado.First();

                    txtApellidoPaternoAlumno.Text = Encriptacion.desEncriptar(alumno.ApellidoPaterno);
                    txtApellidoMaternoAlumno.Text = Encriptacion.desEncriptar(alumno.ApellidoMaterno);
                    txtNombreAlumno.Text = Encriptacion.desEncriptar(alumno.Nombre);

                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {

                    ReiniciarForm(false, 2);
                    String issemym = txtIssemym.Text;
                    String encriptarIssemym = Encriptacion.Encriptar(issemym);


                    IEnumerable<Empleado> resultado = empleados.Where(c => c.ClaveISSEMYM.Equals(encriptarIssemym));
                    if (resultado.Count() == 0)
                    {
                        MessageBox.Show("Ningún registro encontrado", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    Empleado empleado = resultado.First();

                    txtApellidoPaternoEmpleado.Text = Encriptacion.desEncriptar(empleado.ApellidoPaterno);
                    txtApellidoMaternoEmpleado.Text = Encriptacion.desEncriptar(empleado.ApellidoMaterno);
                    txtNombreEmpleado.Text = Encriptacion.desEncriptar(empleado.Nombre);

                }
            }
        }

        private void ReiniciarForm(bool reiniMatricula, int tipo)
        {
            if (tipo == 1)
            {
                txtApellidoPaternoAlumno.Text = null;
                txtApellidoMaternoAlumno.Text = null;
                txtNombreAlumno.Text = null;
                if (reiniMatricula) txtMatricula.Text = null;
            }
            else
            {
                txtApellidoPaternoEmpleado.Text = null;
                txtApellidoMaternoEmpleado.Text = null;
                txtNombreEmpleado.Text = null;
                if (reiniMatricula) txtIssemym.Text = null;
            }

        }

        private void __CerrandoFormulario(object sender, FormClosingEventArgs e)
        {
            hiloVerificarSerial.Abort();
        }

        private void __CambiarTab(object sender, EventArgs e)
        {
            if (tbMain.SelectedTab == tbAlumnos)
            {
                config.nombre = "Alumnos";
                config.tab = tbAlumnos;
                config.LbEmergencia = lbEmergencia;
                config.txtIdTag = txtIdTarjetaAlumno;
            }
            else
            {
                config.nombre = "Empleados";
                config.tab = tbEmpleados;
                config.LbEmergencia = lbEmergenciaEmpleados;
                config.txtIdTag = txtIdTarjetaEmpleado;
            }
        }

        private void RegistrarWebService()
        {
            while (true)
            {
                if (CIdMatricula == null) continue;

                peticion.PedirComunicacion("/CIdMatricula/add", "POST");
                peticion.IncrustarDatos(JsonConvertidor.Objeto_Json(CIdMatricula));
                String resultado = peticion.ObtenerJson();
                CIdMatricula = null;
            }
        }

        private void __Grabar(object sender, EventArgs e)
        {
            if (tbMain.SelectedTab == tbAlumnos)
            {
                serial.WriteLine(txtMatricula.Text + "#");

                String matricula = txtMatricula.Text;
                String idTag = txtIdTarjetaAlumno.Text.TrimEnd('\r');

                CIdMatricula = new CIdMatricula { Matricula = matricula, IDTarjeta = idTag };
            }
            else
            {
                serial.WriteLine(txtIssemym.Text + "#");

                String issemym = txtIssemym.Text;
                String idTag = txtIdTarjetaEmpleado.Text.TrimEnd('\r');

                CIdMatricula = new CIdMatricula { Matricula = issemym, IDTarjeta = idTag };


            }
        }
    }
}
