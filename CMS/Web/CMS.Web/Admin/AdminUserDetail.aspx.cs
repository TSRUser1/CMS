using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFAdministration;
using System.Data;

namespace SEM.CMS.Web
{
    public partial class AdminUserDetail : System.Web.UI.Page
    {
        protected string qs_NEW = "New";
        protected string qs_EDIT = "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUIControl();
                this.GetRole();
                this.DGRoleDetail();
                if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    this.GetAdminUser();
                    this.BindData();
                }
            }
        }

        protected void BindData()
        {
            AdministrationDS outputDS = new AdministrationDS();
            outputDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];

            if (outputDS != null && outputDS.AdminUser.Rows.Count > 0)
            {
                txtLoginID.Text = outputDS.AdminUser[0].LoginID;
                txtFullname.Text = outputDS.AdminUser[0].FullName;
                txtPassword.Text = outputDS.AdminUser[0].Password;
                txtDesignation.Text = outputDS.AdminUser[0].Designation;
            }

            var dt = new DataTable();

            if (ViewState["dtRole"] != null && outputDS.AdminUserInRole != null)
            {
                dt = ViewState["dtRole"] as DataTable;
                var dtuserInRole = (outputDS.AdminUserInRole as DataTable);

                ViewState.Add("dtUserInRole", dtuserInRole);

                var dv = dtuserInRole.AsDataView();

                dv.RowFilter = "IsActive=1";

                dtuserInRole = dv.ToTable();

                foreach(DataRow dr in dt.Rows)
                {
                    dr["IsActive"] = false;
                }

                foreach (DataRow dr in dtuserInRole.Rows)
                {
                    foreach (DataRow drRole in dt.Rows)
                    {
                        if (drRole["RoleID"].ToString().Equals(dr["RoleID"].ToString()))
                        {
                            drRole["IsActive"] = true;
                            break;
                        }
                        else
                        {
                            if (dr["IsActive"] != DBNull.Value && !Convert.ToBoolean(dr["IsActive"]))
                                drRole["IsActive"] = false;
                        }
                    }
                }
            }

            dgRoleDetail.DataSource = dt != null ? dt : outputDS.Role;
            dgRoleDetail.DataBind();
        }

        protected void BindUIControl()
        {
            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                lblPageMode.Text = "Edit";
                btnSave.Text = "Update User";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminUserMaintenance.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtLoginID.Text = "";
            txtFullname.Text = "";
            txtDesignation.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int adminUserID = 0, roleID = 0;
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationDS requestDS = new AdministrationDS();

            if (ViewState[WebBase.VS_ADMIN_DS] != null)
            {
                requestDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];
                if (requestDS.AdminUser.Rows.Count > 0)
                {
                    adminUserID = requestDS.AdminUser[0].IsAdminUserIDNull() ? 0 : requestDS.AdminUser[0].AdminUserID;
                }
            }
            requestDS.AdminUser.Clear();
            AdministrationDS.AdminUserRow row = requestDS.AdminUser.NewAdminUserRow();
            row.AdminUserID = adminUserID;
            if (txtPassword.Text.Trim() != "")
            {
                row.Password = txtPassword.Text;
            }
            row.LoginID = txtLoginID.Text;
            row.FullName = txtFullname.Text;
            row.Designation = txtDesignation.Text;
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            //DateTime date = txtDate.Text == "" ? DateTime.MaxValue : DateTime.ParseExact(txtDate.Text, WebBase.DATE_FORMAT, CultureInfo.InvariantCulture);
            requestDS.AdminUser.AddAdminUserRow(row);

            requestDS.AdminUserInRole.Clear();

            AdministrationClient adminSVC = new AdministrationClient();

            foreach (GridViewRow gridRow in dgRoleDetail.Rows)
            {
                CheckBox chkIsReadOnly = (CheckBox)gridRow.FindControl("chkHasRole");
                roleID = Convert.ToInt32(dgRoleDetail.DataKeys[gridRow.RowIndex].Value);

                var dt = ViewState["dtUserInRole"] as DataTable;

                var ID = dt.AsEnumerable().Where(r => r.Field<Int32>("RoleID") == roleID).Select(x => x.Field<Int32>("AdminUserInRoleID")).FirstOrDefault();

                AdministrationDS.AdminUserInRoleRow dataRow = requestDS.AdminUserInRole.NewAdminUserInRoleRow();

                if (ID != 0)
                {
                    dataRow.AdminUserInRoleID = ID;
                }

                dataRow.RoleID = roleID;
                dataRow.AdminUserID = adminUserID;
                dataRow.IsActive = chkIsReadOnly.Checked ? 1 : 0;
                dataRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                requestDS.AdminUserInRole.AddAdminUserInRoleRow(dataRow);
            }

            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                adminSVC.UpdateAdminUserDetail(requestDS);
            }
            else
            {
                adminSVC.InsertAdminUserDetail(requestDS);
            }

            Master.AjaxPopupMessage("Record Saved ...!", "~/Admin/AdminUserMaintenance.aspx");
        }

        protected void DGRoleDetail()
        {
            WebBase.BindColumn("dgRoleDetail", dgRoleDetail);
            BindData();
        }

        protected void GetAdminUser()
        {
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS adminOutputDS = new AdministrationDS();
            AdministrationDS.AdminUserRow adminUserRow = requestDS.AdminUser.NewAdminUserRow();
            adminUserRow.AdminUserID = Convert.ToInt32(Request.QueryString[WebBase.QS_ADMINUSERID]);
            adminUserRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.AdminUser.AddAdminUserRow(adminUserRow);

            AdministrationClient adminSVC = new AdministrationClient();
            adminOutputDS = adminSVC.GetAdminUser(requestDS);

            ViewState[WebBase.VS_ADMIN_DS] = adminOutputDS;
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

            ViewState["dtRole"] = null;
            ViewState.Add("dtRole", responseDS.Role);

            ViewState[WebBase.VS_ADMIN_DS] = responseDS;
            #endregion
        }
    }
}