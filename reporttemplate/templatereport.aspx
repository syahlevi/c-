<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="templatereport.aspx.cs" Inherits="reporttemplate_templatereport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="stylereport.css" type="text/css" />
     <link rel="stylesheet" href="stylehistorylogin.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
     <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledatastaff.css" type="text/css" />
    <link rel="stylesheet" href="styleassets.css" type="text/css" />
    <link rel="stylesheet" href="stylecost.css" type="text/css" />
    <link rel="stylesheet" href="styletemplate.css" type="text/css" />
  <script src="../crystalreportviewers13/js/crviewer/crv.js" type="text/javascript"></script>
       <style type="text/css">
        .LeftPane
        {
             position: relative;
             z-index: 100;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
         <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
                       <img height="50" width="50" src="../asset/historical_record_333033.png" />

                       </div>
                   <div class="columnss">
<h3>Template Report</h3> 
                       </div>
                   </div>
           </div>
        <div class ="reportss">
            <div class="LeftPane">
                <asp:ScriptManager runat="server" ID="s"> </asp:ScriptManager>
         <CR:CrystalReportViewer style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" ID="CrystalReportViewer1" runat="server" AutoDataBind="True" HasRefreshButton="True" ReportSourceID="CrystalReportSource1" EnableDrillDown="False" EnableTheming="True" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" Height="50px" ValidateRequestMode="Enabled" PageZoomFactor="89" RenderingDPI="99" ToolbarStyle-CssClass="w3-hover-text-grey" BorderStyle="Dashed" ShowAllPageIds="True" GroupTreeImagesFolderUrl="" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
          
                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                         <Report FileName="CrystalReport2.rpt">
                         </Report>
                </CR:CrystalReportSource>
          
                     </div>

        </div>
    </div>
</asp:Content>

