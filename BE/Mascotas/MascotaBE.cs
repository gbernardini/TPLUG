using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MascotaBE: Entidad, IComparable
    {
        #region Propiedades
        public double Energia { get; set; }
        public double Felicidad { get; set; } = 0;
        public string Nombre { get; set; }

        #endregion

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            else
            {
                MascotaBE M2 = (MascotaBE)obj;
                return Nombre.CompareTo(M2.Nombre);
            }
        }

        public virtual string ToQuery()
        {
            return "";
        }
        public enum TamanioMascota
        {
            Pequenio,
            Mediano,
            Grande
        }
    }
}
