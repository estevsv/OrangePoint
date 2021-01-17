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
    public partial class ValoresEmpresa : Form
    {
        private Usuario usuarioPagina;
        private bool fechamentoSistema;
        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();
        DataEmpresaRule dataEmpresaRule = new DataEmpresaRule();
        private List<Empresa> listaEmpresas;
        private bool isLoad;
        SubtipoValorRule subtipoValorRule = new SubtipoValorRule();

        public ValoresEmpresa(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void ValoresEmpresa_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;
            isLoad = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            listaEmpresas = empresaRule.listaEmpresas();
            CarregaComboBox();

            isLoad = false;
        }

        #region Controle de Tela
        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();

        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
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
            new EmpresaView(usuarioPagina).Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Dashboard(usuarioPagina).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroEmpresa(usuarioPagina).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroAuxiliar(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }
        #endregion

        private void CarregaComboBox(string razaoSocial = "")
        {
            List<Empresa> filtroLista = razaoSocial == "" ? listaEmpresas : listaEmpresas.FindAll(o => o.RazaoSocial.Substring(0, 1) == razaoSocial).OrderBy(o => o.RazaoSocial).ToList();
            if (listaEmpresas.Count != 0)
            {
                cbEmpresa.DataSource = empresaRule.ElaboraTabelaEmpresa(filtroLista);
                cbEmpresa.DisplayMember = "Razão Social";
                cbEmpresa.ValueMember = "id";
                CarregaGridDataEmpresa();
            }

            if (filtroLista.Count == 0)
                cbEmpresa.Text = "";
        }

        private void cbEmpresa_TextUpdate(object sender, EventArgs e)
        {
            if (cbEmpresa.Text == "")
                CarregaComboBox();
            else
                CarregaComboBox(cbEmpresa.Text);
        }

        private void CarregaGridDataEmpresa()
        {
            if (cbEmpresa.SelectedValue != null)
            {
                List<DataEmpresa> listaData = dataEmpresaRule.listaDataEmpresa().Where(o => o.Empresa.CodEmpresa == int.Parse(cbEmpresa.SelectedValue.ToString())).ToList();
                if (listaData.Count != 0)
                {
                    cbData.DataSource = dataEmpresaRule.ElaboraTabelaDataEmpresa(listaData);
                    cbData.DisplayMember = "Data";
                    cbData.ValueMember = "id";
                }
                else
                    cbData.DataSource = null;
            }
            else
                cbData.DataSource = null;
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedIndex != -1 && !isLoad)
                CarregaGridDataEmpresa();
        }

        private void CarregarComboBoxSubtipoValor()
        {
            cbSubtipoValor.DataSource = subtipoValorRule.FiltraPesquisaSubtipoValorTabela();
            cbSubtipoValor.DisplayMember = "SubtipoValor";
            cbSubtipoValor.ValueMember = "id";
        }

        private void btnCadastrarValor_Click(object sender, EventArgs e)
        {
            Valor valor = new Valor();
            valor.DataEmpresa = dataEmpresaRule.listaDataEmpresa().Find(o => o.CodData == int.Parse(cbData.SelectedValue.ToString()));
            valor.SubtipoValor = subtipoValorRule.listaSubtipoValor().Find(o => o.CodSubtipoValor == int.Parse(cbSubtipoValor.SelectedValue.ToString()));
            valor.NumValor = decimal.Parse(txtValor.Text);
        }
    }
}
