using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tarea2_AlejandroVenegas.ConexionBD;
using System.Data.SqlClient;
using Servidor_AlejandroVenegas;
using Entidades_AlejandroVenegas.Objetos;

namespace Tarea2_AlejandroVenegas.Formularios
{
    public partial class FormCajero : Form
    {
        public bool Selected = false;
        List<Cajero> lista;
        int x = 0, y = 22;
        public delegate void ClientCarrier(ConexionTcp conexionTcp);
        public delegate void DataRecieved(ConexionTcp conexionTcp, string data);


        private List<ConexionTcp> connectedClients = new List<ConexionTcp>();

        public bool Selected2 = false;

        public FormCajero()
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
            _id.Text = "Identificación";
            _id.Font = new Font("Arial Black", 8);
            _id.Size = new System.Drawing.Size(100, 20);
            _id.TabIndex = 11;
            _id.Enabled = false;

            TextBox _nombre1 = new TextBox();
            this.panel2.Controls.Add(_nombre1);

            _nombre1.Location = new System.Drawing.Point(x + 100, y);
            _nombre1.Name = "nombre";
            _nombre1.Text = "Nombre";
            _nombre1.Font = new Font("Arial Black", 8);
            _nombre1.Size = new System.Drawing.Size(100, 20);
            _nombre1.TabIndex = 11;
            _nombre1.Enabled = false;


            TextBox _apellido1 = new TextBox();
            this.panel2.Controls.Add(_apellido1);

            _apellido1.Location = new System.Drawing.Point(x + 200, y);
            _apellido1.Name = "apellido1";
            _apellido1.Text = "Apellido 1";
            _apellido1.Font = new Font("Arial Black", 8);
            _apellido1.Size = new System.Drawing.Size(100, 20);
            _apellido1.TabIndex = 11;
            _apellido1.Enabled = false;


            TextBox _apellido2 = new TextBox();
            this.panel2.Controls.Add(_apellido2);

            _apellido2.Location = new System.Drawing.Point(x + 300, y);
            _apellido2.Name = "apellido2";
            _apellido2.Text = "Apellido 2";
            _apellido2.Font = new Font("Arial Black", 8);
            _apellido2.Size = new System.Drawing.Size(100, 20);
            _apellido2.TabIndex = 11;
            _apellido2.Enabled = false;


            TextBox _cajaAsig = new TextBox();
            this.panel2.Controls.Add(_cajaAsig);

            _cajaAsig.Location = new System.Drawing.Point(x + 400, y);
            _cajaAsig.Name = "cajaAsignada";
            _cajaAsig.Text = "Caja Asignada";
            _cajaAsig.Font = new Font("Arial Black", 8);
            _cajaAsig.Size = new System.Drawing.Size(100, 20);
            _cajaAsig.TabIndex = 11;
            _cajaAsig.Enabled = false;

            TextBox _estado = new TextBox();
            this.panel2.Controls.Add(_estado);

            _estado.Location = new System.Drawing.Point(x + 500, y);
            _estado.Name = "estado";
            _estado.Text = "Activo";
            _estado.Font = new Font("Arial Black", 8);
            _estado.Size = new System.Drawing.Size(100, 20);
            _estado.TabIndex = 11;
            _estado.Enabled = false;


            //Tabla 2.

            x = 0;
            y = 0;

            TextBox _id2 = new TextBox();
            this.panel1.Controls.Add(_id2);

            _id2.Location = new System.Drawing.Point(x, y);
            _id2.Name = "Id";
            _id2.Text = "Identificación";
            _id2.Font = new Font("Arial Black", 8);
            _id2.Size = new System.Drawing.Size(100, 20);
            _id2.TabIndex = 11;
            _id2.Enabled = false;

            TextBox _nombre2 = new TextBox();
            this.panel1.Controls.Add(_nombre2);

            _nombre2.Location = new System.Drawing.Point(x + 100, y);
            _nombre2.Name = "nombre";
            _nombre2.Text = "Nombre";
            _nombre2.Font = new Font("Arial Black", 8);
            _nombre2.Size = new System.Drawing.Size(100, 20);
            _nombre2.TabIndex = 11;
            _nombre2.Enabled = false;


            TextBox _apellido1b = new TextBox();
            this.panel1.Controls.Add(_apellido1b);

            _apellido1b.Location = new System.Drawing.Point(x + 200, y);
            _apellido1b.Name = "apellido1";
            _apellido1b.Text = "Apellido 1";
            _apellido1b.Font = new Font("Arial Black", 8);
            _apellido1b.Size = new System.Drawing.Size(100, 20);
            _apellido1b.TabIndex = 11;
            _apellido1b.Enabled = false;


