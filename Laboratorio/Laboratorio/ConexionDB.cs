using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Laboratorio.Clases;

namespace Laboratorio
{
    public class ConexionDB
    {
        public static void OpenDB()
        {

            try
            {
                string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
                //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conexion = new SqlConnection(cadena);
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                conexion.Open();
            }
            catch
            {

            }
            finally
            {

            }
        }
        public object ListarProyectos()
        {
            try
            {
                string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
                //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conexion = new SqlConnection(cadena);
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                conexion.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ListarProyectos";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void Insertarnuevoproyecto(Proyecto nuevo)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "INSERTARPROYECTO";
            command.Parameters.AddWithValue("Nombre", nuevo.Nombreproyecto);
            command.Parameters.AddWithValue("FechaInicio", nuevo.Fechainicioproyecto);
            command.Parameters.AddWithValue("FechaFin", nuevo.Fechafinproyecto);
            command.Parameters.AddWithValue("ObservacionesProyecto", nuevo.Observacionesproyecto);
            command.Parameters.AddWithValue("IdEstado", nuevo.Idestadoproyecto);
            command.Parameters.AddWithValue("Responsable", nuevo.Responsableproyecto);
            command.ExecuteNonQuery();

        }
        public void ELIMINARPROYECTO(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ELIMINARPROYECTO";
            command.Parameters.AddWithValue("IdProyecto", id);
            command.ExecuteNonQuery();
        }
        public Proyecto ENCONTRARPROYECTO(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
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
            seleccionado.Responsableproyecto = (string)tablaseleccionada["Responsable"];
            seleccionado.Idestadoproyecto = (int)tablaseleccionada[5];
            seleccionado.Observacionesproyecto = (string)tablaseleccionada["ObservacionesProyecto"];
            return seleccionado;
        }
        public void MODIFICARPROYECTO(Proyecto modificado)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "MODIFICARPROYECTO";
            command.Parameters.AddWithValue("ID", modificado.Idproyecto);
            command.Parameters.AddWithValue("NOMBRE", modificado.Nombreproyecto);
            command.Parameters.AddWithValue("FECHAFIN", modificado.Fechafinproyecto);
            command.Parameters.AddWithValue("OBSERVACIONESPROYECTO", modificado.Observacionesproyecto);
            command.Parameters.AddWithValue("IDESTADO", modificado.Idestadoproyecto);
            command.Parameters.AddWithValue("RESPONSABLE", modificado.Responsableproyecto);
            command.ExecuteNonQuery();
        }
        public void INSERTARPROTOCOLO(Protocolo NUEVO)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand command = new SqlCommand();
            conexion.Open();
            command.Connection = conexion;
            
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "INSERTARPROTOCOLO";
            command.Parameters.AddWithValue("NOMBRE", NUEVO.Nombreprotocolo);
            command.Parameters.AddWithValue("FECHAINICIO", NUEVO.Fechainicioprotocolo);
            command.Parameters.AddWithValue("FECHAFIN", NUEVO.Fechainicioprotocolo);
            command.Parameters.AddWithValue("PUNTAJE", NUEVO.Puntajeprotocolo);
            command.Parameters.AddWithValue("IDESTADO", NUEVO.Idestadoprotocolo);
            command.Parameters.AddWithValue("OBSERVACIONES", NUEVO.Observacionesprotocolo);
            command.Parameters.AddWithValue("IDPROYECTO", NUEVO.Idproyecto);
            command.ExecuteNonQuery();
        }
        public object LISTARPROTOCOLOS(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ListarProtocolos";
            command.Parameters.AddWithValue("IdProyecto", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        public void ELIMINARPROTOCOLO(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ELIMINARPROTOCOLO";
            command.Parameters.AddWithValue("Id_Protocolo", id);
            command.ExecuteNonQuery();
        }
        public Protocolo ENCONTRARPROTOCOLO(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection=conexion;
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
            seleccionado.Idestadoprotocolo = (int)protocoloencontrado[4];
            seleccionado.Idestadoprotocolo = (int)protocoloencontrado[5];
            seleccionado.Observacionesprotocolo = (string)protocoloencontrado["ObservacionesProtocolo"];
            seleccionado.Idproyecto = (int)protocoloencontrado[7];
            return seleccionado;
        }
        public void MODIFICARPROTOCOLO(Protocolo modificado)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "MODIFICARPROTOCOLO";
            command.Parameters.AddWithValue("NOMBRE", modificado.Nombreprotocolo);
            command.Parameters.AddWithValue("FECHAFIN", modificado.Fechafinprotocolo);
            command.Parameters.AddWithValue("OBSERVACIONES", modificado.Observacionesprotocolo);
            command.Parameters.AddWithValue("id_protocolo", modificado.Idprotocolo);
            command.ExecuteNonQuery();
        }
        public void ELIMINARACTIVIDAD(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ELIMINARACTIVIDAD";
            command.Parameters.AddWithValue("IdActividad", id);
            command.ExecuteNonQuery();
        }
        public object LISTARACTIVIDAD(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "listaractividades";
            command.Parameters.AddWithValue("Id_Protocolo", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0] ;
        }
        public void INSERTARACTIVIDAD(Actividad nuevaactividad)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "INSERTARACTIVIDAD";
            command.Parameters.AddWithValue("descripcion", nuevaactividad.Descripcionactividad);
            command.Parameters.AddWithValue("IdProtocolo", nuevaactividad.Idprotocolo);
            command.ExecuteNonQuery();
        }
        public Actividad ENCONTRARACTIVIDAD(int id)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "EncontrarActividades";
            command.Parameters.AddWithValue("Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataRow actividadencontrada = ds.Tables[0].Rows[0];
            Actividad seleccionada = new Actividad();
            seleccionada.Idactividad = id;
            seleccionada.Descripcionactividad = (string)actividadencontrada["Descripcion"];
            seleccionada.Finalizada = (bool)actividadencontrada["Finalizada"];
            seleccionada.puntajeactividad = (int)actividadencontrada["Puntaje"];
            return seleccionada;
        }

        public void MODIFICARACTIVIDAD(Actividad modificada)
        {
            string cadena = "Data Source=NOTEBOOKEXO;user=sa;password=123456;";
            //string cadena = "Data Source=NOTEBOOKEXO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "MODIFICARACTIVIDAD";
            command.Parameters.AddWithValue("descripcion", modificada.Descripcionactividad);
            command.Parameters.AddWithValue("finalizado", modificada.puntajeactividad);
            command.Parameters.AddWithValue("puntaje", modificada.Finalizada);
            command.Parameters.AddWithValue("id", modificada.Idactividad);
            command.ExecuteNonQuery();
        }
    }
}