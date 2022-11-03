using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE.Personas;
using TP1.Modelo;

namespace TP1
{
    public partial class CrearPaseador : Form
    {
        public static List<PaseadorBE>? Paseadores;
        public CrearPaseador()
        {
            InitializeComponent();
            Paseadores = new List<PaseadorBE>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CantMaxMascotas;
            if (!ucmail21.esValido())
            {
                MessageBox.Show("No se puede crear un paseador sin nombre");
                return;
            }

            try
            {
                CantMaxMascotas = Convert.ToInt16(numericUpDown1.Value);
                if (CantMaxMascotas <= 0)
                {
                    MessageBox.Show("No se puede crear un paseador que no pueda pasear mascotas");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese una cantidad valida");
                return;
            }
            PaseadorBE Paseador = new PaseadorBE(ucmail21.Texto(), CantMaxMascotas);
            PaseadorBLL PaseadorBll = new PaseadorBLL();
            PaseadorBll.Alta(Paseador);
            Paseadores.Add(Paseador);
            ucmail21.Limpiar();
            numericUpDown1.Value = 1;      
        }
    }
}
