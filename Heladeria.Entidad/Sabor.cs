using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria.Entidad
{
    public class Sabor
    {

        private int _IdSabor;
        private String _Nombre;
        private bool _Disponible;

        public int IdSabor
        {
            get { return _IdSabor; }
            set { _IdSabor = value; }
        }
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public bool Disponible
        {
            get { return _Disponible; }
            set { _Disponible = value; }
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}