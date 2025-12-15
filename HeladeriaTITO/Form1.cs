using System.Net;

using Heladeria.Logica;
using Heladeria.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeladeriaTITO
{
    public partial class Form1 : Form
    {
        private Heladeria.Logica.Heladeria miHeladeria = new Heladeria.Logica.Heladeria();
        private List<Tamaño> tamañosDisponibles = new List<Tamaño>();
        private List<Sabor> saboresDisponibles = new List<Sabor>();
        private List<DetallePedido> detallesTemporales = new List<DetallePedido>();

        private int proximoIdCliente = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       



        private void Form1_Load_1(object sender, EventArgs e)
        {
            tamañosDisponibles.Add(new Tamaño { IdTamaño = 1, Nombre = "¼ kg", Gramos = 250, PrecioBase = 1000 });
            tamañosDisponibles.Add(new Tamaño { IdTamaño = 2, Nombre = "½ kg", Gramos = 500, PrecioBase = 1800 });
            tamañosDisponibles.Add(new Tamaño { IdTamaño = 3, Nombre = "1 kg", Gramos = 1000, PrecioBase = 3200 });

            cmbTamaño.DataSource = tamañosDisponibles;
            cmbTamaño.DisplayMember = "Nombre";
            saboresDisponibles.Add(new Sabor { IdSabor = 1, Nombre = "Vainilla", Disponible = true });
            saboresDisponibles.Add(new Sabor { IdSabor = 2, Nombre = "Chocolate", Disponible = true });
            saboresDisponibles.Add(new Sabor { IdSabor = 3, Nombre = "Limón", Disponible = true });
            saboresDisponibles.Add(new Sabor { IdSabor = 4, Nombre = "Menta Granizada", Disponible = true });
            saboresDisponibles.Add(new Sabor { IdSabor = 5, Nombre = "Frutilla", Disponible = true });
            saboresDisponibles.Add(new Sabor { IdSabor = 6, Nombre = "Banana Split", Disponible = true });
            saboresDisponibles.Add(new Sabor { IdSabor = 7, Nombre = "Crema Americana", Disponible = true });

            foreach (var sabor in saboresDisponibles)
            {
                checkedListBox1.Items.Add(sabor);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreCliente = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(nombreCliente))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente");
                return;
            }

            if (detallesTemporales.Count == 0)
            {
                MessageBox.Show("Agregá al menos un ítem al pedido.");
                return;
            }

            Pedido nuevoPedido = new Pedido
            {
                Cliente = new Cliente { Nombre = nombreCliente, IdCliente = proximoIdCliente++ },
                Fecha = DateTime.Now,
                Detalles = new List<DetallePedido>(detallesTemporales)
            };

            miHeladeria.RegistrarPedido(nuevoPedido);

            if (nuevoPedido.Fecha.DayOfWeek == DayOfWeek.Monday)
            {
                MessageBox.Show("Pedido registrado con 10% de descuento por ser lunes.", "Descuento aplicado", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Pedido registrado con éxito.", "Confirmación", MessageBoxButtons.OK);
            }

            // Limpiar campos
            detallesTemporales.Clear();
            lstDetallesPedido.Items.Clear();
            textBox1.Clear();
            cmbTamaño.SelectedIndex = -1;

            // Limpiar checks
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var pedidos = miHeladeria.ListarPedidos();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();


            var datosParaMostrar = pedidos.Select(p => new {
                IdPedido = p.IdPedido,
                Cliente = p.Cliente.Nombre,
                Fecha = p.Fecha.ToShortDateString(),
                Total = p.CalcularTotal(),
            }).ToList();
            dataGridView1.DataSource = datosParaMostrar;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tamaño tamañoMasVendido = miHeladeria.TamañoMasVendido();
            Sabor saborMasPedido = miHeladeria.SaborMasPedido();
            double ticketPromocion = miHeladeria.TicketPromedio();
            double totalDia = miHeladeria.CalcularTotalDelDia(DateTime.Now);

            string TxtTamaño = tamañoMasVendido.Nombre;
            string TxtSabor =saborMasPedido.Nombre;

            if(tamañoMasVendido != null)
            {
                TxtTamaño = tamañoMasVendido.Nombre;
            }else
            {
                TxtTamaño = "Ninguno";
            }
            if (saborMasPedido != null)
            {
                TxtSabor = saborMasPedido.Nombre;
            }
            else
            {
                TxtSabor = "Ninguno";
            }


            string mensajeDescuento = "";

            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                mensajeDescuento = "Se aplicó un 10% de descuento por ser lunes.\n";
            }
            else
            {
                mensajeDescuento = "No hay descuento aplicado hoy.\n";
            }

            string informe = "INFORME: \n\n" +
                mensajeDescuento +
                "Tamaño más vendido: " + TxtTamaño + "\n" +
                "Sabor más pedido: " + TxtSabor + "\n" +
                "Ticket promedio: $" + ticketPromocion + "\n" +
                "Recaudación hoy: $" + totalDia;


            MessageBox.Show(informe, "Informes", MessageBoxButtons.OK);
        }


        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            Tamaño tamañoSeleccionado = cmbTamaño.SelectedItem as Tamaño;

            if (tamañoSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un tamaño.");
                return;
            }

            var saboresSeleccionados = checkedListBox1.CheckedItems.Cast<Sabor>().ToList();

            if (saboresSeleccionados.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos un sabor.");
                return;
            }

            //Precio dividido proporcionalmente
            double precioPorSabor = tamañoSeleccionado.PrecioBase / saboresSeleccionados.Count;

            foreach (Sabor sabor in saboresSeleccionados)
            {
                DetallePedido detalle = new DetallePedido
                {
                    Sabor = sabor,
                    Tamaño = tamañoSeleccionado,
                    PrecioUnitario = precioPorSabor
                };

                detallesTemporales.Add(detalle);
                lstDetallesPedido.Items.Add($"{tamañoSeleccionado.Nombre} de {sabor.Nombre} - ${precioPorSabor}");
            }

            // Limpiar selección
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            cmbTamaño.SelectedIndex = -1;
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
                

            int idPedido = int.Parse(dataGridView1.SelectedRows[0].Cells["IdPedido"].Value.ToString());

            var pedidoSeleccionado = miHeladeria.ListarPedidos().FirstOrDefault(p => p.IdPedido == idPedido);

            if (pedidoSeleccionado != null)
            {
                var detallesAMostrar = pedidoSeleccionado.Detalles.Select(d => new
                {
                    Sabor = d.Sabor.Nombre,
                    Tamaño = d.Tamaño.Nombre,
                    Gramos = d.Tamaño.Gramos,
                    Precio = d.PrecioUnitario
                }).ToList();

                dataGridView2.DataSource = detallesAMostrar;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

        }




















        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstDetallesPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

