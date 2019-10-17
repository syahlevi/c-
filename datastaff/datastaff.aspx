<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="datastaff.aspx.cs" Inherits="datastaff_datastaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                       <img src="../asset/staff-8-542410.png" height="50" width="50" />
                       </div>
                   <div class="columnss">
<h3>Data Staff</h3> 
                       </div>
                   </div>
           </div>
                  <div class="containers">

     <asp:Panel runat="server" CssClass="modal" ID="panel1">
          <div class="modal-content">
          <div class="headermodal"> 
              <div class="mod">              
                  <asp:Button runat="server" ID="Button1" Text="X" CssClass="button" OnClick="Button1_Click"      />
                  </div>
              <h3> Ubah Data Staff</h3>
              </div>
              <div class="modal-body">

                  <table>
                     <tr>
                         <td><asp:TextBox runat="server" ID="txtstaffid2" BorderStyle="None"  CssClass="tb72" placeholder="Staff ID"></asp:TextBox></td>
                     </tr>
                      <tr>
                          <td><asp:TextBox runat="server" ID="txtnamastaff2"  CssClass="tb72" placeholder="namastaff"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td>
                              <asp:TextBox runat="server" ID="txtrolesid2" CssClass="tb72" placeholder="rolesid"></asp:TextBox>
                          </td>
                          <td> <asp:DropDownList runat="server" ID="dprolesname" CssClass="select"></asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td>
                              <asp:TextBox runat="server" ID="txtpassword2" CssClass="tb72" placeholder="Password"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td> <asp:TextBox ID="txtmodified" runat="server" CssClass="tb72" placeholder="ModifiedBy"></asp:TextBox></td>
                      <td><asp:TextBox runat="server" ID="txtmodifiedate" CssClass="tb72"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td> <asp:Button runat="server" ID="btnupdate" CssClass="button" Text="Update Staff" OnClick="btnupdate_Click" /></td>
                      </tr>
                  </table>

                  </div>
              </div>
                 </asp:Panel>

    <div class="kotakdata">
        <div class="kotakisi">
            <table>
                <tr>
                <td><asp:TextBox runat="server" ID="txtstaffid" CssClass="tb722" placeholder="Staff ID"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:TextBox runat="server" Width="500" ID="txtnamastaff" CssClass="tb722" placeholder="Nama Staff"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtrolesid" CssClass="tb722" placeholder="Roles ID" ReadOnly="true"></asp:TextBox></td>
                <td><asp:DropDownList AutoPostBack="true" CssClass="select" runat="server" ID="dproles" OnSelectedIndexChanged="dproles_SelectedIndexChanged">
                    <asp:ListItem Text="--Nama Roles--"></asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtpassword" CssClass="tb722" placeholder="Password Staff"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ReadOnly="true" ID="txtcreatedby" CssClass="tb722" placeholder="Petugas Input Data"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtcreatedon" ReadOnly="true" CssClass="tb722" placeholder="Waktu Dibuat"></asp:TextBox></td>
                </tr>
             
                    
             
            </table>
                                <asp:Button runat="server" ID="btnsimpan" Text="Simpan" CssClass="button" OnClick="btnsimpan_Click"/>
            <asp:Button runat="server" ID="btnhapus" Text="Hapus" CssClass="button" BackColor="Red" OnClick="btnhapus_Click" />
        </div>
        <div class="kotakgrid">
            <asp:GridView runat="server" CssClass="mGrid" EmptyDataText="Tidak Ada Data" ID="dgdatastaff" AllowPaging="True" OnPageIndexChanging="dgdatastaff_PageIndexChanging" PageSize="5" AutoGenerateEditButton="False" AutoGenerateSelectButton="True"  OnSelectedIndexChanging="dgdatastaff_SelectedIndexChanging" OnSelectedIndexChanged="dgdatastaff_SelectedIndexChanged" >
                <PagerSettings FirstPageText="First"  LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
            </asp:GridView>
        </div>
        </div>
                      </div>
    </div>
</asp:Content>

