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
        AtividadeEmpresaRule atividadeEmpresaRule = new AtividadeEmpresaRule();
        SubtipoAtividadeRule subtipoAtividadeRule = new SubtipoAtividadeRule();

        public DataTable PesquisaSubtipoValorTabela()
        {
            return subtipoValorDAO.PesquisaSubtipoValorTabela();
        }

        public List<SubtipoValor> ListaSubtipoValor()
        {
            return subtipoValorDAO.PesquisaSubtipoValorLista();
        }

        public SubtipoValor PesquisaSubtipoValorPorId(int id)
        {
            return subtipoValorDAO.PesquisaSubtipoValorPorId(id);
        }

        public void IncluirSubtipoValor(int codTipoValor, string descricao, int id = -1)
        {
            if (id != -1)
            {
                subtipoValorDAO.AtualizaSubtipoValor(descricao, id);
                MessageBox.Show("Conta AnalíticaAtualizado");
            }
            else
                if (ListaSubtipoValor().Exists(o => o.TipoValor.CodTipoValor == codTipoValor && o.DescSubtipo == descricao))
                    MessageBox.Show("Conta Analíticajá existente!");
                else
                {
                    subtipoValorDAO.IncluirSubtipoValor(codTipoValor,descricao);
                    MessageBox.Show("Conta AnalíticaCadastrado!");
                }
        }

        public void ExcluiSubtipoValor(int codSubtipoValor)
        {
            List<Valor> listaValor = valorRule.listaValor();
            if (!listaValor.Exists(o => o.SubtipoValor.CodSubtipoValor == codSubtipoValor))
            {
                List<SubtipoAtividade> subtipoAtividade = subtipoAtividadeRule.listaSubtipoAtividade();
                if (!subtipoAtividade.Exists(o => o.SubtipoValor.CodSubtipoValor == codSubtipoValor))
                {
                    subtipoValorDAO.ExcluiSubtipoValor(codSubtipoValor);
                    MessageBox.Show("Conta AnalíticaRemovido!");
                }
                else
                    MessageBox.Show("Conta Analíticaalocado em uma atividade!");
            }
            else
                MessageBox.Show("Conta Analíticajá alocado em um valor de uma empresa. Exclusão não realizada!");

        }

        public DataTable FiltraPesquisaSubtipoValorTabela(List<SubtipoValor> listaSubtipoValor = null)
        {
            if(listaSubtipoValor == null)
                listaSubtipoValor = ListaSubtipoValor();
            listaSubtipoValor = listaSubtipoValor.OrderBy(o => o.DescSubtipo).ToList();
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

            foreach (SubtipoValor subtipo in listaSubtipoValor)
            {
                row = table.NewRow();
                row["id"] = subtipo.CodSubtipoValor;
                row["TipoValor"] = subtipo.TipoValor.DescTipo;
                row["SubtipoValor"] = subtipo.DescSubtipo;
                table.Rows.Add(row);
            }

            return table;
        }

        public List<SubtipoValor> ListaSubtiposPorEmpresa(Empresa empresa)
        {
            List<AtividadeEmpresa> listaAtividadesEmpresa = atividadeEmpresaRule.listaAtividadeEmpresas().Where(o => o.Empresa.CodEmpresa == empresa.CodEmpresa).ToList();
            List<SubtipoAtividade> listaSubtipoAtividade = subtipoAtividadeRule.listaSubtipoAtividade().Where(o => listaAtividadesEmpresa.Exists(p => p.Atividade.CodAtividade == o.Atividade.CodAtividade)).ToList();

            return ListaSubtipoValor().Where(o => listaSubtipoAtividade.Exists(p => p.SubtipoValor.CodSubtipoValor == o.CodSubtipoValor)).ToList();
        } 
    }
}
