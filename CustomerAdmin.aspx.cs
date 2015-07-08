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
    SqlConnection cns = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
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
        if(cns.State != ConnectionState.Open)
            cns.Open();
        SqlCommand getusers = new SqlCommand("spGetUsers", cns);
        getusers.CommandType = System.Data.CommandType.StoredProcedure;
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString.ToString();
        ds.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.SelectCommand = "spGetUsers";
        ds.DataBind();
        cns.Close();
        Cust_Admin_GridView.DataSource = ds;
        Cust_Admin_GridView.DataBind();
        
    }

    protected void detailsview_insert(object sender, DetailsViewInsertEventArgs e)
    {
 
    }

    protected void DV_ItemInsert(object sender, DetailsViewInsertEventArgs e)
    {
        TextBox txtb_uname =(TextBox)((DetailsView)sender).Rows[0].Cells[1].Controls[0];
        TextBox txtb_eaddress = (TextBox)((DetailsView)sender).Rows[1].Cells[1].Controls[0];
        if (cns.State != ConnectionState.Open)
            cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
        SqlCommand command = new SqlCommand("spAddandUpdateUser", sqlcon);
        command.CommandType = CommandType.StoredProcedure;
        //command.Parameters.Add("@Userid", SqlDbType.Int).Value = int.Parse(row.Cells[2].Text);
        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = txtb_uname.Text;
        command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = txtb_eaddress.Text;
        sqlcon.Open();
        command.ExecuteNonQuery();
        sqlcon.Close();
        detailsview_bind();
        gridview_bind();
    }
    protected void detailsview_bind()
    {
        if (cns.State != ConnectionState.Open)
            cns.Open();
        SqlCommand getusers = new SqlCommand("spGetUsers", cns);
        getusers.CommandType = System.Data.CommandType.StoredProcedure;
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString.ToString();
        ds.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.SelectCommand = "spGetUsers";
        ds.DataBind();
        cns.Close();
        CustAdmin_DetailsView.DataSource = ds;
        CustAdmin_DetailsView.DataBind();
    }

    protected void grid_rowedit(object sender, GridViewEditEventArgs e)
    {
        Cust_Admin_GridView.EditIndex = e.NewEditIndex;
        gridview_bind();
    }

    protected void grid_rowupdating(object sender, GridViewUpdateEventArgs e)
    {
        //int userid = Convert.ToInt32(Cust_Admin_GridView.DataKeys[e.RowIndex].ToString());
        GridViewRow row = (GridViewRow)Cust_Admin_GridView.Rows[e.RowIndex];
        TextBox TxtBUsername = (TextBox)row.Cells[3].Controls[0];
        TextBox TxtBemailaddress =  (TextBox)row.Cells[4].Controls[0];
        //TextBox TxtBUserID = (TextBox)row.Cells[2].Text;
        cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        //ds.UpdateParameters.Add("@Username","Username");
        //ds.UpdateParameters.Add("@EmailAddress", "EmailAddress");
        //ds.UpdateParameters.Add("@Userid", "Userid");
        //int userid = int.Parse(TxtBUserID.Text.ToString());
        //ds.UpdateParameters["Username"].DefaultValue = TxtBUsername.Text;
        //ds.UpdateParameters["EmailAddress"].DefaultValue = TxtBemailaddress.Text;
        //ds.UpdateParameters["Userid"].DefaultValue = TxtBUserID.Text.ToString();
        //ds.UpdateCommand = "spAddandUpdateUser";
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
        SqlCommand command = new SqlCommand("spAddandUpdateUser", sqlcon);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Userid", SqlDbType.Int).Value = int.Parse(row.Cells[2].Text);
        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = TxtBUsername.Text;
        command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = TxtBemailaddress.Text;
        sqlcon.Open();
        command.ExecuteNonQuery();
        sqlcon.Close();
        //ds.Update();
        Cust_Admin_GridView.EditIndex = -1;
        gridview_bind();
        
    }

    protected void grid_rowdeleted(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)Cust_Admin_GridView.Rows[e.RowIndex];
        //TextBox TxtB_userid = (TextBox)row.Cells[2].Controls[0];
        //ds.DeleteCommand = "spDeleteUser";
        //ds.DeleteParameters.Add("@Userid", row.Cells[0].Controls[0].ToString());
        if (cns.State != ConnectionState.Open)
            cns.Open();
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
        SqlCommand command = new SqlCommand("spDeleteUser", sqlcon);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Userid", SqlDbType.Int).Value = int.Parse(row.Cells[2].Text);
        sqlcon.Open();
        command.ExecuteNonQuery();
        sqlcon.Close();
        //ds.Delete();
        gridview_bind();
    }

    protected void CustAdmin_DetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void Cust_Admin_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}