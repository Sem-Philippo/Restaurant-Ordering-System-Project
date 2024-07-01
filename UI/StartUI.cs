using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class StartUI : Form
    {
        public StartUI()
        {
            InitializeComponent();
            Payment payment = new Payment();
            payment.Show();
        }

        private void StartUI_Load(object sender, EventArgs e)
        {
            //because the start window has to be open at all times, to allow switching,
            //this small and unimportant window stays open
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
