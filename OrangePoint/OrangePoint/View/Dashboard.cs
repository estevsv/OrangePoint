using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class Dashboard : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        LoginRule loginRule = new LoginRule();
        bool fechamentoSistema;

        public Dashboard(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Bem Vindo " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));
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
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new EmpresaView(usuarioPagina).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }
    }
}
