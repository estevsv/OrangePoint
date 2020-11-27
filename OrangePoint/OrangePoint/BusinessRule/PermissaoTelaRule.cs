using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.BusinessRule
{
    public class PermissaoTelaRule
    {
        PermissaoTelaDAO permissaoTelaDAO = new PermissaoTelaDAO();
        TipoPermissaoDAO tipoPermissaoDAO = new TipoPermissaoDAO();

        public List<PermissaoTela> PesquisaPermissaoTela()
        {
            return permissaoTelaDAO.PesquisaPermissoesTela();
        }

        public DataTable FiltraPesquisaPermissaoTelaTabela()
        {
            List<PermissaoTela> listaPermissoesTelaTabela = PesquisaPermissaoTela();

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
                ColumnName = "TipoPermissao",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Tela",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach(PermissaoTela permissao in listaPermissoesTelaTabela)
            {
                row = table.NewRow();
                row["id"] = permissao.CodPermissaoTela;
                row["TipoPermissao"] = permissao.TipoPermissao.DescPermissao;
                row["Tela"] = permissao.DescTela;
                table.Rows.Add(row);
            }

            return table;
        }

        public void Incluir(int idTipoUsuario, string tela)
        {
            List<PermissaoTela> listaPermissoesTela = PesquisaPermissaoTela();
            if (!listaPermissoesTela.Exists(o => o.TipoPermissao.CodTipoPermissao == idTipoUsuario && o.DescTela == tela))
                permissaoTelaDAO.Incluir(idTipoUsuario, tela);
        }

        public void DeletarPorIdTipoPermissao(int idTipoPermissao)
        {
            permissaoTelaDAO.DeletarPorIdTipoPermissao(idTipoPermissao);
        }

        public void DeletarPorId(int id)
        {
            permissaoTelaDAO.DeletarPorId(id);
        }

    }
}
