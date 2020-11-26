using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.BusinessRule
{
    public class LoginRule
    {
        LoginDAO loginDAO = new LoginDAO();
        public Usuario PesquisaUsuario(string login, string senha)
        {
            return loginDAO.PesquisaUsuario(login, senha);
        }

        public void AtualizaFotoLogin(string fileName,string safeFileName, Usuario usuarioPagina)
        {
            string pathFotos = Path.Combine(Directory.GetCurrentDirectory(), "fotosUsuarios");
            if (!Directory.Exists(pathFotos))
                Directory.CreateDirectory(pathFotos);

            if (File.Exists(Path.Combine(pathFotos, safeFileName)))
            {
                MessageBox.Show("O arquivo já existe");
                return;
            }

            string fotoUsuarioDelecao = "";
            if (usuarioPagina.FotoUsuario != null && usuarioPagina.FotoUsuario != "")
                fotoUsuarioDelecao = usuarioPagina.FotoUsuario;

            File.Copy(fileName, Path.Combine(pathFotos, safeFileName));
            usuarioPagina.FotoUsuario = Path.Combine(pathFotos, safeFileName);

            AtualizaUsuario(usuarioPagina);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            loginDAO.AtualizaLogin(usuario);
        }

        public List<Usuario> PesquisaTodosUsuarios()
        {
            return loginDAO.PesquisaTodosUsuario();
        }
    }
}
