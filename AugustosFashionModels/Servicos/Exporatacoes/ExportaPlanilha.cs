using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using ClosedXML.Excel;
using FastMember;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AugustosFashionModels.Entidades.Exporatacoes
{
    public static class ExportaPlanilha
    {
        public static bool Exportar(DataTable dataTable, string nomeArquivo, string nomePlanilha)
        {            
            bool exportado = false;

            //DataTable data = new DataTable();

            //using (var reader = ObjectReader.Create(lista))
            //{
            //    data.Load(reader);

            //}

            using (IXLWorkbook workbook = new XLWorkbook())
            {
                //workbook.AddWorksheet(nomePlanilha).FirstCell().InsertTable<T>((IEnumerable<T>)data, false);
                workbook.Worksheets.Add(dataTable, nomePlanilha);

                workbook.SaveAs(nomeArquivo);
                exportado = true;
            }

            return exportado;
        }

        public static DataTable SetarDadosEmDataTable(List<RelatorioPedidoProduto> lista)
        {
            DataTable data = new DataTable();

            data.Columns.Add("Produto");
            data.Columns.Add("Vezes Vendido");
            data.Columns.Add("Total Custo");
            data.Columns.Add("Total Bruto");
            data.Columns.Add("Total Desconto");
            data.Columns.Add("Total Líquido");
            data.Columns.Add("Lucro (R$)");
            data.Columns.Add("Lucro (%)");

            var i = 1;

            foreach (var item in lista)
            {
                data.Rows.Add(item.Nome, item.QuantidadeVendida, item.TotalCusto.RetornaValor, item.TotalBruto.RetornaValor, item.TotalDesconto.RetornaValor, item.TotalLiquido.RetornaValor, item.LucroReais.RetornaValor, RemoverPorcentagem(item.LucroPorcentagem));
                i++;
            }
            return data;
        }

        private static string RemoverPorcentagem(string valor)
        {
            foreach (char c in "%")
            {
                valor = valor.Replace(c.ToString(), string.Empty);
            }

            return valor;
        }
    }
}
