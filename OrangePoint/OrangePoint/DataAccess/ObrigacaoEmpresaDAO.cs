using MySql.Data.MySqlClient;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.DataAccess
{
    public class ObrigacaoEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        TipoClassificacaoDAO tipoClassificacaoDAO = new TipoClassificacaoDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaObrigacaoEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.obrigacao_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro ObrigacaoEmpresaDAO/PesquisaObrigacaoEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<ObrigacaoEmpresa> PesquisaObrigacaoEmpresaLista()
        {
            List<ObrigacaoEmpresa> listObrigacaoEmpresa = new List<ObrigacaoEmpresa>();
            List<TipoClassificacao> listTipoClassificacao = tipoClassificacaoDAO.PesquisaTipoClassificacaoLista();
            List<Empresa> listEmpresaDAO = empresaDAO.PesquisaEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.obrigacao_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    ObrigacaoEmpresa obrigacaoEmpresa = new ObrigacaoEmpresa();
                    obrigacaoEmpresa.CodObrigacaoEmpresa = int.Parse(registro["COD_OBRIGACAO_EMPRESA"].ToString());
                    obrigacaoEmpresa.TipoClassificacao = listTipoClassificacao.Find(o => o.CodTipoClassificacao == int.Parse(registro["COD_TIPO_CLASSIFICACAO"].ToString()));
                    obrigacaoEmpresa.Empresa = listEmpresaDAO.Find(o => o.CodEmpresa == int.Parse(registro["COD_EMPRESA"].ToString()));

                    listObrigacaoEmpresa.Add(obrigacaoEmpresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro ObrigacaoEmpresaDAO/PesquisaObrigacaoEmpresaLista. Contate o Suporte"); }
            return listObrigacaoEmpresa;
        }

        public void ExcluiObrigacaoEmpresa(int codObrigacaoEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.obrigacao_empresa where COD_OBRIGACAO_EMPRESA = " + codObrigacaoEmpresa;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ObrigacaoEmpresaDAO/ExcluiObrigacaoEmpresa. Contate o Suporte");
            }
        }

        public void IncluirObrigacaoEmpresa(int codClassificacao, int codEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`obrigacao_empresa` (`COD_EMPRESA`, `COD_TIPO_CLASSIFICACAO`) VALUES  (" + codEmpresa + "," + codClassificacao + ");";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ObrigacaoEmpresaDAO/IncluirObrigacaoEmpresa. Contate o Suporte");
            }
        }
    }
}
