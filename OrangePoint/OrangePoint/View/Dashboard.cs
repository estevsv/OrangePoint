using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class Dashboard : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();

        public Dashboard(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Bem Vindo " + usuarioPagina.NmeFuncionario;
            Image fotoUsuario = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            new LoginView().Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            new FolhadePonto(usuarioPagina).Show();
        }

    }
}
