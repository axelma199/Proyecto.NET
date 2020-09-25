using System;
using System.Configuration;

namespace Servidor_AlejandroVenegas.Objetos
{
    class Conexion
    { 

        protected String conexion= ConfigurationManager.ConnectionStrings["conexion"].ToString();
    }
}
