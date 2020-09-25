using Entidades_AlejandroVenegas.Objetos;
using Servidor_AlejandroVenegas;
using Servidor_AlejandroVenegas.ConexionBD;
using Servidor_AlejandroVenegas.Formularios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Tarea2_AlejandroVenegas.ConexionBD;
using Tarea2_AlejandroVenegas.Formularios;

namespace Tarea2_AlejandroVenegas
{
    public partial class BuenPrecio : Form
    {

        public BuenPrecio()
        {
            InitializeComponent();
        }

        public delegate void ClientCarrier(ConexionTcp conexionTcp);
        public event ClientCarrier OnClientConnected;
        public event ClientCarrier OnClientDisconnected;
        public delegate void DataRecieved(ConexionTcp conexionTcp, string data);
        public event DataRecieved OnDataRecieved;

        private TcpListener _tcpListener;
        private Thread _acceptThread;
        private List<ConexionTcp> connectedClients = new List<ConexionTcp>();

        private void MensajeRecibido(ConexionTcp conexionTcp, string datos)
        {
            var paquete = new Paquete(datos);
            string comando = paquete.Comando;
            if (comando == "registrarCajero")
            {
                string contenido = paquete.Contenido;
                List<string> valores = Mapa.Deserializar(contenido);
                String id = "", nombre = "", ape1 = "", ape2 = "";

                Invoke(new Action(() => id = valores[0]));//Se extrae valor en primera posición del paquete recibido.
                Invoke(new Action(() => nombre = valores[1]));//Se extrae valor en segunda posición del paquete recibido.
                Invoke(new Action(() => ape1 = valores[2]));//Se extrae valor en tercera posición del paquete recibido.
                Invoke(new Action(() => ape2 = valores[3]));//Se extrae valor en cuarta posición del paquete recibido.

                String accion = "Cajero " + id + " acaba de enviar solicitud de registro.";
                Invoke(new Action(() => listBox1.Items.Add(accion)));

                Cajero cajero = new Cajero(id, nombre, ape1, ape2, 0, false);
                CajeroBD bd = new CajeroBD();//Se conecta con base de datos.
                bool respuesta = bd.insertar(cajero);//Se inserta cajero en base de datos.
                if (respuesta)
                {
                    var msgPack = new Paquete("resultado", "Cliente registrado correctamente.");//Se encarga de enviar respuesta a cliente.
                    conexionTcp.EnviarPaquete(msgPack);//Se encarga de enviar respuesta al cliente.

                }
                else
                {
                    var msgPack = new Paquete("resultado", "Error, cliente ya se encuentra registrado de base de datos.");//Se encarga de enviar respuesta a cliente.
                    conexionTcp.EnviarPaquete(msgPack);//Se encarga de enviar respuesta al cliente.

                }
            }
            if (comando == "validarProducto")
            {
                try
                {
                    string contenido = paquete.Contenido;
                    List<String> valores = Mapa.Deserializar(contenido);
                    String producto = "";int cantidad = 0;

                    Invoke(new Action(() => producto = valores[0]));
                    Invoke(new Action(() => cantidad = int.Parse(valores[1])));

                    ProductoBD bd = new ProductoBD();
                    decimal precio = bd.validarProducto(producto, cantidad);

                    var msgPack = new Paquete("precio", precio + "");


                    conexionTcp.EnviarPaquete(msgPack);
                }
                catch (System.FormatException s)
                {
                    Console.WriteLine(s);
                    string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);
                }
            }
            if (comando == "agregarVenta")
            {
                string contenido = paquete.Contenido;
                List<String> valores = Mapa.Deserializar(contenido);
                List<int> listaCantidadProductos = new List<int>();
                List<String> listaDescripcionProductos = new List<String>();

                String codigoCajero = "", fechaVenta = "", montoFinal = "", codigos = "", cantidades = "";

                Invoke(new Action(() => codigoCajero = valores[0]));
                Invoke(new Action(() => fechaVenta = valores[1]));
                Invoke(new Action(() => codigos = valores[2]));
                Invoke(new Action(() => cantidades = valores[3]));
                Invoke(new Action(() => montoFinal = (valores[4])));

                String accion = "Cajero " + codigoCajero + " acaba de enviar solicitud de venta.";
                Invoke(new Action(() => listBox1.Items.Add(accion)));


                string[] listaCantidades = cantidades.Split(' ');
                string[] listaCodigos = codigos.Split('-');


                decimal monto = decimal.Parse(montoFinal + "," + valores[5]);
                for (int i = 0; i < listaCantidades.Length - 1; i++)
                {
                    listaCantidadProductos.Add(int.Parse(listaCantidades[i]));
                    listaDescripcionProductos.Add((listaCodigos[i]));

                }

                VentaBD ventas = new VentaBD();
                bool estaAprobado=ventas.insertar(codigoCajero, fechaVenta, monto, listaDescripcionProductos, listaCantidadProductos);


                if(estaAprobado)
                {
                    var msgPack = new Paquete("Monto total a pagar:", montoFinal + "");
                conexionTcp.EnviarPaquete(msgPack);
            }
                else
                {
                    var msgPack = new Paquete("Error, cajero no está autorizado o no existe..",   "");
                    conexionTcp.EnviarPaquete(msgPack);
                }
            }
        }

