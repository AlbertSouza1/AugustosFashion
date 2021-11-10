using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;

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

        internal List<ProdutoListagem> ListarProdutos()
        {
            try
            {
                return ProdutoRepositorio.ListarTodosOsProdutos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
