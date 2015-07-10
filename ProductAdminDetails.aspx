<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAdminDetails.aspx.cs" Inherits="ProductAdminDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%">
        <tr>
            <td colspan="2" style="width:100%;height:70px;background-color:lightgray;color:black;text-align:center" >
                <h1>
                    StoreFront
                </h1>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width:100%;align-items:center;padding-left:100px;padding-top:50px">
                <p style="color:darkgray">Update Product Details here</p>
            </td>
        </tr>
        <tr>
            <td style="width:300px; align-items:center;padding-left:100px;" >
             <asp:DetailsView ID="ProdDetInsert_DV" runat="server" Height="50px"  AutoGenerateRows="False" style="color:black" DefaultMode="Edit" OnItemUpdating="DV_ItemUpdating"  OnModeChanging="DV_Onmodechanging">
                  <%--OnItemUpdating="DV_ItemUpdating"  OnModeChanging="DV_Onmodechanging">--%>
                 <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" ItemStyle-Width="100px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="100px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White"  />
                <asp:BoundField DataField="IsPublished" HeaderText="IsPublished" ItemStyle-Width="100px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="100px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White"  />
                <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="100px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White"  />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ControlStyle-ForeColor="Gray"  />
        </Fields>
        </asp:DetailsView>
                <asp:Button ID="Delete_button" Text="delete" runat="server" OnClick="delete_click"  />
        </td>
            <td style="vertical-align:top;text-align:left">
                &nbsp;</td>
            </tr>
        <tr>
            <td colspan="2" style="padding-top:25px;padding-left:10px">
                <asp:GridView ID="CustAdminDet_Address_GV" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" PageSize="50">

                </asp:GridView>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
