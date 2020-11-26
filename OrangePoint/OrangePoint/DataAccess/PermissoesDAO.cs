using MySql.Data.MySqlClient;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.DataAccess
{
    public class PermissoesDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        private LoginDAO loginDAO = new LoginDAO();
        private TipoPermissaoDAO tipoPermissaoDAO = new TipoPermissaoDAO();

        public List<Permissoes> PesquisaTodasPermissoes()
        {
            List<Permissoes> listaPermissoes = new List<Permissoes>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.permissoes;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Permissoes permissao = new Permissoes();
                        permissao.CodPermissao = Convert.ToInt32(registro["COD_PERMISSAO"]);
                        permissao.Usuario = loginDAO.PesquisaTodosUsuario().Find(o => o.CodUsuario == Convert.ToInt32(registro["COD_USUARIO"]));
                        permissao.TipoPermissao = tipoPermissaoDAO.PesquisaTodosTipoPermissaoLista().Find(o => o.CodTipoPermissao == Convert.ToInt32(registro["COD_TIPO_PERMISSAO"]));
                        listaPermissoes.Add(permissao);
                    }
                    conexao.Desconectar();
                }
            }
            catch { MessageBox.Show("Erro PermissoesDAO/PesquisaTodasPermissoes. Contate o Suporte"); }
            return listaPermissoes;
        }

        public void DeletarPorTipoPermissao(int idTipoPermissao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete FROM bdorangepoint.permissoes where COD_TIPO_PERMISSAO=@id;";
                cmd.Parameters.AddWithValue("@id", idTipoPermissao);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro TipoPermissaoDAO/DeletarPorTipoPermissao. Contate o Suporte"); }
        }
    }
}
