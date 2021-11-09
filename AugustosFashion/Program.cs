using AugustosFashion.Controllers.Logins;
using AugustosFashion.Entidades;
using System;
using System.Windows.Forms;

namespace AugustosFashion
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var resultadoLogin = new LoginController().RetornarFormLogin().ShowDialog();

            if (resultadoLogin == DialogResult.OK)
                Application.Run(MDIParentSingleton.InstanciarFrmMdiParent());
        }
    }
}
