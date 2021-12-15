using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Helpers
{
    public class ParametroDeDados
    {
        //public ParametroDeDados(List<IRelatorio> relatorio, string nomeArquivo)
        //{
        //    Relatorio = relatorio;
        //    NomeArquivo = nomeArquivo;
        //}
        public ParametroDeDados()
        {

        }
        //public List<IRelatorio> Relatorio { get; private set; }
        public string NomeArquivo { get;  set; }
    }
}
