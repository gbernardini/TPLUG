using System;
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
        private SqlConnection oCnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TPLUG;Integrated Security=True");

        public DataTable Leer(string consulta)
        {
            DataTable tabla = new DataTable();
            try {
                SqlDataAdapter Da = new SqlDataAdapter(consulta, oCnn);
                Da.Fill(tabla);
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally {
                oCnn.Close();
            }
            return tabla;
        }

        public bool LeerScalar(string consulta)
        {
            oCnn.Open();
            SqlCommand cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta > 0;
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public DataSet Leer2(string Consulta_SQL)
        {
            DataSet Ds = new DataSet();
            try {
                SqlDataAdapter Da = new SqlDataAdapter(Consulta_SQL, oCnn);
                Da.Fill(Ds);
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { 
                oCnn.Close();
            }
            return Ds;
        }

        public bool Escribir(string Consulta_SQL)
        {

            oCnn.Open();
            SqlTransaction myTrans;
            SqlCommand Cmd;
            myTrans = oCnn.BeginTransaction();

            try {

                Cmd = new SqlCommand(Consulta_SQL, oCnn);

                Cmd.Transaction = myTrans;

                Cmd.ExecuteNonQuery();

                myTrans.Commit();
                return true;
            }
            catch (SqlException ex) {
                myTrans.Rollback();
                return false;
            }

            finally { 
                oCnn.Close(); 
            }



        }
    }
}
