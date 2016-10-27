using Operaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grabador
{
    public partial class Inicio : Form
    {
        private Thread _hConsumoWS,_hVerificacion,_hConexionSerial;
        private AdministracionPuertoSerial puerto;
        private WebService ws;

        public Inicio()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            ws = new WebService(pbProgreso,lbEstado);
            puerto = new AdministracionPuertoSerial(pbProgreso,lbEstado);
            _hConsumoWS = new Thread(new ThreadStart(ws.Consumir));
            _hVerificacion = new Thread(new ThreadStart(Verificar));
            _hConexionSerial = new Thread(new ThreadStart(puerto.Conectar));

            _hConsumoWS.Start();
            _hVerificacion.Start();
        }

        private void Verificar()
        {
            while (_hConsumoWS.IsAlive) ;
            _hConexionSerial.Start();
            while (_hConexionSerial.IsAlive) ;

            Form1 form = new Form1();
            form.SetDatosIniciales(ws,puerto);
            this.Visible = false;
            this.Dispose();
            form.ShowDialog();
        }
    }
}
