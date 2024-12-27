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
    public partial class feedbackuser : System.Web.UI.Page
    {
        Connection conobj = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "insert into feedbacktab values(" + Session["userid"] + ",'" + TextBox1.Text + "','',0)";
            int i = conobj.Fn_Nonquery(ins);
            if(i==1)
            {
                Label2.Visible = true;
                Label2.Text = "Submitted";
            }
        }
    }
}