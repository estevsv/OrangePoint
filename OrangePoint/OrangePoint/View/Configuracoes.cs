using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class Configuracoes : Form
    {

        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        LoginRule login = new LoginRule();

        public Configuracoes(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void Configuracoes_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;

            Tbusuario.Text = usuarioPagina.Login;
            tbSenha.Text = usuarioPagina.Senha;
            tbNomeUsuario.Text = usuarioPagina.NmeFuncionario;

            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
            pictureBox1.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Selecionar Foto";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                if (DialogResult.Yes == MessageBox.Show("Será necessário reabrir a aplicação, deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    string pathFotos = Path.Combine(Directory.GetCurrentDirectory(), "fotosUsuarios");
                    if (!Directory.Exists(pathFotos))
                        Directory.CreateDirectory(pathFotos);

                    if (File.Exists(Path.Combine(pathFotos, openFileDialog1.SafeFileName)))
                    {
                        MessageBox.Show("O arquivo já existe");
                        return;
                    }

                    string fotoUsuarioDelecao = "";
                    if (usuarioPagina.FotoUsuario != null && usuarioPagina.FotoUsuario != "")
                        fotoUsuarioDelecao = usuarioPagina.FotoUsuario;

                    File.Copy(openFileDialog1.FileName, Path.Combine(pathFotos, openFileDialog1.SafeFileName));
                    usuarioPagina.FotoUsuario = Path.Combine(pathFotos, openFileDialog1.SafeFileName);

                    login.AtualizaUsuario(usuarioPagina);

                    Application.Exit();
                }
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            usuarioPagina.Login = Tbusuario.Text;
            usuarioPagina.Senha = tbSenha.Text;
            usuarioPagina.NmeFuncionario = tbNomeUsuario.Text;
            usuarioPagina.FotoUsuario = usuarioPagina.FotoUsuario;

            login.AtualizaUsuario(usuarioPagina);

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new LoginView().Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new Configuracoes(usuarioPagina).Show();
        }

        private void FechaPagina()
        {
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }
    }
}
