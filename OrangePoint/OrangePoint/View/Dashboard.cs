using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class Dashboard : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        LoginRule loginRule = new LoginRule();
        EmpresaRule empresaRule = new EmpresaRule();
        ObrigacaoEmpresaRule obrigacaoEmpresaRule = new ObrigacaoEmpresaRule();
        ClassificacaoEmpresaRule classificacaoEmpresaRule = new ClassificacaoEmpresaRule();
        bool fechamentoSistema;
        private List<Empresa> listaEmpresas;

        public Dashboard(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Bem Vindo " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            listaEmpresas = empresaRule.listaEmpresas();
            CarregaComboBox();
            CalculaObrigacoes();
        }

        private void CalculaObrigacoes()
        {
            int obrigacoesAnuais = 0;
            int obrigacoesMensais = 0;

            List<ObrigacaoEmpresa> listaObrigacoes = new List<ObrigacaoEmpresa>();
            listaObrigacoes = obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.Empresa.CodEmpresa == int.Parse(cbEmpresa.SelectedValue.ToString())).ToList(); ;

            obrigacoesMensais = listaObrigacoes.Count();
            obrigacoesAnuais = listaObrigacoes.Count() * 12;

            if(listaEmpresas.Count() > 0)
            {
                List<ClassificacaoEmpresa> classificacaoEmpresa = classificacaoEmpresaRule.listaClassificacaoEmpresa().Where(o => o.DataEmpresa.Empresa.CodEmpresa == int.Parse(cbEmpresa.SelectedValue.ToString())).ToList();
                if(classificacaoEmpresa.Count > 0)
                {
                    obrigacoesAnuais = (listaObrigacoes.Count() *12) - (classificacaoEmpresa.Where(o => o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).Count());
                    
                    obrigacoesMensais = listaObrigacoes.Count() - classificacaoEmpresa.Where(o => o.DataEmpresa.Data.Month == dateTimePicker1.Value.Month
                    && o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).Count();
                }
            }

            lblObrigacaoMensal.Text = obrigacoesMensais.ToString();
            lblObrigacaoAnual.Text = obrigacoesAnuais.ToString();
        }

        private void CarregaComboBox(string razaoSocial = "")
        {
            List<Empresa> filtroLista = razaoSocial == "" ? listaEmpresas : listaEmpresas.FindAll(o => o.RazaoSocial.Substring(0, 1) == razaoSocial).OrderBy(o => o.RazaoSocial).ToList();
            if (listaEmpresas.Count != 0)
            {
                cbEmpresa.DataSource = empresaRule.ElaboraTabelaEmpresa(filtroLista);
                cbEmpresa.DisplayMember = "Razão Social";
                cbEmpresa.ValueMember = "id";
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

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button8.Visible = listaPermissoes[1];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
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

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CalculaObrigacoes();
        }
    }
}
