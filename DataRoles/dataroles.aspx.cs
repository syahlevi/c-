using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Migrations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

public partial class Data_Roles_dataroles : System.Web.UI.Page
{
    db_efileEntities dbe = new db_efileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            datagrid();
            tampilstocksaccount2();
            txtcreatedon.Text = DateTime.Now.ToShortDateString();
           string staffid = Session["staffid"].ToString();
            txtcreatedby.Text = staffid;

        }
    }

   public void hapusrole()
    {
        SqlConnection scon = new SqlConnection(stringkoneksi.connection);
        string query = "delete roles where rolesid=@rolesid";
        if (query == null)
        {
            Response.Write("<script>alert(' Tidak Ada Data Dengan Roles ID Tersebut' );</script>");

        }
        else
        {
            SqlCommand scom = new SqlCommand(query, scon);
            scom.Parameters.Add(new SqlParameter("@rolesid", txtrolesid.Text));
            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
            datagrid(); ;
        }
    }

    public void datagrid()
    {
        var query = dbe.roles.ToList();
        dgroles.DataSource = query;
        dgroles.DataBind();

    }
   
    public void insert()
    {
        roles r = new roles();
        r.rolenames = txtrolesname.Text;
        r.rolesid = txtrolesid.Text;
        r.parentrolesid = Convert.ToDecimal(this.dpparentroles.Text);
        dbe.roles.AddOrUpdate(r);
        dbe.SaveChanges();
        datagrid();

    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        if(txtrolesid.Text=="")
        {
            Response.Write("<script>alert(' Roles ID harus diisi' );</script>");
            txtrolesid.Focus();

        }
        else
        {
            hapusrole();
        }
    }

    public void tampilstocksaccount2()
    {
       dpparentroles.Items.Clear();
        dpparentroles.AppendDataBoundItems = true;
        SqlConnection con = new SqlConnection(stringkoneksi.connection);
        string query = "select DISTINCT [parentrolesid] from [roles]";
        SqlCommand scom = new SqlCommand();
        scom.CommandType = CommandType.Text;
        scom.CommandText = query;
        scom.Connection = con;

        con.Open();


        dpparentroles.DataSource = scom.ExecuteReader();
        dpparentroles.DataTextField = "parentrolesid";
        dpparentroles.DataValueField = "parentrolesid";
        dpparentroles.DataBind();
        dpparentroles.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Silahkan Pilih Parent Roles ID--", "0"));
    }

    protected void dgroles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgroles.PageIndex = e.NewPageIndex;
        datagrid();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(txtrolesid.Text==""||dpparentroles.Text==""||txtrolesname.Text=="")
        {
            Response.Write("<script>alert(' Data Harus Diisi' );</script>");

        }
        else
        {
            insert();
        }
    }
}