<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="historylogin.aspx.cs" Inherits="historylogin_historylogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="stylehistorylogin.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
     <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledatastaff.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
    <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
                       <img height="50" width="50" src="../asset/historical_record_333033.png" />

                       </div>
                   <div class="columnss">
<h3>History Login</h3> 
                       </div>
                   </div>
           </div>
                  <div class="containers">

    <div class="kotak">
        <div class="kotakpencarian">
            <fieldset>
                <legend> Pencarian | Sorting Data</legend>
                <table>
                    <tr>
                        <td></td>
                       
                        <td> <asp:TextBox runat="server" CssClass="tb7" ID="txtcaristaffid" placeholder="Cari Berdasarkan Staff ID " Width="400"></asp:TextBox></td>
                   
                       
                        <td> Login Start</td>
                        <td> <asp:TextBox runat="server" ID="txtloginstart" TextMode="Date" CssClass="tb7"></asp:TextBox></td>
                        <td>Login End</td>
                        <td> <asp:TextBox runat="server" ID="txtloginend" TextMode="Date" CssClass="tb7"></asp:TextBox></td>

                    </tr>
                    
                       
                    
                </table>
                <asp:Button CssClass="button" runat="server" ID="btnhapussemua" BackColor="Brown" Text="Delete All" OnClick="btnhapussemua_Click" />
                <asp:Button runat="server" Text="Hapus Riwayat Login Staff ID" CssClass="button" BackColor="Red" OnClick="Unnamed1_Click" />
                 <asp:Button runat="server" Text="Pencarian Staff ID" CssClass="button" OnClick="Unnamed4_Click" />
                         <asp:Button runat="server" Text="Pencarian Filter Date" CssClass="button" OnClick="Unnamed2_Click" />
                                         <asp:Button runat="server" Text="Reload Pencarian" CssClass="button" ID="btnreload" OnClick="btnreload_Click" />

                 </fieldset>
        </div>
        <div class="kotakgrid">
            <asp:GridView EmptyDataText="NO Data" runat="server" CssClass="mGrid" ID="dghistory" AllowPaging="True" OnPageIndexChanging="dghistory_PageIndexChanging" PageSize="4">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
            </asp:GridView>
        </div>

    </div></div>
         </div>      
</asp:Content>

