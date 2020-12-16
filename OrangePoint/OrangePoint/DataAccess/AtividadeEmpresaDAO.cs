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
    public class AtividadeEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        AtividadeDAO atividadeDAO = new AtividadeDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaAtividadeEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.empresa_atividade;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro AtividadeEmpresaDAO/PesquisaAtividadeEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<AtividadeEmpresa> PesquisaAtividadeEmpresasLista()
        {
            List<AtividadeEmpresa> listAtividadeEmpresa = new List<AtividadeEmpresa>();
            List<Atividade> listAtividadeDAO = atividadeDAO.PesquisaAtividadeLista();
            List<Empresa> listEmpresaDAO = empresaDAO.PesquisaEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.empresa_atividade;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    AtividadeEmpresa atividadeEmpresa = new AtividadeEmpresa();
                    atividadeEmpresa.CodAtividadeEmpresa = int.Parse(registro["COD_EMPRESA_ATIVIDADE"].ToString());
                    atividadeEmpresa.Atividade = listAtividadeDAO.Find(o => o.CodAtividade == int.Parse(registro["COD_ATIVIDADE"].ToString()));
                    atividadeEmpresa.Empresa = listEmpresaDAO.Find(o => o.CodEmpresa == int.Parse(registro["COD_EMPRESA"].ToString()));

                    listAtividadeEmpresa.Add(atividadeEmpresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro AtividadeEmpresaDAO/PesquisaAtividadeEmpresasLista. Contate o Suporte"); }
            return listAtividadeEmpresa;
        }

        public void ExcluiAtividadeEmpresa(int codAtividadeEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.empresa_atividade where COD_EMPRESA_ATIVIDADE = " + codAtividadeEmpresa;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro AtividadeEmpresaDAO/ExcluiAtividadeEmpresa. Contate o Suporte");
            }
        }

        public void IncluirAtividadeEmpresa(int codAtividade, int codEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`empresa_atividade` (`COD_ATIVIDADE`, `COD_EMPRESA`) VALUES (" + codAtividade + "," + codEmpresa + ");";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro AtividadeEmpresaDAO/IncluirAtividadeEmpresa. Contate o Suporte");
            }
        }
    }
}
