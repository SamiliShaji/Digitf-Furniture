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
    public partial class ViewProducts : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "Select * from Product where productid=" + Session["pid"] + "";
            SqlDataReader dr = conobj.Fn_Reader(str);
            while(dr.Read())
            {
                Image1.ImageUrl = dr["image"].ToString();
                Label1.Text = dr["p_name"].ToString();
                Label2.Text = dr["price"].ToString();
                Label3.Text = dr["description"].ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string c = "Select Max(cartid) from Cart";
            string crtid = conobj.Fn_Scalar(c);
            int cartid = 0;
            if(crtid=="")
            {
                cartid = 1;
            }
            else
            {
                int newcid = Convert.ToInt32(crtid);
                cartid = newcid + 1;
            }
            int TotalPrice = Convert.ToInt32(DropDownList1.SelectedItem.Text) * Convert.ToInt32(Label2.Text);

            string ct = "insert into Cart values(" + cartid + "," + Session["userid"] + "," + Session["pid"] + ",'" + DropDownList1.SelectedItem.Text + "'," + TotalPrice + ",'" + DateTime.Now.ToLongDateString() + "')";
            int crt = conobj.Fn_Nonquery(ct);
            if(crt==1)
            {
                Label8.Visible = true;
                Label8.Text = "Added to cart";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(DropDownList1.SelectedItem.Text) * Convert.ToInt32(Label2.Text);
            Label7.Text = t.ToString();
        }
    }
}