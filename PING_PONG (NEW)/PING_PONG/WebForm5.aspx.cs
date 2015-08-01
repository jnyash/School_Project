using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace PING_PONG
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
         

        }

        protected void DDLGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Group_Id = Convert.ToInt32(DDLGroupList.SelectedValue.ToString());

                DataSet dsGroupMem = DataAccessor.Usp_PersGroup(Group_Id);

                this.GroupMember.DataSource = dsGroupMem;
                this.GroupMember.DataBind();
            }
            catch (Exception ex)
            {
                this.messagelb.Text = ex.Message.ToString();
            }
        }

    }
}