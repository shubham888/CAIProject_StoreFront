<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerAdmin.aspx.cs" Inherits="CustomerAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Master_CPHolder" Runat="Server">
    <div>
    <asp:GridView PageSize="50" AllowPaging="true" ID="Cust_Admin_GridView" AutoGenerateColumns="false" runat="server" Width="100%" style="color:black;text-align:center" OnRowEditing ="grid_rowedit" OnRowUpdating="grid_rowupdating" OnRowDeleting="grid_rowdeleted">
    <Columns>
        <%--<asp:CommandField ShowEditButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />--%>
        <ASP:HYPERLINKFIELD ControlStyle-ForeColor="Gray" DataNavigateUrlFields="UserID" text="Edit" datanavigateurlformatstring="CustomerAdminDetails.aspx?UserId={0}"></ASP:HYPERLINKFIELD>
        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />
        <asp:BoundField DataField="UserID" HeaderText="UserID" ItemStyle-Width="30%" ReadOnly="true" />
        <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="30%" />
        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" ItemStyle-Width="30%"  />
        </Columns>
    </asp:GridView>
    <asp:sqldatasource id="ds" runat="server"> 
        <updateparameters> 
                <asp:parameter name="Username" type="String" /> 
                <asp:parameter name="EmailAddress" type="String" /> 
                <asp:parameter name="Userid" type="Int32" /> 
        </updateparameters> 
</asp:sqldatasource>
        </div>
    <div >
        <table style="width:100%">
        <tr>
            <td style="padding-top:50px;padding-left:25%">
        <asp:DetailsView ID="CustAdmin_DetailsView" runat="server" Height="101px" Width="334px" AutoGenerateRows="False" AutoGenerateInsertButton="true" style="color:black" DefaultMode="Insert" OnItemInserting="DV_ItemInsert" OnPageIndexChanging="CustAdmin_DetailsView_PageIndexChanging" >
            <Fields>
                <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="100px" />
                <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" ItemStyle-Width="30px"  />
                <asp:CommandField  ShowInsertButton="true" ControlStyle-ForeColor="Gray" ItemStyle-Width="5%" />
        </Fields>
     </asp:DetailsView>
       </td>
    </tr>
    </table>
    </div>
</asp:Content>

