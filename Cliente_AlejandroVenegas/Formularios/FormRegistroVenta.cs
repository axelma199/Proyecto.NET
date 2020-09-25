using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades_AlejandroVenegas.Objetos;
using Cliente_AlejandroVenegas.ConexionTCP;

namespace Cliente_AlejandroVenegas.Formularios
{
    public partial class FormRegistroVenta : Form
    {
        List<String> listaDescripcionProductos;
        List<decimal> listaPrecioProductos;
        List<int> listaCantidadProductos;
        decimal montoTotal = 0;
        decimal precioProd = 0;



        public ConexionTcp conexionTcp;


        public FormRegistroVenta(ConexionTcp conexion)
        {
            conexionTcp = conexion;
            conexionTcp.OnDataRecieved += MensajeRecibido;

            listaDescripcionProductos = new List<String>();
            listaPrecioProductos = new List<decimal>();
            listaCantidadProductos = new List<int>();
            montoTotal = 0;
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Envia al servidor todo los datos sobre la venta.
        {
            try
            {
                estadoConexion.Text = "";
                if (conexionTcp.TcpClient.Connected)
                {

                    if (this.codigoCajero.Text != "" && this.nombreProducto.Text != "" && this.cantidadProducto.Text != "")
                    {
                        for (int i = 0; i < listaDescripcionProductos.Count; i++)
                        {
                            montoTotal += decimal.Parse(listaPrecioProductos[i] + "") * decimal.Parse(listaCantidadProductos[i] + "");
                        }
                        String monto = montoTotal + "";

                        string message = "Monto total a pagar: ";
                        string title = "Mensaje";
                        MessageBox.Show(message + montoTotal, title);
                        int dia = monthCalendar1.SelectionStart.Day;
                        int mes = monthCalendar1.SelectionStart.Month;
                        int año = monthCalendar1.SelectionStart.Year;
                        String fechaVenta = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");

                        String codCajero = this.codigoCajero.Text;
                        String listaCodigos = "";
                        String listaCantidades = "";

                        for (int i = 0; i < listaDescripcionProductos.Count; i++)
                        {
                            listaCodigos += listaDescripcionProductos[i] + "-";
                            listaCantidades += listaCantidadProductos[i] + " ";
                        }




                        var msgPack = new Paquete("agregarVenta", string.Format("{0},{1},{2},{3},{4}", this.codigoCajero.Text, fechaVenta, listaCodigos, listaCantidades, monto));
                        conexionTcp.EnviarPaquete(msgPack);

                        //Se reinicia todo de nuevo
                        this.codigoCajero.Clear();
                        this.nombreProducto.Clear();
                        this.cantidadProducto.Clear();
                        this.precioProducto.Text = "";
                        this.montoTotal = 0;
                        monthCalendar1.SetDate(DateTime.Now);

                        listaDescripcionProductos = new List<String>();
                        listaPrecioProductos = new List<decimal>();
                        listaCantidadProductos = new List<int>();
                        montoTotal = 0;

                    }
                }
                else
                {
                    string message = "Error, debe rellenar todos los campos respectivos.";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);

                }



            }

            catch (System.FormatException s)
            {



                Console.WriteLine(s);
                string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexionTcp.TcpClient != null)
                {
                    if (conexionTcp.TcpClient.Connected)
                    {



                        if (this.nombreProducto.Text != "" && this.cantidadProducto.Text != "")
                        {

                            var msgPack = new Paquete("validarProducto", string.Format("{0},{1}", this.nombreProducto.Text, this.cantidadProducto.Text));
                            conexionTcp.EnviarPaquete(msgPack);


                        }
                        else
                        {

                            string message = "Para agregar producto debe rellenar todos sus campos correspondientes.";
                            string title = "Mensaje";
                            MessageBox.Show(message, title);
                        }
                    }
                }
                else
                {

                    string message = "Error de conexión con el servidor.";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);
                }
            }

            catch (System.FormatException s)
            {
                Console.WriteLine(s);
                string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
            catch (System.NullReferenceException s)
            {
                Console.WriteLine(s);
                string message = "Error de conexión con servidor.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
        }

        private void MensajeRecibido(string datos)
        {
            var paquete = new Paquete(datos);
            string comando = paquete.Comando;
            if (comando == "precio")
            {
                string contenido = paquete.Contenido;


                Invoke(new Action(() => precioProducto.Text = string.Format("Precio: {0}", contenido)));
                if (contenido != "0")
                {
                    if (!validarSiExisteProductoEnLista((this.nombreProducto.Text)))
                    {
                        precioProd = decimal.Parse(contenido);

                        listaDescripcionProductos.Add((this.nombreProducto.Text));
                        listaPrecioProductos.Add(precioProd);

                        listaCantidadProductos.Add(int.Parse(this.cantidadProducto.Text));
                    }
                    else
                    {
                        string message = "Error,el producto con sus cantidades ya está registrado en la lista de compras.";
                        string title = "Mensaje";
                        MessageBox.Show(message, title);

                    }

                }
                else
                {
                    string message = "Error, No hay cantidad suficiente de producto para comprar o este no existe.";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);

                }
            }
            if (comando == "Monto total a pagar")
            {
                string contenido = "Venta realizada correctamente.";
                Invoke(new Action(() => estadoConexion.Text = string.Format("Respuesta: {0}", contenido)));
            }
            if (comando == "Error, cajero no está autorizado o no existe..")
            {
                string contenido = "Error, cajero no está autorizado o no existe.";
                Invoke(new Action(() => estadoConexion.Text = string.Format("Respuesta: {0}", contenido)));
            }

        }

        private bool validarSiExisteProductoEnLista(String descripcion)//Valida si ya un producto está en la lista de compras.
        {
            bool existe = false;
            for (int i = 0; i < listaDescripcionProductos.Count; i++)
            {
                if (descripcion == listaDescripcionProductos[i])
                {
                    existe = true;
                    break; // Cuando lo encuentra se sale del ciclo.
                }
            }
            return existe;
        }

    }
}