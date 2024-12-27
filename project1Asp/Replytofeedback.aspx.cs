using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace project1Asp
{
    public partial class Replytofeedback : System.Web.UI.Page
    {
        Connection conobj = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            string m = "select email from Userreg where userid=" + Session["getid"] + "";

            string s = conobj.Fn_Scalar(m);
            Session["email"] = s;
            TextBox1.Text = s;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string to = TextBox1.Text;
            string sub = TextBox2.Text;
            string rep = TextBox3.Text;
            SendEmail2("Samili", "samilisha123@gmail.com", "kkzv ovyf qkze avrk", "to user", to, sub, rep);
            string upf = "update feedbacktab set reply_message='" + TextBox3.Text + "',feedback_status=1 where userid=" + Session["userid"] + "";
            int f = conobj.Fn_Nonquery(upf);
        }
        public static void SendEmail2(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)

        {
            string to = toEmail; //To address    
            string from = yourGmailUserName; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}