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
        LoginRule loginRule = new LoginRule();
        TipoPermissaoRule tipoPermissaoRule = new TipoPermissaoRule();
        PermissoesRule permissoesRule = new PermissoesRule();
        Utilities utilities = new Utilities();

        public ConfiguracoesPermissoes(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void ConfiguracoesPermissoes_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            CarregaComboBoxUsuario();
            CarregaComboBoxTipoUsuario();
            CarregaGrid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ConfiguracoesTipoUsuarios(usuarioPagina).Show();
        }


        private void FechaPagina()
        {
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
                dgPermissoes.Columns["Usuario"].Width = 500;
                dgPermissoes.Columns["Permissao"].Width = 305;
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
            permissoesRule.Excluir(int.Parse(dgPermissoes.CurrentRow.Cells[0].Value.ToString()));

            dgPermissoes.Rows.RemoveAt(dgPermissoes.CurrentRow.Index);
            AtualizaDadosPagina();

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
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            button6.Visible = listaPermissoes[3];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }
    }
}
