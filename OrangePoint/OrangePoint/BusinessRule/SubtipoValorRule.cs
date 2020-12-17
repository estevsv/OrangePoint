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
    public class SubtipoValorRule
    {
        SubtipoValorDAO subtipoValorDAO = new SubtipoValorDAO();

        public DataTable PesquisaSubtipoValorTabela()
        {
            return subtipoValorDAO.PesquisaSubtipoValorTabela();
        }

        public List<SubtipoValor> listaSubtipoValor()
        {
            return subtipoValorDAO.PesquisaSubtipoValorLista();
        }

        public void IncluirSubtipoValor(int codTipoValor, string descricao)
        {
            if (listaSubtipoValor().Exists(o => o.TipoValor.CodTipoValor == codTipoValor && o.DescSubtipo == descricao))
                MessageBox.Show("Subtipo já existente!");
            else
            {
                subtipoValorDAO.IncluirSubtipoValor(codTipoValor, descricao);
                MessageBox.Show("Subtipo Cadastrado!");
            }
        }

        public void ExcluiSubtipoValor(int codSubtipoValor)
        {
            subtipoValorDAO.ExcluiSubtipoValor(codSubtipoValor);
            MessageBox.Show("Subtipo Removido!");
        }
    }
}
