using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
        PermissoesRule permissoesRule = new PermissoesRule();
        TipoPermissaoRule tipoPermissaoRule = new TipoPermissaoRule();

        public Usuario PesquisaUsuario(string login, string senha)
        {
            List<TipoPermissao> listaTipoPermissao = tipoPermissaoRule.PesquisaTodosTipoPermissaoLista();
            List<Permissoes> listaPermissoes = permissoesRule.PesquisaTodasPermissoes();

            Usuario usuario = loginDAO.PesquisaUsuario(login, senha);

            usuario = DefineTipoPermissaoUsuario(listaPermissoes, usuario, listaTipoPermissao);

            return usuario;
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
            List<Usuario> listaUsuarios = new List<Usuario>();
            List<TipoPermissao> listaTipoPermissao = tipoPermissaoRule.PesquisaTodosTipoPermissaoLista();
            List<Permissoes> listaPermissoes = permissoesRule.PesquisaTodasPermissoes();

            foreach (Usuario usuario in loginDAO.PesquisaTodosUsuario())
            {
                Usuario usuarioTipoPermissao = new Usuario();
                usuarioTipoPermissao = usuario;
                usuarioTipoPermissao = DefineTipoPermissaoUsuario(listaPermissoes, usuario, listaTipoPermissao);
                listaUsuarios.Add(usuarioTipoPermissao);
            }

            return listaUsuarios;
        }

        public DataTable PesquisaTodosUsuariosTabela()
        {
            return loginDAO.PesquisaTodosUsuariosTabela();
        }

        private Usuario DefineTipoPermissaoUsuario(List<Permissoes> listaPermissoes, Usuario usuario, List<TipoPermissao> listaTipoPermissao)
        {
            if (listaPermissoes.Exists(o => o.Usuario.CodUsuario == usuario.CodUsuario))
                usuario.TipoPermissao = listaPermissoes.Find(o => o.Usuario.CodUsuario == usuario.CodUsuario).TipoPermissao;
            else
                usuario.TipoPermissao = new TipoPermissao { DescPermissao = "Padrão" };

            return usuario;
        }
    }
}
