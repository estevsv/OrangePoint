using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            checkBox1.Checked = true;
            CarregaComboBox();
            CalculaObrigacoes();
        }

        private void CalculaObrigacoes()
        {
            chart1.Series["S1"].Points.Clear();
            chart2.Series["S1"].Points.Clear();

            int obrigacoesMensaisRealizadas = 0;
            int obrigacoesAnuaisRealizadas = 0;
            int totalObrigacoesMensais = 0;
            int totalObrigacoesAnuais = 0;

            List<ObrigacaoEmpresa> listaObrigacoes = new List<ObrigacaoEmpresa>();
            listaObrigacoes = checkBox1.Checked ? obrigacaoEmpresaRule.listaObrigacaoEmpresas() : obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.Empresa.CodEmpresa == int.Parse(cbEmpresa.SelectedValue.ToString())).ToList(); ;

            totalObrigacoesMensais = listaObrigacoes.Count();
            totalObrigacoesAnuais = listaObrigacoes.Count() * 12;

            if (listaEmpresas.Count() > 0)
            {
                List<ClassificacaoEmpresa> classificacaoEmpresa = checkBox1.Checked ? classificacaoEmpresaRule.listaClassificacaoEmpresa() : classificacaoEmpresaRule.listaClassificacaoEmpresa().Where(o => o.DataEmpresa.Empresa.CodEmpresa == int.Parse(cbEmpresa.SelectedValue.ToString())).ToList();
                if(classificacaoEmpresa.Count > 0)
                {
                    obrigacoesMensaisRealizadas = totalObrigacoesMensais - classificacaoEmpresa.Where(o => o.DataEmpresa.Data.Month == dateTimePicker1.Value.Month
                    && o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).Count();

                    obrigacoesAnuaisRealizadas = totalObrigacoesAnuais - (classificacaoEmpresa.Where(o => o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).Count());
                }
            }

            ConstroiCharts(new List<string> { obrigacoesMensaisRealizadas.ToString(),(totalObrigacoesMensais - obrigacoesMensaisRealizadas).ToString(),
            obrigacoesAnuaisRealizadas.ToString(),(totalObrigacoesAnuais - obrigacoesAnuaisRealizadas).ToString()});
        }

        private void ConstroiCharts(List<string> listXY)
        {
            chart1.Series["S1"].IsValueShownAsLabel = true;
            if(listXY[0] != "0")
                chart1.Series["S1"].Points.AddXY("Realizadas", listXY[0]);
            if (listXY[1] != "0")
                chart1.Series["S1"].Points.AddXY("Restantes", listXY[1]);

            chart2.Series["S1"].IsValueShownAsLabel = true;
            if (listXY[2] != "0")
                chart2.Series["S1"].Points.AddXY("Realizadas", listXY[2]);
            if (listXY[3] != "0")
                chart2.Series["S1"].Points.AddXY("Restantes", listXY[3]);
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
            if (cbEmpresa.Enabled)
                CalculaObrigacoes();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbEmpresa.Enabled = !checkBox1.Checked;
            CalculaObrigacoes();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculaObrigacoes();
        }
    }
}
