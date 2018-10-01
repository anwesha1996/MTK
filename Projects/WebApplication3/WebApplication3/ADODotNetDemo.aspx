<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADODotNetDemo.aspx.cs" Inherits="WebApplication3.ADODotNetDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 100px;
        }

        .auto-style3 {
            width: 95px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="User Name" ID="usernamelabelId"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="UsernameId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Email ID"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="EmailId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Contact"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="ContactId" runat="server"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </div>
        <div>  
        <asp:Label ID="Label1" runat="server"></asp:Label>  
    </div>  
    </form>
    <table class="auto-style1">  
        <tr>  
            <td class="auto-style3">  
                <asp:Label ID="Label2" runat="server"></asp:Label></td>  
            <td>  
                <asp:Label ID="Label5" runat="server"></asp:Label></td>  
        </tr>  
        <tr>  
            <td class="auto-style3">  
                <asp:Label ID="Label3" runat="server"></asp:Label></td>  
            <td>  
                <asp:Label ID="Label6" runat="server"></asp:Label></td>  
        </tr>  
        <tr>  
            <td class="auto-style3">  
                <asp:Label ID="Label4" runat="server"></asp:Label></td>  
            <td>  
                <asp:Label ID="Label7" runat="server"></asp:Label></td>  
        </tr>  
    </table>  
</body>
</html>
