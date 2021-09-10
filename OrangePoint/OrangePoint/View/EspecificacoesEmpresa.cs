﻿using OrangePoint.BusinessRule;
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
    public partial class EspecificacoesEmpresa : Form
    {
        private Usuario usuarioPagina;
        private Empresa empresaOperacao;
        private bool aberturaPagina;

        Utilities utilities = new Utilities();
        EmpresaRule empresaRule = new EmpresaRule();
        TipoClassificacaoRule tipoClassificacaoRule = new TipoClassificacaoRule();
        DataEmpresaRule dataEmpresaRule = new DataEmpresaRule();
        ClassificacaoEmpresaRule classificacaoEmpresaRule = new ClassificacaoEmpresaRule();
        DadosWebRule dadoWebRule = new DadosWebRule();
        AtividadeRule atividadeRule = new AtividadeRule();
        AtividadeEmpresaRule atividadeEmpresaRule = new AtividadeEmpresaRule();
        ObrigacaoEmpresaRule obrigacaoEmpresaRule = new ObrigacaoEmpresaRule();

        public bool FechamentoSistema { get; set; }

        public EspecificacoesEmpresa(Usuario usuario, Empresa empresa)
        {
            InitializeComponent();

            aberturaPagina = true;
            usuarioPagina = usuario;
            empresaOperacao = empresa;
        }

        private void EspecificacoesEmpresa_Load(object sender, EventArgs e)
        {
            FechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            lblTxtEmpresaInfo.Text = "Empresa: " + empresaOperacao.RazaoSocial +"  CNPJ:" + empresaOperacao.CNPJ;
            pnCadastraAtividadeEmpresa.Visible = false;

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));
            CarregaComboBoxes();
            CarregaGrids();

            aberturaPagina = false;
        }

        #region Controle de Acesso da Página
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
            button12.Visible = listaPermissoes[0];
            button2.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new LoginView().Show();
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

        private void button12_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new CadastroAuxiliar(usuarioPagina).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }
        #endregion

        #region Carregamento de ComboBox
        private void CarregaComboBoxes()
        {
            CarregaComboBoxClassificacao();
            CarregaComboBoxAtividadeEmpresa();
            CarregaComboBoxObrigacoesEmpresa();
        }

        private void CarregaComboBoxClassificacao()
        {
            List<ObrigacaoEmpresa> listaObrigacaoEmp = obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList();

            cbClassificacao.DataSource = obrigacaoEmpresaRule.ElaboraTabelaObrigacaoEmpresa(listaObrigacaoEmp);
            cbClassificacao.DisplayMember = "NomeCompleto";
            cbClassificacao.ValueMember = "id";
        }

        private void CarregaComboBoxAtividadeEmpresa()
        {
            cbAtividade.DataSource = atividadeRule.PesquisaAtividadeTabela();
            cbAtividade.DisplayMember = "DESCRICAO";
            cbAtividade.ValueMember = "COD_ATIVIDADE";
        }

        private void CarregaComboBoxObrigacoesEmpresa()
        {
            cbObrigacao.DataSource = tipoClassificacaoRule.PesquisaTipoClassificacaoTabela();
            cbObrigacao.DisplayMember = "DESCRICAO";
            cbObrigacao.ValueMember = "COD_TIPO_CLASSIFICACAO";
        }
        #endregion

        private void CarregaGrids()
        {
            CarregaGridControleFC();
            CarregaGridDadosWeb();
            CarregaGridAtividade();
            CarregaObrigacoes();
        }

        private void CarregaGridControleFC()
        {
            dgControleFC.DataSource = classificacaoEmpresaRule.ElaboraTabelaClassificacaoEmpresa(classificacaoEmpresaRule.listaClassificacaoEmpresa()
                .Where(o => o.DataEmpresa.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList());
            dgControleFC.Columns["id"].Visible = false;

            dgControleFC.Columns["Tipo Classificacao"].Width = 160;
            dgControleFC.Columns["Data"].Width = 140;

            dgControleFC.Columns["Tipo Classificacao"].ReadOnly = true;
            dgControleFC.Columns["Data"].ReadOnly = true;
        }


        private void btnControleFC_Click(object sender, EventArgs e)
        {
            ObrigacaoEmpresa obrigacao = obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.CodObrigacaoEmpresa == int.Parse(cbClassificacao.SelectedValue.ToString())).First();

            DateTime result = new DateTime();
            DateTime.TryParse(txtData.Text, out result);
            
            

            if (cbClassificacao.SelectedValue != null && txtData.Text != "")
            {
                if (result != DateTime.MinValue)
                {
                    if (result.Date < obrigacao.DataInicio || result.Date > obrigacao.DataFim)
                    {
                        MessageBox.Show("Data fora do período de vigência!");
                        return;
                    }

                }

                dataEmpresaRule.IncluirDataEmpresa(empresaOperacao.CodEmpresa, txtData.Text);
                int codData = int.Parse(dataEmpresaRule.listaDataEmpresa(empresaOperacao.CodEmpresa, txtData.Text).First().CodData.ToString()) ;

                if(!classificacaoEmpresaRule.listaClassificacaoEmpresa().Exists(o => o.TipoClassificacao.CodTipoClassificacao == obrigacao.TipoClassificacao.CodTipoClassificacao && o.DataEmpresa.CodData == codData))
                {
                    classificacaoEmpresaRule.IncluirClassificacaoEmpresa(obrigacao.TipoClassificacao.CodTipoClassificacao, codData);
                    CarregaGridControleFC();
                    MessageBox.Show("Obrigação cadastrada");
                } else
                    MessageBox.Show("Obrigação já cadastrada");

            }
            else
                MessageBox.Show("Campos inválidos");
        }

        private void dgControleFC_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            classificacaoEmpresaRule.ExcluiClassificacaoEmpresa(int.Parse(dgControleFC.CurrentRow.Cells[0].Value.ToString()));
            dgControleFC.Rows.RemoveAt(dgControleFC.CurrentRow.Index);
            CarregaGridControleFC();
            e.Cancel = true;
        }

        private void CarregaGridDadosWeb()
        {
            dataGridView1.DataSource = dadoWebRule.FiltraPesquisaDadoWebTabela(empresaOperacao.CodEmpresa);

            dataGridView1.Columns["id"].Visible = false;

            dataGridView1.Columns["Usuário"].Width = 100;
            dataGridView1.Columns["Senha"].Width = 100;
            dataGridView1.Columns["Descrição"].Width = 100;

            dataGridView1.Columns["Usuário"].ReadOnly = true;
            dataGridView1.Columns["Senha"].ReadOnly = true;
            dataGridView1.Columns["Descrição"].ReadOnly = true;
        }

        private void btnCadastrarDadosWeb_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                dadoWebRule.IncluirDadosWebEmpresa(empresaOperacao.CodEmpresa, textBox1.Text, textBox2.Text, textBox3.Text);
                CarregaGridDadosWeb();
            }
            else
                MessageBox.Show("Campos Inválidos!");

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            dadoWebRule.ExcluiDadosWebEmpresa(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            CarregaGridDadosWeb();
            e.Cancel = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "Detalhes Adicionais da Empresa")
            {
                pnCadastraAtividadeEmpresa.Visible = true;
                button8.Visible = false;
                button10.Text = "Dados Gerais da Empresa";
            }
            else
            {
                pnCadastraAtividadeEmpresa.Visible = false;
                button8.Visible = true;
                button10.Text = "Detalhes Adicionais da Empresa";
            }
        }

        private void CarregaGridAtividade()
        {
            List<AtividadeEmpresa> listaAtvEmp = atividadeEmpresaRule.listaAtividadeEmpresas().Where(o => o.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList();

            dgAtividadeEmpresa.DataSource = atividadeEmpresaRule.ElaboraTabelaAtividadeEmpresa(listaAtvEmp);
            dgAtividadeEmpresa.Columns["id"].Visible = false;
            dgAtividadeEmpresa.Columns["Atividade"].Width = 300;
            dgAtividadeEmpresa.Columns["Atividade"].ReadOnly = true;
        }

        private void CarregaObrigacoes()
        {
            List<ObrigacaoEmpresa> listaObrigacaoEmp = obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList();

            dgObrigacao.DataSource = obrigacaoEmpresaRule.ElaboraTabelaObrigacaoEmpresa(listaObrigacaoEmp);
            dgObrigacao.Columns["id"].Visible = false;
            dgObrigacao.Columns["idTipoObrigação"].Visible = false;
            dgObrigacao.Columns["Obrigação"].Width = 85;
            dgObrigacao.Columns["Obrigação"].ReadOnly = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!atividadeEmpresaRule.listaAtividadeEmpresas().Where(o => o.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList().Exists(o => o.Atividade.CodAtividade == int.Parse(cbAtividade.SelectedValue.ToString())))
            {
                atividadeEmpresaRule.IncluirAtividadeEmpresa(int.Parse(cbAtividade.SelectedValue.ToString()), empresaOperacao.CodEmpresa);
                CarregaGridAtividade();
            }
            else
                MessageBox.Show("Atividade já alocada para esta empresa!");
        }

        private void dgAtividadeEmpresa_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            atividadeEmpresaRule.ExcluiAtividadeEmpresa(int.Parse(dgAtividadeEmpresa.CurrentRow.Cells[0].Value.ToString()));
            dgAtividadeEmpresa.Rows.RemoveAt(dgAtividadeEmpresa.CurrentRow.Index);
            CarregaGridAtividade();
            e.Cancel = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(cbObrigacoes.Text == "")
            {
                MessageBox.Show("Favor selecionar o tipo");
                return;
            }

            DateTime dataInicio = dateTimePicker1.Value; dataInicio = new DateTime(dataInicio.Year, dataInicio.Month, DateTime.DaysInMonth(dataInicio.Year,dataInicio.Month));
            DateTime dataFim = dateTimePicker2.Value; dataFim = new DateTime(dataFim.Year, dataFim.Month, DateTime.DaysInMonth(dataFim.Year, dataFim.Month));


            if (!obrigacaoEmpresaRule.listaObrigacaoEmpresas().Where(o => o.Empresa.CodEmpresa == empresaOperacao.CodEmpresa).ToList()
                .Exists(o => o.TipoClassificacao.CodTipoClassificacao == int.Parse(cbObrigacao.SelectedValue.ToString())
                && utilities.ConjugaMesAno(o.DataInicio) == utilities.ConjugaMesAno(dataInicio) && utilities.ConjugaMesAno(o.DataFim) == utilities.ConjugaMesAno(dataFim)))
            {
                obrigacaoEmpresaRule.IncluirObrigacaoEmpresa(int.Parse(cbObrigacao.SelectedValue.ToString()), empresaOperacao.CodEmpresa, cbObrigacoes.Text == "Mensal" ? 1 : 2, dataInicio, dataFim);
                CarregaObrigacoes();
                CarregaComboBoxClassificacao();
            }
            else
                MessageBox.Show("Obrigação já alocada para esta data (mês e ano) nesta empresa!");
        }

        private void dgObrigacao_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            obrigacaoEmpresaRule.ExcluiObrigacaoEmpresa(int.Parse(dgObrigacao.CurrentRow.Cells[0].Value.ToString()));
            dgObrigacao.Rows.RemoveAt(dgObrigacao.CurrentRow.Index);
            CarregaObrigacoes();
            CarregaComboBoxClassificacao();
            e.Cancel = true;
        }
    }
}