            TextBox _apellido2b = new TextBox();
            this.panel1.Controls.Add(_apellido2b);

            _apellido2b.Location = new System.Drawing.Point(x + 300, y);
            _apellido2b.Name = "apellido2";
            _apellido2b.Text = "Apellido 2";
            _apellido2b.Font = new Font("Arial Black", 8);
            _apellido2b.Size = new System.Drawing.Size(100, 20);
            _apellido2b.TabIndex = 11;
            _apellido2b.Enabled = false;


            TextBox _cajaAsig2 = new TextBox();
            this.panel1.Controls.Add(_cajaAsig2);

            _cajaAsig2.Location = new System.Drawing.Point(x + 400, y);
            _cajaAsig2.Name = "cajaAsignada";
            _cajaAsig2.Text = "Caja Asignada";
            _cajaAsig2.Font = new Font("Arial Black", 8);
            _cajaAsig2.Size = new System.Drawing.Size(100, 20);
            _cajaAsig2.TabIndex = 11;
            _cajaAsig2.Enabled = false;

            TextBox _estado2 = new TextBox();
            this.panel1.Controls.Add(_estado2);

            _estado2.Location = new System.Drawing.Point(x + 500, y);
            _estado2.Name = "estado";
            _estado2.Text = "Activo";
            _estado2.Font = new Font("Arial Black", 8);
            _estado2.Size = new System.Drawing.Size(100, 20);
            _estado2.TabIndex = 11;
            _estado2.Enabled = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (Selected2)
            {
                this.panel1.Controls.Clear(); //Elimina todos los controles del panel.

                x = 0;
                y = 0;

                TextBox _id2 = new TextBox();
                this.panel1.Controls.Add(_id2);

                _id2.Location = new System.Drawing.Point(x, y);
                _id2.Name = "Id";
                _id2.Text = "Identificación";
                _id2.Font = new Font("Arial Black", 8);
                _id2.Size = new System.Drawing.Size(100, 20);
                _id2.TabIndex = 11;
                _id2.Enabled = false;

                TextBox _nombre2 = new TextBox();
                this.panel1.Controls.Add(_nombre2);

                _nombre2.Location = new System.Drawing.Point(x + 100, y);
                _nombre2.Name = "nombre";
                _nombre2.Text = "Nombre";
                _nombre2.Font = new Font("Arial Black", 8);
                _nombre2.Size = new System.Drawing.Size(100, 20);
                _nombre2.TabIndex = 11;
                _nombre2.Enabled = false;


                TextBox _apellido1b = new TextBox();
                this.panel1.Controls.Add(_apellido1b);

                _apellido1b.Location = new System.Drawing.Point(x + 200, y);
                _apellido1b.Name = "apellido1";
                _apellido1b.Text = "Apellido 1";
                _apellido1b.Font = new Font("Arial Black", 8);
                _apellido1b.Size = new System.Drawing.Size(100, 20);
                _apellido1b.TabIndex = 11;
                _apellido1b.Enabled = false;


                TextBox _apellido2b = new TextBox();
                this.panel1.Controls.Add(_apellido2b);

                _apellido2b.Location = new System.Drawing.Point(x + 300, y);
                _apellido2b.Name = "apellido2";
                _apellido2b.Text = "Apellido 2";
                _apellido2b.Font = new Font("Arial Black", 8);
                _apellido2b.Size = new System.Drawing.Size(100, 20);
                _apellido2b.TabIndex = 11;
                _apellido2b.Enabled = false;


                TextBox _cajaAsig2 = new TextBox();
                this.panel1.Controls.Add(_cajaAsig2);

                _cajaAsig2.Location = new System.Drawing.Point(x + 400, y);
                _cajaAsig2.Name = "cajaAsignada";
                _cajaAsig2.Text = "Caja Asignada";
                _cajaAsig2.Font = new Font("Arial Black", 8);
                _cajaAsig2.Size = new System.Drawing.Size(100, 20);
                _cajaAsig2.TabIndex = 11;
                _cajaAsig2.Enabled = false;

                TextBox _estado2 = new TextBox();
                this.panel1.Controls.Add(_estado2);

                _estado2.Location = new System.Drawing.Point(x + 500, y);
                _estado2.Name = "estado";
                _estado2.Text = "Activo";
                _estado2.Font = new Font("Arial Black", 8);
                _estado2.Size = new System.Drawing.Size(100, 20);
                _estado2.TabIndex = 11;
                _estado2.Enabled = false;
            }

            lista = new List<Cajero>();
            CajeroBD conexion = new CajeroBD();
            lista = conexion.listarCajerosNoAprobados();

