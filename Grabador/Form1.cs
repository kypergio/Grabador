using DTO;
using Grabador.Clases;
using Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Utilidades;

namespace Grabador
{
    public partial class Form1 : Form
    {
        private Peticion peticion = new Peticion();
        private Thread _hVerificarSerial, _hRegistrarWebServices;
        private CIdMatricula CIdMatricula = null;
        private Config config = new Config();

        private List<CicloEscolar> ciclosEscolares;

        private WebService ws;
        private AdministracionPuertoSerial puerto;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            config.nombre = "Alumnos";
            config.tab = tbAlumnos;
            config.txtIdTag = txtIdTarjetaAlumno;

        }

        private void __CargarFormulario(object sender, EventArgs e)
        {
            _hVerificarSerial = new Thread(new ThreadStart(puerto.VerificarConexion));
            _hRegistrarWebServices = new Thread(new ThreadStart(RegistrarWebService));


            _hVerificarSerial.Start();
            _hRegistrarWebServices.Start();

        }

        public void SetDatosIniciales(WebService ws, AdministracionPuertoSerial puerto)
        {
            this.ws = ws;
            this.puerto = puerto;
            this.puerto.GetPuerto().DataReceived += RecibirDatos;

            ciclosEscolares = ws.GetCiclosEscolares();
            foreach(var ciclo in ciclosEscolares)
            {
                listaCiclos.Items.Add(ciclo);
            }

            listaCiclos.ComboBox.DisplayMember = "Nombre";
            listaCiclos.ComboBox.ValueMember = "ID";
            listaCiclos.ComboBox.DataSource = ciclosEscolares;


            listaCiclos.Text = ciclosEscolares.Last().Nombre;
        }

        private void RecibirDatos(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                String recibido = puerto.LeerLinea();
                String[] idCard = null;
                if (recibido.Contains("idCard"))
                {
                    if (txtApellidoMaternoAlumno.Text == "" && txtApellidoPaternoEmpleado.Text == "")
                    {
                        lbStatus.Text = "Primero debe buscar un registro";
                        Thread.Sleep(1000);
                        lbStatus.Text = "Puede comenzar a Grabar";
                        puerto.Escribir("reload");
                        return;
                    }
                    idCard = recibido.Split(' ');
                    recibido = "puesta";

                }
                switch (recibido)
                {
                    case "untag\r":
                        lbStatus.Text = "Puede comenzar a Grabar";
                        lbStatus.BackColor = System.Drawing.Color.YellowGreen;
                        btnGrabar.Enabled = false;
                        break;
                    case "success\r":
                        lbStatus.Text = "Retire la credencial ahora";
                        lbStatus.BackColor = System.Drawing.Color.Aquamarine;
                        Thread.Sleep(2000);
                        break;
                    case "fail\r":
                        break;
                    case "puesta":
                        lbStatus.Text = "No retire la credencial";
                        lbStatus.BackColor = System.Drawing.Color.Red;
                        config.txtIdTag.Text = idCard[1];
                        btnCancelar.Enabled = true;
                        btnGrabar.Enabled = true;
                        break;
                }
            }
            catch (Exception) { }
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

                    IEnumerable<Alumno> resultado = ws.GetAlumnos().Where(c => c.Matricula.Equals(encripMat));
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


                    IEnumerable<Empleado> resultado = ws.GetEmpleados().Where(c => c.ClaveISSEMYM.Equals(encriptarIssemym));
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
            _hVerificarSerial.Abort();
        }

        private void __CambiarTab(object sender, EventArgs e)
        {
            if (tbMain.SelectedTab == tbAlumnos)
            {
                config.nombre = "Alumnos";
                config.tab = tbAlumnos;
                config.txtIdTag = txtIdTarjetaAlumno;
            }
            else
            {
                config.nombre = "Empleados";
                config.tab = tbEmpleados;
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

        private void __CancelarGrabacion(object sender, EventArgs e)
        {
            puerto.Escribir("reload");
            btnCancelar.Enabled = false;
        }

        private void __CambioCiclo(object sender, EventArgs e)
        {
            var ciclo = ((CicloEscolar)listaCiclos.SelectedItem).ID;
        }

        private void __Grabar(object sender, EventArgs e)
        {
            if (tbMain.SelectedTab == tbAlumnos)
            {
                puerto.Escribir(txtMatricula.Text);

                String matricula = txtMatricula.Text;
                String idTag = txtIdTarjetaAlumno.Text.TrimEnd('\r');

                CIdMatricula = new CIdMatricula { Matricula = matricula, IDTarjeta = idTag };
            }
            else
            {
                puerto.Escribir(txtIssemym.Text);

                String issemym = txtIssemym.Text;
                String idTag = txtIdTarjetaEmpleado.Text.TrimEnd('\r');

                CIdMatricula = new CIdMatricula { Matricula = issemym, IDTarjeta = idTag };


            }
        }
    }
}
