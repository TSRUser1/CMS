using SEM.CMS.Web.WCFCompetition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Web.Competition
{
    public partial class TeamMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDDLSport();

                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_SPORTID] != null)
                    {
                        ddlSport.SelectedValue = Request.QueryString[WebBase.QS_SPORTID].ToString();
                    }
                }

                this.BindDDLEvent();

                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_EVENTID] != null)
                    {
                        ddlEvent.SelectedValue = Request.QueryString[WebBase.QS_EVENTID].ToString();
                    }
                }

                this.GetTeam();
                this.DGTeam();
            }
        }

        protected void DGTeam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgTeam.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            this.BindData();
        }

        protected void DGTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.TeamRow row = requestDS.Team.NewTeamRow();
            row.TeamID = Convert.ToInt32(dgTeam.DataKeys[e.RowIndex].Values[requestDS.Team.TeamIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Team.AddTeamRow(row);

            CompetitionClient svc = new CompetitionClient();
            svc.DeleteTeam(requestDS);

            this.GetTeam();
            this.BindData();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Competition/TeamDetails.aspx?PageMode=New");
        }

        protected void BindData()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
            dgTeam.DataSource = competitionDS.Team;
            dgTeam.DataBind();
        }

        protected void DGTeam()
        {
            WebBase.BindColumn(WebBase.GetCurrentMethod(), dgTeam);
            BindData();
        }

        protected void GetTeam()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS.TeamRow row = requestDS.Team.NewTeamRow();

            if (!string.IsNullOrEmpty(ddlEvent.SelectedValue))
                row.EventID = Convert.ToInt32(ddlEvent.SelectedValue);

            if (!string.IsNullOrEmpty(ddlSport.SelectedValue))
                row.SportID = Convert.ToInt32(ddlSport.SelectedValue);

            requestDS.Team.AddTeamRow(row);

            #region GetTeam
            responseDS = svc.GetTeam(requestDS);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
            #endregion
        }

        private void BindUIControl()
        {
            this.BindDDLSport();
            this.BindDDLEvent();
        }

        private void BindDDLSport()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS.SportRow row = requestDS.Sport.NewSportRow();
            requestDS.Sport.AddSportRow(row);

            responseDS = svc.GetSport(requestDS);

            ddlSport.Items.Add(new ListItem() { Text = string.Empty, Value = string.Empty });

            foreach (var dr in responseDS.Sport)
            {
                ddlSport.Items.Add(new ListItem() { Text = dr.SportName.Trim(), Value = dr.SportID.ToString() });
            }
        }

        private void BindDDLEvent()
        {
            ddlEvent.Items.Clear();

            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();
            if (!string.IsNullOrEmpty(ddlSport.SelectedValue))
            {
                row.SportID = Convert.ToInt32(ddlSport.SelectedValue);
            }

            requestDS.Event.AddEventRow(row);

            #region GetEventList
            responseDS = svc.GetEventList(requestDS);
            #endregion

            ddlEvent.DataSource = responseDS.Event;
            ddlEvent.DataTextField = responseDS.Event.EventNameColumn.ColumnName;
            ddlEvent.DataValueField = responseDS.Event.EventIDColumn.ColumnName; ;
            ddlEvent.DataBind();
        }

        protected void ddlSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindDDLEvent();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.GetTeam();
            this.BindData();
        }
    }
}