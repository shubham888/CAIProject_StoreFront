using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class CustomerAdmin : System.Web.UI.Page
{
    //SqlConnection cns = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            detailsview_bind();
            gridview_bind();
            CustAdmin_DetailsView.DefaultMode = DetailsViewMode.Insert;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void gridview_bind()
    {
        string[,] p = new string[0, 0];
        string procname = "spGetUsers";
        ds = SQLInteractor.DataSourceSelect(procname, p);

        Cust_Admin_GridView.DataSource = ds;
        Cust_Admin_GridView.DataBind();
        
    }

    protected void detailsview_insert(object sender, DetailsViewInsertEventArgs e)
    {
 
    }

    protected void DV_ItemInsert(object sender, DetailsViewInsertEventArgs e)
    {
        string procname = "spAddandUpdateUser";
        string[,] p = new string[2, 2];
        p[0, 0] = "Username";
        p[1, 0] = ((TextBox)((DetailsView)sender).Rows[0].Cells[1].Controls[0]).Text;
        p[0, 1] = "EmailAddress";
        p[1, 1] = ((TextBox)((DetailsView)sender).Rows[1].Cells[1].Controls[0]).Text;
        ds = SQLInteractor.DataSourceInsert(procname, p);

        detailsview_bind();
        gridview_bind();
    }
    protected void detailsview_bind()
    {
        string[,] p = new string[0,0];
        string procname = "spGetUsers";
        ds = SQLInteractor.DataSourceSelect(procname, p);

        CustAdmin_DetailsView.DataSource = ds;
        CustAdmin_DetailsView.DataBind();
    }

    protected void grid_rowedit(object sender, GridViewEditEventArgs e)
    {
        Cust_Admin_GridView.EditIndex = e.NewEditIndex;
        gridview_bind();
    }

    //protected void grid_rowupdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    //int userid = Convert.ToInt32(Cust_Admin_GridView.DataKeys[e.RowIndex].ToString());
    //    GridViewRow row = (GridViewRow)Cust_Admin_GridView.Rows[e.RowIndex];
    //    TextBox TxtBUsername = (TextBox)row.Cells[3].Controls[0];
    //    TextBox TxtBemailaddress =  (TextBox)row.Cells[4].Controls[0];
    //    //TextBox TxtBUserID = (TextBox)row.Cells[2].Text;
    //    cns.Open();
    //    ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
    //    //ds.UpdateParameters.Add("@Username","Username");
    //    //ds.UpdateParameters.Add("@EmailAddress", "EmailAddress");
    //    //ds.UpdateParameters.Add("@Userid", "Userid");
    //    //int userid = int.Parse(TxtBUserID.Text.ToString());
    //    //ds.UpdateParameters["Username"].DefaultValue = TxtBUsername.Text;
    //    //ds.UpdateParameters["EmailAddress"].DefaultValue = TxtBemailaddress.Text;
    //    //ds.UpdateParameters["Userid"].DefaultValue = TxtBUserID.Text.ToString();
    //    //ds.UpdateCommand = "spAddandUpdateUser";
    //    SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
    //    SqlCommand command = new SqlCommand("spAddandUpdateUser", sqlcon);
    //    command.CommandType = CommandType.StoredProcedure;
    //    command.Parameters.Add("@Userid", SqlDbType.Int).Value = int.Parse(row.Cells[2].Text);
    //    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = TxtBUsername.Text;
    //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = TxtBemailaddress.Text;
    //    sqlcon.Open();
    //    command.ExecuteNonQuery();
    //    sqlcon.Close();
    //    //ds.Update();
    //    Cust_Admin_GridView.EditIndex = -1;
    //    gridview_bind();
        
    //}

    protected void grid_rowdeleted(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)Cust_Admin_GridView.Rows[e.RowIndex];

        string[,] p = new string[2, 1];
        string procname = "spDeleteUser";
        p[0, 0] = "Userid";
        p[1, 0] = (row.Cells[2].Text);
        ds = SQLInteractor.DataSourceDelete(procname, p);

        gridview_bind();
    }

    protected void CustAdmin_DetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void Cust_Admin_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}