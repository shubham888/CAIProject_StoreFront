using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class CustomerAdminDetails : System.Web.UI.Page
{
    int UserID;
    SqlConnection cns = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
    SqlDataSource ds = new SqlDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
            UserID = int.Parse(Request.QueryString["UserID"]);
            DV_Databind();
        //}
       
    }

    protected void DV_Databind()
    {
        if (cns.State != ConnectionState.Open)
            cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
        SqlCommand command = new SqlCommand("spGetUsers", sqlcon);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Userid", SqlDbType.Int).Value = UserID;
        //Parameter p = new Parameter("UserID");
        ds.SelectParameters.Add("UserID",UserID.ToString());
        ds.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.SelectParameters["UserID"].DefaultValue = UserID.ToString();
        ds.SelectCommand = command.CommandText.ToString();
        ds.DataBind();
        cns.Close();
        CustDet_DV.DataSource = ds;
        CustDet_DV.DataBind();

    }
}