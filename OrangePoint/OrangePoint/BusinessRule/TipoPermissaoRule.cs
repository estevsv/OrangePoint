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
    public class TipoPermissaoRule
    {
        TipoPermissaoDAO tipoPermissaoDAO = new TipoPermissaoDAO();
        PermissoesDAO permissoesDAO = new PermissoesDAO();
        PermissaoTelaRule permissaoTelaRule = new PermissaoTelaRule();

        public DataTable PesquisaTodosTipoPermissaoTabela()
        {
            return tipoPermissaoDAO.PesquisaTodosTipoPermissaoTabela();
        }

        public List<TipoPermissao> PesquisaTodosTipoPermissaoLista()
        {
            return tipoPermissaoDAO.PesquisaTodosTipoPermissaoLista();
        }

        public void Incluir(string descTipoPermissao)
        {
            if (!PesquisaTodosTipoPermissaoLista().Exists(o => o.DescPermissao == descTipoPermissao))
            {
                tipoPermissaoDAO.Incluir(descTipoPermissao);
            }
            else
                MessageBox.Show("Tipo de Usuário já existente");
        }

        public void Deletar(int idTipoPermissao)
        {
            permissoesDAO.DeletarPorTipoPermissao(idTipoPermissao);
            permissaoTelaRule.DeletarPorIdTipoPermissao(idTipoPermissao);
            tipoPermissaoDAO.Deletar(idTipoPermissao);
        }
    }
}
