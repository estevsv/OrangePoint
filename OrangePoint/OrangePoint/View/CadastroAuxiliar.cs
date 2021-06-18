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
    public partial class CadastroAuxiliar : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        RegimeEmpresaRule regimeEmpresaRule = new RegimeEmpresaRule();
        GrupoRule grupoRule = new GrupoRule();
        AtividadeRule atividadeRule = new AtividadeRule();
        TipoValorRule tipoValorRule = new TipoValorRule();
        SubtipoValorRule subtipoValorRule = new SubtipoValorRule(); 
        SubtipoAtividadeRule subtipoAtividadeRule = new SubtipoAtividadeRule(); 
        TipoClassificacaoRule tipoClassificacaoRule = new TipoClassificacaoRule(); 
        bool fechamentoSistema;

        private int idRegimeAlteracao = -1;
        private int idGrupoAlteracao = -1;
        private int idAtividadeAlteracao = -1;
        private int idTipoClassificacaoAlteracao = -1;

        public CadastroAuxiliar(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void CadastroAuxiliar_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
            CarregarGrids();
        }

        private void CarregarGrids()
        {
            CarregaGridRegime();
            CarregaGridGrupo();
            CarregaGridAtividade();
            CarregaGridTipoClassificacao();
        }

        #region Controle de Acessos
        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button8.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }
        #endregion

        #region Controle de transição de tela e Fechamento
        
        private void CadastroAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        } 
        #endregion

        #region Gerenciamento de dados

        #region Área Principal

        #region Dados Regime
        private void CarregaGridRegime()
        {
            dgRegime.DataSource = regimeEmpresaRule.PesquisaRegimeEmpresasTabela();
            if (dgRegime.Columns.Count != 0)
            {
                dgRegime.Columns["COD_REGIME"].Visible = false;
                dgRegime.Columns["DESCRICAO"].HeaderText = "Descrição";
                dgRegime.Columns["DESCRICAO"].ReadOnly = true;
                dgRegime.Columns["DESCRICAO"].Width = 187;
            }
        }

        private void AdicionarRegime_Click(object sender, EventArgs e)
        {
            if (txtNovoRegime.Text != "")
            {
                regimeEmpresaRule.IncluirRegimeEmpresa(txtNovoRegime.Text, idRegimeAlteracao);
                btnCancelarRegime.Visible = false;
                idRegimeAlteracao = -1;
            }

            CarregaGridRegime();
        }

        private void dgRegime_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            regimeEmpresaRule.ExcluiRegimeEmpresa(int.Parse(dgRegime.CurrentRow.Cells[0].Value.ToString()));
            dgRegime.Rows.RemoveAt(dgRegime.CurrentRow.Index);

            CarregaGridRegime();

            e.Cancel = true;
        }
        #endregion

        #region Dados Grupo
        private void CarregaGridGrupo()
        {
            dgGrupo.DataSource = grupoRule.PesquisaGrupoEmpresasTabela();
            if (dgGrupo.Columns.Count != 0)
            {
                dgGrupo.Columns["COD_GRUPO"].Visible = false;
                dgGrupo.Columns["DESCRICAO"].HeaderText = "Descrição";
                dgGrupo.Columns["DESCRICAO"].ReadOnly = true;
                dgGrupo.Columns["DESCRICAO"].Width = 187;
            }
        }

        private void AdicionarGrupo_Click(object sender, EventArgs e)
        {
            if (txtNovoGrupo.Text != "")
            {
                grupoRule.IncluirGrupoEmpresa(txtNovoGrupo.Text, idGrupoAlteracao);
                btnCancelarGrupo.Visible = false;
                idGrupoAlteracao = -1;
            }

            CarregaGridGrupo();
        }

        private void dgGrupo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            grupoRule.ExcluiGrupoEmpresa(int.Parse(dgGrupo.CurrentRow.Cells[0].Value.ToString()));
            dgGrupo.Rows.RemoveAt(dgGrupo.CurrentRow.Index);

            CarregaGridGrupo();

            e.Cancel = true;
        }
        #endregion

        #region Dados Atividade
        private void CarregaGridAtividade()
        {
            dgAtividade.DataSource = atividadeRule.PesquisaAtividadeTabela();
            if (dgAtividade.Columns.Count != 0)
            {
                dgAtividade.Columns["COD_Atividade"].Visible = false;
                dgAtividade.Columns["DESCRICAO"].HeaderText = "Descrição";
                dgAtividade.Columns["DESCRICAO"].ReadOnly = true;
                dgAtividade.Columns["DESCRICAO"].Width = 187;
            }
        }

        private void AdicionarAtividadeEmpresa_Click(object sender, EventArgs e)
        {
            if (txtAtividade.Text != "")
            {
                atividadeRule.IncluirAtividade(txtAtividade.Text, idAtividadeAlteracao);
                btnCancelarAtividade.Visible = false;
                idAtividadeAlteracao = -1;
            }

            CarregaGridAtividade();
        }

        private void dgAtividade_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            atividadeRule.ExcluiAtividade(int.Parse(dgAtividade.CurrentRow.Cells[0].Value.ToString()));
            dgAtividade.Rows.RemoveAt(dgAtividade.CurrentRow.Index);

            CarregaGridAtividade();

            e.Cancel = true;
        }
        #endregion

        #region Dados Tipo Classificação
        private void CarregaGridTipoClassificacao()
        {
            dgTipoClassificacao.DataSource = tipoClassificacaoRule.PesquisaTipoClassificacaoTabela();
            if (dgTipoClassificacao.Columns.Count != 0)
            {
                dgTipoClassificacao.Columns["COD_TIPO_CLASSIFICACAO"].Visible = false;
                dgTipoClassificacao.Columns["DESCRICAO"].HeaderText = "Descrição";
                dgTipoClassificacao.Columns["DESCRICAO"].ReadOnly = true;
                dgTipoClassificacao.Columns["DESCRICAO"].Width = 187;
            }
        }

        private void btnAdicionarClassificacao_Click(object sender, EventArgs e)
        {
            if (txtClassificacao.Text != "")
            {
                tipoClassificacaoRule.IncluirTipoClassificacao(txtClassificacao.Text, idTipoClassificacaoAlteracao);
                btnCancelarObrigacoes.Visible = false;
                idTipoClassificacaoAlteracao = -1;
            }

            CarregaGridTipoClassificacao();
        }

        private void dgTipoClassificacao_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            tipoClassificacaoRule.ExcluiTipoClassificacao(int.Parse(dgTipoClassificacao.CurrentRow.Cells[0].Value.ToString()));
            dgTipoClassificacao.Rows.RemoveAt(dgTipoClassificacao.CurrentRow.Index);

            CarregaGridTipoClassificacao();

            e.Cancel = true;
        }
        #endregion

        #endregion

        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }

        private void dgRegime_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNovoRegime.Text = dgRegime.CurrentRow.Cells[1].Value.ToString();
            idRegimeAlteracao = int.Parse(dgRegime.CurrentRow.Cells[0].Value.ToString());
            btnCancelarRegime.Visible = true;
        }

        private void dgGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNovoGrupo.Text = dgGrupo.CurrentRow.Cells[1].Value.ToString();
            idGrupoAlteracao = int.Parse(dgGrupo.CurrentRow.Cells[0].Value.ToString());
            btnCancelarGrupo.Visible = true;
        }

        private void dgAtividade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAtividade.Text = dgAtividade.CurrentRow.Cells[1].Value.ToString();
            idAtividadeAlteracao = int.Parse(dgAtividade.CurrentRow.Cells[0].Value.ToString());
            btnCancelarAtividade.Visible = true;
        }

        private void dgTipoClassificacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClassificacao.Text = dgTipoClassificacao.CurrentRow.Cells[1].Value.ToString();
            idTipoClassificacaoAlteracao = int.Parse(dgTipoClassificacao.CurrentRow.Cells[0].Value.ToString());
            btnCancelarObrigacoes.Visible = true;
        }

        private void btnCancelarRegime_Click(object sender, EventArgs e)
        {
            idRegimeAlteracao = -1;
            btnCancelarRegime.Visible = false;
            txtNovoRegime.Text = "";
        }

        private void btnCancelarGrupo_Click(object sender, EventArgs e)
        {
            idGrupoAlteracao = -1;
            btnCancelarGrupo.Visible = false;
            txtNovoGrupo.Text = "";
        }

        private void btnCancelarAtividade_Click(object sender, EventArgs e)
        {
            idAtividadeAlteracao = -1;
            btnCancelarAtividade.Visible = false;
            txtAtividade.Text = "";
        }

        private void btnCancelarObrigacoes_Click(object sender, EventArgs e)
        {
            idTipoClassificacaoAlteracao = -1;
            btnCancelarObrigacoes.Visible = false;
            txtClassificacao.Text = "";
        }
    }
}
