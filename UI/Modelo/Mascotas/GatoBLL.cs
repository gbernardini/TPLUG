using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Modelo.Mascotas
{
    public class GatoBLL: MascotaBLL
    {

        #region Metodos publicos
        public override void Comer(double Cantidad, MascotaBE MascotaBe)
        {
            MascotaBe.Energia += Cantidad * 10;
            base.Comer(Cantidad, MascotaBe);
        }

        public override double ConsumoEnergia(double Distancia, MascotaBE MascotaBe)
        {
            return Distancia * 10;
        }
        #endregion
    }
}
