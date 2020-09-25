using System;

namespace Entidades_AlejandroVenegas.Objetos
{
    [Serializable]
    public class Empleado
    {
        public Empleado(String id, String _nombre, String apellido1, String apellido2)
        {
            identificacion = id;
            nombre = _nombre;
            primerApellido = apellido1;
            segundoApellido = apellido2;
        }

        protected String identificacion
        {
            get; set;
        }

        protected string nombre
        {
            get; set;

        }

        protected string primerApellido
        {
            get; set;

        }

        protected string segundoApellido
        {
            get; set;

        }

    }

}
