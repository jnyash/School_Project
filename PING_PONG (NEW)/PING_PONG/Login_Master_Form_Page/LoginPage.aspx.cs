using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PING_PONG.Login_Master_Form_Page
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btlogin_Click1(object sender, EventArgs e)
        {
            try
            {
                string inputusername = this.txtusername.Text;
                string inputpassword = this.txtpassword.Text;

                DataSet ds = DataAccessor.Usp_clogin(inputusername, inputpassword);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect("~/Default.aspx"); // CustomerList page will open if condition are meet
                }
                else
                {
                    this.lberrormessage.Text = "Wrong Credentials";   // show this text if condition are not meet
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}