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
    public class SubtipoAtividadeRule
    {
        SubtipoAtividadeDAO subtipoAtividadeDAO = new SubtipoAtividadeDAO();

        public DataTable PesquisaSubtipoAtividadeTabela()
        {
            return subtipoAtividadeDAO.PesquisaSubtipoAtividadeTabela();
        }

        public List<SubtipoAtividade> listaSubtipoAtividade()
        {
            return subtipoAtividadeDAO.PesquisaSubtipoAtividadeLista();
        }

        public void IncluirSubtipoAtividade(int codAtividade, int codSubtipoValor)
        {
            if (listaSubtipoAtividade().Exists(o => o.Atividade.CodAtividade == codAtividade && o.SubtipoValor.CodSubtipoValor == codSubtipoValor))
                MessageBox.Show("Subtipo Atividade já existente!");
            else
            {
                subtipoAtividadeDAO.IncluirSubtipoAtividade(codAtividade, codSubtipoValor);
                MessageBox.Show("Subtipo Cadastrado!");
            }
        }

        public void ExcluiSubtipoAtividade(int codSubtipoAtividade)
        {
            subtipoAtividadeDAO.ExcluiSubtipoAtividade(codSubtipoAtividade);
            MessageBox.Show("Subtipo Removido!");
        }

        public DataTable FiltraPesquisaSubtipoAtividadeTabela()
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
                ColumnName = "Atividade",
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

            foreach (SubtipoAtividade subtipo in listaSubtipoAtividade())
            {
                row = table.NewRow();
                row["id"] = subtipo.CodSubtipoAtividade;
                row["Atividade"] = subtipo.Atividade.Descricao;
                row["SubtipoValor"] = subtipo.SubtipoValor.DescSubtipo;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
