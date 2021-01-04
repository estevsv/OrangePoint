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
    public partial class ControleFolhaPonto : Form
    {
        private Usuario usuarioPagina;
        private FolhaPonto folhaAlteracao;

        
        Utilities utilities = new Utilities();
        LoginRule loginRule = new LoginRule();
        FolhaPontoRule folhaPontoRule = new FolhaPontoRule();
        bool fechamentoSistema;

        public ControleFolhaPonto(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }
        
        private void ControleFolhaPonto_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            CarregaComboBoxUsuario();
        }

        private void CarregaComboBoxUsuario()
        {
            cbUsuario.DataSource = loginRule.PesquisaTodosUsuariosTabela();
            cbUsuario.DisplayMember = "LOGIN";
            cbUsuario.ValueMember = "COD_USUARIO";
            if (cbUsuario.Items.Count != 0)
                cbUsuario.SelectedIndex = 0;
        }

        private void CarregaGridFolhaPonto(Usuario usuario, bool filtro)
        {
            DataTable retorno = new DataTable();
            if (filtro)
                retorno = folhaPontoRule.PesquisaPontoPorIdUsuarioeData(usuario, dateTimePicker1.Value.Date);
            else
                retorno = folhaPontoRule.PesquisaPontoPorIdUsuario(usuario);

            if (retorno.Rows.Count == 0)
                MessageBox.Show("Usuário sem pontos registrados");
            else
            {
                dgFolhaPonto.DataSource = retorno;
                dgFolhaPonto.Columns["COD_PONTO"].Visible = false;
                dgFolhaPonto.Columns["COD_USUARIO"].Visible = false;
                dgFolhaPonto.Columns["DATA_PONTO"].HeaderText = "Data";
                dgFolhaPonto.Columns["ENTRADA_1"].HeaderText = "Primeira Entrada";
                dgFolhaPonto.Columns["SAIDA_1"].HeaderText = "Primeira Saída";
                dgFolhaPonto.Columns["ENTRADA_2"].HeaderText = "Segunda Entrada";
                dgFolhaPonto.Columns["SAIDA_2"].HeaderText = "Segunda Saída";

                dgFolhaPonto.Columns["DATA_PONTO"].Width = 172;
                dgFolhaPonto.Columns["ENTRADA_1"].Width = 160;
                dgFolhaPonto.Columns["SAIDA_1"].Width = 160;
                dgFolhaPonto.Columns["ENTRADA_2"].Width = 160;
                dgFolhaPonto.Columns["SAIDA_2"].Width = 160;

                dgFolhaPonto.Columns["DATA_PONTO"].ReadOnly = true;
            }
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            button6.Visible = listaPermissoes[3];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
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
            new Configuracoes(usuarioPagina).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ConfiguracoesPermissoes(usuarioPagina).Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregaGridFolhaPonto(loginRule.PesquisaUsuarioPorId(int.Parse(cbUsuario.SelectedValue.ToString())), false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CarregaGridFolhaPonto(loginRule.PesquisaUsuarioPorId(int.Parse(cbUsuario.SelectedValue.ToString())), true);
        }

        private void dgFolhaPonto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            folhaAlteracao = new FolhaPonto();
            string valorCelula = dgFolhaPonto.CurrentRow.Cells[0].Value.ToString();
            if (valorCelula != "")
            {
                folhaAlteracao = folhaPontoRule.PesquisaFolhaPontoIndividual(new DateTime(), usuarioPagina, int.Parse(valorCelula));
                dateTimePicker1.Value = folhaAlteracao.DataPonto;
                PreencherCampos();// Nesse caso a data e o usuario não interfere na busca
                pnAlteracao.Visible = true;
            }
            e.Cancel = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pnAlteracao.Visible = false;
            LimpaCamposAlteracao();
        }

        private void LimpaCamposAlteracao()
        {
            txtPrimeiraEntrada.Text = "";
            txtPrimeiraSaida.Text = "";
            txtSegundaEntrada.Text = "";
            txtSegundaSaida.Text = "";
            rtObservacao.Text = "";

            cbUsuario.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker1.Value = DateTime.Today;

        }

        private void PreencherCampos()
        {
            if(folhaAlteracao.Entrada1 != "")
                txtPrimeiraEntrada.Text = folhaAlteracao.Entrada1.Substring(0, 8);
            if (folhaAlteracao.Saida1 != "")
                txtPrimeiraSaida.Text = folhaAlteracao.Saida1.Substring(0, 8);
            if (folhaAlteracao.Entrada2 != "")
                txtSegundaEntrada.Text = folhaAlteracao.Entrada2.Substring(0, 8);
            if (folhaAlteracao.Saida2 != "")
                txtSegundaSaida.Text = folhaAlteracao.Saida2.Substring(0, 8);
            rtObservacao.Text = folhaAlteracao.Observacao;
            cbUsuario.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtPrimeiraEntrada.Text.Length != 8 && txtPrimeiraSaida.Text.Length != 8 && txtSegundaEntrada.Text.Length != 8 &&
                txtSegundaSaida.Text.Length != 8)
            {
                MessageBox.Show("Edição Inválida");
                return;
            }

            if(txtPrimeiraEntrada.Text != "  :  :")
                folhaAlteracao.Entrada1 = txtPrimeiraEntrada.Text;
            if (txtPrimeiraSaida.Text != "  :  :")
                folhaAlteracao.Saida1 = txtPrimeiraSaida.Text;
            if (txtSegundaEntrada.Text != "  :  :")
                folhaAlteracao.Entrada2 = txtSegundaEntrada.Text;
            if (txtSegundaSaida.Text != "  :  :")
                folhaAlteracao.Saida2 = txtSegundaSaida.Text;
            folhaAlteracao.Usuario = loginRule.PesquisaUsuarioPorId(int.Parse(cbUsuario.SelectedValue.ToString()));

            folhaPontoRule.AtualizaPonto(folhaAlteracao);

            folhaPontoRule.RegistraObservacao(folhaAlteracao.DataPonto,folhaAlteracao.Usuario, rtObservacao.Text);

            CarregaGridFolhaPonto(folhaAlteracao.Usuario, false);

            pnAlteracao.Visible = false;
            LimpaCamposAlteracao();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
           
                if (dgFolhaPonto.Rows.Count > 0)
                {
                    try
                    {
                            XcelApp.Application.Workbooks.Add(Type.Missing);
                        int cont = 1;
                        for (int i =3; i < dgFolhaPonto.Columns.Count + 1; i++)
                        {
                            XcelApp.Cells[1, cont] = dgFolhaPonto.Columns[i - 1].HeaderText;
                            cont++;
                        }
                        //
                        for (int i = 0; i < dgFolhaPonto.Rows.Count - 1; i++)
                        {
                            cont = 2;
                            for (int j = 0; j < 6; j++)
                            {
                                XcelApp.Cells[i + 2, j + 1] = dgFolhaPonto.Rows[i].Cells[cont].Value.ToString();
                                cont++;
                            }
                        }
                        //
                        XcelApp.Columns.AutoFit();
                        //
                        XcelApp.Visible = true;
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao exportar. Contate o Suporte.");
                        return;
                    }
                } else
                    MessageBox.Show("Nenhum dado existente!");
            }
            catch { }
        }

        private void ControleFolhaPonto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }

        private void dgFolhaPonto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int idFolha = int.Parse(dgFolhaPonto.CurrentRow.Cells[0].Value.ToString());
            if (DialogResult.Yes == MessageBox.Show("Deseja deletar este dia do ponto eletrônico deste usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                Usuario usuarioFolha = folhaPontoRule.PesquisaPontoPorId(idFolha).Usuario;
                folhaPontoRule.ExcluirPorId(idFolha);
                dgFolhaPonto.Rows.RemoveAt(dgFolhaPonto.CurrentRow.Index);

                CarregaGridFolhaPonto(usuarioFolha,false);
            }
            e.Cancel = true;
        }
    }
}
