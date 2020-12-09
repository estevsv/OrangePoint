using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.BusinessRule
{
    public class RegimeEmpresaRule
    {
        RegimeEmpresaDAO regimeEmpresaDAO = new RegimeEmpresaDAO();

        public DataTable PesquisaRegimeEmpresasTabela()
        {
            return regimeEmpresaDAO.PesquisaRegimeEmpresasTabela();
        }

        public List<RegimeEmpresa> listaRegimeEmpresas()
        {
            return regimeEmpresaDAO.PesquisaRegimeEmpresasLista();
        }
    }
}
