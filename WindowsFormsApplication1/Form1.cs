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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void PonContador(string mensaje)
        {
            contLbl.Text = mensaje;
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

                switch (codigo)
                {
                    case 1:  // respuesta a conectar

                        if (mensaje == "SI")
                            MessageBox.Show("Ok, has entrat");
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
                        string[] listaconectados = mensaje.Split('/');
                        int numerodeconectados = Convert.ToInt32(listaconectados[0]);
                        dataGridView1.ColumnCount = 1;
                        dataGridView1.RowCount = numerodeconectados;

                        for (int i = 1; i <= numerodeconectados; i++)
                        {

                            dataGridView1.Rows[i - 1].Cells[0].Value = listaconectados[i];

                        }
                        break;
                   
                    case 7:     //Recibimos notificacion

                        //Haz tu lo que no me dejas hacer a mi
                        contLbl.Invoke(new Action(() =>
                        {
                            contLbl.Text = mensaje;
                        }));

                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9070);
            

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.LimeGreen;
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
            string mensaje = "1/" + user.Text + "/" + password.Text;
            // Enviamos al servidor el user y contraseña tecleados
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + user.Text + "/" + password.Text;
            // Enviamos al servidor el user y contraseña tecleados
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
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            //enviamos mensaje al sevidor
            string mensaje = "6/" + user.Text + "/" + password.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void Longitud_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
