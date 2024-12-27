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
    public partial class CategoryEdit : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GridView_Bind();
        }
        public void GridView_Bind()
        {
            string str = "select * from Category";
            DataSet ds = conobj.Fn_Dataset(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int i = e.NewSelectedIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            Session["cid"] = getid;
            string str = "select * from Category where categoryid =" + getid + "";
            SqlDataReader dr = conobj.Fn_Reader(str);
            while (dr.Read())
            {
                TextBox1.Text = dr["c_name"].ToString();
                TextBox2.Text = dr["c_image"].ToString();
                TextBox3.Text = dr["description"].ToString();
                TextBox4.Text = dr["status"].ToString();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string p;
            if(FileUpload1.HasFile)
            {
                p = "~/categoryimg/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(p));
            }
            else
            {
                p = TextBox2.Text;
            }
            string str = "Update Category set c_name ='" + TextBox1.Text + "',c_image='" + p + "',description='" + TextBox3.Text + "',status='Available' where categoryid=" +Session["cid"]+ "";
            int i = conobj.Fn_Nonquery(str);
            if(i==1)
            {
                Label5.Visible = true;
                Label5.Text = "Successfully Updated";

            }
            else
            {

                Label5.Visible = true;
                Label5.Text = "Update failed";

            }
        }

    }
}