using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Produtos
{
    public class CadastroProdutoController
    {
        public void AbrirFormCadastroProduto()
        {
            var frmCadastroProduto = new FrmCadastroProduto(this);
            frmCadastroProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmCadastroProduto.Show();
        }

        public void CadastrarProduto(ProdutoModel produto)
        {
            ProdutoRepositorio.CadastrarProduto(produto);
        }
    }
}
