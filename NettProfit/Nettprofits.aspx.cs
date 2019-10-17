using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Globalization;

public partial class NettProfit_Nettprofits : System.Web.UI.Page
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

    public void loaddata()
    {

        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        NpgsqlCommand ncom = new NpgsqlCommand();
        ncom.Connection = ncon;
        ncom.CommandType = CommandType.Text;
        ncom.CommandText = "select*from nettprofits";
        DataSet ds = new DataSet();
        NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
        nda.Fill(ds, "akunting");
        gridgrossprof.DataSource = ds;
        gridgrossprof.DataMember = "akunting";
        gridgrossprof.DataBind();




    }

    public void simpan()

    {
        int angka = 0;

        try
        {
            NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
            string masukdata = "insert into nettprofits (year,month,amount) values(:year,:month,:amount)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("year", Convert.ToDecimal(this.txtyeargrossprof.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("month", txtmonthgrossprof.Text));
            ncom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(angka)));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            loaddata();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Mohon Maaf Terjadi Error' );</script>");

        }
    }


    protected void Unnamed_Click(object sender, EventArgs e)
    {
        simpan();

    }
}