using AugustosFashion.Entidades;
using AugustosFashion.Views.Produtos;

namespace AugustosFashion.Controllers.Produtos
{
    public class ListaProdutoController
    {
        public void AbrirFormListaProduto()
        {
            var frmListaProduto = new FrmListaProduto(this);
            frmListaProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaProduto.Show();
        }
    }
}
