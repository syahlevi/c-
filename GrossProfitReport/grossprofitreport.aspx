<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/dashboard1.master" AutoEventWireup="true" CodeFile="grossprofitreport.aspx.cs" Inherits="GrossProfitReport_grossprofitreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
    <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="stylegrossprofit.css" type="text/css" />
    <link rel="stylesheet" href="stylenettprof.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content">
        <div class="pageheader">
            <div class="rowss">
                <div class="columnss left">
                    <img src ="../asset/102-512.png" height="50" width="50" />
                </div>
                <div class="columnss">
                    <h3>Gross Profit</h3>
                </div>
            </div>
        </div>
          <div class="data">
              <table>
                  <tr>
                      <td>
                          Tanggal Reports :
                      </td>
                      <td>
                          <asp:Label runat="server" ID="lbdate"></asp:Label>
                      </td>
                  </tr>
                  <tr>

                      <td>
                          Month Profits :
                      </td>
                      <td>
                          <asp:DropDownList runat="server" ID="dpmonth"></asp:DropDownList>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          Year Profits :
                      </td>
                      <td> <asp:DropDownList runat="server" ID="dpyear"></asp:DropDownList></td>
                  </tr>
              </table>
          </div>
          </div>
</asp:Content>

