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
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices;

public partial class reportviwer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.DataSources.Clear();
            ////ReportDataSource rptsrc = new ReportDataSource("DataSet1", GetData());
            //ReportParameter rp1 = new ReportParameter("Month", DateTime.Now.Month.ToString());
            //ReportParameter rp2 = new ReportParameter("Year", DateTime.Now.Year.ToString());
            ReportViewer1.LocalReport.ReportPath = "Report.rdlc";
            ////ReportViewer1.LocalReport.DataSources.Add(rptsrc);
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2 });
            ReportViewer1.LocalReport.Refresh();




            //ReportDocument rd = new ReportDocument();
            //string path2 = Server.MapPath("~/CrystalReport2.rpt");
            //rd.Load(path2);

            //rd.SetParameterValue("reportdate", DateTime.Now.ToString("dddd, dd-MM-yyyy"));
            //rd.SetParameterValue("totaloperational", Session["totop"]);
            //rd.SetParameterValue("totalcash", Session["totcash"]);
            //rd.SetParameterValue("totalstocks", Session["totstocks"]);
            //rd.SetParameterValue("sisastocks", Session["sisastocks"]);
            //rd.SetParameterValue("keterangan", Session["keterangan"]);
            //CrystalReportPartsViewer1.ReportSource = rd;
            //CrystalReportPartsViewer1.Refresh();
        }
    }
}