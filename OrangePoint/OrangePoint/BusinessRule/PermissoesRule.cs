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
    }
}
