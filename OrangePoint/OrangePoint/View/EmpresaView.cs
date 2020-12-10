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
    public partial class EmpresaView : Form
    {
        private Usuario usuarioPagina;
        private List<Empresa> listaEmpresas;
        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();

        public EmpresaView(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void EmpresaView_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));
            listaEmpresas = empresaRule.listaEmpresas();
            CarregaGrid(empresaRule.ElaboraTabelaEmpresa(listaEmpresas));
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void FechaPagina()
        {
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Dashboard(usuarioPagina).Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void CarregaGrid(DataTable tabela)
        {
            dgEmpresa.DataSource = tabela;

            dgEmpresa.Columns["id"].Visible = false;
            
            dgEmpresa.Columns["RAZAO_SOCIAL"].Width = 200;
            dgEmpresa.Columns["GRUPO"].Width = 160;

            dgEmpresa.Columns["RAZAO_SOCIAL"].ReadOnly = true;
            dgEmpresa.Columns["GRUPO"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tabelaEmpresas = empresaRule.PesquisaEmpresasTabela();
            //CarregaGrid();
        }

        private void txtFiltroRazaoSocial_TextChanged(object sender, EventArgs e)
        {

        }

        private void FiltraLista()
        {

        }
    }
}
