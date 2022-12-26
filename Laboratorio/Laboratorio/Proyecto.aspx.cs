using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Laboratorio.Clases;
using System.ComponentModel;

namespace Laboratorio
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargargrilla();
            }

            cargarddl();

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Usuariossesion usuario = (Usuariossesion)Session["logueado"];
            if (usuario.IdRol > 2)
                Response.Redirect("rechazado.aspx");
            
               

        }
        protected void BTN_AGREGAR_PROYECTO_Click(object sender, EventArgs e)
        {

            if (HF_EDITARPROYECTO.Value == "")
            {
                string nombreproyecto = TXT_NOMBREPROYECTO.Text;
                string observacionesproyecto = TXT_OBSERVACIONES_PROYECTO.Text;
                DateTime fechafin = DateTime.Parse(FECHAFIN_PROYECTO.SelectedDate.ToString("yyyy-MM-dd"));
                int responsable = int.Parse(DDL_RESPONSABLEPROYECTO.SelectedValue);
                Proyecto nuevoproyecto = new Proyecto(nombreproyecto, DateTime.Today, fechafin, observacionesproyecto, 10, responsable);
                ConexionDB conexion = new ConexionDB();
                conexion.Insertarnuevoproyecto(nuevoproyecto);
                cargargrilla();
                Limpiar();
                PNL_AGREGAR_PROYECTO.Visible = false;
            }
            else
            {
                ConexionDB conexion = new ConexionDB();
                Proyecto modificado = new Proyecto();
                modificado.Idproyecto = int.Parse(HF_EDITARPROYECTO.Value);
                modificado.Nombreproyecto = TXT_NOMBREPROYECTO.Text;
                modificado.Observacionesproyecto = TXT_OBSERVACIONES_PROYECTO.Text;
                modificado.Fechafinproyecto = DateTime.Parse(FECHAFIN_PROYECTO.SelectedDate.ToString("yyyy-MM-dd"));
                modificado.IdResponsableProyecto = int.Parse(DDL_RESPONSABLEPROYECTO.SelectedValue);
                conexion.MODIFICARPROYECTO(modificado);
                cargargrilla();
                PNL_AGREGAR_PROYECTO.Visible = false;
                BTN_AGREGAR_PROYECTO.Text = "Agregar Proyecto";
                Limpiar();

            }
        }
        protected void BTN_CANCELAR_NUEVO_PROYECTO_Click(object sender, ImageClickEventArgs e)
        {
            PNL_AGREGAR_PROYECTO.Visible = false;
            Limpiar();
        }

        protected void BTN_NUEVO_PROYECTO_Click(object sender, EventArgs e)
        {
            PNL_AGREGAR_PROYECTO.Visible = true;
            Limpiar();
            BTN_AGREGAR_PROYECTO.Text = "Agregar Proyecto";
        }

        protected void BTN_iraprotocolos_Click(object sender, EventArgs e)
        {
            Response.Redirect("protocolos.aspx");
        }

        protected void GV_Proyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id_proyecto = int.Parse(e.CommandArgument.ToString());
            ConexionDB conexion = new ConexionDB();
            if (e.CommandName == "ELIMINAR")
            {
                int tieneprotocolos = conexion.tieneprotocolos(id_proyecto);
                if (tieneprotocolos > 0)
                    Response.Write("<script>alert('No se puede eliminar porque tiene protocolos asociados')</script>");
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#MODAL_ELIMINARPROYECTO').modal()", true);
                HF_IDPROYECTO.Value = id_proyecto.ToString();
            }
            if (e.CommandName == "FINALIZAR")
            {
                bool protocolospendientes = conexion.sabersitieneprotocolospendientes(id_proyecto);
                if (protocolospendientes)
                {
                    Response.Write("<script>alert('Tiene Protocolos Pendientes')</script>");
                }
                else
                {
                    conexion.finalizarprotocolosypuntuar(id_proyecto);
                    cargargrilla();
                }

            }
            if (e.CommandName == "RECHAZAR")
            {              
                HF_RECHAZARPROYECTO.Value = id_proyecto.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#MODAL_RECHAZARPROYECTO').modal()", true);
            }

            if (e.CommandName == "EDITAR")
            {
                HF_EDITARPROYECTO.Value = id_proyecto.ToString();
                cargarddl();
                PNL_AGREGAR_PROYECTO.Visible = true;
                Proyecto seleccionado = conexion.ENCONTRARPROYECTO(id_proyecto);
                TXT_NOMBREPROYECTO.Text = seleccionado.Nombreproyecto;
                TXT_OBSERVACIONES_PROYECTO.Text = seleccionado.Observacionesproyecto;
                FECHAFIN_PROYECTO.SelectedDate = (DateTime)seleccionado.Fechafinproyecto;
                DDL_RESPONSABLEPROYECTO.SelectedValue = (string)seleccionado.IdResponsableProyecto.ToString();
                seleccionado.Idproyecto = id_proyecto;
                PNL_AGREGAR_PROYECTO.Visible = true;
                BTN_AGREGAR_PROYECTO.Text = "Modificar Proyecto";
            }
        }

        protected bool PROYECTOFINALIZADO(object DataItem)
        {
            Proyecto aux = DataItem as Proyecto;
            if (aux.Idestadoproyecto == 50)
                return false;
            else return true;
        }
        protected bool ROLADMINISTRADOR()

        {
            Usuariossesion aux = (Usuariossesion)Session["logueado"];
            if (aux.IdRol == 1) return true;
            else return false;
        }

        public void Limpiar()
        {
            TXT_NOMBREPROYECTO.Text = "";
            TXT_OBSERVACIONES_PROYECTO.Text = "";
            FECHAFIN_PROYECTO.SelectedDates.Clear();
            //DDL_RESPONSABLEPROYECTO.SelectedItem.Value = "";
        }

        protected void BTN_ACEPTARELIMINARPROYECTO_Click(object sender, EventArgs e)
        {
            int id_proyecto = int.Parse(HF_IDPROYECTO.Value);
            ConexionDB conexion = new ConexionDB();
            conexion.ELIMINARPROYECTO(id_proyecto);
            cargargrilla();
        }
        public void cargargrilla()
        {
            Usuariossesion usuario = (Usuariossesion)Session["logueado"];
            int idpersona = usuario.Idpersona;
            ConexionDB conexion = new ConexionDB();
            GV_Proyecto.DataSource = conexion.ListarProyectos(idpersona);
            GV_Proyecto.DataBind();
        }
        public void cargarddl()
        {
            Usuariossesion usuario = (Usuariossesion)Session["logueado"];
            ConexionDB conexion = new ConexionDB();
            DDL_RESPONSABLEPROYECTO.DataSource = conexion.listarresponsables(usuario.IdRol, 2);
            DDL_RESPONSABLEPROYECTO.DataValueField = "IdResponsable";
            DDL_RESPONSABLEPROYECTO.DataTextField = "Responsable";
            DDL_RESPONSABLEPROYECTO.DataBind();
        }

        protected void BTN_ACEPTARRECHAZARPROYECTO_Click(object sender, EventArgs e)
        {
            
            ConexionDB conexion = new ConexionDB();
            conexion.rechazarproyecto(int.Parse(HF_RECHAZARPROYECTO.Value));
            cargargrilla();
        }

       
        protected bool proyectofinalizado(int id)
        {
            ConexionDB conexion = new ConexionDB();
            Proyecto Proyectoencontrado = conexion.ENCONTRARPROYECTO(id);
            if (Proyectoencontrado.Idestadoproyecto < 21 )
                return true;
            else
                return false;
        }
    }
}
