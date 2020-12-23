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
    public class ClassificacaoEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        TipoClassificacaoDAO tipoClassificacaoDAO = new TipoClassificacaoDAO();
        DataEmpresaDAO dataEmpresaDAO = new DataEmpresaDAO();

        public DataTable PesquisaClassificacaoEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.classificacao_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro ClassificacaoEmpresaDAO/PesquisaClassificacaoEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<ClassificacaoEmpresa> PesquisaClassificacaoEmpresasLista()
        {
            List<ClassificacaoEmpresa> listClassificacaoEmpresa = new List<ClassificacaoEmpresa>();
            List<TipoClassificacao> listTipoClassificacaoDAO = tipoClassificacaoDAO.PesquisaTipoClassificacaoLista();
            List<DataEmpresa> listDataEmpresaDAO = dataEmpresaDAO.PesquisaDataEmpresaLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.classificacao_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    ClassificacaoEmpresa classificacaoEmpresa = new ClassificacaoEmpresa();
                    classificacaoEmpresa.CodClassificacao = int.Parse(registro["COD_CLASSIFICACAO"].ToString());
                    classificacaoEmpresa.TipoClassificacao = listTipoClassificacaoDAO.Find(o => o.CodTipoClassificacao == int.Parse(registro["COD_TIPO_CLASSIFICACAO"].ToString()));
                    classificacaoEmpresa.DataEmpresa = listDataEmpresaDAO.Find(o => o.CodData == int.Parse(registro["COD_DATA"].ToString()));

                    listClassificacaoEmpresa.Add(classificacaoEmpresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro ClassificacaoEmpresaDAO/PesquisaClassificacaoEmpresasLista. Contate o Suporte"); }
            return listClassificacaoEmpresa;
        }

        public void ExcluiClassificacaoEmpresa(int codClassificacaoEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.classificacao_empresa where COD_CLASSIFICACAO = " + codClassificacaoEmpresa;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ClassificacaoEmpresaDAO/ExcluiClassificacaoEmpresa. Contate o Suporte");
            }
        }

        public void IncluirClassificacaoEmpresa(int codTipoClassificacao, int codData)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`classificacao_empresa` (`COD_TIPO_CLASSIFICACAO`, `COD_DATA`) VALUES (" + codTipoClassificacao + "," + codData + ");";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ClassificacaoEmpresaDAO/IncluirClassificacaoEmpresa. Contate o Suporte");
            }
        }
    }
}
