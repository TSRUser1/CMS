using SEM.CMS.Result.Web.WCFCompetition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Result.Web.Athletes
{
    public partial class TeamBiography : System.Web.UI.Page
    {

        #region protected methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_TEAMID] != null)
                    {
                        GetTeam();
                        GetTeamDetailAndResult();
                        BindData();
                    }
                }
            }
        }

        protected void BindData()
        {
            CompetitionDS response = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
            dgTeam.DataSource = response.TeamBiography;
            dgTeam.DataBind();

            this.BindTeamResultAndScheduleData();
        }

        protected void rptEvent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink linkCollapse = (HyperLink)e.Item.FindControl("linkCollapse");
                Panel panelEvent = (Panel)e.Item.FindControl("panelEvent");
                linkCollapse.Attributes.Add("data-panel-id", panelEvent.ClientID);

                CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
                scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

                HiddenField hidScheduleDate = (HiddenField)e.Item.FindControl("hidScheduleDate");
                GridView grid = (GridView)e.Item.FindControl("dgParticipantSchedule");

                DataRow[] rows = scheduleListDT.Where(a => a.ScheduleDate.Equals(hidScheduleDate.Value)).ToArray();

                if (rows.Length > 0)
                {
                    grid.DataSource = rows.CopyToDataTable();
                }
                else
                {
                    grid.DataSource = rows;
                }
                grid.DataBind();
            }
        }

        protected void dgParticipantSchedule_DataBound(object sender, EventArgs e)
        {
            if (((GridView)sender).HeaderRow != null)
            {
                ((GridView)sender).HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GetTeam()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.TeamBiographyRow row = requestDS.TeamBiography.NewTeamBiographyRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_TEAMID] != null)
                {
                    row.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
                }
            }
            requestDS.TeamBiography.AddTeamBiographyRow(row);

            #region GetTeamBiography
            responseDS = svc.GetTeamBiography(requestDS);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
            #endregion

            if (responseDS.TeamBiography.Rows.Count > 0)
            {
                CompetitionDS.TeamBiographyRow rowteam = responseDS.TeamBiography[0];
                if (rowteam.IsBigCountryImageNull())
                {
                    imgCountry.ImageUrl = "";
                }
                else
                {
                    imgCountry.ImageUrl = rowteam.BigCountryImage;
                }
                if (rowteam.IsCountryIDNull())
                {
                    linkCountryImage.Enabled = false;
                    linkCountryLabel.Enabled = false;
                }
                else
                {
                    linkCountryImage.Enabled = true;
                    linkCountryImage.NavigateUrl = "~/Schedule/ScheduleCountry.aspx?CountryID=" + rowteam.CountryID.ToString();
                    linkCountryLabel.Enabled = true;
                    linkCountryLabel.NavigateUrl = "~/Schedule/ScheduleCountry.aspx?CountryID=" + rowteam.CountryID.ToString();
                }
                if (rowteam.IsCountryNameNull())
                {
                    lblNPC.Text = "-";
                    imgCountry.AlternateText = String.Empty;
                    imgCountry.ToolTip = String.Empty;
                }
                else
                {
                    lblNPC.Text = rowteam.CountryName;
                    imgCountry.AlternateText = rowteam.CountryName;
                    imgCountry.ToolTip = rowteam.CountryName;
                }
            }
            
        }

        protected void dgTeamEventMedal_PreRender(object sender, EventArgs e)
        {
            if (dgTeamEventMedal.HeaderRow != null)
            {
                dgTeamEventMedal.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void dgTeam_PreRender(object sender, EventArgs e)
        {
            if (dgTeam.HeaderRow != null)
            {
                dgTeam.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        #endregion

        #region private methods
        private void BindTeamResultAndScheduleData()
        {
            CompetitionDS.ParticipantEventDataTable participantEventDT = new CompetitionDS.ParticipantEventDataTable();
            participantEventDT = (CompetitionDS.ParticipantEventDataTable)ViewState[WebBase.VS_PARTICIPANTEVENT_DS];

            IEnumerable<CompetitionDS.ParticipantEventRow> result = from tb in participantEventDT
                                                                    where tb.ResultPosition > 0
                                                                    select tb;

            if (result.Count() > 0)
            {
                CompetitionDS.ParticipantEventDataTable dataTable = new CompetitionDS.ParticipantEventDataTable();
                dataTable.Merge(result.CopyToDataTable<CompetitionDS.ParticipantEventRow>());
                dgTeamEventMedal.DataSource = dataTable;
            }
            else
            {
                dgTeamEventMedal.DataSource = participantEventDT;
            }
            dgTeamEventMedal.DataBind();

            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

            DataRow[] rows = scheduleListDT.GroupBy(a => a.ScheduleDate).Select(b => b.First()).ToArray();

            if (rows.Length > 0)
            {
                rptEvent.DataSource = rows.CopyToDataTable();
            }
            else
            {
                rptEvent.DataSource = rows;
            }

            rptEvent.DataBind();
        }

        private void GetTeamDetailAndResult()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.ParticipantEventRow participantEventRow = requestDS.ParticipantEvent.NewParticipantEventRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_TEAMID] != null)
                {
                    participantEventRow.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
                }
            }
            requestDS.ParticipantEvent.AddParticipantEventRow(participantEventRow);

            #region GetParticipantResult
            responseDS = svc.GetTeamEvent(requestDS);

            ViewState[WebBase.VS_PARTICIPANTEVENT_DS] = responseDS.ParticipantEvent;
            #endregion

            CompetitionDS.ScheduleListRow scheduleListRow = requestDS.ScheduleList.NewScheduleListRow();
            scheduleListRow.TeamID = Convert.ToInt32(Request.QueryString[WebBase.QS_TEAMID]);
            requestDS.ScheduleList.AddScheduleListRow(scheduleListRow);
            #region GetScheduleList
            responseDS = svc.GetScheduleList(requestDS);

            responseDS.ScheduleList.AcceptChanges();
            ViewState[WebBase.VS_SCHEDULELIST_DS] = responseDS.ScheduleList;
            #endregion
        }
        #endregion
    }
}