        private void ConexionRecibida(ConexionTcp conexionTcp)//Se encarga de recibir conexiones de clientes.
        {
            lock (connectedClients)
                if (!connectedClients.Contains(conexionTcp))//No permite que se vuelva a conectar si ya se encuentra conectado.
                    connectedClients.Add(conexionTcp);
            String accion = "Cliente " + conexionTcp.GetHashCode() + " conectado.";
            Invoke(new Action(() => this.groupBox1.Text = string.Format("Clientes conectados: {0}", connectedClients.Count)));
            Invoke(new Action(() => listBox1.Items.Add(accion)));

        }

        private void ConexionCerrada(ConexionTcp conexionTcp)
        {
            lock (connectedClients)
                if (connectedClients.Contains(conexionTcp))
                {
                    int cliIndex = connectedClients.IndexOf(conexionTcp);
                    connectedClients.RemoveAt(cliIndex);
                }

            String accion = "Cliente " + conexionTcp.GetHashCode() + " desconectado.";
            Invoke(new Action(() => this.groupBox1.Text = string.Format("Clientes conectados: {0}", connectedClients.Count)));
            Invoke(new Action(() => listBox1.Items.Add(accion)));
        }

        private void EscucharClientes(string ipAddress, int port)//Escucha a los clientes.
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
                _tcpListener.Start();
                _acceptThread = new Thread(AceptarClientes);
                _acceptThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        private void AceptarClientes()
        {
            do
            {
                try
                {
                    var conexion = _tcpListener.AcceptTcpClient();
                    var srvClient = new ConexionTcp(conexion)
                    {
                        ReadThread = new Thread(LeerDatos)
                    };
                    srvClient.ReadThread.Start(srvClient);

                    if (OnClientConnected != null)
                        OnClientConnected(srvClient);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }

            } while (true);
        }

        private void LeerDatos(object client)
        {
            var cli = client as ConexionTcp;
            var charBuffer = new List<int>();

            do
            {
                try
                {
                    if (cli == null)
                        break;
                    if (cli.StreamReader.EndOfStream)
                        break;
                    int charCode = cli.StreamReader.Read();
                    if (charCode == -1)
                        break;
                    if (charCode != 0)
                    {
                        charBuffer.Add(charCode);
                        continue;
                    }
                    if (OnDataRecieved != null)
                    {
                        var chars = new char[charBuffer.Count];

                        for (int i = 0; i < charBuffer.Count; i++)
                        {
                            chars[i] = Convert.ToChar(charBuffer[i]);
                        }
                        //Convierte el arreglo de caracteres a una cadena.
                        var message = new string(chars);


                        OnDataRecieved(cli, message);
                    }
                    charBuffer.Clear();
                }
                catch (IOException)
                {
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());

                    break;
                }
            } while (true);

            if (OnClientDisconnected != null)
                OnClientDisconnected(cli);
        }

        public void cerrarServidor()
        {
            Environment.Exit(0);
        }


        private void BuenPrecio_Load(object sender, EventArgs e)
        {
            OnDataRecieved += MensajeRecibido;
            OnClientConnected += ConexionRecibida;
            OnClientDisconnected += ConexionCerrada;
            Invoke(new Action(() => this.groupBox1.Text = string.Format("Clientes conectados: {0}", 0)));

            EscucharClientes("127.0.0.1", 16830);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var form3 = new FormProducto();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form4 = new FormCategoriaProductos();
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form5 = new FormProducto_Categoria();
            form5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form5 = new FormCajero();
            form5.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form5 = new FormHistorialVentas();
            form5.Show();
        }
    }
}
