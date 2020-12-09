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
    public class EmpresaRule
    {
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaEmpresasTabela()
        {
            return empresaDAO.PesquisaEmpresasTabela();
        }

        public List<Empresa> listaEmpresas()
        {
            return empresaDAO.PesquisaEmpresasLista();
        }
    }
}
