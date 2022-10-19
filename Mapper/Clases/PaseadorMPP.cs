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
    public class PaseadorMPP : IGestor<PaseadorBE>
    {
        private Acceso AccDatos;

        public bool Baja(PaseadorBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(PaseadorBE Objeto)
        {
            string Consulta_SQL = string.Empty;

            Consulta_SQL = "Insert into Paseador (nombre, cantMaxMascotas) values('" + Objeto.Nombre + "', '" + Objeto.CantMaxMascotas + "') ";
            AccDatos = new Acceso();
            return AccDatos.Escribir(Consulta_SQL);
        }
        public PaseadorBE ListarObjeto(PaseadorBE Objeto)
        {
            throw new NotImplementedException();
        }
        public PaseadorBE ListarObjetoXCodigo(int Codigo)
        {
            string Consulta_SQL = string.Empty;
            string Consulta = "SELECT * FROM Paseador P WHERE P.paseadorId = '" + Codigo + "'";
            AccDatos = new Acceso();
            DataSet Ds = AccDatos.Leer2(Consulta);

            DataRow Row = Ds.Tables[0].Rows[0];
            PaseadorBE Paseador = new PaseadorBE(Row[1].ToString(), Convert.ToInt32(Row[2]));
            Paseador.Codigo = Convert.ToInt32(Row[0]);

            return Paseador;
        }

        public List<PaseadorBE> ListarTodo()
        {
            string Consulta_SQL = string.Empty;
            Consulta_SQL = "select * from Paseador";
            AccDatos = new Acceso();
            List<PaseadorBE> lista = new List<PaseadorBE>();
            DataSet Ds = AccDatos.Leer2(Consulta_SQL);

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

        public List<PaseoBE> ListarPaseosXEstadoXPaseador(int CodPaseador, int Pendiente)
        {
            string Consulta_SQL = string.Empty;
            Consulta_SQL = "select * from Paseo P WHERE P.paseadorId = '" + CodPaseador + "' AND P.pendiente = '" + Pendiente + "'";
            AccDatos = new Acceso();
            List<PaseoBE> lista = new List<PaseoBE>();
            DataSet Ds = AccDatos.Leer2(Consulta_SQL);

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
            string Consulta_SQL = string.Empty;

            if (Paseo.Codigo > 0)
            {
                Consulta_SQL = "Update Paseo SET pendiente = 0";
            }
            else
            {
                Consulta_SQL = "Insert into Paseo (paseadorId, mascotaId, distancia, pendiente) values('" + Paseo.Paseador.Codigo + "', '" + Paseo.Mascota.Codigo + "', '" + Paseo.Distancia + "', '" + Paseo.Pendiente + "') ";
            }
            AccDatos = new Acceso();
            return AccDatos.Escribir(Consulta_SQL);
        }

        public int ObtenerDistanciaRecorrida(int CodPaseador)
        {
            string Consulta_SQL = string.Empty;
            Consulta_SQL = "select SUM(P.distancia) from Paseo P WHERE P.paseadorId = '" + CodPaseador + "' AND P.pendiente = 0";
            AccDatos = new Acceso();
            DataSet Ds = AccDatos.Leer2(Consulta_SQL);

            return Ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Ds.Tables[0].Rows[0][0]) : 0;
        }
    }
}
