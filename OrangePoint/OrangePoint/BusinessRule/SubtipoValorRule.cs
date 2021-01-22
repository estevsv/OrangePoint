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
    public class SubtipoValorRule
    {
        SubtipoValorDAO subtipoValorDAO = new SubtipoValorDAO();
        ValorRule valorRule = new ValorRule();

        public DataTable PesquisaSubtipoValorTabela()
        {
            return subtipoValorDAO.PesquisaSubtipoValorTabela();
        }

        public List<SubtipoValor> listaSubtipoValor()
        {
            return subtipoValorDAO.PesquisaSubtipoValorLista();
        }

        public void IncluirSubtipoValor(int codTipoValor, string descricao)
        {
            if (listaSubtipoValor().Exists(o => o.TipoValor.CodTipoValor == codTipoValor && o.DescSubtipo == descricao))
                MessageBox.Show("Subtipo já existente!");
            else
            {
                subtipoValorDAO.IncluirSubtipoValor(codTipoValor, descricao);
                MessageBox.Show("Subtipo Cadastrado!");
            }
        }

        public void ExcluiSubtipoValor(int codSubtipoValor)
        {
            List<Valor> listaValor = valorRule.listaValor();
            if (!listaValor.Exists(o => o.SubtipoValor.CodSubtipoValor == codSubtipoValor))
            {
                subtipoValorDAO.ExcluiSubtipoValor(codSubtipoValor);
                MessageBox.Show("Subtipo Removido!");
            }
            else
                MessageBox.Show("Subtipo já alocado em um valor de uma empresa. Exclusão não realizada!");

        }

        public DataTable FiltraPesquisaSubtipoValorTabela()
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
                ColumnName = "TipoValor",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "SubtipoValor",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (SubtipoValor subtipo in listaSubtipoValor())
            {
                row = table.NewRow();
                row["id"] = subtipo.CodSubtipoValor;
                row["TipoValor"] = subtipo.TipoValor.DescTipo;
                row["SubtipoValor"] = subtipo.DescSubtipo;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
