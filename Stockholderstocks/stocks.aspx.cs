using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using System.Data.SqlClient;


public partial class Stockholderstocks_stocks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loaddata();
        }
    }

    public void loaddata()
    {
        //select * from stocks

        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        NpgsqlCommand ncom = new NpgsqlCommand();
        ncom.Connection = ncon;
        ncom.CommandType = CommandType.Text;
        ncom.CommandText = "select account_id,amount,tanggal from stocks order by account_id asc";
        DataSet ds = new DataSet();
        NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
        nda.Fill(ds, "akunting");
        dgreport.DataSource = ds;
        dgreport.DataMember = "akunting";
        dgreport.DataBind();

        if (ds == null)
        {
            dgreport.EmptyDataText = "NO DATA";
        }
        else
        {
            dgreport.EmptyDataText = "";
        }

    }

}