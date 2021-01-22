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
    public class AtividadeEmpresaRule
    {
        AtividadeEmpresaDAO atividadeEmpresaDAO = new AtividadeEmpresaDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaAtividadeEmpresasTabela()
        {
            return atividadeEmpresaDAO.PesquisaAtividadeEmpresasTabela();
        }

        public List<AtividadeEmpresa> listaAtividadeEmpresas()
        {
            return atividadeEmpresaDAO.PesquisaAtividadeEmpresasLista();
        }

        public void IncluirAtividadeEmpresa(int codAtividade, int codEmpresa)
        {
            if (listaAtividadeEmpresas().Exists(o => o.Atividade.CodAtividade == codAtividade && o.Empresa.CodEmpresa == codEmpresa))
                MessageBox.Show("Atividade já alocada para esta Empresa!");
            else
            {
                atividadeEmpresaDAO.IncluirAtividadeEmpresa(codAtividade,codEmpresa);
                MessageBox.Show("Atividade alocada!");
            }
        }

        public void ExcluiAtividadeEmpresa(int codAtividadeEmpresa)
        {
            atividadeEmpresaDAO.ExcluiAtividadeEmpresa(codAtividadeEmpresa);
            MessageBox.Show("Altividade da empresa retirada!");
        }

        public DataTable ElaboraTabelaAtividadeEmpresa(List<AtividadeEmpresa> listaAtividadeEmpresas)
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

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (AtividadeEmpresa atividadeEmpresa in listaAtividadeEmpresas)
            {
                row = table.NewRow();
                row["id"] = atividadeEmpresa.CodAtividadeEmpresa;
                row["Atividade"] = atividadeEmpresa.Atividade.Descricao;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
