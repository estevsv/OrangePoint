namespace OrangePoint
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LIMPAR = new System.Windows.Forms.Button();
            this.Entrar = new System.Windows.Forms.Button();
            this.Tbsenha = new System.Windows.Forms.TextBox();
            this.Tbusuario = new System.Windows.Forms.TextBox();
            this.Senha = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LIMPAR
            // 
            this.LIMPAR.Location = new System.Drawing.Point(311, 179);
            this.LIMPAR.Margin = new System.Windows.Forms.Padding(2);
            this.LIMPAR.Name = "LIMPAR";
            this.LIMPAR.Size = new System.Drawing.Size(68, 31);
            this.LIMPAR.TabIndex = 9;
            this.LIMPAR.Text = "LIMPAR";
            this.LIMPAR.UseVisualStyleBackColor = true;
            // 
            // Entrar
            // 
            this.Entrar.Location = new System.Drawing.Point(71, 179);
            this.Entrar.Margin = new System.Windows.Forms.Padding(2);
            this.Entrar.Name = "Entrar";
            this.Entrar.Size = new System.Drawing.Size(68, 32);
            this.Entrar.TabIndex = 8;
            this.Entrar.Text = "ENTRAR";
            this.Entrar.UseVisualStyleBackColor = true;
            // 
            // Tbsenha
            // 
            this.Tbsenha.Location = new System.Drawing.Point(126, 113);
            this.Tbsenha.Margin = new System.Windows.Forms.Padding(2);
            this.Tbsenha.Name = "Tbsenha";
            this.Tbsenha.PasswordChar = '*';
            this.Tbsenha.Size = new System.Drawing.Size(254, 20);
            this.Tbsenha.TabIndex = 6;
            // 
            // Tbusuario
            // 
            this.Tbusuario.Location = new System.Drawing.Point(126, 37);
            this.Tbusuario.Margin = new System.Windows.Forms.Padding(2);
            this.Tbusuario.Name = "Tbusuario";
            this.Tbusuario.Size = new System.Drawing.Size(254, 20);
            this.Tbusuario.TabIndex = 4;
            // 
            // Senha
            // 
            this.Senha.AutoSize = true;
            this.Senha.Location = new System.Drawing.Point(42, 113);
            this.Senha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Senha.Name = "Senha";
            this.Senha.Size = new System.Drawing.Size(44, 13);
            this.Senha.TabIndex = 7;
            this.Senha.Text = "SENHA";
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Location = new System.Drawing.Point(42, 37);
            this.Usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(56, 13);
            this.Usuario.TabIndex = 5;
            this.Usuario.Text = "USUÁRIO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 236);
            this.Controls.Add(this.LIMPAR);
            this.Controls.Add(this.Entrar);
            this.Controls.Add(this.Tbsenha);
            this.Controls.Add(this.Tbusuario);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Usuario);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LIMPAR;
        private System.Windows.Forms.Button Entrar;
        private System.Windows.Forms.TextBox Tbsenha;
        private System.Windows.Forms.TextBox Tbusuario;
        private System.Windows.Forms.Label Senha;
        private System.Windows.Forms.Label Usuario;
    }
}

