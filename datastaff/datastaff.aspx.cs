using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Migrations;

public partial class datastaff_datastaff : System.Web.UI.Page
{
    db_efileEntities dbe = new db_efileEntities();
    public string selectstaffid { get; set; }
    public string staffid { get; set; }
    public string id { get; set; }

    public void insertlog()
    {
       id = Session["staffid"].ToString();
        activity ac = new activity();
        ac.idstaff = id;
        ac.waktu = DateTime.Now.Date;
        ac.isact = 1;
        dbe.activity.AddOrUpdate(ac);
        dbe.SaveChanges();
        
    }

    
    

    public void updatelog()
    {
        id = Session["staffid"].ToString();


        // string rol = Session["rolesid"].ToString();

        SqlConnection scon = new SqlConnection(stringkoneksi.connection);

        string masukdata = " delete activity where idstaff=@idstaff";

        SqlCommand scom = new SqlCommand(masukdata, scon);
        scom.Parameters.Add(new SqlParameter("@idstaff", id));
        
        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();
    }


    



protected void Page_Load(object sender, EventArgs e)
    { if (!IsPostBack)
        {
            //string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //if(url== "http://10.0.30.164:78/datastaff/datastaff.aspx")
            //{
            panel1.Visible = false;
            loadd();
            tampilstocksaccount();
            datagrid();
            //}
            // else
            //  {
            //updatelog();
            // }



            //if (url!=)



        }

    }

    public void tampilstocksaccount()
    {
        dproles.Items.Clear();
        dproles.AppendDataBoundItems = true;
        SqlConnection con = new SqlConnection(stringkoneksi.connection);
        string query = "select [rolenames] from [roles]";
        SqlCommand scom = new SqlCommand();
        scom.CommandType = CommandType.Text;
        scom.CommandText = query;
        scom.Connection = con;

        con.Open();


        dproles.DataSource = scom.ExecuteReader();
        dproles.DataTextField = "rolenames";
        dproles.DataValueField = "rolenames";
        dproles.DataBind();
        dproles.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Silahkan Pilih Nama Roles--", "0"));
    }

    public void tampilstocksaccount2()
    {
        dprolesname.Items.Clear();
        dprolesname.AppendDataBoundItems = true;
        SqlConnection con = new SqlConnection(stringkoneksi.connection);
        string query = "select [rolenames] from [roles]";
        SqlCommand scom = new SqlCommand();
        scom.CommandType = CommandType.Text;
        scom.CommandText = query;
        scom.Connection = con;

        con.Open();


        dprolesname.DataSource = scom.ExecuteReader();
        dprolesname.DataTextField = "rolenames";
        dprolesname.DataValueField = "rolenames";
        dprolesname.DataBind();
        dprolesname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Silahkan Pilih Nama Roles--", "0"));
    }

    public void loadd()
    {
       staffid = Session["staffid"].ToString();
        var quer = dbe.staff.Where(es => es.staffid == staffid).FirstOrDefault();
        txtcreatedby.Text = quer.namastaff;
        txtcreatedon.Text = DateTime.Now.ToShortDateString();
    }

    public void loadd2()
    {
       
        var quer = dbe.staff.Where(es => es.staffid == selectstaffid).FirstOrDefault();
        txtnamastaff2.Text = quer.namastaff;
        txtrolesid2.Text = quer.rolesid;
        txtpassword2.Text = quer.passwords;
    }

    protected void dproles_SelectedIndexChanged(object sender, EventArgs e)
    {
        var quer = dbe.roles.Where(es => es.rolenames == dproles.Text).FirstOrDefault();
        txtrolesid.Text = quer.rolesid;

    }

    public void datagrid()
    {
        var query = dbe.staff.ToList();
        dgdatastaff.DataSource = query;
        dgdatastaff.DataBind();

    }

    public void simpan()
    {
        staff s = new staff();
        s.staffid = txtstaffid.Text;
        s.namastaff = txtnamastaff.Text;
        s.rolesid = txtrolesid.Text;
        s.passwords = txtpassword.Text;
        s.createdby = txtcreatedby.Text;
        s.createdon = DateTime.Now;
        s.modifedtime = null;
        s.modifiedby = null;
        dbe.staff.AddOrUpdate(s);
        dbe.SaveChanges();
        datagrid();
    }

    protected void btnsimpan_Click(object sender, EventArgs e)
    {
        if(txtstaffid.Text==""||txtnamastaff.Text==""||txtpassword.Text=="")
        {
            Response.Write("<script>alert(' Data Harus Dimasukkan ' );</script>");
            txtstaffid.Focus();
            txtnamastaff.Focus();
            txtpassword.Focus();
        }
        else
        {
            simpan();
        }
    }

   

    protected void dgdatastaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgdatastaff.PageIndex = e.NewPageIndex;
        datagrid();
    }


  

    protected void dgdatastaff_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }



    protected void dgdatastaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        var qu = dbe.activity.Where(es => es.isact == 1).FirstOrDefault();
        if (qu == null)
        {
            insertlog();
            panel1.Visible = true;
            selectstaffid = dgdatastaff.SelectedRow.Cells[1].Text;
            panel1.Visible = true;
            tampilstocksaccount2();
            txtstaffid2.Text = selectstaffid;
            loadd2();
            txtmodifiedate.Text = DateTime.Now.ToShortDateString();
            txtmodified.Text = Session["staffid"].ToString();


        }
        else
        {
            var qq = dbe.staff.Where(es => es.staffid == qu.idstaff).FirstOrDefault();
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            Response.Write("<script>alert('Sedang Diupdate oleh user Lain');</script>");
            //btnsimpan.Enabled = false;
            panel1.Visible = false;
        }


           
      

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        updatelog();
        panel1.Visible = false;
    }

    public void hapus()
    {
        SqlConnection scon = new SqlConnection(stringkoneksi.connection);
        string query = "delete staff where staffid=@staffid";
        if (query == null)
        {
            Response.Write("<script>alert(' Tidak Ada Data Dengan Staff ID Tersebut' );</script>");

        }
        else
        {
            SqlCommand scom = new SqlCommand(query, scon);
            scom.Parameters.Add(new SqlParameter("@staffid", txtstaffid.Text));
            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
            datagrid();
        }
    }

    protected void btnhapus_Click(object sender, EventArgs e)
    {
        if(txtstaffid.Text=="")
        {
            Response.Write("<script>alert(' Staff ID harus diisi' );</script>");
            txtstaffid.Focus();

        }
        else
        {
            hapus();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

    }
}