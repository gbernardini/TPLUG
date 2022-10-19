using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace TP1.Modelo.Mascotas
{
    public class PerroBLL: MascotaBLL
    {

        #region Metodos publicos
        public override void Comer(double Cantidad, MascotaBE MascotaBe)
        {
            MascotaBe.Energia += Cantidad * 50;
            base.Comer(Cantidad, MascotaBe);
        }

        public override double ConsumoEnergia(double Distancia, MascotaBE MascotaBe)
        {
            return MascotaBe.Felicidad >= 50 ? Distancia * 3 : Distancia * 5;
        }
        #endregion
    }
}
