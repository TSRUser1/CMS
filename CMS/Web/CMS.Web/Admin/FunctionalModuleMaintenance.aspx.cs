using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Web.WCFAdministration;

namespace SEM.CMS.Web.Admin
{
    public partial class FunctionalModuleMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUIControl();
                GetModule("");
                DGModuleFunction();
            }
        }

        protected void BindPageName()
        {
            // Bind page name
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationClient svc = new AdministrationClient();
            responseDS = svc.GetPageName();
            responseDS.Module.AddModuleRow(0,"","","-All-",false,false,0);

            DataView sortedView = new DataView();
            sortedView = responseDS.Module.DefaultView;
            sortedView.Sort = responseDS.Module.PageNameColumn.ColumnName + " ASC";

            ddlPageName.DataSource = sortedView;
            ddlPageName.DataTextField = responseDS.Module.PageNameColumn.ColumnName;
            ddlPageName.DataValueField = responseDS.Module.PageNameColumn.ColumnName;
            ddlPageName.DataBind();
        }

        protected void BindData()
        {
            AdministrationDS outputDS = new AdministrationDS();
            outputDS = (AdministrationDS)ViewState[WebBase.VS_ADMIN_DS];
            dgModuleFunction.DataSource = outputDS.Module;
            dgModuleFunction.DataBind();
        }

        protected void BindUIControl()
        {
            BindPageName();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //redirect back to previous page
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFunctionalName.Text = "";
            txtModuleName.Text = "";
            txtPageName.Text = "";
        }

        protected void ddlPageName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetModule(ddlPageName.SelectedValue.Replace("-All-", ""));
            BindData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.ModuleRow row = requestDS.Module.NewModuleRow();

            row.ModuleName = txtModuleName.Text;
            row.FunctionName = txtFunctionalName.Text;
            row.PageName = txtPageName.Text;
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Module.AddModuleRow(row);

            AdministrationClient svc = new AdministrationClient();
            svc.InsertModule(requestDS);

            GetModule(txtPageName.Text);
            BindData();
        }

        protected void DGModuleFunction()
        {
            WebBase.BindColumn("dgModuleFunction", dgModuleFunction);
            BindData();
        }

        protected void DGModuleFunction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            dgModuleFunction.EditIndex = -1;
            //Bind data to the GridView control.
            BindData();
        }

        protected void DGModuleFunction_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.ModuleRow row = requestDS.Module.NewModuleRow();
            row.ModuleID = Convert.ToInt32(dgModuleFunction.DataKeys[e.RowIndex].Values[requestDS.Module.ModuleIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Module.AddModuleRow(row);

            AdministrationClient svc = new AdministrationClient();
            svc.DeleteModule(requestDS);

            GetModule(ddlPageName.SelectedValue);
            BindData();
        }

        protected void DGModuleFunction_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            dgModuleFunction.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void DGModuleFunction_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.ModuleRow row = requestDS.Module.NewModuleRow();

            row.ModuleID = Convert.ToInt32(dgModuleFunction.DataKeys[e.RowIndex].Values[responseDS.Module.ModuleIDColumn.ColumnName]);
            if (e.NewValues[responseDS.Module.ModuleNameColumn.ColumnName] != null)
            {
                row.ModuleName = e.NewValues[responseDS.Module.ModuleNameColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.Module.FunctionNameColumn.ColumnName] != null)
            {
                row.FunctionName = e.NewValues[responseDS.Module.FunctionNameColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.Module.PageNameColumn.ColumnName] != null)
            {
                row.PageName = e.NewValues[responseDS.Module.PageNameColumn.ColumnName].ToString();
            }
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Module.AddModuleRow(row);

            AdministrationClient svc = new AdministrationClient();
            svc.UpdateModule(requestDS);

            ////Reset the edit index.
            dgModuleFunction.EditIndex = -1;

            //Bind data to the GridView control.
            GetModule(ddlPageName.SelectedValue);
            BindData();
        }

        protected void DGModuleFunction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgModuleFunction.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void GetModule(string pageName)
        {
            AdministrationDS responseDS = new AdministrationDS();
            AdministrationDS requestDS = new AdministrationDS();
            AdministrationDS.ModuleRow row = requestDS.Module.NewModuleRow();
            row.PageName = pageName;
            requestDS.Module.AddModuleRow(row);

            AdministrationClient svc = new AdministrationClient();

            responseDS = svc.GetModule(requestDS);

            ViewState[WebBase.VS_ADMIN_DS] = responseDS;
        }
    }
}