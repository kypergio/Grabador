using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Operaciones
{
    public class AdministracionPuertoSerial
    {
        private Label lbEstado;
        private ProgressBar pbProgreso;
        private SerialPort puertoSerial = new SerialPort();

        public AdministracionPuertoSerial(ProgressBar pbProgreso, Label lbEstado)
        {
            this.pbProgreso = pbProgreso;
            this.lbEstado = lbEstado;
        }

        public void Conectar()
        {
            lbEstado.Text = "Conectando al grabador...";
            var seriales = SerialPort.GetPortNames();

            foreach (var serial in seriales)
            {
                try
                {
                    puertoSerial.PortName = serial;
                    puertoSerial.BaudRate = 9600;
                    puertoSerial.Open();

                    if (puertoSerial.BytesToRead <= 0)
                        throw new Exception();

                    puertoSerial.Write("b");
                    pbProgreso.PerformStep();
                    lbEstado.Text = "Correcto, iniciando...";
                    Thread.Sleep(2000);
                    return;
                }
                catch (Exception e)
                {
                    puertoSerial.Close();
                    Console.WriteLine(e.Message);
                }
            }

            MessageBox.Show("No se pudo conectar al grabador, por favor verifique que está\ncorrectamente conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        internal string LeerLinea()
        {
            return puertoSerial.ReadLine();
        }

        internal SerialPort GetPuerto()
        {
            return puertoSerial;
        }

        internal void VerificarConexion()
        {
            while (true)
            {
                if (!puertoSerial.IsOpen)
                {
                    MessageBox.Show("Se ha desconectado el grabador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);   
                }
            }
        }

        internal void Escribir(string v)
        {
            puertoSerial.WriteLine(v + "#");
        }
    }
}
