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
            UserID = int.Parse(Request.QueryString["UserID"]);
            if (!IsPostBack)
            {
                DV_Databind();
                GV_Address_DataBind();
            }

        }

        protected void DV_Databind()
        {
            string procname = "spGetUsers";
            string[,] p = new string[2, 1];
            p[0, 0] = "Userid";
            p[1, 0] = UserID.ToString();
            ds = SQLInteractor.DataSourceSelect(procname, p);
            ds.DataBind();
            cns.Close();
            CustDet_DV.DataSource = ds;
            CustDet_DV.DataBind();
        }

        protected void GV_Address_DataBind()
        {
            
            string[,] p = new string[2, 1];
            p[0, 0] = "Userid";
            p[1, 0] = UserID.ToString();
            string procname = "spGetUserAddresses";
            ds=SQLInteractor.DataSourceDelete(procname,p);
            //ds.DataBind();
            CustAdminDet_Address_GV.DataSource = ds;
            CustAdminDet_Address_GV.DataBind();
        }

        protected void DV_ItemUpdating(Object sender, DetailsViewUpdateEventArgs e)
        {
            string[,] p = new string[2, 3];
            p[0, 0] = "Userid";
            p[1, 0] = UserID.ToString();
            p[0, 1] = "Username";
            p[1, 1] = ((TextBox)((DetailsView)sender).Rows[0].Cells[1].Controls[0]).Text;
            p[0, 2] = "EmailAddress";
            p[1, 2] = ((TextBox)((DetailsView)sender).Rows[1].Cells[1].Controls[0]).Text;
            string procname = "spAddandUpdateUser";
            ds = SQLInteractor.DataSourceUpdate(procname, p);

            Response.Redirect(@"~\CustomerAdmin.aspx");
        }

        protected void DV_Onmodechanging(object sender, DetailsViewModeEventArgs e)
        {
            Response.Redirect(@"~\CustomerAdmin.aspx");
        }

    }