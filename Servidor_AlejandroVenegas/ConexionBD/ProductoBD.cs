using Entidades_AlejandroVenegas.Objetos;
using Servidor_AlejandroVenegas.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Tarea2_AlejandroVenegas.ConexionBD
{
    class ProductoBD : Conexion
    {
        public bool insertar(Producto c)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    String query = "Insert BuenPrecio.dbo.Producto(codigo, descripcion, precio, cantidad, codigoCategoria) values(@codigo, @descripcion, @precio, @cantidad, @codigoCategoria)";
                    SqlCommand newCmd = new SqlCommand(query, conn);

                    newCmd.CommandType = CommandType.Text;
                    newCmd.Parameters.AddWithValue("@codigo", c.codigo);
                    newCmd.Parameters.AddWithValue("@descripcion", c.descripcion);
                    newCmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(c.precio, CultureInfo.CurrentCulture)); //Convierte precio a decimal para insertarlo en la base de datos.
                    newCmd.Parameters.AddWithValue("@cantidad", c.cantidad);
                    newCmd.Parameters.AddWithValue("@codigoCategoria", c.categoria.codigo);


                    newCmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return false;
            }
            return true;

        }
        public List<Producto> listarProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Producto;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())//Lee registros en base de datos hasta que se termine.
                    {
                        Producto c = new Producto(int.Parse(oReader["Codigo"].ToString()), oReader["Descripcion"].ToString(),
                                                    decimal.Parse(oReader["Precio"].ToString()), int.Parse(oReader["Cantidad"].ToString()), new CategoriaProducto(int.Parse(oReader["codigocategoria"].ToString()),""));

                        listaProductos.Add(c);
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return listaProductos;
        }

        public decimal validarProducto(String Producto, int cantidad)
        {
            decimal precio = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))

                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Producto where descripcion='" + Producto + "' and cantidad>=" + cantidad + ";";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())
                    {
                        precio = decimal.Parse(oReader["Precio"].ToString());

                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return 0;
            }
            return precio;
        }

        public int obtenerCategoriaPorDescripcion(String descripcion)
        {
            int codigo = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))

                {
                    connection.Open();
                    string queryString = "Select codigo from BuenPrecio.dbo.Categoria where descripcion='" + descripcion + "';";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())
                    {
                        codigo = int.Parse(oReader["codigo"].ToString());

                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return 0;
            }
            return codigo;
        }

        public String obtenerDescripcionCategoriaPorCodigo(int codigo)
        {
            String descripcion = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))

                {
                    connection.Open();
                    string queryString = "Select descripcion from BuenPrecio.dbo.Categoria where codigo=" + codigo + ";";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())
                    {
                        descripcion =oReader["descripcion"].ToString();

                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return "";
            }
            return descripcion;
        }

        public List<Producto> listarProductosPorCategoria(String descripcion)
        {
            int codigo = this.obtenerCategoriaPorDescripcion(descripcion);

            List<Producto> listaProductos = new List<Producto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))

                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Producto where codigoCategoria=" + codigo + ";";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())
                    {
                        Producto c = new Producto(int.Parse(oReader["Codigo"].ToString()), oReader["Descripcion"].ToString(),
                                                    decimal.Parse(oReader["Precio"].ToString()), int.Parse(oReader["Cantidad"].ToString()), new CategoriaProducto(int.Parse(oReader["codigocategoria"].ToString()),""));

                        listaProductos.Add(c);
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return listaProductos;

        }



        public bool abastecerInventarioProducto(String descripcion, int cantidad)
        {
            if (validarExistenciaProducto(descripcion))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();

                        String query = "Update BuenPrecio.dbo.Producto set cantidad=cantidad+" + cantidad + " where descripcion='" + descripcion + "';";
                        SqlCommand newCmd = new SqlCommand(query, conn);

                        newCmd.CommandType = CommandType.Text;
                        newCmd.ExecuteNonQuery();

                        conn.Close();

                        string message = "Abastecimiento realizado correctamente.";
                        string title = "Mensaje";
                        MessageBox.Show(message, title);
                    }
                }
                catch (SqlException s)
                {
                    Console.WriteLine(s);
                    return false;
                }
            }
            return true;
        }

        public bool validarExistenciaProducto(String id)
        {
            string estado = "False";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select codigo from BuenPrecio.dbo.producto where descripcion='" + id + "';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee  registros en base de datos hasta que se termine.
                    {
                        estado = oReader["codigo"].ToString();
                    }
                    connection.Close();
                    if (estado == "False")
                    {
                        string message = "Error, producto no existe.";
                        string title = "Mensaje";
                        MessageBox.Show(message, title);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return false;
            }
        }
    }
}
