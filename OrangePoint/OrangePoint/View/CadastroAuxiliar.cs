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
        TipoDataRule tipoDataRule = new TipoDataRule();
        TipoValorRule tipoValorRule = new TipoValorRule();

        public CadastroAuxiliar(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void CadastroAuxiliar_Load(object sender, EventArgs e)
        {
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
            CarregaGridTipoData();
            CarregaGridTipoValor();
        }

        #region Controle de Acessos
        private void FechaPagina()
        {
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
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        } 
        #endregion

        #region Gerenciamento de dados

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
                regimeEmpresaRule.IncluirRegimeEmpresa(txtNovoRegime.Text);

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
                grupoRule.IncluirGrupoEmpresa(txtNovoGrupo.Text);

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
                atividadeRule.IncluirAtividade(txtAtividade.Text);

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

        #region Dados Tipo Data
        private void CarregaGridTipoData()
        {
            dgTipoDatas.DataSource = tipoDataRule.PesquisaTipoDataTabela();
            if (dgTipoDatas.Columns.Count != 0)
            {
                dgTipoDatas.Columns["COD_TIPO_DATA"].Visible = false;
                dgTipoDatas.Columns["DESC_TIPO"].HeaderText = "Descrição";
                dgTipoDatas.Columns["DESC_TIPO"].ReadOnly = true;
                dgTipoDatas.Columns["DESC_TIPO"].Width = 187;
            }
        }

        private void btnAdicionaTipoDatas_Click(object sender, EventArgs e)
        {
            if (txtTipoDatas.Text != "")
                tipoDataRule.IncluirTipoData(txtTipoDatas.Text);

            CarregaGridTipoData();
        }

        private void dgTipoDatas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            tipoDataRule.ExcluiTipoData(int.Parse(dgTipoDatas.CurrentRow.Cells[0].Value.ToString()));
            dgTipoDatas.Rows.RemoveAt(dgTipoDatas.CurrentRow.Index);

            CarregaGridTipoData();

            e.Cancel = true;
        }
        #endregion

        #region Dados Tipo Valor
        private void CarregaGridTipoValor()
        {
            dgTipoValor.DataSource = tipoValorRule.PesquisaTipoValorTabela();
            if (dgTipoValor.Columns.Count != 0)
            {
                dgTipoValor.Columns["COD_TIPO_VALOR"].Visible = false;
                dgTipoValor.Columns["DESC_TIPO"].HeaderText = "Descrição";
                dgTipoValor.Columns["DESC_TIPO"].ReadOnly = true;
                dgTipoValor.Columns["DESC_TIPO"].Width = 187;
            }
        }

        private void btnAdicionarTipoValor_Click(object sender, EventArgs e)
        {
            if (txtTipoValor.Text != "")
                tipoValorRule.IncluirTipoValor(txtTipoValor.Text);

            CarregaGridTipoValor();
        }

        private void dgTipoValor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            tipoValorRule.ExcluiTipoValor(int.Parse(dgTipoValor.CurrentRow.Cells[0].Value.ToString()));
            dgTipoValor.Rows.RemoveAt(dgTipoValor.CurrentRow.Index);

            CarregaGridTipoValor();

            e.Cancel = true;
        }
        #endregion

        #endregion
    }
}
