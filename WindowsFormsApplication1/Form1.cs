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


namespace WindowsFormsApplication1
{
  
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        int port = 9075;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBoxLogin.Visible = false;
            groupBox_chat_partida.Visible = false;
            groupBox3.Visible = false;
            groupBox_aceptarinvitacion.Visible = false;
            gBMarcador.Visible = false;
            buttonConectar.Visible = true;
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

        }

        public void CoMen(string mensaje)
        {
            //ChatdePartida.ClearSelection();

            //ChatdePartida.Rows.Add(mensaje);
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

                    /* case 6:    //lista de conectados
                          string[] listaconectados = mensaje.Split('/');
                         int numerodeconectados = Convert.ToInt32(listaconectados[0]);
                         dataGridView1.ColumnCount = 1;
                         dataGridView1.RowCount = numerodeconectados;

                         for (int i = 1; i <= numerodeconectados; i++)
                         {

                             dataGridView1.Rows[i -1].Cells[0].Value = listaconectados[i];

                         }
                         break;*/
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
                        /* string[] listaconectados = mensaje.Split('/');
                         int numerodeconectados = Convert.ToInt32(listaconectados[0]);
                         

                        if (dataGridView1.InvokeRequired)
                         {
                             dataGridView1.Invoke(new MethodInvoker(delegate
                             {
                                 dataGridView1.ColumnCount = 1;
                             }));
                         }
                         else
                         {
                             dataGridView1.ColumnCount = 1;
                         }

                         dataGridView1.RowCount = numerodeconectados;



                        for (int i = 0; i < numerodeconectados + 1 && i < listaconectados.Length; i++)
                       {
                           //dataGridView1.Rows.Add(2);
                           dataGridView1.Rows[i].Cells[0].Value = listaconectados[i];

                       }*/
                        break;



                        /* case 7:     //Recibimos notificacion

                             //Haz tu lo que no me dejas hacer a mi
                             contLbl.Invoke(new Action(() =>
                             {
                                 contLbl.Text = mensaje;
                             }));

                             break;*/


                       
                    case 7: //Invitacion a partida
                        //MessageBox.Show(Encoding.ASCII.GetString(msg2));
                        //groupBox_invitacionPartida.Visible = true;
                        MessageBox.Show("Sol·licitud enviada");
                        minombre = mensaje.Split('-')[0];
                        sunombre = mensaje.Split('-')[1];
                        groupBox_aceptarinvitacion.Visible = true;
                        label_invitacionPartida_name.Text = minombre + " et convida a una partida";
                        break;

                    case 8: //Respuesta invitacion a partida en el caso del host
                            // MessageBox.Show(Encoding.ASCII.GetString(msg2));
                       // MessageBox.Show("Sol·licitud enviada");
                        string el = mensaje.Split('-')[0];
                        string yo = mensaje.Split('-')[1];
                        string resp = mensaje.Split('-')[2];
                        int idP = Convert.ToInt32(mensaje.Split('-')[3]);
                        this.color = 0;
                        MessageBox.Show(el + " ha dit: " + resp);
                        
                        string jert = "xutador";
                        if (resp == "SI" && jert == "xutador")
                        {
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            MessageBox.Show("Iniciant la partida, et toca xutar "  );
                            MessageBox.Show("El joc consta de 5 penals. " + "Si marques 3 gols guanyes.");


                        }
                        
                        break;

                    case 9:
                        MessageBox.Show("Registrat correctament");
                        MessageBox.Show("Clica 'Entrar' per continuar");
                        break;

                    case 10:
                        int num = Convert.ToInt32(mensaje.Split('-')[0]);
                        string texto = mensaje.Split('-')[1];
                       // pdas[num].CoMen(texto);
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

                    case 15: //Mostrar mensajes del chat 
                        this.Invoke(new Action(() =>
                        {
                            xat.AppendText(respuesta[1] + ": " + respuesta[2] + Environment.NewLine);
                        }));

                        break;

                    case 30:
                        
                        int total = gols + parades;
                        if (total!=5)
                        {
                            if (mensaje == "gol")
                            {
                                //MessageBox.Show("GOL");
                                labelesq.Text = "GOL";
                                labeldreta.Text = " ";
                                gols =( gols + 1);
                               
                                labelGols.Text = "" + gols;

                              /*  radioButton1.Checked = false;
                                radioButton2.Checked = false;
                                radioButton3.Checked = false;
                                radioButton4.Checked = false;
                                radioButton5.Checked = false;
                                radioButton6.Checked = false;
                                radioButton7.Checked = false;
                                radioButton8.Checked = false;
                              */

                            }
                            else
                            {
                                //MessageBox.Show("ATURADA");
                                labelesq.Text = "";
                                labeldreta.Text = "PORTER";
                                parades = parades + 1;
                                
                                labelAturades.Text = "" + parades;

                             /*   radioButton1.Checked = false;
                                radioButton2.Checked = false;
                                radioButton3.Checked = false;
                                radioButton4.Checked = false;
                                radioButton5.Checked = false;
                                radioButton6.Checked = false;
                                radioButton7.Checked = false;
                                radioButton8.Checked = false;
                             */
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
                 



            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, port);
            

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                //this.BackColor = Color.CadetBlue;
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

        }
        private void button5_Click(object sender, EventArgs e)
        {
            labelBEnvingut.Text = "Benvingut/da";
            labelBEnvingut.Visible = true;
            groupBox1.Visible = true;
            groupBoxLogin.Visible = false;
            groupBox_chat_partida.Visible = true;
            groupBox3.Visible = true;
            //groupBox_aceptarinvitacion.Visible = true;
            //buttonConectar.Visible = false;
            //buttonDesconectar.Visible = false;
            //contLbl.Visible = false;
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
            groupBox1.Visible = false;
            groupBoxLogin.Visible = false;
            groupBox_chat_partida.Visible = false;
            groupBox3.Visible = false;
            gBMarcador.Visible = false;
            groupBox_aceptarinvitacion.Visible = false;
            buttonConectar.Visible = true;
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
        /*private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            //enviamos mensaje al sevidor
            string mensaje = "6/" + user.Text + "/" + password.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }*/

        private void Longitud_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //8/jugador
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

            // groupBox_Chat.Visible = true;
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


            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
                    string mensaje = "30/x/dd";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
            //radioButton1.Checked = false;
            
           
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
