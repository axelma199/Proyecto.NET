using Entidades_AlejandroVenegas.Objetos;
using Servidor_AlejandroVenegas.ConexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor_AlejandroVenegas.Formularios
{
    public partial class FormHistorialVentas : Form
    {
        private bool Selected = false;
        List<Venta> lista;
        int x = 0, y = 22;
        public FormHistorialVentas()
        {
            InitializeComponent();

            //
            //Columnas para visualizar información.
            //
            int x = 0;
            int y = 0;

            TextBox _id = new TextBox();
            this.panel2.Controls.Add(_id);

            _id.Location = new System.Drawing.Point(x, y);
            _id.Name = "codigo";
            _id.Text = "Código venta";
            _id.Font = new Font("Arial Black", 8);
            _id.Size = new System.Drawing.Size(100, 20);
            _id.TabIndex = 11;
            _id.Enabled = false;

            TextBox _nombre1 = new TextBox();
            this.panel2.Controls.Add(_nombre1);

            _nombre1.Location = new System.Drawing.Point(x + 100, y);
            _nombre1.Name = "codigoCajero";
            _nombre1.Text = "Id de cajero";
            _nombre1.Font = new Font("Arial Black", 8);
            _nombre1.Size = new System.Drawing.Size(100, 20);
            _nombre1.TabIndex = 11;
            _nombre1.Enabled = false;


            TextBox _apellido1 = new TextBox();
            this.panel2.Controls.Add(_apellido1);

            _apellido1.Location = new System.Drawing.Point(x + 200, y);
            _apellido1.Name = "apellido1";
            _apellido1.Text = "Fecha de venta";
            _apellido1.Font = new Font("Arial Black", 8);
            _apellido1.Size = new System.Drawing.Size(100, 20);
            _apellido1.TabIndex = 11;
            _apellido1.Enabled = false;


            TextBox _estado = new TextBox();
            this.panel2.Controls.Add(_estado);



            _estado.Location = new System.Drawing.Point(x + 300, y);
            _estado.Name = "estado";
            _estado.Text = "Monto total";
            _estado.Font = new Font("Arial Black", 8);
            _estado.Size = new System.Drawing.Size(100, 20);
            _estado.TabIndex = 11;
            _estado.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.codigoVenta.Text != "")
            {
                try
                {
                    VentaBD venta = new VentaBD();
                    bool existe=venta.validarExistenciaVenta(int.Parse(this.codigoVenta.Text));
                    if(existe)
                    {
                        var formLista = new FormListaProductosVenta(int.Parse(this.codigoVenta.Text)); 
                        formLista.Show();
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
            else
            {
                string message = "Error, debe rellenar el campo respectivo.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Selected)
            {

                this.panel2.Controls.Clear(); //Elimina todos los controles del panel.

                //
                //Columnas para visualizar información.
                //
                int x = 0;
                int y = 0;

                TextBox _id = new TextBox();
                this.panel2.Controls.Add(_id);

                _id.Location = new System.Drawing.Point(x, y);
                _id.Name = "codigo";
                _id.Text = "Código venta";
                _id.Font = new Font("Arial Black", 8);
                _id.Size = new System.Drawing.Size(100, 20);
                _id.TabIndex = 11;
                _id.Enabled = false;

                TextBox _nombre1 = new TextBox();
                this.panel2.Controls.Add(_nombre1);

                _nombre1.Location = new System.Drawing.Point(x + 100, y);
                _nombre1.Name = "codigoCajero";
                _nombre1.Text = "Id de cajero";
                _nombre1.Font = new Font("Arial Black", 8);
                _nombre1.Size = new System.Drawing.Size(100, 20);
                _nombre1.TabIndex = 11;
                _nombre1.Enabled = false;


                TextBox _apellido1 = new TextBox();
                this.panel2.Controls.Add(_apellido1);

                _apellido1.Location = new System.Drawing.Point(x + 200, y);
                _apellido1.Name = "apellido1";
                _apellido1.Text = "Fecha de venta";
                _apellido1.Font = new Font("Arial Black", 8);
                _apellido1.Size = new System.Drawing.Size(100, 20);
                _apellido1.TabIndex = 11;
                _apellido1.Enabled = false;

                TextBox _estado = new TextBox();
                this.panel2.Controls.Add(_estado);

                _estado.Location = new System.Drawing.Point(x + 300, y);
                _estado.Name = "estado";
                _estado.Text = "Monto total";
                _estado.Font = new Font("Arial Black", 8);
                _estado.Size = new System.Drawing.Size(100, 20);
                _estado.TabIndex = 11;
                _estado.Enabled = false;
            }

            lista = new List<Venta>();
            VentaBD conexion = new VentaBD();
            lista = conexion.listarVentas();

            if (lista != null)
            {
                this.label12.Text = "Número de registros= " + lista.Count;//Modifica etiqueta para poder visualizar cantidad total de registros en base de datos.
                this.label12.Font = new Font("Arial", 8);
                x = 0;
                y = 23;

                for (int i = 0; i < lista.Count; i++)
                {



                    TextBox _id = new TextBox();
                    this.panel2.Controls.Add(_id);

                    _id.Location = new System.Drawing.Point(x, y);
                    _id.Name = "codigo";
                    _id.Text = lista[i].codigo + "";
                    _id.Font = new Font("Arial Black", 8);
                    _id.Size = new System.Drawing.Size(100, 20);
                    _id.TabIndex = 11;
                    _id.Enabled = false;

                    TextBox _nombre1 = new TextBox();
                    this.panel2.Controls.Add(_nombre1);

                    _nombre1.Location = new System.Drawing.Point(x + 100, y);
                    _nombre1.Name = "codigoCajero";
                    _nombre1.Text = lista[i].codigoCajero;
                    _nombre1.Font = new Font("Arial Black", 8);
                    _nombre1.Size = new System.Drawing.Size(100, 20);
                    _nombre1.TabIndex = 11;
                    _nombre1.Enabled = false;

                    string[] fecha = lista[i].fechaVenta.Split(' ');//Evita que se lea la hora junto a la fecha.

                    TextBox _apellido1 = new TextBox();
                    this.panel2.Controls.Add(_apellido1);

                    _apellido1.Location = new System.Drawing.Point(x + 200, y);
                    _apellido1.Name = "apellido1";
                    _apellido1.Text = fecha[0];
                    _apellido1.Font = new Font("Arial Black", 8);
                    _apellido1.Size = new System.Drawing.Size(100, 20);
                    _apellido1.TabIndex = 11;
                    _apellido1.Enabled = false;

                    TextBox _estado = new TextBox();
                    this.panel2.Controls.Add(_estado);


                    _estado.Location = new System.Drawing.Point(x + 300, y);
                    _estado.Name = "estado";
                    _estado.Text = lista[i].montoTotal + "";
                    _estado.Font = new Font("Arial Black", 8);
                    _estado.Size = new System.Drawing.Size(100, 20);
                    _estado.TabIndex = 11;
                    _estado.Enabled = false;



                    y += 20;
                }
                Selected = true;
            }

            else
            {
                string message = "Ha ocurrido un error en la carga de registros desde base de datos.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
        }



    }
}