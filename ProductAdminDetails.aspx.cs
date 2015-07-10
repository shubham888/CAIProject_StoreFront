using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ProductAdminDetails : System.Web.UI.Page
{
    int ProductID;
    SqlDataSource ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        ProductID = int.Parse(Request.QueryString["ProductID"]);
        if (!IsPostBack)
        {
            DV_Databind();
            GV_ProdVariant_DataBind();
        }

    }

    protected void DV_Databind()
    {
        string procname = "spGetProducts";
        string[,] p = new string[2, 1];
        p[0, 0] = "ProductID";
        p[1, 0] = ProductID.ToString();
        ds = SQLInteractor.DataSourceSelect(procname, p);
        ds.DataBind();
        //cns.Close();
        ProdDetInsert_DV.DataSource = ds;
        ProdDetInsert_DV.DataBind();
    }

    protected void GV_ProdVariant_DataBind()
    {

        string[,] p = new string[2, 1];
        p[0, 0] = "ProductID";
        p[1, 0] = ProductID.ToString();
        string procname = "spGetProductVariants";
        ds = SQLInteractor.DataSourceSelect(procname, p);
        //ds.DataBind();
        CustAdminDet_Address_GV.DataSource = ds;
        CustAdminDet_Address_GV.DataBind();
    }

    protected void DV_Onmodechanging(object sender, DetailsViewModeEventArgs e)
    {
        Response.Redirect(@"~\ProductsAdmin.aspx");
    }

    protected void DV_ItemUpdating(Object sender, DetailsViewUpdateEventArgs e)
    {
        string[,] p = new string[2, 6];
        p[0, 0] = "ProductID";
        p[1, 0] = ProductID.ToString();
        p[0, 1] = "ProductName";
        p[1, 1] = ((TextBox)((DetailsView)sender).Rows[0].Cells[1].Controls[0]).Text;
        p[0, 2] = "Description";
        p[1, 2] = ((TextBox)((DetailsView)sender).Rows[1].Cells[1].Controls[0]).Text;
        p[0, 3] = "IsPublished";
        p[1, 3] = ((TextBox)((DetailsView)sender).Rows[2].Cells[1].Controls[0]).Text;
        p[0, 4] = "Quantity";
        p[1, 4] = ((TextBox)((DetailsView)sender).Rows[3].Cells[1].Controls[0]).Text;
        p[0, 5] = "Price";
        p[1, 5] = ((TextBox)((DetailsView)sender).Rows[4].Cells[1].Controls[0]).Text;
        string procname = "spAddandInsertProduct";
        ds = SQLInteractor.DataSourceUpdate(procname, p);

        Response.Redirect(@"~\ProductsAdmin.aspx");
    }
    protected void delete_click(object sender, EventArgs e)
    {
        string[,] p = new string[2, 1];
        string procname = "spDeleteProduct";
        p[0, 0] = "ProductID";
        p[1, 0] =ProductID.ToString();
        ds = SQLInteractor.DataSourceDelete(procname, p);
        Response.Redirect(@"~\ProductsAdmin.aspx");
    }
}