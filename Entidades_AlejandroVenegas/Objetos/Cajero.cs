using System;

namespace Entidades_AlejandroVenegas.Objetos
{
    [Serializable]
    public class Cajero : Empleado
    {


        public Cajero(String id, String nombre, String apellido1, String apellido2, int numeroCaja, bool activo) : base(id, nombre, apellido1, apellido2)
        {
            cajaAsignada = numeroCaja;
            this.activo = activo;

        }

        public int cajaAsignada
        {
            get; set;

        }

        public bool activo
        {
            get; set;
        }

        public String getIdentificacion()
        {
            return identificacion;
        }


        public String getNombre()
        {
            return nombre;
        }

        public String getPrimerApellido()
        {
            return primerApellido;
        }

        public String getSegundoApellido()
        {
            return segundoApellido;
        }

    }
}
