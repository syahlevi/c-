using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
public partial class costs_costs : System.Web.UI.Page
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

        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        NpgsqlCommand ncom = new NpgsqlCommand();
        ncom.Connection = ncon;
        ncom.CommandType = CommandType.Text;
        ncom.CommandText = "select account_id,amount, DATE(tanggal) from costs order by account_id asc";
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