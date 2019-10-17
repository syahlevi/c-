<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="Accounts.aspx.cs" Inherits="Accounts_Accounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
        <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="styleaccounts.css" type="text/css" />
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function ceknull()
        {
            var text = document.getElementById('<%= txtaccountid.ClientID %>');
            try{
                if(Text == null)

                {
                    alert("Kosong");
                }
                else
                {
                    alert("no");
                }
            }
            catch(ex)
            {
                alert("aa");
            }


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
       <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
               <img src="../asset/102-512.png" height="50" width="50" />
                       </div>
                   <div class="columnss">
<h3>Accounts</h3> 
                       </div>
                   </div>
           </div>

     <asp:Panel runat="server" CssClass="modal" ID="panel1" OnLoad="panel1_Load">
          <div class="modal-content">
          <div class="headermodal"> 
              <div class="mod">              
                  <asp:Button runat="server" ID="Button1" Text="X" CssClass="button"  OnClick="Button1_Click"     />
                  </div>
              <h3> Ubah Data Staff</h3>
              </div>
              <div class="modal-body">

                  <table>
                     <tr>
                         <td><asp:TextBox runat="server" ReadOnly="true" onkeypress="return isNumberKey(event)" ID="txtparentid" BorderStyle="None"  CssClass="tb72" placeholder="Staff ID"></asp:TextBox></td>
                     </tr>
                      <tr>
                          <td><asp:TextBox runat="server" ReadOnly="true" onkeypress="return isNumberKey(event)" ID="txtaccountids"  CssClass="tb72" placeholder="namastaff"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td>
                              <asp:TextBox runat="server" onkeypress="return isNumberKey(event)" ID="txtamount" CssClass="tb72" placeholder="rolesid"></asp:TextBox>
                          </td>
                          </tr>
                        
                      <tr>
                          <td> <asp:Button runat="server" ID="btnupdate" CssClass="button" Text="Save" OnClick="btnupdate_Click" /></td>
                      </tr>
                  </table>

                  </div>
              </div>
                 </asp:Panel>
                  <div class="containers">

        <div class="data">
            <fieldset style="width:300px;">
                <legend> Konfigurasi Parent / Child Account</legend>
          
            <table>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtaccountid" onkeypress="return isNumberKey(event)" placeholder="Account ID" CssClass="tb7" Width="250px"></asp:TextBox>
                    </td>
                     </tr>
                <tr>

                
                    <td colspan="2"> <asp:RadioButton AutoPostBack="true" GroupName="conf" runat="server" ID="rbparent" Text="Parent Account" />
                 <asp:RadioButton runat="server" AutoPostBack="true" GroupName="conf" ID="rdchild" Text="Child Account" /></td>
               </tr>
                <tr>
                     <td><asp:Label runat="server" ID="co" ></asp:Label></td>
                    </tr>
               
                <tr>
                    <td><asp:DropDownList runat="server" AutoPostBack="true" ID="dpparent" Height="30px" Width="250px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" CssClass="button" Text="Set Konfigurasi" OnClick="Unnamed1_Click1" />
                    
                    <asp:Button runat="server" CssClass="button" Text="Batalkan" OnClick="Unnamed2_Click" /></td>
                </tr>
                </table>
                   </fieldset>
                <table>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtnameaccount" placeholder="Nama Accounts" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> Parent ID : 
                        <asp:TextBox runat="server"  ID="txtparentaccountid"  placeholder="Parent Account ID" CssClass="tb71" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server"  Text="Submit" CssClass="button" OnClick="Unnamed1_Click" />
                    </td>
                </tr>
            </table>
               
        </div>

          <div class="kotakgrid">
            <asp:GridView runat="server" ID="gridaccounts" AutoGenerateColumns="true" CssClass="mGrid" EmptyDataText="Tidak ADA Data"></asp:GridView>
        </div>
</div>
        </div>
</asp:Content>

