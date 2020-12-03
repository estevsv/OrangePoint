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
    public class PermissoesRule
    {
        PermissoesDAO permissoesDAO = new PermissoesDAO();

        public List<Permissoes> PesquisaTodasPermissoes()
        {
            return permissoesDAO.PesquisaTodasPermissoes();
        }

        public DataTable PesquisaTodasPermissoesTabela()
        {
            return permissoesDAO.PesquisaTodasPermissaoTabela();
        }

        public void Update(Permissoes permissao)
        {
            permissoesDAO.Update(permissao);
        }

        public void Incluir(Permissoes permissao)
        {
            if (!PesquisaTodasPermissoes().Exists(o => o.Usuario.CodUsuario == permissao.Usuario.CodUsuario))
            {
                permissoesDAO.Incluir(permissao);
            }
            else if (DialogResult.Yes == MessageBox.Show("Este usuário já possui permissão de '" + permissao.Usuario.TipoPermissao.DescPermissao +"', deseja substituir a permissão para '"+ permissao.TipoPermissao.DescPermissao +"'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                Update(permissao);
            }
        }

        public DataTable FiltraPesquisaPermissaoTelaTabela()
        {
            List<Permissoes> listaPermissoesLista = PesquisaTodasPermissoes();

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
                ColumnName = "Usuario",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Permissao",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (Permissoes permissao in listaPermissoesLista)
            {
                row = table.NewRow();
                row["id"] = permissao.CodPermissao;
                row["Usuario"] = permissao.Usuario.Login;
                row["Permissao"] = permissao.TipoPermissao.DescPermissao;
                table.Rows.Add(row);
            }

            return table;
        }

        public void Excluir(int codPermissao)
        {
            permissoesDAO.Excluir(codPermissao);
        }

        public void ExcluirPorUsuario(int codUsuario)
        {
            permissoesDAO.ExcluirPorUsuario(codUsuario);
        }
    }
}
