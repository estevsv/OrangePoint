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
            CarregarComboBoxSubtipoValor();
            CarregaGridValorEmpresa();

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

        private void CarregaGridValorEmpresa()
        {
            if (idEmpresaSelecionada == 0)
                return;
            List<Valor> listaValor = valorRule.listaValor();

            dgValor.DataSource = valorRule.ElaboraTabelaValor(listaValor.Where(o => o.DataEmpresa.Empresa.CodEmpresa == idEmpresaSelecionada).ToList());

            dgValor.Columns["id"].Visible = false;

            dgValor.Columns["Data"].Width = 250;
            dgValor.Columns["Valor"].Width = 165;
            dgValor.Columns["Subtipo"].Width = 200;

            dgValor.Columns["Data"].ReadOnly = true;
            dgValor.Columns["Valor"].ReadOnly = true;
            dgValor.Columns["Subtipo"].ReadOnly = true;
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
            {
                idEmpresaSelecionada = int.Parse(cbEmpresa.SelectedValue.ToString());
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
                CarregaComboBoxEmpresa();

            CarregaGridValorEmpresa();
        }

        private void CarregarComboBoxSubtipoValor()
        {
            cbSubtipoValor.DataSource = subtipoValorRule.FiltraPesquisaSubtipoValorTabela();
            cbSubtipoValor.DisplayMember = "SubtipoValor";
            cbSubtipoValor.ValueMember = "id";
        }

        private void btnCadastrarValor_Click(object sender, EventArgs e)
        {
            decimal number;
            if (cbData.SelectedIndex != -1 && cbEmpresa.SelectedIndex != -1 && cbSubtipoValor.SelectedIndex != -1 && txtValor.Text != "             ," && decimal.TryParse(txtValor.Text,out number))
            {
                Valor valor = new Valor();
                valor.DataEmpresa = dataEmpresaRule.listaDataEmpresa().Find(o => o.CodData == int.Parse(cbData.SelectedValue.ToString()));
                valor.SubtipoValor = subtipoValorRule.listaSubtipoValor().Find(o => o.CodSubtipoValor == int.Parse(cbSubtipoValor.SelectedValue.ToString()));
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

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Moeda(ref txt);
        }

        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 && n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch
            {
                MessageBox.Show("Caractere inválido!");
                txt.Text = "";
            }
        }
    }
}
