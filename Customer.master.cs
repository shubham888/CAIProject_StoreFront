using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer : CustomerBase
{
    string[] usr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            usr=loadcustomer();
        }
         
    }
}
