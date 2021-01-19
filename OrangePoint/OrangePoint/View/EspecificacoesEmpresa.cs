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
        private bool fechamentoSistema;
        private bool aberturaPagina;

        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();
        TipoClassificacaoRule tipoClassificacaoRule = new TipoClassificacaoRule();
        TipoDataRule tipoDataRule = new TipoDataRule();
        DataEmpresaRule dataEmpresaRule = new DataEmpresaRule();
        ClassificacaoEmpresaRule classificacaoEmpresaRule = new ClassificacaoEmpresaRule();
        DadosWebRule dadoWebRule = new DadosWebRule();

        public EspecificacoesEmpresa(Usuario usuario, Empresa empresa)
        {
            InitializeComponent();

            aberturaPagina = true;
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
            CarregaGrids();

            aberturaPagina = false;
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

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
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

            cbTipoData1.DataSource = cbTipoData.DataSource;
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
            CarregaGridControleFC();
            CarregaGridDataEmpresa();
            CarregaGridDadosWeb();
        }

        private void CarregaGridControleFC()
        {
            dgControleFC.DataSource = classificacaoEmpresaRule.ElaboraTabelaClassificacaoEmpresa(classificacaoEmpresaRule.listaClassificacaoEmpresa()
                .Where(o => o.DataEmpresa.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList());
            dgControleFC.Columns["id"].Visible = false;

            dgControleFC.Columns["Tipo Classificacao"].Width = 160;
            dgControleFC.Columns["Data"].Width = 140;

            dgControleFC.Columns["Tipo Classificacao"].ReadOnly = true;
            dgControleFC.Columns["Data"].ReadOnly = true;
        }

        private void CarregaGridDataEmpresa()
        {
            dgDatas.DataSource = dataEmpresaRule.ElaboraTabelaDataEmpresa(dataEmpresaRule.listaDataEmpresa().Where(o => o.Empresa.CodEmpresa == empresaOperacao.CodEmpresa && o.TipoData.CodTipoData == int.Parse(cbTipoData1.SelectedValue.ToString())).ToList());

            dgDatas.Columns["id"].Visible = false;
            dgDatas.Columns["Data"].Width = 300;
            dgDatas.Columns["Data"].ReadOnly = true;
        }

        private void cbTipoData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!aberturaPagina)
                CarregaComboBoxDataEmpresa();
        }

        private void cbTipoData1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!aberturaPagina)
                CarregaGridDataEmpresa(); 
        }

        private void btnControleFC_Click(object sender, EventArgs e)
        {
            if (cbClassificacao.SelectedValue != null && cbData.SelectedValue != null && cbData.Text != "")
            {
                classificacaoEmpresaRule.IncluirClassificacaoEmpresa(int.Parse(cbClassificacao.SelectedValue.ToString()), int.Parse(cbData.SelectedValue.ToString()));
                CarregaGridControleFC();
            }
            else
                MessageBox.Show("Campos inválidos");
        }

        private void btnAdicionarData_Click(object sender, EventArgs e)
        {
            if (cbTipoData1.SelectedValue != null)
            {
                dataEmpresaRule.IncluirDataEmpresa(int.Parse(cbTipoData1.SelectedValue.ToString()), empresaOperacao.CodEmpresa, txtData.Text);
                CarregaGridDataEmpresa();
                CarregaComboBoxDataEmpresa();
            }
            else
                MessageBox.Show("Tipo de Data Inválido");
        }

        private void dgControleFC_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            classificacaoEmpresaRule.ExcluiClassificacaoEmpresa(int.Parse(dgControleFC.CurrentRow.Cells[0].Value.ToString()));
            dgControleFC.Rows.RemoveAt(dgControleFC.CurrentRow.Index);
            CarregaGridControleFC();
            e.Cancel = true;
        }

        private void dgDatas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            dataEmpresaRule.ExcluiDataEmpresa(int.Parse(dgDatas.CurrentRow.Cells[0].Value.ToString()));
            dgDatas.Rows.RemoveAt(dgDatas.CurrentRow.Index);
            CarregaComboBoxDataEmpresa();
            CarregaGridDataEmpresa();
            e.Cancel = true;
        }

        private void CarregaGridDadosWeb()
        {
            dgControleWeb.DataSource = dadoWebRule.FiltraPesquisaDadoWebTabela(empresaOperacao.CodEmpresa);

            dgControleWeb.Columns["id"].Visible = false;

            dgControleWeb.Columns["Usuário"].Width = 100;
            dgControleWeb.Columns["Senha"].Width = 100;
            dgControleWeb.Columns["Descrição"].Width = 100;

            dgControleWeb.Columns["Usuário"].ReadOnly = true;
            dgControleWeb.Columns["Senha"].ReadOnly = true;
            dgControleWeb.Columns["Descrição"].ReadOnly = true;
        }

        private void btnCadastrarDadosWeb_Click(object sender, EventArgs e)
        {
            if (txtUsuarioWEB.Text != "" && txtSenhaWEB.Text != "" && txtDescricaoWEB.Text != "")
            {
                dadoWebRule.IncluirTipoValor(empresaOperacao.CodEmpresa, txtUsuarioWEB.Text, txtSenhaWEB.Text, txtDescricaoWEB.Text);
                CarregaGridDadosWeb();
            }
            else
                MessageBox.Show("Campos Inválidos!");

        }

        private void dgControleWeb_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            dadoWebRule.ExcluiTipoValor(int.Parse(dgControleWeb.CurrentRow.Cells[0].Value.ToString()));
            dgControleWeb.Rows.RemoveAt(dgControleWeb.CurrentRow.Index);
            CarregaGridDadosWeb();
            e.Cancel = true;
        }
    }
}