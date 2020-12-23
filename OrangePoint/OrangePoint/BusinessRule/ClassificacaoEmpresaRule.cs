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
    public class ClassificacaoEmpresaRule
    {
        ClassificacaoEmpresaDAO classificacaoEmpresaDAO = new ClassificacaoEmpresaDAO();
        DataEmpresaDAO dataEmpresaDAO = new DataEmpresaDAO();

        public DataTable PesquisaClassificacaoEmpresaTabela()
        {
            return classificacaoEmpresaDAO.PesquisaClassificacaoEmpresasTabela();
        }

        public List<ClassificacaoEmpresa> listaClassificacaoEmpresa()
        {
            return classificacaoEmpresaDAO.PesquisaClassificacaoEmpresasLista();
        }

        public void IncluirClassificacaoEmpresa(int codTipoClassificacao, int codData)
        {
            classificacaoEmpresaDAO.IncluirClassificacaoEmpresa(codTipoClassificacao, codData);
            MessageBox.Show("Inclusão Concluída!");
        }

        public void ExcluiClassificacaoEmpresa(int codClassificacaoEmpresa)
        {
            classificacaoEmpresaDAO.ExcluiClassificacaoEmpresa(codClassificacaoEmpresa);
            MessageBox.Show("Exclusão Concluída!");
        }

        public DataTable ElaboraTabelaClassificacaoEmpresa(List<ClassificacaoEmpresa> listClassificacaoEmpresa)
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
                ColumnName = "Tipo Classificacao",
                ReadOnly = true,
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

            foreach (ClassificacaoEmpresa classificacaoEmpresa in listClassificacaoEmpresa)
            {
                row = table.NewRow();
                row["id"] = classificacaoEmpresa.CodClassificacao;
                row["Tipo Classificacao"] = classificacaoEmpresa.TipoClassificacao.Descricao;
                row["Data"] = classificacaoEmpresa.DataEmpresa.Data.ToShortDateString();
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
