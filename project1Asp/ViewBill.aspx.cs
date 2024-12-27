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
    public partial class ViewBill : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string se = "select sum(grandtotal) from Bill where userid=" + Session["userid"] + "and status='ordered'";
                Label9.Text = conobj.Fn_Scalar(se);
                string s = "select billid ,date from Bill where userid=" + Session["userid"] + " and status='ordered'";
                SqlDataReader dr = conobj.Fn_Reader(s);
                while(dr.Read())
                {
                    Label4.Text = dr["billid"].ToString();
                    Label7.Text = dr["date"].ToString();
                }
                gridbind_fun();
            }
        }
        public void gridbind_fun()
        {
            string f = "select Product.p_name,order_tab.quantity,order_tab.totalprice from order_tab INNER JOIN Product ON order_tab.productid = Product.productid and userid=" + Session["userid"] + "";
            DataSet ds = conobj.Fn_Dataset(f);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_accdetails";
        //    cmd.Parameters.AddWithValue("@uid", Session["userid"]);
        //    cmd.Parameters.AddWithValue("@accna",TextBox1.Text);
        //    cmd.Parameters.AddWithValue("@accno",TextBox2.Text);
        //    cmd.Parameters.AddWithValue("@accType",TextBox3.Text);
        //    cmd.Parameters.AddWithValue("@accbal",TextBox4.Text);
        //    cmd.Parameters.AddWithValue("@status","Active");
        //    SqlParameter sp = new SqlParameter();
        //    sp.DbType = DbType.Int32;
        //    sp.ParameterName = "@sta";
        //    sp.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(sp);
        //    conobj.Fun_Nonquery(cmd);
        //    int i = Convert.ToInt32(sp.Value);
        //    if(i==1)
        //    {
        //        Response.Redirect("Payment.aspx");
        //    }
        //    else
        //    {
        //        Label15.Visible = true;
        //        Label15.Text = "Invalid account details";
        //        string up = "update order_tab set status='Failed'";
        //        conobj.Fn_Nonquery(up);
        //        string up1 = "update Bill set status='Failed'";
        //        conobj.Fn_Nonquery(up1);
        //    }
        //}
    }
}