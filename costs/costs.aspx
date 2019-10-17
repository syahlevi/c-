<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="costs.aspx.cs" Inherits="costs_costs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link rel="stylesheet" href="stylereport.css" type="text/css" />
     <link rel="stylesheet" href="stylehistorylogin.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
     <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledatastaff.css" type="text/css" />
    <link rel="stylesheet" href="styleassets.css" type="text/css" />
    <link rel="stylesheet" href="stylecost.css" type="text/css" />
    <script src="../asset/JavaScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
          <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
                       <img height="50" width="50" src="../asset/historical_record_333033.png" />

                       </div>
                   <div class="columnss">
<h3>Costs</h3> 
                       </div>
                   </div>
           </div>
                  <div class="containers">

        <div class="form">
            <table>
                <tr>
                    <td>
                        Total asset : 
                        <asp:Label runat="server" ID="lbcount"></asp:Label>
                    </td>
                </tr>
               
            </table>
        </div>
        <div class="grid">
            <asp:GridView runat="server" ID="dgreport" CssClass="mGrid" EmptyDataText="Tidak Ada Data" >
             


            </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>

