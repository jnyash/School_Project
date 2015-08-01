using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Security;
using System.Text;

namespace PING_PONG
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
         * Username:    pingpongptk2013@gmail.com
         * Password:    programmeringpingpongptk2013
         */
        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(TextBox2.Text);
                mail.To.Add("pingpongptk2013@gmail.com");
                mail.IsBodyHtml = true;
                mail.Subject = "Contact Details";
                StringBuilder body = new StringBuilder();
                body.Append("Contact Details");
                body.Append("<b>Name:</b>");
                body.Append(TextBox1.Text);
                body.Append(" <br/> <b>Email - address :</b>");
                body.Append(TextBox2.Text);
                body.Append("<br/> <b>Comments :</b>");
                body.Append(TextBox3.Text);
                mail.Body = body.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                mail.Priority = MailPriority.Normal;
                smtp.Credentials = new System.Net.NetworkCredential("pingpongptk2013@gmail.com", "programmeringpingpongptk2013");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                lbl_status.ForeColor = System.Drawing.Color.Green;
                lbl_status.Text = "Your Message has been submitted.";
            }
            catch
            {
                lbl_status.ForeColor = System.Drawing.Color.Red;
                lbl_status.Text = "Please try again. :(";
            }
        }
    }
}