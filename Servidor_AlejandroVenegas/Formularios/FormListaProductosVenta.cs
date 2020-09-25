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

    public partial class FormListaProductosVenta : Form
    {

        Factura lista;
        int codigoVenta;
        public FormListaProductosVenta(int codigoVenta)
        {
            InitializeComponent();
            this.codigoVenta = codigoVenta;
            //
            //Columnas para visualizar información.
            //
            int x = 0;
            int y = 0;

            TextBox _id = new TextBox();
            this.panel2.Controls.Add(_id);

            _id.Location = new System.Drawing.Point(x, y);
            _id.Name = "codigo";
            _id.Text = "Código";
            _id.Font = new Font("Arial Black", 8);
            _id.Size = new System.Drawing.Size(100, 20);
            _id.TabIndex = 11;
            _id.Enabled = false;



            TextBox _nombre1 = new TextBox();
            this.panel2.Controls.Add(_nombre1);

            _nombre1.Location = new System.Drawing.Point(x + 100, y);
            _nombre1.Name = "codigoCajero";
            _nombre1.Text = "Descripción";
            _nombre1.Font = new Font("Arial Black", 8);
            _nombre1.Size = new System.Drawing.Size(100, 20);
            _nombre1.TabIndex = 11;
            _nombre1.Enabled = false;



            TextBox _apellido1 = new TextBox();
            this.panel2.Controls.Add(_apellido1);

            _apellido1.Location = new System.Drawing.Point(x + 200, y);
            _apellido1.Name = "apellido1";
            _apellido1.Text = "Precio";
            _apellido1.Font = new Font("Arial Black", 8);
            _apellido1.Size = new System.Drawing.Size(100, 20);
            _apellido1.TabIndex = 11;
            _apellido1.Enabled = false;



            TextBox _estado = new TextBox();
            this.panel2.Controls.Add(_estado);


            _estado.Location = new System.Drawing.Point(x + 300, y);
            _estado.Name = "estado";
            _estado.Text = "Cantidad comprada";
            _estado.Font = new Font("Arial Black", 8);
            _estado.Size = new System.Drawing.Size(100, 20);
            _estado.TabIndex = 11;
            _estado.Enabled = false;


            VentaBD conexion = new VentaBD();
            lista = conexion.listarVentasPorProducto(codigoVenta);

            if (lista != null)
            {
                this.label1.Text = this.label1.Text + " " + codigoVenta;
                this.label12.Text = "Número de registros= " + lista.codigoProductos.Count;//Modifica etiqueta para poder visualizar cantidad total de registros en base de datos.
                this.label12.Font = new Font("Arial", 8);
                x = 0;
                y = 23;

                for (int i = 0; i < lista.codigoProductos.Count; i++)
                {



                    TextBox _id2 = new TextBox();
                    this.panel2.Controls.Add(_id2);

                    _id2.Location = new System.Drawing.Point(x, y);
                    _id2.Name = "codigo";
                    _id2.Text = lista.codigoProductos[i] + "";
                    _id2.Font = new Font("Arial Black", 8);
                    _id2.Size = new System.Drawing.Size(100, 20);
                    _id2.TabIndex = 11;
                    _id2.Enabled = false;

                    TextBox _nombre2 = new TextBox();
                    this.panel2.Controls.Add(_nombre2);

                    _nombre2.Location = new System.Drawing.Point(x + 100, y);
                    _nombre2.Name = "codigoCajero";
                    _nombre2.Text = lista.descripcionProductos[i];
                    _nombre2.Font = new Font("Arial Black", 8);
                    _nombre2.Size = new System.Drawing.Size(100, 20);
                    _nombre2.TabIndex = 11;
                    _nombre2.Enabled = false;


                    TextBox apellido1 = new TextBox();
                    this.panel2.Controls.Add(apellido1);

                    apellido1.Location = new System.Drawing.Point(x + 200, y);
                    apellido1.Name = "apellido1";
                    apellido1.Text = lista.precioProductos[i] + "";
                    apellido1.Font = new Font("Arial Black", 8);
                    apellido1.Size = new System.Drawing.Size(100, 20);
                    apellido1.TabIndex = 11;
                    apellido1.Enabled = false;


                    TextBox _estado2 = new TextBox();
                    this.panel2.Controls.Add(_estado2);


                    _estado2.Location = new System.Drawing.Point(x + 300, y);
                    _estado2.Name = "estado";
                    _estado2.Text = lista.cantidadProductos[i] + "";
                    _estado2.Font = new Font("Arial Black", 8);
                    _estado2.Size = new System.Drawing.Size(100, 20);
                    _estado2.TabIndex = 11;
                    _estado2.Enabled = false;



                    y += 20;
                }

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
