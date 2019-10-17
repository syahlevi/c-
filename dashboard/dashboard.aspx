<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
        <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="content">
         
           <div class="pageheader">
               <div class="rowss">
                   <div class="columnss left">
               <img src="../asset/102-512.png" height="50" width="50" />
                       </div>
                   <div class="columnss">
<h3>Dashboard</h3> 
                       </div>
                   </div>
           </div>

          <div class="containers">
        
             <asp:Panel runat="server" CssClass="modal" ID="panelmodal">
          <div class="modal-content">
          <div class="headermodal"> 
              <div class="mod">              
                  <asp:Button runat="server" ID="btnclose" Text="X" CssClass="button"  OnClick="btnclose_Click"     />
                  </div>

                            <h3> User Yang Sedang Login</h3>
              </div>
              <div class="modal-body">
                  <asp:GridView runat="server" CssClass="mGrid" ID="dgreport" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="SqlDataSource1" GridLines="None">
                      <Columns>
                          <asp:BoundField DataField="staffid" HeaderText="staffid" SortExpression="staffid" />
                          <asp:BoundField DataField="loginstart" HeaderText="loginstart" SortExpression="loginstart" />
                          <asp:BoundField DataField="loginout" HeaderText="loginout" SortExpression="loginout" />
                          <asp:BoundField DataField="islogin" HeaderText="islogin" SortExpression="islogin" />
                      </Columns>
                      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                      <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#F1F1F1" />
                      <SortedAscendingHeaderStyle BackColor="#594B9C" />
                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                      <SortedDescendingHeaderStyle BackColor="#33276A" />
                  </asp:GridView>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\SQLEXPRESS;Initial Catalog=db_efile;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [staffid], [loginstart], [loginout], [islogin] FROM [stafflogin] WHERE ([islogin] = @islogin)">
                      <SelectParameters>
                          <asp:Parameter DefaultValue="0" Name="islogin" Type="Decimal" />
                      </SelectParameters>
                  </asp:SqlDataSource>
                  <asp:EntityDataSource ID="EntityDataSource1" runat="server">
                  </asp:EntityDataSource>
              </div>
              </div>
      </asp:Panel>

               <div class="lefts">
                   <div class="column op">
                       Jumlah User Sedang Login
                   </div>
                   <div class="column">
                       <asp:LinkButton runat="server"  ID="lblinklogin" OnClick="lblinklogin_Click" ></asp:LinkButton>
                    
                       </div>
                   <div class="column op">
                      Jumlah Staff
                   </div>
                   <div class="column">
                       <asp:LinkButton runat="server" ID="LinkButtonstaff" OnClick="LinkButtonstaff_Click"></asp:LinkButton>

                      
                   </div>
                   <div class="column op">
                    Jumlah Roles
                   </div>
                   <div class="column">
                      <asp:LinkButton runat="server" ID="linkrole" OnClick="linkrole_Click" ></asp:LinkButton>
                   </div>
                </div>
              </div>
            
            </div>
           
    
</asp:Content>

