using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Laboratorio.Clases;



namespace Laboratorio
{
    public partial class Protocolos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["Id"] != null)
            {

                if (!IsPostBack)
                {
                    //   string idproyecto = this.Request.QueryString["Id"].ToString();
                    // Session["idproyecto"] = idproyecto;
                    cargarddl();
                    LBL_IDPROYECTO.Text = "EL PROYECTO POSEE ID NUMERO " + Session["idproyecto"];
                    cargargrilla();

                }

            }
            else
            {
                ConexionDB conexion = new ConexionDB();
                GV_Protocolo.DataSource = conexion.LISTARPROTOCOLOS(1);
                GV_Protocolo.DataBind();
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.Request.QueryString["Id"] != null)
            {
                int idproyecto = int.Parse(this.Request.QueryString["Id"].ToString());
                Session["idproyecto"] = idproyecto.ToString();
                Usuariossesion usuario = (Usuariossesion)Session["logueado"];
                if (usuario.IdRol > 3)
                    Response.Redirect("rechazado.aspx");
                ConexionDB conexion = new ConexionDB();
                if (usuario.IdRol == 1)
                    BTN_MOSTRARTODOSLOSPROTOCOLOS.Visible = true;

                int estadoproyecto = conexion.get_estadoproyecto(idproyecto);
                if (estadoproyecto < 21)
                    BTN_NUEVO_PROTOCOLO.Enabled = true;
                else
                    BTN_NUEVO_PROTOCOLO.Enabled = false;
            }
        }

        protected void BTN_AGREGAR_PROTOCOLO_Click(object sender, EventArgs e)
        {
            if (HF_EDITARPROTOCOLO.Value == "")
            {
                BTN_AGREGAR_PROTOCOLO.Text = "Agregar Protocolo";
                Protocolo nuevoprotocolo = new Protocolo();
                nuevoprotocolo.Idproyecto = int.Parse(Request.QueryString["Id"]);
                nuevoprotocolo.Nombreprotocolo = TXT_NOMBREPROTOCOLO.Text;
                nuevoprotocolo.Fechainicioprotocolo = DateTime.Today;
                nuevoprotocolo.Fechafinprotocolo = DateTime.Parse(FECHAFIN_PROTOCOLO.SelectedDate.ToString("yyyy-MM-dd"));
                nuevoprotocolo.Observacionesprotocolo = TXT_OBSERVACIONES_PROTOCOLO.Text;
                nuevoprotocolo.Idresponsableprotocolo = int.Parse(DDL_RESPONSABLEPROTOCOLO.SelectedValue);
                nuevoprotocolo.Idestado = 10;
                nuevoprotocolo.Puntajeprotocolo = 0;
                ConexionDB conexion = new ConexionDB();
                conexion.INSERTARPROTOCOLO(nuevoprotocolo);
                PNL_AGREGAR_PROTOCOLO.Visible = false;
                cargargrilla();
                Limpiar();
            }
            else
            {
                Protocolo modificado = new Protocolo();
                modificado.Idprotocolo = int.Parse(HF_EDITARPROTOCOLO.Value);
                modificado.Nombreprotocolo = TXT_NOMBREPROTOCOLO.Text;
                modificado.Fechafinprotocolo = DateTime.Parse(FECHAFIN_PROTOCOLO.SelectedDate.ToString("yyyy-MM-dd"));
                modificado.Observacionesprotocolo = TXT_OBSERVACIONES_PROTOCOLO.Text;
                modificado.Idresponsableprotocolo = int.Parse(DDL_RESPONSABLEPROTOCOLO.SelectedValue);
                ConexionDB conexion = new ConexionDB();
                conexion.MODIFICARPROTOCOLO(modificado);
                cargargrilla();
                Limpiar();
                PNL_AGREGAR_PROTOCOLO.Visible = false;
                BTN_AGREGAR_PROTOCOLO.Text = "Agregar Protocolo";
            }
        }
        protected void BTN_CANCELAR_NUEVO_PROTOCOLO_Click(object sender, ImageClickEventArgs e)
        {
            PNL_AGREGAR_PROTOCOLO.Visible = false;
        }

        protected void BTN_NUEVO_PROTOCOLO_Click(object sender, EventArgs e)
        {
            PNL_AGREGAR_PROTOCOLO.Visible = true;
        }

        protected void BTN_BACK_PROYECTOS_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proyecto.aspx");
        }

        protected void btn_nextctividades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Actividad.aspx");
        }
        protected void GV_Protocolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EDITAR")
            {
                int id_protocolo = int.Parse(e.CommandArgument.ToString());
                HF_EDITARPROTOCOLO.Value = id_protocolo.ToString();
                ConexionDB conexion = new ConexionDB();
                Protocolo seleccionado = conexion.ENCONTRARPROTOCOLO(id_protocolo);
                TXT_NOMBREPROTOCOLO.Text = seleccionado.Nombreprotocolo;
                TXT_OBSERVACIONES_PROTOCOLO.Text = seleccionado.Observacionesprotocolo;
                FECHAFIN_PROTOCOLO.SelectedDate = seleccionado.Fechafinprotocolo;
                DDL_RESPONSABLEPROTOCOLO.SelectedValue = seleccionado.Idresponsableprotocolo.ToString();
                BTN_AGREGAR_PROTOCOLO.Text = "Modificar Protocolo";
                PNL_AGREGAR_PROTOCOLO.Visible = true;
            }
            if (e.CommandName == "ELIMINAR")
            {
                int id_protocolo = int.Parse(e.CommandArgument.ToString());
                HF_ELIMINARPROTOCOLO.Value = e.CommandArgument.ToString();
                ConexionDB conexion = new ConexionDB();
                int tieneactiviades = conexion.tieneactividades(id_protocolo);
                if (tieneactiviades > 0)
                    Response.Write("<script>alert('No se puede eliminar porque tiene Actividades asociadas')</script>");
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#MODAL_ELIMINARPROTOCOLO').modal()", true);
            }
        }
        protected void BTN_ACEPTARELIMINAPROTOCOLO_Click(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();
            conexion.ELIMINARPROTOCOLO(int.Parse(HF_ELIMINARPROTOCOLO.Value));
            cargargrilla();
            HF_ELIMINARPROTOCOLO.Value = "";
        }
        public void Limpiar()
        {
            TXT_NOMBREPROTOCOLO.Text = "";
            TXT_OBSERVACIONES_PROTOCOLO.Text = "";
            FECHAFIN_PROTOCOLO.SelectedDates.Clear();
            HF_EDITARPROTOCOLO.Value = "";
            HF_ELIMINARPROTOCOLO.Value = "";
        }
        protected void BTN_MOSTRARTODOSLOSPROTOCOLOS_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Protocolos.aspx");
        }
        public void cargargrilla()
        {
            ConexionDB conexion = new ConexionDB();
            Usuariossesion Usuario = (Usuariossesion)Session["logueado"];
            int idproyecto = int.Parse(this.Request.QueryString["Id"].ToString());
            GV_Protocolo.DataSource = conexion.LISTARPROTOCOLOSbyPROYECTO(idproyecto);
            GV_Protocolo.DataBind();
        }

        protected bool protocolofinalizado(int id)
        {
            ConexionDB conexion = new ConexionDB();
            Protocolo protocoloencontrado = conexion.ENCONTRARPROTOCOLO(id);
            if (protocoloencontrado.Idestado == 10)
                return true;
            else
                return false;
        }
        public void cargarddl()
        {
            Usuariossesion usuario = (Usuariossesion)Session["logueado"];
            ConexionDB conexion = new ConexionDB();
            DDL_RESPONSABLEPROTOCOLO.DataSource = conexion.listarresponsables(usuario.IdRol, 3);
            DDL_RESPONSABLEPROTOCOLO.DataValueField = "IdResponsable";
            DDL_RESPONSABLEPROTOCOLO.DataTextField = "Responsable";
            DDL_RESPONSABLEPROTOCOLO.DataBind();
        }
        //protected void finalizarprotocolosypuntuar_Click(object sender, EventArgs e)
        //{
        //    DDL_PROYECTO_A_FINALIZAR.Visible = true;
        //    ConexionDB conexion = new ConexionDB();

        //    DDL_PROYECTO_A_FINALIZAR.DataSource = conexion.ListartodoslosProyectos();
        //    DDL_PROYECTO_A_FINALIZAR.DataValueField = "Id";
        //    DDL_PROYECTO_A_FINALIZAR.DataTextField = "Nombre";
        //    DDL_PROYECTO_A_FINALIZAR.DataBind();

        //}

        //protected void BTN_FINPROYECTO_Click(object sender, EventArgs e)
        //{
        //    ConexionDB conexion = new ConexionDB();
        //    conexion.finalizarprotocolosypuntuar(int.Parse(HF_FINPROYECTO.Value));
        //    Response.Write("<script>alert('Proyecto finalizado'</script>");
        //    BTN_FINPROYECTO.Visible = false;
        //    LBL_SiPOSEEPROTOCOLOSPENDIENTES.Text = "";
        //    LBL_SiPOSEEPROTOCOLOSPENDIENTES.Visible = false;
        //    DDL_PROYECTO_A_FINALIZAR.Visible = false;
        //}

        //protected void DDL_PROYECTO_A_FINALIZAR_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LBL_SiPOSEEPROTOCOLOSPENDIENTES.Visible = true;
        //    int idproyecto = int.Parse(DDL_PROYECTO_A_FINALIZAR.SelectedValue);
        //    HF_FINPROYECTO.Value = idproyecto.ToString();
        //    ConexionDB conexion = new ConexionDB();
        //    bool protocolospendientes = conexion.sabersitieneprotocolospendientes(idproyecto);
        //    if (protocolospendientes)
        //    {
        //        LBL_SiPOSEEPROTOCOLOSPENDIENTES.Text = "Tiene Protocolos Pendientes";
        //    }
        //    else
        //    {
        //        LBL_SiPOSEEPROTOCOLOSPENDIENTES.Text = "Pulse Aceptar para finalizar";
        //        BTN_FINPROYECTO.Visible = true;
        //    }

        //}
        //protected bool MOSTRARPUNTAJE(object dataitem)
        //{
        //    Protocolo aux2 = new Protocolo();
        //    aux2.Actividadesfinalizadas = dataitem;
        //    Protocolo aux= dataitem(Protocolo);

        //    ConexionDB conexion = new ConexionDB();
        //    //bool actfinalizadas = conexion.actividadesfinalziadas(int.Parse(dataitem.ToString()));
        //    if (aux.Actividadesfinalizadas == false)
        //        return false;
        //    else return true;
        //}
    }

}