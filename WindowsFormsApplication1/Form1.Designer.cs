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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partidas = new System.Windows.Forms.RadioButton();
            this.jugadresenestadio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.estadioBox = new System.Windows.Forms.TextBox();
            this.dosgoles = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contLbl = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1_invitar = new System.Windows.Forms.GroupBox();
            this.groupBox_invitacionPartida = new System.Windows.Forms.GroupBox();
            this.button2_invitacionPartida_NO = new System.Windows.Forms.Button();
            this.button_invitacionPartida_si = new System.Windows.Forms.Button();
            this.label_invitacionPartida_name = new System.Windows.Forms.Label();
            this.groupBox_chat_partida = new System.Windows.Forms.GroupBox();
            this.ChatdePartida = new System.Windows.Forms.DataGridView();
            this.textBox_mensaje_partida = new System.Windows.Forms.TextBox();
            this.enviat_btn_partida = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1_invitar.SuspendLayout();
            this.groupBox_invitacionPartida.SuspendLayout();
            this.groupBox_chat_partida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatdePartida)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(158, 59);
            this.nombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(244, 26);
            this.nombre.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(64, 86);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "connectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 238);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
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
            this.groupBox1.Location = new System.Drawing.Point(64, 379);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(587, 311);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Petició";
            // 
            // partidas
            // 
            this.partidas.AutoSize = true;
            this.partidas.Location = new System.Drawing.Point(174, 114);
            this.partidas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partidas.Name = "partidas";
            this.partidas.Size = new System.Drawing.Size(309, 24);
            this.partidas.TabIndex = 7;
            this.partidas.TabStop = true;
            this.partidas.Text = "Quines partides ha participat el jugador";
            this.partidas.UseVisualStyleBackColor = true;
            this.partidas.CheckedChanged += new System.EventHandler(this.Longitud_CheckedChanged);
            // 
            // jugadresenestadio
            // 
            this.jugadresenestadio.AutoSize = true;
            this.jugadresenestadio.Location = new System.Drawing.Point(174, 168);
            this.jugadresenestadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jugadresenestadio.Name = "jugadresenestadio";
            this.jugadresenestadio.Size = new System.Drawing.Size(339, 24);
            this.jugadresenestadio.TabIndex = 7;
            this.jugadresenestadio.TabStop = true;
            this.jugadresenestadio.Text = "Mostra els jugadors que han jugat a l\'estadi";
            this.jugadresenestadio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Estadi";
            // 
            // estadioBox
            // 
            this.estadioBox.Location = new System.Drawing.Point(32, 166);
            this.estadioBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.estadioBox.Name = "estadioBox";
            this.estadioBox.Size = new System.Drawing.Size(91, 26);
            this.estadioBox.TabIndex = 9;
            // 
            // dosgoles
            // 
            this.dosgoles.AutoSize = true;
            this.dosgoles.Location = new System.Drawing.Point(174, 140);
            this.dosgoles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dosgoles.Name = "dosgoles";
            this.dosgoles.Size = new System.Drawing.Size(365, 24);
            this.dosgoles.TabIndex = 8;
            this.dosgoles.TabStop = true;
            this.dosgoles.Text = "Jugadors amb 2 o + gols i l\'estadi on ho han fet";
            this.dosgoles.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(430, 85);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 49);
            this.button3.TabIndex = 10;
            this.button3.Text = "desconnectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.user);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(64, 158);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(586, 212);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log in";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(482, 162);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 29);
            this.button5.TabIndex = 5;
            this.button5.Text = "Entrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(378, 162);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 29);
            this.button4.TabIndex = 4;
            this.button4.Text = "Registrar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "USER";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(189, 114);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.PasswordChar = '·';
            this.password.Size = new System.Drawing.Size(170, 26);
            this.password.TabIndex = 1;
            // 
            // user
            // 
            this.user.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(142, 45);
            this.user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(219, 31);
            this.user.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(708, 158);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(345, 532);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Llistat";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(36, 249);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(270, 188);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // contLbl
            // 
            this.contLbl.AutoSize = true;
            this.contLbl.Location = new System.Drawing.Point(52, 34);
            this.contLbl.Name = "contLbl";
            this.contLbl.Size = new System.Drawing.Size(51, 20);
            this.contLbl.TabIndex = 13;
            this.contLbl.Text = "label5";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(61, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 41);
            this.button6.TabIndex = 1;
            this.button6.Text = "Convidar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1_invitar
            // 
            this.groupBox1_invitar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1_invitar.Controls.Add(this.button6);
            this.groupBox1_invitar.Controls.Add(this.textBox1);
            this.groupBox1_invitar.Location = new System.Drawing.Point(1143, 158);
            this.groupBox1_invitar.Name = "groupBox1_invitar";
            this.groupBox1_invitar.Size = new System.Drawing.Size(212, 135);
            this.groupBox1_invitar.TabIndex = 16;
            this.groupBox1_invitar.TabStop = false;
            this.groupBox1_invitar.Text = "Convidar";
            this.groupBox1_invitar.Enter += new System.EventHandler(this.groupBox1_invitar_Enter);
            // 
            // groupBox_invitacionPartida
            // 
            this.groupBox_invitacionPartida.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox_invitacionPartida.Controls.Add(this.button2_invitacionPartida_NO);
            this.groupBox_invitacionPartida.Controls.Add(this.button_invitacionPartida_si);
            this.groupBox_invitacionPartida.Controls.Add(this.label_invitacionPartida_name);
            this.groupBox_invitacionPartida.Location = new System.Drawing.Point(1081, 299);
            this.groupBox_invitacionPartida.Name = "groupBox_invitacionPartida";
            this.groupBox_invitacionPartida.Size = new System.Drawing.Size(327, 149);
            this.groupBox_invitacionPartida.TabIndex = 15;
            this.groupBox_invitacionPartida.TabStop = false;
            this.groupBox_invitacionPartida.Text = "Invitació";
            // 
            // button2_invitacionPartida_NO
            // 
            this.button2_invitacionPartida_NO.Location = new System.Drawing.Point(219, 84);
            this.button2_invitacionPartida_NO.Name = "button2_invitacionPartida_NO";
            this.button2_invitacionPartida_NO.Size = new System.Drawing.Size(55, 33);
            this.button2_invitacionPartida_NO.TabIndex = 2;
            this.button2_invitacionPartida_NO.Text = "NO";
            this.button2_invitacionPartida_NO.UseVisualStyleBackColor = true;
            // 
            // button_invitacionPartida_si
            // 
            this.button_invitacionPartida_si.Location = new System.Drawing.Point(62, 84);
            this.button_invitacionPartida_si.Name = "button_invitacionPartida_si";
            this.button_invitacionPartida_si.Size = new System.Drawing.Size(61, 32);
            this.button_invitacionPartida_si.TabIndex = 1;
            this.button_invitacionPartida_si.Text = "SI";
            this.button_invitacionPartida_si.UseVisualStyleBackColor = true;
            this.button_invitacionPartida_si.Click += new System.EventHandler(this.button_invitacionPartida_si_Click);
            // 
            // label_invitacionPartida_name
            // 
            this.label_invitacionPartida_name.AutoSize = true;
            this.label_invitacionPartida_name.Location = new System.Drawing.Point(138, 45);
            this.label_invitacionPartida_name.Name = "label_invitacionPartida_name";
            this.label_invitacionPartida_name.Size = new System.Drawing.Size(51, 20);
            this.label_invitacionPartida_name.TabIndex = 0;
            this.label_invitacionPartida_name.Text = "label1";
            // 
            // groupBox_chat_partida
            // 
            this.groupBox_chat_partida.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox_chat_partida.Controls.Add(this.ChatdePartida);
            this.groupBox_chat_partida.Controls.Add(this.textBox_mensaje_partida);
            this.groupBox_chat_partida.Controls.Add(this.enviat_btn_partida);
            this.groupBox_chat_partida.Location = new System.Drawing.Point(1098, 454);
            this.groupBox_chat_partida.Name = "groupBox_chat_partida";
            this.groupBox_chat_partida.Size = new System.Drawing.Size(297, 244);
            this.groupBox_chat_partida.TabIndex = 17;
            this.groupBox_chat_partida.TabStop = false;
            this.groupBox_chat_partida.Text = "xat";
            // 
            // ChatdePartida
            // 
            this.ChatdePartida.AllowUserToAddRows = false;
            this.ChatdePartida.AllowUserToDeleteRows = false;
            this.ChatdePartida.BackgroundColor = System.Drawing.Color.White;
            this.ChatdePartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChatdePartida.Location = new System.Drawing.Point(28, 25);
            this.ChatdePartida.Name = "ChatdePartida";
            this.ChatdePartida.ReadOnly = true;
            this.ChatdePartida.RowHeadersWidth = 62;
            this.ChatdePartida.RowTemplate.Height = 28;
            this.ChatdePartida.Size = new System.Drawing.Size(240, 150);
            this.ChatdePartida.TabIndex = 0;
            // 
            // textBox_mensaje_partida
            // 
            this.textBox_mensaje_partida.Location = new System.Drawing.Point(28, 181);
            this.textBox_mensaje_partida.Name = "textBox_mensaje_partida";
            this.textBox_mensaje_partida.Size = new System.Drawing.Size(240, 26);
            this.textBox_mensaje_partida.TabIndex = 1;
            // 
            // enviat_btn_partida
            // 
            this.enviat_btn_partida.Location = new System.Drawing.Point(102, 213);
            this.enviat_btn_partida.Name = "enviat_btn_partida";
            this.enviat_btn_partida.Size = new System.Drawing.Size(81, 28);
            this.enviat_btn_partida.TabIndex = 2;
            this.enviat_btn_partida.Text = "ENVIAR";
            this.enviat_btn_partida.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.groupBox_chat_partida);
            this.Controls.Add(this.groupBox1_invitar);
            this.Controls.Add(this.groupBox_invitacionPartida);
            this.Controls.Add(this.contLbl);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Grup 5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1_invitar.ResumeLayout(false);
            this.groupBox1_invitar.PerformLayout();
            this.groupBox_invitacionPartida.ResumeLayout(false);
            this.groupBox_invitacionPartida.PerformLayout();
            this.groupBox_chat_partida.ResumeLayout(false);
            this.groupBox_chat_partida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatdePartida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton partidas;
        private System.Windows.Forms.RadioButton dosgoles;
        private System.Windows.Forms.RadioButton jugadresenestadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox estadioBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label contLbl;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1_invitar;
        private System.Windows.Forms.GroupBox groupBox_invitacionPartida;
        private System.Windows.Forms.Button button2_invitacionPartida_NO;
        private System.Windows.Forms.Button button_invitacionPartida_si;
        private System.Windows.Forms.Label label_invitacionPartida_name;
        private System.Windows.Forms.GroupBox groupBox_chat_partida;
        private System.Windows.Forms.DataGridView ChatdePartida;
        private System.Windows.Forms.TextBox textBox_mensaje_partida;
        private System.Windows.Forms.Button enviat_btn_partida;
    }
}

