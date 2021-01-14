﻿using OrangePoint.BusinessRule;
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
        SubtipoValorRule subtipoValorRule = new SubtipoValorRule(); 
        SubtipoAtividadeRule subtipoAtividadeRule = new SubtipoAtividadeRule(); 
        TipoClassificacaoRule tipoClassificacaoRule = new TipoClassificacaoRule(); 
        bool fechamentoSistema;

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
            CarregaGridTipoData();
            CarregaGridTipoValor();
            CarregaGridSubtipoValor();
            CarregaCbTipoValor();
            CarregaGridSubtipoAtividade();
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
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }
        #endregion

        #region Controle de transição de tela e Fechamento
        private void btnCadastrarSubtipos_Click(object sender, EventArgs e)
        {
            pnCadastraSubtipos.Visible = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnCadastraSubtipos.Visible = false;
        }

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

            CarregaCbAtividade();
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

            CarregaCbTipoValor();
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
                tipoClassificacaoRule.IncluirTipoClassificacao(txtClassificacao.Text);

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

        #region Área Subtipos

        #region Carregamentos de Comboboxes
        private void CarregaCbTipoValor()
        {
            cbTipoValor.DataSource = dgTipoValor.DataSource;
            cbTipoValor.DisplayMember = "DESC_TIPO";
            cbTipoValor.ValueMember = "COD_TIPO_VALOR";
        }

        private void CarregaCbAtividade()
        {
            cbAtividade.DataSource = dgAtividade.DataSource;
            cbAtividade.DisplayMember = "DESCRICAO";
            cbAtividade.ValueMember = "COD_ATIVIDADE";
        }

        private void CarregaCbSubtipoValor()
        {
            cbSubtipoValor.DataSource = dgSubtipoValor.DataSource;
            cbSubtipoValor.DisplayMember = "SubtipoValor";
            cbSubtipoValor.ValueMember = "id";
        }

        #endregion

        #region Dados Subtipo Valor

        private void CarregaGridSubtipoValor()
        {
            dgSubtipoValor.DataSource = subtipoValorRule.FiltraPesquisaSubtipoValorTabela();
            if (dgSubtipoValor.Columns.Count != 0)
            {
                dgSubtipoValor.Columns["id"].Visible = false;
                dgSubtipoValor.Columns["TipoValor"].HeaderText = "Tipo de Valor";
                dgSubtipoValor.Columns["SubtipoValor"].HeaderText = "Subtipo de Valor";
                dgSubtipoValor.Columns["TipoValor"].ReadOnly = true;
                dgSubtipoValor.Columns["SubtipoValor"].ReadOnly = true;
                dgSubtipoValor.Columns["TipoValor"].Width = 145;
                dgSubtipoValor.Columns["SubtipoValor"].Width = 145;
            }

            CarregaCbSubtipoValor();
        }

        private void btnAdicionarSubitipoValor_Click(object sender, EventArgs e)
        {
            if (txtSubtipoValor.Text != "" && cbTipoValor.Text != "")
                subtipoValorRule.IncluirSubtipoValor(int.Parse(cbTipoValor.SelectedValue.ToString()), txtSubtipoValor.Text);

            CarregaGridSubtipoValor();
        }

        private void dgSubtipoValor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            subtipoValorRule.ExcluiSubtipoValor(int.Parse(dgSubtipoValor.CurrentRow.Cells[0].Value.ToString()));
            dgSubtipoValor.Rows.RemoveAt(dgSubtipoValor.CurrentRow.Index);

            CarregaGridSubtipoValor();

            e.Cancel = true;
        }

        #endregion

        #region Dados Subtipo Atividade

        private void CarregaGridSubtipoAtividade()
        {
            dgSubtipoAtividade.DataSource = subtipoAtividadeRule.FiltraPesquisaSubtipoAtividadeTabela();
            if (dgSubtipoAtividade.Columns.Count != 0)
            {
                dgSubtipoAtividade.Columns["id"].Visible = false;
                dgSubtipoAtividade.Columns["Atividade"].HeaderText = "Atividade";
                dgSubtipoAtividade.Columns["SubtipoValor"].HeaderText = "Subtipo de Valor";
                dgSubtipoAtividade.Columns["Atividade"].ReadOnly = true;
                dgSubtipoAtividade.Columns["SubtipoValor"].ReadOnly = true;
                dgSubtipoAtividade.Columns["Atividade"].Width = 145;
                dgSubtipoAtividade.Columns["SubtipoValor"].Width = 145;
            }
        }

        private void btnAdicionaSubtipoAtividade_Click(object sender, EventArgs e)
        {
            if (cbAtividade.Text != "" && cbSubtipoValor.Text != "")
                subtipoAtividadeRule.IncluirSubtipoAtividade(int.Parse(cbAtividade.SelectedValue.ToString()), int.Parse(cbSubtipoValor.SelectedValue.ToString()));

            CarregaGridSubtipoAtividade();
        }

        private void dgSubtipoAtividade_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            subtipoAtividadeRule.ExcluiSubtipoAtividade(int.Parse(dgSubtipoAtividade.CurrentRow.Cells[0].Value.ToString()));
            dgSubtipoAtividade.Rows.RemoveAt(dgSubtipoAtividade.CurrentRow.Index);

            CarregaGridSubtipoAtividade();

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
    }
}
