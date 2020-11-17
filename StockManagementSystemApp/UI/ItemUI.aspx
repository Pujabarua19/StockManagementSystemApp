<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemUI.aspx.cs" Inherits="StockManagementSystemApp.UI.ItemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label></td>
            <td class="auto-style1"><asp:DropDownList runat="server" Width="209px" ID="categoryDropDownList">
               
                </asp:DropDownList>
            </td>
        </tr>
            
          <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label></td>
            <td class="auto-style1"><asp:DropDownList runat="server" Width="209px" ID="companyDropDownList">
               
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label></td>
            <td> <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Record Level"></asp:Label></td>
            <td>
                <asp:TextBox ID="recordLevelTextBox" runat="server"></asp:TextBox></td>
        </tr>
          <tr>
            <td></td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
        </tr>
    </table>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
