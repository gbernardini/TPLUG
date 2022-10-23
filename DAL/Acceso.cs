using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso
    {
        string ConnStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=TPLUG;Integrated Security=True";
        private SqlConnection oCnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TPLUG;Integrated Security=True");
        private SqlTransaction Tranx;
        private SqlCommand Cmd;

        public bool LeerScalar(string Consulta, Hashtable Parametros)
        {
            oCnn.Open();
            Cmd = new SqlCommand(Consulta, oCnn);
            Cmd.CommandType = CommandType.StoredProcedure;
            try {
                if (Parametros != null) {
                    foreach (string dato in Parametros.Keys) {
                        Cmd.Parameters.AddWithValue(dato, Parametros[dato]);
                    }
                }

                int Respuesta = Convert.ToInt32(Cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta > 0;
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public DataSet Leer2(string Consulta, Hashtable Parametros)
        {
            DataSet Ds = new DataSet();
            SqlDataAdapter Da;

            Cmd = new SqlCommand(Consulta, oCnn);
            Cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Da = new SqlDataAdapter(Cmd);
                if (Parametros != null)
                {
                    foreach (string dato in Parametros.Keys)
                    {
                        var test = Parametros[dato];

                        Cmd.Parameters.AddWithValue(dato, test);
                    }
                }
            }
            catch (SqlException ex) { throw ex; return null; }
            catch (Exception ex) { throw ex; return null; }
            finally
            {
                oCnn.Close();
            }
            Da.Fill(Ds);
            return Ds;
        }

        public bool Escribir(string Consulta, Hashtable Parametros)
        {

            if (oCnn.State == ConnectionState.Closed) {
                oCnn.ConnectionString = ConnStr;
                oCnn.Open();
            }
            try {
                Tranx = oCnn.BeginTransaction();
                Cmd = new SqlCommand(Consulta, oCnn, Tranx);
                Cmd.CommandType = CommandType.StoredProcedure;

                if (Parametros != null) {
                    foreach (string dato in Parametros.Keys) {
                        Cmd.Parameters.AddWithValue(dato, Parametros[dato]);
                    }
                }

                int respuesta = Cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;

            }
            catch (SqlException ex)
            {
                Tranx.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                Tranx.Rollback();
                return false;
            }

            finally { 
                oCnn.Close(); 
            }



        }
    }
}
