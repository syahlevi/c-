using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;
using Npgsql;
public partial class reporttemplate_templatereport : System.Web.UI.Page
{
    public string keterangan { get; set; }
    public int selisih { get; set; }
    public int totoperasional { get; set; }
    public int totcash { get; set; }
    public int totstocks { get; set; }
    public string printreport { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ReportDocument rd = new ReportDocument();
            string path2 = Server.MapPath("~/CrystalReport2.rpt");
            rd.Load(path2);
            CrystalReportViewer1.DisplayToolbar = true;
            CrystalReportViewer1.HasSearchButton = true;
            CrystalReportViewer1.HasExportButton = true;
            CrystalReportViewer1.HasPrintButton = true;
            rd.SetParameterValue("reportdate", DateTime.Now.ToString("dddd, dd-MM-yyyy"));
            rd.SetParameterValue("totaloperational", Session["totop"]);
            rd.SetParameterValue("totalcash", Session["totcash"]);
            rd.SetParameterValue("totalstocks", Session["totstocks"]);
            rd.SetParameterValue("sisastocks", Session["sisastocks"]);
            rd.SetParameterValue("keterangan", Session["keterangan"]);

            //string path = @"C:\Users\Acer\Documents\Visual Studio 2015\WebSites\WebSite2\CrystalReport.rpt";

            CrystalReportViewer1.ReportSource = rd;
            
            
        }
    }
}