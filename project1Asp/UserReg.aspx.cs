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
    public partial class UserReg : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindstate();
                binddistrict();
            }

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
                id = newid + 1;
            }
            string ins = "insert into Userreg values(" + id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "'," + TextBox5.Text + ",'"+DropDownList1.SelectedItem.Text+"','"+DropDownList2.SelectedItem.Text+"','Active')";
            int i = conobj.Fn_Nonquery(ins);
            if(i==1)
            {
                string ins1 = "insert into Login values(" + id + ",'" + TextBox6.Text + "','" + TextBox7.Text + "','User','active')";
                int j = conobj.Fn_Nonquery(ins1);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select * from Districttb where stateid='" + DropDownList1.SelectedItem.Value + "'";
            DataSet ds = conobj.Fn_Dataset(str);
            DropDownList2.DataValueField = "districtid";
            DropDownList2.DataTextField = "districtname";
            DropDownList2.DataSource = ds;
            DropDownList2.DataBind();
        }
        public void bindstate()
        {
            string sel = "select stateid,statename from Statetb";
            DataSet ds = conobj.Fn_Dataset(sel);
            DropDownList1.DataValueField = "stateid";
            DropDownList1.DataTextField = "statename";
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
        }
        public void binddistrict()
        {
            string sel = "select districtid,districtname from Districttb where stateid='"+DropDownList1.SelectedItem.Value+"'";
            DataSet ds = conobj.Fn_Dataset(sel);
            DropDownList2.DataValueField = "districtid";
            DropDownList2.DataTextField = "districtname";
            DropDownList2.DataSource = ds;
            DropDownList2.DataBind();
        }
    }
}