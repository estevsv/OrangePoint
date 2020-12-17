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
        AtividadeEmpresaDAO atividadeEmpresaDAO = new AtividadeEmpresaDAO();

        public DataTable PesquisaAtividadeTabela()
        {
            return AtividadeDAO.PesquisaAtividadeTabela();
        }

        public List<Atividade> listaAtividade()
        {
            return AtividadeDAO.PesquisaAtividadeLista();
        }

        public void IncluirAtividade(string descricao)
        {
            if (listaAtividade().Exists(o => o.Descricao == descricao))
                MessageBox.Show("Atividade já existente!");
            else
            {
                AtividadeDAO.IncluirAtividade(descricao);
                MessageBox.Show("Atividade cadastrado");
            }
        }

        public void ExcluiAtividade(int codAtividade)
        {
            List<AtividadeEmpresa> listaAtividadeEmpresa = atividadeEmpresaDAO.PesquisaAtividadeEmpresasLista();
            if (!listaAtividadeEmpresa.Exists(o => o.Atividade.CodAtividade == codAtividade))
            {
                AtividadeDAO.ExcluiAtividade(codAtividade);
                MessageBox.Show("Atividade Excluído");
            }
            else
                MessageBox.Show("Atividade alocada em uma Empresa. Exclusão não realizada!");
        }
    }
}
