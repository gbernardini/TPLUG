using BE.Personas;
using System.Data;
using System.Xml.Linq;

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
            var consulta =
                from paseador in XElement.Load("paseadores.xml").Elements("paseador")
                select new PaseadorXML
                {
                    IdPaseador = Convert.ToInt32(Convert.ToString(paseador.Attribute("id").Value).Trim()),
                    Nombre = Convert.ToString(paseador.Element("nombre").Value).Trim(),
                    Apellido = Convert.ToString(paseador.Element("apellido").Value).Trim(),
                    DNI = Convert.ToInt32(paseador.Element("dni").Value.Trim()),
                    CantMascotasMax = Convert.ToInt32(paseador.Element("cantMascotas").Value.Trim())
                };

            List<PaseadorXML> Paseadores = consulta.ToList<PaseadorXML>();
            return Paseadores;
        }

        private void AgregarXML()
        {
            XDocument xmlDoc = XDocument.Load("paseadores.xml");

            xmlDoc.Element("paseadores").Add(new XElement("paseador",
                                        new XAttribute("id", textBox4.Text.Trim()),
                                        new XElement("nombre", textBox1.Text.Trim()),
                                        new XElement("apellido", textBox2.Text.Trim()),
                                        new XElement("dni", textBox3.Text.Trim()),
                                        new XElement("cantMascotas", numericUpDown1.Value.ToString().Trim())));

            xmlDoc.Save("paseadores.xml");
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
            XDocument doc = XDocument.Load("paseadores.xml");

            var consulta = from paseador in doc.Descendants("paseador")
                           where paseador.Attribute("id").Value == id
                           select paseador;
            consulta.Remove();

            doc.Save("paseadores.xml");

            BorrarDatos();
            ActualizarPaseadores();
        }

        private void ModificarPaseador(string id)
        {
            XDocument doc = XDocument.Load("paseadores.xml");

            var consulta = from paseador in doc.Descendants("paseador")
                           where paseador.Attribute("id").Value == id
                           select paseador;

            foreach (XElement Nodo in consulta)
            {
                Nodo.Attribute("id").Value = textBox4.Text.Trim();
                Nodo.Element("nombre").Value = textBox1.Text.Trim();
                Nodo.Element("apellido").Value = textBox2.Text.Trim();
                Nodo.Element("dni").Value = textBox3.Text.Trim();
                Nodo.Element("cantMascotas").Value = numericUpDown1.Value.ToString().Trim();
            }

            doc.Save("paseadores.xml");
            BorrarDatos();
            ActualizarPaseadores();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var consulta =
                from paseador in XElement.Load("paseadores.xml").Elements("paseador")
                where paseador.Element("cantMascotas").Value == numericUpDown2.Value.ToString().Trim()
                select new PaseadorXML

                {
                     IdPaseador = Convert.ToInt32(Convert.ToString(paseador.Attribute("id").Value).Trim()),
                    Nombre = Convert.ToString(paseador.Element("nombre").Value).Trim(),
                    Apellido = Convert.ToString(paseador.Element("apellido").Value).Trim(),
                    DNI = Convert.ToInt32(paseador.Element("dni").Value.Trim()),
                    CantMascotasMax = Convert.ToInt32(paseador.Element("cantMascotas").Value.Trim())
                };

            List<PaseadorXML> Paseadores = consulta.ToList<PaseadorXML>();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = Paseadores;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarPaseadores();
        }
    }
}
