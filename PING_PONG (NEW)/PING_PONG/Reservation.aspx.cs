using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace PING_PONG
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usp_Book_Tabel();
        }
        public void Usp_Book_Tabel()
        {
            DataSet dsPlayer = DataAccessor.Usp_Book_Tabel();
            this.dgBoking.DataSource = dsPlayer;
            this.dgBoking.DataBind();
        }
        // Make a reservation     STATUS:FINISH
        protected void btn_reserve_Click(object sender, EventArgs e)
        {

            List<Label> delLabel = new List<Label>() { erroraddellb2, lbshowdate };
            OurUtilities.imCleaningLabels(delLabel);
            this.erroraddellb2.Text = "";
            try
            {
                //get the value of the dropdownlist
                string groupname = DDLBokGroupList.SelectedValue.ToString();
                string date = this.Date.Text;
                string time = DDL_Time.SelectedValue.ToString();

                string today = Convert.ToString(DateTime.Today).Substring(0, 10);
                //this.lbshowdate.Text = date;
                DateTime inputdate = Convert.ToDateTime(date);
                DateTime todaydate = Convert.ToDateTime(today);

                if (inputdate >= todaydate)
                {
                    //Insert Bookning
                    if (time != "Välj Period")
                    {


                        DataAccessor.Usp_booking(date, time, groupname);
                        Usp_Book_Tabel();

                        this.erroraddellb2.Text = "<br/>Reservation has been made ";
                        dgBoking.DataBind();
                    }
                    else
                    {
                        this.erroraddellb2.Text = "Invalid \"Time:\" input";
                    }
                }
                else
                {
                    this.erroraddellb2.Text = "<br/>Please Input A Valid Date";
                }
            }
            catch (Exception x)
            {
                this.erroraddellb2.Text = "Something went wrong, Try again later ";
            }
        }
    }
}