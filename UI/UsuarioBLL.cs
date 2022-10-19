using BE;
using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioMPP MPP {get; set;}

        public UsuarioBLL ()
        {
            MPP = new UsuarioMPP ();
        }
        public bool IniciarSesion(UsuarioBE UsuarioBe)
        {
            UsuarioBe.Password = Encriptar(UsuarioBe.Password);
            return MPP.Existe_Usuario(UsuarioBe);
        }
        private string Encriptar(string Password)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Password);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
