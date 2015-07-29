<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Customer_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cust_master" Runat="Server">
    <asp:GridView ID="shoppingcart_gv" runat="server" AllowSorting="true" PageSize="50" AllowPaging="true" AutoGenerateColumns="false" Width="100%" 
                    style="color:black;text-align:center">
                    <Columns>
                        <%--<ASP:HYPERLINKFIELD ControlStyle-ForeColor="Gray" DataNavigateUrlFields="ProductID" text="Add to Cart" datanavigateurlformatstring="CustomerAdminDetails.aspx?ProductID={0}"></ASP:HYPERLINKFIELD>--%>
                        <asp:BoundField DataField="ProductID" HeaderText="UserID"  ReadOnly="true" />
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName"  ReadOnly="true" />
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" 
                                           ImageUrl='<%# "ImageHandler.ashx?ID=" + Convert.ToString(Eval("ProductID"))%>'/>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField  Text="UpdateCart"  />
            </Columns>
      </asp:GridView>
</asp:Content>

