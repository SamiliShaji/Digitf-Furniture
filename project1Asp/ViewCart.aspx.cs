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
    public partial class ViewCart : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridbind_fun();  
            }
            string m = "select count(cartid) from Cart where userid='" + Session["userid"] + "'";
            string mx = conobj.Fn_Scalar(m);
            int mee = Convert.ToInt32(mx);
            if (mee == 0)
            {
                Label6.Visible = true;
                Label6.Text = "your cart is empty";
            }
            else
            {
                string sel1 = "select sum(totalprice) from Cart where userid='" + Session["userid"] + "'";
                string str1 = conobj.Fn_Scalar(sel1);
                Label5.Text = str1;
            }
        }
        public void gridbind_fun()
        {
            string Gr = "select Product.productid,Product.p_name,Product.price,Product.image,Cart.quantity,Cart.totalprice from Product INNER JOIN Cart on Product.productid=Cart.productid WHERE Cart.userid=" + Session["userid"] + "";
            DataSet ds = conobj.Fn_Dataset(Gr);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind_fun();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbind_fun();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string P = "select price from Product where productid=" + getid + "";
            string Pp = conobj.Fn_Scalar(P);
            Session["price"] = Pp;

            TextBox txtquantity = (TextBox)GridView1.Rows[i].Cells[5].FindControl("TextBox1");

            int k = Convert.ToInt32(txtquantity.Text) * Convert.ToInt32(Session["price"]);
            string Tp = k.ToString();
            Label5.Text = Tp;

            string up = "Update Cart set quantity =" + txtquantity.Text + ",totalprice=" + Tp + " where productid=" + getid + "";

            conobj.Fn_Nonquery(up);
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from Cart where productid=" + getid + "";
            conobj.Fn_Nonquery(del);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string Gr ="select Product.productid,Product.p_name,Product.image,Product.price,Cart.productid,Cart.quantity,Cart.totalprice from Product INNER JOIN Cart ON Product.productid=Cart.productid WHERE Cart.userid=" + Session["userid"] + "";
            //DataSet ds = conobj.Fn_Dataset(Gr);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();

            string se = "select * from Cart where userid =" + Session["userid"] + "";
            List<int> itemlis = new List<int>();
            SqlDataReader dr = conobj.Fn_Reader(se);
            while (dr.Read()) 
            {
                itemlis.Add(Convert.ToInt32(dr["cartid"]));
            }
            foreach (int i in itemlis)
            {
                string al = "select * from Cart where(cartid=" + i + " and userid=" + Session["userid"] + ")";
                SqlDataReader dr1= conobj.Fn_Reader(al);
                int pid = 0;
                int pp = 0;
                int tp = 0;
                while(dr1.Read())
                {
                    pid = Convert.ToInt32(dr1["productid"]);
                    pp = Convert.ToInt32(dr1["quantity"]);
                    tp = Convert.ToInt32(dr1["totalprice"]);
                }
                string inn = "insert into order_tab values(" + Session["userid"] + "," + pid + "," + pp + "," + tp + ",'" + DateTime.Now.ToLongDateString() + "','ordered')";
                int s = conobj.Fn_Nonquery(inn);
                string d = "delete from cart where productid=" + pid + " and userid=" + Session["userid"] + "";
                int p = conobj.Fn_Nonquery(d);

                int c1 = Convert.ToInt32(Label5.Text);
                string f = "insert into Bill values(" + Session["userid"] + ",'" + DateTime.Now.ToLongDateString() + "'," + c1 + ",'ordered')";
                conobj.Fn_Nonquery(f);

            }
            Response.Redirect("ViewBill.aspx");
        }
    }
}
    
