using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grabador.Clases
{
    public class Config
    {
        public Object nombre { get; set; }
        public TabPage tab { get; set; }

        public Label LbEmergencia { get; set; }

        public TextBox txtIdTag { get; set; }

        public TextBox txtMat { get; set; }
    }
}
