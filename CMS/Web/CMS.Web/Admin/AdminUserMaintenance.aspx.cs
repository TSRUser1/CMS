using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Web.WCFAdministration;

namespace SEM.CMS.Web
{
    public partial class AdminUserMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetAdminUser();
                this.DGAdminUserDetail();
            }
        }

        protected void GetAdminUser()
        {
            AdministrationClient svc = new AdministrationClient();
            AdministrationDS responseDS = new AdministrationDS();

            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.AdminUserRow row = requestDS.AdminUser.NewAdminUserRow();
            requestDS.AdminUser.AddAdminUserRow(row);

            #region GetAdminUserList
            responseDS = svc.GetAdminUser(requestDS);

            ViewState[WebBase.VS_ADMIN_DS] = responseDS;
            #endregion
        }

        protected void BindData()
        {
            AdministrationDS adminOutputDS = new AdministrationDS();
            adminOutputDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];
            dgAdminUserDetail.DataSource = adminOutputDS.AdminUser;
            dgAdminUserDetail.DataBind();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminUserDetail.aspx?PageMode=New");
        }

        protected void DGAdminUserDetail()
        {
            WebBase.BindColumn("dgAdminUserDetail", dgAdminUserDetail);
            BindData();
        }

        protected void DGAdminUserDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.AdminUserRow row = requestDS.AdminUser.NewAdminUserRow();
            row.AdminUserID = Convert.ToInt32(dgAdminUserDetail.DataKeys[e.RowIndex].Values[requestDS.AdminUser.AdminUserIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.AdminUser.AddAdminUserRow(row);

            AdministrationClient svc = new AdministrationClient();
            svc.DeleteAdminUserDetail(requestDS);

            GetAdminUser();
            BindData();
        }

        protected void DGAdminUserDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgAdminUserDetail.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }
    }
}