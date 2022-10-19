using Abstraccion;
using BE;
using BE.Mascotas;
using DAL;
using System;
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

        public bool Baja(MascotaBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(MascotaBE MascotaBe)
        {
            string Consulta_SQL = string.Empty;
            if (MascotaBe.Codigo != 0)
            {
                Consulta_SQL = "Update Mascota SET felicidad = '" + MascotaBe.Felicidad + "', energia = '" + MascotaBe.Energia + "' WHERE mascotaId = '" + MascotaBe.Codigo + "'";
            }

            else
            {
                Consulta_SQL = MascotaBe.ToQuery();
            }
            AccDatos = new Acceso();
            return AccDatos.Escribir(Consulta_SQL);
        }

        public MascotaBE ListarObjeto(MascotaBE Objeto)
        {
            string Consulta_SQL = string.Empty;
            string Consulta = "SELECT * FROM Mascota M WHERE M.nombre = '" + Objeto.Nombre + "'";
            AccDatos = new Acceso(); 
            DataSet Ds = AccDatos.Leer2(Consulta);

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
            string Consulta_SQL = string.Empty;
            string Consulta = "SELECT * FROM Mascota M WHERE M.mascotaId = '" + Codigo + "'";
            AccDatos = new Acceso();
            DataSet Ds = AccDatos.Leer2(Consulta);

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
            string Consulta_SQL = string.Empty;
            Consulta_SQL = "select * from Mascota";
            AccDatos = new Acceso();
            List<MascotaBE> lista = new List<MascotaBE>();
            DataSet Ds = AccDatos.Leer2(Consulta_SQL);

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
