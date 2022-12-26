using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class Actividad
    { 
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public float Puntaje { get; set; }
        
        public bool Finalizada { get; set; }
        
        public int IdProtocolo { get; set; }

        public Actividad( int Id, string Descripcion, float Puntaje, bool Finalizada, int IdProtocolo)
        {
            
            this.Id = Id;
            this.Descripcion = Descripcion;
            this.Puntaje = Puntaje;
            this.Finalizada = Finalizada;
            this.IdProtocolo = IdProtocolo;
        }
        public Actividad()
        {

        }
    }
}