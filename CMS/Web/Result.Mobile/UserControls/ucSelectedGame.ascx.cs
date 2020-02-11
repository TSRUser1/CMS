using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.UserControls
{
    public partial class ucSelectedGame : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    ViewState[WebBase.VS_SPORTID] = Request.QueryString[WebBase.QS_SPORTID];
                }
            }

            GetCurrentSportDetails();
            BindData();
        }

        protected void GetCurrentSportDetails()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.SportDetailsRow row = requestDS.SportDetails.NewSportDetailsRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (ViewState[WebBase.VS_EVENTID] != null)
                {
                    row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
                }

                if (ViewState[WebBase.VS_SCHEDULEID] != null)
                {
                    row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                }

                if (ViewState[WebBase.VS_SPORTID] != null)
                {
                    row.SportID = Convert.ToInt32(ViewState[WebBase.VS_SPORTID]);
                }
            }

            requestDS.SportDetails.AddSportDetailsRow(row);

            #region GetSportDetails
            responseDS = svc.GetSportDetails(requestDS);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS.SportDetails;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS.SportDetailsDataTable sportDetailsDT = new CompetitionDS.SportDetailsDataTable();
            sportDetailsDT = (CompetitionDS.SportDetailsDataTable)ViewState[WebBase.VS_COMPETITION_DS];

            if (sportDetailsDT.Count > 0)
            {
                CompetitionDS.SportDetailsRow row = sportDetailsDT[0];
                lblGame.Text = row.SportName;
                lblNumberAthletes.Text = row.ParticipantCount.ToString();
                imgGame.AlternateText = row.SportName;
                if (!row.IsStartEventNull() && !row.IsEndEventNull())
                {
                    lblGameDuration.Text = row.StartEvent.ToString("MMM dd") + " - " + row.EndEvent.ToString("MMM dd");
                }

                if (!row.IsImageFilePathNull())
                {
                    imgGame.ImageUrl = row.ImageFilePath.Replace(".png","_small.png");
                }                
            }
            
        }
    }
}