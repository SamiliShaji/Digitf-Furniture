using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace project1Asp
{
    public partial class UserProduct : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
                string str = "select * from Product where categoryid='"+Session["cid"]+"'";
                DataSet ds = conobj.Fn_Dataset(str);
                DataList1.DataSource = ds;
                DataList1.DataBind();
           }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            Session["pid"] = getid;
            Response.Redirect("ViewProducts.aspx");
        }
    }
}