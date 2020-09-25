using Cliente_AlejandroVenegas.ConexionTCP;
using Entidades_AlejandroVenegas.Objetos;
using System;
using System.Windows.Forms;

namespace Tarea2_AlejandroVenegas.Formularios
{
    public partial class FormCajero : Form
    {

        public bool Selected = false;
        public ConexionTcp conexionTcp;
        public FormCajero(ConexionTcp conexion)
        {
            conexionTcp = conexion;
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.Identificación.Text != "" && this.Nombre.Text != "" && this.Apellido1.Text != "" && this.Apellido2.Text != "") //Comprueba que la conexión TCP esté activa.
                {

                    if (conexionTcp.TcpClient != null)
                    {
                        if (conexionTcp.TcpClient.Connected) //Comprueba que la conexión TCP esté activa.
                        {


                            Cajero cajero = new Cajero(this.Identificación.Text, this.Nombre.Text, this.Apellido1.Text, this.Apellido2.Text, 0, false);

                            var msgPack = new Paquete("registrarCajero", string.Format("{0},{1},{2},{3}", this.Identificación.Text, this.Nombre.Text, this.Apellido1.Text, this.Apellido2.Text));//Convierte datos a formato de cadena.
                            conexionTcp.EnviarPaquete(msgPack); //Envia datos respectivos al servidor.

                            this.Nombre.Clear();//Limpia campo de texto.
                            this.Identificación.Clear();
                            this.Apellido1.Clear();
                            this.Apellido2.Clear();
                        }
                        else
                        {
                            string message = "Error, no puede dejar campos sin rellenar.";
                            string title = "Mensaje";
                            MessageBox.Show(message, title);
                        }

                    }
                    else
                    {
                        string message = "Error de conexión con el servidor.";
                        string title = "Mensaje";
                        MessageBox.Show(message, title);
                    }

                }
            }
            catch (System.FormatException s)
            {
                Console.WriteLine(s);
                string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
            catch (System.Net.Sockets.SocketException s)
            {
                Console.WriteLine(s);
                string message = "Error con la conexión con el servidor.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
            catch (System.NullReferenceException s)
            {
                Console.WriteLine(s);
                string message = "Error con la conexión con el servidor.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
        }

        private void MensajeRecibido(string datos) //Se encarga de recibir alguna respuesta por parte del servidor.
        {
            var paquete = new Paquete(datos);
            string comando = paquete.Comando;
            if (comando == "resultado")
            {
                string contenido = paquete.Contenido; //Extrae contenido desde el servidor.
            }
        }



    }
}




