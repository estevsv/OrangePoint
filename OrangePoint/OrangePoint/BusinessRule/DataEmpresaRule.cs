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
    public class DataEmpresaRule
    {
        DataEmpresaDAO DataEmpresaDAO = new DataEmpresaDAO();

        public DataTable PesquisaDataEmpresaTabela()
        {
            return DataEmpresaDAO.PesquisaDataEmpresaTabela();
        }

        public List<DataEmpresa> listaDataEmpresa()
        {
            return DataEmpresaDAO.PesquisaDataEmpresaLista();
        }

        public void IncluirDataEmpresa(int codTipoData, int codEmpresa, DateTime data)
        {
            if (listaDataEmpresa().Exists(o => o.TipoData.CodTipoData == codTipoData && o.Empresa.CodEmpresa == codEmpresa && o.Data.Date == data.Date))
                MessageBox.Show("Data já cadastrada!");
            else
            {
                DataEmpresaDAO.IncluirDataEmpresa(codTipoData, codEmpresa,data);
                MessageBox.Show("Data cadastrada!");
            }
        }

        public void ExcluiDataEmpresa(int codData)
        {
            DataEmpresaDAO.ExcluiDataEmpresa(codData);
            MessageBox.Show("Data Excluída!");
        }
    }
}
