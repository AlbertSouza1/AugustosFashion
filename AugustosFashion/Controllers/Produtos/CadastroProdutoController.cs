using AugustosFashion.Entidades;
using AugustosFashion.Views.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
