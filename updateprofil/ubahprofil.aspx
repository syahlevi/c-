<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="ubahprofil.aspx.cs" Inherits="updateprofil_ubahprofil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
        <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="../asset/styleubahprofil.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:Panel runat="server" CssClass="modal" ID="panel1">
          <div class="modal-content">
          <div class="headermodal"> 
              <div class="mod">              
                  <asp:Button runat="server" ID="Button1" Text="X" CssClass="button" OnClick="Button1_Click"      />
                  </div>
              <h3> Ubah Data Personal</h3>
              </div>
              <div class="modal-body">

                  <table>
                      <tr>
                          <td>
                              <asp:TextBox runat="server" ID="txtnamastaff" CssClass="tb7" placeholder="Nama Anda" Width="313px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td> <asp:TextBox runat="server" CssClass="tb7" ID="txtrole" ReadOnly="true"  Width="313px" placeholder="Jabatan Anda"></asp:TextBox></td>
                           <td> <asp:DropDownList CssClass="select" AutoPostBack="true" runat="server" ID="dprole" OnSelectedIndexChanged="dprole_SelectedIndexChanged">
                              <asp:ListItem Text="--Role--"></asp:ListItem>

                               </asp:DropDownList></td>
                          <td><asp:TextBox runat="server" ID="txtidrole" CssClass="tb7"></asp:TextBox></td>
                      </tr>
                      
                      <tr>
                          <td>
                              <asp:TextBox runat="server" Width="313px" placeholder="Password Anda" CssClass="tb7" ID="txtpass"></asp:TextBox>
                          </td>
                      </tr>
                     
                      <tr>
                          <td>
                              <asp:TextBox runat="server" ID="txtmodifiedby" Width="313px" ReadOnly="true" placeholder="Diupdateoleh" CssClass="tb7"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:TextBox runat="server" ReadOnly="true" placeholder="Tanggal Update" ID="txtupdatedate" Width="313px"  CssClass="tb7"></asp:TextBox>
                          </td>
                      </tr>
                       <tr>
                          
                          <td><asp:Button runat="server"  CssClass="button" ID="btn" OnClick="btn_Click" Text="Update" Width="313px" /></td>
                      </tr>
                  </table>

                  </div>
              </div>
                 </asp:Panel>

</asp:Content>

