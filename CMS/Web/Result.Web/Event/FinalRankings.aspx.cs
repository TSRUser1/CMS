using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;
using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Result.Web.Event
{
    public partial class FinalRankings : System.Web.UI.Page
    {
        #region protected methods

        protected bool IsTeamGame;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetEvent();
                this.BindUIControl();
                this.GetFinalRankings();
                this.BindData();
            }
        }

        protected void dgFinalRanking_PreRender(object sender, EventArgs e)
        {
            dgFinalRanking.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void dgFinalRanking_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (IsTeamGame)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Image img = (Image)e.Row.Cells[2].FindControl("imgParticipant");
                    img.Visible = false;
                }
            }
        }

        #endregion

        #region private methods
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
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                SelectedGame.Visible = true;
            }
            else
            {
                SelectedGame.Visible = false;
            }

            CompetitionDS.EventDataTable eventDT = new CompetitionDS.EventDataTable();
            eventDT = (CompetitionDS.EventDataTable)ViewState[WebBase.VS_EVENT_DS];
        }

        private void GetFinalRankings()
        {
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                CompetitionClient svc = new CompetitionClient();
                CompetitionDS responseDS = new CompetitionDS();

                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS.FinalRankingsRow row = requestDS.FinalRankings.NewFinalRankingsRow();

                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
                #region GetFinalRankings

                requestDS.FinalRankings.AddFinalRankingsRow(row);
                responseDS = svc.GetFinalRankings(requestDS);

                ViewState[WebBase.VS_FINALRANKINGS_DS] = responseDS.FinalRankings;
                #endregion
            }
            else
            {
                ViewState[WebBase.VS_FINALRANKINGS_DS] = new CompetitionDS.FinalRankingsDataTable();
            }
        }

        private void BindData()
        {
            CompetitionDS.FinalRankingsDataTable finalRankingsDT = new CompetitionDS.FinalRankingsDataTable();
            finalRankingsDT = (CompetitionDS.FinalRankingsDataTable)ViewState[WebBase.VS_FINALRANKINGS_DS];
            

            if (finalRankingsDT != null && finalRankingsDT.Count > 0)
            {
                if ((ReferenceNum.EventType)finalRankingsDT[0].EventTypeID == ReferenceNum.EventType.Individual)
                {
                    IsTeamGame = false;
                }
                else
                {
                    IsTeamGame = true;
                }
            }

            dgFinalRanking.DataSource = finalRankingsDT;
            dgFinalRanking.DataBind();
        }

        #endregion
    }
}