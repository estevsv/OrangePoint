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
    public partial class CadastroEmpresa : Form
    {
        private Usuario usuarioPagina;
        Utilities utilities = new Utilities();
        bool fechamentoSistema;

        public CadastroEmpresa(Usuario usuario)
        {
            InitializeComponent();
            usuarioPagina = usuario;
        }

        private void CadastroEmpresa_Load(object sender, EventArgs e)
        {
            fechamentoSistema = true;

            lblWelcomeUser.Text = "Usuário: " + usuarioPagina.NmeFuncionario;
            lblTipoUsuario.Text = usuarioPagina.TipoPermissao.DescPermissao;
            userImage.Image = utilities.CarregaImagemUsuario(usuarioPagina, userImage.Image);

            HabilitaPermissoes(utilities.GeraListaPermissoes(usuarioPagina));
        }

        //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
        private void HabilitaPermissoes(List<bool> listaPermissoes)
        {
            button2.Visible = listaPermissoes[0];
            button4.Visible = listaPermissoes[1];
            button5.Visible = listaPermissoes[2];
            btnPontoEletronico.Visible = listaPermissoes[4];
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
            new CadastroAuxiliar(usuarioPagina).Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            FechaPagina();
            new EmpresaView(usuarioPagina).Show();
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

        private void CadastroEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fechamentoSistema)
                Application.Exit();
        }
    }
}
