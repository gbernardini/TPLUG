using Abstraccion;
using BE;
using BE.Mascotas;
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
    public class MascotaMPP : IGestor<MascotaBE>
    {
        private Acceso AccDatos;
        private Hashtable HT;

        public bool Baja(MascotaBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(MascotaBE MascotaBe)
        {
            string StoreProcedure = "ModificarMascota";
            HT = new Hashtable();
            if (MascotaBe.Codigo != 0) {
                HT.Add("@codigo", MascotaBe.Codigo);
                HT.Add("@felicidad", MascotaBe.Felicidad);
                HT.Add("@energia", MascotaBe.Energia);
            } else {
                StoreProcedure = "CrearMascota";
                HT = MascotaBe.ObtenerHTAlta();
            }

            AccDatos = new Acceso();
            return AccDatos.Escribir(StoreProcedure, HT);
        }

        public MascotaBE ListarObjeto(MascotaBE Objeto)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@nombre",Objeto.Nombre);
            DataSet Ds = AccDatos.Leer2("ListarMascotaXNombre", HT);

            DataRow Row = Ds.Tables[0].Rows[0];
            Int32 Clase = Convert.ToInt32(Row[9]);
            MascotaBE Mascota = ObtenerMascotaCargada(Clase, Row);
            Mascota.Energia = Convert.ToInt32(Row[2]);
            Mascota.Felicidad = Convert.ToInt32(Row[3]);
            Mascota.Codigo = Convert.ToInt32(Row[0]);
            
            return Mascota;
        }

        private MascotaBE ObtenerMascotaCargada(Int32 Clase, DataRow row)
        {
            switch (Clase)
            {
                case 1:
                    return new PerroBE(row["nombre"].ToString());
                case 2:
                    return new GatoBE(row["nombre"].ToString());
                default:
                    return new LoroBE(row["nombre"].ToString());
            }
        }
        public MascotaBE ListarObjetoXCodigo(int Codigo)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@codigo", Codigo);
            DataSet Ds = AccDatos.Leer2("ListarMascotaXId", HT);

            DataRow Row = Ds.Tables[0].Rows[0];
            Int32 Clase = Convert.ToInt32(Row[9]);
            MascotaBE Mascota = ObtenerMascotaCargada(Clase, Row);
            Mascota.Energia = Convert.ToInt32(Row[2]);
            Mascota.Felicidad = Convert.ToInt32(Row[3]);
            Mascota.Codigo = Convert.ToInt32(Row[0]);

            return Mascota;
        }
        public List<MascotaBE> ListarTodo()
        {
            AccDatos = new Acceso();
            List<MascotaBE> lista = new List<MascotaBE>();
            DataSet Ds = AccDatos.Leer2("ListarMascotas",null);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Fila in Ds.Tables[0].Rows)
                {
                    Int32 Clase = Convert.ToInt32(Fila[9]);
                    MascotaBE Mascota = ObtenerMascotaCargada(Clase, Fila);
                    Mascota.Energia = Convert.ToInt32(Fila[2]);
                    Mascota.Felicidad = Convert.ToInt32(Fila[3]);
                    Mascota.Codigo = Convert.ToInt32(Fila[0]);
                    lista.Add(Mascota);
                }
            }

            return lista;
        }
    }
}
