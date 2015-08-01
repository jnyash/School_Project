using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace PING_PONG
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //this.lberrormessage.Text = "is post back";
            }
            if (!Page.IsPostBack)
            {
                checkLogin(); // ÄNTLIGEN!
                //this.lberrormessage.Text = "is NOT post back, (cookie är nu försvunnen)";
            }
        }

        protected void btlogin_Click1(object sender, EventArgs e)
        {
            try
            {
                string User = this.txtusername.Text;
                string PW = this.txtpassword.Text;
                DataSet ds = DataAccessor.Usp_clogin(User, PW);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CreateCookie(User, PW);
                    btnPuttesPressMe_Click();
                    Response.Redirect("Start Sidan.aspx");
                }
            }
            catch (Exception ex)
            {
                this.lberrormessage.Text = ex.Message.ToString() + "<br/>";
            }
        }

        public void CreateCookie(string User, string PW)
        {
            HttpCookie myCookie = new HttpCookie("TesTlogg");
            myCookie["User"] = User;
            myCookie["PW"] = PW;
            Response.Cookies.Add(myCookie);
        }

        protected void btnCookieShow_Click(object sender, EventArgs e)
        {
            try
            {
                HttpCookie myCookie = new HttpCookie("TesTlogg");
                myCookie = Request.Cookies["TesTlogg"];
                if (myCookie != null)
                {
                    btnPuttesPressMe_Click();
                    this.txtusername.Text = Request.Cookies["TesTlogg"]["User"];
                    this.txtpassword.Text = Request.Cookies["TesTlogg"]["PW"];
                }
                else
                {
                    //Response.Write("not found");
                }
            }
            catch (Exception ex)
            {
                this.lberrormessage.Text = ex.Message.ToString() + "<br/>";
            }
        }

        protected void checkLogin()
        {
            try
            {
                HttpCookie myCookie = new HttpCookie("TesTlogg");
                myCookie = Request.Cookies["TesTlogg"];
                if (myCookie != null)
                {
                    btnPuttesPressMe_Click();
                    this.txtusername.Text = Request.Cookies["TesTlogg"]["User"];
                    this.txtpassword.Text = Request.Cookies["TesTlogg"]["PW"];
                }
                else
                {
                    //Response.Write("not found");
                }
            }
            catch (Exception ex)
            {
                this.lberrormessage.Text = ex.Message.ToString() + "<br/>";
            }
        }

        private void btnPuttesPressMe_Click()
        {
            //Tar bort login

            LogginHolder1.Visible = false;
            LogginHolder2.Visible = true;

            //throw new NotImplementedException();
        }

        protected void btnPuttesPressedMe()
        {
            //Tar dit login
            LogginHolder1.Visible = true;
            LogginHolder2.Visible = false;
        }
    }
}