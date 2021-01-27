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
    public class TipoValorRule
    {
        SubtipoValorRule subtipoValorRule = new SubtipoValorRule();
        TipoValorDAO tipoValorDAO = new TipoValorDAO();

        public DataTable PesquisaTipoValorTabela()
        {
            return tipoValorDAO.PesquisaTipoValorTabela();
        }

        public List<TipoValor> listaTipoValor()
        {
            return tipoValorDAO.PesquisaTipoValorLista();
        }

        public void IncluirTipoValor(string descricao)
        {
            if (listaTipoValor().Exists(o => o.DescTipo == descricao))
                MessageBox.Show("Tipo de Valor já existente!");
            else
            {
                tipoValorDAO.IncluirTipoValor(descricao);
                MessageBox.Show("Tipo de Valor cadastrado");
            }
        }

        public void ExcluiTipoValor(int codTipoValor)
        {
            List<SubtipoValor> listaSubtipos = subtipoValorRule.ListaSubtipoValor();
            if (!listaSubtipos.Exists(o => o.TipoValor.CodTipoValor == codTipoValor))
            {
                tipoValorDAO.ExcluiTipoValor(codTipoValor);
                MessageBox.Show("Tipo de Valor Excluído");
            }
            else
                MessageBox.Show("Tipo de Valor alocado em um Subtipo de Valor. Exclusão não realizada!");
        }
    }
}
