using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data;
using System.Globalization;


public partial class Accounts_Accounts : System.Web.UI.Page
{
    public int conf { get; set; }
    public string id { get; set; }
    public string parentid { get; set; }
    public int nol { get; set; }
    public int c { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            nol = 0;
            txtparentaccountid.Text = nol.ToString();
            panel1.Visible = false;
            Response.Write("<script>alert('Anda Harus Menginput Stocks Terlebih Dahulu Sebelum Mengisi Amount Account Yang Lain' );</script>");

            loaddata();
            txtnameaccount.Enabled = false;
            txtparentaccountid.Enabled = false;

            dpparent.Enabled = false;
        }
    }

    public void simpandata()
    { 

            if (txtaccountid.Text == "" )
            {
                Response.Write("<script>alert(' Data Harus Dimasukkan' );</script>");

            }

            else
            {
            int i = 0;
            int b = 1;
                NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
                string masukdata = "insert into accounts values(@id,@name,@parent_id,@isparentaccount)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(this.txtaccountid.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("@name", txtnameaccount.Text));
            if (conf == 1)
            {
                ncom.Parameters.Add(new NpgsqlParameter("@parent_id", Convert.ToInt32(this.dpparent.Text)));

                ncom.Parameters.Add(new NpgsqlParameter("@isparentaccount", c));

            }
             if (conf == 0)
            {
                ncom.Parameters.Add(new NpgsqlParameter("@parent_id", Convert.ToInt32(this.txtparentaccountid.Text)));

                ncom.Parameters.Add(new NpgsqlParameter("@isparentaccount", c));

            }

            ncon.Open();
                ncom.ExecuteNonQuery();
                ncon.Close();
                loaddata();
            txtaccountid.Text = "";
            txtparentaccountid.Text = "";
            txtnameaccount.Text = "";
            
            }

        }
      
        
       
    

    public void loaddata()
    {

        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        NpgsqlCommand ncom = new NpgsqlCommand();
        ncom.Connection = ncon;
        ncom.CommandType = CommandType.Text;
        ncom.CommandText = "select id as Accounts_ID, name as Nama_Account, parent_id from accounts";
        DataSet ds = new DataSet();
        NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
        nda.Fill(ds, "akunting");
        gridaccounts.DataSource = ds;
        gridaccounts.DataMember = "akunting";
        gridaccounts.DataBind();

        if (ds == null)
        {
            gridaccounts.EmptyDataText = "NO DATA";
        }
        else
        {
            gridaccounts.EmptyDataText = "";
        }

    }


    public void simpanasset2()
    {
        decimal d = 0;
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        string masukdata = "insert into assets (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
        ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtaccountid.Text)));
        ncom.Parameters.Add(new NpgsqlParameter("amount", d));
        ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

        ncon.Open();
        ncom.ExecuteNonQuery();
        ncon.Close();
        panel1.Visible = true;
        //popupcostamount pp = new popupcostamount(); //ModalPanelVisible
        //pp.id = txtakunid.Text;
        if (conf == 0)
        {
            txtparentaccountid.Text = txtaccountid.Text;
            //pp.parentid = txtakunid.Text;
        }
        else if (conf == 1)
        {
            txtparentaccountid.Text = dpparent.Text;
            //pp.parentid = cbparent.Text;

        }
        //pp.ShowDialog();
    }

    public void simpanstocks()
    {
        decimal d = 0;
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        string masukdata = "insert into stocks (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
        ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtaccountid.Text)));
        ncom.Parameters.Add(new NpgsqlParameter("amount", d));
        ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

        ncon.Open();
        ncom.ExecuteNonQuery();
        ncon.Close();
        panel1.Visible = true;
        if (conf == 0)
        {
            txtparentaccountid.Text = txtaccountid.Text;
        }
        else if (conf == 1)
        {
            txtparentaccountid.Text = dpparent.Text;

        }

    }

    public void simpancost()
    {
        DateTime ds = DateTime.Parse("12/03/1950");
        decimal d = 0;
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        string masukdata = "insert into costs (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
        ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtaccountid.Text)));
        ncom.Parameters.Add(new NpgsqlParameter("amount", d));
        ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

        ncon.Open();
        ncom.ExecuteNonQuery();
        ncon.Close();

        panel1.Visible = true;
        if (conf == 0)
        {
            txtparentaccountid.Text = txtaccountid.Text;
        }
        else if (conf == 1)
        {
            txtparentaccountid.Text = dpparent.Text;

        }
    }

    public void simpandebts()
    {
        DateTime ds = DateTime.Parse("12/03/1950");
        decimal d = 0;
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        string masukdata = "insert into debts (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
        ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtaccountid.Text)));
        ncom.Parameters.Add(new NpgsqlParameter("amount", d));
        ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

        ncon.Open();
        ncom.ExecuteNonQuery();
        ncon.Close();
        panel1.Visible = true;
        if (conf == 0)
        {
            txtparentaccountid.Text = txtaccountid.Text;
        }
        else if (conf == 1)
        {
            txtparentaccountid.Text = dpparent.Text;

        }
    }


    public void simpanearnings()
    {
        DateTime ds = DateTime.Parse("12/03/1950");
        decimal d = 0;
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        string masukdata = "insert into earnings (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
        ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtaccountid.Text)));
        ncom.Parameters.Add(new NpgsqlParameter("amount", d));
        ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

        ncon.Open();
        ncom.ExecuteNonQuery();
        ncon.Close();
        panel1.Visible = true;
        if (conf == 0)
        {
            txtparentaccountid.Text = txtaccountid.Text;
        }
        else if (conf == 1)
        {
            txtparentaccountid.Text = dpparent.Text;

        }
    }



    public void simpanasset()
    {
        if (txtaccountid.Text == "" && conf == -1)
        {
            Response.Write("<script>alert(' Data Harus Dimasukkan' );</script>");
        }
        else
        {
            if (dpparent.Text == "1000" || txtparentaccountid.Text == "1000")
            {

                simpanasset2();
            }
            if (dpparent.Text == "2000" || txtparentaccountid.Text == "2000")
            {
                simpandebts();
            }
            if (dpparent.Text == "3000" || txtparentaccountid.Text == "3000")
            {
                simpanstocks();
            }
            if (dpparent.Text == "4000" || txtparentaccountid.Text == "4000")
            {
                simpancost();
            }
            if (dpparent.Text == "5000" || txtparentaccountid.Text == "5000")
            {
                simpanearnings();

            }
        }
    }


    public void counts()
    {
        int a = DateTime.Now.Year;
        int m = DateTime.Now.Month;
        //int tot = Convert.ToInt32(this.lbtotop.Text);
        NpgsqlConnection ncon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        ncon.Open();
        //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

        var sql = "select sum(amount)  from stocks where extract(year from tanggal) ='" + a + "' and extract(month from tanggal) ='" + m + "'";
        NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
        NpgsqlDataReader dr = ncom.ExecuteReader();


        while (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                int cost = dr.GetInt32(0);
                Response.Write("<script>alert('Jumlah Stocks Perusahaan Anda : '" + cost + "' );</script>");

                simpandata();
                simpanasset();

            }
            else
            {
                if (dpparent.Text == "3000")
                {
                    simpandata();
                    simpanstocks();
                }
                else
                {
                    Response.Write("<script>alert('Jumlah Stocks Perusahaan : 0, Anda Perlu Menambah Stocks Terlebih Dahulu ( Parent ID : 3000)');</script>");


                }



            }
        }

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        if (txtaccountid.Text == "" || conf == -1)
        {
            Response.Write("<script>alert(' Data Harus Dimasukkan' );</script>");
        }
        else
        {
            if (co.Text == "0")
            {
                c = 0;
                simpandata();
            }
            if (co.Text == "1")
            {
                c = 1;
                counts();
                //simpanasset();
            }
        }

    }

    public void loadbind()
    {
        dpparent.Items.Clear();
        dpparent.AppendDataBoundItems = true;
        NpgsqlConnection con = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);
        string query = "select id from accounts where isparentaccount=0";
        NpgsqlCommand scom = new NpgsqlCommand();
        scom.CommandType = CommandType.Text;
        scom.CommandText = query;
        scom.Connection = con;

        con.Open();


        dpparent.DataSource = scom.ExecuteReader();
        dpparent.DataTextField = "id";
        dpparent.DataValueField = "id";
        dpparent.DataBind();
        dpparent.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Silahkan Pilih Parent ID--", "0"));
    }


    //public void loadbind()
    //{
    //    dpparent.Enabled = true;
    //    NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
    //    nocn.Open();
    //    NpgsqlCommand ncom = new NpgsqlCommand("select id from accounts where isparentaccount=0", nocn);
    //    NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
    //    DataTable dt = new DataTable();
    //    nda.Fill(dt);
    //    //DataRow dr = dt.NewRow();
    //    //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
    //    //dt.Rows.InsertAt(dr, 0);

    //    dpparent.ValueMember = "id";
    //    dpparent.DisplayMember = "id";
    //    dpparent.DataSource = dt;
    //    nocn.Close();
    //}

    public void konfig()
    {
        if (rdchild.Checked == true)
        {
            conf = 1;
            co.Text = conf.ToString();
            txtnameaccount.Enabled = true;
            dpparent.Enabled = true;
            loadbind();
        }
        else if (rbparent.Checked == true)
        {
            conf = 0;
            co.Text = conf.ToString();

            txtnameaccount.Enabled = true;
            txtparentaccountid.Text = txtaccountid.Text;
            dpparent.Enabled = false;

        }
    }

    protected void Unnamed1_Click1(object sender, EventArgs e)
    {
        if (txtaccountid.Text == "")
        {
            Response.Write("<script>alert(' Data Harus Dimasukkan' );</script>");
            txtaccountid.Focus();

        }
        else
        {
            konfig();
        }
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        conf = -1;
        dpparent.Enabled = false;
        txtaccountid.Text = "";
        txtparentaccountid.Text = "";
        txtnameaccount.Enabled = false;
        txtparentaccountid.Enabled = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
    }

    public void updateamountearnings()
    {
        NpgsqlConnection scon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);

        string masukdata = "update earnings set amount=:amount where account_id='" + txtaccountids.Text + "'";

        NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
        scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();
        panel1.Visible = false;
    }

    public void updateamountstocks()
    {
        NpgsqlConnection scon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);

        string masukdata = "update stocks set amount=:amount where account_id='" + txtaccountids.Text + "'";

        NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
        scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();
        panel1.Visible = false;
    }

    public void updateassets()
    {
        NpgsqlConnection scon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);

        string masukdata = "update assets set amount=:amount where account_id='" + txtaccountids.Text + "'";

        NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
        scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();
        panel1.Visible = false;
    }

    public void updateamountdebts()
    {
        NpgsqlConnection scon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);

        string masukdata = "update debts set amount=:amount where account_id='" + txtaccountids.Text + "'";

        NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
        scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();
        panel1.Visible = false;
    }

    public void updatetopupamountcosts()
    {
        NpgsqlConnection scon = new NpgsqlConnection(STRINGKONEKSIPOSTGRE.connection);

        string masukdata = "update costs set amount=:amount where account_id='" + txtaccountids.Text + "'";

        NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
        scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


        scon.Open();
        scom.ExecuteNonQuery();

        scon.Close();
        panel1.Visible = false;


    }


    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (txtamount.Text == "")
        {
            Response.Write("<script>alert(' Data Harus Dimasukkan' );</script>");

        }
        else
        {
            if (txtparentid.Text == "1000")
            {
                updateassets();
            }
            else if (txtparentid.Text == "2000")
            {
                updateamountdebts();
            }
            else if (txtparentid.Text == "3000")
            {
                updateamountstocks();
            }
            else if (txtparentid.Text == "4000")
            {
                updatetopupamountcosts();

            }
            else if (txtparentid.Text == "5000")
            {
                updateamountearnings();
            }
        }
    }
    protected void panel1_Load(object sender, EventArgs e)
    {
        txtaccountids.Text = txtaccountid.Text;
        txtparentid.Text = dpparent.Text;
    }
}
