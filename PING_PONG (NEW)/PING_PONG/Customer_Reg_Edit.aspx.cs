using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PING_PONG
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private OurUtilities OU = new OurUtilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    // Create a Datagridet
            //    Show_Person(0, 0);
            //}
        }

        // Display all data in PersonGrid    Status:finish
        public void Show_Person(int pers, int intPage)
        {
            // Creates a dataset that retrieves info
            DataSet dsPerson = DataAccessor.Usp_Show_Person(pers);
            // Datagridet PersonGrid get all the data from dsPerson
            this.PersonGrid.DataSource = dsPerson;
            // Starts on the first page
            this.PersonGrid.CurrentPageIndex = intPage;     //=0
            // Binder data sets to PersonGrid
            this.PersonGrid.DataBind();
        }

        /// Arrangerar pager i datagrid.
        protected void PersonGrid_Pager(object sender, DataGridItemEventArgs DGE)
        {
            try
            {
                if (DGE.Item.ItemType == ListItemType.Pager)
                {
                    int currentPage = PersonGrid.CurrentPageIndex + 1;
                    int totalPages = PersonGrid.PageCount;
                    string strNewPager = "You now are at page " + currentPage + " of " + totalPages + ", ";

                    Label lblPageInfo = new Label();
                    lblPageInfo.Text = strNewPager;
                    lblPageInfo.CssClass = "deniedText";
                    DGE.Item.Controls[0].Controls.AddAt(0, lblPageInfo);

                    for (int i = 0; i < DGE.Item.Cells[0].Controls.Count; i++)
                    {
                        if (DGE.Item.Cells[0].Controls[i].GetType().ToString() == "System.Web.UI.WebControls.DataGridLinkButton")
                        {
                            ((LinkButton)DGE.Item.Cells[0].Controls[i]).Attributes.Add("onfocus", "this.blur()");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Arranges the links in the data grid          Status:finish
        public void PersonGrid_Bind(object sender, DataGridItemEventArgs DGE)
        {
            try
            {
                if ((DGE.Item.ItemType == ListItemType.Item) || (DGE.Item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView drv = (DataRowView)DGE.Item.DataItem;
                    string strID = (string)drv["ID"].ToString();

                    LinkButton linkUpdate = (LinkButton)DGE.Item.FindControl("Linkmodifier");
                    linkUpdate.Text = "Edit person";
                    linkUpdate.Attributes.Add("onfocus", "this.blur()");
                    linkUpdate.ToolTip = strID;
                    linkUpdate.CommandName = "Updform";
                    linkUpdate.CommandArgument = strID;
                    linkUpdate.CausesValidation = false;
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = ex.Message.ToString();
            }
        }

        //Update a person    Status:finish

        //protected string checkValues(string text, string Filter)
        //{
        //    if (text.Length != OurUtilities.(Filter)(text).Length)
        //    {
        //        int calc = text.Length - OurUtilities.(Filter)(text).Length;
        //        string Format = "Unathorised characters, there are " + calc + " characters that is not allowed";
        //        return Format;
        //    }

        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            this.erroraddellb.Text = "";
            try
            {
                int intID = Convert.ToInt32(this.LbID.Text);

                string strFirstName = this.FirstNameTextBox.Text;
                string strLastName = this.LastNameTextBox.Text;
                string strSSN = this.LbSSN.Text;
                string strEmail = this.EmailTextBox.Text;
                string strPhone = this.PhoneTextBox.Text;
                string strAdress = this.AdressTextBox.Text;
                string City = this.CityTextBox.Text;
                int Zip = Convert.ToInt32(ZipTextBox.Text);

                if (true)
                {
                    DataAccessor.Usp_Update_Persons(intID, strFirstName, strLastName, strEmail, strPhone, strAdress, City, Zip);

                    this.erroraddellb.Text = "<br/>" + strFirstName + " " + strLastName + " has been update<br/>";
                    this.LbID.Text = "";
                    this.FirstNameTextBox.Text = "";
                    this.LastNameTextBox.Text = "";
                    this.LbSSN.Text = "";
                    this.EmailTextBox.Text = "";
                    this.PhoneTextBox.Text = "";
                    this.AdressTextBox.Text = "";
                    this.CityTextBox.Text = "";
                    this.ZipTextBox.Text = "";
                }

                // Display the new data in PersonGrid
                Show_Person(0, 0);
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = this.erroraddellb.Text + "<br/>" + ex.Message.ToString();
            }
        }

        //Delete  a person    Status:finish
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int intID = Convert.ToInt32(this.LbID.Text);
                string strFirstName = this.FirstNameTextBox.Text;
                string strLastName = this.LastNameTextBox.Text;
                string strSSN = this.LbSSN.Text;
                string strEmail = this.EmailTextBox.Text;
                string strPhone = this.PhoneTextBox.Text;
                string strAdress = this.AdressTextBox.Text;
                string City = this.CityTextBox.Text;
                int Zip = Convert.ToInt32(ZipTextBox.Text);

                DataSet ds = DataAccessor.Usp_Show_Person(intID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataAccessor.Usp_Delete_User(intID);
                }
                else
                {
                    this.erroraddellb.Text = "The customer cannot be deleted because it doesn't exist";   // show this text if condition are not meet
                }

                this.erroraddellb.Text = "<br/> " + strFirstName + " " + strLastName + " har raderats<br/>";
                this.LbID.Text = "";
                this.FirstNameTextBox.Text = "";
                this.LastNameTextBox.Text = "";
                this.LbSSN.Text = "";
                this.EmailTextBox.Text = "";
                this.PhoneTextBox.Text = "";
                this.AdressTextBox.Text = "";
                this.CityTextBox.Text = "";
                this.ZipTextBox.Text = "";

                // Display the new data in PersonGrid
                Show_Person(0, 0);
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = ex.Message.ToString();
            }
        }

        //Order by numeric
        protected void PersonGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.erroraddellb.Text = "";
            try
            {
                Show_Person(0, e.NewPageIndex);
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = ex.Message.ToString();
            }
        }

        //shows the selected person in the form (table ID = tblAddDel)   Status:finish
        protected void PersonGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            this.erroraddellb.Text = "";
            try
            {
                string strComName = e.CommandName.ToString();
                switch (strComName)
                {
                    case "Updform":
                        int intComArg = Convert.ToInt32(e.CommandArgument.ToString());
                        DataSet dsLista = DataAccessor.Usp_Show_Person(intComArg);
                        if (dsLista.Tables[0].Rows.Count > 0)
                        {
                            this.LbID.Text = dsLista.Tables[0].Rows[0]["ID"].ToString();
                            this.FirstNameTextBox.Text = dsLista.Tables[0].Rows[0]["vchFirstName"].ToString();
                            this.LastNameTextBox.Text = dsLista.Tables[0].Rows[0]["vchLastName"].ToString();
                            this.LbSSN.Text = dsLista.Tables[0].Rows[0]["SSN"].ToString();
                            this.EmailTextBox.Text = dsLista.Tables[0].Rows[0]["vchEmail"].ToString();
                            this.PhoneTextBox.Text = dsLista.Tables[0].Rows[0]["vchPhone"].ToString();
                            this.AdressTextBox.Text = dsLista.Tables[0].Rows[0]["vchAdress"].ToString();
                            this.CityTextBox.Text = dsLista.Tables[0].Rows[0]["vchCity"].ToString();
                            this.ZipTextBox.Text = dsLista.Tables[0].Rows[0]["intZIP"].ToString();
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = ex.Message.ToString();
            }
        }

        // empty all data in textbox
        protected void btnClos_Click(object sender, EventArgs e)
        {
            //int intID = Convert.ToInt32(this.LbID.Text);
            //string strFirstName = this.FirstNameTextBox.Text;
            //string strLastName = this.LastNameTextBox.Text;
            //string strSSN = this.LbSSN.Text;
            //string strEmail = this.EmailTextBox.Text;
            //string strPhone = this.PhoneTextBox.Text;
            //string strAdress = this.AdressTextBox.Text;
            //string City = this.CityTextBox.Text;
            //int Zip = Convert.ToInt32(ZipTextBox.Text);

            this.LbID.Text = "";
            this.FirstNameTextBox.Text = "";
            this.LastNameTextBox.Text = "";
            this.LbSSN.Text = "";
            this.EmailTextBox.Text = "";
            this.PhoneTextBox.Text = "";
            this.AdressTextBox.Text = "";
            this.CityTextBox.Text = "";
            this.ZipTextBox.Text = "";
        }

        //Search a person in PersonGrid
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PersonGrid.DataSource = "";
            PersonGrid.DataSource = SDSearchEn;
            PersonGrid.DataBind();
        }

        //register a person in the system
        protected void btnreg_Click(object sender, EventArgs e)
        {
            List<Label> delLabel = new List<Label>() { Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, erroraddellb };
            OurUtilities.imCleaningLabels(delLabel);
        
            try
            {
                OU.OnPropertyChanged += new EventHandler(OU_OnPropertyChanged);
                OU.valueChanged += new myEventHandler(OU_valueChanged);
                                
                string strFirstName = this.FirstNameTextBox.Text;   //1
                string strLastName = this.LastNameTextBox.Text;     //2
                string strSSN = this.LbSSN.Text;                    //3
                string strEmail = this.EmailTextBox.Text;           //4
                string strPhone = this.PhoneTextBox.Text;           //5
                string strAdress = this.AdressTextBox.Text;         //6
                string City = this.CityTextBox.Text;                //7
                int Zip = Convert.ToInt32(OurUtilities.OnlyNumbers(ZipTextBox.Text)); //8
                string type = this.DropDownListtype.Text;


                this.Label2.Text = (dubbelKoll(strFirstName, "OnlyLETTERS") == "") ? "" : dubbelKoll(strFirstName, "OnlyLETTERS");
                this.Label3.Text = (dubbelKoll(strLastName, "OnlyLETTERS") == "") ? "" : dubbelKoll(strLastName, "OnlyLETTERS");
                this.Label5.Text = (dubbelKoll(strEmail, "OnlyEmail") == "") ? "" : dubbelKoll(strEmail, "OnlyEmail");
                this.Label6.Text = (dubbelKoll(strPhone, "OnlyNumbers") == "") ? "" : dubbelKoll(strPhone, "OnlyNumbers");
                this.Label7.Text = (dubbelKoll(strAdress, "OnlyLettNumb") == "") ? "" : dubbelKoll(strAdress, "OnlyLettNumb");
                this.Label8.Text = (dubbelKoll(City, "OnlyLETTERS") == "") ? "" : dubbelKoll(City, "OnlyLETTERS");
                this.Label4.Text = (dubbelKoll(strSSN, "SSN") == "") ? "" : dubbelKoll(strSSN, "SSN");

                if (strSSN.Length == 12)
                    strSSN = strSSN.Substring(2);


                if (OurUtilities.verifyingSSNs2(strSSN) && Label2.Text == "" && Label3.Text == "" && Label5.Text == "" && Label6.Text == "" && Label7.Text == "" && Label8.Text == "" && Label9.Text == "" && this.erroraddellb.Text == "")
                { 
                    DataAccessor.Usp_Insert_Person(strFirstName, strLastName, strSSN, strEmail, strPhone, type, strAdress, City, Zip);

                    this.erroraddellb.Text = "<br/>" + strFirstName + " " + strLastName + " has been registered.<br/>";
                    this.LbID.Text = "";
                    this.FirstNameTextBox.Text = "";
                    this.LastNameTextBox.Text = "";
                    this.LbSSN.Text = "";
                    this.EmailTextBox.Text = "";
                    this.PhoneTextBox.Text = "";
                    this.AdressTextBox.Text = "";
                    this.CityTextBox.Text = "";
                    this.ZipTextBox.Text = "";

                    // Display the new data in PersonGrid
                    Show_Person(0, 0);
                }
                //else if (this.erroraddellb.Text != "")
                else if (OurUtilities.verifyingSSNs2(strSSN) == false)
                {
                    //i hope that event will turn up here..
                    //this.erroraddellb.Text += "<br/>triggering this shit!";
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = this.erroraddellb.Text + "<br/>" + ex.Message.ToString() + "<br/> bajs!" ;
            }
        }

        //public void imCleaningLabels(List<Label> delLabel)
        //{
        //    //throw new NotImplementedException();
        //    foreach (Label item in delLabel)
        //    {
        //        item.Text = "";
        //    }
        //}

        //private void imCleaningLabels(Label[] labArray)
        //{
        //    for (int i = 0; i < labArray.Length; i++)
        //    {
        //        labArray[i].Text = "";
        //    }
        //}

      

        private void OU_valueChanged(string newValue)
        {
            //throw new NotImplementedException();
            
                this.erroraddellb.Text += " went so good, then it went soooo bad...";
            
            
        }

        //UNDER ARBETE
        ////////////private abstract void testar(string sender, string e)
        ////////////{
        ////////////    testarLite tL;
        ////////////    int hmm = 0;
        ////////////    if (Enum.TryParse<testarLite>(sender, true, out tL))
        ////////////    {
        ////////////        switch (tL)
        ////////////        {
        ////////////            case testarLite.FirstNameTextBox:
        ////////////            case testarLite.LastNameTextBox:

        ////////////            break;
        ////////////            case testarLite.LbSSN:
        ////////////                break;
        ////////////            case testarLite.EmailTextBox:
        ////////////                break;
        ////////////            case testarLite.PhoneTextBox:
        ////////////                break;
        ////////////            case testarLite.AdressTextBox:
        ////////////                break;
        ////////////            case testarLite.CityTextBox:
        ////////////                break;
        ////////////            case testarLite.ZipTextBox:
        ////////////                break;
        ////////////            default:
        ////////////                break;
        ////////////        }
        ////////////    }
        ////////////}

        public string dubbelKoll(string input, string kontrollant)
        {
            //OU.valueChanged += new myEventHandler(OU_valueChanged);
            //OU_OnPropertyChanged(this, new EventArgs());
            MyEnum kolla;
            int calc = 0;
            string Format = "";
            if (input.Length<= 0)
            {
                Format  = "No input! Minimum input is 3";
                OU.Name = Format;
            }
            else if (input.Length <= 2)
            {
                Format = "Minimum of characters is 3!";
                OU.Name = Format;

            }
            else
            if (Enum.TryParse<MyEnum>(kontrollant, true, out kolla))
            {

                switch (kolla)  
                {
                    case MyEnum.OnlyLETTERS:
                        calc = input.Length - OurUtilities.OnlyLETTERS(input).Length;
                        //OU.Val = calc.ToString();
                        break;
                    case MyEnum.OnlyNumbers:
                        calc = input.Length - OurUtilities.OnlyNumbers(input).Length;
                        break;
                    case MyEnum.OnlyEmail:
                        calc = input.Length - OurUtilities.OnlyEmail(input).Length;
                        break;
                    case MyEnum.OnlyLettNumb:
                        calc = input.Length - OurUtilities.OnlyLettNumb(input).Length;
                        break;
                    case MyEnum.SSN:
                            if (!OurUtilities.verifyingSSNs2(input))
                            {
                                Format += " SSN failure<br/>";
                                //OU.Name=
                            }
                            if (dubbelKoll(input, "OnlyNumbers") != "")
                            {
                                Format += dubbelKoll(input, "OnlyNumbers");
                                //Format += " - " + input + " False";
                            }
                        break;

                    default:
                        break;
                }

            }
            if (calc != 0)
            {
                Format= "Unathorised characters, there are " + calc + " characters that is not allowed";
                //OU.Name = calc.ToString();
                // ett event här?
            }

            if (Format != "")
            {


                OU_OnPropertyChanged(this, new EventArgs());
                OU_valueChanged(OU.Name);

                OU.Name = Format;
            }
            return Format;
        }

        private void OU_OnPropertyChanged(object sender, EventArgs e)
        {
            this.erroraddellb.Text = "Something is messed up!";

        }



        //UTAN FÖR CLASSEN!!
        enum MyEnum
        {
            OnlyLETTERS, OnlyNumbers, OnlyEmail, OnlyLettNumb, SSN
        }
        enum testarLite //används ej just nu
        {
            FirstNameTextBox,
            LastNameTextBox,
            LbSSN,
            EmailTextBox,
            PhoneTextBox,
            AdressTextBox,
            CityTextBox,
            ZipTextBox
        }

        //protected void FirstNameTextBox_TextChanged(TextBox textbox)
        ////protected void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    testarLite kollar;
        //    string test = textbox.Text;
        //    string id = textbox.ID;
        //    string mongis = "hej";

        //if (Enum.TryParse<testarLite>(id, true, out kollar))
        //{
        //    switch (kollar)
        //    {
        //        case testarLite.FirstNameTextBox:
        //            mongis = "OnlyLETTERS";
        //            //this.Label2.Text = dubbelKoll(test, "OnlyLETTERS");           //1
        //            this.CustomValidator1.Text = "skit";
        //            break;
        //        case testarLite.LastNameTextBox:
        //            this.CustomValidator2.Text = dubbelKoll(test, "OnlyLETTERS");            //2
        //            mongis = "OnlyLETTERS";
        //            break;
        //        case testarLite.CityTextBox:
        //            mongis = "OnlyLETTERS";
        //            this.CustomValidator7.Text = dubbelKoll(test, "OnlyLETTERS");                   //7
        //            break;

        //        case testarLite.LbSSN:
        //            mongis = "OnlyNumbers";
        //            if (OurUtilities.verifyingSSNs2(test))                                        //3
        //                this.CustomValidator3.ErrorMessage = dubbelKoll(test, "OnlyNumbers");
        //            else
        //            {
        //                //OU.Name = strSSN;
        //                test = "hej";
        //                this.CustomValidator3.ErrorMessage = "SSN Failure! This is not a correct SSN!";
        //            }
        //            break;

        //        case testarLite.PhoneTextBox:
        //            mongis = "OnlyNumbers";
        //            this.CustomValidator5.Text = dubbelKoll(test, "OnlyNumbers");               //5

        //            break;
        //        case testarLite.ZipTextBox:
        //            mongis = "OnlyNumbers";
        //            break;
        //        case testarLite.EmailTextBox:
        //            mongis = "OnlyEmail";
        //            this.CustomValidator4.Text = dubbelKoll(test, "OnlyEmail");                 //4

        //            break;
        //        case testarLite.AdressTextBox:

        //            mongis = "OnlyLettNumb";
        //            this.CustomValidator6.Text = dubbelKoll(test, "OnlyEmail");                //6

        //            break;

        //        //this.CustomValidator3.ErrorMessage = OurUtilities.verifyingSSNs2(strSSN) ? dubbelKoll(strSSN, "OnlyNumbers") : "";

        //        default:
        //            break;
        //    }

        //}

        //dubbelKoll(test, mongis);
        //}
        //protected void FirstNameTextBox_TextChanged(object sender, EventArgs e)

     
            //testarLite kollar;
            //string test = textbox.Text;
            //string id = textbox.ID;
            //string mongis = "hej";

            //if (Enum.TryParse<testarLite>(id, true, out kollar))
            //{
            //    switch (kollar)
            //    {
            //        case testarLite.FirstNameTextBox:
            //            mongis = "OnlyLETTERS";
            //            //this.Label2.Text = dubbelKoll(test, "OnlyLETTERS");           //1
            //            this.Label2.Text = test;         //1
            //            //this.CustomValidator1.Text = "skit";
            //            break;
            //        case testarLite.LastNameTextBox:
            //            //this.CustomValidator2.Text = dubbelKoll(test, "OnlyLETTERS");            //2
            //            this.Label3.Text = test;         //1
            //            mongis = "OnlyLETTERS";
            //            break;
            //        case testarLite.CityTextBox:
            //            mongis = "OnlyLETTERS";
            //            //this.CustomValidator7.Text = dubbelKoll(test, "OnlyLETTERS");                   //7
            //            this.Label8.Text = test;         //1
            //            break;

            //        case testarLite.LbSSN:
            //            mongis = "OnlyNumbers";
            //            if (OurUtilities.verifyingSSNs2(test))                                        //3
            //                //this.CustomValidator3.ErrorMessage = dubbelKoll(test, "OnlyNumbers");
            //                this.Label4.Text = test;         //1
            //            else
            //            {
            //                //OU.Name = strSSN;
            //                test = "hej";
            //                //this.CustomValidator3.ErrorMessage = "SSN Failure! This is not a correct SSN!";
            //                this.Label4.Text = test;         //1
            //            }
            //            break;

            //        case testarLite.PhoneTextBox:
            //            mongis = "OnlyNumbers";
            //            //this.CustomValidator5.Text = dubbelKoll(test, "OnlyNumbers");               //5
            //            this.Label6.Text = test;         //1

            //            break;
            //        case testarLite.ZipTextBox:
            //            mongis = "OnlyNumbers";
            //            this.Label9.Text = test;         //1
            //            break;
            //        case testarLite.EmailTextBox:
            //            mongis = "OnlyEmail";
            //            //this.CustomValidator4.Text = dubbelKoll(test, "OnlyEmail");                 //4
            //            this.Label5.Text = test;         //1

            //            break;
            //        case testarLite.AdressTextBox:

            //            mongis = "OnlyLettNumb";
            //            //this.CustomValidator6.Text = dubbelKoll(test, "OnlyEmail");                //6
            //            this.Label7.Text = test;         //1
            //            break;

            //        //this.CustomValidator3.ErrorMessage = OurUtilities.verifyingSSNs2(strSSN) ? dubbelKoll(strSSN, "OnlyNumbers") : "";

            //        default:
            //            break;
            //    }

            //}

            //dubbelKoll(test, mongis);
        

        //SLUTET AV NAMESPACE!!
    }
}