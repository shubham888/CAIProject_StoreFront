using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public static class SQLInteractor
{
    static SqlConnection cns = new SqlConnection(ConfigurationManager.ConnectionStrings["cns"].ConnectionString);
    static SqlDataSource ds;



    public static SqlDataSource DataSourceSelect(string sp, string[,] param)
    {
        ds = new SqlDataSource();
        if (cns.State != ConnectionState.Open)
            cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        ds.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.SelectCommand = sp;
        
        for (int i = 0; i < param.GetLength(1); i++)
        {
            ds.SelectParameters.Add(param[0, i], param[1, i]);
            ds.SelectParameters[param[0,i]].DefaultValue = param[1,i];
        }
        ds.DataBind();
        return ds;
    }

    public static SqlDataSource DataSourceInsert(string sp, string[,] param)
    {
        float f;
        ds = new SqlDataSource();
        if (cns.State != ConnectionState.Open)
            cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        ds.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.InsertCommand = sp;

        for (int i = 0; i < param.GetLength(1); i++)
        {
            ds.InsertParameters.Add(param[0, i], param[1, i]);
            ds.InsertParameters[param[0, i]].DefaultValue = param[1, i];
            if(float.TryParse(param[1, i],out f))
                ds.InsertParameters[param[0, i]].Type = System.TypeCode.Double;
        }
        ds.Insert();
        return ds;
    }

    public static SqlDataSource DataSourceUpdate(string sp, string[,] param)
    {
        ds = new SqlDataSource();
        if (cns.State != ConnectionState.Open)
            cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        ds.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.UpdateCommand = sp;

        for (int i = 0; i < param.GetLength(1); i++)
        {
            ds.UpdateParameters.Add(param[0, i], param[1, i]);
            ds.UpdateParameters[param[0, i]].DefaultValue = param[1, i];
        }
        ds.Update();
        return ds;
    }

    public static SqlDataSource DataSourceDelete(string sp, string[,] param)
    {
        ds = new SqlDataSource();
        if (cns.State != ConnectionState.Open)
            cns.Open();
        ds.ConnectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        ds.DeleteCommandType = SqlDataSourceCommandType.StoredProcedure;
        ds.DeleteCommand = sp;

        for (int i = 0; i < param.GetLength(1); i++)
        {
            ds.DeleteParameters.Add(param[0, i], param[1, i]);
            ds.DeleteParameters[param[0, i]].DefaultValue = param[1, i];
        }
        ds.Delete();
        return ds;
    }
}
