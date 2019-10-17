<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="stylereport.css" type="text/css" />
     <link rel="stylesheet" href="stylehistorylogin.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
     <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledatastaff.css" type="text/css" />
    <link rel="stylesheet" href="styleassets.css" type="text/css" />
    <script src="../belajarjavascript/jquery.zoomooz.js" type="text/javascript"></script>
    <script>
        $(document).ready(function ceks() { 
            $("#print").zoomTarget();
        });
        function printDiv(print) {
            var x = document.getElementById("bt");
            var printContents = document.getElementById(print).innerHTML;
    

     document.body.innerHTML = printContents;
     x.style.display = "none";
     window.print();

     document.body.innerHTML = originalContents;
    }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content" id="print">
          <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
                       <img height="50" width="50" src="../asset/historical_record_333033.png" />

                       </div>
                   <div class="columnss">
<h3>Operational Cost  Report</h3> 
                       </div>
                   </div>
           </div>
                  <div class="containers">

        <div class="data">
            <table runat="server">
                <tr>
                    <td>
                        Tanggal Pencarian Report</td> <td>:</td>
                    
                    <td>
                        <asp:TextBox runat="server" ID="txtdate" CssClass="tb7" TextMode="Date" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> Print Report  </td><td>:</td>
                    <td> <asp:Label runat="server" ID="lbdateprint"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        Report Date  </td><td>:</td>
                    <td>
                        <asp:Label runat="server" ID="lbreportdate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td> Total Operasional </td><td>:</td>
                    <td><asp:Label runat="server" ID="lbtotop"></asp:Label></td>
                </tr>
                <tr>
                    <td>Total Cash  </td><td>:</td>
                    <td> <asp:Label runat="server" ID="lbtotcash"></asp:Label></td>
                </tr>
                <tr>
                    <td> Total Stocks </td><td>:</td>
                    <td> <asp:Label runat="server" ID="totstocks"></asp:Label></td>
                </tr>
                    <tr>
                    <td>
                        Sisa Stocks (Stocks - Operational)  </td><td>:</td>
                    <td> <asp:Label runat="server" ID="lbselisih"></asp:Label></td>
                </tr>
                <tr>
                    <td> Keterangan  </td><td>:</td>
                    <td> <asp:Label runat="server" ID="lbketerangan"></asp:Label></td>
                </tr>
                <tr>
                <td>
                    <div id="bt">
                    <asp:Button runat="server" ID="btnreport" Text="Report" OnClick="btnreport_Click"  CssClass="button"/>
<%--                    <asp:Button runat="server" ID="btnreload" Text="Reload" CssClass="button" OnClick="btnreload_Click" />--%>
                 <%--   <asp:Button runat="server" ID="btnprint" Text="Print" CssClass="button" OnClick="btnprint_Click" />--%>
                    <input type="button" onclick="printDiv('print')" value="Cetak Report (Java Script)" class="button" />
                </div>
                        </td>
                    </tr>
            
            </table>
        </div>
        <div class="grid">
            <asp:GridView runat="server" ID="dgreport" EmptyDataText="No Data" CssClass="mGrid">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:GridView>
        </div>
    </div></div>

</asp:Content>

