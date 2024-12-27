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
    public partial class CreateAccount : System.Web.UI.Page
    {
        Connection conobj = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_accdetails";
            cmd.Parameters.AddWithValue("@uid", Session["userid"]);
            cmd.Parameters.AddWithValue("@accna",TextBox1.Text);
            cmd.Parameters.AddWithValue("@accno",TextBox2.Text);
            cmd.Parameters.AddWithValue("@accType",TextBox3.Text);
            cmd.Parameters.AddWithValue("@accbal",TextBox4.Text);
            cmd.Parameters.AddWithValue("@status","Active");
            SqlParameter sp = new SqlParameter();
            sp.DbType = DbType.Int32;
            sp.ParameterName = "@sta";
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            conobj.Fun_Nonquery(cmd);
            int i = Convert.ToInt32(sp.Value);
            if(i == 1)
            {
                Response.Redirect("Payment.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            string bal = "select account_balance from account where userid=" + Session["userid"] + "";
            string j = conobj.Fn_Scalar(bal);
            Label10.Text = j;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string bal = "select account_balance from account where userid=" + Session["userid"] + "";
            string j = conobj.Fn_Scalar(bal);
            decimal ball = Convert.ToDecimal(j);
            decimal newbal = ball + Convert.ToDecimal(TextBox5.Text);
            string up = "update account set account_balance=" + newbal + "where userid=" + Session["userid"] + "";
            int i = conobj.Fn_Nonquery(up);
            if(i==1)
            {
                Label12.Visible = true;
                Label12.Text = "Updated Successfully";
            }
        }
    }
}