using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

/// <summary>
/// Summary description for STRINGKONEKSIPOSTGRE
/// </summary>
public class STRINGKONEKSIPOSTGRE
{

    public static string connection = @"User ID=postgres;Password=godofwar32;Host=localhost;Port=5432;Database=akunting;";

    public static NpgsqlConnection conn = new NpgsqlConnection(stringkoneksi.connection);
    public static NpgsqlCommand comm;

    //
    // TODO: Add constructor logic here
    //

}
