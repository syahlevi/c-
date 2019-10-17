<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="belajarjavascript_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link rel="stylesheet" href="stylereport.css" type="text/css" />
     <link rel="stylesheet" href="stylehistorylogin.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
     <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styledatastaff.css" type="text/css" />
    <link rel="stylesheet" href="styleassets.css" type="text/css" />
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
    <link rel="stylesheet" href="stylecost.css" type="text/css" />
    <script src="JavaScript.js" type="text/javascript"></script>
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
<h3>Belajar Java Script</h3> 
                       </div>
                   </div>
              </div>
        <div class="forms">
            <table>
                <tr>
                    <td>
                        <input id="txtangka" type="text" placeholder="Masukkan Angka" />
                    </td>
                </tr>
                <tr>
                    <td>
           
            <input id="txtusername" type="text"  />
                        </td>
                </tr>
                <tr>
                    <td>
           <button id="btn" type="button" onclick="cekusername()" style="width:200px;">Click Cek Username</button>
                        </td>
                    </tr>
                <tr>
                    <td>
                   
            <button id="btn2" type="button" onclick="cekusernamelength()" style="width:200px;">Click Cek Panjang</button>
                </td> 
                    </tr>
                <tr>
                    <td>
                        <button id="btn3" type="button" style="width:200px;" onclick="perulangan()">Click Perulangan</button>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>

