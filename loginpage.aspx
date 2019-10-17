<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginpage.aspx.cs" Inherits="loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="stylelogin.css" type="text/css" />
     <title>E-Filing Login Page</title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta name="HandheldFriendly" content="true" />
<meta name="viewport" content="width=device-width, initial-scale=1.0">

</head>
<body>
    <form id="form1" runat="server">
  
    <div class="row">
      
        <div class="column op">
            <h3> Akunting Application Web Based</h3>
        </div>
        <div class="column">
            <img src="asset/icon-documents-11.jpg.png"  height="90" width="90"/>
           
        </div>
     
        <div class="column">
            
            <table>

                <tr>
                   <td></td>
                    <td>
                        <asp:TextBox CssClass="tb7" runat="server" placeholder="Masukkan Username Anda" ID="txtusername" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                  <td></td>
                    <td>
                        <asp:TextBox runat="server" CssClass="tb7" TextMode="Password" placeholder="Masukkan Password Anda" ID="txtpassword" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
               <td></td>
                    <td>
                        <asp:Button runat="server" CssClass="button" ID="btnlogin" Text="Login" Height="54px" Width="200px" OnClick="btnlogin_Click" />
                    </td>
                </tr>
            </table>
               
        </div>
    </div>
    </form>
</body>
</html>
