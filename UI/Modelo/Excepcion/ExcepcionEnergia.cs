using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Modelo.Excepcion
{
    public class ExcepcionEnergia : Exception
    {
        public override string Message
        {
            get { return "No tiene energia suficiente para pasear"; }
        }
    }
}
