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
    public class ObrigacaoEmpresaRule
    {
        ObrigacaoEmpresaDAO obrigacaoEmpresaDAO = new ObrigacaoEmpresaDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaObrigacaoEmpresasTabela()
        {
            return obrigacaoEmpresaDAO.PesquisaObrigacaoEmpresasTabela();
        }

        public List<ObrigacaoEmpresa> listaObrigacaoEmpresas()
        {
            return obrigacaoEmpresaDAO.PesquisaObrigacaoEmpresaLista();
        }

        public void IncluirObrigacaoEmpresa(int codTipoClassificacao, int codEmpresa)
        {
            if (listaObrigacaoEmpresas().Exists(o => o.TipoClassificacao.CodTipoClassificacao == codTipoClassificacao && o.Empresa.CodEmpresa == codEmpresa))
                MessageBox.Show("Obrigação já alocada para esta Empresa!");
            else
            {
                obrigacaoEmpresaDAO.IncluirObrigacaoEmpresa(codTipoClassificacao, codEmpresa);
                MessageBox.Show("Obrigação alocada!");
            }
        }

        public void ExcluiObrigacaoEmpresa(int codObrigacaoEmpresa)
        {
            obrigacaoEmpresaDAO.ExcluiObrigacaoEmpresa(codObrigacaoEmpresa);
            MessageBox.Show("Obrigação da empresa retirada!");
        }

        public DataTable ElaboraTabelaObrigacaoEmpresa(List<ObrigacaoEmpresa> listaObrigacaoEmpresa)
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
                ColumnName = "Obrigação",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (ObrigacaoEmpresa obrigacaoEmpresa in listaObrigacaoEmpresa)
            {
                row = table.NewRow();
                row["id"] = obrigacaoEmpresa.CodObrigacaoEmpresa;
                row["Obrigação"] = obrigacaoEmpresa.TipoClassificacao.Descricao;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
