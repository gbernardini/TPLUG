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
            string Usuario = textBox1.Text;
            string Password = textBox2.Text;
            UsuarioBE UsuarioBe = new UsuarioBE(Usuario, Password);
            UsuarioBLL loginBLL = new UsuarioBLL();
            if (loginBLL.IniciarSesion(UsuarioBe)) {
                EvLogin();
                this.Close();
  

            } else {
                MessageBox.Show("Credenciales no validas");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
