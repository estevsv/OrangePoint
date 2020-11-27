using OrangePoint.BusinessRule;
using OrangePoint.Model;
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
    public partial class ConfiguracoesTipoUsuarios : Form
    {
        private Usuario usuarioPagina;
        TipoPermissaoRule tipoPermissaoRule = new TipoPermissaoRule();
        PermissaoTelaRule permissaoTelaRule = new PermissaoTelaRule();

        public ConfiguracoesTipoUsuarios(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void ConfiguracoesTipoUsuarios_Load(object sender, EventArgs e)
        {
            CarregaGridTipoUsuarios();
            CarregaGridPermissoesUsuario();
            CarregaComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void FechaPagina()
        {
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ConfiguracoesPermissoes(usuarioPagina).Show();
        }

        private void CarregaGridTipoUsuarios()
        {
            dgTipoUsuario.DataSource = tipoPermissaoRule.PesquisaTodosTipoPermissaoTabela();
            if (dgTipoUsuario.Columns.Count != 0)
            {
                dgTipoUsuario.Columns["COD_TIPO_PERMISSAO"].HeaderText = "Código";
                dgTipoUsuario.Columns["DESC_PERMISSAO"].HeaderText = "Descrição";
                dgTipoUsuario.Columns["COD_TIPO_PERMISSAO"].ReadOnly = true;
                dgTipoUsuario.Columns["DESC_PERMISSAO"].ReadOnly = true;
                dgTipoUsuario.Columns["COD_TIPO_PERMISSAO"].Width = 150;
                dgTipoUsuario.Columns["DESC_PERMISSAO"].Width = 187;
            }
        }

        private void CarregaGridPermissoesUsuario()
        {
            dgPermissoesUsuario.DataSource = permissaoTelaRule.FiltraPesquisaPermissaoTelaTabela();
            if (dgPermissoesUsuario.Columns.Count != 0)
            {
                dgPermissoesUsuario.Columns["id"].Visible = false;

                dgPermissoesUsuario.Columns["TipoPermissao"].HeaderText = "Tipo de Usuário";
                dgPermissoesUsuario.Columns["Tela"].HeaderText = "Tela disponível";
                dgPermissoesUsuario.Columns["TipoPermissao"].ReadOnly = true;
                dgPermissoesUsuario.Columns["Tela"].ReadOnly = true;
                dgPermissoesUsuario.Columns["TipoPermissao"].Width = 150;
                dgPermissoesUsuario.Columns["Tela"].Width = 187;
            }
        }

        private void CarregaComboBoxes()
        {
            cbTipoUsuario.DataSource = dgTipoUsuario.DataSource;
            cbTipoUsuario.DisplayMember = "DESC_PERMISSAO";
            cbTipoUsuario.ValueMember = "COD_TIPO_PERMISSAO";
            cbTela.SelectedIndex = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Tbusuario.Text != "")
            {
                tipoPermissaoRule.Incluir(Tbusuario.Text);
                CarregaGridTipoUsuarios();
                CarregaComboBoxes();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(cbTipoUsuario.Text != "" && cbTela.Text != "")
            {
                permissaoTelaRule.Incluir(int.Parse(cbTipoUsuario.SelectedValue.ToString()), cbTela.Text);
            }
            CarregaGridPermissoesUsuario();
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

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void dgTipoUsuario_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Ao deletar um tipo de usuário, todos os usuários com essa permissão automaticamente receberão a configuração padrão, deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                tipoPermissaoRule.Deletar(int.Parse(dgTipoUsuario.CurrentRow.Cells[0].Value.ToString()));
                dgTipoUsuario.Rows.RemoveAt(dgTipoUsuario.CurrentRow.Index);

                CarregaGridPermissoesUsuario();
            }
            e.Cancel = true;
        }
    }
}
