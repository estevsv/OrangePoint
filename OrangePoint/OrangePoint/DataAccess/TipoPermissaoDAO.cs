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
    public class TipoPermissaoDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public List<TipoPermissao> PesquisaTodosTipoPermissaoLista()
        {
            List<TipoPermissao> listaTipoPermissao = new List<TipoPermissao>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from bdorangepoint.tipo_permissao;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        TipoPermissao tipoPermissao = new TipoPermissao();
                        tipoPermissao.CodTipoPermissao = Convert.ToInt32(registro["COD_TIPO_PERMISSAO"]);
                        tipoPermissao.DescPermissao = registro["DESC_PERMISSAO"].ToString();
                        listaTipoPermissao.Add(tipoPermissao);
                    }
                    conexao.Desconectar();
                }
            }
            catch { MessageBox.Show("Erro TipoPermissaoDAO/PesquisaTodosTipoPermissaoLista. Contate o Suporte"); }
            return listaTipoPermissao;
        }

        public DataTable PesquisaTodosTipoPermissaoTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from bdorangepoint.tipo_permissao;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro TipoPermissaoDAO/PesquisaTodosTipoPermissaoTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public void Incluir(string descTipoPermissao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO bdorangepoint.tipo_permissao(DESC_PERMISSAO) VALUES(@DESC_PERMISSAO);";
                cmd.Parameters.AddWithValue("@DESC_PERMISSAO", descTipoPermissao);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro TipoPermissaoDAO/Incluir. Contate o Suporte"); }
        }
    }
}
