using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFSystemMaintenance;

namespace SEM.CMS.Web.Admin
{
    public partial class DataGridColumnMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUIControl();
                GetDataGridColumn("");
                DGDataGridColumn();
            }
        }

        protected void BindColumnType()
        {
            // Bind data column type
            foreach (ReferenceNum.DataColumnType item in Enum.GetValues(typeof(ReferenceNum.DataColumnType)).Cast<ReferenceNum.DataColumnType>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.DataColumnType)Enum.Parse(typeof(ReferenceNum.DataColumnType), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlColumnType.Items.Add(listItem);
            }
        }

        protected void BindEnumType()
        {
            // Bind data Enum type
            foreach (ReferenceNum.ReferenceCategory item in Enum.GetValues(typeof(ReferenceNum.ReferenceCategory)).Cast<ReferenceNum.ReferenceCategory>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.ReferenceCategory)Enum.Parse(typeof(ReferenceNum.ReferenceCategory), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlEnumType.Items.Add(listItem);
            }
        }

        protected void BindDataGridName()
        {
            // Bind data column name
            SystemMaintenanceDS responseDS = new SystemMaintenanceDS();
            SystemMaintenanceClient svc = new SystemMaintenanceClient();
            responseDS = svc.GetDataColumnName();
            responseDS.DataGridColumn.AddDataGridColumnRow(0,"-All-","","",0,0,"","",0,"",false,false,0, 0);

            DataView sortedView = new DataView();
            sortedView = responseDS.DataGridColumn.DefaultView;
            sortedView.Sort = responseDS.DataGridColumn.DataGridNameColumn.ColumnName + " ASC";

            ddlDataGridName.DataSource = sortedView;
            ddlDataGridName.DataTextField = responseDS.DataGridColumn.DataGridNameColumn.ColumnName;
            ddlDataGridName.DataValueField = responseDS.DataGridColumn.DataGridNameColumn.ColumnName;
            ddlDataGridName.DataBind();
        }

        protected void BindData()
        {
            SystemMaintenanceDS outputDS = new SystemMaintenanceDS();
            outputDS = (SystemMaintenanceDS)ViewState[WebBase.VS_SYSTEMMAINTENANCE_DS];
            dgDataGridColumn.DataSource = outputDS.DataGridColumn;
            dgDataGridColumn.DataBind();
        }

        protected void BindUIControl()
        {
            BindColumnType();
            BindEnumType();
            BindDataGridName();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //redirect back to previous page
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtColumnWidth.Text = "";
            txtCssClass.Text = "";
            txtDataField.Text = "";
            txtDataGridName.Text = "";
            txtHeaderText.Text = "";
            txtNavigationURL.Text = "";
            txtNavigationURLDataField.Text = "";
            txtSortID.Text = "";
            chkIsAllowHTMLEncode.Checked = false;
            chkIsReadOnly.Checked = false;
            ddlColumnType.SelectedIndex = 0;
            ddlEnumType.SelectedIndex = 0;
        }

        protected void ddlDataGridName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataGridColumn(ddlDataGridName.SelectedValue.Replace("-All-", ""));
            BindData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SystemMaintenanceDS responseDS = new SystemMaintenanceDS();
            SystemMaintenanceDS requestDS = new SystemMaintenanceDS();
            SystemMaintenanceDS.DataGridColumnRow row = requestDS.DataGridColumn.NewDataGridColumnRow();

            row.ColumnTypeID = Convert.ToInt32(ddlColumnType.SelectedValue);
            row.ColumnWidth = Convert.ToInt32(txtColumnWidth.Text);
            row.CssClass = txtCssClass.Text;
            row.DataField = txtDataField.Text;
            row.DataGridName = txtDataGridName.Text;
            row.HeaderText = txtHeaderText.Text;
            row.NavigateURL = txtNavigationURL.Text;
            row.NavigateURLDataField = txtNavigationURLDataField.Text;
            row.SortID = Convert.ToInt32(txtSortID.Text);
            row.IsAllowHTMLEncode = chkIsAllowHTMLEncode.Checked;
            row.IsReadOnly = chkIsReadOnly.Checked;
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

            if (ddlEnumType.Enabled)
            {
                row.EnumTypeID = Convert.ToInt32(ddlEnumType.SelectedValue);
            }
                

            requestDS.DataGridColumn.AddDataGridColumnRow(row);

            SystemMaintenanceClient svc = new SystemMaintenanceClient();
            svc.InsertDataGridColumn(requestDS);

            GetDataGridColumn(txtDataGridName.Text);
            BindData();
        }

        protected void DGDataGridColumn()
        {
            WebBase.BindColumn("dgDataGridColumn", dgDataGridColumn);
            BindData();
        }

        protected void DGDataGridColumn_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            dgDataGridColumn.EditIndex = -1;
            //Bind data to the GridView control.
            BindData();
        }

        protected void DGDataGridColumn_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SystemMaintenanceDS requestDS = new SystemMaintenanceDS();
            SystemMaintenanceDS.DataGridColumnRow row = requestDS.DataGridColumn.NewDataGridColumnRow();
            row.DataGridColumnID = Convert.ToInt32(dgDataGridColumn.DataKeys[e.RowIndex].Values[requestDS.DataGridColumn.DataGridColumnIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.DataGridColumn.AddDataGridColumnRow(row);

            SystemMaintenanceClient svc = new SystemMaintenanceClient();
            svc.DeleteDataGridColumn(requestDS);

            GetDataGridColumn(ddlDataGridName.SelectedValue);
            BindData();
        }

        protected void DGDataGridColumn_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            dgDataGridColumn.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void DGDataGridColumn_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SystemMaintenanceDS responseDS = new SystemMaintenanceDS();
            SystemMaintenanceDS requestDS = new SystemMaintenanceDS();
            SystemMaintenanceDS.DataGridColumnRow row = requestDS.DataGridColumn.NewDataGridColumnRow();

            row.DataGridColumnID = Convert.ToInt32(dgDataGridColumn.DataKeys[e.RowIndex].Values[responseDS.DataGridColumn.DataGridColumnIDColumn.ColumnName]);
            if(e.NewValues[responseDS.DataGridColumn.ColumnTypeIDColumn.ColumnName] != null)
            {
                row.ColumnTypeID = Convert.ToInt32(e.NewValues[responseDS.DataGridColumn.ColumnTypeIDColumn.ColumnName].ToString());
            }
            if (e.NewValues[responseDS.DataGridColumn.ColumnWidthColumn.ColumnName] != null)
            {
                row.ColumnWidth = Convert.ToInt32(e.NewValues[responseDS.DataGridColumn.ColumnWidthColumn.ColumnName].ToString());
            }
            if (e.NewValues[responseDS.DataGridColumn.CssClassColumn.ColumnName] != null)
            {
                row.CssClass = e.NewValues[responseDS.DataGridColumn.CssClassColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.DataGridColumn.DataFieldColumn.ColumnName] != null)
            {
                row.DataField = e.NewValues[responseDS.DataGridColumn.DataFieldColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.DataGridColumn.DataGridNameColumn.ColumnName] != null)
            {
                row.DataGridName = e.NewValues[responseDS.DataGridColumn.DataGridNameColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.DataGridColumn.HeaderTextColumn.ColumnName] != null)
            {
                row.HeaderText = e.NewValues[responseDS.DataGridColumn.HeaderTextColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.DataGridColumn.NavigateURLColumn.ColumnName] != null)
            {
                row.NavigateURL = e.NewValues[responseDS.DataGridColumn.NavigateURLColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.DataGridColumn.NavigateURLDataFieldColumn.ColumnName] != null)
            {
                row.NavigateURLDataField = e.NewValues[responseDS.DataGridColumn.NavigateURLDataFieldColumn.ColumnName].ToString();
            }
            if (e.NewValues[responseDS.DataGridColumn.SortIDColumn.ColumnName] != null)
            {
                row.SortID = Convert.ToInt32(e.NewValues[responseDS.DataGridColumn.SortIDColumn.ColumnName].ToString());
            }
            if (e.NewValues[responseDS.DataGridColumn.IsAllowHTMLEncodeColumn.ColumnName] != null)
            {
                row.IsAllowHTMLEncode = Convert.ToBoolean(e.NewValues[responseDS.DataGridColumn.IsAllowHTMLEncodeColumn.ColumnName]);
            }
            if (e.NewValues[responseDS.DataGridColumn.IsReadOnlyColumn.ColumnName] != null)
            {
                row.IsReadOnly = Convert.ToBoolean(e.NewValues[responseDS.DataGridColumn.IsReadOnlyColumn.ColumnName]);
            }
            if (e.NewValues[responseDS.DataGridColumn.EnumTypeIDColumn.ColumnName] != null)
            {
                row.EnumTypeID = Convert.ToInt32(e.NewValues[responseDS.DataGridColumn.EnumTypeIDColumn.ColumnName].ToString());
            }
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.DataGridColumn.AddDataGridColumnRow(row);

            SystemMaintenanceClient systemSVC = new SystemMaintenanceClient();
            systemSVC.UpdateDataGridColumn(requestDS);

            ////Reset the edit index.
            dgDataGridColumn.EditIndex = -1;

            //Bind data to the GridView control.
            GetDataGridColumn(ddlDataGridName.SelectedValue);
            BindData();
        }

        protected void DGDataGridColumn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgDataGridColumn.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void GetDataGridColumn(string dataGridName)
        {
            SystemMaintenanceDS responseDS = new SystemMaintenanceDS();

            SystemMaintenanceClient svc = new SystemMaintenanceClient();
            responseDS = svc.GetDataColumnList(dataGridName);

            ViewState[WebBase.VS_SYSTEMMAINTENANCE_DS] = responseDS;
        }

        protected void ddlColumnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if (ddl.SelectedItem.Text == ReferenceNum.DataColumnType.DropDown.ToString())
            {
                ddlEnumType.Enabled = true;
            }
            else
            {
                ddlEnumType.Enabled = false;
            }
        }
    }
}