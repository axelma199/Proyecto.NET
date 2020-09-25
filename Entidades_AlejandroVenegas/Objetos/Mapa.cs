using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades_AlejandroVenegas.Objetos
{
    public class Mapa
    {
        public static string Serializar(List<string> lista) //Se encarga de serializar los datos respectivos para ser enviados al servidor.
        {
            if (lista.Count == 0)
            {
                return null;
            }

            bool esPrimero = true;
            var salida = new StringBuilder();

            foreach (var linea in lista)
            {
                if (esPrimero)
                {
                    salida.Append(linea);
                    esPrimero = false;
                }
                else
                {
                    salida.Append(string.Format(",{0}", linea));//Se agregan datos según el formato correspondiente.
                }
            }
            return salida.ToString();
        }

        public static List<string> Deserializar(string entrada)//Se encarga de deserializar los datos que vienen desde el servidor hacia el cliente respectivo.
        {
            string str = entrada;
            var lista = new List<string>();

            if (string.IsNullOrEmpty(str))
            {
                return lista;
            }

            try
            {
                foreach (string linea in entrada.Split(','))
                {
                    lista.Add(linea);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }

    }
}
