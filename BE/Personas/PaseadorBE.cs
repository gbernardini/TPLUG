using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Personas
{
    public class PaseadorBE: Entidad
    {
        #region Propiedades

        public string Nombre { get; set; }
        public List<MascotaBE> Mascotas { get; set; } = new List<MascotaBE>();
        public int CantMaxMascotas { get; set; }
        #endregion

        #region Constructor
        public PaseadorBE(string Nombre, int CantMaxMascotas)
        {
            this.Nombre = Nombre;
            this.CantMaxMascotas = CantMaxMascotas;
        }
        #endregion
        public override string ToString()
        {
            return Nombre;
        }
    }
}
