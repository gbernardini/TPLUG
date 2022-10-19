using BE;
using BE.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1.Modelo;
using TP1.Modelo.Excepcion;
using TP1.Modelo.Mascotas;

namespace TP1
{
    public partial class GestionarMascotas : Form
    {
        private DuenioBE DuenioSeleccionado;
        private PaseadorBE PaseadorSeleccionado;
        private PaseoBE PaseoSeleccionado;
        List<PaseadorBE> Paseadores;
        List<DuenioBE> Duenios;
        List<PaseoBE> Paseos;
        public GestionarMascotas()
        {
            InitializeComponent();
            CargarPaseadores();
        }

        private void CargarPaseadores()
        {
            DuenioBLL DuenioBll = new DuenioBLL();
            Duenios = DuenioBll.ListarDuenios();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Duenios;

            PaseadorBLL PaseadorBll = new PaseadorBLL();
            Paseadores = PaseadorBll.ListarPaseadores();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Paseadores;

            comboBox1.DataSource = Paseadores;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DuenioSeleccionado = (DuenioBE) dataGridView1.CurrentRow.DataBoundItem;
            CargarEstadoMascota();
        }

        private void CargarEstadoMascota()
        {
            try
            {
                label5.Text = DuenioSeleccionado.Mascota.Nombre;
                label7.Text = DuenioSeleccionado.Mascota.Energia.ToString();
                label8.Text = DuenioSeleccionado.Mascota.Felicidad.ToString();
            }
            catch (Exception)
            {
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DuenioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un entrenador");
                return;
            }
            try
            {
                double Distancia = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese una cantidad valida");
                return;
            }
            if (textBox1.Text != "" )
            {
                double Cantidad = Convert.ToDouble(textBox1.Text);
                DuenioBLL Duenio = new DuenioBLL();
                Duenio.AlimentarMascota(Cantidad, DuenioSeleccionado.Mascota);
                CargarEstadoMascota();
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad de comida");
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DuenioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un entrenador");
                return;
            }

            try
            {
                double Distancia = Convert.ToDouble(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese una distancia valida");
                textBox2.Text = "";
                return;
            }

            if (textBox2.Text != "")
            {
                try
                {
                    DuenioBLL Duenio = new DuenioBLL();
                    Duenio.PasearMascota(DuenioSeleccionado.Mascota, Convert.ToDouble(textBox2.Text));
    
                }
                catch (ExcepcionEnergia ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CargarEstadoMascota();
            }
            else
            {
                MessageBox.Show("Ingrese una distancia para recorrer");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DuenioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un entrenador");
                return;
            }

            if (Paseadores.Count == 0)
            {
                MessageBox.Show("Debe tener paseadores cargados");
                return;
            }
            PaseadorBE PaseadorElegido = Paseadores.ElementAt(comboBox1.SelectedIndex);
            try
            {
                DuenioBLL Duenio = new DuenioBLL();
                Duenio.MandarAPasearCon(PaseadorElegido, DuenioSeleccionado.Mascota, Convert.ToInt32(textBox2.Text));
            } catch (ExcepcionLimiteMascotas ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReflejarEstadistica(MascotaArgumentos e)
        {
            label18.Text = e.CantidadIntentos.ToString();
            label15.Text = e.PaseosEfectuados.ToString();
            label13.Text = e.Efectividad.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaseadorSeleccionado = (PaseadorBE)dataGridView2.CurrentRow.DataBoundItem;
            PaseadorBLL PaseadorBll = new PaseadorBLL();

            RecargarPaseosPendientes();
            RecargarEstadisticaPaseador();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (PaseoSeleccionado == null)
            {
                MessageBox.Show("No hay paseo seleccionado");
                return;
            }
            try
            {
                PaseadorBLL PaseadorBll = new PaseadorBLL();

                PaseadorBll.PasearMascota(PaseoSeleccionado.Mascota, PaseoSeleccionado.Distancia);
                PaseadorSeleccionado.Mascotas.Remove(PaseoSeleccionado.Mascota);
                PaseoSeleccionado.Pendiente = false;
                PaseadorBll.GuardarPaseo(PaseoSeleccionado);
                RecargarPaseosPendientes();
                RecargarEstadisticaPaseador();
            }
            catch (ExcepcionEnergia ex)
            {
                MessageBox.Show(ex.Message);
            }
            CargarEstadoMascota();
        }

        private void RecargarPaseosPendientes()
        {
            PaseadorBLL PaseadorBll = new PaseadorBLL();

            Paseos = PaseadorBll.ListarPaseosXEstadoXPaseador(PaseadorSeleccionado.Codigo, 1);
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Paseos;
        }

        private void RecargarEstadisticaPaseador()
        {
            PaseadorBLL PaseadorBll = new PaseadorBLL();
            label14.Text = PaseadorBll.ListarPaseosXEstadoXPaseador(PaseadorSeleccionado.Codigo, 0).Count.ToString();
            label20.Text = PaseadorBll.ObtenerDistanciaRecorrida(PaseadorSeleccionado.Codigo).ToString();
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaseoSeleccionado = (PaseoBE)dataGridView3.CurrentRow.DataBoundItem;
        }

        
    }
}
