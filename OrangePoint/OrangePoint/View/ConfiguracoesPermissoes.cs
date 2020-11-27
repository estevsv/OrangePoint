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
    public partial class ConfiguracoesPermissoes : Form
    {
        private Usuario usuarioPagina;
        LoginRule loginRule = new LoginRule();
        TipoPermissaoRule tipoPermissaoRule = new TipoPermissaoRule();
        PermissoesRule permissoesRule = new PermissoesRule();

        public ConfiguracoesPermissoes(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void ConfiguracoesPermissoes_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;

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
            cbUsuario.SelectedIndex = 0;
        }

        private void CarregaComboBoxTipoUsuario()
        {
            cbTipoUsuario.DataSource = tipoPermissaoRule.PesquisaTodosTipoPermissaoTabela();
            cbTipoUsuario.DisplayMember = "DESC_PERMISSAO";
            cbTipoUsuario.ValueMember = "COD_TIPO_PERMISSAO";
            cbTipoUsuario.SelectedIndex = 0;
        }

        private void CarregaGrid()
        {
            /*dgPermissoes.DataSource = permissoesRule.PesquisaTodasPermissoesTabela();
            if (dgPermissoes.Columns.Count != 0)
            {
                dgPermissoes.Columns["COD_PERMISSAO"].Visible = false;

                dgPermissoes.Columns["COD_USUARIO"].HeaderText = "Tipo de Usuário";
                dgPermissoes.Columns["COD_TIPO_PERMISSAO"].HeaderText = "Tela disponível";
                dgPermissoes.Columns["COD_USUARIO"].ReadOnly = true;
                dgPermissoes.Columns["COD_TIPO_PERMISSAO"].ReadOnly = true;
                dgPermissoes.Columns["COD_USUARIO"].Width = 150;
                dgPermissoes.Columns["COD_TIPO_PERMISSAO"].Width = 187;
            }*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Permissoes permissao = new Permissoes();


            permissao.TipoPermissao = tipoPermissaoRule.PesquisaTodosTipoPermissaoLista().Find(o => o.CodTipoPermissao == int.Parse(cbTipoUsuario.ValueMember)) ;
            permissao.Usuario = loginRule.PesquisaTodosUsuarios().Find(o => o.CodUsuario == int.Parse(cbUsuario.ValueMember));
            permissoesRule.Incluir(permissao);

            CarregaComboBoxUsuario();
            CarregaComboBoxTipoUsuario();
            CarregaGrid();
        }
    }
}
