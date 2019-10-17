using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
public partial class dashboard_dashboard : System.Web.UI.Page
{
    db_efileEntities dbe = new db_efileEntities();


    public void hitunglogin()
    {
        var sp = dbe.stafflogin.Where(es => es.islogin == 0).Count();
        if (sp.Equals(null))
        {
            sp = 0;
            lblinklogin.Text = sp.ToString();
        }
        else
        {
            lblinklogin.Text = sp.ToString();

        }

    }

    public void hitungrole()
    {
        var ss = dbe.roles.Count();
        linkrole.Text = ss.ToString();
    }

    public void hitungstaff()
    {
        var pp = dbe.staff.Count();
        if (pp.Equals(null))
        {
            pp = 0;
            LinkButtonstaff.Text = pp.ToString();
        }
        else
        {
            LinkButtonstaff.Text = pp.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            hitunglogin();
            hitungstaff();
            panelmodal.Visible = false;
            hitungrole();
            var sa = dbe.stafflogin.Count();
            
        }
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        panelmodal.Visible = false;
    }

    protected void lblinklogin_Click(object sender, EventArgs e)
    {
        panelmodal.Visible = true;
    }

    protected void LinkButtonstaff_Click(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(Session["rolesid"]);

        if (a >= 1000 && a < 2000)
        {
            Response.Redirect("http://100.0.30.184:78/datastaff/datastaff.aspx");
        }
        else
        {
            Response.Write("<script>alert(' Anda Tidak Memiliki Autorisasi' );</script>");

        }
    }

    protected void linkrole_Click(object sender, EventArgs e)
    {

    }
}