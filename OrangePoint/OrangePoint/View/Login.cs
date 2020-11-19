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

namespace OrangePoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        LoginRule loginRule = new LoginRule();
        private void Entrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = loginRule.PesquisaUsuario(Tbusuario.Text, Tbsenha.Text);
            if (usuario != null)
                MessageBox.Show("usuario existe");
            else
                MessageBox.Show("usuario não existe");

        }
    }
}
