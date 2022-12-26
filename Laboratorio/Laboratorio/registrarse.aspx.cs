using Laboratorio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio
{
    public partial class registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();
            Usuario nuevousuario = new Usuario();
            Persona nuevapersona = new Persona();
            
            if (TXT_NOMBRE.Text == "")
                Response.Write("<script>alert('El Campo Nombre no puede estar vacio')</script>");
            else
                nuevapersona.Nombrepersona = TXT_NOMBRE.Text;
            if (TXT_APELLIDO.Text == "")
                Response.Write("<script>alert('El Campo Apellido no puede estar vacio')</script>");
            else
                nuevapersona.Apellidopersona = TXT_APELLIDO.Text;
            if (TXT_DNI.Text == "")
                Response.Write("<script>alert('El Campo DNI no puede estar vacio')</script>");
            else
                nuevapersona.Dnipersona = int.Parse(TXT_DNI.Text);
            if (TXT_EMAIL.Text == "")
                Response.Write("<script>alert('El Campo Email no puede estar vacio')</script>");
            else
                nuevousuario.Username = TXT_EMAIL.Text.Trim();
            if (TXT_PASSWORD.Text == "")
                Response.Write("<script>alert('El Campo Password no puede estar vacio')</script>");
            else
                nuevousuario.Password = TXT_PASSWORD.Text.Trim();
            if (CHK_ACEPTARTERMINOS.Checked)
            { 
                if (conexion.encontrarusuario(nuevapersona.Dnipersona, nuevousuario.Username))
                {
                    Response.Write("<script>alert('El Email o DNI ya se encuentran Registrados')</script>");
                }
                else
                {
                    conexion.insertarusuario(nuevapersona, nuevousuario);
                    limpiar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#MODAL_USUARIOCREADO').modal()", true);
                }
            }
            else
            {
            Response.Write("<script>alert('Debe Aceptar los terminos')</script>");
           
            }
        }

        public void limpiar()
        {
            TXT_APELLIDO.Text = "";
            TXT_NOMBRE.Text = "";
            TXT_DNI.Text = "";
            TXT_EMAIL.Text = "";
            TXT_PASSWORD.Text = "";
        }


        protected void BTN_ACEPTAR_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}