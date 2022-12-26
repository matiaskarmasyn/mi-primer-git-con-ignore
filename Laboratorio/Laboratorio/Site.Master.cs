using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Laboratorio.Clases;


namespace Laboratorio
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuariossesion usuariologueado = (Usuariossesion)Session["logueado"];
            LBL_USUARIOLOGUEADO.Text = "El usuario Logueado es "+ usuariologueado.Nombre + " " + usuariologueado.Apellido +" y posee Rol de "+usuariologueado.Descripcionrol;
            switch (usuariologueado.IdRol)
            {
                case 1:
                    LinkNuevoUsuario.Visible = true;
                    break;
                case 2:
                    LinkNuevoUsuario.Visible = false;
                    break;
                case 3:
                    LinkNuevoUsuario.Visible = false;
                    break;
                case 4:
                    LinkEstadistica.Visible = false;
                    break;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["logueado"] == null)
                Response.Redirect("desloguearse.aspx");

        }

        protected void LinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Desloguearse.aspx");
        }

        protected void LinkEstadistica_Click(object sender, EventArgs e)
        {
            Response.Redirect("estadistica.aspx");
        }

        protected void linkAyuda_Click(object sender, EventArgs e)
        {

        }

        protected void LinkNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrarse.aspx");
        }
    }
}