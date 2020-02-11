using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Medal
{
    public partial class Date : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindLabelHeader();

                this.GetMedalStandings();
                this.BindData();
            }
        }

        private void BindLabelHeader()
        {
            string header = "Medal Tally";

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                {
                    this.GetCountry();
                    CompetitionDS.CountryDataTable countryDT = new CompetitionDS.CountryDataTable();
                    countryDT = (CompetitionDS.CountryDataTable)ViewState[WebBase.VS_COUNTRY_DS];
                    if (countryDT.Rows.Count > 0)
                    {
                        header += " for " + countryDT[0].CountryName;

                        if (!countryDT[0].IsIconFilePathNull())
                        {
                            imgCountry.Visible = true;
                            imgCountry.ToolTip = countryDT[0].CountryName;
                            imgCountry.AlternateText = countryDT[0].CountryName;
                            imgCountry.ImageUrl = countryDT[0].IconFilePath;
                        }
                        else
                        {
                            imgCountry.Visible = false;
                        }
                    }
                }

                if (Request.QueryString[WebBase.QS_DATE] != null)
                {
                    ViewState[WebBase.VS_DATE] = Request.QueryString[WebBase.QS_DATE].ToString();

                    bool isDate = false;
                    DateTime date;

                    isDate = DateTime.TryParse(Request.QueryString[WebBase.QS_DATE], out date);

                    if (isDate)
                    {
                        string headerDate = date.ToString(WebBase.DATETIME_dd_MMM_yyyy_FORMAT);

                        if (header.Equals("Medal Tally"))
                        {
                            header += " " + headerDate;
                        }
                        else
                        {
                            header += " (" + headerDate + ")";
                        }
                    }
                }
            }

            lblHeader.Text = header;
        }

        protected void GetCountry()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.CountryRow row = requestDS.Country.NewCountryRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                {
                    row.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                }
            }

            #region GetCountry

            requestDS.Country.AddCountryRow(row);
            responseDS = svc.GetCountry(requestDS);

            ViewState[WebBase.VS_COUNTRY_DS] = responseDS.Country;
            #endregion
        }

        protected void GetMedalStandings()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.MedalStandingsCountryRow row = requestDS.MedalStandingsCountry.NewMedalStandingsCountryRow();

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

                if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                {
                    row.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                }
            }

            #region GetMedalStandings
            requestDS.MedalStandingsCountry.AddMedalStandingsCountryRow(row);
            responseDS = svc.GetMedalStandingsByCountry(requestDS);
            ViewState[WebBase.VS_MEDALSTANDINGS_DS] = responseDS.MedalStandingsCountry;
            #endregion

        }

        protected void BindData()
        {
            CompetitionDS.MedalStandingsCountryDataTable medalStandingsDT = new CompetitionDS.MedalStandingsCountryDataTable();
            medalStandingsDT = (CompetitionDS.MedalStandingsCountryDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_DS];
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
                CompetitionDS.MedalStandingsCountryDataTable medalStandingsDT = new CompetitionDS.MedalStandingsCountryDataTable();
                medalStandingsDT = (CompetitionDS.MedalStandingsCountryDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_DS];

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