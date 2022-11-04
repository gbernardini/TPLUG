using BE.Personas;
using System.Data;
using System.Xml.Linq;
using TP1.Modelo;

namespace Presentacion_UI
{
    public partial class GestionarPaseador : Form
    {
        public GestionarPaseador()
        {
            InitializeComponent();
            ActualizarPaseadores();
        }

        public List<PaseadorXML> LeerXML()
        {
            PaseadorBLL PaseadorBll = new PaseadorBLL();
            return PaseadorBll.ListarPaseadoresXML();
        }

        private void AgregarXML()
        {
            PaseadorBLL PaseadorBll = new PaseadorBLL();
            PaseadorXML PaseadorXml = new PaseadorXML();
            int cantMascotas = 1;
            int dni = 0;
            try { 
                cantMascotas = Convert.ToInt32(numericUpDown1.Value.ToString().Trim());
                dni = Convert.ToInt32(textBox3.Text.Trim());
            } catch {
                MessageBox.Show("Ingrese un DNI valido");
                return;
            }

            if (textBox1.Text == "" | textBox2.Text == "") {
                MessageBox.Show("Complete los campos vacios");
                return;
            }

            PaseadorXml.Nombre = textBox1.Text.Trim();
            PaseadorXml.Apellido = textBox2.Text.Trim();
            PaseadorXml.DNI = dni;
            PaseadorXml.CantMascotasMax = cantMascotas;

            PaseadorBll.AltaPaseadorXML(PaseadorXml);
           
            ActualizarPaseadores();
            BorrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarXML();
        }

        private void ActualizarPaseadores()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = LeerXML();
        }

        private void BorrarDatos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            numericUpDown1.Value = 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaseadorXML Paseador = new PaseadorXML();
            Paseador = (PaseadorXML)dataGridView1.CurrentRow.DataBoundItem;

            textBox1.Text = Paseador.Nombre;
            textBox2.Text = Paseador.Apellido;
            textBox3.Text = Paseador.DNI.ToString();
            textBox4.Text = Paseador.IdPaseador.ToString();
            numericUpDown1.Value = Paseador.CantMascotasMax;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarPaseador(textBox4.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BorrarPaseador(textBox4.Text.Trim());
        }

        private void BorrarPaseador(string id)
        {

            PaseadorBLL PaseadorBll = new PaseadorBLL();
            PaseadorBll.BorrarPaseadorXML(id);
            BorrarDatos();
            ActualizarPaseadores();
        }

        private void ModificarPaseador(string id)
        {
            PaseadorBLL PaseadorBll = new PaseadorBLL();
            PaseadorXML PaseadorXml = new PaseadorXML();
            int cantMascotas = 1;
            int PasId = 0;
            int dni;
            try { 
                cantMascotas = Convert.ToInt32(numericUpDown1.Value.ToString().Trim());
                PasId = Convert.ToInt32(textBox4.Text.Trim());
                dni = Convert.ToInt32(textBox3.Text.Trim());
            } catch {
                MessageBox.Show("Ingrese un datos valido");
                return;
            }

            if (textBox1.Text == "" | textBox2.Text == "")
            {
                MessageBox.Show("Complete los campos vacios");
                return;
            }

            PaseadorXml.IdPaseador = PasId;
            PaseadorXml.Nombre = textBox1.Text.Trim();
            PaseadorXml.Apellido = textBox2.Text.Trim();
            PaseadorXml.DNI = dni;
            PaseadorXml.CantMascotasMax = cantMascotas;

            PaseadorBll.EditarPaseadorXML(PaseadorXml);

            BorrarDatos();
            ActualizarPaseadores();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PaseadorBLL PaseadorBll = new PaseadorBLL();
            string cantMascotas = numericUpDown2.Value.ToString().Trim();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = PaseadorBll.ListarPaseadoresPorMascotasXML(cantMascotas);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarPaseadores();
        }
    }
}
