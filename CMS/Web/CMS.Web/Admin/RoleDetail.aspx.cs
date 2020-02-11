using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFAdministration;

namespace SEM.CMS.Web.Admin
{
    public partial class RoleDetail : System.Web.UI.Page
    {
        protected string qs_NEW = "New";
        protected string qs_EDIT = "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    this.GetRole();
                    this.BindData();
                }
                else
                {
                    GetModule("");
                }

                BindUIControl();
                DGModuleFunction();
            }
        }

        protected void BindPageName()
        {
            // Bind page name
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationClient svc = new AdministrationClient();
            responseDS = svc.GetFunctionName();
            AdministrationDS.ModuleRow row = responseDS.Module.NewModuleRow();
            row.FunctionName = "-All-";
            responseDS.Module.AddModuleRow(row);

            DataView sortedView = new DataView();
            sortedView = responseDS.Module.DefaultView;
            sortedView.Sort = responseDS.Module.FunctionNameColumn.ColumnName + " ASC";

            ddlFunction.DataSource = sortedView;
            ddlFunction.DataTextField = responseDS.Module.FunctionNameColumn.ColumnName;
            ddlFunction.DataValueField = responseDS.Module.FunctionNameColumn.ColumnName;
            ddlFunction.DataBind();
        }

        protected void BindData()
        {
            AdministrationDS outputDS = new AdministrationDS();
            outputDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];
            dgModuleFunction.DataSource = outputDS.Module;
            dgModuleFunction.DataBind();

            if (outputDS != null && outputDS.Role.Rows.Count > 0)
            {
                txtRoleName.Text = outputDS.Role[0].RoleName;
                txtDescription.Text = outputDS.Role[0].RoleDescription;
            }
        }

        protected void BindUIControl()
        {
            BindPageName();

            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                lblPageMode.Text = "Edit";
                btnSave.Text = "Update Role";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //redirect back to previous page
            Response.Redirect("RoleMaintenance.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtRoleName.Text = "";
            txtDescription.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int roleID = 0, moduleID = 0;
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationDS requestDS = new AdministrationDS();

            if (ViewState[WebBase.VS_ADMIN_DS] != null)
            {
                requestDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];
                if (requestDS != null && requestDS.Role.Rows.Count > 0)
                {
                    roleID = requestDS.Role[0].RoleID;
                    requestDS.Role[0].RoleName = txtRoleName.Text;
                    requestDS.Role[0].RoleDescription = txtDescription.Text;
                    requestDS.Role[0].ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                }
                else
                {
                    AdministrationDS.RoleRow row = requestDS.Role.NewRoleRow();
                    row.RoleID = roleID;
                    row.RoleName = txtRoleName.Text;
                    row.RoleDescription = txtDescription.Text;
                    row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                    requestDS.Role.AddRoleRow(row);
                }
            }

            requestDS.ModuleInRole.Clear();
            foreach (GridViewRow gridRow in dgModuleFunction.Rows)
            {
                CheckBox chkIsReadOnly = (CheckBox)gridRow.FindControl("chkIsReadOnly");
                CheckBox chkIsReadWrite = (CheckBox)gridRow.FindControl("chkIsReadWrite");
                moduleID = Convert.ToInt32(dgModuleFunction.DataKeys[gridRow.RowIndex].Value);

                AdministrationDS.ModuleInRoleRow dataRow = requestDS.ModuleInRole.NewModuleInRoleRow();
                dataRow.RoleID = roleID;
                dataRow.ModuleID = moduleID;
                dataRow.IsReadOnly = chkIsReadOnly.Checked;
                dataRow.IsReadWrite = chkIsReadWrite.Checked;
                dataRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                requestDS.ModuleInRole.AddModuleInRoleRow(dataRow);
            }

            AdministrationClient svc = new AdministrationClient();
            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                responseDS = svc.UpdateRole(requestDS);
            }
            else
            {
                responseDS = svc.InsertRole(requestDS);
            }

            if (responseDS.Response.Count > 0)
            {
                if (responseDS.Response[0].ResponseCode == SystemMessage.Generic_Success_Code)
                {
                    AjaxPopupMessage("Record Saved ...!", "RoleMaintenance.aspx");
                }
                else
                {
                    AjaxPopupMessage("Save Record Failed ...!");
                }
            }
            else
            {
                AjaxPopupMessage("Save Record Failed ...!");
            }
        }

        protected void GetRole()
        {
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS response = new AdministrationDS();
            AdministrationDS.RoleRow row = requestDS.Role.NewRoleRow();
            row.RoleID = Convert.ToInt32(Request.QueryString[WebBase.QS_ROLEID]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Role.AddRoleRow(row);

            AdministrationClient adminSVC = new AdministrationClient();
            response = adminSVC.GetRole(requestDS);

            ViewState[WebBase.VS_ADMIN_DS] = response;
        }

        protected void ddlFunction_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetModule(ddlFunction.SelectedValue.Replace("-All-", ""));
            BindData();
        }

        protected void DGModuleFunction()
        {
            WebBase.BindColumn("dgModuleFunction", dgModuleFunction);
            BindData();
        }

        protected void GetModule(string functionName)
        {
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationDS requestDS = new AdministrationDS();

            AdministrationDS.ModuleRow row = requestDS.Module.NewModuleRow();
            row.FunctionName = functionName;
            requestDS.Module.AddModuleRow(row);

            AdministrationClient svc = new AdministrationClient();
            responseDS = svc.GetModule(requestDS);

            foreach (AdministrationDS.ModuleInRoleRow moduleInRoleRow in requestDS.ModuleInRole)
            {
                foreach (AdministrationDS.ModuleRow moduleRow in responseDS.Module)
                {
                    if(moduleRow.ModuleID == moduleInRoleRow.ModuleID)
                    {
                        moduleRow.IsReadOnly = moduleInRoleRow.IsReadOnly;
                        moduleRow.IsReadWrite = moduleInRoleRow.IsReadWrite;
                    }
                }
            }

            responseDS.Merge(requestDS.Role);
            responseDS.Merge(requestDS.ModuleInRole);

            ViewState[WebBase.VS_ADMIN_DS] = responseDS;
        }

        #region ReferenceCode

        //private void ToggleCheckState(bool checkState)
        //{
        //    // Iterate through the Products.Rows property
        //    foreach (GridViewRow row in Products.Rows)
        //    {
        //        // Access the CheckBox
        //        CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
        //        if (cb != null)
        //            cb.Checked = checkState;
        //    }
        //}

        //protected void CheckAll_Click(object sender, EventArgs e)
        //{
        //    ToggleCheckState(true);
        //}
        //protected void UncheckAll_Click(object sender, EventArgs e)
        //{
        //    ToggleCheckState(false);
        //}
        #endregion

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }
    }
}