﻿using OrangePoint.BusinessRule;
using OrangePoint.Model;
using OrangePoint.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.View
{
    public partial class Configuracoes : Form
    {

        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        LoginRule login = new LoginRule();
        bool fechamentoSistema;
        public Configuracoes(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void Configuracoes_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;

            Tbusuario.Text = usuarioPagina.Login;
            tbSenha.Text = usuarioPagina.Senha;
            tbNomeUsuario.Text = usuarioPagina.NmeFuncionario;

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));

            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
            pictureBox1.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Selecionar Foto";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                if (DialogResult.Yes == MessageBox.Show("Será necessário reabrir a aplicação, deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    login.AtualizaFotoLogin(openFileDialog1.FileName, openFileDialog1.SafeFileName, usuarioPagina);
                    Application.Exit();
                }
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            usuarioPagina.Login = Tbusuario.Text;
            usuarioPagina.Senha = tbSenha.Text;
            usuarioPagina.NmeFuncionario = tbNomeUsuario.Text;
            usuarioPagina.FotoUsuario = usuarioPagina.FotoUsuario;

            login.AtualizaUsuario(usuarioPagina);

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new LoginView().Show();
        }

        private void btnPontoEletronico_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new FolhadePonto(usuarioPagina).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new Configuracoes(usuarioPagina).Show();
        }

        private void FechaPagina()
        {
            fechamentoSistema = false;

            this.Visible = false;
            this.Close();
            userImage = new PictureBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new ConfiguracoesPermissoes(usuarioPagina).Show();
        }

        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button8.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            button1.Visible = listaPermissoes[3];
            btnPontoEletronico.Visible = listaPermissoes[4];
            btnCtrFlhPonto.Visible = listaPermissoes[5];
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

        private void btnCtrFlhPonto_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new ControleFolhaPonto(usuarioPagina).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FechaPagina();
            pictureBox1 = new PictureBox();
            new Dashboard(usuarioPagina).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new ValoresEmpresa(usuarioPagina).Show();
        }

        private void Configuracoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }
    }
}
