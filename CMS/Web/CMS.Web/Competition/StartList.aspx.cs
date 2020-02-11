using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFSystemMaintenance;
using SEM.CMS.Web.WCFCompetition;

namespace SEM.CMS.Web.Competition
{
    public partial class StartList : System.Web.UI.Page
    {
        protected CompetitionDS.SportEventScheduleRow sportEventScheduleRow;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetSportEventSchedule();

            if (!IsPostBack)
            {
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    ViewState[WebBase.VS_EVENTID] = Request.QueryString[WebBase.QS_EVENTID];
                }

                if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
                {
                    ViewState[WebBase.VS_SCHEDULEID] = Request.QueryString[WebBase.QS_SCHEDULEID];
                }

                GetSportEventSchedule();
                DGStartListMaintenance();
                DGStartListAddParticipant();
                GetStartListMaintenance();
                BindData();
            }

            StartListMaintenanceBindData();
        }

        protected void GetSportEventSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportEventScheduleRow row = requestDS.SportEventSchedule.NewSportEventScheduleRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.SportEventSchedule.AddSportEventScheduleRow(row);

            #region GetSchedule
            responseDS = svc.GetSportEventSchedule(requestDS);
            if (responseDS.SportEventSchedule.Count > 0)
            {
                sportEventScheduleRow = responseDS.SportEventSchedule[0];
            }
            #endregion
        }

        protected void BindData()
        {
            #region Bind Schedule Details
            if (sportEventScheduleRow != null)
            {
                lblEventDetails.Text = sportEventScheduleRow.SportName.ToUpper() + " - " + sportEventScheduleRow.EventName;
                imgSportImage.ImageUrl = sportEventScheduleRow.ImageFilePath;
                lblScheduleDetails.Text = sportEventScheduleRow.ScheduleName;
                lblScheduleVenueTime.Text = sportEventScheduleRow.Location + " - " + sportEventScheduleRow.ScheduleDateTime.ToString();

                if (!sportEventScheduleRow.IsStartListFooterNull())
                {
                    ckeStarlistFooter.Text = sportEventScheduleRow.StartListFooter;
                }
            }
            else
            {
                lblEventDetails.Visible = false;
                imgSportImage.Visible = false;
                lblScheduleDetails.Visible = false;
                lblScheduleVenueTime.Visible = false;
            }
            #endregion
        }

        protected void ddlSourceName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGStartListAddParticipant();

            if (ddlSourceName.SelectedValue != "")
            {
                btnAddMultipleParticipant.Visible = true;
            }
            else
            {
                btnAddMultipleParticipant.Visible = false;
            }
        }

        protected void DGStartListAddParticipant()
        {
            WebBase.BindColumn("dgStartListAddParticipant", dgStartListAddParticipant);
        }

        protected void DGStartListMaintenance()
        {
            dgStartListMaintenance.Font.Size = FontUnit.Smaller;
            WebBase.BindColumn("dgStartListMaintenance", dgStartListMaintenance);
        }

        protected void RefreshDGStartListAddParticipant()
        {
            GetStartListParticipant(ddlSourceName.SelectedValue);
            ParticipantListBindData();
        }

        protected void RefreshDGStartListMaintenance()
        {
            GetStartListMaintenance();
            StartListMaintenanceBindData();
        }

        protected void ParticipantListBindData()
        {
            CompetitionDS outputDS = new CompetitionDS();
            outputDS = (CompetitionDS)ViewState[WebBase.VS_STARTLISTPARTICIPANT_DS];

            if ((ReferenceNum.EventType)sportEventScheduleRow.EventTypeID != ReferenceNum.EventType.Individual)
            {
                dgStartListAddParticipant.DataSource = outputDS.ParticipantInSchedule.Where(row => !row.IsTeamIDNull() && row.TeamID != 0);
            }
            else
            {
                dgStartListAddParticipant.DataSource = outputDS.ParticipantInSchedule;
            }
                        
            dgStartListAddParticipant.DataBind();
        }

        protected void StartListMaintenanceBindData()
        {
            CompetitionDS outputDS = new CompetitionDS();
            outputDS = (CompetitionDS)ViewState[WebBase.VS_STARTLIST_DS];
            dgStartListMaintenance.DataSource = outputDS.ParticipantInSchedule;
            dgStartListMaintenance.DataBind();
        }

        protected void GetStartListParticipant(string sourceName)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantInScheduleRow row = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();

            // Get EventID
            if (sourceName != null && sourceName != "")
            {
                if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
                {
                    row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
                }
                //row.EventID = 1;//for Testing only!!!
            }
            else
            {
                row.EventID = 0;//for Testing only!!!
            }
            // Get ScheduleID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }
            else
            {
                row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
                //row.ScheduleID = 1;//for Testing only!!!
            }
            requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(row);

            #region GetStartListParticipantList
            responseDS = svc.GetStartListParticipantList(requestDS);
            ViewState[WebBase.VS_STARTLISTPARTICIPANT_DS] = responseDS;
            #endregion
        }

        protected void GetStartListMaintenance()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantInScheduleRow row = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();

            // Get ScheduleID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            //row.ScheduleID = 1;//for Testing only!!!

            requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(row);

            #region GetStartListMaintenance
            responseDS = svc.GetStartListMaintenance(requestDS);

            ViewState[WebBase.VS_STARTLIST_DS] = responseDS;
            #endregion
        }

        protected void DGStartListMaintenance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantInScheduleRow row = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();
            row.ParticipantInScheduleID = Convert.ToInt32(dgStartListMaintenance.DataKeys[e.RowIndex].Values[requestDS.ParticipantInSchedule.ParticipantInScheduleIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(row);

            CompetitionClient svc = new CompetitionClient();
            svc.DeleteStartListParticipant(requestDS);

            RefreshDGStartListMaintenance();
            RefreshDGStartListAddParticipant();
        }

        protected void btnAddMultipleParticipant_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in dgStartListAddParticipant.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkAdd");
                if (chk != null & chk.Checked)
                {
                    CompetitionClient svc = new CompetitionClient();
                    CompetitionDS responseDS = new CompetitionDS();

                    CompetitionDS requestDS = new CompetitionDS();
                    CompetitionDS.ParticipantInScheduleRow row = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();

                    // Get ScheduleID
                    if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
                    {
                        row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                    }
                    else
                    {
                        row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
                        //row.ScheduleID = 1;//for Testing only!!!
                    }

                    //1-ParticipantID
                    //2-ParticipantName
                    //3-CountryName
                    //4-PassportNumber
                    //5-TeamID
                    //4-GroupCode

                    row.ParticipantID = Convert.ToInt32(gvrow.Cells[1].Text);

                    if (gvrow.Cells[5].Text != string.Empty && gvrow.Cells[5].Text != "&nbsp;")
                    {
                        row.TeamID = Convert.ToInt32(gvrow.Cells[5].Text);
                    }

                    row.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                    requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(row);

                    svc.InsertStartList(requestDS);
                }
            }

            RefreshDGStartListAddParticipant();
            RefreshDGStartListMaintenance();
        }

        protected void HiddenBtnUp_Click(object sender, EventArgs e)
        {
            SortPositionUp(true);

            RefreshDGStartListMaintenance();
        }

        protected void HiddenBtnDown_Click(object sender, EventArgs e)
        {
            SortPositionUp(false);

            RefreshDGStartListMaintenance();
        }

        protected void SortPositionUp(bool Up)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS outputDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();
            outputDS = (CompetitionDS)ViewState[WebBase.VS_STARTLIST_DS];

            int sortID = Convert.ToInt32(HiddenTxtSortID.Text);
            int swapID = sortID;

            if(Up)
            {
                var rows = from PIS in outputDS.ParticipantInSchedule
                          where PIS.SortID < sortID
                          select PIS;
                swapID = 0;
                foreach(var row in rows)
                {
                    if(row.SortID > swapID)
                    {
                        swapID = row.SortID;
                    }
                }
            }
            else
            {
                var rows = from PIS in outputDS.ParticipantInSchedule
                           where PIS.SortID > sortID
                           select PIS;

                var maxSort = (from PIS in outputDS.ParticipantInSchedule
                               select PIS.SortID).Max();

                swapID = Convert.ToInt32(maxSort);
                
                foreach (var row in rows)
                {
                    if (row.SortID < swapID)
                    {
                        swapID = row.SortID;
                    }
                }
            }

            if (swapID != sortID)
            {
                foreach (CompetitionDS.ParticipantInScheduleRow row in outputDS.ParticipantInSchedule)
                {
                    requestDS.Clear();
                    CompetitionDS.ParticipantInScheduleRow requestRow = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();
                    if (row.SortID == sortID)
                    {
                        requestRow.ScheduleID = Convert.ToInt32(HiddenTxtScheduleID.Text);

                        if (HiddenTxtTeamID.Text != "")
                        {
                            requestRow.TeamID = Convert.ToInt32(row.TeamID);
                        }
                        else
                        {
                            requestRow.ParticipantID = Convert.ToInt32(row.ParticipantID);
                        }

                        requestRow.SortID = swapID;
                        requestRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                        requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(requestRow);

                        svc.UpdateStartListPosition(requestDS);
                    }
                    else if (row.SortID == swapID)
                    {
                        requestRow.ScheduleID = Convert.ToInt32(HiddenTxtScheduleID.Text);

                        if (HiddenTxtTeamID.Text != "")
                        {
                            requestRow.TeamID = Convert.ToInt32(row.TeamID);
                        }
                        else
                        {
                            requestRow.ParticipantID = Convert.ToInt32(row.ParticipantID);
                        }

                        requestRow.SortID = sortID;
                        requestRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                        requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(requestRow);

                        svc.UpdateStartListPosition(requestDS);
                    }
                }
            }
        }

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState[WebBase.VS_EVENTID] != null)
            {
                Response.Redirect("~/Competition/ScheduleMaintenance.aspx?EventID=" + ViewState[WebBase.VS_EVENTID]);
            }
            else
            {
                Response.Redirect("~/Competition/ScheduleMaintenance.aspx");
            }
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Competition/ResultMaintenance.aspx?" + Request.QueryString.ToString());
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            WebBase webBase = new WebBase();
            if (!webBase.IsValidModule(Request))
            {
                int id = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);

                ReferenceNum.Sport sport = (ReferenceNum.Sport)Enum.ToObject(typeof(ReferenceNum.Sport), id);
                string sportName = ReferenceNum.ToEnumString<ReferenceNum.Sport>(sport);
                AjaxPopupMessage("Insufficient rights. Attempt to edit value for " + sportName + " is prohibited.");
                return;
            }

            CompetitionClient systemSVC = new CompetitionClient();
            
            foreach (GridViewRow gvRow in dgStartListMaintenance.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    CompetitionDS requestDS = new CompetitionDS();
                    CompetitionDS.ParticipantInScheduleRow row = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();

                    row.ParticipantInScheduleID = Convert.ToInt32(dgStartListMaintenance.DataKeys[gvRow.RowIndex].Values[requestDS.ParticipantInSchedule.ParticipantInScheduleIDColumn.ColumnName]);
                    
                    if (gvRow.FindControl("ddl_" + requestDS.ParticipantInSchedule.ParticipantTypeIDColumn) != null)
                    {
                        row.ParticipantTypeID = Convert.ToInt32(((DropDownList)gvRow.FindControl("ddl_" + requestDS.ParticipantInSchedule.ParticipantTypeIDColumn)).SelectedValue);
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList1Column) != null)
                    {
                        row.StartList1 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList1Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList2Column) != null)
                    {
                        row.StartList2 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList2Column)).Text;
                    }
                    
                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList3Column) != null)
                    {
                        row.StartList3 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList3Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList4Column) != null)
                    {
                        row.StartList4 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList4Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList5Column) != null)
                    {
                        row.StartList5 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList5Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList6Column) != null)
                    {
                        row.StartList6 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList6Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList7Column) != null)
                    {
                        row.StartList7 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList7Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList8Column) != null)
                    {
                        row.StartList8 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList8Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList9Column) != null)
                    {
                        row.StartList9 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList9Column)).Text;
                    }

                    if (gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList10Column) != null)
                    {
                        row.StartList10 = ((TextBox)gvRow.FindControl("txt_" + requestDS.ParticipantInSchedule.StartList10Column)).Text;
                    }

                    row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                    requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(row);

                    systemSVC.UpdateStartList(requestDS);
                }
            }


            GridViewRow headerGvRow = dgStartListMaintenance.HeaderRow;
            CompetitionDS requestStartListDS = new CompetitionDS();
            CompetitionDS.StartlistNameRow starListRow = requestStartListDS.StartlistName.NewStartlistNameRow();

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName1Column) != null)
            {
                starListRow.StartListName1 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName1Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName2Column) != null)
            {
                starListRow.StartListName2 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName2Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName3Column) != null)
            {
                starListRow.StartListName3 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName3Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName4Column) != null)
            {
                starListRow.StartListName4 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName4Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName5Column) != null)
            {
                starListRow.StartListName5 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName5Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName6Column) != null)
            {
                starListRow.StartListName6 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName6Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName7Column) != null)
            {
                starListRow.StartListName7 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName7Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName8Column) != null)
            {
                starListRow.StartListName8 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName8Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName9Column) != null)
            {
                starListRow.StartListName9 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName9Column)).Text;
            }

            if (headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName10Column) != null)
            {
                starListRow.StartListName10 = ((TextBox)headerGvRow.FindControl("txt_" + requestStartListDS.StartlistName.StartListName10Column)).Text;
            }
            
            if (hidStartListNameID.Value != string.Empty)
            {
                starListRow.StartListNameID = Convert.ToInt32(hidStartListNameID.Value);
                starListRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                requestStartListDS.StartlistName.AddStartlistNameRow(starListRow);
                systemSVC.UpdateStartListName(requestStartListDS);
            }
            else
            {
                // Get ScheduleID
                if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
                {
                    starListRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                }
                else
                {
                    starListRow.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
                }

                starListRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                requestStartListDS.StartlistName.AddStartlistNameRow(starListRow);
                systemSVC.InsertStartListName(requestStartListDS);
            }

            SaveScheduleDetails();
        }

        protected void SaveScheduleDetails()
        {
            CompetitionClient competitionSVC = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            #region SaveScheduleDetails
            CompetitionDS.SportEventScheduleRow newSportEventScheduleRow = requestDS.SportEventSchedule.NewSportEventScheduleRow();
            newSportEventScheduleRow.StartListFooter = ckeStarlistFooter.Text;

            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                newSportEventScheduleRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
            {
                newSportEventScheduleRow.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            newSportEventScheduleRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

            requestDS.SportEventSchedule.AddSportEventScheduleRow(newSportEventScheduleRow);

            competitionSVC.UpdateScheduleExtraDetail(requestDS);
            #endregion
        }

        protected void dgStartListMaintenance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SystemMaintenanceDS ds = new SystemMaintenanceDS();
                CompetitionDS compDS = new CompetitionDS();

                ds = GetDataColumnByDataGridName("dgStartListMaintenance");

                foreach (SystemMaintenanceDS.DataGridColumnRow row in ds.DataGridColumn)
                {
                    switch ((ReferenceNum.DataColumnType)Enum.Parse(typeof(ReferenceNum.DataColumnType), row.ColumnTypeID.ToString()))
                    {
                        case ReferenceNum.DataColumnType.TextBox:
                            TextBox txt = new TextBox();
                            txt.ID = "txt_" + row.DataField;

                            object txtValue = DataBinder.Eval(e.Row.DataItem, row.DataField);
                            if (txtValue != DBNull.Value)
                            {
                                txt.Text = txtValue.ToString();
                            }
                            txt.Height = 20;
                            txt.Width = 70;
                            txt.Font.Size = FontUnit.Small;
                            txt.Style.Add("padding", "1px 1px 3px 1px");

                            e.Row.Cells[row.SortID + 1].Controls.Add(txt);

                            break;
                        case ReferenceNum.DataColumnType.DropDown:
                            DropDownList ddl = new DropDownList();
                            ddl.ID = "ddl_" + row.DataField;
                            BindDropDownItems(ddl, row.EnumTypeID);

                            object ddlValue = DataBinder.Eval(e.Row.DataItem, row.DataField);
                            if (ddlValue != DBNull.Value)
                            {
                                ddl.SelectedValue = ddlValue.ToString();
                            }
                            ddl.Font.Size = FontUnit.Small;
                            ddl.Width = 70;
                            ddl.Height = 25;
                            e.Row.Cells[row.SortID + 1].Controls.Add(ddl);
                            break;
                    }
                }
                
                for (int i = 1; i <= 10; i++)
                {
                    TableCell cell = new TableCell();

                    TextBox txt = new TextBox();
                    txt.ID = "txt_" + "StartList" + i;

                    object txtValue = DataBinder.Eval(e.Row.DataItem, "StartList" + i);
                    if (txtValue != DBNull.Value)
                    {
                        txt.Text = txtValue.ToString();
                    }
                    txt.Height = 20;
                    txt.Width = 70;
                    txt.Font.Size = FontUnit.Small;
                    txt.Style.Add("padding", "1px 1px 3px 1px");

                    cell.Controls.Add(txt);
                    e.Row.Cells.Add(cell);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                CompetitionDS competitionDS = GetStartListName();

                for (int i = 1; i <= 10; i++)
                {
                    TableHeaderCell headerCell = new TableHeaderCell();

                    TextBox txt = new TextBox();
                    txt.ID = "txt_" + "StartListName" + i;

                    if (competitionDS != null && competitionDS.StartlistName != null && competitionDS.StartlistName.Count > 0)
                    {
                        txt.Text = competitionDS.StartlistName[0]["StartListName" + i].ToString();
                        hidStartListNameID.Value = competitionDS.StartlistName[0].StartListNameID.ToString();
                    }
                    txt.Height = 20;
                    txt.Width = 70;
                    txt.Font.Size = FontUnit.Small;
                    txt.Style.Add("padding", "1px 1px 3px 1px");

                    //headerCell.Style.Add("ControlStyle-Font-Size", "X-Small");
                    //headerCell.Style.Add("HeaderStyle-Font-Size", "X-Small");
                    headerCell.Controls.Add(txt);
                    e.Row.Cells.Add(headerCell);
                }
            }
        }

        public SystemMaintenanceDS GetDataColumnByDataGridName(string dataGridName)
        {
            //Get data grid from DB
            SystemMaintenanceClient systemMaintenanceSVC = new SystemMaintenanceClient();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();

            ds = systemMaintenanceSVC.GetDataColumnByDataGridName(dataGridName);

            return ds;
        }

        public CompetitionDS GetStartListName()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.StartlistNameRow row = requestDS.StartlistName.NewStartlistNameRow();

            // Get ScheduleID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }
            else
            {
                row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
            }

            requestDS.StartlistName.AddStartlistNameRow(row);

            #region GetStartListName
            responseDS = svc.GetStartListName(requestDS);
            #endregion

            return responseDS;
        }

        void BindDropDownItems(DropDownList dropDown, int eNum)
        {
            switch ((ReferenceNum.ReferenceCategory)Enum.Parse(typeof(ReferenceNum.ReferenceCategory), eNum.ToString()))
            {
                case ReferenceNum.ReferenceCategory.ParticipantType:
                    foreach (ReferenceNum.ParticipantType item in Enum.GetValues(typeof(ReferenceNum.ParticipantType)).Cast<ReferenceNum.ParticipantType>())
                    {
                        ListItem listItem = new ListItem();
                        listItem.Value = Convert.ToInt32((ReferenceNum.ParticipantType)Enum.Parse(typeof(ReferenceNum.ParticipantType), item.ToString())).ToString();
                        listItem.Text = item.ToString();
                        dropDown.Items.Add(listItem);
                    }
                    break;
            }
        }
    }
}