using Cliente_AlejandroVenegas.ConexionTCP;
using Cliente_AlejandroVenegas.Formularios;
using Entidades_AlejandroVenegas.Objetos;
using System;
using System.Windows.Forms;
using Tarea2_AlejandroVenegas.Formularios;

namespace Cliente_AlejandroVenegas
{
    public partial class Form1 : Form
    {
        public bool estaConectado = false;
        public static ConexionTcp conexionTcp = new ConexionTcp();
        public static string IPADDRESS = "127.0.0.1";
        public const int PORT = 16830;
        FormRegistroVenta form4 = new FormRegistroVenta(conexionTcp);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (estaConectado)
            {
                var form5 = new FormCajero(conexionTcp);
                form5.Show();
            }
            else
            {
                string message = "Error de conexión con el servidor.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (estaConectado)
            {
                form4.Show();
            }
            else
            {
                string message = "Error de conexión con el servidor.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }

        }

        private void Form1_Load(object sender, EventArgs e)//Se conecta al servidor apenas de carga el formulario.
        {
            label1.Text = "Bienvenido" + "" + ", por favor presione opción.";

        }

        private void MensajeRecibido(string datos)
        {
            var paquete = new Paquete(datos);
            string comando = paquete.Comando;
            if (comando == "resultado")
            {
                string contenido = paquete.Contenido;

                Invoke(new Action(() => groupBox1.Text = string.Format("Respuesta: {0}", contenido)));
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);//Se desconecta del servidor apenas de cierra el formulario.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!estaConectado)
            {
                String accion = "";
                conexionTcp.OnDataRecieved += MensajeRecibido;//Llama al método para recibir el mensaje.
                label1.Text = "Bienvenidos" + "" + ", por favor presione opción.";

                if (!conexionTcp.Conectar(IPADDRESS, PORT))
                {
                    accion = "Error conectando con el servidor.";
                    return;

                }
                estaConectado = true;
                accion = "Conectado al servidor.";
                Invoke(new Action(() => listBox1.Items.Add(accion)));
            }
            else
            {
                string message = "Error, ya se encuentra conectado al servidor.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (estaConectado)
            {
                try
                {
                    conexionTcp.desconectar();
                    estaConectado = false;
                    String accion = "Desconectado del servidor.";
                    Invoke(new Action(() => listBox1.Items.Add(accion)));
                }
                catch (System.IO.IOException es)
                {
                    string message = es + "";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);
                }
            }

            else
            {
                string message = "Error, no se puede desconectar del servidor sin estar previamente conectado al mismo.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
        }

    }
}
