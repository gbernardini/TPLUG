using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Mascotas
{
    public class PerroBE: MascotaBE
    {
        #region Propiedades
        private bool TieneColaLarga { get; set; } = true;
        private TamanioMascota Tamanio { get; set; }
        #endregion

        #region Contructores
        public PerroBE(string Nombre)
        {
            this.Nombre = Nombre;
            this.Tamanio = TamanioMascota.Grande;
            this.Energia = 200;
        }

        public PerroBE(string Nombre, TamanioMascota Tamanio, bool TieneColaLarga)
        {
            this.Nombre = Nombre;
            this.Tamanio = Tamanio;
            this.Energia = 200;
            this.TieneColaLarga = TieneColaLarga;
        }
        #endregion

        public override string ToString()
        {
            return "Perro" + " - " + Nombre;
        }

        public override Hashtable ObtenerHTAlta()
        {
            Hashtable HT = new Hashtable();
            HT.Add("@nombre", Nombre);
            HT.Add("@energia", Energia);
            HT.Add("@felicidad", Felicidad);
            HT.Add("@tieneColaLarga", TieneColaLarga);
            HT.Add("@tamanio", Tamanio.ToString());
            HT.Add("@tienePelo", null);
            HT.Add("@tienePlumas", null);
            HT.Add("@idioma", null);
            HT.Add("@clase", 1);
            return HT;
        }
    }
}
