using System;
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

        public override string ToQuery()
        {
            return "Insert into Mascota (nombre, energia, felicidad, tienePlumas, idioma, clase) values('" + Nombre + "', '" + Energia + "', '" + Felicidad + "', '" + TienePlumas + "', '" + Idioma + "', '3') ";
        }
    }
}
