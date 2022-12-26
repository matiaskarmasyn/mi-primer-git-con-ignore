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
using System.IO;

namespace Laboratorio
{
    public class Log
    {
        public static string Escribirerrorenarchivo(Exception ex)
        {
            string path = "C:/Error c#/Log.txt";
            string codigo = DateTime.Now.ToString("yyyyMMddhhmmss");
            File.AppendAllLines(path, new string[] { codigo });
            File.AppendAllLines(path, new string[] { ex.Message });
            File.AppendAllLines(path, new string[] { ex.StackTrace });
            return codigo;
          
        }
    }
}