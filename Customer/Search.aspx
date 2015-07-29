<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Customer_Search" %>

<%@ MasterType VirtualPath="~/Customer.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cust_master" Runat="Server">

    <table style="width:100%">
        <tr>
            <td style="text-align:center" colspan="2">
                <asp:Label ID="SearchLabel" runat="server">
                        <h3>Please enter the name of the product you are looking for </h3>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:60%; height:auto;text-align:right">
                <asp:TextBox ID="searchtb" runat="server" Height="30px" Width="300px" Text="Search Here"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton runat="server" Height="30px" Width="30px" ImageUrl="~/srch_icon.png" OnClick="SearchButton_Click" />
                     <%--OnClick="SrchImage_onclick" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="searchres_gv" runat="server" AllowSorting="true" PageSize="50" AllowPaging="true" AutoGenerateColumns="false" Width="100%"  OnRowCommand="searchres_gv_RowCommand"
                    style="color:black;text-align:center" OnRowDataBound="GV_DataBound">
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:Button runat="server" ForeColor="Gray" CommandArgument="<%# ((GridViewRow) Container).RowIndex %> " CommandName="add2cart" DataNavigateUrlFields="ProductID" text="Add to Cart" 
                            datanavigateurlformatstring="CustomerAdminDetails.aspx?ProductID={0}"></asp:Button>
                        </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="ProductID" HeaderText="UserID"  ReadOnly="true" />
                            <asp:BoundField DataField="ProductName" HeaderText="ProductName"  ReadOnly="true" />
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                  <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" 
                                             ImageUrl='<%# "ImageHandler.ashx?ID=" + Convert.ToString(Eval("ProductID"))%>'/>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>

