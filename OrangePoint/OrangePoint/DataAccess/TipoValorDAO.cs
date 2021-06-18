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
    public class TipoValorDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaTipoValorTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.tipo_valor;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro TipoValorDAO/PesquisaTipoValorTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<TipoValor> PesquisaTipoValorLista()
        {
            List<TipoValor> listTipoValorEmpresa = new List<TipoValor>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.tipo_valor;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    TipoValor TipoValor = new TipoValor();
                    TipoValor.CodTipoValor = int.Parse(registro["COD_TIPO_VALOR"].ToString());
                    TipoValor.DescTipo = registro["DESC_TIPO"].ToString();

                    listTipoValorEmpresa.Add(TipoValor);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro TipoValorDAO/PesquisaTipoValorLista. Contate o Suporte"); }
            return listTipoValorEmpresa;
        }

        public void ExcluiTipoValor(int codTipoValor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.tipo_valor where COD_TIPO_VALOR = " + codTipoValor;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoValorDAO/ExcluiTipoValor. Contate o Suporte");
            }
        }

        public void IncluirTipoValor(string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`tipo_valor` (`DESC_TIPO`) VALUES ('" + descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoValorDAO/IncluirTipoValor. Contate o Suporte");
            }
        }

        public void AtualizaTipoValor(string descricao, int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE `bdorangepoint`.`tipo_valor` SET `DESC_TIPO` = '"+ descricao + "' WHERE(`COD_TIPO_VALOR` = '"+ id + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoValorDAO/AtualizaTipoValor. Contate o Suporte");
            }
        }
    }
}
