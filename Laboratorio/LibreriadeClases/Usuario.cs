using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class Usuario
    {
        int idusuario;
        int idpersona;
        string username;
        string password;
        int idrol;

        public int Idusuario { get => idusuario; set => idusuario = value; }
        public int Idpersona { get => idpersona; set => idpersona = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Idrol { get => idrol; set => idrol = value; }

        public Usuario(int idusuario, int idpersona, string username, string password, int idrol)
        {
            this.idusuario = idusuario;
            this.idpersona = idpersona;
            this.username = username;
            this.password = password;
            this.idrol = idrol;
     
        }
        public Usuario()
        {

        }
    }
}