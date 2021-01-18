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
    public class ValorRule
    {
        ValorDAO valorDAO = new ValorDAO();

        public List<Valor> listaValor()
        {
            return valorDAO.PesquisaValorLista();
        }

        public void IncluirValor(int codData, int codSubtipoValor, string valor)
        {
            if (listaValor().Exists(o => o.DataEmpresa.CodData == codData && o.SubtipoValor.CodSubtipoValor == codSubtipoValor && o.NumValor.ToString() == valor))
                MessageBox.Show("Valor já existente!");
            else
            {
                valorDAO.IncluirValor(codData, codSubtipoValor, valor);
                MessageBox.Show("Tipo de Valor cadastrado");
            }
        }

        public void ExcluiValor(int codValor)
        {
            valorDAO.ExcluiValor(codValor);
            MessageBox.Show("Valor Excluído");
        }

        public DataTable ElaboraTabelaValor(List<Valor> listaValor)
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
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Valor",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Subtipo",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (Valor valor in listaValor)
            {
                row = table.NewRow();
                row["id"] = valor.CodValor;
                row["Data"] = valor.DataEmpresa.Data.ToShortDateString();
                row["Valor"] = valor.NumValor;
                row["Subtipo"] = valor.SubtipoValor.DescSubtipo;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
