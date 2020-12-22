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
    public partial class EspecificacoesEmpresa : Form
    {
        private Usuario usuarioPagina;
        private Empresa empresaOperacao;
        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();
        TipoClassificacaoRule tipoClassificacaoRule = new TipoClassificacaoRule();
        TipoDataRule tipoDataRule = new TipoDataRule();
        DataEmpresaRule dataEmpresaRule = new DataEmpresaRule();
        ClassificacaoEmpresaRule classificacaoEmpresaRule = new ClassificacaoEmpresaRule();
        bool fechamentoSistema;

        public EspecificacoesEmpresa(Usuario usuario, Empresa empresa)
        {
            InitializeComponent();
            usuarioPagina = usuario;
            empresaOperacao = empresa;
        }

        private void EspecificacoesEmpresa_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            lblTxtEmpresaInfo.Text = "Empresa: " + empresaOperacao.RazaoSocial +"  CNPJ:" + empresaOperacao.CNPJ;

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));
            CarregaComboBoxes();
        }

        #region Controle de Acesso da Página
        private void FechaPagina()
        {
            fechamentoSistema = false;
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
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
            new CadastroEmpresa(usuarioPagina).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroAuxiliar(usuarioPagina).Show();
        }
        #endregion

        #region Carregamento de ComboBox
        private void CarregaComboBoxes()
        {
            CarregaComboBoxClassificacao();
            CarregaComboBoxTipoData();
            CarregaComboBoxDataEmpresa();
        }

        private void CarregaComboBoxClassificacao()
        {
            cbClassificacao.DataSource = tipoClassificacaoRule.PesquisaTipoClassificacaoTabela();
            cbClassificacao.DisplayMember = "DESCRICAO";
            cbClassificacao.ValueMember = "COD_TIPO_CLASSIFICACAO";
        }

        private void CarregaComboBoxTipoData()
        {
            cbTipoData.DataSource = tipoDataRule.PesquisaTipoDataTabela();
            cbTipoData.DisplayMember = "DESC_TIPO";
            cbTipoData.ValueMember = "COD_TIPO_DATA";

            cbTipoData1.DataSource = cbTipoData;
            cbTipoData1.DisplayMember = "DESC_TIPO";
            cbTipoData1.ValueMember = "COD_TIPO_DATA";
        }

        private void CarregaComboBoxDataEmpresa()
        {
            cbData.DataSource = dataEmpresaRule.ElaboraTabelaDataEmpresa(dataEmpresaRule.listaDataEmpresa().Where(o => o.TipoData.CodTipoData == int.Parse(cbTipoData.SelectedValue.ToString())).ToList());
            cbData.DisplayMember = "Data";
            cbData.ValueMember = "id";
        } 
        #endregion

        private void CarregaGrids()
        {

        }

        private void CarregaGridControleFC()
        {
            dgControleFC.DataSource = classificacaoEmpresaRule.PesquisaClassificacaoEmpresaTabela();
            //dgEmpresa.Columns["id"].Visible = false;

            //dgEmpresa.Columns["Razão Social"].Width = 250;
            //dgEmpresa.Columns["CNPJ"].Width = 165;
            //dgEmpresa.Columns["Grupo"].Width = 200;
            //dgEmpresa.Columns["Regime"].Width = 200;

            //dgEmpresa.Columns["Razão Social"].ReadOnly = true;
            //dgEmpresa.Columns["CNPJ"].ReadOnly = true;
            //dgEmpresa.Columns["Grupo"].ReadOnly = true;
            //dgEmpresa.Columns["Regime"].ReadOnly = true;
        }
    }
}