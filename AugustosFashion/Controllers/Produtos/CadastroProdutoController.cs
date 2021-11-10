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
        internal void AbrirFormCadastroProduto()
        {
            var frmCadastroProduto = new FrmCadastroProduto(this);
            frmCadastroProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmCadastroProduto.Show();
        }

        internal void CadastrarProduto(ProdutoModel produto)
        {
            try
            {
                ProdutoRepositorio.CadastrarProduto(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
