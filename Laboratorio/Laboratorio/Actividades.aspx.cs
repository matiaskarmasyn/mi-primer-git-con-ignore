using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using Laboratorio.Clases;
using System.ComponentModel;

namespace Laboratorio
{
    public partial class Actividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();
            if (!IsPostBack)
            {
             
                if (this.Request.QueryString["IdProtocolo"] != null)
                 
                {
               LBL_NUMEROPROTOCOLO.Text = "EL PROTOCOLO POSEE ID NUMERO " + HF_IDPROTOCOLO.Value;
                    cargargrilla();
                }
                else
                {

                }
            }

         
            cargargrilla();

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            HF_IDPROTOCOLO.Value = this.Request.QueryString["IdProtocolo"].ToString();
            Session["IdProtocolo"] = HF_IDPROTOCOLO.Value;
            HF_IDPROYECTO.Value = Session["idproyecto"].ToString();
            ConexionDB conexion = new ConexionDB();
            int idestadoprotocolo = conexion.get_estadoprotocolo(int.Parse(HF_IDPROTOCOLO.Value));
            if (idestadoprotocolo == 10)
                BTN_NUEVA_ACTIVIDAD.Enabled = true;
            else
                BTN_NUEVA_ACTIVIDAD.Enabled=false;
        }

        protected bool actividadfinalizada(int Id)
        {
            ConexionDB conexion = new ConexionDB();
            Actividad actividadencontrada=conexion.ENCONTRARACTIVIDAD(Id);
            if (actividadencontrada.Finalizada)
                return false;
            else
                return true;
        }
        protected void BTN_AGREGAR_ACTIVIDAD_Click(object sender, EventArgs e)
        {
            if (HF_EditarActividad.Value == "")
            {

                Actividad nuevaactividad = new Actividad();
                nuevaactividad.Descripcion = TXT_DESCRIPCIONACTIVIDAD.Text;
                nuevaactividad.IdProtocolo = int.Parse(Request.QueryString["IdProtocolo"]);
                ConexionDB conexion = new ConexionDB();
                conexion.INSERTARACTIVIDAD(nuevaactividad);
                PNL_AGREGAR_ACTIVIDAD.Visible = false;
                cargargrilla();
                limpiar();
                PNL_AGREGAR_ACTIVIDAD.Visible = false;
            }
            else
            {
                ConexionDB conexion = new ConexionDB();
                Actividad modificado = new Actividad();
                modificado.Descripcion = TXT_DESCRIPCIONACTIVIDAD.Text;
                modificado.Finalizada = CHK_ACTIVIDAD_FINALIZADA.Checked;
                if (CHK_ACTIVIDAD_FINALIZADA.Checked)
                    TXT_PUNTAJE_ACTIVIDAD.Enabled = true;
                modificado.Puntaje = float.Parse(TXT_PUNTAJE_ACTIVIDAD.Text);
                modificado.Id = int.Parse(HF_EditarActividad.Value);
                conexion.MODIFICARACTIVIDAD(modificado);
                cargargrilla();
                limpiar();
                BTN_AGREGAR_ACTIVIDAD.Text = "Agregar Actividad";
                PNL_AGREGAR_ACTIVIDAD.Visible = false;
            }
        }

        protected void BTN_CANCELAR_NUEVA_ACTIVIDAD_Click(object sender, ImageClickEventArgs e)
        {
            PNL_AGREGAR_ACTIVIDAD.Visible = false;
        }

        protected void BTN_NUEVA_ACTIVIDAD_Click(object sender, EventArgs e)
        {
            PNL_AGREGAR_ACTIVIDAD.Visible = true;
            BTN_AGREGAR_ACTIVIDAD.Text = "Agregar Actividad";
        }

        protected void btn_back_protocolo_Click(object sender, EventArgs e)
        {

            int idprotocolo = int.Parse(this.Request.QueryString["IdProtocolo"]);
            string idproyecto = HF_IDPROYECTO.Value;
            Response.Redirect("~/Protocolos.aspx?Id=" + idproyecto);
        }

        protected void CHK_ACTIVIDAD_FINALIZADA_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_ACTIVIDAD_FINALIZADA.Checked == true)
                TXT_PUNTAJE_ACTIVIDAD.Visible = true;
            else
                TXT_PUNTAJE_ACTIVIDAD.Visible = false;
            int nota = int.Parse(TXT_PUNTAJE_ACTIVIDAD.Text);
            if (nota >= 7)
                TXT_PUNTAJE_ACTIVIDAD.ForeColor = Color.Green;
            else
                TXT_PUNTAJE_ACTIVIDAD.ForeColor = Color.Red;
        }

        protected void GV_ACTIVIDAD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ELIMINAR")
            {
                int id_actividad = int.Parse(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#MODAL_ELIMINARACTIVIDAD').modal()", true);
                HF_EliminarActividad.Value = id_actividad.ToString();
            }
            if (e.CommandName == "EDITAR")
            {
                int id_actividad = int.Parse(e.CommandArgument.ToString());
                HF_EditarActividad.Value = id_actividad.ToString();
                ConexionDB conexion = new ConexionDB();
                Actividad seleccionado = conexion.ENCONTRARACTIVIDAD(id_actividad);
                TXT_DESCRIPCIONACTIVIDAD.Text = seleccionado.Descripcion;
                CHK_ACTIVIDAD_FINALIZADA.Visible = true;
                CHK_ACTIVIDAD_FINALIZADA.Checked = seleccionado.Finalizada;
                LBL_FINALIZADA.Visible = true;
                if (CHK_ACTIVIDAD_FINALIZADA.Checked)
                    TXT_PUNTAJE_ACTIVIDAD.Visible = true;
                TXT_PUNTAJE_ACTIVIDAD.Text = seleccionado.Puntaje.ToString();
                BTN_AGREGAR_ACTIVIDAD.Text = "Modificar Actividad";
                PNL_AGREGAR_ACTIVIDAD.Visible = true;
            }
        }

        protected void BTN_ACEPTARELIMINACTIVIDAD_Click(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();
            int idactividad = int.Parse(HF_EliminarActividad.Value.ToString());
            int idprotocolo = int.Parse(Request.QueryString["IdProtocolo"]);
            conexion.ELIMINARACTIVIDAD(idactividad, idprotocolo);
            cargargrilla();
            limpiar();
        }
        public void cargargrilla()
        {
            int id_protocolo = int.Parse(HF_IDPROTOCOLO.Value);
            ConexionDB conexion = new ConexionDB();
            GV_ACTIVIDAD.DataSource = conexion.LISTARACTIVIDAD(id_protocolo);
            GV_ACTIVIDAD.DataBind();
        }

        public void limpiar()
        {
            TXT_DESCRIPCIONACTIVIDAD.Text = "";
            TXT_PUNTAJE_ACTIVIDAD.Text = "";
            HF_EditarActividad.Value = "";
            HF_EliminarActividad.Value = "";
            LBL_FINALIZADA.Visible = false;
            CHK_ACTIVIDAD_FINALIZADA.Visible = false;
            TXT_PUNTAJE_ACTIVIDAD.Visible = false;
        }

        protected void BTN_obtenerpromedio_Click(object sender, EventArgs e)
        {
            int idProtocolo = int.Parse(HF_IDPROTOCOLO.Value);
            ConexionDB conexion = new ConexionDB();
            bool posee_act_pendientes = conexion.sabersihayactividadespendientes(idProtocolo);
            if (!posee_act_pendientes)
            {
                Response.Write("<script>alert('Posee actividades pendientes, finalizelas y vuelva')</script>");
            }
            else
            {
                conexion.obtenerpromedioprotocolo(idProtocolo);
                conexion.cambiarestadoprotocolofinalizado(idProtocolo);
                Response.Write("<script>alert('Promedio obtenido para visualizarlo dirigirse a la pantalla Protocolos')</script>");
            }
        }

  
    }
}