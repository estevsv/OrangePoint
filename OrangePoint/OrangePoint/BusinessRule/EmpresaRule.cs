using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.BusinessRule
{
    public class EmpresaRule
    {
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaEmpresasTabela()
        {
            return empresaDAO.PesquisaEmpresasTabela();
        }

        public List<Empresa> listaEmpresas()
        {
            return empresaDAO.PesquisaEmpresasLista();
        }

        public DataTable ElaboraTabelaEmpresa(List<Empresa> listaEmpresa)
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
                ColumnName = "Razão Social",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "CNPJ",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Grupo",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Regime",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (Empresa empresa in listaEmpresa)
            {
                row = table.NewRow();
                row["id"] = empresa.CodEmpresa;
                row["Razão Social"] = empresa.RazaoSocial;
                row["CNPJ"] = empresa.CNPJ;
                row["Grupo"] = empresa.Grupo;
                row["Regime"] = empresa.Regime;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
