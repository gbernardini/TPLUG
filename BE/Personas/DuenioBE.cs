using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Personas
{
    public class DuenioBE: Entidad
    {
        #region Propiedades
        public string Nombre { get; set; }
        public MascotaBE Mascota { get; set; }
        #endregion

        #region Contructores
        public DuenioBE(string Nombre, MascotaBE Mascota)
        {
            this.Nombre = Nombre;
            this.Mascota = Mascota;
        }
        #endregion
    }
}
