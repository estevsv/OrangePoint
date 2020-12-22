using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OrangePoint.Model;

namespace OrangePoint.DataAccess
{
    public class EmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        RegimeEmpresaDAO regimeEmpresaDAO = new RegimeEmpresaDAO();
        GrupoDAO grupoDAO = new GrupoDAO();

        public DataTable PesquisaEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro EmpresaDAO/PesquisaEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<Empresa> PesquisaEmpresasLista()
        {
            List<Empresa> listEmpresa = new List<Empresa>();
            List<RegimeEmpresa> listaRegimeEmpresa = regimeEmpresaDAO.PesquisaRegimeEmpresasLista();
            List<Grupo> listaGrupoEmpresa = grupoDAO.PesquisaGrupoEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.CodEmpresa = int.Parse(registro["COD_EMPRESA"].ToString());
                    empresa.Regime = listaRegimeEmpresa.Find(o => o.CodRegime == int.Parse(registro["COD_REGIME"].ToString()));
                    empresa.CNPJ = registro["CNPJ"].ToString();
                    empresa.ESocial = registro["ESOCIAL"].ToString();
                    empresa.Grupo = listaGrupoEmpresa.Find(o => o.CodGrupo == int.Parse(registro["COD_GRUPO"].ToString()));
                    empresa.NumSocios = int.Parse(registro["NUM_SOCIOS"].ToString() == "" ? "0" : registro["NUM_SOCIOS"].ToString());
                    empresa.NumVinculos = int.Parse(registro["NUM_VINCULOS"].ToString() == "" ? "0" : registro["NUM_VINCULOS"].ToString());
                    empresa.Observacao = registro["OBSERVACAO"].ToString();
                    empresa.RazaoSocial = registro["RAZAO_SOCIAL"].ToString();
                    empresa.SenhaSIAT = registro["NUM_VINCULOS"].ToString();
                    listEmpresa.Add(empresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro EmpresaDAO/PesquisaEmpresasLista. Contate o Suporte"); }
            return listEmpresa;
        }

        public void IncluirEmpresa(Empresa empresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`empresa` (`COD_REGIME`, `COD_GRUPO`, `RAZAO_SOCIAL`, `CNPJ`, `NUM_SOCIOS`, `NUM_VINCULOS`, `OBSERVACAO`, `SENHA_SIAT`, `ESOCIAL`) VALUES (@COD_REGIME, @COD_GRUPO, @RAZAO_SOCIAL, @CNPJ, @NUM_SOCIOS, @NUM_VINCULOS, @OBSERVACAO, @SENHA_SIAT, @ESOCIAL);";
                cmd.Parameters.AddWithValue("@COD_REGIME", empresa.Regime.CodRegime);
                cmd.Parameters.AddWithValue("@COD_GRUPO", empresa.Grupo.CodGrupo);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", empresa.RazaoSocial);
                cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                cmd.Parameters.AddWithValue("@NUM_SOCIOS", empresa.NumSocios);
                cmd.Parameters.AddWithValue("@NUM_VINCULOS", empresa.NumVinculos);
                cmd.Parameters.AddWithValue("@OBSERVACAO", empresa.Observacao);
                cmd.Parameters.AddWithValue("@SENHA_SIAT", empresa.SenhaSIAT);
                cmd.Parameters.AddWithValue("@ESOCIAL", empresa.SenhaSIAT);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro EmpresaDAO/IncluirEmpresa. Contate o Suporte"); }
        }

        public Empresa PesquisaEmpresaPorId(int idEmpresa)
        {
            Empresa empresa = new Empresa();
            List<RegimeEmpresa> listaRegimeEmpresa = regimeEmpresaDAO.PesquisaRegimeEmpresasLista();
            List<Grupo> listaGrupoEmpresa = grupoDAO.PesquisaGrupoEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.empresa where COD_EMPRESA = " + idEmpresa + ";";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    empresa.CodEmpresa = int.Parse(registro["COD_EMPRESA"].ToString());
                    empresa.Regime = listaRegimeEmpresa.Find(o => o.CodRegime == int.Parse(registro["COD_REGIME"].ToString()));
                    empresa.CNPJ = registro["CNPJ"].ToString();
                    empresa.ESocial = registro["ESOCIAL"].ToString();
                    empresa.Grupo = listaGrupoEmpresa.Find(o => o.CodGrupo == int.Parse(registro["COD_GRUPO"].ToString()));
                    empresa.NumSocios = int.Parse(registro["NUM_SOCIOS"].ToString() == "" ? "0" : registro["NUM_SOCIOS"].ToString());
                    empresa.NumVinculos = int.Parse(registro["NUM_VINCULOS"].ToString() == "" ? "0" : registro["NUM_VINCULOS"].ToString());
                    empresa.Observacao = registro["OBSERVACAO"].ToString();
                    empresa.RazaoSocial = registro["RAZAO_SOCIAL"].ToString();
                    empresa.SenhaSIAT = registro["SENHA_SIAT"].ToString();
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro EmpresaDAO/PesquisaEmpresaPorId. Contate o Suporte"); }
            return empresa;
        }

        public void AtualizaEmpresa(Empresa empresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update bdorangepoint.empresa set COD_REGIME = @COD_REGIME, COD_GRUPO = @COD_GRUPO, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, NUM_SOCIOS = @NUM_SOCIOS, NUM_VINCULOS = @NUM_VINCULOS, OBSERVACAO = @OBSERVACAO, SENHA_SIAT = @SENHA_SIAT, ESOCIAL = @ESOCIAL " +
                    "where COD_EMPRESA = @COD_EMPRESA;";
                cmd.Parameters.AddWithValue("@COD_EMPRESA", empresa.CodEmpresa);
                cmd.Parameters.AddWithValue("@COD_REGIME", empresa.Regime.CodRegime);
                cmd.Parameters.AddWithValue("@COD_GRUPO", empresa.Grupo.CodGrupo);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", empresa.RazaoSocial);
                cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                cmd.Parameters.AddWithValue("@NUM_SOCIOS", empresa.NumSocios);
                cmd.Parameters.AddWithValue("@NUM_VINCULOS", empresa.NumVinculos);
                cmd.Parameters.AddWithValue("@OBSERVACAO", empresa.Observacao);
                cmd.Parameters.AddWithValue("@SENHA_SIAT", empresa.SenhaSIAT);
                cmd.Parameters.AddWithValue("@ESOCIAL", empresa.ESocial);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro EmpresaDAO/AtualizaEmpresa. Contate o Suporte");
            }
        }
    }
}
