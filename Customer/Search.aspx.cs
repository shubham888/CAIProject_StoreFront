using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Search : System.Web.UI.Page
{
    SqlDataSource ds;
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void searchres_gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "add2cart")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            string[,] p = new string[2, 4];
            p[0, 0] = "ProductVariantID";
            p[0, 1] = "UserID";
            p[0, 2] = "user";
            p[0, 3] = "quantity";
            p[1, 0] = "1";
            //p[0, 1] = searchres_gv.Rows[index].Cells[1].Text.ToString();
            p[1, 1] =  Master.uid;
            p[1, 2] = Master.uname;
            p[1, 3] = "1";
            ds = SQLInteractor.DataSourceInsert("spAddShoppingCartItem", p);
        }
    }


    //sp_searchproduct
    protected void SearchButton_Click(object sender, ImageClickEventArgs e)
    {
        gv_databing();
    }

    protected void gv_databing()
    {
        string searchquery = searchtb.Text;
        searchquery = searchquery.TrimEnd();
        searchquery = searchquery.TrimStart();
        if (searchquery != string.Empty)
        {
            string[,] p = new string[2,1];
            p[0, 0] = "searchtext";
            p[1,0] = searchquery;
            string procname = "spSearchProducts";
            ds = SQLInteractor.DataSourceSelect(procname, p);
        }

        else 
        {
            string[,] p = new string[0, 0];
            string procname = "spGetProducts ";
            ds = SQLInteractor.DataSourceSelect(procname, p);
        }

        searchres_gv.DataSource = ds;
        searchres_gv.DataBind();

    }

    public void GV_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Attributes.Add("style", "cursor:pointer;");
            e.Row.Cells[3].Attributes.Add("style", "cursor:pointer;");
            e.Row.Cells[2].Attributes.Add("onClick", "location='ProductDetails.aspx?ProductID=" + e.Row.Cells[1].Text + "'");
            e.Row.Cells[3].Attributes.Add("onClick", "location='ProductDetails.aspx?ProductID=" + e.Row.Cells[1].Text + "'");
        }
    }

    
    //protected void GV_SelectIndexChange (object sender, EventArgs e)  
    //{
    //    GridViewRow selectedRow = searchres_gv.SelectedRow;  
    //    string longurl =@"~/ProductDetails.aspx";
    //    var uriBuilder = new UriBuilder(longurl);
    //    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
    //    query["ProductID"] =  selectedRow.Cells[1].Text ;
    //    uriBuilder.Query = query.ToString();
    //    longurl = uriBuilder.ToString();
    //    Response.Redirect(longurl);
 
    //}  

}