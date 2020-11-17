<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyUI.aspx.cs" Inherits="StockManagementSystemApp.UI.CompanyUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset style="height: 268px; width: 424px">
            <legend>Company Setup</legend>
        
        <table>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="auto-style1"></td>
                 
                 
                <td class="auto-style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
            </tr>
        </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            <br />
         <br />
       <asp:GridView ID="companiesGridView" runat="server" AutoGenerateColumns="false" Width="228px" style="margin-left: 89px">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                       <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("CompanyName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
      </Columns>
        </asp:GridView>
                </fieldset>
    </div>
    </form>
</body>
</html>
