using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Presentacion_UI
{
    public partial class Ucmail2 : UserControl
    {
        public Ucmail2()
        {
            InitializeComponent();
        }
        public string LabelText { get; set; }
        public string RegexString { get; set; }

        public void CargarCon(string Text, string expresion)
        {
            LabelText = Text;
            RegexString = expresion;
        }
        public bool esValido()
        {
            Regex RegExp = new Regex(RegexString);
            string text = TextBox.Text;
            return RegExp.IsMatch(text);
        }

        public void Limpiar()
        {
            TextBox.Text = "";
        }

        public string Texto()
        {
            return TextBox.Text;
        }
    }
}
