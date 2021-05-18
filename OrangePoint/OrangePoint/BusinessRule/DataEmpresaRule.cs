using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.BusinessRule
{
    public class DataEmpresaRule
    {
        DataEmpresaDAO DataEmpresaDAO = new DataEmpresaDAO();

        public DataTable PesquisaDataEmpresaTabela()
        {
            return DataEmpresaDAO.PesquisaDataEmpresaTabela();
        }

        public List<DataEmpresa> listaDataEmpresa(int codEmpresa = -1, string data = "")
        {
            return DataEmpresaDAO.PesquisaDataEmpresaLista(codEmpresa, data);
        }

        public void IncluirDataEmpresa(int codEmpresa, string data)
        {
            Tuple<bool, DateTime> retornaDataValida = RetornaDataValida(data);
            if (retornaDataValida.Item1)
                if (listaDataEmpresa().Exists(o => o.Empresa.CodEmpresa == codEmpresa && o.Data.Date == retornaDataValida.Item2.Date))
                    MessageBox.Show("Data já cadastrada!");
                else
                {
                    DataEmpresaDAO.IncluirDataEmpresa(codEmpresa, retornaDataValida.Item2);
                }
            else
                MessageBox.Show("Data Inválida!");
        }

        public Tuple<bool,DateTime> RetornaDataValida(string data)
        {
            DateTime dataConversao = new DateTime();
            return new Tuple<bool, DateTime>(DateTime.TryParse(data, out dataConversao),dataConversao);
        }

        public DataTable ElaboraTabelaDataEmpresa(List<DataEmpresa> listaDataEmpresa)
        {
            DataTable table = new DataTable("TabelaGridClasse");
            DataColumn column;
            DataRow row;
            column = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "id",
                ReadOnly = true,
                Unique = true
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Data",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (DataEmpresa data in listaDataEmpresa)
            {
                row = table.NewRow();
                row["id"] = data.CodData;
                row["Data"] = data.Data.ToShortDateString();
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
