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
    public class PaseadorMPP : IGestor<PaseadorBE>
    {
        private Acceso AccDatos;
        private Hashtable HT;

        public bool Baja(PaseadorBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(PaseadorBE Objeto)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@nombre", Objeto.Nombre);
            HT.Add("@cantMaxMascotas", Objeto.CantMaxMascotas);
            return AccDatos.Escribir("CrearPaseador", HT);
        }
        public PaseadorBE ListarObjeto(PaseadorBE Objeto)
        {
            throw new NotImplementedException();
        }
        public PaseadorBE ListarObjetoXCodigo(int Codigo)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@codigo", Codigo);
            DataSet Ds = AccDatos.Leer2("ListarPaseadorXCodigo", HT);

            DataRow Row = Ds.Tables[0].Rows[0];
            PaseadorBE Paseador = new PaseadorBE(Row[1].ToString(), Convert.ToInt32(Row[2]));
            Paseador.Codigo = Convert.ToInt32(Row[0]);

            return Paseador;
        }

        public List<PaseadorBE> ListarTodo()
        {
            AccDatos = new Acceso();
            List<PaseadorBE> lista = new List<PaseadorBE>();
            DataSet Ds = AccDatos.Leer2("ListarPaseadores",null);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    PaseadorBE Paseador = new PaseadorBE(fila[1].ToString(), Convert.ToInt32(fila[2]));
                    Paseador.Codigo = Convert.ToInt32(fila[0]);

                    lista.Add(Paseador);
                }
            }

            return lista;
        }

        public bool ExistePaseador(string nombre)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@nombre", nombre);
            return AccDatos.LeerScalar("ExistePaseador", HT);
        }

        public List<PaseoBE> ListarPaseosXEstadoXPaseador(int CodPaseador, int Pendiente)
        {
            AccDatos = new Acceso();
            List<PaseoBE> lista = new List<PaseoBE>();
            HT = new Hashtable();
            HT.Add("@codigo", CodPaseador);
            HT.Add("@estado", Pendiente);
            DataSet Ds = AccDatos.Leer2("ListarPaseoXEstadoXPaseador", HT);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    MascotaMPP MascotaMpp = new MascotaMPP();
                    PaseoBE Paseo = new PaseoBE();
                    Paseo.Codigo = Convert.ToInt32(fila[0]);
                    Paseo.Paseador = ListarObjetoXCodigo(Convert.ToInt32(fila[1]));
                    Paseo.Mascota = MascotaMpp.ListarObjetoXCodigo(Convert.ToInt32(fila[2]));
                    Paseo.Distancia = Convert.ToInt32(fila[3]);
                    Paseo.Pendiente = Convert.ToBoolean(fila[4]);

                    lista.Add(Paseo);
                }
            }

            return lista;
        }

        public bool GuardarPaseo(PaseoBE Paseo)
        {
            string StoreProcedure = "ModificarPaseo";
            HT = new Hashtable();

            if (Paseo.Codigo > 0)
            {
                HT.Add("@codigo", Paseo.Codigo);
            }
            else
            {
                StoreProcedure = "CrearPaseo";
                HT.Add("@codigoPaseador", Paseo.Paseador.Codigo);
                HT.Add("@codigoMascota", Paseo.Mascota.Codigo);
                HT.Add("@distancia", Paseo.Distancia);
            }
            AccDatos = new Acceso();
            return AccDatos.Escribir(StoreProcedure,HT);
        }

        public int ObtenerDistanciaRecorrida(int CodPaseador)
        {
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@codigo", CodPaseador);
            DataSet Ds = AccDatos.Leer2("ObtenerDistanciaRecorridaPaseador", HT);
            int Distancia = 0;
            try
            {
                Distancia = Convert.ToInt32(Ds.Tables[0].Rows[0][0]);
            } catch (Exception ex) { return 0; }
            return Distancia;
        }
    }
}
