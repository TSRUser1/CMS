using SEM.CMS.CL.AR.Common;
using SEM.CMS.Result.Mobile.WCFCompetition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Result.Mobile.UserControls
{
    public partial class ucSubMenu : System.Web.UI.UserControl
    {
        bool IsEventSummary;
        protected void Page_Load(object sender, EventArgs e)
        {
            hlResult.NavigateUrl = "~/Event/Results.aspx?" + Request.QueryString.ToString();
            hlMedals.NavigateUrl = "~/Event/FinalRankings.aspx?" + Request.QueryString.ToString();
            hlAthletes.NavigateUrl = "~/Event/Athletes.aspx?" + Request.QueryString.ToString();

            hlRecords.NavigateUrl = "~/Event/Record.aspx?" + Request.QueryString.ToString();
            hlRecords.Visible = false;

            hlReports.NavigateUrl = "~/Event/Report.aspx?" + Request.QueryString.ToString();
            hlSummary.NavigateUrl = "~/Event/Summary.aspx?" + Request.QueryString.ToString();

            switch (Path.GetFileNameWithoutExtension(Request.Path))
            {
                case "Results":
                    IsEventSummary = false;
                    hlResult.CssClass = "selected";
                    break;
                case "FinalRankings":
                    IsEventSummary = true;
                    hlMedals.CssClass = "selected";
                    break;
                case "Athletes":
                    IsEventSummary = true;
                    hlAthletes.CssClass = "selected";
                    break;
                case "Records":
                    IsEventSummary = true;
                    hlRecords.CssClass = "selected";
                    break;
                case "Report":
                    IsEventSummary = true;
                    hlReports.CssClass = "selected";
                    break;
                case "Summary":
                    IsEventSummary = true;
                    hlSummary.CssClass = "selected";
                    break;
            }

            if (!IsPostBack)
            {
                if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
                {
                    ViewState[WebBase.VS_SCHEDULEID] = Request.QueryString[WebBase.QS_SCHEDULEID];
                }

                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    ViewState[WebBase.VS_EVENTID] = Request.QueryString[WebBase.QS_EVENTID];
                }

                GetSportEventSchedule();
                GetEventList();
            }

            BindData();
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

            #region GetSportEventSchedule
            responseDS = svc.GetSportEventSchedule(requestDS);

            if (responseDS.SportEventSchedule.Count > 0)
            {
                ViewState[WebBase.VS_SPORTID] = responseDS.SportEventSchedule[0].SportID;
                ViewState[WebBase.VS_GENDERID] = responseDS.SportEventSchedule[0].GenderID;
            }

            ViewState[WebBase.VS_SPORTEVENTSCHEDULE_DS] = responseDS;
            #endregion
        }

        protected void GetEventList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();

            // Get Sport ID
            if (ViewState[WebBase.VS_SPORTID] != null && ViewState[WebBase.VS_SPORTID].ToString() != string.Empty)
            {
                row.SportID = Convert.ToInt32(ViewState[WebBase.VS_SPORTID]);
            }

            requestDS.Event.AddEventRow(row);

            #region GetEventList
            responseDS = svc.GetEventList(requestDS);
            ViewState[WebBase.VS_EVENT_DS] = responseDS;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS competitionDS = new CompetitionDS();

            #region Schedule Details
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_SPORTEVENTSCHEDULE_DS];

            if (competitionDS != null && competitionDS.SportEventSchedule.Count > 0)
            {
                foreach (CompetitionDS.SportEventScheduleRow row in competitionDS.SportEventSchedule)
                {
                    if (ViewState[WebBase.VS_SCHEDULEID] != null && row.ScheduleID == Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]))
                    {
                        if (IsEventSummary)
                        {
                            lblScheduleName.Text = row.EventName;
                        }
                        else
                        {
                            lblScheduleName.Text = row.EventName + " - " + row.ScheduleName;
                        }

                    }

                    hlAthletes.Visible = row.IsShowAthelete;
                    hlMedals.Visible = row.IsShowMedal;
                    hlRecords.Visible = (row.IsShowRecord && row.HasRecord);
                    hlReports.Visible = row.IsShowReport;
                    hlResult.Visible = row.IsShowResult;
                    hlSummary.Visible = row.IsShowSummary;
                }
            }
            #endregion
        }
    }
}