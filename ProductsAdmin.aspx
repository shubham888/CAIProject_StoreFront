<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductsAdmin.aspx.cs" Inherits="ProductsAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<table style="width:100%">
        <tr>
            <td style="width:100%;height:70px;background-color:lightgray;color:black;text-align:center" >
                <h1>
                    StoreFront
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width:100%;align-items:center;padding-left:100px;padding-top:50px">
                <p style="color:black">Product Details</p>
            </td>
        </tr>
    <tr>
            <td style="width:100%;align-items:center;" >
    <asp:GridView PageSize="50" AllowPaging="true" ID="Prod_Admin_GridView" AutoGenerateColumns="true" runat="server" Width="100%" style="color:black;text-align:center" >
    <Columns>
        <%--<asp:CommandField ShowEditButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />--%>
        <ASP:HYPERLINKFIELD ControlStyle-ForeColor="Gray" DataNavigateUrlFields= "ProductID" text="Edit" datanavigateurlformatstring="ProductAdminDetails.aspx?ProductID={0}"></ASP:HYPERLINKFIELD>
        <%--<asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />--%>
       <%-- <asp:BoundField DataField="UserID" HeaderText="UserID" ItemStyle-Width="30%" ReadOnly="true" />
        <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="30%" />
        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" ItemStyle-Width="30%"  />--%>
        </Columns>
    </asp:GridView>
        </td>
        </tr>
    <tr>
       <td style="padding-top:50px;padding-left:25%">
        <asp:DetailsView ID="ProdAdmin_insertDV" runat="server" Height="101px" Width="334px" AutoGenerateRows="False" AutoGenerateInsertButton="true" style="color:black" DefaultMode="Insert" OnItemInserting="DV_ItemInsert"  >
            <Fields>
                
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" ItemStyle-Width="30px" />
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="30px" />
                <asp:BoundField DataField="IsPublished" HeaderText="IsPublished" ItemStyle-Width="30px" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="30px" />
                <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="30px"  />
                <%--<asp:CommandField  ShowInsertButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />--%>
        </Fields>
     </asp:DetailsView>

        </td>
    </tr>
    </table>
    </form>
</body>
</html>
