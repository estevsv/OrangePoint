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
    public class FolhadePontoDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public void Incluir(FolhaPonto folhaPonto)
        {
            string dataPesquisa = folhaPonto.DataPonto.Year + "-" + folhaPonto.DataPonto.Month + "-" + folhaPonto.DataPonto.Day;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO bdorangepoint.folha_ponto_usuario(COD_USUARIO, DATA_PONTO, ENTRADA_1, SAIDA_1, ENTRADA_2, SAIDA_2,OBSERVACAO) VALUES(@COD_USUARIO, @DATA_PONTO, @ENTRADA_1, @SAIDA_1, @ENTRADA_2, @SAIDA_2, @OBSERVACAO);";
                cmd.Parameters.AddWithValue("@COD_USUARIO", folhaPonto.Usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@DATA_PONTO", dataPesquisa);
                cmd.Parameters.AddWithValue("@ENTRADA_1", folhaPonto.Entrada1);
                cmd.Parameters.AddWithValue("@SAIDA_1", folhaPonto.Saida1);
                cmd.Parameters.AddWithValue("@ENTRADA_2", folhaPonto.Entrada2);
                cmd.Parameters.AddWithValue("@SAIDA_2", folhaPonto.Saida2);
                cmd.Parameters.AddWithValue("@OBSERVACAO", folhaPonto.Observacao);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro FolhaPontoDAO/Incluir. Contate o Suporte"); }
        }

        public void AtualizaObservacao(DateTime data, string observacao, Usuario usuario)
        {
            try
            {
                string dataPesquisa = data.Year + "-" + data.Month + "-" + data.Day;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update bdorangepoint.folha_ponto_usuario set OBSERVACAO = @OBSERVACAO where COD_USUARIO = @COD_USUARIO and DATA_PONTO = @DATA_PONTO;";
                cmd.Parameters.AddWithValue("@OBSERVACAO", observacao);
                cmd.Parameters.AddWithValue("@COD_USUARIO", usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@DATA_PONTO", dataPesquisa);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/IncluirObservacao. Contate o Suporte");
            }
        }

        public bool VerificaFolha(DateTime data, Usuario usuario)
        {
            FolhaPonto ponto = new FolhaPonto();
            bool retorno = false;
            string dataPesquisa = data.Year + "-" + data.Month + "-" + data.Day;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = '" + usuario.CodUsuario + "' and DATA_PONTO = '" + dataPesquisa + "';";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                registro.Read();
                retorno = registro.HasRows;
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro FolhaPontoDAO/VerificaFolha. Contate o Suporte"); }
            return retorno;
        }

        public DataTable PesquisaPontoPorIdUsuario(Usuario usuario)
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = "+ usuario .CodUsuario + "; ";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = " + usuario.CodUsuario + ";", conexao.StringConexao);
                    da.Fill(tabela);
                }
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/PesquisarIdUsuario. Contate o Suporte.");
            }
            return tabela;
        }

        public DataTable PesquisaPontoPorIdUsuarioeData(Usuario usuario,DateTime dataProcura)
        {
            DataTable tabela = new DataTable();
            string dataPesquisa = dataProcura.Year + "-" + dataProcura.Month + "-" + dataProcura.Day;
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = " + usuario.CodUsuario + " AND DATA_PONTO = '" + dataPesquisa + "';", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/PesquisaPontoPorIdUsuarioeData. Contate o Suporte.");
            }
            return tabela;
        }

        public FolhaPonto PesquisaFolhadePontoPorUsuarioData(DateTime dataPonto, Usuario usuario, int codigoID)
        {
            FolhaPonto ponto = new FolhaPonto();
            string dataPesquisa = dataPonto.Year + "-" + dataPonto.Month + "-" + dataPonto.Day;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                
                cmd.CommandText = codigoID == 0 ? "select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = '" + usuario.CodUsuario + "' and DATA_PONTO = '" + dataPesquisa + "';"
                    : "select * from bdorangepoint.folha_ponto_usuario where COD_PONTO = " + codigoID + ";";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                registro.Read();
                if (registro.HasRows)
                {
                    ponto.Usuario = usuario;
                    ponto.DataPonto = dataPonto;
                    ponto.CodPonto = Convert.ToInt32(registro["COD_PONTO"]);
                    ponto.DataPonto = Convert.ToDateTime(registro["DATA_PONTO"]);
                    ponto.Entrada1 = registro["ENTRADA_1"].ToString();
                    ponto.Saida1 = registro["SAIDA_1"].ToString();
                    ponto.Entrada2 = registro["ENTRADA_2"].ToString();
                    ponto.Saida2 = registro["SAIDA_2"].ToString();
                    ponto.Observacao = registro["OBSERVACAO"].ToString();
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro FolhaPontoDAO/PesquisaFolhadePontoPorUsuarioData. Contate o Suporte"); }
            return ponto;
        }

        public FolhaPonto PesquisaFolhadePontoPorId(int codigoID)
        {
            FolhaPonto ponto = new FolhaPonto();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;

                cmd.CommandText = "select * from bdorangepoint.folha_ponto_usuario where COD_PONTO = '" + codigoID + "';";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                registro.Read();
                if (registro.HasRows)
                {
                    ponto.Usuario = new LoginDAO().PesquisaUsuarioPorId(Convert.ToInt32(registro["COD_PONTO"]));
                    ponto.CodPonto = codigoID;
                    ponto.DataPonto = Convert.ToDateTime(registro["DATA_PONTO"]);
                    ponto.Entrada1 = registro["ENTRADA_1"].ToString();
                    ponto.Saida1 = registro["SAIDA_1"].ToString();
                    ponto.Entrada2 = registro["ENTRADA_2"].ToString();
                    ponto.Saida2 = registro["SAIDA_2"].ToString();
                    ponto.Observacao = registro["OBSERVACAO"].ToString();
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro FolhaPontoDAO/PesquisaFolhadePontoPorId. Contate o Suporte"); }
            return ponto;
        }

        public void AtualizaPonto(FolhaPonto folhaPonto)
        {
            try
            {
                string dataPesquisa = folhaPonto.DataPonto.Year + "-" + folhaPonto.DataPonto.Month + "-" + folhaPonto.DataPonto.Day;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update bdorangepoint.folha_ponto_usuario set ENTRADA_1 = @ENTRADA_1,SAIDA_1 = @SAIDA_1,ENTRADA_2=@ENTRADA_2,SAIDA_2 = @SAIDA_2" +
                    " where COD_USUARIO = @COD_USUARIO and DATA_PONTO = @DATA_PONTO;";
                cmd.Parameters.AddWithValue("@ENTRADA_1", folhaPonto.Entrada1);
                cmd.Parameters.AddWithValue("@SAIDA_1", folhaPonto.Saida1);
                cmd.Parameters.AddWithValue("@ENTRADA_2", folhaPonto.Entrada2);
                cmd.Parameters.AddWithValue("@SAIDA_2", folhaPonto.Saida2);
                cmd.Parameters.AddWithValue("@COD_USUARIO", folhaPonto.Usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@DATA_PONTO", dataPesquisa);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/AtualizaPonto. Contate o Suporte");
            }
        }

        public void ExcluiFolhaPorUsuario(int codUsuario)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.folha_ponto_usuario where COD_USUARIO = " + codUsuario;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/ExcluiFolhaPorUsuario. Contate o Suporte");
            }
        }

        public void ExcluiFolhaPorId(int codFolha)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.folha_ponto_usuario where COD_PONTO = " + codFolha;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/ExcluiFolhaPorId. Contate o Suporte");
            }
        }
    }
}
