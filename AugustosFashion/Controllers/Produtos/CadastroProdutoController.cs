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

        public string CadastrarProduto(ProdutoModel produto)
        {
            var retorno = produto.ValidarProduto();
            if (string.IsNullOrEmpty(retorno))
            {
                ProdutoRepositorio.CadastrarProduto(produto);                
            }
            return retorno;
        }
    }
}
