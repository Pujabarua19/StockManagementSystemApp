<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystemApp.UI.StockOutUI" %>

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
                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label> </td>
            <td><asp:DropDownList ID="companyDropDownList" runat="server" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td></td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label></td>
            <td>
                <asp:DropDownList ID="itemDropDownList" runat="server" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label></td> 
            <td>
                <asp:TextBox ID="reorderLavelTextBox" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label></td>
            <td>
                <asp:TextBox ID="availableQuantityTextBox" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label></td>
            <td>
                <asp:TextBox ID="stockOutQuantityTextBox" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td></td>
            <td>
                <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" /></td>
        </tr>
    </table>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
         <br />
       <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                       <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("ItemName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("AvailableQuantity") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Comapany">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("CompanyName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
      </Columns>
        </asp:GridView>
        <table>
            <td></td><td>
                <asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" /></td><td>
                    <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" /></td>
            <td>
                <asp:Button ID="lostButton" runat="server" Text="Lost" OnClick="lostButton_Click" /></td>
        </table>
    </div>
    </form>
</body>
</html>
