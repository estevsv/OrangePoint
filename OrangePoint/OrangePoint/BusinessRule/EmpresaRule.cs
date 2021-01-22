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
    public class EmpresaRule
    {
        EmpresaDAO empresaDAO = new EmpresaDAO();
        RegimeEmpresaRule regimeEmpresaRule = new RegimeEmpresaRule();
        GrupoRule grupoRule = new GrupoRule();

        public DataTable PesquisaEmpresasTabela()
        {
            return empresaDAO.PesquisaEmpresasTabela();
        }

        public List<Empresa> listaEmpresas()
        {
            return empresaDAO.PesquisaEmpresasLista();
        }

        public DataTable ElaboraTabelaEmpresa(List<Empresa> listaEmpresa)
        {
            DataTable table = new DataTable("TabelaGridClasse");
            DataColumn column;
            DataRow row;
            column = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "id",
                ReadOnly = true,
                Unique = true
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Razão Social",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "CNPJ",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Grupo",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Regime",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            foreach (Empresa empresa in listaEmpresa)
            {
                row = table.NewRow();
                row["id"] = empresa.CodEmpresa;
                row["Razão Social"] = empresa.RazaoSocial;
                row["CNPJ"] = empresa.CNPJ;
                row["Grupo"] = empresa.Grupo.Descricao;
                row["Regime"] = empresa.Regime.Descricao;
                table.Rows.Add(row);
            }

            return table;
        }

        public void IncluirEmpresa(int codRegime, int codGrupo, string razaoSocial, string CNPJ, int numSocios, int numVinculos, string observacao, string senhaSiat, string Esocial)
        {
            if (!EmpresaExistente(CNPJ, razaoSocial, codRegime, codGrupo))
            {
                Empresa empresa = CarregaDadosEmpresa(new Empresa(), codRegime, codGrupo, razaoSocial, CNPJ, numSocios, numVinculos, observacao, senhaSiat, Esocial);

                empresaDAO.IncluirEmpresa(empresa);

                MessageBox.Show("Cadastro Realizado!");
            }
            else 
                MessageBox.Show("Empresa Existente!");
        }

        private bool EmpresaExistente(string CNPJ, string razaoSocial, int codRegime, int codGrupo)
        {
            return empresaDAO.PesquisaEmpresasLista().Exists(o => o.CNPJ == CNPJ ||( o.RazaoSocial == razaoSocial && o.Regime.CodRegime == codRegime && o.Grupo.CodGrupo == codGrupo));
        }

        public Empresa PesquisaEmpresaPorId(int idEmpresa)
        {
            return empresaDAO.PesquisaEmpresaPorId(idEmpresa);
        }

        public void AtualizarEmpresa(int codEmpresa , int codRegime, int codGrupo, string razaoSocial, string CNPJ, int numSocios, int numVinculos, string observacao, 
            string senhaSiat, string Esocial)
        {
            Empresa empresa = CarregaDadosEmpresa(new Empresa(), codRegime, codGrupo, razaoSocial, CNPJ, numSocios, numVinculos, observacao, senhaSiat, Esocial);
            empresa.CodEmpresa = codEmpresa;

            empresaDAO.AtualizaEmpresa(empresa);

            MessageBox.Show("Atualização Realizada!");
        }

        private Empresa CarregaDadosEmpresa(Empresa empresa,int codRegime, int codGrupo, string razaoSocial, string CNPJ, int numSocios, int numVinculos, string observacao,
            string senhaSiat, string Esocial)
        {
            empresa.Regime = regimeEmpresaRule.listaRegimeEmpresas().Find(o => o.CodRegime == codRegime);
            empresa.Grupo = grupoRule.listaGrupoEmpresas().Find(o => o.CodGrupo == codGrupo);
            empresa.RazaoSocial = razaoSocial;
            empresa.CNPJ = CNPJ;
            empresa.NumSocios = numSocios;
            empresa.NumVinculos = numVinculos;
            empresa.Observacao = observacao;
            empresa.Email= senhaSiat;
            empresa.Telefone = Esocial;

            return empresa;
        }
    }
}
