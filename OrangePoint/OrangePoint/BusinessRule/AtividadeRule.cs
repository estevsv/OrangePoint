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
        AtividadeDAO atividadeDAO = new AtividadeDAO();
        AtividadeEmpresaDAO atividadeEmpresaDAO = new AtividadeEmpresaDAO();

        public DataTable PesquisaAtividadeTabela()
        {
            return atividadeDAO.PesquisaAtividadeTabela();
        }

        public List<Atividade> listaAtividade()
        {
            return atividadeDAO.PesquisaAtividadeLista();
        }

        public void IncluirAtividade(string descricao, int id = -1)
        {
            if (id != -1)
            {
                atividadeDAO.AtualizaAtividade(descricao, id);
                MessageBox.Show("Atividade Atualizada");
            }
            else
                if (listaAtividade().Exists(o => o.Descricao == descricao))
                    MessageBox.Show("Atividade já existente!");
                else
                {
                    atividadeDAO.IncluirAtividade(descricao);
                    MessageBox.Show("Atividade cadastrado");
                }
        }

        public void ExcluiAtividade(int codAtividade)
        {
            List<AtividadeEmpresa> listaAtividadeEmpresa = atividadeEmpresaDAO.PesquisaAtividadeEmpresasLista();
            if (!listaAtividadeEmpresa.Exists(o => o.Atividade.CodAtividade == codAtividade))
            {
                atividadeDAO.ExcluiAtividade(codAtividade);
                MessageBox.Show("Atividade Excluído");
            }
            else
                MessageBox.Show("Atividade alocada em uma Empresa. Exclusão não realizada!");
        }
    }
}
