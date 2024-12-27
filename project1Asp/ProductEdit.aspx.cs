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
    public partial class ProductEdit : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView_Bind();
            DropDownList_Bind();
        }
        public void GridView_Bind()
        {
            string str = "select * from Product";
            DataSet ds = conobj.Fn_Dataset(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public void DropDownList_Bind()
        {
            string str = "select * from Category";
            DataSet ds = conobj.Fn_Dataset(str);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "c_name";
            DropDownList1.DataValueField = "categoryid";
            DropDownList1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int i = e.NewSelectedIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            Session["pid"] = getid;
            string str = "select * from Product where productid=" + getid + "";
            SqlDataReader dr = conobj.Fn_Reader(str);
            while(dr.Read())
            {
                TextBox1.Text = dr["p_name"].ToString();
                TextBox2.Text = dr["price"].ToString();
                TextBox3.Text = dr["stock"].ToString();
                TextBox4.Text = dr["image"].ToString();
                TextBox5.Text = dr["description"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p;
            if(FileUpload1.HasFile)
            {
                p = "~/productimg/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(p));
            }
            else
            {
                p = TextBox4.Text;
            }
            string str = "update Product set p_name='" + TextBox1.Text + "',price=" + TextBox2.Text + ",stock=" + TextBox3.Text + ",image='" + p + "',description='" + TextBox5.Text + "',status='Available' where productid=" + Session["pid"] + "";
            int i = conobj.Fn_Nonquery(str);
            if(i==1)
            {
                Label7.Visible = true;
                Label7.Text = "Successfully Updated";
            }
            else
            {
                Label7.Text = "Update Failed";
            }
        }
    }
}