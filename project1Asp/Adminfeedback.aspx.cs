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
    public partial class Adminfeedback : System.Web.UI.Page
    {
        Connection conobj = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                fn_gridbind();
            }
        }
        public void fn_gridbind()
        {
            string s = "select Userreg.*,feedbacktab.* from Userreg INNER JOIN feedbacktab ON Userreg.userid=feedbacktab.userid WHERE feedbacktab.feedback_status=0";
            DataSet ds = conobj.Fn_Dataset(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            Session["getid"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Replytofeedback.aspx");
        }
    }
}