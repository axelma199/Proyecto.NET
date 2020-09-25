using System;
using System.Collections.Generic;

namespace Entidades_AlejandroVenegas.Objetos
{
    [Serializable]
    public class Venta
    {

        public Venta(int codigo, String codigoCajero, String fechaVenta, decimal montoTotal)
        {
            this.codigo = codigo;
            this.codigoCajero = codigoCajero;
            this.fechaVenta = fechaVenta;
            this.montoTotal = montoTotal;

        }

        public int codigo
        {
            get; set;

        }

        public String codigoCajero
        {
            get; set;
        }

        public String fechaVenta
        {
            get; set;

        }

        public decimal montoTotal
        {
            get; set;

        }

    }
}
