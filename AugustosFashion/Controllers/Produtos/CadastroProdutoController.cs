using AugustosFashion.Entidades;
using AugustosFashion.Views.Produtos;

namespace AugustosFashion.Controllers.Produtos
{
    public class CadastroProdutoController
    {
        internal void AbrirFormCadastroProduto()
        {
            var frmCadastroProduto = new FrmCadastroProduto(this);
            frmCadastroProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmCadastroProduto.Show();
        }
    }
}
