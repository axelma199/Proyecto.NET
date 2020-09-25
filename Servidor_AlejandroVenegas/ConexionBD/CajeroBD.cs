using Entidades_AlejandroVenegas.Objetos;
using Servidor_AlejandroVenegas.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tarea2_AlejandroVenegas.ConexionBD
{
    class CajeroBD : Conexion
    {

        public bool insertar(Cajero c)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    String query = "Insert BuenPrecio.dbo.Cajero(identificacion, nombre, primerapellido, segundoapellido, cajaasignada,estado) values(@identificacion, @nombre, @primerapellido, @segundoapellido, @cajaasignada,@estado)";
                    SqlCommand newCmd = new SqlCommand(query, conn);

                    newCmd.CommandType = CommandType.Text;
                    newCmd.Parameters.AddWithValue("@identificacion", c.getIdentificacion());
                    newCmd.Parameters.AddWithValue("@nombre", c.getNombre());
                    newCmd.Parameters.AddWithValue("@primerapellido", c.getPrimerApellido());
                    newCmd.Parameters.AddWithValue("@segundoapellido", c.getSegundoApellido());
                    newCmd.Parameters.AddWithValue("@cajaasignada", c.cajaAsignada);
                    newCmd.Parameters.AddWithValue("@estado", c.activo);


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


        public bool validarCajasAsignadas(int caja)
        {
            List<int> listaCajas = new List<int>();
            bool existeCaja = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))

                {
                    connection.Open();
                    string queryString = "Select CajaAsignada from BuenPrecio.dbo.Cajero where CajaAsignada=" + caja + ";";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read())
                    {
                        listaCajas.Add(int.Parse(oReader["CajaAsignada"].ToString()));
                    }
                    connection.Close();
                    if (listaCajas.Count != 0)
                        existeCaja = true;


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return false;
            }
            return existeCaja;

        }
        public List<Cajero> listarCajeros()
        {
            List<Cajero> listaCajeros = new List<Cajero>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Cajero where estado=1;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee registros en base de datos hasta que se termine.
                    {
                        Cajero c = null;
                        if (oReader["estado"].ToString() == "True")
                        {
                            c = new Cajero(oReader["Identificacion"].ToString(), oReader["Nombre"].ToString(),
                                                   oReader["PrimerApellido"].ToString(), oReader["SegundoApellido"].ToString(), int.Parse(oReader["CajaAsignada"].ToString()), true);

                        }
                        else
                        {
                            c = new Cajero(oReader["Identificacion"].ToString(), oReader["Nombre"].ToString(),
                                                     oReader["PrimerApellido"].ToString(), oReader["SegundoApellido"].ToString(), int.Parse(oReader["CajaAsignada"].ToString()), false);

                        }
                        listaCajeros.Add(c);
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return listaCajeros;
        }

        public List<Cajero> listarCajerosNoAprobados() //Extrae de la base de datos solamente a los cajeros no aprobados todavía. 
        {
            List<Cajero> listaCajeros = new List<Cajero>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select * from BuenPrecio.dbo.Cajero where estado=0;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee registros en base de datos hasta que se termine.
                    {
                        bool estado = false;



                        if (oReader["estado"].ToString() == "True")
                            estado = true;



                        Cajero c = new Cajero(oReader["Identificacion"].ToString(), oReader["Nombre"].ToString(),
                                                     oReader["PrimerApellido"].ToString(), oReader["SegundoApellido"].ToString(), int.Parse(oReader["CajaAsignada"].ToString()), estado);

                        listaCajeros.Add(c);
                    }
                    connection.Close();


                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                return null;
            }
            return listaCajeros;
        }

        internal bool aprobarCajero(string id, int cajaAsig)
        {
            if (validarExistenciaCajero(id))
            {
                try
                {
                    if (!validarCajasAsignadas(cajaAsig))
                    {
                        using (SqlConnection conn = new SqlConnection(conexion))
                        {
                            conn.Open();

                            String query = "Update BuenPrecio.dbo.Cajero set estado=1,CajaAsignada=" + cajaAsig + "where identificacion='" + id + "' and estado=0;"; //Aprueba sólo cajeros con estado en cero.
                            SqlCommand newCmd = new SqlCommand(query, conn);

                            newCmd.CommandType = CommandType.Text;

                            newCmd.ExecuteNonQuery();

                            conn.Close();

                            string message = "Aprobación de cajero exitosa.";
                            string title = "Mensaje";
                            MessageBox.Show(message, title);
                        }
                    }
                    else
                    {
                        string message2 = "Error, caja ya esta siendo asignada por otro cliente.";
                        string title2 = "Mensaje";
                        MessageBox.Show(message2, title2);

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

        public bool validarExistenciaCajero(String id)
        {
            string estado = "False";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string queryString = "Select identificacion from BuenPrecio.dbo.cajero where identificacion='" + id + "';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader oReader = command.ExecuteReader();
                    while (oReader.Read()) //Lee  registros en base de datos hasta que se termine.
                    {
                        estado = oReader["identificacion"].ToString();
                    }
                    connection.Close();
                    if (estado == "False")
                    {
                        string message = "Error, cajero no existe.";
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
