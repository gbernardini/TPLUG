using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class UsuarioMPP : IGestor<UsuarioBE>
    {
        private Acceso AccDatos;
        public bool Existe_Usuario(UsuarioBE UsuarioBe)
        {  //instancio un objeto de la clase datos para operar con la BD
            AccDatos = new Acceso();
            string Consulta = "SELECT U.username FROM Usuario U WHERE U.password = '" + UsuarioBe.Password + "' AND U.username = '" + UsuarioBe.Username + "'";
            DataTable Tabla = AccDatos.Leer(Consulta);
            return Tabla.Rows.Count > 0;
        }
        public bool Baja(UsuarioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(UsuarioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public UsuarioBE ListarObjeto(UsuarioBE Objeto)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioBE> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
