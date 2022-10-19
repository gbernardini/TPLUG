using Abstraccion;
using BE;
using BE.Personas;
using DAL;
using System;
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
        public bool Baja(DuenioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(DuenioBE Objeto)
        {
            string Consulta_SQL = string.Empty;

            Consulta_SQL = "Insert into Duenio (nombre, mascotaId) values('" + Objeto.Nombre + "', '" + Objeto.Mascota.Codigo + "') ";
            AccDatos = new Acceso();
            return AccDatos.Escribir(Consulta_SQL);
        }

        public DuenioBE ListarObjeto(DuenioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public List<DuenioBE> ListarTodo()
        {
            string Consulta_SQL = string.Empty;
            Consulta_SQL = "select * from Duenio";
            AccDatos = new Acceso();
            List<DuenioBE> lista = new List<DuenioBE>();
            DataSet Ds = AccDatos.Leer2(Consulta_SQL);
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
    }
}
