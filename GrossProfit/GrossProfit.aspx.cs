using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Globalization;

public partial class GrossProfit_GrossProfit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loaddata();
            txtmonthgrossprof.Text = DateTime.Now.Date.ToString("MMMM");

            txtyeargrossprof.Text = DateTime.Now.Date.ToString("yyyy");
        }
    }
    public void simpan()

    {
        int angka = 0;

        
            NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
            string masukdata = "insert into grossprofits (year,month,amount) values(:year,:month,:amount)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("year", Convert.ToInt32(this.txtyeargrossprof.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("month", txtmonthgrossprof.Text));
            ncom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToInt32(angka)));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            loaddata();
      
    }


public void loaddata()
{

    NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
    NpgsqlCommand ncom = new NpgsqlCommand();
    ncom.Connection = ncon;
    ncom.CommandType = CommandType.Text;
    ncom.CommandText = "select*from grossprofits";
    DataSet ds = new DataSet();
    NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
    nda.Fill(ds, "akunting");
    gridgrossprof.DataSource = ds;
        gridgrossprof.DataMember = "akunting";

        gridgrossprof.DataBind();


}

protected void Unnamed1_Click(object sender, EventArgs e)
    {
        simpan();
    }
}