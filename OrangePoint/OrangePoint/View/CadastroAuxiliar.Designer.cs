namespace OrangePoint.View
{
    partial class CadastroAuxiliar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroAuxiliar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPontoEletronico = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.userImage = new System.Windows.Forms.PictureBox();
            this.txtNovoRegime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgRegime = new System.Windows.Forms.DataGridView();
            this.AdicionarRegime = new System.Windows.Forms.Button();
            this.AdicionarGrupo = new System.Windows.Forms.Button();
            this.dgGrupo = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNovoGrupo = new System.Windows.Forms.TextBox();
            this.AdicionarAtividadeEmpresa = new System.Windows.Forms.Button();
            this.dgAtividade = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAtividade = new System.Windows.Forms.TextBox();
            this.btnAdicionaTipoDatas = new System.Windows.Forms.Button();
            this.dgTipoDatas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoDatas = new System.Windows.Forms.TextBox();
            this.btnAdicionarTipoValor = new System.Windows.Forms.Button();
            this.dgTipoValor = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoValor = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCadastrarSubtipos = new System.Windows.Forms.Button();
            this.pnCadastraSubtipos = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbAtividade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSubtipoValor = new System.Windows.Forms.ComboBox();
            this.btnAdicionaSubtipoAtividade = new System.Windows.Forms.Button();
            this.dgSubtipoAtividade = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTipoValor = new System.Windows.Forms.ComboBox();
            this.btnAdicionarSubitipoValor = new System.Windows.Forms.Button();
            this.dgSubtipoValor = new System.Windows.Forms.DataGridView();
            this.txtSubtipoValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtividade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoValor)).BeginInit();
            this.pnCadastraSubtipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubtipoAtividade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubtipoValor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.lblTipoUsuario);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.lblWelcomeUser);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnPontoEletronico);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 621);
            this.panel1.TabIndex = 6;
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button7.AutoSize = true;
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(0, 72);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(211, 68);
            this.button7.TabIndex = 9;
            this.button7.Text = "Dashboard";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoUsuario.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoUsuario.Location = new System.Drawing.Point(12, 39);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(99, 23);
            this.lblTipoUsuario.TabIndex = 8;
            this.lblTipoUsuario.Text = "Tipo Usuário";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button5.AutoSize = true;
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(0, 421);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(211, 68);
            this.button5.TabIndex = 5;
            this.button5.Text = "Apuração de Lucro Real";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 347);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(211, 68);
            this.button4.TabIndex = 4;
            this.button4.Text = "Consultoria Contábil";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.lblWelcomeUser.Location = new System.Drawing.Point(12, 12);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(86, 23);
            this.lblWelcomeUser.TabIndex = 2;
            this.lblWelcomeUser.Text = "Bem Vindo";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 68);
            this.button2.TabIndex = 1;
            this.button2.Text = "Empresas";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPontoEletronico
            // 
            this.btnPontoEletronico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPontoEletronico.AutoSize = true;
            this.btnPontoEletronico.BackColor = System.Drawing.Color.Transparent;
            this.btnPontoEletronico.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPontoEletronico.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPontoEletronico.Location = new System.Drawing.Point(0, 146);
            this.btnPontoEletronico.Name = "btnPontoEletronico";
            this.btnPontoEletronico.Size = new System.Drawing.Size(211, 68);
            this.btnPontoEletronico.TabIndex = 0;
            this.btnPontoEletronico.Text = "Ponto Eletrônico";
            this.btnPontoEletronico.UseVisualStyleBackColor = false;
            this.btnPontoEletronico.Click += new System.EventHandler(this.btnPontoEletronico_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.userImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(211, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 69);
            this.panel2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 68);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cadastro de Empresa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userImage
            // 
            this.userImage.BackColor = System.Drawing.Color.Transparent;
            this.userImage.Image = ((System.Drawing.Image)(resources.GetObject("userImage.Image")));
            this.userImage.Location = new System.Drawing.Point(811, 12);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(51, 50);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userImage.TabIndex = 0;
            this.userImage.TabStop = false;
            // 
            // txtNovoRegime
            // 
            this.txtNovoRegime.Location = new System.Drawing.Point(237, 122);
            this.txtNovoRegime.Name = "txtNovoRegime";
            this.txtNovoRegime.Size = new System.Drawing.Size(196, 20);
            this.txtNovoRegime.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(298, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Regime";
            // 
            // dgRegime
            // 
            this.dgRegime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegime.Location = new System.Drawing.Point(237, 184);
            this.dgRegime.MultiSelect = false;
            this.dgRegime.Name = "dgRegime";
            this.dgRegime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgRegime.Size = new System.Drawing.Size(196, 157);
            this.dgRegime.TabIndex = 21;
            this.dgRegime.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgRegime_UserDeletingRow);
            // 
            // AdicionarRegime
            // 
            this.AdicionarRegime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AdicionarRegime.AutoSize = true;
            this.AdicionarRegime.BackColor = System.Drawing.Color.Transparent;
            this.AdicionarRegime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdicionarRegime.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdicionarRegime.ForeColor = System.Drawing.Color.White;
            this.AdicionarRegime.Location = new System.Drawing.Point(277, 148);
            this.AdicionarRegime.Name = "AdicionarRegime";
            this.AdicionarRegime.Size = new System.Drawing.Size(113, 30);
            this.AdicionarRegime.TabIndex = 22;
            this.AdicionarRegime.Text = "Adicionar";
            this.AdicionarRegime.UseVisualStyleBackColor = false;
            this.AdicionarRegime.Click += new System.EventHandler(this.AdicionarRegime_Click);
            // 
            // AdicionarGrupo
            // 
            this.AdicionarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AdicionarGrupo.AutoSize = true;
            this.AdicionarGrupo.BackColor = System.Drawing.Color.Transparent;
            this.AdicionarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdicionarGrupo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdicionarGrupo.ForeColor = System.Drawing.Color.White;
            this.AdicionarGrupo.Location = new System.Drawing.Point(591, 148);
            this.AdicionarGrupo.Name = "AdicionarGrupo";
            this.AdicionarGrupo.Size = new System.Drawing.Size(113, 30);
            this.AdicionarGrupo.TabIndex = 26;
            this.AdicionarGrupo.Text = "Adicionar";
            this.AdicionarGrupo.UseVisualStyleBackColor = false;
            this.AdicionarGrupo.Click += new System.EventHandler(this.AdicionarGrupo_Click);
            // 
            // dgGrupo
            // 
            this.dgGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGrupo.Location = new System.Drawing.Point(551, 184);
            this.dgGrupo.MultiSelect = false;
            this.dgGrupo.Name = "dgGrupo";
            this.dgGrupo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgGrupo.Size = new System.Drawing.Size(196, 157);
            this.dgGrupo.TabIndex = 25;
            this.dgGrupo.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgGrupo_UserDeletingRow);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(614, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Grupo";
            // 
            // txtNovoGrupo
            // 
            this.txtNovoGrupo.Location = new System.Drawing.Point(551, 122);
            this.txtNovoGrupo.Name = "txtNovoGrupo";
            this.txtNovoGrupo.Size = new System.Drawing.Size(196, 20);
            this.txtNovoGrupo.TabIndex = 23;
            // 
            // AdicionarAtividadeEmpresa
            // 
            this.AdicionarAtividadeEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AdicionarAtividadeEmpresa.AutoSize = true;
            this.AdicionarAtividadeEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.AdicionarAtividadeEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdicionarAtividadeEmpresa.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdicionarAtividadeEmpresa.ForeColor = System.Drawing.Color.White;
            this.AdicionarAtividadeEmpresa.Location = new System.Drawing.Point(903, 148);
            this.AdicionarAtividadeEmpresa.Name = "AdicionarAtividadeEmpresa";
            this.AdicionarAtividadeEmpresa.Size = new System.Drawing.Size(113, 30);
            this.AdicionarAtividadeEmpresa.TabIndex = 30;
            this.AdicionarAtividadeEmpresa.Text = "Adicionar";
            this.AdicionarAtividadeEmpresa.UseVisualStyleBackColor = false;
            this.AdicionarAtividadeEmpresa.Click += new System.EventHandler(this.AdicionarAtividadeEmpresa_Click);
            // 
            // dgAtividade
            // 
            this.dgAtividade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAtividade.Location = new System.Drawing.Point(863, 184);
            this.dgAtividade.MultiSelect = false;
            this.dgAtividade.Name = "dgAtividade";
            this.dgAtividade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgAtividade.Size = new System.Drawing.Size(196, 157);
            this.dgAtividade.TabIndex = 29;
            this.dgAtividade.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgAtividade_UserDeletingRow);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(924, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Atividade";
            // 
            // txtAtividade
            // 
            this.txtAtividade.Location = new System.Drawing.Point(863, 122);
            this.txtAtividade.Name = "txtAtividade";
            this.txtAtividade.Size = new System.Drawing.Size(196, 20);
            this.txtAtividade.TabIndex = 27;
            // 
            // btnAdicionaTipoDatas
            // 
            this.btnAdicionaTipoDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionaTipoDatas.AutoSize = true;
            this.btnAdicionaTipoDatas.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionaTipoDatas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionaTipoDatas.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionaTipoDatas.ForeColor = System.Drawing.Color.White;
            this.btnAdicionaTipoDatas.Location = new System.Drawing.Point(277, 416);
            this.btnAdicionaTipoDatas.Name = "btnAdicionaTipoDatas";
            this.btnAdicionaTipoDatas.Size = new System.Drawing.Size(113, 30);
            this.btnAdicionaTipoDatas.TabIndex = 34;
            this.btnAdicionaTipoDatas.Text = "Adicionar";
            this.btnAdicionaTipoDatas.UseVisualStyleBackColor = false;
            this.btnAdicionaTipoDatas.Click += new System.EventHandler(this.btnAdicionaTipoDatas_Click);
            // 
            // dgTipoDatas
            // 
            this.dgTipoDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTipoDatas.Location = new System.Drawing.Point(237, 452);
            this.dgTipoDatas.MultiSelect = false;
            this.dgTipoDatas.Name = "dgTipoDatas";
            this.dgTipoDatas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTipoDatas.Size = new System.Drawing.Size(196, 157);
            this.dgTipoDatas.TabIndex = 33;
            this.dgTipoDatas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgTipoDatas_UserDeletingRow);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(283, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tipo de Datas";
            // 
            // txtTipoDatas
            // 
            this.txtTipoDatas.Location = new System.Drawing.Point(237, 390);
            this.txtTipoDatas.Name = "txtTipoDatas";
            this.txtTipoDatas.Size = new System.Drawing.Size(196, 20);
            this.txtTipoDatas.TabIndex = 31;
            // 
            // btnAdicionarTipoValor
            // 
            this.btnAdicionarTipoValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarTipoValor.AutoSize = true;
            this.btnAdicionarTipoValor.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarTipoValor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarTipoValor.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarTipoValor.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarTipoValor.Location = new System.Drawing.Point(591, 416);
            this.btnAdicionarTipoValor.Name = "btnAdicionarTipoValor";
            this.btnAdicionarTipoValor.Size = new System.Drawing.Size(113, 30);
            this.btnAdicionarTipoValor.TabIndex = 38;
            this.btnAdicionarTipoValor.Text = "Adicionar";
            this.btnAdicionarTipoValor.UseVisualStyleBackColor = false;
            this.btnAdicionarTipoValor.Click += new System.EventHandler(this.btnAdicionarTipoValor_Click);
            // 
            // dgTipoValor
            // 
            this.dgTipoValor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTipoValor.Location = new System.Drawing.Point(551, 452);
            this.dgTipoValor.MultiSelect = false;
            this.dgTipoValor.Name = "dgTipoValor";
            this.dgTipoValor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTipoValor.Size = new System.Drawing.Size(196, 157);
            this.dgTipoValor.TabIndex = 37;
            this.dgTipoValor.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgTipoValor_UserDeletingRow);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(597, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 22);
            this.label5.TabIndex = 36;
            this.label5.Text = "Tipo de Valor";
            // 
            // txtTipoValor
            // 
            this.txtTipoValor.Location = new System.Drawing.Point(551, 390);
            this.txtTipoValor.Name = "txtTipoValor";
            this.txtTipoValor.Size = new System.Drawing.Size(196, 20);
            this.txtTipoValor.TabIndex = 35;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.AutoSize = true;
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(893, 564);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(134, 42);
            this.btnSair.TabIndex = 41;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCadastrarSubtipos
            // 
            this.btnCadastrarSubtipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrarSubtipos.AutoSize = true;
            this.btnCadastrarSubtipos.BackColor = System.Drawing.Color.Transparent;
            this.btnCadastrarSubtipos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrarSubtipos.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarSubtipos.ForeColor = System.Drawing.Color.White;
            this.btnCadastrarSubtipos.Location = new System.Drawing.Point(863, 452);
            this.btnCadastrarSubtipos.Name = "btnCadastrarSubtipos";
            this.btnCadastrarSubtipos.Size = new System.Drawing.Size(196, 72);
            this.btnCadastrarSubtipos.TabIndex = 42;
            this.btnCadastrarSubtipos.Text = "Cadastrar Subtipos";
            this.btnCadastrarSubtipos.UseVisualStyleBackColor = false;
            this.btnCadastrarSubtipos.Click += new System.EventHandler(this.btnCadastrarSubtipos_Click);
            // 
            // pnCadastraSubtipos
            // 
            this.pnCadastraSubtipos.BackgroundImage = global::OrangePoint.Properties.Resources.Background_Padrão;
            this.pnCadastraSubtipos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnCadastraSubtipos.Controls.Add(this.btnVoltar);
            this.pnCadastraSubtipos.Controls.Add(this.label11);
            this.pnCadastraSubtipos.Controls.Add(this.label10);
            this.pnCadastraSubtipos.Controls.Add(this.cbAtividade);
            this.pnCadastraSubtipos.Controls.Add(this.label7);
            this.pnCadastraSubtipos.Controls.Add(this.cbSubtipoValor);
            this.pnCadastraSubtipos.Controls.Add(this.btnAdicionaSubtipoAtividade);
            this.pnCadastraSubtipos.Controls.Add(this.dgSubtipoAtividade);
            this.pnCadastraSubtipos.Controls.Add(this.label9);
            this.pnCadastraSubtipos.Controls.Add(this.label8);
            this.pnCadastraSubtipos.Controls.Add(this.cbTipoValor);
            this.pnCadastraSubtipos.Controls.Add(this.btnAdicionarSubitipoValor);
            this.pnCadastraSubtipos.Controls.Add(this.dgSubtipoValor);
            this.pnCadastraSubtipos.Controls.Add(this.txtSubtipoValor);
            this.pnCadastraSubtipos.Controls.Add(this.label6);
            this.pnCadastraSubtipos.Location = new System.Drawing.Point(211, 68);
            this.pnCadastraSubtipos.Name = "pnCadastraSubtipos";
            this.pnCadastraSubtipos.Size = new System.Drawing.Size(874, 553);
            this.pnCadastraSubtipos.TabIndex = 43;
            this.pnCadastraSubtipos.Visible = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoltar.AutoSize = true;
            this.btnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoltar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(368, 451);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(113, 30);
            this.btnVoltar.TabIndex = 63;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(522, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 22);
            this.label11.TabIndex = 62;
            this.label11.Text = "Cadastro de Subtipo de Atividade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(121, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 22);
            this.label10.TabIndex = 61;
            this.label10.Text = "Cadastro de Subtipo de Valor";
            // 
            // cbAtividade
            // 
            this.cbAtividade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtividade.FormattingEnabled = true;
            this.cbAtividade.Items.AddRange(new object[] {
            "Cadastros",
            "Consultoria Contábil",
            "Apuração de Lucro Real",
            "Controle de Usuários",
            "Folha de Ponto",
            "Controle de Folha de Ponto"});
            this.cbAtividade.Location = new System.Drawing.Point(609, 75);
            this.cbAtividade.Name = "cbAtividade";
            this.cbAtividade.Size = new System.Drawing.Size(196, 21);
            this.cbAtividade.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(480, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 59;
            this.label7.Text = "Subtipo de Valor";
            // 
            // cbSubtipoValor
            // 
            this.cbSubtipoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubtipoValor.FormattingEnabled = true;
            this.cbSubtipoValor.Items.AddRange(new object[] {
            "Cadastros",
            "Consultoria Contábil",
            "Apuração de Lucro Real",
            "Controle de Usuários",
            "Folha de Ponto",
            "Controle de Folha de Ponto"});
            this.cbSubtipoValor.Location = new System.Drawing.Point(609, 118);
            this.cbSubtipoValor.Name = "cbSubtipoValor";
            this.cbSubtipoValor.Size = new System.Drawing.Size(196, 21);
            this.cbSubtipoValor.TabIndex = 58;
            // 
            // btnAdicionaSubtipoAtividade
            // 
            this.btnAdicionaSubtipoAtividade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionaSubtipoAtividade.AutoSize = true;
            this.btnAdicionaSubtipoAtividade.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionaSubtipoAtividade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionaSubtipoAtividade.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionaSubtipoAtividade.ForeColor = System.Drawing.Color.White;
            this.btnAdicionaSubtipoAtividade.Location = new System.Drawing.Point(576, 152);
            this.btnAdicionaSubtipoAtividade.Name = "btnAdicionaSubtipoAtividade";
            this.btnAdicionaSubtipoAtividade.Size = new System.Drawing.Size(113, 30);
            this.btnAdicionaSubtipoAtividade.TabIndex = 57;
            this.btnAdicionaSubtipoAtividade.Text = "Adicionar";
            this.btnAdicionaSubtipoAtividade.UseVisualStyleBackColor = false;
            this.btnAdicionaSubtipoAtividade.Click += new System.EventHandler(this.btnAdicionaSubtipoAtividade_Click);
            // 
            // dgSubtipoAtividade
            // 
            this.dgSubtipoAtividade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubtipoAtividade.Location = new System.Drawing.Point(473, 195);
            this.dgSubtipoAtividade.MultiSelect = false;
            this.dgSubtipoAtividade.Name = "dgSubtipoAtividade";
            this.dgSubtipoAtividade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSubtipoAtividade.Size = new System.Drawing.Size(332, 183);
            this.dgSubtipoAtividade.TabIndex = 56;
            this.dgSubtipoAtividade.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgSubtipoAtividade_UserDeletingRow);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(480, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 22);
            this.label9.TabIndex = 55;
            this.label9.Text = "Atividade";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(55, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 22);
            this.label8.TabIndex = 53;
            this.label8.Text = "Tipo de Valor";
            // 
            // cbTipoValor
            // 
            this.cbTipoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoValor.FormattingEnabled = true;
            this.cbTipoValor.Items.AddRange(new object[] {
            "Cadastros",
            "Consultoria Contábil",
            "Apuração de Lucro Real",
            "Controle de Usuários",
            "Folha de Ponto",
            "Controle de Folha de Ponto"});
            this.cbTipoValor.Location = new System.Drawing.Point(184, 118);
            this.cbTipoValor.Name = "cbTipoValor";
            this.cbTipoValor.Size = new System.Drawing.Size(196, 21);
            this.cbTipoValor.TabIndex = 52;
            // 
            // btnAdicionarSubitipoValor
            // 
            this.btnAdicionarSubitipoValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarSubitipoValor.AutoSize = true;
            this.btnAdicionarSubitipoValor.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarSubitipoValor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarSubitipoValor.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarSubitipoValor.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarSubitipoValor.Location = new System.Drawing.Point(151, 152);
            this.btnAdicionarSubitipoValor.Name = "btnAdicionarSubitipoValor";
            this.btnAdicionarSubitipoValor.Size = new System.Drawing.Size(113, 30);
            this.btnAdicionarSubitipoValor.TabIndex = 47;
            this.btnAdicionarSubitipoValor.Text = "Adicionar";
            this.btnAdicionarSubitipoValor.UseVisualStyleBackColor = false;
            this.btnAdicionarSubitipoValor.Click += new System.EventHandler(this.btnAdicionarSubitipoValor_Click);
            // 
            // dgSubtipoValor
            // 
            this.dgSubtipoValor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubtipoValor.Location = new System.Drawing.Point(48, 195);
            this.dgSubtipoValor.MultiSelect = false;
            this.dgSubtipoValor.Name = "dgSubtipoValor";
            this.dgSubtipoValor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSubtipoValor.Size = new System.Drawing.Size(332, 183);
            this.dgSubtipoValor.TabIndex = 46;
            this.dgSubtipoValor.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgSubtipoValor_UserDeletingRow);
            // 
            // txtSubtipoValor
            // 
            this.txtSubtipoValor.Location = new System.Drawing.Point(184, 76);
            this.txtSubtipoValor.Name = "txtSubtipoValor";
            this.txtSubtipoValor.Size = new System.Drawing.Size(196, 20);
            this.txtSubtipoValor.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(55, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 22);
            this.label6.TabIndex = 45;
            this.label6.Text = "Subtipo de Valor";
            // 
            // CadastroAuxiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OrangePoint.Properties.Resources.Background_Padrão;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 621);
            this.Controls.Add(this.pnCadastraSubtipos);
            this.Controls.Add(this.btnCadastrarSubtipos);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAdicionarTipoValor);
            this.Controls.Add(this.dgTipoValor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipoValor);
            this.Controls.Add(this.btnAdicionaTipoDatas);
            this.Controls.Add(this.dgTipoDatas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTipoDatas);
            this.Controls.Add(this.AdicionarAtividadeEmpresa);
            this.Controls.Add(this.dgAtividade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAtividade);
            this.Controls.Add(this.AdicionarGrupo);
            this.Controls.Add(this.dgGrupo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNovoGrupo);
            this.Controls.Add(this.AdicionarRegime);
            this.Controls.Add(this.dgRegime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNovoRegime);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastroAuxiliar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Auxiliar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadastroAuxiliar_FormClosing);
            this.Load += new System.EventHandler(this.CadastroAuxiliar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtividade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoValor)).EndInit();
            this.pnCadastraSubtipos.ResumeLayout(false);
            this.pnCadastraSubtipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubtipoAtividade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubtipoValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPontoEletronico;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox userImage;
        private System.Windows.Forms.TextBox txtNovoRegime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgRegime;
        private System.Windows.Forms.Button AdicionarRegime;
        private System.Windows.Forms.Button AdicionarGrupo;
        private System.Windows.Forms.DataGridView dgGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNovoGrupo;
        private System.Windows.Forms.Button AdicionarAtividadeEmpresa;
        private System.Windows.Forms.DataGridView dgAtividade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAtividade;
        private System.Windows.Forms.Button btnAdicionaTipoDatas;
        private System.Windows.Forms.DataGridView dgTipoDatas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoDatas;
        private System.Windows.Forms.Button btnAdicionarTipoValor;
        private System.Windows.Forms.DataGridView dgTipoValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTipoValor;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCadastrarSubtipos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnCadastraSubtipos;
        private System.Windows.Forms.Button btnAdicionarSubitipoValor;
        private System.Windows.Forms.DataGridView dgSubtipoValor;
        private System.Windows.Forms.TextBox txtSubtipoValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTipoValor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbAtividade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSubtipoValor;
        private System.Windows.Forms.Button btnAdicionaSubtipoAtividade;
        private System.Windows.Forms.DataGridView dgSubtipoAtividade;
        private System.Windows.Forms.Label label9;
    }
}