using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

/// <summary>
/// Summary description for CustomeBase
/// </summary>
public class CustomerBase : System.Web.UI.MasterPage
{
    string  userid, emailaddress;
    string username = "Kevin Mack";
    SqlDataSource ds;
    string[] usr;

    public string uname
    {
        get { return ViewState["username"] as string; }
        set { ViewState["username"] = usr[1]; }
    }

    public string uid
    {
        get { return ViewState["MyProperty"] as string; }
        set { ViewState["MyProperty"] = usr[0]; }
    }

    protected string[] loadcustomer()
    {
        //
        string[,] p = new string[2, 1];
        usr = new string[2];
        p[0, 0] = "Name";
        p[1, 0] = username;
        ds = SQLInteractor.DataSourceSelect("sp_loaduser", p);
        DataView dv = (DataView)(ds.Select(DataSourceSelectArguments.Empty));
        DataTable dt = dv.ToTable();
        usr[0] = dt.Rows[0][0].ToString();
        usr[1] = username;
        uname = usr[1];
        uid = usr[0];

        HttpCookie cookie = new HttpCookie("SFCookie");
        cookie.Values.Add("EmailAddress", emailaddress);
        cookie.Expires = DateTime.Now.AddHours(12);
        Response.Cookies.Add(cookie);
        return usr;

        #region
        //HttpCookie myCookie = Request.Cookies["myCookie"];
        //if (myCookie == null)
        //{
        //    //No cookie found or cookie expired.
        //    //Handle the situation here, Redirect the user or simply return;
        //}

        ////ok - cookie is found.
        ////Gracefully check if the cookie has the key-value as expected.
        //if (!string.IsNullOrEmpty(myCookie.Values["userid"]))
        //{
        //    string userId = myCookie.Values["userid"].ToString();
        //    //Yes userId is found. Mission accomplished.
        //}
        #endregion
    }

}