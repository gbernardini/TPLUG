using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Modelo.Mascotas;
using BE;

namespace TP1.Modelo.Personas
{
    public interface IPaseador
    {
        void PasearMascota(MascotaBE MascotaBe, double Distancia);
    }
}
