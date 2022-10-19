using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BE.MascotaBE;
using BE.Mascotas;
using BE.Personas;
using TP1.Modelo;
using TP1.Modelo.Mascotas;

namespace TP1
{
    public partial class CrearDuenio : Form
    {
        private readonly string[] Idiomas = { "Castellano", "Ingles", "Frances" };
        private DuenioBE Dueno;
        public static List<DuenioBE>? Duenios;

        public CrearDuenio()
        {
            InitializeComponent();
            Duenios = new List<DuenioBE>();
        }

        private void CrearDuenio_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(TamanioMascota));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            radioButton1.Checked = true;
            checkBox1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label5.Text = "Tamano";
                checkBox1.Text = "Tiene cola larga";
                comboBox1.DataSource = Enum.GetValues(typeof(TamanioMascota));
                comboBox1.ResetText();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label5.Text = "Tamano";
                checkBox1.Text = "Tiene pelo";
                comboBox1.DataSource = Enum.GetValues(typeof(TamanioMascota));
                comboBox1.ResetText();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label5.Text = "Idioma";
                checkBox1.Text = "Tiene plumas";
                comboBox1.DataSource = (Array)Idiomas;
                comboBox1.ResetText();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MascotaBE Mascota;

            if (textBox1.Text == "")
            {
                MessageBox.Show("No se puede crear un dueno sin nombre");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("No se puede crear una mascota sin nombre");
                return;
            }

            if (radioButton1.Checked)
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    Mascota = new PerroBE(textBox2.Text, (TamanioMascota)Enum.Parse(typeof(TamanioMascota), comboBox1.Text), checkBox1.Checked);
                }
                else
                {
                    Mascota = new PerroBE(textBox2.Text);
                }
            }
            else if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    Mascota = new GatoBE(textBox2.Text, (TamanioMascota)Enum.Parse(typeof(TamanioMascota), comboBox1.Text), checkBox1.Checked);
                }
                else
                {
                    Mascota = new GatoBE(textBox2.Text);
                }
            }
            else
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    Mascota = new LoroBE(textBox2.Text, comboBox1.Text, checkBox1.Checked);
                }
                else
                {
                    Mascota = new LoroBE(textBox2.Text);
                }
            }
            MascotaBLL MascotaBll = MascotaBLL.ObtenerMascota(Mascota);
            if (!MascotaBll.GuardarMascota(Mascota)) { return; }
            Mascota.Codigo = MascotaBll.ObtenerCodigoMascota(Mascota);
            Dueno = new DuenioBE(textBox1.Text, Mascota);
            DuenioBLL DuenioBll = new DuenioBLL();
            DuenioBll.Alta(Dueno, Mascota);
            Duenios.Add(Dueno);

            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.SelectedIndex = 0;
            }

            #region Reset 
            textBox1.Text = "";
            textBox2.Text = "";
            #endregion
        }
    }
}
