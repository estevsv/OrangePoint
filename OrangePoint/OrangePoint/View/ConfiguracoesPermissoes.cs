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
    public partial class ConfiguracoesPermissoes : Form
    {
        private Usuario usuarioPagina;
        private bool visibilidadeNovoUsuario;

        LoginRule loginRule = new LoginRule();
        TipoPermissaoRule tipoPermissaoRule = new TipoPermissaoRule();
        PermissoesRule permissoesRule = new PermissoesRule();
        FolhaPontoRule folhaPontoRule = new FolhaPontoRule();
        Utilities utilities = new Utilities();
        bool fechamentoSistema;

        public ConfiguracoesPermissoes(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void ConfiguracoesPermissoes_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            AtualizaDadosPagina();

            visibilidadeNovoUsuario = false;
            VisibilidadeCamposNovoUsuario();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ConfiguracoesTipoUsuarios(usuarioPagina).Show();
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void CarregaComboBoxUsuario()
        {
            cbUsuario.DataSource = loginRule.PesquisaTodosUsuariosTabela();
            cbUsuario.DisplayMember = "LOGIN";
            cbUsuario.ValueMember = "COD_USUARIO";
            if(cbUsuario.Items.Count != 0)
                cbUsuario.SelectedIndex = 0;
        }

        private void CarregaComboBoxTipoUsuario()
        {
            cbTipoUsuario.DataSource = tipoPermissaoRule.PesquisaTodosTipoPermissaoTabela();
            cbTipoUsuario.DisplayMember = "DESC_PERMISSAO";
            cbTipoUsuario.ValueMember = "COD_TIPO_PERMISSAO";
            if (cbTipoUsuario.Items.Count != 0)
                cbTipoUsuario.SelectedIndex = 0;
        }

        private void CarregaGrid()
        {
            dgPermissoes.DataSource = permissoesRule.FiltraPesquisaPermissaoTelaTabela();
            if (dgPermissoes.Columns.Count != 0)
            {
                dgPermissoes.Columns["id"].Visible = false;

                dgPermissoes.Columns["Usuario"].HeaderText = "Usuário";
                dgPermissoes.Columns["Permissao"].HeaderText = "Permissão";
                dgPermissoes.Columns["Usuario"].ReadOnly = true;
                dgPermissoes.Columns["Permissao"].ReadOnly = true;
                dgPermissoes.Columns["Usuario"].Width = 174;
                dgPermissoes.Columns["Permissao"].Width = 174;
            }
        }

        private void CarregaGridUsuarios()
        {
            dgUsuarios.DataSource = loginRule.PesquisaTodosUsuariosTabela();
            if (dgUsuarios.Columns.Count != 0)
            {
                dgUsuarios.Columns["COD_USUARIO"].Visible = false;
                dgUsuarios.Columns["SENHA"].Visible = false;
                dgUsuarios.Columns["HRS_DIARIA"].Visible = false;
                dgUsuarios.Columns["FOTO_USUARIO"].Visible = false;

                dgUsuarios.Columns["LOGIN"].HeaderText = "Usuário";
                dgUsuarios.Columns["NME_FUNCIONARIO"].HeaderText = "Nome do Usuário";
                dgUsuarios.Columns["LOGIN"].ReadOnly = true;
                dgUsuarios.Columns["NME_FUNCIONARIO"].ReadOnly = true;
                dgUsuarios.Columns["LOGIN"].Width = 174;
                dgUsuarios.Columns["NME_FUNCIONARIO"].Width = 174;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Permissoes permissao = new Permissoes();
            permissao.TipoPermissao = tipoPermissaoRule.PesquisaTodosTipoPermissaoLista().Find(o => o.CodTipoPermissao == int.Parse(cbTipoUsuario.SelectedValue.ToString())) ;
            permissao.Usuario = loginRule.PesquisaTodosUsuarios().Find(o => o.CodUsuario == int.Parse(cbUsuario.SelectedValue.ToString()));
            permissoesRule.Incluir(permissao);

            AtualizaDadosPagina();
        }

        private void dgPermissoes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Após esta operação o usuário " + usuarioPagina.Login +" se tornará Padrão do Sistema, deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                permissoesRule.Excluir(int.Parse(dgPermissoes.CurrentRow.Cells[0].Value.ToString()));

                dgPermissoes.Rows.RemoveAt(dgPermissoes.CurrentRow.Index);
                AtualizaDadosPagina();
            }
            e.Cancel = true;
        }

        private void AtualizaTipoUsuario()
        {
            List<TipoPermissao> listaTipoPermissao = tipoPermissaoRule.PesquisaTodosTipoPermissaoLista();
            List<Permissoes> listaPermissoes = permissoesRule.PesquisaTodasPermissoes();

            usuarioPagina = loginRule.DefineTipoPermissaoUsuario(listaPermissoes, usuarioPagina, listaTipoPermissao);
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
        }

        private void AtualizaDadosPagina()
        {
            CarregaComboBoxUsuario();
            CarregaComboBoxTipoUsuario();
            CarregaGrid();
            AtualizaTipoUsuario();
            CarregaGridUsuarios();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            button6.Visible = listaPermissoes[3];
            button7.Visible = listaPermissoes[0];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            if (visibilidadeNovoUsuario)
            {
                if (txtNovoUsuario.Text != "")
                {
                    loginRule.IncluirLogin(txtNovoUsuario.Text, txtNovaSenha.Text);
                    AtualizaDadosPagina();
                }
                else
                    MessageBox.Show("É necessário um Login. Novo Usuário não adicionado!");
                visibilidadeNovoUsuario = false;
                VisibilidadeCamposNovoUsuario();
                btnNovoUsuario.Text = "Adicionar Usuário";
            }
            else
            {
                visibilidadeNovoUsuario = true;
                VisibilidadeCamposNovoUsuario();
                btnNovoUsuario.Text = "Finalizar";
            }
            LimparCamposNovoUsuario();
        }

        private void VisibilidadeCamposNovoUsuario()
        {
            lblNovaSenha.Visible = visibilidadeNovoUsuario;
            lblNovoUsuario.Visible = visibilidadeNovoUsuario;
            txtNovaSenha.Visible = visibilidadeNovoUsuario;
            txtNovoUsuario.Visible = visibilidadeNovoUsuario;
        }

        private void LimparCamposNovoUsuario()
        {
            txtNovaSenha.Text = "";
            txtNovoUsuario.Text = "";
        }

        private void dgUsuarios_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Após esta operação o USUÁRIO selecionado, bem como suas PERMISSÕES e FOLHA DE PONTO serão EXCLUÍDOS, , deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                int codUsuario = int.Parse(dgUsuarios.CurrentRow.Cells[0].Value.ToString());

                folhaPontoRule.ExcluirPorUsuario(codUsuario);
                permissoesRule.ExcluirPorUsuario(codUsuario);
                loginRule.ExcluirLogin(codUsuario);

                dgUsuarios.Rows.RemoveAt(dgUsuarios.CurrentRow.Index);
                AtualizaDadosPagina();
            }
            e.Cancel = true;
        }

        private void ConfiguracoesPermissoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }
    }
}
