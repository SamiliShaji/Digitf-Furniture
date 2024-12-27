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
    public partial class CategoryAdd : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/categoryimg/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into Category values ('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','Available')";
            int i = conobj.Fn_Nonquery(str);
            Label4.Visible = true;
            Label4.Text = "Successfully Inserted";
        }
    }
}