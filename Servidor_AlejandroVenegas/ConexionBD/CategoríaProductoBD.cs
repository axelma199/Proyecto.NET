using Servidor_AlejandroVenegas.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades_AlejandroVenegas.Objetos;

namespace Tarea2_AlejandroVenegas.ConexionBD
{
    class CategoríaProductoBD : Conexion
    {
        public bool insertar(CategoriaProducto c)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    String query = "Insert BuenPrecio.dbo.Categoria(codigo, descripcion) values(@codigo, @descripcion)";
                    SqlCommand newCmd = new SqlCommand(query, conn);

                    newCmd.CommandType = CommandType.Text;
                    newCmd.Parameters.AddWithValue("@codigo", c.codigo);
                    newCmd.Parameters.AddWithValue("@descripcion", c.descripcion);
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
        public List<CategoriaProducto> listarCategorias()
        {
            List<CategoriaProducto> listaCategorias = new List<CategoriaProducto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Categoria;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())//Lee registros en base de datos hasta que se termine.
                    {
                        CategoriaProducto c = new CategoriaProducto(int.Parse(oReader["Codigo"].ToString()), oReader["Descripcion"].ToString());

                        listaCategorias.Add(c);
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return listaCategorias;
        }
    }
}
