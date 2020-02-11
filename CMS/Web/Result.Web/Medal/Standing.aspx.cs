using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Medal
{
    public partial class Standing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblHeader.Text = "Overall Medal Standings";
                
                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_SPORTID] != null)
                    {
                        this.GetCurrentSportDetails();

                        CompetitionDS.SportDetailsDataTable sportsDT = new CompetitionDS.SportDetailsDataTable();
                        sportsDT = (CompetitionDS.SportDetailsDataTable)ViewState[WebBase.VS_SPORT_DS];

                        if (sportsDT.Rows.Count > 0)
                        {
                            lblHeader.Text = "Medal Standings for " + sportsDT[0].SportName;
                        }
                        else
                        {
                            lblHeader.Text = string.Empty;
                        }

                        SelectedGame.Visible = true;
                        ViewState[WebBase.VS_SPORTID] = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                    }
                }

                this.BindUIControl();
                this.GetMedalStandings();
                this.BindData();

                if (!SelectedGame.Visible)
                {
                    Master.ControlVisible("divEventMenu", false);
                }
                else
                {
                    Master.ControlVisible("divEventMenu", true);
                }
            }
        }

        protected void GetCurrentSportDetails()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.SportDetailsRow row = requestDS.SportDetails.NewSportDetailsRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                }
            }

            requestDS.SportDetails.AddSportDetailsRow(row);

            #region GetSportDetails
            responseDS = svc.GetSportDetails(requestDS);
            ViewState[WebBase.VS_SPORT_DS] = responseDS.SportDetails;
            #endregion
        }

        protected void GetMedalStandings()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.MedalStandingsRow row = requestDS.MedalStandings.NewMedalStandingsRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                }

                if (Request.QueryString[WebBase.QS_DATE] != null)
                {
                    row.ScheduleDateTime = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                }
            }

            #region GetMedalStandings
            requestDS.MedalStandings.AddMedalStandingsRow(row);
            responseDS = svc.GetMedalStandings(requestDS);
            ViewState[WebBase.VS_MEDALSTANDINGS_DS] = responseDS.MedalStandings;
            #endregion
        }

        protected void BindUIControl()
        {
            this.BindDailyMedallists();
        }

        protected void BindDailyMedallists()
        {
            TimeZoneInfo singaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById(WebBase.TIMEZONE_SINGAPORE);
            DateTime singaporeDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, singaporeTimeZone);
            btnDailyMedallist.Attributes.Add("data-navigate-url", String.Format("/Medal/Medallist.aspx?PageMode=Daily&Date={0}", singaporeDateTime.ToString(WebBase.DATETIME_yyyy_MM_dd_FORMAT)));

#if(DEBUG)
            btnDailyMedallist.Attributes.Add("data-navigate-url", String.Format("/Medal/Medallist.aspx?PageMode=Daily&Date={0}", "2015-12-5"));
#endif
        }

        protected void BindData()
        {
            CompetitionDS.MedalStandingsDataTable medalStandingsDT = new CompetitionDS.MedalStandingsDataTable();
            medalStandingsDT = (CompetitionDS.MedalStandingsDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_DS];
            
            //calculate total sum of medals, to be used to hide ranking if all countries has no medals
            ViewState[WebBase.VS_MEDALSTANDINGS_TOTAL] = medalStandingsDT.Sum(item => item.Total);

            dgMedalStanding.DataSource = medalStandingsDT;
            dgMedalStanding.DataBind();
        }

        protected void dgMedalStanding_PreRender(object sender, EventArgs e)
        {
            dgMedalStanding.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void dgMedalStanding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                CompetitionDS.MedalStandingsDataTable medalStandingsDT = new CompetitionDS.MedalStandingsDataTable();
                medalStandingsDT = (CompetitionDS.MedalStandingsDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_DS];

                Label lblSumGold = (Label)e.Row.FindControl("lblSumGold");
                Label lblSumSilver = (Label)e.Row.FindControl("lblSumSilver");
                Label lblSumBronze = (Label)e.Row.FindControl("lblSumBronze");
                Label lblSumTotal = (Label)e.Row.FindControl("lblSumTotal");

                lblSumGold.Text = medalStandingsDT.Sum(item => item.GoldMedal).ToString();
                lblSumSilver.Text = medalStandingsDT.Sum(item => item.SilverMedal).ToString();
                lblSumBronze.Text = medalStandingsDT.Sum(item => item.BronzeMedal).ToString();
                lblSumTotal.Text = medalStandingsDT.Sum(item => item.Total).ToString();
            }
        }
    }
}