using System;

namespace Entidades_AlejandroVenegas.Objetos
{
    [Serializable]
    public class Producto
    {
        public Producto(int _codigo, String _descripcion, decimal _precio, int _cantidad, CategoriaProducto _categoria)
        {
            codigo = _codigo;
            descripcion = _descripcion;
            precio = _precio;
            cantidad = _cantidad;
            categoria = _categoria;
        }
        public int codigo
        {
            get; set;

        }

        public string descripcion
        {
            get; set;

        }

        public decimal precio
        {
            get; set;

        }

        public int cantidad
        {
            get; set;

        }

        public CategoriaProducto categoria
        {
            get; set;

        } 
    }
}
