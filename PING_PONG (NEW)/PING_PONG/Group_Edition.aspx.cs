using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PING_PONG
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Create a Datagridet
                Show_Person(0, 0);
                this.erroraddellb.Text = "";
                groupDDLgrid(0);
            }
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

        /*Create new group*/

        protected void btnnewgroup_Click(object sender, EventArgs e)
        {
            this.lberror.Text = "";
            try
            {
                string groupname = this.txtnewgroup.Text;
                //get the value of the dropdownlist
                string type = DDLTypeListnewgroup.SelectedValue.ToString();
                DataAccessor.Usp_Create_NewGroup(groupname, type);
                this.lberror.Text = "<br/>The Group " + groupname + " has been created";
                DDLGroupList.DataBind();
            }
            catch (Exception x)
            {
                this.lberror.Text = "Something went wrong ";
            }
        }

        /// Arrangerar pager i datagrid.
        protected void PersonGrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs DGE)
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

        //Order by numeric
        protected void PersonGrid_PageIndexChanged1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
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

        //Search a person to add to a group
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            PersonGrid.DataSource = "";
            PersonGrid.DataSource = SDSearchEn;
            PersonGrid.DataBind();
        }

        // Bound ID to groupform and Linkadd
        protected void PersonGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs DGE)
        {
            try
            {
                if ((DGE.Item.ItemType == ListItemType.Item) || (DGE.Item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView drv = (DataRowView)DGE.Item.DataItem;
                    string strID = (string)drv["ID"].ToString();

                    LinkButton linkAdd = (LinkButton)DGE.Item.FindControl("Linkadd");
                    linkAdd.Text = "Add";
                    linkAdd.Attributes.Add("onfocus", "this.blur()");
                    linkAdd.ToolTip = strID;
                    linkAdd.CommandName = "add";
                    linkAdd.CommandArgument = strID;
                    linkAdd.CausesValidation = false;
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = ex.Message.ToString();
            }
        }

        protected void PersonGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            try
            {
                int group_id = Convert.ToInt32(DDLGroupList.SelectedValue.ToString());

                string strComName = e.CommandName.ToString();
                switch (strComName)
                {
                    case "add":
                        int pers_id = Convert.ToInt32(e.CommandArgument.ToString());

                        DataSet dsGroupMem = DataAccessor.Usp_PersGroup(group_id);
                        int rowCount = dsGroupMem.Tables[0].Rows.Count;

                        this.lbcount.Text = Convert.ToString(rowCount);
                        if (rowCount < 4)
                        {
                            DataAccessor.Usp_AddPersGroup(group_id, pers_id);
                        }
                        groupDDLgrid(group_id);

                        break;
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb.Text = ex.Message.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //delete this later
            DDLGroupList.DataBind();
            DDLTypeList.DataBind();
        }

        // SHOW THE LIST OF MEMBER IN A GROUP
        protected void DDLGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int group_id = Convert.ToInt32(DDLGroupList.SelectedValue.ToString());
                this.lbgroup.Text = Convert.ToString(group_id);
                groupDDLgrid(group_id);
            }
            catch (Exception ex)
            {
                this.erroraddellb1.Text = ex.Message.ToString();
            }

        }
       
        private void groupDDLgrid(int p)
        {
            DataSet dsGroupMem = DataAccessor.Usp_PersGroup(p);

            this.GroupMember.DataSource = dsGroupMem;
            this.GroupMember.DataBind();
        }
        /// ADD DELETE BUTTON ON THE DATAGRID STATUS: FINISH
        protected void GroupMember_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView drv = (DataRowView)e.Item.DataItem;
                    string strID = (string)drv["Pers_ID"].ToString();

                    LinkButton linkdelete = (LinkButton)e.Item.FindControl("Linkdelete");
                    linkdelete.Text = "Delete";
                    linkdelete.Attributes.Add("onfocus", "this.blur()");
                    linkdelete.ToolTip = strID;
                    linkdelete.CommandName = "delete";
                    linkdelete.CommandArgument = strID;
                    linkdelete.CausesValidation = false;
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb1.Text = ex.Message.ToString();
            }
        }

        protected void GroupMember_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                int group_id = Convert.ToInt32(DDLGroupList.SelectedValue.ToString());
                string strComName = e.CommandName.ToString();
                switch (strComName)
                {
                    case "delete":
                        int intComArg = Convert.ToInt32(e.CommandArgument.ToString());
                        DataAccessor.Usp_DelPersGroup(intComArg);

                        //INPUT THE GROUP_ID VALUE INTO A PROCEDURE
                        DataSet dsGroupMem = DataAccessor.Usp_PersGroup(group_id);
                        //
                        this.GroupMember.DataSource = dsGroupMem;
                        this.GroupMember.DataBind();

                        break;
                }
            }
            catch (Exception ex)
            {
                this.erroraddellb1.Text = ex.Message.ToString();
            }
        }
    }
}