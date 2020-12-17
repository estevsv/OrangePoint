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
    }
}
