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
    public partial class Admin : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(regid) from Login";
            string s = conobj.Fn_Scalar(sel);
            int id = 0;
            if (s == "")
            {
                id = 1;
            }

            else
            {
                int newid = Convert.ToInt32(s);
                id=newid + 1;
            }
            string ins = "insert into Admin values(" + id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','"+TextBox3.Text+"',"+TextBox4.Text+")";
            int i = conobj.Fn_Nonquery(ins);
            if (i == 1)
            {
                string inslog = "insert into Login values(" + id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','Admin','active')";
                int j = conobj.Fn_Nonquery(inslog);
            }

        }
    }
}