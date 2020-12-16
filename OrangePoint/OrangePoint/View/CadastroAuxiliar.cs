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

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void CarregarGrids()
        {
            CarregaGridRegime();
            CarregaGridGrupo();
        }

        #region Gerenciamento de dados
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
        #endregion

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

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }
    }
}
