<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchViewUI.aspx.cs" Inherits="StockManagementSystemApp.UI.SearchViewUI" %>

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
                  <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label></td>
              <td>
                  <asp:DropDownList ID="companyDropDownList" runat="server"></asp:DropDownList></td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label></td>
              <td>
                  <asp:DropDownList ID="categoryDropDownList" runat="server"></asp:DropDownList></td>
          </tr>
          <tr>
              <td></td>
            
              
              <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" /></td>
          </tr>
      </table>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
         <br />
       <asp:GridView ID="searchAndViewGridView" runat="server" AutoGenerateColumns="false">
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
                 <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("CompanyName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("CatagoryName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Available Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("AvailableQuantity") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Reorder Level">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("ReorderLevel") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
      </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
