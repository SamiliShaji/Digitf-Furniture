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
    public partial class ProductAdd : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList_Bind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/productimg/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string ins = "insert into Product values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "'," + TextBox2.Text + "," + TextBox3.Text + ",'" + p + "','" + TextBox5.Text + "','Available')";
            int i = conobj.Fn_Nonquery(ins);
            Session["uid"] = i;
            if(i==1)
            {
                Label7.Text = "Successfully inserted";
            }
        }
        public void DropDownList_Bind()
        {
            string str = "select * from Category";
            DataSet ds = conobj.Fn_Dataset(str);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "c_name";
            DropDownList1.DataValueField = "categoryid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--Select--");
        }
    }
}