            if (lista != null)
            {
                this.label3.Text = "Número de registros= " + lista.Count;//Modifica etiqueta para poder visualizar cantidad total de registros en base de datos.
                this.label3.Font = new Font("Arial", 8);
                x = 0;
                y = 23;

                for (int i = 0; i < lista.Count; i++)
                {
                    TextBox id = new TextBox();
                    this.panel1.Controls.Add(id);

                    id.Location = new System.Drawing.Point(x, y);
                    id.Name = "Apellido2";
                    id.Text = lista[i].getIdentificacion();
                    id.Size = new System.Drawing.Size(100, 20);
                    id.TabIndex = 11;
                    id.Enabled = false;

                    TextBox nombre = new TextBox();
                    this.panel1.Controls.Add(nombre);

                    nombre.Location = new System.Drawing.Point(x + 100, y);
                    nombre.Name = "nombre";
                    nombre.Text = lista[i].getNombre();
                    nombre.Size = new System.Drawing.Size(100, 20);
                    nombre.TabIndex = 11;
                    nombre.Enabled = false;

                    TextBox apellido1 = new TextBox();
                    this.panel1.Controls.Add(apellido1);

                    apellido1.Location = new System.Drawing.Point(x + 200, y);
                    apellido1.Name = "apellido1";
                    apellido1.Text = lista[i].getPrimerApellido();
                    apellido1.Size = new System.Drawing.Size(100, 20);
                    apellido1.TabIndex = 11;
                    apellido1.Enabled = false;

                    TextBox apellido2 = new TextBox();
                    this.panel1.Controls.Add(apellido2);

                    apellido2.Location = new System.Drawing.Point(x + 300, y);
                    apellido2.Name = "apellido2";
                    apellido2.Text = lista[i].getSegundoApellido();
                    apellido2.Size = new System.Drawing.Size(100, 20);
                    apellido2.TabIndex = 11;
                    apellido2.Enabled = false;

                    TextBox cajaAsig = new TextBox();
                    this.panel1.Controls.Add(cajaAsig);

                    cajaAsig.Location = new System.Drawing.Point(x + 400, y);
                    cajaAsig.Name = "cajaAsignada";
                    cajaAsig.Text = lista[i].cajaAsignada + "";
                    cajaAsig.Size = new System.Drawing.Size(100, 20);
                    cajaAsig.TabIndex = 11;
                    cajaAsig.Enabled = false;

                    TextBox _estado = new TextBox();
                    this.panel1.Controls.Add(_estado);

                    _estado.Location = new System.Drawing.Point(x + 500, y);
                    _estado.Name = "estado";
                    String activo = lista[i].activo + "";
                    if (activo == "True")
                        _estado.Text = "Sí";
                    else
                        _estado.Text = "No";
                    _estado.Font = new Font("Arial Black", 8);
                    _estado.Size = new System.Drawing.Size(100, 20);
                    _estado.TabIndex = 11;
                    _estado.Enabled = false;


                    y += 20;
                }
                Selected2 = true;
            }

            else
            {
                string message = "Ha ocurrido un error en la carga de registros desde base de datos.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
                if (this.IdAprobar.Text != "" && this.cajaAsig.Text != "")
                {
                    if (int.Parse(this.cajaAsig.Text) ==0)
                    {
                        string message = "Error, No se puede asignar caja cero.";
                        string title = "Mensaje";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        try
                    {
                        CajeroBD c = new CajeroBD();
                        c.aprobarCajero(this.IdAprobar.Text, int.Parse(this.cajaAsig.Text));
                    }
                    catch (System.FormatException s)
                    {
                        Console.WriteLine(s);
                        string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
                        string title = "Mensaje";
                        MessageBox.Show(message, title);
                    }
                    }
                }
                else
                {
                    string message = "Error, debe rellenar todos los campos respectivos.";
                    string title = "Mensaje";
                    MessageBox.Show(message, title);
                }
            }

