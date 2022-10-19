using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Modelo.Mascotas
{
    public class LoroBLL: MascotaBLL
    {
        #region Metodos publicos
        public override void Comer(double Cantidad, MascotaBE MascotaBe)
        {
            MascotaBe.Energia += Cantidad;
            base.Comer(Cantidad, MascotaBe);
        }

        #endregion
    }
}
