<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="reportviwer.aspx.cs" Inherits="reportviwer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
             <div class="report">
<%--                 <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true" />--%>
                 <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
                 <rsweb:ReportViewer ID="ReportViewer1"  Width="100%"  ProcessingMode="Remote" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" >
                     <LocalReport ReportPath="Report.rdlc">
                     </LocalReport>
                 </rsweb:ReportViewer>
             </div>
         
        </div>
</asp:Content>

