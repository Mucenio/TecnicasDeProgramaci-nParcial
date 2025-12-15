using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria.Entidad
{
    public class Tamaño
    {
        private int _IdTamaño;
        private string _Nombre;
        private int _Gramos;
        private double _PrecioBase;

        public int IdTamaño
        {
            get { return _IdTamaño; }
            set { _IdTamaño = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public int Gramos
        {
            get { return _Gramos; }
            set { _Gramos = value; }
        }
        public double PrecioBase
        {
            get { return _PrecioBase; }
            set { _PrecioBase = value; }
        }
        public override string ToString()
        {
            return Nombre;
        }

    }
}