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
    public class AtividadeRule
    {
        AtividadeDAO AtividadeDAO = new AtividadeDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaAtividadeTabela()
        {
            return AtividadeDAO.PesquisaAtividadeTabela();
        }

        public List<Atividade> listaAtividadeEmpresas()
        {
            return AtividadeDAO.PesquisaAtividadeLista();
        }

        public void IncluirGrupoEmpresa(string descricao)
        {
            if (listaGrupoEmpresas().Exists(o => o.Descricao == descricao))
                MessageBox.Show("Grupo já existente!");
            else
            {
                grupoDAO.IncluirGrupoEmpresa(descricao);
                MessageBox.Show("Grupo cadastrado");
            }
        }

        public void ExcluiGrupoEmpresa(int codGrupo)
        {
            List<Empresa> listaEmpresa = empresaDAO.PesquisaEmpresasLista();
            if (!listaEmpresa.Exists(o => o.Grupo.CodGrupo == codGrupo))
            {
                grupoDAO.ExcluiGrupoEmpresa(codGrupo);
                MessageBox.Show("Grupo Excluído");
            }
            else
                MessageBox.Show("Grupo alocado em uma Empresa. Exclusão não realizada!");
        }
    }
}
