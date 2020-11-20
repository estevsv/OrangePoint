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
    public class LoginDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public Usuario PesquisaUsuario(string login, string senha)
        {
            Usuario usuarioExistente = new Usuario();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from `bdorangepoint`.`usuario` where LOGIN = '" + login + "' and SENHA = '" + senha + "';";
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                registro.Read();
                if (registro.HasRows)
                {
                    usuarioExistente.CodUsuario = Convert.ToInt32(registro["COD_USUARIO"]);
                    usuarioExistente.Login = registro["LOGIN"].ToString();
                    usuarioExistente.Senha = registro["SENHA"].ToString();
                    usuarioExistente.NmeFuncionario = registro["NME_FUNCIONARIO"].ToString() != "" ? registro["NME_FUNCIONARIO"].ToString() : "";
                    usuarioExistente.HrsDiaria = registro["HRS_DIARIA"].ToString() != "" ? Convert.ToDecimal(registro["HRS_DIARIA"]) : 0;
                    usuarioExistente.FotoUsuario = registro["FOTO_USUARIO"].ToString() != "" ? registro["FOTO_USUARIO"].ToString() : ""; 
                }
                else
                    usuarioExistente = null;
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro LoginDAO/PesquisaUsuario. Contate o Suporte"); }
            return usuarioExistente;
        }
    }
}
