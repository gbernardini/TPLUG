using Abstraccion;
using BE;
using BE.Personas;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class DuenioMPP : IGestor<DuenioBE>
    {
        private Acceso AccDatos;
        private Hashtable HT;

        public bool Baja(DuenioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(DuenioBE Objeto)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@nombre", Objeto.Nombre);
            HT.Add("@mascotaId", Objeto.Mascota.Codigo);
            return AccDatos.Escribir("CrearDuenio",HT);
        }

        public DuenioBE ListarObjeto(DuenioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public List<DuenioBE> ListarTodo()
        {
            AccDatos = new Acceso();
            List<DuenioBE> lista = new List<DuenioBE>();
            DataSet Ds = AccDatos.Leer2("ListarDuenios", null);
            MascotaMPP MascotaMpp = new MascotaMPP();

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    MascotaBE MascotaBe = MascotaMpp.ListarObjetoXCodigo(Convert.ToInt32(fila[2]));
                    DuenioBE DuenioBe = new DuenioBE(fila[1].ToString(), MascotaBe);
                    DuenioBe.Codigo = Convert.ToInt32(fila[0]);
                    lista.Add(DuenioBe);
                }
            }
           
            return lista;
        }

        public bool ExisteDuenio(string nombre)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@nombre", nombre);
            return AccDatos.LeerScalar("ExisteDuenio", HT);
        }
    }
}
