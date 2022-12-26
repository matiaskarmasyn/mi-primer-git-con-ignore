using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class Rol
    {
        int idrol;
        string descripcion;

        public int Idrol { get => idrol; set => idrol = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    public Rol(int idrol, string descripcion)
        {
            Idrol = idrol;
            Descripcion = descripcion;
        }
    }
}