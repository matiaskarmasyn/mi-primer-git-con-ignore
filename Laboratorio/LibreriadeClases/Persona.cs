using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class Persona
    {
        int idpersona;
        string nombrepersona;
        string apellidopersona;
        int dnipersona;
        public int Idpersona { get => idpersona; set => idpersona = value; }
        public string Nombrepersona { get => nombrepersona; set => nombrepersona = value; }
        public string Apellidopersona { get => apellidopersona; set => apellidopersona = value; }
        public int Dnipersona { get => dnipersona; set => dnipersona = value; }
        public Persona(int id,string nombre,string apellido, int dni)
        {
            idpersona = id;
            nombrepersona = nombre;
            apellidopersona = apellido;
            dnipersona = dni;
        }
        public Persona() 
        { 

        }
    }
}