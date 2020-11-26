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
            dgPemissoesUsuario.DataSource = permissaoTelaRule.FiltraPesquisaPermissaoTelaTabela();
            if (dgPemissoesUsuario.Columns.Count != 0)
            {
                dgPemissoesUsuario.Columns["id"].Visible = false;

                dgPemissoesUsuario.Columns["TipoPermissao"].HeaderText = "Tipo de Usuário";
                dgPemissoesUsuario.Columns["Tela"].HeaderText = "Tela disponível";
                dgPemissoesUsuario.Columns["TipoPermissao"].ReadOnly = true;
                dgPemissoesUsuario.Columns["Tela"].ReadOnly = true;
                dgPemissoesUsuario.Columns["TipoPermissao"].Width = 150;
                dgPemissoesUsuario.Columns["Tela"].Width = 187;
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

            }
        }
    }
}
