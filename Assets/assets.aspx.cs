using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using System.Globalization;

public partial class Assets_assets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loaddata();
            counts();
        }
    }
    public int jmlaset { get; set; }
    public void counts()
    {
        //int a = DateTime.Now.Year;
        //int m = DateTime.ParseExact("Oktober", "MMMM", CultureInfo.CurrentCulture).Month;
        //int tot = Convert.ToInt32(this.lbtotop.Text);
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        ncon.Open();
        //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

        var sql = "select sum(amount)  from assets";
        NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
        NpgsqlDataReader dr = ncom.ExecuteReader();


        while (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                jmlaset = dr.GetInt32(0);
                lbtotaset.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));

            }
            else
            {

                jmlaset = 0;

                lbtotaset.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));


            }
        }
    }
    public void loaddata()
    {

        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        NpgsqlCommand ncom = new NpgsqlCommand();
        ncom.Connection = ncon;
        ncom.CommandType = CommandType.Text;
        ncom.CommandText = "select account_id,amount,tanggal from assets";
        DataSet ds = new DataSet();
        NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
        nda.Fill(ds, "akunting");
        gdassets.DataSource = ds;
        gdassets.DataMember = "akunting";
        gdassets.DataBind();

        if (ds == null)
        {
            gdassets.EmptyDataText = "NO DATA";
        }
        else
        {
            gdassets.EmptyDataText = "";
        }

    }

   
}