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
    public class PermissaoTelaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        TipoPermissaoDAO tipoPermissaoDAO = new TipoPermissaoDAO();

        public List<PermissaoTela> PesquisaPermissoesTela()
        {
            List<PermissaoTela> listPermissaoTela = new List<PermissaoTela>();

            List<TipoPermissao> listaTipoPermissao = tipoPermissaoDAO.PesquisaTodosTipoPermissaoLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from bdorangepoint.permissoes_tela;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    PermissaoTela permissaoTela = new PermissaoTela();
                    permissaoTela.CodPermissaoTela = Convert.ToInt32(registro["COD_PERMISSAO_TELA"]);
                    int codTipoPermissao = Convert.ToInt32(registro["COD_TIPO_PERMISSAO"]);
                    permissaoTela.DescTela = registro["DESCRICAO_TELA"].ToString();
                    permissaoTela.TipoPermissao = listaTipoPermissao.Find(o => o.CodTipoPermissao == codTipoPermissao);
                    listPermissaoTela.Add(permissaoTela);
                }
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissaoTelaDAO/PesquisaPermissoesTela. Contate o Suporte"); }
            return listPermissaoTela;
        }

        public void Incluir(int idTipoUsuario, string tela)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO bdorangepoint.permissoes_tela(COD_TIPO_PERMISSAO,DESCRICAO_TELA) VALUES(@COD_TIPO_PERMISSAO,@DESCRICAO_TELA);";
                cmd.Parameters.AddWithValue("@COD_TIPO_PERMISSAO", idTipoUsuario);
                cmd.Parameters.AddWithValue("@DESCRICAO_TELA", tela);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissaoTelaDAO/Incluir. Contate o Suporte"); }
        }

        public void DeletarPorId(int idPermissaoTela)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete FROM bdorangepoint.permissoes_tela where COD_PERMISSAO_TELA=@id;";
                cmd.Parameters.AddWithValue("@id", idPermissaoTela);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissaoTelaDAO/DeletarPorId. Contate o Suporte"); }
        }

        public void DeletarPorIdTipoPermissao(int idTipoPermissao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete FROM bdorangepoint.permissoes_tela where COD_TIPO_PERMISSAO=@id;";
                cmd.Parameters.AddWithValue("@id", idTipoPermissao);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissaoTelaDAO/DeletarPorIdTipoPermissao. Contate o Suporte"); }
        }
    }
}
