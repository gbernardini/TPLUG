using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE: Entidad
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UsuarioBE (string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
