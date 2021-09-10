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

        public void IncluirTipoValor(string descricao, int id = -1)
        {
            if (id != -1)
            {
                tipoValorDAO.AtualizaTipoValor(descricao, id);
                MessageBox.Show("Conta Sintética Atualizado");
            }
            else
                if (listaTipoValor().Exists(o => o.DescTipo == descricao))
                    MessageBox.Show("Conta Sintética já existente!");
                else
                {   
                    tipoValorDAO.IncluirTipoValor(descricao);
                    MessageBox.Show("Conta Sintética cadastrado");
                }
        }

        public void ExcluiTipoValor(int codTipoValor)
        {
            List<SubtipoValor> listaSubtipos = subtipoValorRule.ListaSubtipoValor();
            if (!listaSubtipos.Exists(o => o.TipoValor.CodTipoValor == codTipoValor))
            {
                tipoValorDAO.ExcluiTipoValor(codTipoValor);
                MessageBox.Show("Conta Sintética Excluído");
            }
            else
                MessageBox.Show("Conta Sintética alocado em um SubConta Sintética. Exclusão não realizada!");
        }
    }
}
