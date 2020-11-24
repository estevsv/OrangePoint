using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.BusinessRule
{
    public class LoginRule
    {
        LoginDAO loginDAO = new LoginDAO();
        public Usuario PesquisaUsuario(string login, string senha)
        {
            return loginDAO.PesquisaUsuario(login, senha);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            loginDAO.AtualizaLogin(usuario);
        }
    }
}
