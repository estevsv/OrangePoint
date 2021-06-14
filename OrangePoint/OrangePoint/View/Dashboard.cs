using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.Data;
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
            cbTipoDetalhamento.SelectedIndex = 0;
            CarregaComboBox();
            CalculaObrigacoes();
        }

        private void CalculaObrigacoes()
        {
            int tipoObrigacao = cbTipoDetalhamento.Text == "Mensal" ? 1 : 2;

            chart1.Series["S1"].Points.Clear();
            chart2.Series["S1"].Points.Clear();

            int obrigacoesMensaisRealizadas = 0;
            int obrigacoesAnuaisRealizadas = 0;
            int totalObrigacoesMensais = 0;
            int totalObrigacoesAnuais = 0;

            List<ObrigacaoEmpresa> listaObrigacoes = new List<ObrigacaoEmpresa>();
            listaObrigacoes = checkBox1.Checked ? obrigacaoEmpresaRule.listaObrigacaoEmpresas() : obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.Empresa.RazaoSocial == cbEmpresa.Text).ToList(); ;

            totalObrigacoesMensais = listaObrigacoes.Where(o => o.TipoObrigacao == 1).Count();
            totalObrigacoesAnuais = listaObrigacoes.Where(o => o.TipoObrigacao == 2).Count();

            if (listaEmpresas.Count() > 0)
            {
                List<ClassificacaoEmpresa> classificacaoEmpresa = checkBox1.Checked ? classificacaoEmpresaRule.listaClassificacaoEmpresa() : classificacaoEmpresaRule.listaClassificacaoEmpresa().Where(o => o.DataEmpresa.Empresa.RazaoSocial == cbEmpresa.Text).ToList();
                if(classificacaoEmpresa.Count > 0)
                {
                    List<ClassificacaoEmpresa> classificacaoEmpresaMensal = classificacaoEmpresa.Where(o => listaObrigacoes.Exists(p => p.TipoClassificacao.CodTipoClassificacao == o.TipoClassificacao.CodTipoClassificacao && p.TipoObrigacao == 1)).ToList();
                    List<ClassificacaoEmpresa> classificacaoEmpresaAnual = classificacaoEmpresa.Where(o => listaObrigacoes.Exists(p => p.TipoClassificacao.CodTipoClassificacao == o.TipoClassificacao.CodTipoClassificacao && p.TipoObrigacao == 2)).ToList();

                    obrigacoesMensaisRealizadas = classificacaoEmpresaMensal.Where(o => o.DataEmpresa.Data.Month == dateTimePicker1.Value.Month
                    && o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).Count();

                    obrigacoesAnuaisRealizadas = classificacaoEmpresaAnual.Where(o => o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).Count();

                    dgDetalhamento.DataSource = ElaboraTabelaDetalhamentoObrigacoes(listaObrigacoes.Where(o => o.TipoObrigacao == tipoObrigacao).ToList(),
                        tipoObrigacao == 1 ? classificacaoEmpresaMensal.Where(o => o.DataEmpresa.Data.Month == dateTimePicker1.Value.Month
                    && o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).ToList() : classificacaoEmpresaAnual.Where(o => o.DataEmpresa.Data.Year == dateTimePicker1.Value.Year).ToList());
                    dgDetalhamento.Columns["id"].Visible = false;
                }
            }

            ConstroiCharts(new List<string> { obrigacoesMensaisRealizadas.ToString(),(totalObrigacoesMensais - obrigacoesMensaisRealizadas).ToString(),
            obrigacoesAnuaisRealizadas.ToString(),(totalObrigacoesAnuais - obrigacoesAnuaisRealizadas).ToString()});
        }

        private void ConstroiCharts(List<string> listXY)
        {
            bool realizada = false;
            chart1.Series["S1"].IsValueShownAsLabel = true;
            if (listXY[0] != "0")
            {
                chart1.Series["S1"].Points.AddXY("Realizadas", listXY[0]);
                chart1.Series["S1"].Points[0].Color = Color.Orange;
                realizada = true;
            }
            if (listXY[1] != "0")
            {
                chart1.Series["S1"].Points.AddXY("Restantes", listXY[1]);
                if (realizada)
                    chart1.Series["S1"].Points[1].Color = Color.Blue;
                else
                    chart1.Series["S1"].Points[0].Color = Color.Blue;
            }

            realizada = false;
            chart2.Series["S1"].IsValueShownAsLabel = true;
            if (listXY[2] != "0")
            {
                chart2.Series["S1"].Points.AddXY("Realizadas", listXY[2]);
                chart2.Series["S1"].Points[0].Color = Color.Orange;
                realizada = true;
            }
            if (listXY[3] != "0")
            {
                chart2.Series["S1"].Points.AddXY("Restantes", listXY[3]);
                if (realizada)
                    chart2.Series["S1"].Points[1].Color = Color.Blue;
                else
                    chart2.Series["S1"].Points[0].Color = Color.Blue;
            }
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
            cbEmpresa.Enabled = !checkBox1.Checked && listaEmpresas.Count > 0;

            CalculaObrigacoes();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculaObrigacoes();
        }
        public DataTable ElaboraTabelaDetalhamentoObrigacoes(List<ObrigacaoEmpresa> listaObrigacaoEmpresas,List<ClassificacaoEmpresa> listaClassificacaoEmpresa)
        {
            DataTable table = new DataTable("TabelaGridClasse");
            DataColumn column;
            DataRow row;
            column = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "id",
                ReadOnly = true,
                Unique = true
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Empresa",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Obrigação",
                ReadOnly = true,
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Status",
                ReadOnly = true,
            };
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            int cont = -1;

            foreach (ObrigacaoEmpresa obrigacaoEmpresa in listaObrigacaoEmpresas)
            {
                row = table.NewRow();
                row["id"] = cont++;
                row["Empresa"] = obrigacaoEmpresa.Empresa.RazaoSocial;
                row["Obrigação"] = obrigacaoEmpresa.TipoClassificacao.Descricao;
                row["Status"] = listaClassificacaoEmpresa.Exists(o => o.TipoClassificacao.CodTipoClassificacao == obrigacaoEmpresa.TipoClassificacao.CodTipoClassificacao 
                && o.DataEmpresa.Empresa.CodEmpresa == obrigacaoEmpresa.Empresa.CodEmpresa) ? "Concluído" : "Pedente";
                table.Rows.Add(row);
            }
            return table;
        }

        private void cbTipoDetalhamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculaObrigacoes();
        }
    }
}
