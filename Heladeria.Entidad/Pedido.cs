using Heladeria.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria.Entidad
{
    public class Pedido
    {
        public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

        private int _IdPedido;
        private Cliente _Cliente;
        private DateTime _Fecha;
        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }






        public double CalcularTotal()
        {
            if (Detalles == null || Detalles.Count == 0)
                return 0;

            double total = Detalles.Sum(d => d.PrecioUnitario);

            // aplica descuento si es lunes
            if (Fecha.DayOfWeek == DayOfWeek.Monday)
            {
                total *= 0.9; //10% de descuento
            }

            return total;
        }





    }
}