using Abstraccion;
using BE;
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
    public class UsuarioMPP : IGestor<UsuarioBE>
    {
        private Acceso AccDatos;
        private Hashtable HT;

        public bool Existe_Usuario(UsuarioBE UsuarioBe)
        {  
            AccDatos = new Acceso();
            HT = new Hashtable();
            HT.Add("@nombreUsuario", UsuarioBe.Username);
            HT.Add("@contrasenia", UsuarioBe.Password);
            return AccDatos.LeerScalar("ExisteUsuario", HT);
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
