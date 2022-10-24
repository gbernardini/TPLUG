using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Mascotas
{
    public class LoroBE : MascotaBE
    {

        #region Propiedades
        private bool TienePlumas { get; set; } = true;
        private string Idioma { get; set; } = "Castellano";
        #endregion

        #region Constructores
        public LoroBE(string Nombre)
        {
            this.Nombre = Nombre;
            this.Energia = 50;
        }

        public LoroBE(string Nombre, string Idioma, bool TienePlumas)
        {
            this.Nombre = Nombre;
            this.Idioma = Idioma;
            this.Energia = 50;
            this.TienePlumas = TienePlumas;
        }
        #endregion


        public override string ToString()
        {
            return "Loro" + " - " + Nombre;
        }

        public override Hashtable ObtenerHTAlta()
        {
            Hashtable HT = new Hashtable();
            HT.Add("@nombre", Nombre);
            HT.Add("@felicidad", Felicidad);
            HT.Add("@energia", Energia);
            HT.Add("@tieneColaLarga", null);
            HT.Add("@tienePelo", null);
            HT.Add("@tamanio", null);
            HT.Add("@tienePlumas", TienePlumas);
            HT.Add("@idioma", Idioma);
            HT.Add("@clase", 3);
            return HT;
        }
    }
}
