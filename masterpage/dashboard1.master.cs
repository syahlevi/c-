using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using Npgsql;

public partial class masterpage_dashboard1 : System.Web.UI.MasterPage
{
    db_efileEntities dbe = new db_efileEntities();
    public string staffid { get; set; }
   

    protected void Page_Load(object sender, EventArgs e)
    {if (!IsPostBack)
        {

           
                staffid = Session["staffid"].ToString();
            var query = dbe.staff.Where(es => es.staffid == staffid).FirstOrDefault();
            lbnama.Text = query.namastaff;
            var query2 = dbe.roles.Where(ess => ess.rolesid == query.rolesid).FirstOrDefault();
            lbjabatan.Text = query2.rolenames;

        }
    }



    private void update()
    {
        
            SqlConnection scon = new SqlConnection(stringkoneksi.connection);

            string masukdata = "update stafflogin set islogin=@islogin, loginout=@loginout where staffid='" + Session["staffid"].ToString()+ "'";

            SqlCommand scom = new SqlCommand(masukdata, scon);
            scom.Parameters.Add(new SqlParameter("@islogin", 1));
            scom.Parameters.Add(new SqlParameter("@loginout", DateTime.Now));

          
            scon.Open();
            scom.ExecuteNonQuery();
           
            scon.Close();
        
       
    }

    protected void lb1_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoServerCaching();
        HttpContext.Current.Response.Cache.SetNoStore();
        Session.Abandon();
      
        update();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);

        Response.Redirect("http://10.0.30.164:78/loginpage.aspx");
       
    }

    protected void lblinklogin_Click(object sender, EventArgs e)
    {
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
    }

    protected void lbdatastaff_Click(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(Session["rolesid"]);

        if (a>=1000 && a<2000)
        {
            Response.Redirect("http://10.0.30.164:78/datastaff/datastaff.aspx");
        }
        else
        {
            Response.Write("<script>alert(' Anda Tidak Memiliki Autorisasi' );</script>");

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(Session["rolesid"]);

        if (a >= 1000 && a < 2000)
        {
            Response.Redirect("http://10.0.30.164:78/DataRoles/dataroles.aspx");
        }
        else
        {
            Response.Write("<script>alert(' Anda Tidak Memiliki Autorisasi' );</script>");

        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        try
        {
            ncon.Open();
            Response.Write("<script>alert('Koneksi Berhasil' );</script>");

        }

        catch ( Exception ex)
        {
            Response.Write("<script>alert('"+ex.Message+"' );</script>");

        }
        ncon.Close();

    }
}
