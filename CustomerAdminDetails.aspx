<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerAdminDetails.aspx.cs" Inherits="CustomerAdminDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Admin Details</title>
</head>
<body>
    <form id="CustAdminDetails_form" runat="server">
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
                <p style="color:darkgray">Update User Details here</p>
            </td>
        </tr>
        <tr>
            <td style="width:100%;align-items:center;padding-left:100px;" >
             <asp:DetailsView ID="CustDet_DV" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" style="color:black" DefaultMode="Edit" OnItemUpdating="DV_ItemUpdating"  OnModeChanging="DV_Onmodechanging">
                 <Fields>
                <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="100px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" ItemStyle-Width="30px" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White"  />
                <asp:CommandField ShowEditButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />
        </Fields>
             </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td style="padding-top:25px;padding-left:10px">
                <asp:GridView ID="CustAdminDet_Address_GV" runat="server" AutoGenerateColumns="true" Width="100%" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" PageSize="50">

                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
