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
    public class TipoClassificacaoRule
    {
        TipoClassificacaoDAO tipoClassificacaoDAO = new TipoClassificacaoDAO();
        ClassificacaoEmpresaRule classificacaoEmpresaRule = new ClassificacaoEmpresaRule();
        ObrigacaoEmpresaRule obrigacaoEmpresaRule = new ObrigacaoEmpresaRule();

        public DataTable PesquisaTipoClassificacaoTabela()
        {
            return tipoClassificacaoDAO.PesquisaTipoClassificacaoTabela();
        }

        public List<TipoClassificacao> listaTipoClassificacao()
        {
            return tipoClassificacaoDAO.PesquisaTipoClassificacaoLista();
        }

        public void IncluirTipoClassificacao(string descricao, int id = -1)
        {
            if (id != -1)
            {
                tipoClassificacaoDAO.AtualizaTipoClassificacao(descricao, id);
                MessageBox.Show("Obrigação Atualizada");
            }
            else
                if (listaTipoClassificacao().Exists(o => o.Descricao == descricao))
                    MessageBox.Show("Obrigação já existente!");
                else
                {
                    tipoClassificacaoDAO.IncluirTipoClassificacao(descricao);
                    MessageBox.Show("Obrigação cadastrada");
                }
        }

        public void ExcluiTipoClassificacao(int codTipoClassificacao)
        {
            List<ClassificacaoEmpresa> listaClassificacaoEmpresa = classificacaoEmpresaRule.listaClassificacaoEmpresa();
            List<ObrigacaoEmpresa> listaObrigacaoEmpresa = obrigacaoEmpresaRule.listaObrigacaoEmpresas();

            if (!listaClassificacaoEmpresa.Exists(o => o.TipoClassificacao.CodTipoClassificacao == codTipoClassificacao) && 
                !listaObrigacaoEmpresa.Exists(o => o.TipoClassificacao.CodTipoClassificacao == codTipoClassificacao))
            {
                tipoClassificacaoDAO.ExcluiTipoClassificacao(codTipoClassificacao);
                MessageBox.Show("Tipo Excluído");
            }
            else
                MessageBox.Show("Obrigação já alocada em uma empresa por uma data ou cadastro de obrigações. Exclusão não realizada!");
        }
    }
}
