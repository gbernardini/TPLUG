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
using TP1.Modelo.Mascotas;

namespace PresentacionUI
{
    public partial class OrdenarMascotas : Form
    {
        private List<MascotaBE> Mascotas;
        public OrdenarMascotas()
        {
            InitializeComponent();

            Mascotas = new List<MascotaBE>();
            SetupMascotas();
            CargarListBox(Mascotas);
        }

        private void SetupMascotas()
        {

            PerroBLL MascotaBll = new PerroBLL();
            Mascotas = MascotaBll.ObtenerMascotas();

            if (Mascotas.Count == 0)
            {
                MessageBox.Show("Debe Tener Mascotas cargadas");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Mascotas.Count; i++)
            {
                for (int j = i + 1; j < Mascotas.Count; j++)
                {
                    if (Mascotas[i].Nombre.CompareTo(Mascotas[j].Nombre) == 1)
                    {
                        MascotaBE M2 = Mascotas[i];
                        Mascotas[i] = Mascotas[j];
                        Mascotas[j] = M2;

                    }
                }

            }

            CargarListBox(Mascotas);
        }

        private void CargarListBox(List<MascotaBE> LMascotas)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = Mascotas;
        }
    }
}
