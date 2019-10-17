using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

public partial class historylogin_historylogin : System.Web.UI.Page
{
    db_efileEntities dbe = new db_efileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadd();
    }

    public void loadd()
    {
        var aq = dbe.stafflogin.ToList();
        dghistory.DataSource = aq;
        dghistory.DataBind();
    }

    protected void Unnamed4_Click(object sender, EventArgs e)
    {
        if(txtcaristaffid.Text=="")
        {
            Response.Write("<script>alert(' Data Staff ID Harus Dimasukkan' );</script>");
            txtcaristaffid.Focus();

        }
        else

        {
            caristaffid();
        }
    }

    public void caristaffid()
    { stafflogin sf = new stafflogin();
        try
        {
            var qu = from stafflogin in dbe.stafflogin where stafflogin.staffid.Contains(txtcaristaffid.Text) select stafflogin;
            dghistory.DataSource = qu.ToList();
            dghistory.DataBind();
        }
        catch (Exception )
        {
            Response.Write("<script>alert(' Data tidak ditemukan' );</script>");

        }
    }

    

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        if(txtloginend.Text==""||txtloginstart.Text=="")
        {
            Response.Write("<script>alert(' Tanggal Filter harus dimasukkan' );</script>");

        }
        else
        {

        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {

    }

    protected void btnreload_Click(object sender, EventArgs e)
    {
        loadd();
    }

    protected void dghistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dghistory.PageIndex = e.NewPageIndex;
        loadd();
    }

    public void reseed()
    {
        SqlConnection scon = new SqlConnection(stringkoneksi.connection);
      
        string query = "dbcc checkident ('stafflogin',reseed,0)";
        SqlCommand scom = new SqlCommand(query, scon);
        scon.Open();
        scom.ExecuteNonQuery();
    }

    public void hapus()
    {
        SqlConnection scon = new SqlConnection(stringkoneksi.connection);
        string query = "delete stafflogin where staffid=@staffid";
        if (query == null)
        {
            Response.Write("<script>alert(' Tidak Ada Data Dengan Staff ID Tersebut' );</script>");

        }
        else
        {
            SqlCommand scom = new SqlCommand(query, scon);
            scom.Parameters.Add(new SqlParameter("@staffid", txtcaristaffid.Text));
            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
            loadd();
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        if (txtcaristaffid.Text == "")
        {
            Response.Write("<script>alert(' Staff ID Harus Dimasukkan' );</script>");

        }
        else
        {
           

            hapus();
        }
    }

    protected void btnhapussemua_Click(object sender, EventArgs e)
    {
        SqlConnection scon = new SqlConnection(stringkoneksi.connection);
        string query = "delete stafflogin";
        if (query == null)
        {
            Response.Write("<script>alert(' Tidak Ada Data Dengan Staff ID Tersebut' );</script>");

        }
        else
        {
            SqlCommand scom = new SqlCommand(query, scon);
           
            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
            reseed();
            loadd();

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            Session.Abandon();

          
            Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);

            Response.Redirect("http://100.0.30.184:78/loginpage.aspx");
        }
    }
}