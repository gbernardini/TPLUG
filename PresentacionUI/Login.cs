using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_UI
{
    public partial class Login : Form
    {
        public delegate void DelLogin();
        public event DelLogin EvLogin;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Usuario = ucmail22.Texto();
            string Password = ucmail23.Texto();
            UsuarioBE UsuarioBe = new UsuarioBE(Usuario, Password);
            UsuarioBLL loginBLL = new UsuarioBLL();

            if (!ucmail22.esValido())
            {
                MessageBox.Show("El mail no cumple con el formato");
                return;
            }
            if (!ucmail23.esValido())
            {
                MessageBox.Show("La contrasenia no cumple con el formato");
                return;
            }
            if (loginBLL.IniciarSesion(UsuarioBe)) {
                EvLogin();
                this.Close();
            } else {
                MessageBox.Show("Credenciales no validas");
            }
        }
    }
}
