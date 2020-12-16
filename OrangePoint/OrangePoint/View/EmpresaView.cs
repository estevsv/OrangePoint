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
    public partial class EmpresaView : Form
    {
        private Usuario usuarioPagina;
        private List<Empresa> listaEmpresas;
        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();
        RegimeEmpresaRule regimeEmpresaRule = new RegimeEmpresaRule();
        GrupoRule grupoRule = new GrupoRule();

        public EmpresaView(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void EmpresaView_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));
            listaEmpresas = empresaRule.listaEmpresas();
            CarregaGrid(empresaRule.ElaboraTabelaEmpresa(listaEmpresas));
            CarregaComboBoxes();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void FechaPagina()
        {
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Dashboard(usuarioPagina).Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroEmpresa(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroAuxiliar(usuarioPagina).Show();
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void CarregaGrid(DataTable tabela)
        {
            dgEmpresa.DataSource = tabela;

            dgEmpresa.Columns["id"].Visible = false;
            
            dgEmpresa.Columns["Razão Social"].Width = 250;
            dgEmpresa.Columns["CNPJ"].Width = 165;
            dgEmpresa.Columns["Grupo"].Width = 200;
            dgEmpresa.Columns["Regime"].Width = 200;

            dgEmpresa.Columns["Razão Social"].ReadOnly = true; 
            dgEmpresa.Columns["CNPJ"].ReadOnly = true;
            dgEmpresa.Columns["Grupo"].ReadOnly = true;
            dgEmpresa.Columns["Regime"].ReadOnly = true;
        }

        private void CarregaComboBoxes()
        {
            cbGrupo.DataSource = grupoRule.PesquisaGrupoEmpresasTabela();
            cbGrupo.DisplayMember = "DESCRICAO";
            cbGrupo.ValueMember = "COD_GRUPO";

            cbRegime.DataSource = regimeEmpresaRule.PesquisaRegimeEmpresasTabela();
            cbRegime.DisplayMember = "DESCRICAO";
            cbRegime.ValueMember = "COD_REGIME";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid(empresaRule.ElaboraTabelaEmpresa(empresaRule.listaEmpresas()));
            CarregaComboBoxes();
            LimparCampos();
        }


        private void LimparCampos()
        {
            txtFiltroRazaoSocial.Text = "";
            cbGrupo.SelectedIndex = -1;
            cbRegime.SelectedIndex = -1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Empresa> listaFiltrada = listaEmpresas;
            if (txtFiltroRazaoSocial.Text != "")
                listaFiltrada = listaFiltrada.Where(o => o.RazaoSocial == txtFiltroRazaoSocial.Text).ToList();
            if (int.Parse(cbRegime.SelectedValue.ToString()) != -1)
                listaFiltrada.Where(o => o.Regime.CodRegime == int.Parse(cbRegime.SelectedValue.ToString()));
            if (int.Parse(cbGrupo.SelectedValue.ToString()) != -1)
                listaFiltrada.Where(o => o.Grupo.CodGrupo == int.Parse(cbGrupo.SelectedValue.ToString()));

            CarregaGrid(empresaRule.ElaboraTabelaEmpresa(listaFiltrada));
        }
    }
}
