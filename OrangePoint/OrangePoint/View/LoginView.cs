using OrangePoint.BusinessRule;
using OrangePoint.Model;
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
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        LoginRule loginRule = new LoginRule();
        private void Entrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = loginRule.PesquisaUsuario(Tbusuario.Text, Tbsenha.Text);
            if (usuario != null)
            {
                this.Visible = false;
                new Dashboard().Show();
            }
            else
                MessageBox.Show("Usuario e/ou Senha Incorreta");

        }
    }
}
