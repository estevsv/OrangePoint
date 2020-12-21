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
    public class SubtipoAtividadeDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        AtividadeDAO atividadeDAO = new AtividadeDAO();
        SubtipoValorDAO subtipoValorDAO = new SubtipoValorDAO();

        public DataTable PesquisaSubtipoAtividadeTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.subtipo_atividade;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro SubtipoAtividadeDAO/PesquisaSubtipoAtividadeTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<SubtipoAtividade> PesquisaSubtipoAtividadeLista()
        {
            List<SubtipoAtividade> listSubtipoAtividade = new List<SubtipoAtividade>();
            List<Atividade> listAtividade = atividadeDAO.PesquisaAtividadeLista();
            List<SubtipoValor> listSubtipoValor = subtipoValorDAO.PesquisaSubtipoValorLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.subtipo_atividade;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    SubtipoAtividade subtipoAtividade = new SubtipoAtividade();
                    subtipoAtividade.CodSubtipoAtividade = int.Parse(registro["COD_SUBTIPO_ATIVIDADE"].ToString());
                    subtipoAtividade.Atividade = listAtividade.Find(o => o.CodAtividade == int.Parse(registro["COD_ATIVIDADE"].ToString()));
                    subtipoAtividade.SubtipoValor = listSubtipoValor.Find(o => o.CodSubtipoValor == int.Parse(registro["COD_SUBTIPO_VALOR"].ToString()));

                    listSubtipoAtividade.Add(subtipoAtividade);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro SubtipoAtividadeDAO/PesquisaSubtipoAtividadeLista. Contate o Suporte"); }
            return listSubtipoAtividade;
        }

        public void ExcluiSubtipoAtividade(int codSubtipoAtividade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.subtipo_atividade where COD_SUBTIPO_ATIVIDADE = " + codSubtipoAtividade;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro SubtipoAtividadeDAO/ExcluiSubtipoAtividade. Contate o Suporte");
            }
        }

        public void IncluirSubtipoAtividade(int codAtividade, int codSubtipoValor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`subtipo_atividade` (`COD_ATIVIDADE`, `COD_SUBTIPO_VALOR`) VALUES (" + codAtividade + "," + codSubtipoValor + ");";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro SubtipoAtividadeDAO/IncluirSubtipoAtividade. Contate o Suporte");
            }
        }

    }
}
