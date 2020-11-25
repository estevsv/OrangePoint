using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class Dashboard : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        LoginRule loginRule = new LoginRule();

        public Dashboard(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Bem Vindo " + usuarioPagina.NmeFuncionario;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
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
