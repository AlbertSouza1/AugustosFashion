﻿using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace AugustosFashionModels.Entidades.Exporatacoes
{
    public static class ExportaPlanilha
    {
        public static bool Exportar<T>(List<T> lista, string nomeArquivo, string nomePlanilha) where T : class
        {
            try
            {
                bool exportado = false;

                var dataTable = ListaParaDataTable(lista);

                using (IXLWorkbook workbook = new XLWorkbook())
                {
                    workbook.Worksheets.Add(dataTable, nomePlanilha);

                    workbook.SaveAs(nomeArquivo);
                    exportado = true;
                }

                return exportado;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ListaParaDataTable<T>(List<T> items) where T : class
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }       
    }
}
