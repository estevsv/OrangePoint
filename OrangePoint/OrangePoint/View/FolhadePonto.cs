using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class FolhadePonto : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        FolhaPontoRule folhaPontoRule = new FolhaPontoRule();

        public FolhadePonto(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void FolhadePonto_Load(object sender, EventArgs e)
        {
            tmDataHora.Start();

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            dgPontoUsuario.DataSource = folhaPontoRule.PesquisaPontoPorIdUsuario(usuarioPagina);
        }

        #region Controle de Hora de Ponto

        private string Data
        {
            get { return DateTime.Now.ToLongDateString(); }
        }

        private string Hora
        {
            get { return DateTime.Now.ToLongTimeString(); }
        }
        private void tmDataHora_Tick(object sender, System.EventArgs e)
        {
            lblDataHora.Text = Data + " - " + Hora;
        } 
        #endregion

        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
            this.Close();
            new Dashboard(usuarioPagina).Show();
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
            this.Close();
            new LoginView().Show();
        }

        private void btnRegistrarPonto_Click(object sender, EventArgs e)
        {
            DateTime dataPonto = DateTime.Now;
            folhaPontoRule.RegistrarPonto(dataPonto, usuarioPagina);
            dgPontoUsuario.DataSource = folhaPontoRule.PesquisaPontoPorIdUsuario(usuarioPagina);
        }
    }
}
