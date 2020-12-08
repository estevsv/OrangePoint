using OrangePoint.BusinessRule;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class LoginView : Form
    {
        LoginRule loginRule = new LoginRule();

        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            if (!loginRule.VerificaBanco())
                Application.Exit();

            //LimpaFotosInutilizadas();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = loginRule.PesquisaUsuario(Tbusuario.Text, Tbsenha.Text);
            if (usuario != null)
            {
                this.Visible = false;
                new Dashboard(usuario).Show();
            }
            else
                MessageBox.Show("Usuario e/ou Senha Incorreta");
        }

        private void LimpaFotosInutilizadas()
        {
            List<Usuario> listaUsuarios = loginRule.PesquisaTodosUsuarios();

            DirectoryInfo diretorio = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "fotosUsuarios"));
            //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
            FileInfo[] Arquivos = diretorio.GetFiles("*.*");

            //Começamos a listar os arquivos
            foreach (FileInfo fileinfo in Arquivos)
            {
                if (!listaUsuarios.Exists(o => o.FotoUsuario == fileinfo.FullName))
                    File.Delete(fileinfo.FullName);
            }
        }

    }
}
