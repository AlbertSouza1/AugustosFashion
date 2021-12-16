using AugustosFashion.Entidades;
using AugustosFashion.Views.Pedidos;

namespace AugustosFashion.Controllers.Colaborador
{
    public class BuscaColaboradorController
    {
        private FrmBuscaColaborador _frmBuscaColaborador;
        public BuscaColaboradorController()
        {
            _frmBuscaColaborador = new FrmBuscaColaborador();
        }
        public void AbrirFormBuscaColaborador()
        {
            _frmBuscaColaborador = new FrmBuscaColaborador
            {
                MdiParent = MDIParentSingleton.InstanciarFrmMdiParent()
            };
            _frmBuscaColaborador.Show();
            _frmBuscaColaborador.BringToFront();
        }

        public void AbrirFormBuscaColaboradorSemMdi()
        {
            _frmBuscaColaborador = new FrmBuscaColaborador();
            _frmBuscaColaborador.Show();
        }

        public FrmBuscaColaborador RetornarFrmBuscaColaborador() => _frmBuscaColaborador;
    }
}
