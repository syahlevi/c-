<%@ page title="" language="C#" masterpagefile="~/masterpage/dashboard1.master" autoeventwireup="true" codefile="GrossProfit.aspx.cs" inherits="GrossProfit_GrossProfit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../asset/styledashboard.css" type="text/css" />
    <link rel="stylesheet" href="../asset/sidebarw3.css" type="text/css" />
    <link rel="stylesheet" href="../asset/ajaxcss.css" type="text/css" />
    <link rel="stylesheet" href="stylegrossprofit.css" type="text/css" />
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
        <div class="containers">
         <div class="data">
            <table>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtyeargrossprof" placeholder="Year" CssClass="tb7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server"  ID="txtmonthgrossprof"  placeholder="Month" CssClass="tb7" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
            <asp:GridView runat="server" ID="gridgrossprof" AutoGenerateColumns="true" CssClass="mGrid" EmptyDataText="Tidak ADA Data"></asp:GridView>
        </div>
        
        </div>



    </div>
</asp:content>

