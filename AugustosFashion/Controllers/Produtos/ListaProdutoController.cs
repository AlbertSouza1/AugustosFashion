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

        internal List<ProdutoListagem> ListarProdutos(EStatusProduto status)
        {
            try
            {
                return ProdutoRepositorio.ListarTodosOsProdutos(status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal List<ProdutoListagem> BuscarProdutosPorNome(string busca, EStatusProduto status)
        {
            try
            {
                return ProdutoRepositorio.BuscarProdutosPorNome(busca, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
