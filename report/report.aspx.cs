using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using System.Globalization;

public partial class report_report : System.Web.UI.Page
{
    public int stocks { get; set; }
    public int cost { get; set; }
    public int selisih { get; set; }
    public int cash { get; set; }
    public int cekselisih { get; set; }
    public DateTime date { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            lbdateprint.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy");
        }
    }

    public void loaddata()
    {
        date = DateTime.Parse(this.txtdate.Text);

        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        NpgsqlCommand ncom = new NpgsqlCommand();
        ncom.Connection = ncon;
        ncom.CommandType = CommandType.Text;
        ncom.CommandText = "select*from costs where extract(year from tanggal) ='" + date.Year + "' and extract(month from tanggal) ='" + date.Month + "'";
        DataSet ds = new DataSet();
        NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
        nda.Fill(ds, "akunting");
        dgreport.DataSource = ds;
        dgreport.DataMember = "akunting";
        dgreport.DataBind();

        



    }

    public void countstock()
    {
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        ncon.Open();
        var sql = "select sum(amount)  from stocks where extract(year from tanggal) ='" + date.Year + "' and extract(month from tanggal) ='" + date.Month+ "'";
        NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
        NpgsqlDataReader dr = ncom.ExecuteReader();


        while (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                totstocks.Text = dr.GetInt32(0).ToString("N0", new CultureInfo("en-US"));
                stocks = dr.GetInt32(0);

            }
            else
            {
                totstocks.Text = 0.ToString();
                stocks = 0;
            }
        }

    }

    public void cekcash()
    {
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        ncon.Open();
        var sql = "select sum (amount) from assets where extract(year from tanggal) ='" + date.Year + "' and extract(month from tanggal) ='" + date.Month+ "'";
        NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
        NpgsqlDataReader nred = ncom.ExecuteReader();
        while (nred.Read())
        {
            if (!nred.IsDBNull(0))
            {
                lbtotcash.Text = nred.GetInt32(0).ToString("N0", new CultureInfo("en-US"));
                cash = nred.GetInt32(0);

            }
            else
            {
                lbtotcash.Text = 0.ToString();
                cash = 0;
            }
        }
    }

    public void counts()
    {
        //int tot = Convert.ToInt32(this.lbtotop.Text);
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        ncon.Open();
        var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" +date.Year + "' and extract(month from tanggal) ='" + date.Month + "'";
        NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
        NpgsqlDataReader dr = ncom.ExecuteReader();


        while (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                lbtotop.Text = dr.GetInt32(0).ToString("N0", new CultureInfo("en-US"));
                cost = dr.GetInt32(0);

            }
            else
            {
                lbtotop.Text = 0.ToString();
                cost = 0;
            }
        }

    }


    protected void btnreport_Click(object sender, EventArgs e)
    {
        if (txtdate.Text == "")
        {
            Response.Write("<script>alert(' Tanggal Pencarian Harus Diisi' );</script>");

        }
        else
        { 
        DateTime month = DateTime.Parse(this.txtdate.Text);
        Class1.ToMonthName(month);

        lbdateprint.Text = txtdate.Text;
        lbreportdate.Text = month.ToMonthName()+" "+ month.Year.ToString();
        loaddata();
        counts();
        countstock();
        cekcash();

        selisih = stocks - cost;
        lbselisih.Text = selisih.ToString("N0", new CultureInfo("en-US"));
    
        selisih = stocks - cost;

        lbselisih.Text = selisih.ToString("N0", new CultureInfo("en-US"));
        cekselisih = selisih + cost;
            if (selisih == 0)
            {
                lbketerangan.Text = "-";
            }
            else
            {

                if (cekselisih == stocks)
                {
                    lbketerangan.Text = "PERHITUNGAN SESUAI";
                    lbketerangan.ForeColor = System.Drawing.Color.YellowGreen;
                }
                if (cekselisih < stocks)
                {
                    lbketerangan.Text = "Selisih Aman";
                    lbketerangan.ForeColor = System.Drawing.Color.Blue;
                }
                if (cekselisih > stocks)
                {
                    lbketerangan.Text = "PERHITUNGAN TIDAK SESUAI";
                    lbketerangan.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        }

    protected void btnreload_Click(object sender, EventArgs e)
    {
        loaddata();
        counts();
        countstock();
        cekcash();
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["totop"] = lbtotop.Text;
        Session["totcash"] = cash;
        Session["totstocks"] = stocks;
        Session["sisastocks"] = selisih;
        Session["keterangan"] = lbketerangan.Text;
       
        Response.Redirect("http://10.0.30.164:78/reporttemplate/templatereport.aspx");
    }
}