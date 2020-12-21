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
    public class ClassificacaoEmpresaRule
    {
        ClassificacaoEmpresaDAO classificacaoEmpresaDAO = new ClassificacaoEmpresaDAO();
        DataEmpresaDAO dataEmpresaDAO = new DataEmpresaDAO();

        public DataTable PesquisaClassificacaoEmpresaTabela()
        {
            return classificacaoEmpresaDAO.PesquisaClassificacaoEmpresasTabela();
        }

        public List<ClassificacaoEmpresa> listaClassificacaoEmpresa()
        {
            return classificacaoEmpresaDAO.PesquisaClassificacaoEmpresasLista();
        }

        public void IncluirClassificacaoEmpresa(int codTipoClassificacao, int codData, int flagAtivo)
        {
            classificacaoEmpresaDAO.IncluirClassificacaoEmpresa(codTipoClassificacao, codData, flagAtivo);
            MessageBox.Show("Inclusão Concluído!");
        }

        public void ExcluiClassificacaoEmpresa(int codClassificacaoEmpresa)
        {
            classificacaoEmpresaDAO.ExcluiClassificacaoEmpresa(codClassificacaoEmpresa);
            MessageBox.Show("Exclusão Concluído!");
        }
    }
}
