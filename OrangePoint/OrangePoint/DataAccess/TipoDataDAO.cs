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
    public class TipoDataDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaTipoDataTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.tipo_data;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro TipoDataDAO/PesquisaTipoDataTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<TipoData> PesquisaTipoDataLista()
        {
            List<TipoData> listTipoDataEmpresa = new List<TipoData>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.tipo_data;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    TipoData tipoData = new TipoData();
                    tipoData.CodTipoData = int.Parse(registro["COD_TIPO_DATA"].ToString());
                    tipoData.DescTipoData = registro["DESC_TIPO"].ToString();

                    listTipoDataEmpresa.Add(tipoData);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro TipoDataDAO/PesquisaTipoDataLista. Contate o Suporte"); }
            return listTipoDataEmpresa;
        }

        public void ExcluiTipoData(int codTipoData)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.tipo_data where COD_TIPO_DATA = " + codTipoData;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoDataDAO/ExcluiTipoData. Contate o Suporte");
            }
        }

        public void IncluirTipoData(string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`tipo_data` (`DESC_TIPO`) VALUES ('" + descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro TipoDataDAO/IncluirTipoData. Contate o Suporte");
            }
        }
    }
}
