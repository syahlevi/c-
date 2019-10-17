using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Migrations;

public partial class updateprofil_ubahprofil : System.Web.UI.Page
{
    db_efileEntities dbe = new db_efileEntities();
    public string idrole { get; set; }
    public string idrole2 { get; set; }
    public string rolesname { get; set; }
    public void tampilstocksaccount()
    {
        dprole.Items.Clear();
        dprole.AppendDataBoundItems = true;
        SqlConnection con = new SqlConnection(stringkoneksi.connection);
        string query = "select [rolenames] from [roles]";
        SqlCommand scom = new SqlCommand();
        scom.CommandType = CommandType.Text;
        scom.CommandText = query;
        scom.Connection = con;

        con.Open();


        dprole.DataSource = scom.ExecuteReader();
        dprole.DataTextField = "rolenames";
        dprole.DataValueField = "rolenames";
        dprole.DataBind();
        dprole.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Silahkan Pilih Nama Roles--", "0"));
    }


    public void loaddata()
    {
        string staffid = Session["staffid"].ToString();
        string rol = Session["rolesid"].ToString();
        var po = dbe.staff.Where(es => es.staffid == staffid).FirstOrDefault();
        // txtrole.Text = po.rolesid;
        txtnamastaff.Text = po.namastaff;
        txtpass.Text = po.passwords;

        var poss = dbe.roles.Where(ess => ess.rolesid == po.rolesid).FirstOrDefault();
        rolesname = poss.rolenames;
        idrole = rol;
        txtrole.Text = rolesname + " " + idrole;
    }

   

    private void update2()
    {
        string rol = Session["rolesid"].ToString();

        SqlConnection scon = new SqlConnection(stringkoneksi.connection);

        string masukdata = "update staff set namastaff=@namastaff, modifiedby=@modifiedby, modifedtime=@modifedtime, rolesid=@rolesid, passwords=@passwords where staffid='" + Session["staffid"].ToString() + "'";

        SqlCommand scom = new SqlCommand(masukdata, scon);
        scom.Parameters.Add(new SqlParameter("@namastaff", txtnamastaff.Text));
        scom.Parameters.Add(new SqlParameter("@passwords", txtpass.Text));
        scom.Parameters.Add(new SqlParameter("@rolesid", rol));

        scom.Parameters.Add(new SqlParameter("@modifiedby", txtmodifiedby.Text));

        scom.Parameters.Add(new SqlParameter("@modifedtime", DateTime.Now.Date));



        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();


    }




    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            panel1.Visible = true;
            loaddata();
            tampilstocksaccount();
            txtupdatedate.Text = DateTime.Now.ToShortDateString();
            txtmodifiedby.Text = Session["staffid"].ToString();
         

        }

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        Response.Redirect("http://10.0.30.18:78/dashboard/dashboard.aspx");
    }

    protected void dprole_SelectedIndexChanged(object sender, EventArgs e)
    {
      int rolesid=  Convert.ToInt32(this.Session["rolesid"]);


        if (rolesid < 2000 && rolesid >= 1000)
        {
            var quer = dbe.roles.Where(es => es.rolenames == dprole.Text).FirstOrDefault();
            idrole = quer.rolesid;
            idrole2 = quer.rolesid;
            txtrole.Text = dprole.Text + idrole;
            txtidrole.Text = idrole;

        }
        else
        {
            Response.Write("<script>alert(' Anda tidak memiliki autorisasi' );</script>");

        }




    }



    protected void btn_Click(object sender, EventArgs e)
    {
        int rolesid = Convert.ToInt32(this.Session["rolesid"]);

        if (rolesid>=1000 && rolesid<2000)
        {
            update1();
        }
        else
        {
            update2();
        }
    }

    private void update1()
    {

        SqlConnection scon = new SqlConnection(stringkoneksi.connection);

        string masukdata = "update staff set namastaff=@namastaff, modifiedby=@modifiedby, modifedtime=@modifedtime, rolesid=@rolesid, passwords=@passwords where staffid='" + Session["staffid"].ToString() + "'";

        SqlCommand scom = new SqlCommand(masukdata, scon);
        scom.Parameters.Add(new SqlParameter("@namastaff", txtnamastaff.Text));
        scom.Parameters.Add(new SqlParameter("@rolesid", txtidrole.Text));
        scom.Parameters.Add(new SqlParameter("@passwords", txtpass.Text));
        scom.Parameters.Add(new SqlParameter("@modifiedby", txtmodifiedby.Text));

        scom.Parameters.Add(new SqlParameter("@modifedtime", DateTime.Now.Date));



        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();


    }
}