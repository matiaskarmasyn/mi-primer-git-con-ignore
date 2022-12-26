using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class EstadoProyecto
    {
        int idestadoproyecto;
        string descripcionestadoproyecto;

        public int Idestadoproyecto { get => idestadoproyecto; set => idestadoproyecto = value; }
        public string Descripcionestadoproyecto { get => descripcionestadoproyecto; set => descripcionestadoproyecto = value; }

        public EstadoProyecto(int idestadoproyecto, string descripcionestadoproyecto)
        {
            Idestadoproyecto = idestadoproyecto;
            Descripcionestadoproyecto = descripcionestadoproyecto;
        }
    }
}