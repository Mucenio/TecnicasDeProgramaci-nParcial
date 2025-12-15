using Heladeria.Entidad;
using Heladeria.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria.Logica
{
    public class Heladeria
    {
        private List<Pedido> _pedidos = new List<Pedido>();
        private int proximoIdPedido = 1;

        public void RegistrarPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                pedido.IdPedido = proximoIdPedido++;
                _pedidos.Add(pedido);
                Console.WriteLine($"Pedido registrado: Cliente={pedido.Cliente.Nombre}, Detalles={pedido.Detalles.Count}");

            }

        }
        public double CalcularTotalDelDia(DateTime fecha)
        {
            double total = 0;
            foreach (Pedido p in _pedidos)
            {
                if (p.Fecha.Date == fecha.Date)
                {
                    total += p.CalcularTotal();
                }
            }
            return total;
        }
        public Tamaño TamañoMasVendido()
        {
            Dictionary<Tamaño, int> contadorTamaño = new Dictionary<Tamaño, int>();

            foreach (Pedido p in _pedidos)
            {
                foreach (DetallePedido d in p.Detalles)
                {
                    if (!contadorTamaño.ContainsKey(d.Tamaño))
                    {
                        contadorTamaño[d.Tamaño] = 0;
                    }
                    contadorTamaño[d.Tamaño]++;
                }
            }

            Tamaño TamañoMasVendido = null;
            int max = 0;
            foreach (var par in contadorTamaño)
            {
                if (par.Value > max)
                {
                    max = par.Value;
                    TamañoMasVendido = par.Key;
                }
            }
            return TamañoMasVendido;
        }

        public Sabor SaborMasPedido()
        {
            Console.WriteLine("sabor mas vendido!");
            Dictionary<Sabor, int> contadorSabor = new Dictionary<Sabor, int>();

            foreach (Pedido p in _pedidos)
            {
                foreach (DetallePedido d in p.Detalles)
                {
                    if (!contadorSabor.ContainsKey(d.Sabor))
                    {
                        contadorSabor[d.Sabor] = 0;
                    }
                    contadorSabor[d.Sabor]++;
                }
            }

            Sabor SaborMasVendido = null;
            int max = 0;
            foreach (var par in contadorSabor)
            {
                if (par.Value > max)
                {
                    max = par.Value;
                    SaborMasVendido = par.Key;
                }
            }

            return SaborMasVendido;
        }

        public double TicketPromedio()
        {
            if (_pedidos.Count == 0) return 0;

            double total = 0;
            foreach (Pedido p in _pedidos)
            {
                total += p.CalcularTotal();
            }

            return total / _pedidos.Count;
        }
        public List<Pedido> ListarPedidos()
        {
            return _pedidos;
        }

    }
}
