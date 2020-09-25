using Entidades_AlejandroVenegas.Objetos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms; 
using Tarea2_AlejandroVenegas.ConexionBD;

namespace Tarea2_AlejandroVenegas.Formularios
{
    public partial class FormCategoriaProductos : Form
    {
        public bool Selected = false;
        List<CategoriaProducto> lista;
        int x = 0, y = 22;

        public FormCategoriaProductos()
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



        }




        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaProducto c = new CategoriaProducto(int.Parse(this.codigo.Text), this.descripción.Text);
                CategoríaProductoBD conexion = new CategoríaProductoBD();
                bool opc = conexion.insertar(c);//Inserta categoría en base de datos.
                if (opc)
                {
                    string message = "Categoría de producto agregada exitosamente.";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);

                }
                else
                {
                    string message = "Error, código de categoría ya existe en base de datos o excede del límite, intente de nuevo.";
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




            }

            lista = new List<CategoriaProducto>();
            CategoríaProductoBD conexion = new CategoríaProductoBD();
            lista = conexion.listarCategorias();

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
