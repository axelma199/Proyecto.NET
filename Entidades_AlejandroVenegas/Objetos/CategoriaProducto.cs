using System;

namespace Entidades_AlejandroVenegas.Objetos
{
    [Serializable]
    public class CategoriaProducto
    {

        public CategoriaProducto(int _codigo, String _descripcion)
        {
            codigo = _codigo;
            descripcion = _descripcion;
        }
        public int codigo
        {
            get; set;
        }

        public string descripcion
        {
            get; set;
        }

    }
}
