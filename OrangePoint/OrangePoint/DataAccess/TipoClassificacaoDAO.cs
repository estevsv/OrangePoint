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
    public class TipoClassificacaoDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaTipoClassificacaoTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.tipo_classificao;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro TipoClassificacaoDAO/PesquisaTipoClassificacaoTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<TipoClassificacao> PesquisaTipoClassificacaoLista()
        {
            List<TipoClassificacao> listTipoClassificacao = new List<TipoClassificacao>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.tipo_classificao;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    TipoClassificacao tipoClassificacao = new TipoClassificacao();
                    tipoClassificacao.CodTipoClassificacao = int.Parse(registro["COD_TIPO_CLASSIFICACAO"].ToString());
                    tipoClassificacao.Descricao = registro["DESCRICAO"].ToString();

                    listTipoClassificacao.Add(tipoClassificacao);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro TipoClassificacaoDAO/PesquisaTipoDataLista. Contate o Suporte"); }
            return listTipoClassificacao;
        }

        public void ExcluiTipoClassificacao(int codTipoClassificacao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.tipo_classificao where COD_TIPO_CLASSIFICACAO = " + codTipoClassificacao;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoClassificacaoDAO/ExcluiTipoClassificacao. Contate o Suporte");
            }
        }

        public void IncluirTipoClassificacao(string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`tipo_classificao` (`DESCRICAO`) VALUES ('" + descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoClassificacaoDAO/IncluirTipoClassificacao. Contate o Suporte");
            }
        }

        public void AtualizaTipoClassificacao(string descricao, int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE `bdorangepoint`.`tipo_classificao` SET `DESCRICAO` = '"+descricao+"' WHERE (`COD_TIPO_CLASSIFICACAO` = '"+id+"');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoClassificacaoDAO/AtualizaTipoClassificacao. Contate o Suporte");
            }
        }
    }
}
