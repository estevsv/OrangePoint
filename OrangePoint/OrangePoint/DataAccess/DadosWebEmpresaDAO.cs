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
    public class DadosWebEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaDadosWebEmpresaTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.dados_web_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro DadosWebEmpresaDAO/PesquisaDadosWebEmpresaTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<DadosWebEmpresa> PesquisaDadosWebEmpresaLista()
        {
            List<DadosWebEmpresa> listDadosWebEmpresa = new List<DadosWebEmpresa>();
            List<Empresa> listEmpresa = empresaDAO.PesquisaEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.dados_web_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    DadosWebEmpresa dadosWebEmpresa = new DadosWebEmpresa();
                    dadosWebEmpresa.CodDadoWeb = int.Parse(registro["COD_DADO_WEB"].ToString());
                    dadosWebEmpresa.Empresa = listEmpresa.Find(o => o.CodEmpresa == int.Parse(registro["COD_EMPRESA"].ToString()));
                    dadosWebEmpresa.UsuarioWeb = registro["USUARIO_WEB"].ToString();
                    dadosWebEmpresa.SenhaWeb = registro["SENHA_WEB"].ToString();
                    dadosWebEmpresa.DescDado = registro["DESC_DADO"].ToString();

                    listDadosWebEmpresa.Add(dadosWebEmpresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro DadosWebEmpresaDAO/PesquisaDadosWebEmpresaLista. Contate o Suporte"); }
            return listDadosWebEmpresa;
        }

        public void ExcluiDadoWebEmpresa(int codDadoWebEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.dados_web_empresa where COD_DADO_WEB = " + codDadoWebEmpresa;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro DadosWebEmpresaDAO/ExcluiDadoWebEmpresa. Contate o Suporte");
            }
        }

        public void IncluirDadosWebEmpresa(int codEmpresa,string usuarioWeb, string senhaWeb, string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`dados_web_empresa` (`COD_EMPRESA`, `USUARIO_WEB`, `SENHA_WEB`, `DESC_DADO`) VALUES ('"+ codEmpresa + "', '"+ usuarioWeb + "', '"+ senhaWeb + "', '"+ descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro DadosWebEmpresaDAO/IncluirDadosWebEmpresa. Contate o Suporte");
            }
        }
    }
}
