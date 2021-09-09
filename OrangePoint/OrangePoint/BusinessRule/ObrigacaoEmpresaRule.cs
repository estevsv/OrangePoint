using OrangePoint.DataAccess;
using OrangePoint.Model;
using OrangePoint.Resources;
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
        Utilities utilities = new Utilities();

        public DataTable PesquisaObrigacaoEmpresasTabela()
        {
            return obrigacaoEmpresaDAO.PesquisaObrigacaoEmpresasTabela();
        }

        public List<ObrigacaoEmpresa> listaObrigacaoEmpresas()
        {
            return obrigacaoEmpresaDAO.PesquisaObrigacaoEmpresaLista();
        }

        public void IncluirObrigacaoEmpresa(int codTipoClassificacao, int codEmpresa, int tipo, DateTime dataInicio, DateTime dataFim)
        {
            obrigacaoEmpresaDAO.IncluirObrigacaoEmpresa(codTipoClassificacao, codEmpresa, tipo, dataInicio, dataFim);
            MessageBox.Show("Obrigação alocada!");
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
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "idTipoObrigação",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Tipo",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Data Início",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Data Fim",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "NomeCompleto",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (ObrigacaoEmpresa obrigacaoEmpresa in listaObrigacaoEmpresa.OrderByDescending(o => o.DataFim))
            {
                string dataInicio = "";
                string dataFim = "";

                row = table.NewRow();
                row["id"] = obrigacaoEmpresa.CodObrigacaoEmpresa;
                row["idTipoObrigação"] = obrigacaoEmpresa.TipoClassificacao.CodTipoClassificacao;
                row["Obrigação"] = obrigacaoEmpresa.TipoClassificacao.Descricao;
                row["Tipo"] = obrigacaoEmpresa.TipoObrigacao == 1 ? "Mensal" : "Anual";

                if(obrigacaoEmpresa.DataInicio != DateTime.MinValue)
                    dataInicio = obrigacaoEmpresa.DataInicio.ToShortDateString();
                if (obrigacaoEmpresa.DataInicio != DateTime.MinValue)
                    dataFim = obrigacaoEmpresa.DataFim.ToShortDateString();

                row["Data Início"] = dataInicio;
                row["Data Fim"] = dataFim;
                row["NomeCompleto"] = obrigacaoEmpresa.TipoClassificacao.Descricao + " - " + dataInicio + " - " + dataFim;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
