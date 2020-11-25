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
            CarregaGridFolhaPonto();
        }

        private void CarregaGridFolhaPonto()
        {
            dgPontoUsuario.DataSource = folhaPontoRule.PesquisaPontoPorIdUsuario(usuarioPagina);
            dgPontoUsuario.Columns["COD_PONTO"].Visible = false;
            dgPontoUsuario.Columns["COD_USUARIO"].Visible = false;
            dgPontoUsuario.Columns["DATA_PONTO"].HeaderText = "Data";
            dgPontoUsuario.Columns["ENTRADA_1"].HeaderText = "Primeira Entrada";
            dgPontoUsuario.Columns["SAIDA_1"].HeaderText = "Primeira Saída";
            dgPontoUsuario.Columns["ENTRADA_2"].HeaderText = "Segunda Entrada";
            dgPontoUsuario.Columns["SAIDA_2"].HeaderText = "Segunda Saída";

            dgPontoUsuario.Columns["DATA_PONTO"].Width = 172;
            dgPontoUsuario.Columns["ENTRADA_1"].Width = 160;
            dgPontoUsuario.Columns["SAIDA_1"].Width = 160;
            dgPontoUsuario.Columns["ENTRADA_2"].Width = 160;
            dgPontoUsuario.Columns["SAIDA_2"].Width = 160;

            dgPontoUsuario.Columns["DATA_PONTO"].ReadOnly = true;
            dgPontoUsuario.Columns["ENTRADA_1"].ReadOnly = true;
            dgPontoUsuario.Columns["SAIDA_1"].ReadOnly = true;
            dgPontoUsuario.Columns["ENTRADA_2"].ReadOnly = true;
            dgPontoUsuario.Columns["SAIDA_2"].ReadOnly = true;
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
            FechaPagina();
            new Dashboard(usuarioPagina).Show();
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void btnRegistrarPonto_Click(object sender, EventArgs e)
        {
            DateTime dataPonto = DateTime.Now;
            folhaPontoRule.RegistrarPonto(dataPonto, usuarioPagina);
            CarregaGridFolhaPonto();
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
