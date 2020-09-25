using Entidades_AlejandroVenegas.Objetos;
using Servidor_AlejandroVenegas.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Servidor_AlejandroVenegas.ConexionBD
{
    class VentaBD : Conexion
    {
        public bool insertar(String codCajero, String fechaVenta, decimal montoTotal, List<String> listaDescripcionproductos, List<int> listaCantidadesProductos)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    String estado = validarCajero(codCajero);//Valida si cajero esta autorizado para realizar ventas.

                    conn.Open();

                    if (estado == "True")
                    {

                        String query = "Insert BuenPrecio.dbo.Venta(Codigo_Cajero, Fecha_Venta, Monto_Total) values(@Codigo_Cajero, @Fecha_Venta, @Monto_Total)";
                        SqlCommand newCmd = new SqlCommand(query, conn);

                        newCmd.CommandType = CommandType.Text;
                        newCmd.Parameters.AddWithValue("@Codigo_Cajero", codCajero);
                        newCmd.Parameters.AddWithValue("@Fecha_Venta", fechaVenta);
                        newCmd.Parameters.AddWithValue("@Monto_Total", montoTotal);


                        newCmd.ExecuteNonQuery();


                        for (int i = 0; i < listaDescripcionproductos.Count; i++)
                        {

                            String query2 = "Insert BuenPrecio.dbo.Venta_Producto(Codigo_Venta, Codigo_Producto, Cantidad_Producto) values(convert(int,(SELECT current_value FROM sys.sequences WHERE name = 'secuencia_venta' ) ), @Codigo_Producto, @Cantidad_Producto)";
                            SqlCommand newCmd2 = new SqlCommand(query2, conn);

                            newCmd2.CommandType = CommandType.Text;
                            int codigo = obtenerCodigoProducto(listaDescripcionproductos[i]);
                            newCmd2.Parameters.AddWithValue("@Codigo_Producto", codigo);
                            newCmd2.Parameters.AddWithValue("@Cantidad_Producto", listaCantidadesProductos[i]);


                            newCmd2.ExecuteNonQuery();
                        }

                        conn.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return false;
            }
            catch (System.InvalidOperationException s)
            {
                Console.WriteLine(s);
                return false;
            }


        }

        public String validarCajero(String id)
        {
            string estado = "False";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select estado from BuenPrecio.dbo.Cajero where identificacion='" + id + "';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee  registros en base de datos hasta que se termine.
                    {
                        estado = oReader["estado"].ToString();
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return estado;
        }

        public int obtenerCodigoProducto(String descripcion)
        {
            int codigo = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select codigo from BuenPrecio.dbo.Producto where descripcion='" + descripcion + "';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee  registros en base de datos hasta que se termine.
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

        public Factura listarVentasPorProducto(int codigoVenta)
        {
            Factura factura = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();

                    // Extraer datos de tabla intermedia Venta_Producto.
                    string queryString2 = "select producto.descripcion,venta_producto.Codigo,producto.Codigo,producto.precio,Venta_Producto.cantidad_producto from producto  INNER JOIN venta_producto ON Venta_Producto.Codigo_Producto = producto.Codigo and Venta_Producto.Codigo_Venta =" + codigoVenta + ";";

                    SqlCommand command2 = new SqlCommand(queryString2, connection);
                    SqlDataReader oReader = command2.ExecuteReader();

                    List<int> codigoProductos = new List<int>();
                    List<String> descripcionProductos = new List<String>();
                    List<int> cantidadProductos = new List<int>();
                    List<decimal> precioProductos = new List<decimal>();
                    factura = new Factura(0, new Venta(codigoVenta, "", "", 0), null, null, null, null);
                    int codigo = 0;

                    while (oReader.Read()) //Lee registros en base de datos hasta que se termine.
                    {
                        descripcionProductos.Add(oReader.GetString(0));
                        codigo = oReader.GetInt32(1);
                        codigoProductos.Add(oReader.GetInt32(2));
                        precioProductos.Add(oReader.GetDecimal(3));
                        cantidadProductos.Add(oReader.GetInt32(4));

                    }

                    factura.codigoProductos = codigoProductos;
                    factura.descripcionProductos = descripcionProductos;
                    factura.cantidadProductos = cantidadProductos;
                    factura.precioProductos = precioProductos;
                    factura.codigo = codigo;
                    //Termina extracción desde tabla intermedia. 

                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return factura;

        }

        public List<Venta> listarVentas()
        {
            List<Venta> listaVentas = new List<Venta>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Venta;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee  registros en base de datos hasta que se termine.
                    {
                        Venta venta = new Venta(int.Parse(oReader["Codigo"].ToString()), (oReader["codigo_cajero"].ToString()), (oReader["fecha_venta"].ToString()), decimal.Parse(oReader["monto_total"].ToString()));


                        listaVentas.Add(venta);
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return listaVentas;

        }
        public bool validarExistenciaVenta(int id)
        {
            string estado = "False";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select codigo from BuenPrecio.dbo.venta where codigo=" + id + ";";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee  registros en base de datos hasta que se termine.
                    {
                        estado = oReader["codigo"].ToString();
                    }
                    connection.Close();
                    if (estado == "False")
                    {
                        string message = "Error, venta no existe.";
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
