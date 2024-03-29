﻿using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class ValoresEmpresa : Form
    {
        GeradorExcel geradorExcel = new GeradorExcel();
        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();
        DataEmpresaRule dataEmpresaRule = new DataEmpresaRule();
        SubtipoValorRule subtipoValorRule = new SubtipoValorRule();
        ValorRule valorRule = new ValorRule();
        private Usuario usuarioPagina;
        private List<Empresa> listaEmpresas;
        private bool isLoad;
        private int idEmpresaSelecionada;

        public bool FechamentoSistema { get; set; }

        public ValoresEmpresa(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;

            AplicarEventos(txtValor);
        }

        private void ValoresEmpresa_Load(object sender, EventArgs e)
        {
            idEmpresaSelecionada = 0;
            FechamentoSistema = true;
            isLoad = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            listaEmpresas = empresaRule.listaEmpresas();
            CarregaComboBox();
            CarregaGridValorEmpresa();

            if(cbEmpresa.Text != "")
                CarregarComboBoxSubtipoValor();

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
            FechamentoSistema = false;
            this.Visible = false;
            this.Close();
            userImage = new PictureBox();

        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
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
            new CadastroAuxiliarFinanceiro(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new Configuracoes(usuarioPagina).Show();
        }

        #endregion

        private void CarregaGridValorEmpresa()
        {
            if (idEmpresaSelecionada == 0)
                return;
            List<Valor> listaValor = valorRule.listaValor();

            if (cbFiltraData.Checked) {
                if (dataEmpresaRule.RetornaDataValida(cbData.Text).Item1 && cbData.Text.Length == 10) {
                    dataEmpresaRule.IncluirDataEmpresa(idEmpresaSelecionada, cbData.Text);
                    int codData = int.Parse(dataEmpresaRule.listaDataEmpresa(idEmpresaSelecionada, cbData.Text).First().CodData.ToString());
                    listaValor = listaValor.Where(o => o.DataEmpresa.CodData == codData).ToList();
                }
                else
                    listaValor = new List<Valor>();
            }

            if (cbFiltraSubtipo.Checked) {
                listaValor = listaValor.Where(o => o.SubtipoValor.CodSubtipoValor == int.Parse(cbSubtipoValor.SelectedValue.ToString())).ToList();
            }

            if (cbFiltraValor.Checked) 
            {
                if (txtValor.Text != "")
                {
                    string valor = txtValor.Text;
                    valor = valor.Replace("R$", "").Trim();
                    valor = valor.Replace(" ", "").Trim();
                    valor = decimal.Parse(valor).ToString();
                    listaValor = listaValor.Where(o => o.NumValor.ToString() == valor).ToList();
                }else
                    listaValor = new List<Valor>();
            }

            dgValor.DataSource = valorRule.ElaboraTabelaValor(listaValor.Where(o => o.DataEmpresa.Empresa.CodEmpresa == idEmpresaSelecionada).ToList());

            dgValor.Columns["id"].Visible = false;

            dgValor.Columns["Data"].Width = 250;
            dgValor.Columns["Valor"].Width = 165;
            dgValor.Columns["Conta Analítica"].Width = 200;

            dgValor.Columns["Data"].ReadOnly = true;
            dgValor.Columns["Valor"].ReadOnly = true;
            dgValor.Columns["Conta Analítica"].ReadOnly = true;
        }

        private void CarregaComboBox(string razaoSocial = "")
        {
            List<Empresa> filtroLista = razaoSocial == "" ? listaEmpresas : listaEmpresas.FindAll(o => o.RazaoSocial.Substring(0, 1) == razaoSocial).OrderBy(o => o.RazaoSocial).ToList();
            if (listaEmpresas.Count != 0)
            {
                cbEmpresa.DataSource = empresaRule.ElaboraTabelaEmpresa(filtroLista);
                cbEmpresa.DisplayMember = "Razão Social";
                cbEmpresa.ValueMember = "id";
                CarregaComboBoxEmpresa();
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

        private void CarregaComboBoxEmpresa()
        {
            if (cbEmpresa.SelectedValue != null)
                idEmpresaSelecionada = int.Parse(cbEmpresa.SelectedValue.ToString());
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedIndex != -1 && !isLoad)
                CarregaComboBoxEmpresa();

            CarregaGridValorEmpresa();

            if (idEmpresaSelecionada != 0)
                CarregarComboBoxSubtipoValor();
        }

        private void CarregarComboBoxSubtipoValor()
        {
            cbSubtipoValor.DataSource = subtipoValorRule.FiltraPesquisaSubtipoValorTabela(subtipoValorRule.ListaSubtiposPorEmpresa(empresaRule.PesquisaEmpresaPorId(int.Parse(cbEmpresa.SelectedValue.ToString()))).OrderBy(o => o.DescSubtipo).ToList());
            cbSubtipoValor.DisplayMember = "SubtipoValor";
            cbSubtipoValor.ValueMember = "id";
        }

        private void btnCadastrarValor_Click(object sender, EventArgs e)
        {
            decimal number;
            Tuple<bool, DateTime> retornaDataValida = dataEmpresaRule.RetornaDataValida(cbData.Text);
            txtValor.Text = txtValor.Text.Replace("R$", "").Trim();
            txtValor.Text = txtValor.Text.Replace(" ", "").Trim();
            if (cbData.Text != "" && retornaDataValida.Item1 && cbEmpresa.SelectedIndex != -1 && cbSubtipoValor.SelectedIndex != -1 && txtValor.Text != "             ," && decimal.TryParse(txtValor.Text,out number))
            {
                Valor valor = new Valor();

                dataEmpresaRule.IncluirDataEmpresa(idEmpresaSelecionada, cbData.Text);
                int codData = int.Parse(dataEmpresaRule.listaDataEmpresa(idEmpresaSelecionada, cbData.Text).First().CodData.ToString());

                valor.DataEmpresa = dataEmpresaRule.listaDataEmpresa().Find(o => o.CodData == codData);
                valor.SubtipoValor = subtipoValorRule.ListaSubtipoValor().Find(o => o.CodSubtipoValor == int.Parse(cbSubtipoValor.SelectedValue.ToString()));
                valor.NumValor = decimal.Parse(txtValor.Text);

                valorRule.IncluirValor(valor.DataEmpresa.CodData, valor.SubtipoValor.CodSubtipoValor, valor.NumValor.ToString());
                CarregaGridValorEmpresa();
            }
            else
                MessageBox.Show("Campos Inválidos");
        }

        private void dgValor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int idValor = int.Parse(dgValor.CurrentRow.Cells[0].Value.ToString());
            if (DialogResult.Yes == MessageBox.Show("Deseja deletar este Valor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                valorRule.ExcluiValor(idValor);
                dgValor.Rows.RemoveAt(dgValor.CurrentRow.Index);

                CarregaGridValorEmpresa();
            }
            e.Cancel = true;
        }

        private void RetornarMascara(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                TextBox txt = (TextBox)sender;
                txt.Text = double.Parse(txt.Text).ToString("C2");
            }
        }

        private void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else if (txt.Text.Length == 0 && e.KeyChar == '-') {
                    e.Handled = (txt.Text.Contains('-'));
                }
                else
                    e.Handled = true;
            }
        }
        private void AplicarEventos(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            txt.KeyPress += ApenasValorNumerico;
        }

        private void cbFiltraData_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGridValorEmpresa();
        }

        private void cbFiltraSubtipo_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGridValorEmpresa();
        }

        private void cbFiltraValor_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGridValorEmpresa();
        }

        private void cbData_TextChanged(object sender, EventArgs e)
        {
            CarregaGridValorEmpresa();
        }

        private void cbSubtipoValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGridValorEmpresa();

            if (idEmpresaSelecionada != 0)
            {
                SubtipoValor subtipoValor = subtipoValorRule.PesquisaSubtipoValorPorId(isLoad? subtipoValorRule.ListaSubtiposPorEmpresa(empresaRule.PesquisaEmpresaPorId(int.Parse(cbEmpresa.SelectedValue.ToString()))).OrderBy(o => o.DescSubtipo).ToList().First().CodSubtipoValor 
                    : int.Parse(cbSubtipoValor.SelectedValue.ToString()));
                if (subtipoValor.TipoValor != null)
                    txtTipoValor.Text = subtipoValor.TipoValor.DescTipo;
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            CarregaGridValorEmpresa();
        }

        private void btnGeraConsultoriaContabil_Click(object sender, EventArgs e)
        {
            if (idEmpresaSelecionada != 0)
                if (dataEmpresaRule.RetornaDataValida(cbData.Text).Item1)
                {
                    DateTime data = dataEmpresaRule.RetornaDataValida(cbData.Text).Item2;
                    geradorExcel.GeraExcelConsultoriaContabil(idEmpresaSelecionada, new List<DateTime> { data, data.AddMonths(3), data.AddMonths(6) });
                }
                else
                    MessageBox.Show("Data Inválida");
            else
                MessageBox.Show("Selecione uma Empresa");
        }
    }
}
