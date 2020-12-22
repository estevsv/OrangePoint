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

        public List<DataEmpresa> listaDataEmpresa()
        {
            return DataEmpresaDAO.PesquisaDataEmpresaLista();
        }

        public void IncluirDataEmpresa(int codTipoData, int codEmpresa, DateTime data)
        {
            if (listaDataEmpresa().Exists(o => o.TipoData.CodTipoData == codTipoData && o.Empresa.CodEmpresa == codEmpresa && o.Data.Date == data.Date))
                MessageBox.Show("Data já cadastrada!");
            else
            {
                DataEmpresaDAO.IncluirDataEmpresa(codTipoData, codEmpresa,data);
                MessageBox.Show("Data cadastrada!");
            }
        }

        public void ExcluiDataEmpresa(int codData)
        {
            DataEmpresaDAO.ExcluiDataEmpresa(codData);
            MessageBox.Show("Data Excluída!");
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
