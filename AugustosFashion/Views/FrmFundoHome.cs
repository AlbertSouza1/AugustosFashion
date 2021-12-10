using System;
using System.Drawing;
using System.Windows.Forms;

namespace AugustosFashion.Views
{
    public partial class FrmFundoHome : Form
    {
        private Color color = Color.Red;
        public FrmFundoHome()
        {
            InitializeComponent();
        }  

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //tituloPrincipal.ForeColor = color;

            //color = color == Color.Red ? Color.RoyalBlue : Color.Red;
        }

        private void FrmFundoHome_Load(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            //timer1.Interval = 1000;
            //timer1.Start();            
        }
    }
}
