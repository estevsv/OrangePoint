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
    public class DadosWebRule
    {
        DadosWebEmpresaDAO dadosWebEmpresaDAO = new DadosWebEmpresaDAO();

        public DataTable PesquisaDadosWebEmpresaTabela()
        {
            return dadosWebEmpresaDAO.PesquisaDadosWebEmpresaTabela();
        }

        public List<DadosWebEmpresa> listaDadosWeb()
        {
            return dadosWebEmpresaDAO.PesquisaDadosWebEmpresaLista();
        }

        public void IncluirDadosWebEmpresa(int codEmpresa, string usuarioWeb, string senhaWeb, string descricao)
        {
            if (listaDadosWeb().Exists(o => o.Empresa.CodEmpresa == codEmpresa && o.UsuarioWeb == usuarioWeb && o.SenhaWeb == senhaWeb && o.DescDado == descricao))
                MessageBox.Show("Dado já existente!");
            else
            {
                dadosWebEmpresaDAO.IncluirDadosWebEmpresa(codEmpresa, usuarioWeb, senhaWeb, descricao);
                MessageBox.Show("Dado cadastrado");
            }
        }

        public void ExcluiDadosWebEmpresa(int codDado)
        {
            dadosWebEmpresaDAO.ExcluiDadoWebEmpresa(codDado);
            MessageBox.Show("Dado Excluído");
        }

        public DataTable FiltraPesquisaDadoWebTabela(int codEmpresa)
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
                ColumnName = "Usuário",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Senha",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Descrição",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (DadosWebEmpresa dado in listaDadosWeb().Where(o => o.Empresa.CodEmpresa == codEmpresa))
            {
                row = table.NewRow();
                row["id"] = dado.CodDadoWeb;
                row["Usuário"] = dado.UsuarioWeb;
                row["Senha"] = dado.SenhaWeb;
                row["Descrição"] = dado.DescDado;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
