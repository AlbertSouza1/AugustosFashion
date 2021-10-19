using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades
{
    public class MDIParentSingleton
    {
        private MDIParentSingleton() { }

        private static FrmMDIParent InstanciaFrmMdiParent;
       
        public static FrmMDIParent InstanciarFrmMdiParent()
        {
            if(InstanciaFrmMdiParent == null)
            {
                InstanciaFrmMdiParent = new FrmMDIParent();
            }
            return InstanciaFrmMdiParent;
        }
    }
}
