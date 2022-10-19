using System;
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

        public override string ToQuery()
        {
            return "Insert into Mascota (nombre, energia, felicidad, tienePelo, tamanio, clase) values('" + Nombre + "', '" + Energia + "', '" + Felicidad + "', '" + TienePelo + "', '" + Tamanio.ToString() + "', '2') ";
        }
    }


}
