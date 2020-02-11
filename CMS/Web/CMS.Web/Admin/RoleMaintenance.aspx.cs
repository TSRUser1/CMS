using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Web.WCFAdministration;

namespace SEM.CMS.Web.Admin
{
    public partial class RoleMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetRole();
                this.DGRoleDetail();
            }
        }

        protected void GetRole()
        {
            AdministrationClient svc = new AdministrationClient();
            AdministrationDS responseDS = new AdministrationDS();

            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.RoleRow row = requestDS.Role.NewRoleRow();
            requestDS.Role.AddRoleRow(row);

            #region GetRoleList
            responseDS = svc.GetRole(requestDS);

            ViewState[WebBase.VS_ADMIN_DS] = responseDS;
            #endregion
        }

        protected void BindData()
        {
            AdministrationDS adminOutputDS = new AdministrationDS();
            adminOutputDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];
            dgRoleDetail.DataSource = adminOutputDS.Role;
            dgRoleDetail.DataBind();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/RoleDetail.aspx?PageMode=New");
        }

        protected void DGRoleDetail()
        {
            WebBase.BindColumn("dgRoleDetail", dgRoleDetail);
            BindData();
        }

        protected void DGRoleDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.RoleRow row = requestDS.Role.NewRoleRow();
            row.RoleID = Convert.ToInt32(dgRoleDetail.DataKeys[e.RowIndex].Values[requestDS.Role.RoleIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Role.AddRoleRow(row);

            AdministrationClient svc = new AdministrationClient();
            svc.DeleteRole(requestDS);

            GetRole();
            BindData();
        }

        protected void DGRoleDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgRoleDetail.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }
    }
}