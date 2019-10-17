using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for stringkoneksi
/// </summary>
public class stringkoneksi
{
    
        public static string connection = @"Server=.\SQLEXPRESS;database=db_efile;Integrated Security=true";

    public static SqlConnection conn = new SqlConnection(stringkoneksi.connection);
    public static SqlCommand comm;
}


