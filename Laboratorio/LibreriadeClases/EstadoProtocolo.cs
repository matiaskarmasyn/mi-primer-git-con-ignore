using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Clases
{
    public class EstadoProtocolo
    {
        int idestadoprotocolo;
        string descripcionestadoprotocolo;

        public int Idestadoprotocolo { get => idestadoprotocolo; set => idestadoprotocolo = value; }
        public string Descripcionestadoprotocolo { get => descripcionestadoprotocolo; set => descripcionestadoprotocolo = value; }

        public EstadoProtocolo(int idestadoprotocolo, string descripcionestadoprotocolo)
        {
            Idestadoprotocolo = idestadoprotocolo;
            Descripcionestadoprotocolo = descripcionestadoprotocolo;

        }
    }
}