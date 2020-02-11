using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFCompetition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Web.Competition
{
    public partial class TeamDetails : System.Web.UI.Page
    {
        const string qs_NEW = "New";
        const string qs_EDIT = "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindUIControl();
                if (Request.QueryString[WebBase.QS_PAGE_MODE] != null && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    this.BindData();

                    divAssign.Visible = true;
                    divCountry.Visible = true;
                    divParticipants.Visible = true;
                    divTeamMember.Visible = true;
                    this.GetParticipantInTeam();
                    this.GetParticipantInEvent();
                    this.DGParticipantInTeam();
                    this.DGParticipantInEvent();

                    BindParticipantInEvent();
                    BindParticipantInTeam();
                }
                else
                {
                    this.BindEventList();
                }
            }
        }

        protected void DGParticipantInTeam()
        {
            WebBase.BindColumn("dgParticipantInTeam", dgParticipantInTeam);
            BindParticipantInTeam();
        }

        protected void DGParticipantInEvent()
        {
            WebBase.BindColumn("dgParticipantInEventForTeam", dgParticipantInEventForTeam);
            BindParticipantInEvent();
        }

        protected void BindUIControl()
        {
            this.BindSportList();
            this.BindCountryList();
        }

        protected void BindData()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.TeamRow row = requestDS.Team.NewTeamRow();
            row.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
            requestDS.Team.AddTeamRow(row);

            #region GetTeam
            responseDS = svc.GetTeam(requestDS);
            #endregion

            lblPageMode.Text = "Update";
            if (!responseDS.Team[0].IsTeamNameNull())
            {
                txtTeamName.Text = responseDS.Team[0].TeamName;
            }
            if (!responseDS.Team[0].IsSportIDNull())
            {
                ddlSport.SelectedValue = Convert.ToString(responseDS.Team[0].SportID);
            }

            //bind event list based on sport value selected
            this.BindEventList();

            if (!responseDS.Team[0].IsEventIDNull())
            {
                ddlEvent.SelectedValue = Convert.ToString(responseDS.Team[0].EventID);
            }
        }

        protected void BindParticipantInEvent()
        {
            CompetitionDS.ParticipantDetailDataTable participantDT = new CompetitionDS.ParticipantDetailDataTable();
            participantDT = (CompetitionDS.ParticipantDetailDataTable)ViewState[WebBase.VS_PARTICIPANTINEVENT_DT];
            dgParticipantInEventForTeam.DataSource = participantDT;
            dgParticipantInEventForTeam.DataBind();
        }

        protected void BindParticipantInTeam()
        {
            CompetitionDS.ParticipantDetailDataTable participantDT = new CompetitionDS.ParticipantDetailDataTable();
            participantDT = (CompetitionDS.ParticipantDetailDataTable)ViewState[WebBase.VS_PARTICIPANTINTEAM_DT];
            dgParticipantInTeam.DataSource = participantDT;
            dgParticipantInTeam.DataBind();
        }

        protected void ddlSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindEventList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.TeamRow row = requestDS.Team.NewTeamRow();
            
            int teamID = 0;

            row.TeamName = txtTeamName.Text;
            row.EventID = Convert.ToInt32(ddlEvent.SelectedItem.Value);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);


            CompetitionClient competitionSVC = new CompetitionClient();
            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                row.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
                requestDS.Team.AddTeamRow(row);
                responseDS = competitionSVC.UpdateTeam(requestDS);
                teamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
            }
            else
            {
                row.IsActive = 1;
                row.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                requestDS.Team.AddTeamRow(row);
                responseDS = competitionSVC.InsertTeam(requestDS);
                teamID = responseDS.Team[0].TeamID;
            }

            AjaxPopupMessage("Team Saved ...!", Request.Url.AbsolutePath + "?PageMode=Edit&TeamID=" + teamID.ToString());
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //redirect back to previous page
            Response.Redirect("~/Competition/TeamMaintenance.aspx");

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTeamName.Text = "";
            ddlSport.SelectedIndex = 0;
            this.BindEventList();
            ddlEvent.SelectedIndex = 0;
        }

        protected void BindCountryList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.CountryRow row = requestDS.Country.NewCountryRow();

            requestDS.Country.AddCountryRow(row);

            #region GetSport
            responseDS = svc.GetCountry(requestDS);
            #endregion

            ddlCountry.DataSource = responseDS.Country;
            ddlCountry.DataTextField = responseDS.Country.CountryNameColumn.ColumnName;
            ddlCountry.DataValueField = responseDS.Country.CountryIDColumn.ColumnName; ;
            ddlCountry.DataBind();
        }

        protected void BindSportList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportRow row = requestDS.Sport.NewSportRow();

            requestDS.Sport.AddSportRow(row);

            #region GetSport
            responseDS = svc.GetSport(requestDS);
            #endregion

            ddlSport.DataSource = responseDS.Sport;
            ddlSport.DataTextField = responseDS.Sport.SportNameColumn.ColumnName;
            ddlSport.DataValueField = responseDS.Sport.SportIDColumn.ColumnName; ;
            ddlSport.DataBind();
        }

        protected void BindEventList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();


            if (string.IsNullOrEmpty(ddlSport.SelectedValue))
                return;

            row.SportID = Convert.ToInt32(ddlSport.SelectedValue);

            requestDS.Event.AddEventRow(row);

            #region GetEventList
            responseDS = svc.GetEventList(requestDS);
            #endregion

            ddlEvent.DataSource = responseDS.Event;
            ddlEvent.DataTextField = responseDS.Event.EventNameColumn.ColumnName;
            ddlEvent.DataValueField = responseDS.Event.EventIDColumn.ColumnName; ;
            ddlEvent.DataBind();
        }

        protected void GetParticipantInEvent()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();
            row.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            row.EventID = Convert.ToInt32(ddlEvent.SelectedValue);
            requestDS.ParticipantDetail.AddParticipantDetailRow(row);

            #region GetParticipant
            responseDS = svc.GetParticipantInEventForTeam(requestDS);

            ViewState[WebBase.VS_PARTICIPANTINEVENT_DT] = responseDS.ParticipantDetail;
            #endregion
        }

        protected void GetParticipantInTeam()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.ParticipantInEventRow row = requestDS.ParticipantInEvent.NewParticipantInEventRow();
            row.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
            requestDS.ParticipantInEvent.AddParticipantInEventRow(row);

            #region GetParticipant
            responseDS = svc.GetParticipantInTeam(requestDS);

            ViewState[WebBase.VS_PARTICIPANTINTEAM_DT] = responseDS.ParticipantDetail;
            #endregion
        }

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetParticipantInEvent();
            BindParticipantInEvent();
        }

        protected void btnAddParticipant_Click(object sender, EventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            foreach (GridViewRow gridRow in dgParticipantInEventForTeam.Rows)
            {
                CheckBox chkAssignTeam = (CheckBox)gridRow.FindControl("chkAssignTeam");

                if (chkAssignTeam.Checked)
                {
                    int participantInEventID = Convert.ToInt32(dgParticipantInEventForTeam.DataKeys[gridRow.RowIndex].Value);

                    CompetitionDS.ParticipantInEventRow participantInEventRow = requestDS.ParticipantInEvent.NewParticipantInEventRow();
                    participantInEventRow.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
                    participantInEventRow.ParticipantInEventID = participantInEventID;
                    participantInEventRow.IsActive = 1;
                    participantInEventRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                    requestDS.ParticipantInEvent.AddParticipantInEventRow(participantInEventRow);

                    responseDS = svc.UpdateParticipantDetail(requestDS);
                }
            }
            GetParticipantInTeam();
            BindParticipantInTeam();
        }

        protected void dgParticipantInTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            int participantInEventID = Convert.ToInt32(dgParticipantInTeam.DataKeys[e.RowIndex].Value);

            CompetitionDS.ParticipantInEventRow participantInEventRow = requestDS.ParticipantInEvent.NewParticipantInEventRow();
            participantInEventRow.IsActive = 1;
            participantInEventRow.TeamID = 0;
            participantInEventRow.ParticipantInEventID = participantInEventID;
            participantInEventRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.ParticipantInEvent.AddParticipantInEventRow(participantInEventRow);

            responseDS = svc.UpdateParticipantDetail(requestDS);
            GetParticipantInTeam();
            BindParticipantInTeam();
        }
    }
}