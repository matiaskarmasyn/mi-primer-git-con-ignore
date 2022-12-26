using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class Protocolo
    {
        int idprotocolo;
        int idproyecto;
        string nombreprotocolo;
        DateTime fechainicioprotocolo;
        DateTime fechafinprotocolo;
        float puntajeprotocolo;
        int idestado;
        string observacionesprotocolo;
        int idresponsableprotocolo;
        bool actividadesfinalizadas;

        public int Idproyecto { get => idproyecto; set => idproyecto = value; }
        public int Idprotocolo { get => idprotocolo; set => idprotocolo = value; }
        public string Nombreprotocolo { get => nombreprotocolo; set => nombreprotocolo = value; }
        public DateTime Fechainicioprotocolo { get => fechainicioprotocolo; set => fechainicioprotocolo = value; }
        public DateTime Fechafinprotocolo { get => fechafinprotocolo; set => fechafinprotocolo = value; }
        public float Puntajeprotocolo { get => puntajeprotocolo; set => puntajeprotocolo = value; }
        public int Idestado { get => idestado; set => idestado = value; }
        public string Observacionesprotocolo { get => observacionesprotocolo; set => observacionesprotocolo = value; }
       
        public bool Actividadesfinalizadas { get => actividadesfinalizadas; set => actividadesfinalizadas = value; }
        public int Idresponsableprotocolo { get => idresponsableprotocolo; set => idresponsableprotocolo = value; }

        public Protocolo(int idproyecto, string nombre, DateTime fechainicio, DateTime fechafin, float puntaje, int idestado, string observaciones, int responsable)
        {
            this.idproyecto = idproyecto;
            this.nombreprotocolo = nombre;
            this.fechainicioprotocolo = fechainicio;
            this.fechafinprotocolo = fechafin;
            this.puntajeprotocolo = puntaje;
            this.idestado = idestado;
            this.observacionesprotocolo=observaciones;
            this.idresponsableprotocolo = responsable;
        }
        public Protocolo() { }

    }
}