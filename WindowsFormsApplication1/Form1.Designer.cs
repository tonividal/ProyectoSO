namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.buttonConectar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partidas = new System.Windows.Forms.RadioButton();
            this.jugadresenestadio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.estadioBox = new System.Windows.Forms.TextBox();
            this.dosgoles = new System.Windows.Forms.RadioButton();
            this.buttonDesconectar = new System.Windows.Forms.Button();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1_invitar = new System.Windows.Forms.GroupBox();
            this.groupBox_aceptarinvitacion = new System.Windows.Forms.GroupBox();
            this.button2_invitacionPartida_NO = new System.Windows.Forms.Button();
            this.button_invitacionPartida_si = new System.Windows.Forms.Button();
            this.label_invitacionPartida_name = new System.Windows.Forms.Label();
            this.groupBox_chat_partida = new System.Windows.Forms.GroupBox();
            this.xat = new System.Windows.Forms.TextBox();
            this.textBox_xat_partida = new System.Windows.Forms.TextBox();
            this.enviat_btn_partida = new System.Windows.Forms.Button();
            this.pictureBoxGameBase = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelBEnvingut = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.gBMarcador = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelAturades = new System.Windows.Forms.Label();
            this.labelGols = new System.Windows.Forms.Label();
            this.labelesq = new System.Windows.Forms.Label();
            this.labeldreta = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.groupBox1_invitar.SuspendLayout();
            this.groupBox_aceptarinvitacion.SuspendLayout();
            this.groupBox_chat_partida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.gBMarcador.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(77, 47);
            this.nombre.Margin = new System.Windows.Forms.Padding(4);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(217, 22);
            this.nombre.TabIndex = 3;
            // 
            // buttonConectar
            // 
            this.buttonConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConectar.Location = new System.Drawing.Point(13, 13);
            this.buttonConectar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConectar.Name = "buttonConectar";
            this.buttonConectar.Size = new System.Drawing.Size(199, 38);
            this.buttonConectar.TabIndex = 4;
            this.buttonConectar.Text = "connectar";
            this.buttonConectar.UseVisualStyleBackColor = true;
            this.buttonConectar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 170);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.partidas);
            this.groupBox1.Controls.Add(this.jugadresenestadio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.estadioBox);
            this.groupBox1.Controls.Add(this.dosgoles);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Location = new System.Drawing.Point(13, 249);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(431, 210);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Petició";
            // 
            // partidas
            // 
            this.partidas.AutoSize = true;
            this.partidas.Location = new System.Drawing.Point(77, 80);
            this.partidas.Margin = new System.Windows.Forms.Padding(4);
            this.partidas.Name = "partidas";
            this.partidas.Size = new System.Drawing.Size(278, 21);
            this.partidas.TabIndex = 7;
            this.partidas.TabStop = true;
            this.partidas.Text = "Quines partides ha participat el jugador";
            this.partidas.UseVisualStyleBackColor = true;
            this.partidas.CheckedChanged += new System.EventHandler(this.Longitud_CheckedChanged);
            // 
            // jugadresenestadio
            // 
            this.jugadresenestadio.AutoSize = true;
            this.jugadresenestadio.Location = new System.Drawing.Point(77, 123);
            this.jugadresenestadio.Margin = new System.Windows.Forms.Padding(4);
            this.jugadresenestadio.Name = "jugadresenestadio";
            this.jugadresenestadio.Size = new System.Drawing.Size(304, 21);
            this.jugadresenestadio.TabIndex = 7;
            this.jugadresenestadio.TabStop = true;
            this.jugadresenestadio.Text = "Mostra els jugadors que han jugat a l\'estadi";
            this.jugadresenestadio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Estadi";
            // 
            // estadioBox
            // 
            this.estadioBox.Location = new System.Drawing.Point(16, 176);
            this.estadioBox.Margin = new System.Windows.Forms.Padding(4);
            this.estadioBox.Name = "estadioBox";
            this.estadioBox.Size = new System.Drawing.Size(81, 22);
            this.estadioBox.TabIndex = 9;
            // 
            // dosgoles
            // 
            this.dosgoles.AutoSize = true;
            this.dosgoles.Location = new System.Drawing.Point(77, 101);
            this.dosgoles.Margin = new System.Windows.Forms.Padding(4);
            this.dosgoles.Name = "dosgoles";
            this.dosgoles.Size = new System.Drawing.Size(328, 21);
            this.dosgoles.TabIndex = 8;
            this.dosgoles.TabStop = true;
            this.dosgoles.Text = "Jugadors amb 2 o + gols i l\'estadi on ho han fet";
            this.dosgoles.UseVisualStyleBackColor = true;
            // 
            // buttonDesconectar
            // 
            this.buttonDesconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDesconectar.Location = new System.Drawing.Point(13, 12);
            this.buttonDesconectar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDesconectar.Name = "buttonDesconectar";
            this.buttonDesconectar.Size = new System.Drawing.Size(199, 39);
            this.buttonDesconectar.TabIndex = 10;
            this.buttonDesconectar.Text = "desconnectar";
            this.buttonDesconectar.UseVisualStyleBackColor = true;
            this.buttonDesconectar.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBoxLogin.Controls.Add(this.button5);
            this.groupBoxLogin.Controls.Add(this.button4);
            this.groupBoxLogin.Controls.Add(this.label4);
            this.groupBoxLogin.Controls.Add(this.label1);
            this.groupBoxLogin.Controls.Add(this.password);
            this.groupBoxLogin.Controls.Add(this.user);
            this.groupBoxLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxLogin.Location = new System.Drawing.Point(13, 74);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(280, 150);
            this.groupBoxLogin.TabIndex = 11;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Log in";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(180, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Entrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(88, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Registrar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "USER";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(103, 76);
            this.password.Name = "password";
            this.password.PasswordChar = '·';
            this.password.Size = new System.Drawing.Size(152, 22);
            this.password.TabIndex = 1;
            // 
            // user
            // 
            this.user.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(61, 21);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(195, 27);
            this.user.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox3.Controls.Add(this.ListaConectados);
            this.groupBox3.Location = new System.Drawing.Point(1220, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(260, 302);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Llistat";
            // 
            // ListaConectados
            // 
            this.ListaConectados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.GridColor = System.Drawing.SystemColors.Control;
            this.ListaConectados.Location = new System.Drawing.Point(33, 32);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.RowHeadersWidth = 51;
            this.ListaConectados.RowTemplate.Height = 24;
            this.ListaConectados.Size = new System.Drawing.Size(193, 239);
            this.ListaConectados.TabIndex = 13;
            this.ListaConectados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(299, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "---";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(54, 58);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 33);
            this.button6.TabIndex = 1;
            this.button6.Text = "Convidar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 22);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1_invitar
            // 
            this.groupBox1_invitar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1_invitar.Controls.Add(this.button6);
            this.groupBox1_invitar.Controls.Add(this.textBox1);
            this.groupBox1_invitar.Location = new System.Drawing.Point(1253, 342);
            this.groupBox1_invitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1_invitar.Name = "groupBox1_invitar";
            this.groupBox1_invitar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1_invitar.Size = new System.Drawing.Size(193, 108);
            this.groupBox1_invitar.TabIndex = 16;
            this.groupBox1_invitar.TabStop = false;
            this.groupBox1_invitar.Text = "Convidar";
            this.groupBox1_invitar.Enter += new System.EventHandler(this.groupBox1_invitar_Enter);
            // 
            // groupBox_aceptarinvitacion
            // 
            this.groupBox_aceptarinvitacion.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox_aceptarinvitacion.Controls.Add(this.button2_invitacionPartida_NO);
            this.groupBox_aceptarinvitacion.Controls.Add(this.button_invitacionPartida_si);
            this.groupBox_aceptarinvitacion.Controls.Add(this.label_invitacionPartida_name);
            this.groupBox_aceptarinvitacion.Location = new System.Drawing.Point(1253, 461);
            this.groupBox_aceptarinvitacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_aceptarinvitacion.Name = "groupBox_aceptarinvitacion";
            this.groupBox_aceptarinvitacion.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_aceptarinvitacion.Size = new System.Drawing.Size(193, 119);
            this.groupBox_aceptarinvitacion.TabIndex = 15;
            this.groupBox_aceptarinvitacion.TabStop = false;
            this.groupBox_aceptarinvitacion.Text = "Invitació";
            // 
            // button2_invitacionPartida_NO
            // 
            this.button2_invitacionPartida_NO.Location = new System.Drawing.Point(94, 76);
            this.button2_invitacionPartida_NO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2_invitacionPartida_NO.Name = "button2_invitacionPartida_NO";
            this.button2_invitacionPartida_NO.Size = new System.Drawing.Size(99, 26);
            this.button2_invitacionPartida_NO.TabIndex = 2;
            this.button2_invitacionPartida_NO.Text = "Refusa";
            this.button2_invitacionPartida_NO.UseVisualStyleBackColor = true;
            this.button2_invitacionPartida_NO.Click += new System.EventHandler(this.button2_invitacionPartida_NO_Click);
            // 
            // button_invitacionPartida_si
            // 
            this.button_invitacionPartida_si.Location = new System.Drawing.Point(0, 76);
            this.button_invitacionPartida_si.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_invitacionPartida_si.Name = "button_invitacionPartida_si";
            this.button_invitacionPartida_si.Size = new System.Drawing.Size(99, 26);
            this.button_invitacionPartida_si.TabIndex = 1;
            this.button_invitacionPartida_si.Text = "Accepta";
            this.button_invitacionPartida_si.UseVisualStyleBackColor = true;
            this.button_invitacionPartida_si.Click += new System.EventHandler(this.button_invitacionPartida_si_Click);
            // 
            // label_invitacionPartida_name
            // 
            this.label_invitacionPartida_name.AutoSize = true;
            this.label_invitacionPartida_name.Location = new System.Drawing.Point(15, 33);
            this.label_invitacionPartida_name.Name = "label_invitacionPartida_name";
            this.label_invitacionPartida_name.Size = new System.Drawing.Size(0, 17);
            this.label_invitacionPartida_name.TabIndex = 0;
            // 
            // groupBox_chat_partida
            // 
            this.groupBox_chat_partida.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox_chat_partida.Controls.Add(this.xat);
            this.groupBox_chat_partida.Controls.Add(this.textBox_xat_partida);
            this.groupBox_chat_partida.Controls.Add(this.enviat_btn_partida);
            this.groupBox_chat_partida.Location = new System.Drawing.Point(13, 484);
            this.groupBox_chat_partida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_chat_partida.Name = "groupBox_chat_partida";
            this.groupBox_chat_partida.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_chat_partida.Size = new System.Drawing.Size(294, 205);
            this.groupBox_chat_partida.TabIndex = 17;
            this.groupBox_chat_partida.TabStop = false;
            this.groupBox_chat_partida.Text = "Xat";
            // 
            // xat
            // 
            this.xat.Location = new System.Drawing.Point(39, 19);
            this.xat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xat.Multiline = true;
            this.xat.Name = "xat";
            this.xat.Size = new System.Drawing.Size(214, 118);
            this.xat.TabIndex = 4;
            // 
            // textBox_xat_partida
            // 
            this.textBox_xat_partida.Location = new System.Drawing.Point(39, 144);
            this.textBox_xat_partida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_xat_partida.Name = "textBox_xat_partida";
            this.textBox_xat_partida.Size = new System.Drawing.Size(214, 22);
            this.textBox_xat_partida.TabIndex = 1;
            // 
            // enviat_btn_partida
            // 
            this.enviat_btn_partida.Location = new System.Drawing.Point(103, 170);
            this.enviat_btn_partida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enviat_btn_partida.Name = "enviat_btn_partida";
            this.enviat_btn_partida.Size = new System.Drawing.Size(72, 22);
            this.enviat_btn_partida.TabIndex = 2;
            this.enviat_btn_partida.Text = "ENVIAR";
            this.enviat_btn_partida.UseVisualStyleBackColor = true;
            this.enviat_btn_partida.Click += new System.EventHandler(this.enviat_btn_partida_Click);
            // 
            // pictureBoxGameBase
            // 
            this.pictureBoxGameBase.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGameBase.Image")));
            this.pictureBoxGameBase.Location = new System.Drawing.Point(514, 215);
            this.pictureBoxGameBase.Name = "pictureBoxGameBase";
            this.pictureBoxGameBase.Size = new System.Drawing.Size(617, 435);
            this.pictureBoxGameBase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGameBase.TabIndex = 18;
            this.pictureBoxGameBase.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(627, 13);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(388, 168);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 19;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelBEnvingut
            // 
            this.labelBEnvingut.AutoSize = true;
            this.labelBEnvingut.Font = new System.Drawing.Font("Wide Latin", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBEnvingut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelBEnvingut.Location = new System.Drawing.Point(26, 126);
            this.labelBEnvingut.Name = "labelBEnvingut";
            this.labelBEnvingut.Size = new System.Drawing.Size(233, 23);
            this.labelBEnvingut.TabIndex = 20;
            this.labelBEnvingut.Text = "Benvingut/da";
            this.labelBEnvingut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(973, 309);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 21);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Xuta!";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(627, 309);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 21);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Xuta!";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(627, 390);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(61, 21);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Xuta!";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(973, 390);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(61, 21);
            this.radioButton4.TabIndex = 24;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Xuta!";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(973, 309);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(66, 21);
            this.radioButton5.TabIndex = 25;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Atura!";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(627, 390);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(66, 21);
            this.radioButton6.TabIndex = 26;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Atura!";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(627, 309);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(66, 21);
            this.radioButton7.TabIndex = 27;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Atura!";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(973, 390);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(66, 21);
            this.radioButton8.TabIndex = 28;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Atura!";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // gBMarcador
            // 
            this.gBMarcador.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.gBMarcador.Controls.Add(this.label8);
            this.gBMarcador.Controls.Add(this.labelAturades);
            this.gBMarcador.Controls.Add(this.labelGols);
            this.gBMarcador.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gBMarcador.Location = new System.Drawing.Point(722, 675);
            this.gBMarcador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBMarcador.Name = "gBMarcador";
            this.gBMarcador.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBMarcador.Size = new System.Drawing.Size(176, 90);
            this.gBMarcador.TabIndex = 29;
            this.gBMarcador.TabStop = false;
            this.gBMarcador.Text = "Marcador";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cascadia Mono", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(74, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 37);
            this.label8.TabIndex = 2;
            this.label8.Text = "-";
            // 
            // labelAturades
            // 
            this.labelAturades.AutoSize = true;
            this.labelAturades.Font = new System.Drawing.Font("Cascadia Mono", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAturades.Location = new System.Drawing.Point(113, 26);
            this.labelAturades.Name = "labelAturades";
            this.labelAturades.Size = new System.Drawing.Size(39, 44);
            this.labelAturades.TabIndex = 1;
            this.labelAturades.Text = "0";
            // 
            // labelGols
            // 
            this.labelGols.AutoSize = true;
            this.labelGols.Font = new System.Drawing.Font("Cascadia Mono", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGols.Location = new System.Drawing.Point(28, 26);
            this.labelGols.Name = "labelGols";
            this.labelGols.Size = new System.Drawing.Size(39, 44);
            this.labelGols.TabIndex = 0;
            this.labelGols.Text = "0";
            // 
            // labelesq
            // 
            this.labelesq.AutoSize = true;
            this.labelesq.Location = new System.Drawing.Point(670, 724);
            this.labelesq.Name = "labelesq";
            this.labelesq.Size = new System.Drawing.Size(0, 17);
            this.labelesq.TabIndex = 30;
            // 
            // labeldreta
            // 
            this.labeldreta.AutoSize = true;
            this.labeldreta.Location = new System.Drawing.Point(904, 724);
            this.labeldreta.Name = "labeldreta";
            this.labeldreta.Size = new System.Drawing.Size(0, 17);
            this.labeldreta.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1493, 776);
            this.Controls.Add(this.labeldreta);
            this.Controls.Add(this.labelesq);
            this.Controls.Add(this.gBMarcador);
            this.Controls.Add(this.radioButton8);
            this.Controls.Add(this.radioButton7);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.labelBEnvingut);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.pictureBoxGameBase);
            this.Controls.Add(this.groupBox_chat_partida);
            this.Controls.Add(this.groupBox1_invitar);
            this.Controls.Add(this.groupBox_aceptarinvitacion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxLogin);
            this.Controls.Add(this.buttonDesconectar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonConectar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PENALTY FEVER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.groupBox1_invitar.ResumeLayout(false);
            this.groupBox1_invitar.PerformLayout();
            this.groupBox_aceptarinvitacion.ResumeLayout(false);
            this.groupBox_aceptarinvitacion.PerformLayout();
            this.groupBox_chat_partida.ResumeLayout(false);
            this.groupBox_chat_partida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.gBMarcador.ResumeLayout(false);
            this.gBMarcador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button buttonConectar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton partidas;
        private System.Windows.Forms.RadioButton dosgoles;
        private System.Windows.Forms.RadioButton jugadresenestadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox estadioBox;
        private System.Windows.Forms.Button buttonDesconectar;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView ListaConectados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1_invitar;
        private System.Windows.Forms.GroupBox groupBox_aceptarinvitacion;
        private System.Windows.Forms.Button button2_invitacionPartida_NO;
        private System.Windows.Forms.Button button_invitacionPartida_si;
        private System.Windows.Forms.Label label_invitacionPartida_name;
        private System.Windows.Forms.GroupBox groupBox_chat_partida;
        private System.Windows.Forms.TextBox textBox_xat_partida;
        private System.Windows.Forms.Button enviat_btn_partida;
        private System.Windows.Forms.PictureBox pictureBoxGameBase;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelBEnvingut;
        private System.Windows.Forms.TextBox xat;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.GroupBox gBMarcador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelAturades;
        private System.Windows.Forms.Label labelGols;
        private System.Windows.Forms.Label labelesq;
        private System.Windows.Forms.Label labeldreta;
    }
}

