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
    public partial class ViewOrder : System.Web.UI.Page
    {
        Connection conobj = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            gridbind();
        }
        
        public void gridbind()
        {
            string sel = "select Userreg.name,Bill.status from Userreg join Bill on Userreg.userid=Bill.userid where Bill.status='Paid'";
            DataSet ds = conobj.Fn_Dataset(sel);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "update Bill set status='Delivered' where status='Paid'";
            conobj.Fn_Nonquery(sel);
            Label1.Visible = true;
            Label1.Text = "Updated Successfully";
            gridbind();
        }
    }
}