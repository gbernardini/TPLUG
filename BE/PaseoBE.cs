using BE.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PaseoBE : Entidad
    {
        public bool Pendiente { get; set; }
        public int Distancia { get; set; }
        public MascotaBE Mascota { get; set; }
        public PaseadorBE Paseador { get; set; }
    }
}
