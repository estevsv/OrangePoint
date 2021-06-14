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
    public partial class CadastroAuxiliarFinanceiro : Form
    {
        private Usuario usuarioPagina;
        bool fechamentoSistema;

        Utilities utilities = new Utilities();
        TipoValorRule tipoValorRule = new TipoValorRule();
        SubtipoValorRule subtipoValorRule = new SubtipoValorRule();
        SubtipoAtividadeRule subtipoAtividadeRule = new SubtipoAtividadeRule();
        AtividadeRule atividadeRule = new AtividadeRule();

        public CadastroAuxiliarFinanceiro(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void CadastroAuxiliarFinanceiro_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            CarregaGrids();
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button8.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void CadastroAuxiliarFinanceiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }

        private void CarregaGrids()
        {
            CarregaGridTipoValor();
            CarregaGridSubtipoValor();
            CarregaGridSubtipoAtividade();
            CarregaGridAtividade();
        }

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

                CarregaCbTipoValor();
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
            if (int.Parse(dgTipoValor.CurrentRow.Cells[0].Value.ToString()) > 5)
            {
                tipoValorRule.ExcluiTipoValor(int.Parse(dgTipoValor.CurrentRow.Cells[0].Value.ToString()));
                dgTipoValor.Rows.RemoveAt(dgTipoValor.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Este item não pode ser excluído (Padrão)");
            }
            CarregaGridTipoValor();

            e.Cancel = true;
        }
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

                CarregaCbAtividade();
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

        #region Controle de Tela
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }
    }
}
