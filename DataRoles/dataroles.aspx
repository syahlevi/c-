<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="dataroles.aspx.cs" Inherits="Data_Roles_dataroles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
      function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
</script>
        <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
        <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="styledataroles.css" type="text/css" />
<link rel="stylesheet" href="../asset/styledatastaff.css" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
     <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
                       <img src="../asset/281793-200.png"   height="50" width="50"/>
                       </div>
                   <div class="columnss">
<h3>Data Roles</h3> 
                       </div>
                   </div>
           </div>
                  <div class="containers">

      <div class="kotakdata">
        <div class="kotakisi">
            <table>
                <tr>
                    <td> <asp:TextBox runat="server" ID="txtrolesid" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32)" CssClass="tb722" placeholder="Roles ID"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td> <asp:TextBox runat="server" ID="txtrolesname" CssClass="tb722" placeholder="Roles Name" Width="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:DropDownList runat="server" ID="dpparentroles" CssClass="select" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td> <asp:TextBox runat="server" ReadOnly="true" ID="txtcreatedby" CssClass="tb722" placeholder="CreatedBy" Width="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtcreatedon" ReadOnly="true"  CssClass="tb722" placeholder="CreatedOn"></asp:TextBox></td>
                </tr>

                </table>
              <div class="mod">              
                  <asp:Button runat="server" ID="Button1" Text="Simpan" CssClass="button" OnClick="Button1_Click"     /> 
                  <asp:Button runat="server" ID="btn2" Text="Hapus" CssClass="button" BackColor="Red" OnClick="btn2_Click" />
                  </div>
                </div>
           <div class="kotakgrid">
            <asp:GridView runat="server" CssClass="mGrid" OnPageIndexChanging="dgroles_PageIndexChanging" EmptyDataText="Tidak Ada Data" PageSize="5" AutoGenerateSelectButton="true" AllowPaging="true" ID="dgroles">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
               </asp:GridView>
        </div>
          </div></div>
          </div>

</asp:Content>

