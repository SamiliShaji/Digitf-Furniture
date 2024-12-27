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
    public partial class Payment : System.Web.UI.Page
    {
        Connection conobj = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string str = "select sum(grandtotal) from Bill where userid=" + Session["userid"] + " and status='ordered'";
                Session["total"] = conobj.Fn_Scalar(str);
                Label3.Text = Session["total"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string se_acc = "select account_no from account where userid=" + Session["userid"] + "";
            string accno = conobj.Fn_Scalar(se_acc);
            int accnum = Convert.ToInt32(accno);
            if(accnum == Convert.ToInt32(TextBox1.Text))
            {
                PaymentServiceReference.ServiceClient objservice = new PaymentServiceReference.ServiceClient();
                decimal bal = objservice.Check_Balance(Convert.ToInt32(TextBox1.Text));
                decimal gt = Convert.ToInt32(Session["total"]);

                if (bal>=gt)
                {
                    decimal newball = bal - gt;
                    string upbal_amnt = "update account set account_balance=" + newball + " where account_no=" + Convert.ToInt32(TextBox1.Text) + "";
                    int i = conobj.Fn_Nonquery(upbal_amnt);

                    if(i==1)
                    {
                        string sel = "select orderid from order_tab where userid=" + Session["userid"] + " and orderstatus='Ordered'";
                        List<int> olist = new List<int>();
                        SqlDataReader dr = conobj.Fn_Reader(sel);
                        while(dr.Read())
                        {
                            olist.Add(Convert.ToInt32(dr["orderid"]));
                        }
                        foreach (int k in olist)
                        {
                            string updates = "update order_tab set orderstatus='Paid' where orderid=" + k + "";
                            conobj.Fn_Nonquery(updates);

                        }
                        string sell = "select max(billid) from Bill where userid=" + Session["userid"] + "";
                        string bi = conobj.Fn_Scalar(sell);
                        string upd = "update Bill set status='Paid' where billid=" + bi + "";
                        conobj.Fn_Nonquery(upd);
                        string strin = "select productid from order_tab where orderstatus='Paid' and userid=" + Session["userid"] + "";
                        List<int> prlist = new List<int>();
                        SqlDataReader dr1 = conobj.Fn_Reader(strin);
                        while(dr1.Read())
                        {
                            prlist.Add(Convert.ToInt32(dr1["productid"]));
                        }
                        foreach(int j in prlist)
                        {
                            string se = "select Product.stock,order_tab.quantity from Product INNER JOIN order_tab ON Product.productid=order_tab.productid where order_tab.productid=" + j + "and userid=" + Session["userid"] + "";
                            SqlDataReader dru = conobj.Fn_Reader(se);
                            decimal pt = 0;
                            decimal qt = 0;
                            while (dru.Read())
                            {
                                pt = Convert.ToDecimal(dru["stock"]);
                                qt = Convert.ToDecimal(dru["quantity"]);

                            }
                            decimal newst = pt - qt;
                            string newpdt = newst.ToString();
                            string up2 = "update Product set stock=" + newpdt + " where productid=" + j + "";
                            int k = conobj.Fn_Nonquery(up2);
                            if(k==1)
                            {
                                Label5.Visible = true;
                                Label5.Text = "successfully paid";
                            }
                           
                        }

                    }
                    else
                    {
                        Label5.Visible = true;
                        Label5.Text = "Insufficient Balance";

                        string see = "select orderid from order_tab where userid=" + Session["userid"] + " and orderstatus='Ordered'";
                        List<int> olist = new List<int>();
                        SqlDataReader dr22 = conobj.Fn_Reader(see);
                        while(dr22.Read())
                        {
                            olist.Add(Convert.ToInt32(dr22["orderid"]));

                        }
                        foreach (int k in olist)
                        {
                            string up1 = "update order_tab set orderstatus='Insufficient balance' where order_tab=" + k + "";
                            conobj.Fn_Nonquery(up1);

                        }
                        string sn = "select max(billid) from Bill where userid=" + Session["uid"] + "";
                        string bi = conobj.Fn_Scalar(sn);
                        string sg = "update Bill set status='Failed' where billid=" + bi + "";
                        conobj.Fn_Nonquery(sg);
                    }
                }
                else
                {
                    Response.Redirect("CreateAccount.aspx");
                }
            }
        }
    }
}