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
    public partial class CadastroEmpresa : Form
    {
        private Usuario usuarioPagina;
        private Empresa empresaEdicao;

        Utilities utilities = new Utilities();
        bool fechamentoSistema;
        RegimeEmpresaRule regimeEmpresaRule = new RegimeEmpresaRule();
        GrupoRule grupoRule = new GrupoRule();
        EmpresaRule empresaRule = new EmpresaRule();



        public CadastroEmpresa(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void CadastroEmpresa_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            CarregaGridseComboBoxes();
        }

        #region Controle de Página
        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroAuxiliar(usuarioPagina).Show();
        }

        private void button7_Click(object sender, EventArgs e)
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
            new EmpresaView(usuarioPagina).Show();
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

        private void CadastroEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        } 
        #endregion

        private void CarregaGridseComboBoxes()
        {
            CarregaGridEmpresa(empresaRule.ElaboraTabelaEmpresa(empresaRule.listaEmpresas()));
            CarregaCbRegime();
            CarregaCbGrupo();
        }

        private void CarregaCbRegime()
        {
            cbRegime.DataSource = regimeEmpresaRule.PesquisaRegimeEmpresasTabela();
            cbRegime.DisplayMember = "DESCRICAO";
            cbRegime.ValueMember = "COD_REGIME";
        }

        private void CarregaCbGrupo()
        {
            cbGrupo.DataSource = grupoRule.PesquisaGrupoEmpresasTabela();
            cbGrupo.DisplayMember = "DESCRICAO";
            cbGrupo.ValueMember = "COD_GRUPO";
        }

        private void CarregaGridEmpresa(DataTable tabela)
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

        private void btnCadastrarEmpresa_Click(object sender, EventArgs e)
        {
            if (txtRazaoSocial.Text != "" && cbRegime.Text != "" && cbRegime.Text != "")
            {
                if (txtNumSocios.Text == "")
                    txtNumSocios.Text = "0";
                if (txtNumVinculos.Text == "")
                    txtNumVinculos.Text = "0";

                if (btnCadastrarEmpresa.Text == "Editar Empresa")
                {
                    empresaRule.AtualizarEmpresa(empresaEdicao.CodEmpresa, int.Parse(cbRegime.SelectedValue.ToString()), int.Parse(cbGrupo.SelectedValue.ToString()), txtRazaoSocial.Text, txtCNPJ.Text, int.Parse(txtNumSocios.Text),
                        int.Parse(txtNumVinculos.Text), txtObservacoes.Text, txtSenhaSIAT.Text, txtEsocial.Text);
                    
                }
                else
                {
                    empresaRule.IncluirEmpresa(int.Parse(cbRegime.SelectedValue.ToString()), int.Parse(cbGrupo.SelectedValue.ToString()), txtRazaoSocial.Text, txtCNPJ.Text, int.Parse(txtNumSocios.Text),
                        int.Parse(txtNumVinculos.Text), txtObservacoes.Text, txtSenhaSIAT.Text, txtEsocial.Text);
                }

                LimparCampos();
                CarregaGridEmpresa(empresaRule.ElaboraTabelaEmpresa(empresaRule.listaEmpresas()));
            }
        }

        private void dgEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            empresaEdicao = empresaRule.PesquisaEmpresaPorId(int.Parse(dgEmpresa.CurrentRow.Cells[0].Value.ToString()));

            txtRazaoSocial.Text = empresaEdicao.RazaoSocial;
            txtNumSocios.Text = empresaEdicao.NumSocios.ToString();
            txtNumVinculos.Text = empresaEdicao.NumVinculos.ToString();
            txtCNPJ.Text = empresaEdicao.CNPJ;
            txtSenhaSIAT.Text = empresaEdicao.SenhaSIAT;
            txtEsocial.Text = empresaEdicao.ESocial;
            txtObservacoes.Text = empresaEdicao.Observacao;
            cbGrupo.SelectedValue = empresaEdicao.Grupo.CodGrupo;
            cbRegime.SelectedValue = empresaEdicao.Regime.CodRegime;

            btnCadastrarEmpresa.Text = "Editar Empresa";
            btnCancelaEdicao.Visible = true;
        }

        private void LimparCampos()
        {
            txtRazaoSocial.Text = "";
            txtNumSocios.Text = "";
            txtNumVinculos.Text = "";
            txtCNPJ.Text = "";
            txtSenhaSIAT.Text = "";
            txtEsocial.Text = "";
            txtObservacoes.Text = "";

            btnCadastrarEmpresa.Text = "Cadastrar Empresa";
            btnCancelaEdicao.Visible = false;
        }

        private void btnCancelaEdicao_Click(object sender, EventArgs e)
        {
            empresaEdicao = new Empresa();
            LimparCampos();
            btnCadastrarEmpresa.Text = "Cadastrar Empresa";
            btnCancelaEdicao.Visible = false;
            CarregaGridEmpresa(empresaRule.ElaboraTabelaEmpresa(empresaRule.listaEmpresas()));
        }

        private void txtRazaoSocial_TextChanged(object sender, EventArgs e)
        {
            CarregaGridEmpresa(empresaRule.ElaboraTabelaEmpresa(txtRazaoSocial.Text != "" ? empresaRule.listaEmpresas().Where(o => o.RazaoSocial == txtRazaoSocial.Text).ToList() : empresaRule.listaEmpresas()));
        }

        private void txtCNPJ_TextChanged(object sender, EventArgs e)
        {
            CarregaGridEmpresa(empresaRule.ElaboraTabelaEmpresa(txtCNPJ.Text != "" ? empresaRule.listaEmpresas().Where(o => o.CNPJ == txtCNPJ.Text).ToList() : empresaRule.listaEmpresas()));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }
    }
}