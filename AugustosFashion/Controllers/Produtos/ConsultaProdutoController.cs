using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;

namespace AugustosFashion.Controllers.Produtos
{
    public class ConsultaProdutoController
    {
        internal void AbrirFormConsulta(ProdutoModel produto)
        {
            var frmConsultaProduto = new FrmConsultaProduto(this, produto);
            frmConsultaProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmConsultaProduto.Show();
        }
        public ProdutoModel ConsultarProduto(int idProduto)
        {
            try
            {
                return ProdutoRepositorio.ConsultarProduto(idProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal string AlterarProduto(ProdutoModel produto)
        {
            var retorno = produto.ValidarProduto();

            if (string.IsNullOrEmpty(retorno))
            {
                ProdutoRepositorio.AlterarProduto(produto);
            }
            return retorno;
        }

        internal void InativarProduto(int idProduto)
        {
            try
            {
                ProdutoRepositorio.InativarProduto(idProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void AtivarProduto(int idProduto)
        {
            try
            {
                ProdutoRepositorio.AtivarProduto(idProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
