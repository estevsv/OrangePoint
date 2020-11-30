using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class ControleFolhaPonto : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        LoginRule loginRule = new LoginRule();
        FolhaPontoRule folhaPontoRule = new FolhaPontoRule();

        public ControleFolhaPonto(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }
        
        private void ControleFolhaPonto_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            CarregaComboBoxUsuario();
        }

        private void CarregaComboBoxUsuario()
        {
            cbUsuario.DataSource = loginRule.PesquisaTodosUsuariosTabela();
            cbUsuario.DisplayMember = "LOGIN";
            cbUsuario.ValueMember = "COD_USUARIO";
            if (cbUsuario.Items.Count != 0)
                cbUsuario.SelectedIndex = 0;
        }

        private void CarregaGridFolhaPonto(Usuario usuario, bool filtro)
        {
            if (filtro)
                dgFolhaPonto.DataSource = folhaPontoRule.PesquisaPontoPorIdUsuarioeData(usuario, dateTimePicker1.Value.Date);
            else
                dgFolhaPonto.DataSource = folhaPontoRule.PesquisaPontoPorIdUsuario(usuario);
            dgFolhaPonto.Columns["COD_PONTO"].Visible = false;
            dgFolhaPonto.Columns["COD_USUARIO"].Visible = false;
            dgFolhaPonto.Columns["DATA_PONTO"].HeaderText = "Data";
            dgFolhaPonto.Columns["ENTRADA_1"].HeaderText = "Primeira Entrada";
            dgFolhaPonto.Columns["SAIDA_1"].HeaderText = "Primeira Saída";
            dgFolhaPonto.Columns["ENTRADA_2"].HeaderText = "Segunda Entrada";
            dgFolhaPonto.Columns["SAIDA_2"].HeaderText = "Segunda Saída";

            dgFolhaPonto.Columns["DATA_PONTO"].Width = 172;
            dgFolhaPonto.Columns["ENTRADA_1"].Width = 160;
            dgFolhaPonto.Columns["SAIDA_1"].Width = 160;
            dgFolhaPonto.Columns["ENTRADA_2"].Width = 160;
            dgFolhaPonto.Columns["SAIDA_2"].Width = 160;

            dgFolhaPonto.Columns["DATA_PONTO"].ReadOnly = true;
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            button6.Visible = listaPermissoes[3];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void FechaPagina()
        {
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ConfiguracoesPermissoes(usuarioPagina).Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregaGridFolhaPonto(loginRule.PesquisaUsuarioPorId(int.Parse(cbUsuario.SelectedValue.ToString())), false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CarregaGridFolhaPonto(loginRule.PesquisaUsuarioPorId(int.Parse(cbUsuario.SelectedValue.ToString())), true);
        }
    }
}
