
using Presentacion_UI;

namespace TP1
{
    public partial class Inicio : Form
    {
        
        public Inicio()
        {
            InitializeComponent();

            Login formLogin = new Login();
            formLogin.MdiParent = this;
            formLogin.Show();
            formLogin.EvLogin += habilitarMenu;
            menuStrip2.Visible = false;
        }

        private void crearDuenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearDuenio formDuenio = new CrearDuenio();
            formDuenio.MdiParent = this;
            formDuenio.Show();
        }

        private void crearPaseadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPaseador formPaseador = new CrearPaseador();
            formPaseador.MdiParent = this;
            formPaseador.Show();
        }

        private void gestionarMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarMascotas GestionarMascotas = new GestionarMascotas();
            GestionarMascotas.MdiParent = this;
            GestionarMascotas.Show();
        }

        private void mascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenarMascotas OrdenarMascotas = new OrdenarMascotas();
            OrdenarMascotas.MdiParent = this;
            OrdenarMascotas.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void habilitarMenu()
        {
            menuStrip2.Visible = true;
        }

        private void gestionarPaseadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarPaseador GestionarPaseadorFrom = new GestionarPaseador();
            GestionarPaseadorFrom.MdiParent = this;
            GestionarPaseadorFrom.Show();
        }
    }
}