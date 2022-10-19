using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Modelo.Excepcion
{
    public class ExcepcionLimiteMascotas : Exception
    {
        public override string Message
        {
            get { return "No puede exceder el limite de perros a pasear"; }
        }
    }
}
