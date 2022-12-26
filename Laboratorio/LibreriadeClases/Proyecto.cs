using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class Proyecto
    {
        int idproyecto;
        string nombreproyecto;
        DateTime fechainicioproyecto;
        DateTime fechafinproyecto;
        string observacionesproyecto;
        int idestadoproyecto;
        int idResponsableProyecto;
        bool protocolospendientes;
        
        public int Idproyecto { get => idproyecto; set => idproyecto = value; }
        public string Nombreproyecto { get => nombreproyecto; set => nombreproyecto = value; }
        public DateTime Fechainicioproyecto { get => fechainicioproyecto; set => fechainicioproyecto = value; }
        public DateTime Fechafinproyecto { get => fechafinproyecto; set => fechafinproyecto = value; }
        public string Observacionesproyecto { get => observacionesproyecto; set => observacionesproyecto = value; }
        public int Idestadoproyecto { get => idestadoproyecto; set => idestadoproyecto = value; }
        public int IdResponsableProyecto { get => idResponsableProyecto; set => idResponsableProyecto = value; }
        public bool Protocolospendientes { get => protocolospendientes; set => protocolospendientes = value; }

        public Proyecto( string nombre, DateTime fechainicio, DateTime fechafin, string observaciones, int idestadoproyecto, int responsable)
        {
            Nombreproyecto = nombre;
            Fechainicioproyecto = fechainicio;
            Fechafinproyecto = fechafin;
            Observacionesproyecto = observaciones;
            Idestadoproyecto = idestadoproyecto;
            IdResponsableProyecto = responsable;         
        }
        public Proyecto()
        {

        }
    }
}