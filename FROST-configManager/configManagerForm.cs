using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FROST_configManager
{
    public partial class configManagerForm : Form
    {
        public configManagerForm(List<String> devicesToConnectTo)
        {
            InitializeComponent();

            foreach (string device in devicesToConnectTo)
                Console.WriteLine(device.ToString());
        }
    }
}
