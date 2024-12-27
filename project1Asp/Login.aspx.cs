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
    public partial class Login : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select Count(regid) from Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string s= conobj.Fn_Scalar(sel);
            
            if (s=="1")
            {
                string sel1 = "select regid from Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string id = conobj.Fn_Scalar(sel1);
                Session["userid"] = id;
                string sel2 = "select logtype from Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string logtype = conobj.Fn_Scalar(sel2);
                if (logtype == "Admin")
                {
                    Response.Redirect("Adminhome.aspx");
                }
                else if (logtype == "User")

                {
                    Response.Redirect("Userhome.aspx");
                }
            }
            else
            {
                Label3.Text = "Invalid Username and Password";
            }
        }
    }
}