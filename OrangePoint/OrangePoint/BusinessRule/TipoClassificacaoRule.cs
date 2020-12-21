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

        public DataTable PesquisaTipoClassificacaoTabela()
        {
            return tipoClassificacaoDAO.PesquisaTipoClassificacaoTabela();
        }

        public List<TipoClassificacao> listaTipoClassificacao()
        {
            return tipoClassificacaoDAO.PesquisaTipoClassificacaoLista();
        }

        public void IncluirTipoClassificacao(string descricao)
        {
            if (listaTipoClassificacao().Exists(o => o.Descricao == descricao))
                MessageBox.Show("Tipo de Classificacao já existente!");
            else
            {
                tipoClassificacaoDAO.IncluirTipoClassificacao(descricao);
                MessageBox.Show("Tipo de Classificacao cadastrado");
            }
        }

        public void ExcluiTipoClassificacao(int codTipoClassificacao)
        {
            List<ClassificacaoEmpresa> listaClassificacaoEmpresa = classificacaoEmpresaRule.listaClassificacaoEmpresa();
            if (!listaClassificacaoEmpresa.Exists(o => o.TipoClassificacao.CodTipoClassificacao == codTipoClassificacao))
            {
                tipoClassificacaoDAO.ExcluiTipoClassificacao(codTipoClassificacao);
                MessageBox.Show("Tipo Excluído");
            }
            else
                MessageBox.Show("Tipo de classificação já alocado em em uma data de uma empresa. Exclusão não realizada!");
        }
    }
}
