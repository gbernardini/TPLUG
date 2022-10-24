using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.MascotaBE;

namespace BE.Mascotas
{
    public class GatoBE: MascotaBE
    {
        #region Propiedades

        private bool TienePelo { get; set; } = true;
        private TamanioMascota Tamanio { get; set; }
        #endregion

        #region Contructores
        public GatoBE(string Nombre)
        {
            this.Nombre = Nombre;
            this.Tamanio = TamanioMascota.Grande;
            this.Energia = 100;
        }

        public GatoBE(string Nombre, TamanioMascota Tamanio, bool TienePelo)
        {
            this.Nombre = Nombre;
            this.Tamanio = Tamanio;
            this.Energia = 100;
            this.TienePelo = TienePelo;
        }
        #endregion

        public override string ToString()
        {
            return "Gato" + " - " + Nombre;
        }

        public override Hashtable ObtenerHTAlta()
        {
            Hashtable HT = new Hashtable();
            HT.Add("@nombre", Nombre);
            HT.Add("@felicidad", Felicidad);
            HT.Add("@energia", Energia);
            HT.Add("@tienePelo", TienePelo);
            HT.Add("@tamanio", Tamanio.ToString());
            HT.Add("@tienePlumas", null);
            HT.Add("@idioma", null);
            HT.Add("@clase", 2);
            return HT;
        }
    }


}
