using System;
using System.Windows.Forms;

namespace AugustosFashion.Views
{
    public partial class FrmFundoHome : Form
    {
        public FrmFundoHome()
        {
            InitializeComponent();
        }
        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);
        }
        private void OnTimerEvent(object sender, EventArgs e)
        {
            

        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {

        }
    }
}