            catch (SqlException s)
            {
                Console.WriteLine(s);
                string message = "Error en la conexión con la base de datos.";
                string title = "Mensaje";
                MessageBox.Show(message, title);
            }
            catch (System.FormatException s)
            {
                Console.WriteLine(s);
                string message = "Error, debe rellenar todos los campos en el formato correspondiente.";
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
                x = 0;
                y = 0;

                TextBox _id = new TextBox();
                this.panel2.Controls.Add(_id);

                _id.Location = new System.Drawing.Point(x, y);
                _id.Name = "Id";
                _id.Text = "Identificación";
                _id.Font = new Font("Arial Black", 8);
                _id.Size = new System.Drawing.Size(100, 20);
                _id.TabIndex = 11;
                _id.Enabled = false;

                TextBox _nombre1 = new TextBox();
                this.panel2.Controls.Add(_nombre1);

                _nombre1.Location = new System.Drawing.Point(x + 100, y);
                _nombre1.Name = "nombre";
                _nombre1.Text = "Nombre";
                _nombre1.Font = new Font("Arial Black", 8);
                _nombre1.Size = new System.Drawing.Size(100, 20);
                _nombre1.TabIndex = 11;
                _nombre1.Enabled = false;


                TextBox _apellido1 = new TextBox();
                this.panel2.Controls.Add(_apellido1);

                _apellido1.Location = new System.Drawing.Point(x + 200, y);
                _apellido1.Name = "apellido1";
                _apellido1.Text = "Apellido 1";
                _apellido1.Font = new Font("Arial Black", 8);
                _apellido1.Size = new System.Drawing.Size(100, 20);
                _apellido1.TabIndex = 11;
                _apellido1.Enabled = false;


                TextBox _apellido2 = new TextBox();
                this.panel2.Controls.Add(_apellido2);

                _apellido2.Location = new System.Drawing.Point(x + 300, y);
                _apellido2.Name = "apellido2";
                _apellido2.Text = "Apellido 2";
                _apellido2.Font = new Font("Arial Black", 8);
                _apellido2.Size = new System.Drawing.Size(100, 20);
                _apellido2.TabIndex = 11;
                _apellido2.Enabled = false;


                TextBox _cajaAsig = new TextBox();
                this.panel2.Controls.Add(_cajaAsig);

                _cajaAsig.Location = new System.Drawing.Point(x + 400, y);
                _cajaAsig.Name = "cajaAsignada";
                _cajaAsig.Text = "Caja Asignada";
                _cajaAsig.Font = new Font("Arial Black", 8);
                _cajaAsig.Size = new System.Drawing.Size(100, 20);
                _cajaAsig.TabIndex = 11;
                _cajaAsig.Enabled = false;

                TextBox _estado = new TextBox();
                this.panel2.Controls.Add(_estado);

                _estado.Location = new System.Drawing.Point(x + 500, y);
                _estado.Name = "estado";
                _estado.Text = "Activo";
                _estado.Font = new Font("Arial Black", 8);
                _estado.Size = new System.Drawing.Size(100, 20);
                _estado.TabIndex = 11;
                _estado.Enabled = false;

            }

            lista = new List<Cajero>();
            CajeroBD conexion = new CajeroBD();
            lista = conexion.listarCajeros();

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
                    id.Name = "Apellido2";
                    id.Text = lista[i].getIdentificacion();
                    id.Size = new System.Drawing.Size(100, 20);
                    id.TabIndex = 11;
                    id.Enabled = false;

                    TextBox nombre = new TextBox();
                    this.panel2.Controls.Add(nombre);

                    nombre.Location = new System.Drawing.Point(x + 100, y);
                    nombre.Name = "nombre";
                    nombre.Text = lista[i].getNombre();
                    nombre.Size = new System.Drawing.Size(100, 20);
                    nombre.TabIndex = 11;
                    nombre.Enabled = false;

                    TextBox apellido1 = new TextBox();
                    this.panel2.Controls.Add(apellido1);

                    apellido1.Location = new System.Drawing.Point(x + 200, y);
                    apellido1.Name = "apellido1";
                    apellido1.Text = lista[i].getPrimerApellido();
                    apellido1.Size = new System.Drawing.Size(100, 20);
                    apellido1.TabIndex = 11;
                    apellido1.Enabled = false;

                    TextBox apellido2 = new TextBox();
                    this.panel2.Controls.Add(apellido2);

                    apellido2.Location = new System.Drawing.Point(x + 300, y);
                    apellido2.Name = "apellido2";
                    apellido2.Text = lista[i].getSegundoApellido();
                    apellido2.Size = new System.Drawing.Size(100, 20);
                    apellido2.TabIndex = 11;
                    apellido2.Enabled = false;

                    TextBox cajaAsig = new TextBox();
                    this.panel2.Controls.Add(cajaAsig);

                    cajaAsig.Location = new System.Drawing.Point(x + 400, y);
                    cajaAsig.Name = "cajaAsignada";
                    cajaAsig.Text = lista[i].cajaAsignada + "";
                    cajaAsig.Size = new System.Drawing.Size(100, 20);
                    cajaAsig.TabIndex = 11;
                    cajaAsig.Enabled = false;

                    TextBox _estado = new TextBox();
                    this.panel2.Controls.Add(_estado);

                    _estado.Location = new System.Drawing.Point(x + 500, y);
                    _estado.Name = "estado";

                    String activo = lista[i].activo + "";
                    if (activo == "True")
                        _estado.Text = "Sí";
                    else
                        _estado.Text = "No";
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




