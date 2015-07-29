using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ProductsAdmin : System.Web.UI.Page
{
    SqlDataSource ds;
    private const string PASCENDING = " ASC";
    private const string PDESCENDING = " DESC";

    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GV_databind();
        }
    }

    protected void GV_sort(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, PDESCENDING);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, PASCENDING);
        }

    }


    private void SortGridView(string sortExpression, string direction)
    {
        //  You can cache the DataTable for improving performance
        string[,] p = new string[0, 0];
        ds = SQLInteractor.DataSourceSelect("spGetProducts", p);
        DataView dv = (DataView)(ds.Select(DataSourceSelectArguments.Empty));
        DataTable dt = dv.ToTable();
        dv.Sort = sortExpression + direction;

        Prod_Admin_GridView.DataSource = dv;
        Prod_Admin_GridView.DataBind();
    }
    protected void GV_databind()
    {
        string[,] p = new string[0, 0];
        string procname = "spGetProducts ";
        ds = SQLInteractor.DataSourceSelect(procname, p);

        Prod_Admin_GridView.DataSource = ds;
        Prod_Admin_GridView.DataBind();
    }


    protected void DV_ItemInsert(object sender, DetailsViewInsertEventArgs e)
    {
        string procname = "spAddandInsertProduct";
        string[,] p = new string[2, 5];
        p[0, 0] = "ProductName";
        p[1, 0] = ((TextBox)((DetailsView)sender).Rows[0].Cells[1].Controls[0]).Text;
        p[0, 1] = "Description";
        p[1, 1] = ((TextBox)((DetailsView)sender).Rows[1].Cells[1].Controls[0]).Text;
        p[0, 2] = "IsPublished";
        p[1, 2] = ((TextBox)((DetailsView)sender).Rows[2].Cells[1].Controls[0]).Text;
        p[0, 3] = "Quantity";
        p[1, 3] = ((TextBox)((DetailsView)sender).Rows[3].Cells[1].Controls[0]).Text;
        p[0, 4] = "Price";
        p[1, 4] = ((TextBox)((DetailsView)sender).Rows[4].Cells[1].Controls[0]).Text;
        ds = SQLInteractor.DataSourceInsert(procname, p);

        ProdAdmin_insertDV.DataSource = ds;
        ProdAdmin_insertDV.DataBind();
        GV_databind();
    }
    protected void ProdAdmin_insertDV_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }

    protected void DV_ModeChange(object sender, DetailsViewModeEventArgs  e)
    {
        ((TextBox)((DetailsView)sender).Rows[0].Cells[1].Controls[0]).Text = string.Empty;
        ((TextBox)((DetailsView)sender).Rows[1].Cells[1].Controls[0]).Text = string.Empty;
        ((TextBox)((DetailsView)sender).Rows[2].Cells[1].Controls[0]).Text = string.Empty;
        ((TextBox)((DetailsView)sender).Rows[3].Cells[1].Controls[0]).Text = string.Empty;
        ((TextBox)((DetailsView)sender).Rows[4].Cells[1].Controls[0]).Text = string.Empty;
    }
}