<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerAdminDetails.aspx.cs" Inherits="CustomerAdminDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Admin Details</title>
</head>
<body>
    <form id="CustAdminDetails_form" runat="server">
    <table>
        <tr>
            <td>
                Check
            </td>
        </tr>
        <tr>
            <td style="width:100%;align-items:center;padding-left:100px" >
             <asp:DetailsView ID="CustDet_DV" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" style="color:black" DefaultMode="Edit">
                 <Fields>
                <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="100px" />
                <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" ItemStyle-Width="30px"  />
                <asp:CommandField ShowEditButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />
        </Fields>
             </asp:DetailsView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
