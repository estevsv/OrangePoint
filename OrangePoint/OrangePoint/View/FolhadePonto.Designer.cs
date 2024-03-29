﻿namespace OrangePoint.View
{
    partial class FolhadePonto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolhadePonto));
            this.panel2 = new System.Windows.Forms.Panel();
            this.userImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.dgPontoUsuario = new System.Windows.Forms.DataGridView();
            this.btnRegistrarPonto = new System.Windows.Forms.Button();
            this.tmDataHora = new System.Windows.Forms.Timer(this.components);
            this.lblDataHora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtObservacao = new System.Windows.Forms.RichTextBox();
            this.registrarObservacao = new System.Windows.Forms.Button();
            this.dateTimePickerObs = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPontoUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.userImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(211, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 69);
            this.panel2.TabIndex = 5;
            // 
            // userImage
            // 
            this.userImage.BackColor = System.Drawing.Color.Transparent;
            this.userImage.Image = ((System.Drawing.Image)(resources.GetObject("userImage.Image")));
            this.userImage.Location = new System.Drawing.Point(808, 12);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(54, 50);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userImage.TabIndex = 0;
            this.userImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblTipoUsuario);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.lblWelcomeUser);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 621);
            this.panel1.TabIndex = 4;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button8.AutoSize = true;
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(0, 321);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(211, 68);
            this.button8.TabIndex = 19;
            this.button8.Text = "Financeiro";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button5.AutoSize = true;
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(0, 247);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(211, 68);
            this.button5.TabIndex = 18;
            this.button5.Text = "Apuração de Lucro Real";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 68);
            this.button2.TabIndex = 16;
            this.button2.Text = "Empresas";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoUsuario.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoUsuario.Location = new System.Drawing.Point(12, 39);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(99, 23);
            this.lblTipoUsuario.TabIndex = 7;
            this.lblTipoUsuario.Text = "Tipo Usuário";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 550);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 71);
            this.button3.TabIndex = 3;
            this.button3.Text = "Configurações";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeUser.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUser.Location = new System.Drawing.Point(12, 9);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(41, 23);
            this.lblWelcomeUser.TabIndex = 2;
            this.lblWelcomeUser.Text = "Text";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDashboard.AutoSize = true;
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDashboard.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(0, 75);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(211, 68);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.AutoSize = true;
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(939, 567);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(134, 42);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // dgPontoUsuario
            // 
            this.dgPontoUsuario.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgPontoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPontoUsuario.Location = new System.Drawing.Point(217, 202);
            this.dgPontoUsuario.MultiSelect = false;
            this.dgPontoUsuario.Name = "dgPontoUsuario";
            this.dgPontoUsuario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgPontoUsuario.Size = new System.Drawing.Size(856, 242);
            this.dgPontoUsuario.TabIndex = 6;
            // 
            // btnRegistrarPonto
            // 
            this.btnRegistrarPonto.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistrarPonto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarPonto.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPonto.Location = new System.Drawing.Point(563, 159);
            this.btnRegistrarPonto.Name = "btnRegistrarPonto";
            this.btnRegistrarPonto.Size = new System.Drawing.Size(125, 35);
            this.btnRegistrarPonto.TabIndex = 7;
            this.btnRegistrarPonto.Text = "Registrar Ponto";
            this.btnRegistrarPonto.UseVisualStyleBackColor = false;
            this.btnRegistrarPonto.Click += new System.EventHandler(this.btnRegistrarPonto_Click);
            // 
            // tmDataHora
            // 
            this.tmDataHora.Tick += new System.EventHandler(this.tmDataHora_Tick);
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.BackColor = System.Drawing.Color.Transparent;
            this.lblDataHora.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataHora.ForeColor = System.Drawing.Color.White;
            this.lblDataHora.Location = new System.Drawing.Point(467, 123);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(45, 20);
            this.lblDataHora.TabIndex = 8;
            this.lblDataHora.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(217, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Observação";
            // 
            // rtObservacao
            // 
            this.rtObservacao.Location = new System.Drawing.Point(318, 475);
            this.rtObservacao.MaxLength = 9999;
            this.rtObservacao.Name = "rtObservacao";
            this.rtObservacao.Size = new System.Drawing.Size(418, 59);
            this.rtObservacao.TabIndex = 10;
            this.rtObservacao.Text = "";
            // 
            // registrarObservacao
            // 
            this.registrarObservacao.BackColor = System.Drawing.Color.Transparent;
            this.registrarObservacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.registrarObservacao.ForeColor = System.Drawing.Color.White;
            this.registrarObservacao.Location = new System.Drawing.Point(861, 508);
            this.registrarObservacao.Name = "registrarObservacao";
            this.registrarObservacao.Size = new System.Drawing.Size(125, 26);
            this.registrarObservacao.TabIndex = 11;
            this.registrarObservacao.Text = "Registrar Observação ";
            this.registrarObservacao.UseVisualStyleBackColor = false;
            this.registrarObservacao.Click += new System.EventHandler(this.registrarObservacao_Click);
            // 
            // dateTimePickerObs
            // 
            this.dateTimePickerObs.Location = new System.Drawing.Point(774, 472);
            this.dateTimePickerObs.Name = "dateTimePickerObs";
            this.dateTimePickerObs.Size = new System.Drawing.Size(299, 20);
            this.dateTimePickerObs.TabIndex = 12;
            // 
            // FolhadePonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OrangePoint.Properties.Resources.Background_Padrão;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 621);
            this.Controls.Add(this.dateTimePickerObs);
            this.Controls.Add(this.registrarObservacao);
            this.Controls.Add(this.rtObservacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.btnRegistrarPonto);
            this.Controls.Add(this.dgPontoUsuario);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSair);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FolhadePonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ponto Eletrônico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FolhadePonto_FormClosing);
            this.Load += new System.EventHandler(this.FolhadePonto_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPontoUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox userImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridView dgPontoUsuario;
        private System.Windows.Forms.Button btnRegistrarPonto;
        private System.Windows.Forms.Timer tmDataHora;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtObservacao;
        private System.Windows.Forms.Button registrarObservacao;
        private System.Windows.Forms.DateTimePicker dateTimePickerObs;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
    }
}