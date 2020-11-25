namespace OrangePoint.View
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.Entrar = new System.Windows.Forms.Button();
            this.Tbsenha = new System.Windows.Forms.TextBox();
            this.Tbusuario = new System.Windows.Forms.TextBox();
            this.Senha = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Entrar
            // 
            this.Entrar.BackColor = System.Drawing.Color.Transparent;
            this.Entrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Entrar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Entrar.ForeColor = System.Drawing.SystemColors.Control;
            this.Entrar.Location = new System.Drawing.Point(212, 188);
            this.Entrar.Margin = new System.Windows.Forms.Padding(2);
            this.Entrar.Name = "Entrar";
            this.Entrar.Size = new System.Drawing.Size(86, 32);
            this.Entrar.TabIndex = 14;
            this.Entrar.Text = "ENTRAR";
            this.Entrar.UseVisualStyleBackColor = false;
            this.Entrar.Click += new System.EventHandler(this.Entrar_Click);
            // 
            // Tbsenha
            // 
            this.Tbsenha.Location = new System.Drawing.Point(161, 137);
            this.Tbsenha.Margin = new System.Windows.Forms.Padding(2);
            this.Tbsenha.Name = "Tbsenha";
            this.Tbsenha.PasswordChar = '*';
            this.Tbsenha.Size = new System.Drawing.Size(254, 20);
            this.Tbsenha.TabIndex = 12;
            this.Tbsenha.Text = "123";
            // 
            // Tbusuario
            // 
            this.Tbusuario.Location = new System.Drawing.Point(161, 61);
            this.Tbusuario.Margin = new System.Windows.Forms.Padding(2);
            this.Tbusuario.Name = "Tbusuario";
            this.Tbusuario.Size = new System.Drawing.Size(254, 20);
            this.Tbusuario.TabIndex = 10;
            this.Tbusuario.Text = "admin";
            // 
            // Senha
            // 
            this.Senha.AutoSize = true;
            this.Senha.BackColor = System.Drawing.Color.Transparent;
            this.Senha.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Senha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Senha.Location = new System.Drawing.Point(77, 137);
            this.Senha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Senha.Name = "Senha";
            this.Senha.Size = new System.Drawing.Size(54, 20);
            this.Senha.TabIndex = 13;
            this.Senha.Text = "SENHA";
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.BackColor = System.Drawing.Color.Transparent;
            this.Usuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Usuario.Location = new System.Drawing.Point(77, 61);
            this.Usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(67, 20);
            this.Usuario.TabIndex = 11;
            this.Usuario.Text = "USUÁRIO";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OrangePoint.Properties.Resources.Background_Padrão;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(491, 280);
            this.Controls.Add(this.Entrar);
            this.Controls.Add(this.Tbsenha);
            this.Controls.Add(this.Tbusuario);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orange Point";
            this.Load += new System.EventHandler(this.LoginView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Entrar;
        private System.Windows.Forms.TextBox Tbsenha;
        private System.Windows.Forms.TextBox Tbusuario;
        private System.Windows.Forms.Label Senha;
        private System.Windows.Forms.Label Usuario;
    }
}