using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Drawing;


namespace WindowsFormsApplication1
{
  
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        int port = 9035;
        int color;

        int gols = 0;
        int parades = 0;

        List<string> pdas = new List<string>();
        //string jert;

        string minombre, sunombre;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
        }
        SoundPlayer sonido;
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBoxLogin.Visible = true;
            groupBox_chat_partida.Visible = false;
            groupBox3.Visible = false;
            groupBox_aceptarinvitacion.Visible = false;
            gBMarcador.Visible = false;
            buttonConectar.Visible = false;
            buttonDesconectar.Visible = false;
            label5.Visible = false;
            groupBox1_invitar.Visible = false;
            pictureBoxGameBase.Visible = false;
            pictureBoxLogo.Visible = false;
            labelBEnvingut.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            groupBoxMusica.Visible = false;

        }

      
        private void PonContador(string mensaje)
        {
            label5.Text = mensaje;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[4096];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = mensaje = trozos[1].Split('\0')[0];
                //MessageBox.Show(Encoding.ASCII.GetString(msg2));
                string mensajeJ = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] respuesta;
                respuesta = mensajeJ.Split('/');

                switch (codigo)
                {
                    case 1:  // respuesta a conectar

                        if (mensaje == "SI")
                        {
                            MessageBox.Show("Ok, has entrat");
                            label5.Text = user.Text;
                        }
                        else
                            MessageBox.Show("credencials incorrectes.");
                        break;
                    case 2:      //respuesta a desconectar


                        if (mensaje == "SI")
                            MessageBox.Show("Ok");
                        else
                            MessageBox.Show("credencials incorrectes.");
                        break;
                    case 3:       //respuesta a primera consulta

                        string mensajeRespuesta = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show(mensajeRespuesta);
                        break;

                    case 4:     //respuesta a segunda consulta

                        string mensajeRespuesta2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show(mensajeRespuesta2);

                        break;
                    case 5:      //respuesta a tercera consulta

                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show("Jugadors amb més de dos gols i l'estadi: " + mensaje);

                        break;

                   
                    case 6:    //lista de conectados
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Jugadors actius", typeof(string));

                        int i = 0;
                        for (i = 0; i < trozos.Length - 2; i++)
                        {
                            trozos[i] = trozos[i + 1];
                        }

                        Array.Resize(ref trozos, i);

                        foreach (string nombre in trozos)
                        {
                            DataRow row = dt.NewRow();
                            row["Jugadors actius"] = nombre;
                            dt.Rows.Add(row);
                        }
                        this.Invoke(new Action(() =>
                        {
                            ListaConectados.DataSource = dt;
                            ListaConectados.Refresh();
                        }));
                        
                        break;
                       
                    case 7: //Invitacion a partida
                        MessageBox.Show("Sol·licitud enviada");
                        minombre = mensaje.Split('-')[0];
                        sunombre = mensaje.Split('-')[1];
                        groupBox_aceptarinvitacion.Visible = true;
                        label_invitacionPartida_name.Text = minombre + " et convida";
                        break;

                    case 8: //Respuesta invitacion a partida en el caso del host
                        string el = mensaje.Split('-')[0];
                        string yo = mensaje.Split('-')[1];
                        string resp = mensaje.Split('-')[2];
                       
                        this.color = 0;
                        MessageBox.Show(el + " ha dit: " + resp);
                        
                        string jert = "xutador";
                        if (resp == "SI" && jert == "xutador")
                        {
                            int idP = Convert.ToInt32(mensaje.Split('-')[3]);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            MessageBox.Show("Iniciant la partida, et toca xutar "  );
                            MessageBox.Show("El joc consta de 5 penals. " + "Si marques 3 gols guanyes.");
                        }
                        else
                        {
                            MessageBox.Show("Partida refusada");
                        }
                        
                        break;

                    case 9:
                        MessageBox.Show("Registrat correctament");
                        MessageBox.Show("Clica 'Entrar' per continuar");
                        break;

                    case 10:
                        int num = Convert.ToInt32(mensaje.Split('-')[0]);
                        string texto = mensaje.Split('-')[1];
                        break;

                    case 11: //Respuesta de la invitacion en el caso de ser el invitado
                        string el2 = mensaje.Split('-')[0];
                        string yo2 = mensaje.Split('-')[1];
                        string resp2 = mensaje.Split('-')[2];
                        int idP2 = Convert.ToInt32(mensaje.Split('-')[3]);
                        this.color = 1;
                        MessageBox.Show(el2 + " ha dicho: " + resp2);
                        jert = "porter";
                        if (resp2 == "SI" && jert == "porter")
                        {

                            radioButton5.Visible = true;
                            radioButton6.Visible = true;
                            radioButton7.Visible = true;
                            radioButton8.Visible = true;

                            MessageBox.Show("Iniciant la partida, ets el porter" + sunombre);
                            MessageBox.Show("El joc consta de 5 penals. " + "Si n'atures 3 guanyes.");


                        }
                        

                        break;

                    case 12:
                        MessageBox.Show("Donat de baixa correctament");
                        break;

                    case 15: //Mostrar mensajes del chat 
                        this.Invoke(new Action(() =>
                        {
                            xat.AppendText(respuesta[1] + ": " + respuesta[2] + Environment.NewLine);
                        }));

                        break;

                    case 30: //juegp
                        
                        int total = gols + parades;
                        if (total!=5)
                        {
                            if (mensaje == "gol")
                            {
                                try
                                {
                                    sonido = new SoundPlayer(Application.StartupPath + @"\Musica\gol-de-cerro-_mp3cut.net_.wav");
                                    sonido.Play();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex);
                                }
                               
                                labelesq.Text = "GOL";
                                labeldreta.Text = " ";
                                gols =( gols + 1);
                               
                                labelGols.Text = "" + gols;
                           
                            }
                            else
                            {
                                
                                try
                                {
                                    sonido = new SoundPlayer(Application.StartupPath + @"\Musica\arbitro-futbol-.wav");
                                    sonido.Play();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex);
                                }
                                labelesq.Text = "";
                                labeldreta.Text = "PORTER";
                                parades = parades + 1;
                                
                                labelAturades.Text = "" + parades;

                            }
                        }
                        else
                        {
                            labelesq.Text = "FINAL";
                            labeldreta.Text = "PARTIDA";
                            radioButton1.Visible = false;
                            radioButton2.Visible = false;
                            radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                            radioButton6.Visible = false;
                            radioButton7.Visible = false;
                            radioButton8.Visible = false;
                        }
                        
                            

                        break;

                        Array.Clear(trozos, 0, trozos.Length);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password.Text = "";
            buttonDesconectar.Visible = true;
            buttonConectar.Visible = false;
            groupBoxLogin.Visible = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            buttonDesconectar.Visible = true;
            groupBoxMusica.Visible = true;

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, port);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.CadetBlue;
                MessageBox.Show("Connectat");
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No s'ha pogut establir connexió amb el servidor");
                return;
            }



            labelBEnvingut.Text = "Benvingut/da";
            labelBEnvingut.Visible = true;
            groupBoxLogin.Visible = false;
            groupBox_chat_partida.Visible = true;
            groupBox3.Visible = true;
            groupBox1_invitar.Visible = true;
            pictureBoxGameBase.Visible = true;
            pictureBoxLogo.Visible = true;
            label5.Visible = true;
            gBMarcador.Visible = true;

            string mensaje = "1/" + user.Text + "/" + password.Text;
            // Enviamos al servidor el user y contraseña tecleados
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, port);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.CadetBlue;
                MessageBox.Show("Connectat");

                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No s'ha pogut establir connexió amb el servidor");
                return;
            }

            string mensaje = "2/" + user.Text + "/" + password.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }  
            
        private void button2_Click(object sender, EventArgs e)
        {
            if (partidas.Checked)
            {
                string mensaje = "3/" + nombre.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                MessageBox.Show(mensaje);

               
            }

            else if (dosgoles.Checked)
            {
                string mensaje = "5/" ;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("Jugadors amb més de dos gols i l'estadi: " + mensaje);

              

            }
            else if (jugadresenestadio.Checked)
            {
               
                string mensaje = "4/" + estadioBox.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
             
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            password.Text = "";
            groupBox1.Visible = false;
            groupBoxLogin.Visible = true;
            groupBox_chat_partida.Visible = false;
            groupBox3.Visible = false;
            gBMarcador.Visible = false;
            groupBox_aceptarinvitacion.Visible = false;
            buttonConectar.Visible = false;
            buttonDesconectar.Visible = false;
            label5.Visible = false;
            groupBox1_invitar.Visible = false;
            pictureBoxGameBase.Visible = false;
            pictureBoxLogo.Visible = false;
            labelBEnvingut.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            labelesq.Visible = false;
            labeldreta.Visible = false;



            //Mensaje de desconexión
            string mensaje = "0/";
        
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();


        }
       
        private void Longitud_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + textBox1.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void button_invitacionPartida_si_Click(object sender, EventArgs e)
        {
            string mensaje = "8/" + minombre + "/" + sunombre + "/SI";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            groupBox_aceptarinvitacion.Visible = false;
            gBMarcador.Visible = true;

        }

        private void groupBox1_invitar_Enter(object sender, EventArgs e)
        {

        }

        private void button2_invitacionPartida_NO_Click(object sender, EventArgs e)
        {
            string mensaje = "8/" + minombre + "/" + sunombre + "/NO";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            groupBox_aceptarinvitacion.Visible = false;
        }

        private void enviat_btn_partida_Click(object sender, EventArgs e)
        {
            xat.AppendText("Tu: " + textBox_xat_partida.Text + Environment.NewLine);
            string mensaje = "15/" + label5.Text + "/" + textBox_xat_partida.Text;
            textBox_xat_partida.Text = "";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
                    string mensaje = "30/x/dd";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
          
            
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
                string mensaje = "30/x/de/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
                string mensaje = "30/x/be/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
                string mensaje = "30/x/bd/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string mensaje = "30/p/dd/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            string mensaje = "30/p/bd/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            string mensaje = "30/p/de/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            string mensaje = "30/p/be/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }
        private void pictureBoxGameBase_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, pictureBoxGameBase.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (sonido != null)
            {
                sonido.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\Musica\Bakermat-Baianá-_Official-Video_.wav");
                sonido.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void groupBox_aceptarinvitacion_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, port);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.CadetBlue;
                MessageBox.Show("Connectat");

                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No s'ha pogut establir connexió amb el servidor");
                return;
            }

            string mensaje = "12/" + user.Text + "/" + password.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void buttonplay_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 5);
            if (numeroAleatorio == 1)
            {
                try
                {
                    sonido = new SoundPlayer(Application.StartupPath + @"\Musica\RVFV_-Kikimoteleba-TIGINI-REMIX-_Video-Oficial_.wav");
                    sonido.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else if (numeroAleatorio == 2)
            {
                try
                {
                    sonido = new SoundPlayer(Application.StartupPath + @"\Musica\ACDC-Thunderstruck.wav");
                    sonido.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else if (numeroAleatorio == 3)
            {
                try
                {
                    sonido = new SoundPlayer(Application.StartupPath + @"\Musica\Bakermat-Baianá-_Official-Video_.wav");
                    sonido.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else if (numeroAleatorio == 4)
            {
                try
                {
                    sonido = new SoundPlayer(Application.StartupPath + @"\Musica\Ed-Sheeran-Bad-Habits-_Official-Video_.wav");
                    sonido.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }

        }

       
       
    }
}
