using Entidades_AlejandroVenegas.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea2_AlejandroVenegas.ConexionBD;

namespace Tarea2_AlejandroVenegas.Formularios
{
    public partial class FormProducto_Categoria : Form
    {
        public bool Selected = false;
        List<Producto> lista;
        int x = 0, y = 22;

        public FormProducto_Categoria()
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
            _id.Name = "Id";
            _id.Text = "Código";
            _id.Font = new Font("Arial Black", 8);
            _id.Size = new System.Drawing.Size(100, 20);
            _id.TabIndex = 11;
            _id.Enabled = false;

            TextBox _nombre1 = new TextBox();
            this.panel2.Controls.Add(_nombre1);

            _nombre1.Location = new System.Drawing.Point(x + 100, y);
            _nombre1.Name = "nombre";
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


            TextBox _apellido2 = new TextBox();
            this.panel2.Controls.Add(_apellido2);

            _apellido2.Location = new System.Drawing.Point(x + 300, y);
            _apellido2.Name = "apellido2";
            _apellido2.Text = "Cantidad";
            _apellido2.Font = new Font("Arial Black", 8);
            _apellido2.Size = new System.Drawing.Size(100, 20);
            _apellido2.TabIndex = 11;
            _apellido2.Enabled = false;


            TextBox _cajaAsig = new TextBox();
            this.panel2.Controls.Add(_cajaAsig);

            _cajaAsig.Location = new System.Drawing.Point(x + 400, y);
            _cajaAsig.Name = "cajaAsignada";
            _cajaAsig.Text = "Categoría";
            _cajaAsig.Font = new Font("Arial Black", 8);
            _cajaAsig.Size = new System.Drawing.Size(100, 20);
            _cajaAsig.TabIndex = 11;
            _cajaAsig.Enabled = false;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (Selected)
            {

                this.panel2.Controls.Clear(); //Elimina todos los controles del panel.

                //
                //Columnas para visualizar información.
                //
                x = 0;
                y = 0;

                TextBox _id = new TextBox();
                this.panel2.Controls.Add(_id);

                _id.Location = new System.Drawing.Point(x, y);
                _id.Name = "Id";
                _id.Text = "Código";
                _id.Font = new Font("Arial Black", 8);
                _id.Size = new System.Drawing.Size(100, 20);
                _id.TabIndex = 11;
                _id.Enabled = false;

                TextBox _nombre1 = new TextBox();
                this.panel2.Controls.Add(_nombre1);

                _nombre1.Location = new System.Drawing.Point(x + 100, y);
                _nombre1.Name = "nombre";
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


                TextBox _apellido2 = new TextBox();
                this.panel2.Controls.Add(_apellido2);

                _apellido2.Location = new System.Drawing.Point(x + 300, y);
                _apellido2.Name = "apellido2";
                _apellido2.Text = "Cantidad";
                _apellido2.Font = new Font("Arial Black", 8);
                _apellido2.Size = new System.Drawing.Size(100, 20);
                _apellido2.TabIndex = 11;
                _apellido2.Enabled = false;


                TextBox _cajaAsig = new TextBox();
                this.panel2.Controls.Add(_cajaAsig);

                _cajaAsig.Location = new System.Drawing.Point(x + 400, y);
                _cajaAsig.Name = "cajaAsignada";
                _cajaAsig.Text = "Categoría";
                _cajaAsig.Font = new Font("Arial Black", 8);
                _cajaAsig.Size = new System.Drawing.Size(100, 20);
                _cajaAsig.TabIndex = 11;
                _cajaAsig.Enabled = false;

            }

            try
            {

                lista = new List<Producto>();
                ProductoBD conexion = new ProductoBD();
                lista = conexion.listarProductosPorCategoria(this.Categoria.Text);
                if (lista != null)
                {
                    this.label12.Text = "Número de registros= " + lista.Count;//Modifica etiqueta para poder visualizar cantidad total de registros en base de datos.
                    this.label12.Font = new Font("Arial", 8);
                    x = 0;
                    y = 23;

                    for (int i = 0; i < lista.Count; i++)
                    {
                        TextBox id = new TextBox();
                        this.panel2.Controls.Add(id);

                        id.Location = new System.Drawing.Point(x, y);
                        id.Name = "codigo";
                        id.Text = lista[i].codigo + "";
                        id.Size = new System.Drawing.Size(100, 20);
                        id.TabIndex = 11;
                        id.Enabled = false;

                        TextBox nombre = new TextBox();
                        this.panel2.Controls.Add(nombre);

                        nombre.Location = new System.Drawing.Point(x + 100, y);
                        nombre.Name = "descripcion";
                        nombre.Text = lista[i].descripcion;
                        nombre.Size = new System.Drawing.Size(100, 20);
                        nombre.TabIndex = 11;
                        nombre.Enabled = false;

                        TextBox apellido1 = new TextBox();
                        this.panel2.Controls.Add(apellido1);

                        apellido1.Location = new System.Drawing.Point(x + 200, y);
                        apellido1.Name = "precio";
                        apellido1.Text = lista[i].precio + "";
                        apellido1.Size = new System.Drawing.Size(100, 20);
                        apellido1.TabIndex = 11;
                        apellido1.Enabled = false;

                        TextBox apellido2 = new TextBox();
                        this.panel2.Controls.Add(apellido2);

                        apellido2.Location = new System.Drawing.Point(x + 300, y);
                        apellido2.Name = "cantidad";
                        apellido2.Text = lista[i].cantidad + "";
                        apellido2.Size = new System.Drawing.Size(100, 20);
                        apellido2.TabIndex = 11;
                        apellido2.Enabled = false;

                        TextBox cajaAsig = new TextBox();
                        this.panel2.Controls.Add(cajaAsig);

                        String descripcionCategoria = conexion.obtenerDescripcionCategoriaPorCodigo(lista[i].categoria.codigo);

                        cajaAsig.Location = new System.Drawing.Point(x + 400, y);
                        cajaAsig.Name = "categoria";
                        cajaAsig.Text = descripcionCategoria + "";
                        cajaAsig.Size = new System.Drawing.Size(100, 20);
                        cajaAsig.TabIndex = 11;
                        cajaAsig.Enabled = false;
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
            catch (System.FormatException s)
            {
                Console.WriteLine(s);
                string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
                string title = "Mensaje";
                MessageBox.Show(message, title);

                this.label12.Text = "Número de registros= " + 0;//Modifica etiqueta para poder visualizar cantidad total de registros en base de datos.
                this.label12.Font = new Font("Arial", 8);
            }


        }
    }
}
