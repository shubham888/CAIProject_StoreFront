<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductsAdmin.aspx.cs" Inherits="ProductsAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID ="ProductsAdminGridView" runat="server" DataSourceID="SqlDataSource1"
     AllowPaging="True" AllowSorting="True" AutoGenerateEditButton="true" 
      DataKeyNames="AutoID" PageSize="8"></asp:GridView>
    </div>
    </form>
</body>
</html>
