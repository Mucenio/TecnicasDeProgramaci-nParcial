using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria.Entidad
{
    public class DetallePedido
    {

        private int _IdDetallePedido;
        private Sabor _Sabor;
        private Tamaño _Tamaño;
        private double _PrecioUnitario;

        public int IdDetallePedido
        {
            get { return _IdDetallePedido; }
            set { _IdDetallePedido = value; }
        }
        public Sabor Sabor
        {
            get { return _Sabor; }
            set { _Sabor = value; }
        }
        public Tamaño Tamaño
        {
            get { return _Tamaño; }
            set { _Tamaño = value; }
        }
        public double PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }





    }
}