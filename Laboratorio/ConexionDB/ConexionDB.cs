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
using System.Runtime.Remoting.Contexts;


namespace Laboratorio
{
    public class ConexionDB
    {
        public SqlConnection setearconexion()
        {
            try
            {
                //    string cadena = "Data Source=KARMA;user=sa;password=123456;";
                string cadena = "Data Source=KARMA;Initial Catalog=Laboratorio;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conexion = new SqlConnection(cadena);
                return conexion;
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return null;
            }

        }
        public SqlCommand Get_Command(SqlConnection conexion)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.Connection.Open();
                return command;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public Usuariossesion login(string email, string pass)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "login";
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("pass", pass);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string username = dt.Rows[0]["Username"].ToString();
                    string password = dt.Rows[0]["Password"].ToString();
                    int idrol = (int)dt.Rows[0]["IdRol"];
                    string apellido = (string)dt.Rows[0]["Apellido"];
                    string Nombre = (string)dt.Rows[0]["Nombre"];
                    int idpersona = (int)dt.Rows[0]["IdPersona"];
                    string descripcionrol = (string)dt.Rows[0]["descripcionrol"];
                    Usuariossesion usuariologueado = new Usuariossesion(username, password, idrol, apellido, Nombre, idpersona, descripcionrol);
                    return usuariologueado;

                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Log.Escribirerrorenarchivo(ex);
                return null;
            }
        }
        public int get_estadoproyecto(int idproyecto)
        {
            SqlCommand command = Get_Command(setearconexion());
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "get_estadoproyecto";
            command.Parameters.AddWithValue("idproyecto", idproyecto);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataRow drestadoproyecto = ds.Tables[0].Rows[0];
            int estadoproyecto = (int)drestadoproyecto["IdEstado"];
            return estadoproyecto;
        }
        public int get_estadoprotocolo(int idprotocolo)
        {
            SqlCommand command = Get_Command(setearconexion());
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "get_estadoprotocolo";
            command.Parameters.AddWithValue("idprotocolo", idprotocolo);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataRow drestadoprotocolo = ds.Tables[0].Rows[0];
            int estadoproyecto = (int)drestadoprotocolo["IdEstado"];
            return estadoproyecto;
        }
        public void insertarusuario(Persona nuevapersona, Usuario nuevousuario)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "intesertarusuario";
                command.Parameters.AddWithValue("nombre", nuevapersona.Nombrepersona);
                command.Parameters.AddWithValue("apellido", nuevapersona.Apellidopersona);
                command.Parameters.AddWithValue("dni", nuevapersona.Dnipersona);
                command.Parameters.AddWithValue("email", nuevousuario.Username);
                command.Parameters.AddWithValue("password", nuevousuario.Password);
                command.Parameters.AddWithValue("idrol", nuevousuario.Idrol);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }


        public bool encontrarusuario(int dni, string email)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "encontrarusuario";
                command.Parameters.AddWithValue("dni", dni);
                command.Parameters.AddWithValue("email", email);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return false;
            }


        }
        public DataTable ListarProyectos(int idpersona)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ListarProyectos";
                command.Parameters.AddWithValue("idpersona", idpersona);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return null;
            }
        }
        public void Insertarnuevoproyecto(Proyecto nuevo)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "INSERTARPROYECTO";
                command.Parameters.AddWithValue("FechaInicio", nuevo.Fechainicioproyecto);
                command.Parameters.AddWithValue("Nombre", nuevo.Nombreproyecto);
                command.Parameters.AddWithValue("FechaFin", nuevo.Fechafinproyecto);
                command.Parameters.AddWithValue("ObservacionesProyecto", nuevo.Observacionesproyecto);
                command.Parameters.AddWithValue("IdEstado", nuevo.Idestadoproyecto);
                command.Parameters.AddWithValue("IdResponsableProyecto", nuevo.IdResponsableProyecto);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }

        public void rechazarproyecto(int idproyecto)

        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "rechazarproyecto";
                command.Parameters.AddWithValue("idproyecto", idproyecto);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }

        public void ELIMINARPROYECTO(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ELIMINARPROYECTO";
                command.Parameters.AddWithValue("IdProyecto", id);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public Proyecto ENCONTRARPROYECTO(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ENCONTRARPROYECTO";
                command.Parameters.AddWithValue("Idproyecto", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow tablaseleccionada = ds.Tables[0].Rows[0];
                Proyecto seleccionado = new Proyecto();
                seleccionado.Idproyecto = id;
                seleccionado.Nombreproyecto = (string)tablaseleccionada["Nombre"];
                seleccionado.Fechafinproyecto = (DateTime)tablaseleccionada["FechaFin"];
                seleccionado.IdResponsableProyecto = (int)tablaseleccionada["IdResponsable"];
                seleccionado.Idestadoproyecto = (int)tablaseleccionada[5];
                seleccionado.Observacionesproyecto = (string)tablaseleccionada["ObservacionesProyecto"];
                command.Connection.Close();
                return seleccionado;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return null;
            }
        }
        public void MODIFICARPROYECTO(Proyecto modificado)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "MODIFICARPROYECTO";
                command.Parameters.AddWithValue("ID", modificado.Idproyecto);
                command.Parameters.AddWithValue("NOMBRE", modificado.Nombreproyecto);
                command.Parameters.AddWithValue("FECHAFIN", modificado.Fechafinproyecto);
                command.Parameters.AddWithValue("OBSERVACIONESPROYECTO", modificado.Observacionesproyecto);
                command.Parameters.AddWithValue("@idresponsableproyecto ", modificado.IdResponsableProyecto);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }

        }
        public void INSERTARPROTOCOLO(Protocolo NUEVO)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "INSERTARPROTOCOLO";
                command.Parameters.AddWithValue("NOMBRE", NUEVO.Nombreprotocolo);
                command.Parameters.AddWithValue("FECHAINICIO", NUEVO.Fechainicioprotocolo);
                command.Parameters.AddWithValue("FECHAFIN", NUEVO.Fechainicioprotocolo);
                command.Parameters.AddWithValue("IDESTADO", NUEVO.Idestado);
                command.Parameters.AddWithValue("OBSERVACIONES", NUEVO.Observacionesprotocolo);
                command.Parameters.AddWithValue("IDPROYECTO", NUEVO.Idproyecto);
                command.Parameters.AddWithValue("idResponsableProtocolo", NUEVO.Idresponsableprotocolo);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public DataSet listarresponsables(int idrol, int rolpagina)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "listarresponsables";
                command.Parameters.AddWithValue("idrol", idrol);
                command.Parameters.AddWithValue("rolpagina", rolpagina);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public DataTable listartodoslosprotocolos(int idproyecto)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "listartodoslosprotocolos";
                command.Parameters.AddWithValue("idproyecto", idproyecto);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public DataTable LISTARPROTOCOLOSbyPROYECTO(int idproyecto)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LISTARPROTOCOLOSbyPROYECTO";
                command.Parameters.AddWithValue("IdProyecto", idproyecto);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public DataTable LISTARPROTOCOLOS(int idpersona)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ListarProtocolos";
                //command.Parameters.AddWithValue("IdProyecto", idproyecto);
                command.Parameters.AddWithValue("idpersona", idpersona);
                // command.Parameters.AddWithValue("roladmin", roladministrador);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public void ELIMINARPROTOCOLO(int idprotocolo)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ELIMINARPROTOCOLO";
                command.Parameters.AddWithValue("Id_Protocolo", idprotocolo);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public Protocolo ENCONTRARPROTOCOLO(int id)
        {
            try
            {

                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ENCONTRARPROTOCOLO";
                command.Parameters.AddWithValue("IDPROTOCOLO", id);
                SqlDataAdapter Adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                Adapter.Fill(ds);
                DataRow protocoloencontrado = ds.Tables[0].Rows[0];
                Protocolo seleccionado = new Protocolo();
                seleccionado.Idprotocolo = id;
                seleccionado.Nombreprotocolo = (string)protocoloencontrado["Nombre"];
                seleccionado.Fechafinprotocolo = (DateTime)protocoloencontrado["FechaFin"];
                seleccionado.Fechainicioprotocolo = (DateTime)protocoloencontrado["FechaInicio"];
                seleccionado.Idestado = (int)protocoloencontrado["IdEstado"];
                seleccionado.Observacionesprotocolo = (string)protocoloencontrado["ObservacionesProtocolo"];
                seleccionado.Idresponsableprotocolo = (int)protocoloencontrado["idResponsableProtocolo"];
                seleccionado.Idproyecto = (int)protocoloencontrado[7];
                command.Connection.Close();
                return seleccionado;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public void MODIFICARPROTOCOLO(Protocolo modificado)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "MODIFICARPROTOCOLO";
                command.Parameters.AddWithValue("NOMBRE", modificado.Nombreprotocolo);
                command.Parameters.AddWithValue("FECHAFIN", modificado.Fechafinprotocolo);
                command.Parameters.AddWithValue("OBSERVACIONES", modificado.Observacionesprotocolo);
                command.Parameters.AddWithValue("id_protocolo", modificado.Idprotocolo);
                command.Parameters.AddWithValue("idResponsableProtocolo", modificado.Idresponsableprotocolo);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));

            }
        }
        public bool actividadesfinalziadas(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ListarProtocolos";
                command.Parameters.AddWithValue("IdProyecto", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow protocoloaux = ds.Tables[0].Rows[0];
                bool actfinalizadas = (bool)protocoloaux["actividadesfinalizadas"];
                command.Connection.Close();
                return actfinalizadas;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return false;
            }
        }
        public void ELIMINARACTIVIDAD(int idactividad, int idprotocolo)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ELIMINARACTIVIDAD";
                command.Parameters.AddWithValue("IdActividad", idactividad);
                command.Parameters.AddWithValue("idprotocolo", idprotocolo);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public object LISTARACTIVIDAD(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "listaractividades";
                command.Parameters.AddWithValue("Id_Protocolo", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public void INSERTARACTIVIDAD(Actividad nuevaactividad)
        {
            try
            {

                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "INSERTARACTIVIDAD";
                command.Parameters.AddWithValue("descripcion", nuevaactividad.Descripcion);
                command.Parameters.AddWithValue("IdProtocolo", nuevaactividad.IdProtocolo);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public Actividad ENCONTRARACTIVIDAD(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "EncontrarActividades";
                command.Parameters.AddWithValue("Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow actividadencontrada = ds.Tables[0].Rows[0];
                Actividad seleccionada = new Actividad();
                seleccionada.Id = id;
                seleccionada.Descripcion = (string)actividadencontrada["Descripcion"];
                seleccionada.Finalizada = (bool)actividadencontrada["Finalizada"];
                seleccionada.Puntaje = float.Parse(actividadencontrada["Puntaje"].ToString());
                command.Connection.Close();
                return seleccionada;
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;
            }
        }
        public void obtenerpromedioprotocolo(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "obtenerpromedioprotocolo";
                command.Parameters.AddWithValue("Id_Protocolo", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                command.Connection.Close();

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }

        }

        public void cambiarestadoprotocolofinalizado(int idprotocolo)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "cambiarestadoprotocolofinalizado";
                command.Parameters.AddWithValue("idprotocolo", idprotocolo);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public void MODIFICARACTIVIDAD(Actividad modificada)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "MODIFICARACTIVIDAD";
                command.Parameters.AddWithValue("descripcion", modificada.Descripcion);
                command.Parameters.AddWithValue("finalizado", modificada.Finalizada);
                command.Parameters.AddWithValue("puntaje", modificada.Puntaje);
                command.Parameters.AddWithValue("id", modificada.Id);
                command.Parameters.AddWithValue("idprotocolo", modificada.IdProtocolo);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public int tieneprotocolos(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "tieneprotocolos";
                command.Parameters.AddWithValue("idproyecto", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return 0;
            }
        }

        public void finalizarprotocolosypuntuar(int idproyecto)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "finalizarprotocolosypuntuar";
                command.Parameters.AddWithValue("idproyecto", idproyecto);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
            }
        }
        public bool sabersihayactividadespendientes(int idprotocolo)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sabersihayactividadespendientes";
                command.Parameters.AddWithValue("idprotocolo", idprotocolo);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                Protocolo aux = new Protocolo();
                aux.Actividadesfinalizadas = (bool)dr["actividadesfinalizadas"];

                return aux.Actividadesfinalizadas;
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex));
                return false;
            }

        }
        public bool sabersitieneprotocolospendientes(int idproyecto)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sabersitieneprotocolospendientes";
                command.Parameters.AddWithValue("idproyecto", idproyecto);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                Proyecto aux = new Proyecto();
                aux.Protocolospendientes = (bool)dr["protocolospendientes"];
                return aux.Protocolospendientes;
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return false;

            }

        }
        public int tieneactividades(int id)
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "tieneactividades";
                command.Parameters.AddWithValue("idprotocolo", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Connection.Close();
                return ds.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ListartodoslosProyectos()
        {
            try
            {
                SqlCommand command = Get_Command(setearconexion());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ListartodoslosProyectos";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("hubo un error con numero " + Log.Escribirerrorenarchivo(ex)); return null;

            }
        }
    }
}