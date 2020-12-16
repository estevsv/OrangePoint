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
    public class RegimeEmpresaRule
    {
        RegimeEmpresaDAO regimeEmpresaDAO = new RegimeEmpresaDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaRegimeEmpresasTabela()
        {
            return regimeEmpresaDAO.PesquisaRegimeEmpresasTabela();
        }

        public List<RegimeEmpresa> listaRegimeEmpresas()
        {
            return regimeEmpresaDAO.PesquisaRegimeEmpresasLista();
        }

        public void IncluirRegimeEmpresa(string descricao)
        {
            if (listaRegimeEmpresas().Exists(o => o.Descricao == descricao))
                MessageBox.Show("Regime já existente!");
            else
            {
                regimeEmpresaDAO.IncluirRegimeEmpresa(descricao);
                MessageBox.Show("Regime cadastrado");
            }
        }

        public void ExcluiRegimeEmpresa(int codRegime)
        {
            List<Empresa> listaEmpresa = empresaDAO.PesquisaEmpresasLista();
            if (!listaEmpresa.Exists(o => o.Regime.CodRegime == codRegime))
            {
                regimeEmpresaDAO.ExcluiRegimeEmpresa(codRegime);
                MessageBox.Show("Regime Excluído");
            }
            else
                MessageBox.Show("Regime alocado em uma Empresa. Exclusão não realizada!");
        }
    }
}
