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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void AlterarProduto(ProdutoModel produto)
        {
            ProdutoRepositorio.AlterarProduto(produto);
        }
    }
}
