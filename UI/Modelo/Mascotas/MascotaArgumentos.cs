using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Modelo.Mascotas
{
    public class MascotaArgumentos : EventArgs
    {

        public float CantidadIntentos { get; set; }
        public float Efectividad { get => (PaseosEfectuados / CantidadIntentos)*100; }
        public float PaseosEfectuados { get; set; }

    }
}
