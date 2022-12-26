using Laboratorio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MultiView.ActiveViewIndex = 0;
                ConexionDB conexion = new ConexionDB();
                GV_Proyecto.DataSource = conexion.ListartodoslosProyectos();
                GV_Proyecto.DataBind();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void GV_Proyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HF_proyecto.Value = e.CommandArgument.ToString();
            int idproyecto = int.Parse(e.CommandArgument.ToString());
            Usuariossesion usuario = (Usuariossesion)Session["logueado"];
            ConexionDB conexion = new ConexionDB();
            GV_Protocolo.DataSource = conexion.listartodoslosprotocolos(idproyecto);
            GV_Protocolo.DataBind();
            MultiView.ActiveViewIndex = 1;
        }

        protected void GV_Protocolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HF_Protocolo.Value = e.CommandArgument.ToString();
            int idprotocolo = int.Parse(e.CommandArgument.ToString());
            ConexionDB conexion = new ConexionDB();
            GV_ACTIVIDAD.DataSource = conexion.LISTARACTIVIDAD(idprotocolo);
            GV_ACTIVIDAD.DataBind();
            MultiView.ActiveViewIndex = 2;
        }

        protected void backprotocolo_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
        }

        protected void backproyecto_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 0;
        }
    }
}