using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Migrations;
public partial class loginpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    db_efileEntities dbe = new db_efileEntities();

    public void insertlogin()
    {
        stafflogin sl = new stafflogin();
        sl.staffid = txtusername.Text;
        sl.loginstart = DateTime.Now;
        sl.islogin = 0;
        dbe.stafflogin.AddOrUpdate(sl);
        dbe.SaveChanges();
    }

    public void login()
    {
        try
        {
            var query = dbe.staff.Select(es => new { es.staffid, es.passwords,es.rolesid }).Where(es => es.staffid == txtusername.Text && es.passwords == txtpassword.Text).FirstOrDefault();
            int rolesids =Convert.ToInt32(query.rolesid);

            if (query == null)
            {
                Response.Write("<script>alert(' Username atau Password Salah' );</script>");

            }
            else
            {


                var querys = dbe.stafflogin.Select(es => new { es.staffid, es.islogin }).Where(es => es.islogin == 0 && es.staffid == txtusername.Text).FirstOrDefault();
                if (querys == null)
                {
                    insertlogin();
                    Session["staffid"] = query.staffid;
                    Session["rolesid"] = rolesids;
                    Response.Redirect("http://10.0.30.18:78/dashboard/dashboard.aspx");

                }



                else
                {
                    Response.Write("<script>alert(' Anda Sudah Login Di tempat Lain' );</script>");


                }
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(' Username atau Password Tidak Ada di Database' );</script>");


        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (txtpassword.Text == "" || txtusername.Text == "")
        {
            Response.Write("<script>alert(' Username dan Password Harus Diisi' );</script>");
            txtpassword.Focus();
            txtusername.Focus();

        }
        else
        {
            login();

        }
    }
}
