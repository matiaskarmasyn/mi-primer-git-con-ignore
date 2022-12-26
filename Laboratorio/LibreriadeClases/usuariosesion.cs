using System;
namespace Laboratorio.Clases
{
    public class Usuariossesion
    {
        string userName;
        string password;
        int idrol;
        int idpersona;
        string apellido;
        string nombre;
        string descripcionrol;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int IdRol { get => idrol; set => idrol = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Idpersona { get => idpersona; set => idpersona = value; }
        public string Descripcionrol { get => descripcionrol; set => descripcionrol = value; }

        public Usuariossesion(string Us, string pass, int idr, string ape, string nom,int idpersona,string desc_rol)
        {
            userName = Us;
            password = pass;
            idrol = idr;
            apellido = ape;
            nombre = nom;
            this.idpersona = idpersona;
            descripcionrol=desc_rol ;
        }
        public Usuariossesion()
        {

        }
    }
}