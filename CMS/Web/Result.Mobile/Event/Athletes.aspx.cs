using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.Event
{
    public partial class Athletes : System.Web.UI.Page
    {
        #region protected methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetEventAthletes();
                this.GetEvent();
                this.BindUIControl();
                this.BindEventAthletesData();
            }
        }

        #endregion

        #region private methods

        private void GetEventAthletes()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventAthletesRow row = requestDS.EventAthletes.NewEventAthletesRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                    
                    #region GetEventAthletes

                    requestDS.EventAthletes.AddEventAthletesRow(row);
                    responseDS = svc.GetEventAthletes(requestDS);

                    #endregion
                }
            }

            ViewState[WebBase.VS_EVENTATHLETES_DS] = responseDS.EventAthletes;
        }

        private void GetEvent()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);

                    #region GetEvent

                    requestDS.Event.AddEventRow(row);
                    responseDS = svc.GetEventDetails(requestDS);

                    #endregion
                }
            }

            ViewState[WebBase.VS_EVENT_DS] = responseDS.Event;
        }

        private void BindUIControl()
        {
            CompetitionDS.EventAthletesDataTable eventAthletesDT = new CompetitionDS.EventAthletesDataTable();
            eventAthletesDT = (CompetitionDS.EventAthletesDataTable)ViewState[WebBase.VS_EVENTATHLETES_DS];

            if (eventAthletesDT.Count > 0)
            {
                lblNumberOfEntries.Text = eventAthletesDT.Count.ToString();
            }
            else
            {
                lblNumberOfEntries.Text = "-";
            }

            CompetitionDS.EventDataTable eventDT = new CompetitionDS.EventDataTable();
            eventDT = (CompetitionDS.EventDataTable)ViewState[WebBase.VS_EVENT_DS];

            //if (eventDT.Count > 0)
            //{
            //    lblHeader.Text = eventDT[0].EventName;
            //}
            //else
            //{
            //    lblHeader.Text = string.Empty;
            //}
        }

        private void BindEventAthletesData()
        {
            CompetitionDS.EventAthletesDataTable eventAthletesDT = new CompetitionDS.EventAthletesDataTable();
            eventAthletesDT = (CompetitionDS.EventAthletesDataTable)ViewState[WebBase.VS_EVENTATHLETES_DS];
            listAthletes.DataSource = eventAthletesDT;
            listAthletes.DataBind();
        }

        #endregion

    }
}