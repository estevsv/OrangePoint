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
    public class PermissoesDAO
    {
        private TipoPermissaoDAO tipoPermissaoDAO = new TipoPermissaoDAO();
        private LoginDAO loginDAO = new LoginDAO();

        private ConexaoBD conexao = new ConexaoBD();

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

        public void Incluir(Permissoes permissao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO bdorangepoint.permissoes(COD_USUARIO,COD_TIPO_PERMISSAO) VALUES(@COD_USUARIO,@COD_TIPO_PERMISSAO);";
                cmd.Parameters.AddWithValue("@COD_USUARIO", permissao.Usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@COD_TIPO_PERMISSAO", permissao.TipoPermissao.CodTipoPermissao);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissoesDAO/Incluir. Contate o Suporte"); }
        }

        public void Update(Permissoes permissao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE bdorangepoint.permissoes set  COD_TIPO_PERMISSAO = @COD_TIPO_PERMISSAO where COD_USUARIO = @COD_USUARIO;";
                cmd.Parameters.AddWithValue("@COD_TIPO_PERMISSAO", permissao.TipoPermissao.CodTipoPermissao);
                cmd.Parameters.AddWithValue("@COD_USUARIO", permissao.Usuario.CodUsuario);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissoesDAO/Update. Contate o Suporte"); }
        }

        public DataTable PesquisaTodasPermissaoTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.permissoes;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro PermissoesDAO/PesquisaTodasPermissaoTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public void Excluir(int codPermissao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete FROM bdorangepoint.permissoes where COD_PERMISSAO = @COD_PERMISSAO;";
                cmd.Parameters.AddWithValue("@COD_PERMISSAO", codPermissao);
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissoesDAO/Excluir. Contate o Suporte"); }
        }
    }
}
