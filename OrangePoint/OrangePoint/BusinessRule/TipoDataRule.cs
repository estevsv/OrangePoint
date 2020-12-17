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
    public class TipoDataRule
    {
        DataEmpresaRule dataEmpresaRule = new DataEmpresaRule();
        TipoDataDAO tipoDataDAO = new TipoDataDAO();

        public DataTable PesquisaTipoDataTabela()
        {
            return tipoDataDAO.PesquisaTipoDataTabela();
        }

        public List<TipoData> listaTipoData()
        {
            return tipoDataDAO.PesquisaTipoDataLista();
        }

        public void IncluirTipoData(string descricao)
        {
            if (listaTipoData().Exists(o => o.DescTipoData == descricao))
                MessageBox.Show("Tipo de Data já existente!");
            else
            {
                tipoDataDAO.IncluirTipoData(descricao);
                MessageBox.Show("Tipo de Data cadastrada");
            }
        }

        public void ExcluiTipoData(int codTipoData)
        {
            List<DataEmpresa> listaDataEmpresa = dataEmpresaRule.listaDataEmpresa();
            if (!listaDataEmpresa.Exists(o => o.TipoData.CodTipoData == codTipoData))
            {
                tipoDataDAO.ExcluiTipoData(codTipoData);
                MessageBox.Show("TipoData Excluído");
            }
            else
                MessageBox.Show("TipoData com data ainda cadastrada. Exclusão não realizada!");
        }
    }
}
