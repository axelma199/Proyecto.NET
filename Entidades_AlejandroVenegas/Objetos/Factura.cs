using System;
using System.Collections.Generic;

namespace Entidades_AlejandroVenegas.Objetos
{
    [Serializable]
    public class Factura
    {
        public Factura(int codigo, Venta venta, List<int> codigoProductos, List<String> descripcionProductos, List<int> cantidadProductos, List<decimal> precioProductos)
        {
            this.codigo = codigo;
            this.venta = venta;
            this.codigoProductos = codigoProductos;
            this.descripcionProductos = descripcionProductos;
            this.cantidadProductos = cantidadProductos;
            this.precioProductos = precioProductos;
        }
        public int codigo
        {
            get; set;

        }

        public Venta venta
        {
            get; set;

        }

        public List<int> codigoProductos //Lista de códigos de los productos comprados en cierta venta.
        {
            get; set;
        }

        public List<String> descripcionProductos //Lista de descripciones de los productos comprados en cierta venta.
        {
            get; set;
        }

        public List<decimal> precioProductos //Lista de precios de los productos comprados en cierta venta.
        {
            get; set;
        }

        public List<int> cantidadProductos //Lista de cantidades de los productos comprados en cierta venta.
        {
            get; set;
        }

    }
}
