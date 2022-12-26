using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;
using Laboratorio.Clases;
using System.Drawing;


namespace Laboratorio
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void BTN_INGRESAR_Click(object sender, EventArgs e)
        {
            string email = TXT_EMAIL.Text;
            string password = TXT_PASSWORD.Text;
            var pos = email.IndexOf("@");

            //try
            //{
            if (pos > 0 && (email.LastIndexOf(".") > pos) && (email.ToString().Length - pos > 4))
            {
                ConexionDB conexion = new ConexionDB();
                if (password.Length >= 2)
                {
                    Usuariossesion usuariologueado = conexion.login(email, password);
                    Session["logueado"] = usuariologueado;
                    if (usuariologueado != null)
                    {
                        switch (usuariologueado.IdRol)
                        {
                            case 1:
                                Response.Redirect("Proyecto.aspx");
                                break;
                            case 2:
                                Response.Redirect("Proyecto.aspx");
                                break;
                            case 3:
                                Response.Redirect("Protocolos.aspx");
                                break;
                            case 4:
                                Response.Redirect("estadistica.aspx");
                                break;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Contraseña Incorrecta')</script>");
                    }
                }
                else
                {
                    Response.Redirect("desloguearse.aspx");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Email y/o contraseña incorrectos')</script>");
            }

        }
        //catch (Exception ex)
        //{
        //    string codigo = "Hubo un erro con numero " + Log.Escribirerrorenarchivo(ex);
        //    Session["error"] = codigo;
        //    Response.Redirect("error.aspx");
        //}
    }
}
