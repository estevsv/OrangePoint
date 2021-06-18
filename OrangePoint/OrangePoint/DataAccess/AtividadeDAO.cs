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
    public class AtividadeDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaAtividadeTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.atividade;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro AtividadeDAO/PesquisaAtividadeEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<Atividade> PesquisaAtividadeLista()
        {
            List<Atividade> listAtividadeEmpresa = new List<Atividade>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.atividade;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    Atividade Atividade = new Atividade();
                    Atividade.CodAtividade = int.Parse(registro["COD_ATIVIDADE"].ToString());
                    Atividade.Descricao = registro["DESCRICAO"].ToString();

                    listAtividadeEmpresa.Add(Atividade);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro AtividadeDAO/PesquisaAtividadeEmpresasLista. Contate o Suporte"); }
            return listAtividadeEmpresa;
        }

        public Atividade PesquisaAtividade(int codAtividade)
        {
            Atividade atividade = new Atividade();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from `bdorangepoint`.`atividade` where COD_ATIVIDADE = '" + codAtividade + "';";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                registro.Read();
                if (registro.HasRows)
                {
                    atividade.CodAtividade = codAtividade;
                    atividade.Descricao = registro["DESCRICAO"].ToString();
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro AtividadeDAO/PesquisaAtividade. Contate o Suporte"); }
            return atividade;
        }

        public void ExcluiAtividade(int codAtividade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.atividade where COD_ATIVIDADE = " + codAtividade;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro AtividadeDAO/ExcluiAtividadeEmpresa. Contate o Suporte");
            }
        }

        public void IncluirAtividade(string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`atividade` (`DESCRICAO`) VALUES ('" + descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro AtividadeDAO/IncluirAtividadeEmpresa. Contate o Suporte");
            }
        }

        public void AtualizaAtividade(string descricao, int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE `bdorangepoint`.`atividade` SET `DESCRICAO` = '"+ descricao +"' WHERE (`COD_ATIVIDADE` = '"+ id +"');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro AtividadeDAO/AtualizaAtividade. Contate o Suporte");
            }
        }
    }
}
