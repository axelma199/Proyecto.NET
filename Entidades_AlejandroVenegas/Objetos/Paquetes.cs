namespace Entidades_AlejandroVenegas.Objetos
{
    public class Paquetes
    {
        public static Paquete respuestaOk(string respuesta) //Comprueba que la respuesta se haya recibido bien.
        {
            return new Paquete(respuesta);
        }

    }
}
