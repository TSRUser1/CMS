using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEM.CMS.Web.WCFCompetition;
using SEM.CMS.Web.WCFSystemMaintenance;
using System.Globalization;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Web.Schedule
{
    public partial class ScheduleDetails : System.Web.UI.Page
    {
        const string qs_NEW = "New";
        const string qs_EDIT = "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindControl();
                if (Request.QueryString[WebBase.QS_PAGE_MODE] != null && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    BindData();
                }
            }
        }

        protected void BindControl()
        {
            GetCompetitionFormat();
            GetStatusCode();
            BindtxtGroupValidation();
        }

        protected void BindData()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
            row.ScheduleID = Convert.ToInt32(Request.QueryString[1]);
            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            #region GetSchedule
            responseDS = svc.GetSchedule(requestDS);
            #endregion

            lblPageMode.Text = "Update";
            if (!responseDS.ScheduleDetail[0].IsPlayFormatIDNull())
            {
                ddlCompetitionFormat.SelectedValue = Convert.ToString(responseDS.ScheduleDetail[0].PlayFormatID);
            }
            if (!responseDS.ScheduleDetail[0].IsScheduleNameNull())
            {
                txtScheduleName.Text = responseDS.ScheduleDetail[0].ScheduleName;
            }
            if (!responseDS.ScheduleDetail[0].IsScheduleDateTimeNull())
            {
                txtScheduleDateTime.Text = responseDS.ScheduleDetail[0].ScheduleDateTime.ToString(WebBase.DATE_FORMAT);
            }
            if (!responseDS.ScheduleDetail[0].IsVenueNull())
            {
                txtVenue.Text = responseDS.ScheduleDetail[0].Venue;
            }
            if (!responseDS.ScheduleDetail[0].IsLocationNull())
            {
                txtLocation.Text = responseDS.ScheduleDetail[0].Location;
            }
            if (!responseDS.ScheduleDetail[0].IsRoundNameNull())
            {
                txtRoundName.Text = responseDS.ScheduleDetail[0].RoundName;
            }
            if (!responseDS.ScheduleDetail[0].IsMatchNumberNull())
            {
                txtMatchNo.Text = Convert.ToString(responseDS.ScheduleDetail[0].MatchNumber);
            }
            if (!responseDS.ScheduleDetail[0].IsTotalParticipantNull())
            {
                txtTotalParticipants.Text = Convert.ToString(responseDS.ScheduleDetail[0].TotalParticipant);
            }
            if (!responseDS.ScheduleDetail[0].IsGroupCodeNull())
            {
                txtGroup.Text = responseDS.ScheduleDetail[0].GroupCode;
            }
            if (!responseDS.ScheduleDetail[0].IsStatusCodeIDNull())
            {
                ddlStatus.SelectedValue = Convert.ToString(responseDS.ScheduleDetail[0].StatusCodeID);
            }
            if (!responseDS.ScheduleDetail[0].IsHeadToHeadNull())
            {
                chkHeadToHead.Checked = responseDS.ScheduleDetail[0].HeadToHead;
            }
            if (!responseDS.ScheduleDetail[0].IsIsMedalGameNull())
            {
                chkIsMedalGame.Checked = responseDS.ScheduleDetail[0].IsMedalGame;
            }
            if (!responseDS.ScheduleDetail[0].IsIsPublishStartListNull())
            {
                chkIsPublishStartlist.Checked = responseDS.ScheduleDetail[0].IsPublishStartList;
            }
            if (!responseDS.ScheduleDetail[0].IsIsPublishScheduleNull())
            {
                chkIsPublishSchedule.Checked = responseDS.ScheduleDetail[0].IsPublishSchedule;
            }
            if (!responseDS.ScheduleDetail[0].IsScheduleDateTimeNull())
            {
                txtScheduleTime.Text = responseDS.ScheduleDetail[0].ScheduleDateTime.ToString(WebBase.TIME_FORMAT_HRS24);
            }
            if (!responseDS.ScheduleDetail[0].IsCompetitionStageNull())
            {
                txtCompetitionStage.Text = responseDS.ScheduleDetail[0].CompetitionStage.ToString();
            }
            if (!responseDS.ScheduleDetail[0].IsIsOfficialNull())
            {
                chkIsOfficial.Checked = responseDS.ScheduleDetail[0].IsOfficial;
            }
            if (!responseDS.ScheduleDetail[0].IsIsGenerateLeagueSummaryNull())
            {
                chkIsGenerateLeagueSummary.Checked = responseDS.ScheduleDetail[0].IsGenerateLeagueSummary;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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

            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();
            bool headToHeadFlag = true;
            bool medalGameFlag = true;
            bool isValidTime = true;
            if (!chkHeadToHead.Checked)
            {
                headToHeadFlag = false;
            }
            if (!chkIsMedalGame.Checked)
            {
                medalGameFlag = false;
            }

            int index = txtScheduleTime.Text.IndexOf(':');
            if (Convert.ToInt32(txtScheduleTime.Text.Remove(index, 1)) > 2359 || string.IsNullOrEmpty(txtScheduleTime.Text))
            {
                isValidTime = false;
            }

            if (isValidTime == true)
            {
                string transDateTimeStr = txtScheduleDateTime.Text + " " + txtScheduleTime.Text + ":00";
                DateTime date = DateTime.ParseExact(transDateTimeStr, "dd/MM/yyyy HH:mm:ss", null);
                CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();

                if (Request.QueryString[WebBase.QS_EVENTID] != null && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
                else if (Request.QueryString[WebBase.QS_EVENTID] != null && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_NEW)
                {
                    row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
                else
                {
                    row.EventID = 1;
                }
                row.PlayFormatID = Convert.ToInt32(ddlCompetitionFormat.SelectedValue);
                row.ScheduleName = txtScheduleName.Text;
                row.ScheduleDateTime = date;
                row.Venue = txtVenue.Text;
                row.Location = txtLocation.Text;
                row.RoundName = txtRoundName.Text;
                row.MatchNumber = Convert.ToInt32(txtMatchNo.Text);
                row.TotalParticipant = Convert.ToInt32(txtTotalParticipants.Text);
                row.GroupCode = txtGroup.Text;
                row.CompetitionStage = Convert.ToInt32(txtCompetitionStage.Text);
                row.StatusCodeID = Convert.ToInt32(ddlStatus.SelectedValue);
                row.HeadToHead = headToHeadFlag;
                row.IsMedalGame = medalGameFlag;
                row.IsPublishStartList = chkIsPublishStartlist.Checked;
                row.IsPublishSchedule = chkIsPublishSchedule.Checked;
                row.IsOfficial = chkIsOfficial.Checked;
                row.IsGenerateLeagueSummary = chkIsGenerateLeagueSummary.Checked;

                if (chkIsOfficial.Checked)
                {
                    row.StatusCodeID = Convert.ToInt32(ReferenceNum.StatusCode.OF);
                }

                row.IsActive = 1;
                row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
                    requestDS.ScheduleDetail.AddScheduleDetailRow(row);
                    svc.UpdateScheduleDetail(requestDS);
                }
                else
                {
                    row.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                    requestDS.ScheduleDetail.AddScheduleDetailRow(row);
                    svc.InsertScheduleDetail(requestDS);
                }

                #region PopupResponseMessage
                //After closed dialog will redirect to other page
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    AjaxPopupMessage("Record Saved ...!", "~/Competition/ScheduleMaintenance.aspx?EventID=" + Request.QueryString[WebBase.QS_EVENTID]);
                }
                else
                {
                    AjaxPopupMessage("Record Saved ...!", "~/Competition/ScheduleMaintenance.aspx");
                }

                //After closed dialog will stay current page
                //AjaxPopupMessage("Record Saved ...!");
                #endregion
            }
            else
            {
                AjaxPopupMessage("Time is invalid...!");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[WebBase.QS_EVENTID] != null)
            {
                Response.Redirect("~/Competition/ScheduleMaintenance.aspx?EventID=" + Request.QueryString[WebBase.QS_EVENTID]);
            }
            else
            {
                Response.Redirect("~/Competition/ScheduleMaintenance.aspx?");
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtScheduleName.Text = "";
            txtScheduleDateTime.Text = "";
            txtVenue.Text = "";
            txtLocation.Text = "";
            txtRoundName.Text = "";
            txtMatchNo.Text = "";
            txtCompetitionStage.Text = "";
            txtTotalParticipants.Text = "";
            ddlCompetitionFormat.SelectedIndex = 0;
            txtGroup.Text = "";
            ddlStatus.SelectedIndex = 0;
            chkHeadToHead.Checked = false;
            chkIsPublishStartlist.Checked = false;
            chkIsPublishSchedule.Checked = false;
            chkIsOfficial.Checked = false;
            chkIsGenerateLeagueSummary.Checked = false;
        }

        protected void GetCompetitionFormat()
        {
            SystemMaintenanceDS responseDS = new SystemMaintenanceDS();
            SystemMaintenanceDS requestDS = new SystemMaintenanceDS();
            SystemMaintenanceDS.ReferenceRow row = requestDS.Reference.NewReferenceRow();
            row.ReferenceCategoryID = Convert.ToInt32(ReferenceNum.ReferenceCategory.CompetitionFormatType);
            requestDS.Reference.AddReferenceRow(row);
            SystemMaintenanceClient svc = new SystemMaintenanceClient();
            responseDS = svc.GetReferenceByReferenceCategoryID(requestDS);

            ddlCompetitionFormat.DataSource = responseDS.Reference;
            ddlCompetitionFormat.DataTextField = responseDS.Reference.ReferenceContentColumn.ColumnName;
            ddlCompetitionFormat.DataValueField = responseDS.Reference.ReferenceInternalIDColumn.ColumnName; ;
            ddlCompetitionFormat.DataBind();
        }

        protected void GetStatusCode()
        {
            SystemMaintenanceDS responseDS = new SystemMaintenanceDS();
            SystemMaintenanceDS requestDS = new SystemMaintenanceDS();
            SystemMaintenanceDS.ReferenceRow row = requestDS.Reference.NewReferenceRow();
            row.ReferenceCategoryID = Convert.ToInt32(ReferenceNum.ReferenceCategory.StatusCode);
            requestDS.Reference.AddReferenceRow(row);
            SystemMaintenanceClient svc = new SystemMaintenanceClient();
            responseDS = svc.GetReferenceByReferenceCategoryID(requestDS);

            ddlStatus.DataSource = responseDS.Reference;
            ddlStatus.DataTextField = responseDS.Reference.ReferenceContentColumn.ColumnName;
            ddlStatus.DataValueField = responseDS.Reference.ReferenceInternalIDColumn.ColumnName; ;
            ddlStatus.DataBind();
        }

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }

        protected void ddlCompetitionFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindtxtGroupValidation();
        }

        protected void BindtxtGroupValidation()
        {
            if (ddlCompetitionFormat.SelectedItem.Text == ReferenceNum.CompetitionFormatType.League.ToString())
            {
                reqTxtGroup.Enabled = true;
                reqTxtGroup.ValidationGroup = "validationGrp_ScheduleDetails";
            }
            else
            {
                reqTxtGroup.Enabled = false;
                reqTxtGroup.ValidationGroup = string.Empty;
            }
        }
    }
}