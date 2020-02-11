using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.UserControls
{
    public partial class uscMedalStandings : System.Web.UI.UserControl
    {
        
        public int? CountryID
        {
            get { return (int?)ViewState["CountryID"]; }
            set { ViewState["CountryID"] = value; }
        }
        public int? SportID
        {
            get { return (int?)ViewState["SportID"]; }
            set { ViewState["SportID"] = value; }
        }
        public DateTime? Date
        {
            get { return (DateTime?)ViewState["Date"]; }
            set { ViewState["Date"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CountryID.HasValue)
            {
                dgMedalStanding.Visible = true;
                dgMedalStandingCountry.Visible = false;

                if (this.SportID.HasValue)
                {
                    this.GetSportDetails();
                }   
            }
            else
            {
                dgMedalStanding.Visible = false;
                dgMedalStandingCountry.Visible = true;
                this.GetCountry();
            }

            if (!IsPostBack)
            {
                this.GetMedalStandings();
            }
            this.BindData();
        }

        private void GetMedalStandings()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();


            if (!this.CountryID.HasValue)
            {
                CompetitionDS.MedalStandingsRow row = requestDS.MedalStandings.NewMedalStandingsRow();

                if (this.SportID.HasValue)
                {
                    row.SportID = this.SportID.Value;
                }
                if (this.Date.HasValue)
                {
                    row.ScheduleDateTime = this.Date.Value;
                }

                #region GetMedalStandings
                requestDS.MedalStandings.AddMedalStandingsRow(row);
                responseDS = svc.GetMedalStandings(requestDS);
                ViewState[WebBase.VS_MEDALSTANDINGS_DS] = responseDS.MedalStandings;
                #endregion
            }
            else
            {
                CompetitionDS.MedalStandingsCountryRow countryRow = requestDS.MedalStandingsCountry.NewMedalStandingsCountryRow();

                countryRow.CountryID = this.CountryID.Value;
                if (this.SportID.HasValue)
                {
                    countryRow.SportID = this.SportID.Value;
                }
                if (this.Date.HasValue)
                {
                    countryRow.ScheduleDateTime = this.Date.Value;
                }

                #region GetMedalStandingsByCountry
                requestDS.MedalStandingsCountry.AddMedalStandingsCountryRow(countryRow);
                responseDS = svc.GetMedalStandingsByCountry(requestDS);
                ViewState[WebBase.VS_MEDALSTANDINGS_DS] = responseDS.MedalStandingsCountry;
                #endregion
            }
        }

        private void GetSportDetails()
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
            ViewState[WebBase.VS_MEDALSTANDINGS_HEADER_DS] = responseDS.SportDetails;
            #endregion
        }

        private void GetCountry()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.CountryRow countryRow = requestDS.Country.NewCountryRow();

            countryRow.CountryID = this.CountryID.Value;

            requestDS.Country.AddCountryRow(countryRow);

            #region GetCountry
            responseDS = svc.GetCountry(requestDS);
            ViewState[WebBase.VS_MEDALSTANDINGS_HEADER_DS] = responseDS.Country;
            #endregion
        }

        private void BindData()
        {
            if (!this.CountryID.HasValue)
            {
                CompetitionDS.MedalStandingsDataTable medalStandingsDT = new CompetitionDS.MedalStandingsDataTable();
                medalStandingsDT = (CompetitionDS.MedalStandingsDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_DS];
                
                //calculate total sum of medals, to be used to hide ranking if all countries has no medals
                ViewState[WebBase.VS_MEDALSTANDINGS_TOTAL] = medalStandingsDT.Sum(item => item.Total);

                dgMedalStanding.DataSource = medalStandingsDT;
                dgMedalStanding.DataBind();

                /*Create header row above generated header row*/

                //create row    
                GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                row.CssClass = "horizontal-header";

                if (!this.SportID.HasValue)
                { 
                    TableCell header1 = new TableHeaderCell();
                    header1.Text = "Rank";
                    row.Cells.Add(header1);

                    TableCell header2 = new TableHeaderCell();
                    header2.Text = "Country";
                    row.Cells.Add(header2);
                }
                else
                {
                    TableCell header2 = new TableHeaderCell();
                    header2.Text = "Country";
                    header2.ColumnSpan = 2;
                    row.Cells.Add(header2);
                }

                TableCell header3 = new TableHeaderCell();
                header3.Text = string.Empty;
                header3.CssClass = "text-center";

                Image goldImage = new Image();
                goldImage.ImageUrl = "~/img/medal/gold.png";
                goldImage.AlternateText = "Gold Medal";
                goldImage.ToolTip = "Gold Medal";

                header3.Controls.Add(goldImage);

                row.Cells.Add(header3);

                TableCell header4 = new TableHeaderCell();
                header4.Text = string.Empty;
                header4.CssClass = "text-center";

                Image silverImage = new Image();
                silverImage.ImageUrl = "~/img/medal/silver.png";
                silverImage.AlternateText = "Silver Medal";
                silverImage.ToolTip = "Silver Medal";

                header4.Controls.Add(silverImage);

                row.Cells.Add(header4);

                TableCell header5 = new TableHeaderCell();
                header5.Text = string.Empty;
                header5.CssClass = "text-center";

                Image bronzeImage = new Image();
                bronzeImage.ImageUrl = "~/img/medal/bronze.png";
                bronzeImage.AlternateText = "Bronze Medal";
                bronzeImage.ToolTip = "Bronze Medal";

                header5.Controls.Add(bronzeImage);

                row.Cells.Add(header5);

                TableCell header6 = new TableHeaderCell();
                header6.Text = "Total";
                header6.CssClass = "text-center";
                row.Cells.Add(header6);

                ((Table)dgMedalStanding.Controls[0]).Rows.AddAt(1, row);
            }
            else
            {
                CompetitionDS.MedalStandingsCountryDataTable medalStandingsDT = new CompetitionDS.MedalStandingsCountryDataTable();
                medalStandingsDT = (CompetitionDS.MedalStandingsCountryDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_DS];
                dgMedalStandingCountry.DataSource = medalStandingsDT;
                dgMedalStandingCountry.DataBind();

                /*Create header row above generated header row*/

                //create row    
                GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                row.CssClass = "horizontal-header";

                TableCell header1 = new TableHeaderCell();
                header1.Text = "Sport";
                header1.CssClass = "sport";
                row.Cells.Add(header1);

                TableCell header2 = new TableHeaderCell();
                header2.Text = string.Empty;
                header2.CssClass = "text-center";

                Image goldImage = new Image();
                goldImage.ImageUrl = "~/img/medal/gold.png";
                goldImage.AlternateText = "Gold Medal";
                goldImage.ToolTip = "Gold Medal";

                header2.Controls.Add(goldImage);

                row.Cells.Add(header2);

                TableCell header3 = new TableHeaderCell();
                header3.Text = string.Empty;
                header3.CssClass = "text-center";

                Image silverImage = new Image();
                silverImage.ImageUrl = "~/img/medal/silver.png";
                silverImage.AlternateText = "Silver Medal";
                silverImage.ToolTip = "Silver Medal";

                header3.Controls.Add(silverImage);

                row.Cells.Add(header3);

                TableCell header4 = new TableHeaderCell();
                header4.Text = string.Empty;
                header4.CssClass = "text-center";

                Image bronzeImage = new Image();
                bronzeImage.ImageUrl = "~/img/medal/bronze.png";
                bronzeImage.AlternateText = "Bronze Medal";
                bronzeImage.ToolTip = "Bronze Medal";

                header4.Controls.Add(bronzeImage);

                row.Cells.Add(header4);

                TableCell header5 = new TableHeaderCell();
                header5.Text = "Total";
                header5.CssClass = "text-center";
                row.Cells.Add(header5);

                ((Table)dgMedalStandingCountry.Controls[0]).Rows.AddAt(1, row);
            }
        }

        public void Bind()
        {
            this.GetMedalStandings();
            this.BindData();
        }
        protected void dgMedalStanding_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].ColumnSpan = 6;
                e.Row.Cells.RemoveAt(5);
                e.Row.Cells.RemoveAt(4);
                e.Row.Cells.RemoveAt(3);
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.RemoveAt(1);
                
                if (this.SportID.HasValue)
                {
                    CompetitionDS.SportDetailsDataTable medalStandingsHeaderDT = new CompetitionDS.SportDetailsDataTable();
                    medalStandingsHeaderDT = (CompetitionDS.SportDetailsDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_HEADER_DS];

                    if (medalStandingsHeaderDT.Rows.Count > 0)
                    {
                        Label lblMedalStandingHeader = (Label)e.Row.FindControl("lblMedalStandingHeader");
                        lblMedalStandingHeader.Visible = true;

                        if (!medalStandingsHeaderDT[0].IsSportNameNull())
                        {
                            lblMedalStandingHeader.Text = medalStandingsHeaderDT[0].SportName;
                        }
                        else
                        {
                            lblMedalStandingHeader.Text = string.Empty;
                        }
                    }
                }
                else if (this.Date.HasValue)
                {
                    Label lblMedalStandingHeader = (Label)e.Row.FindControl("lblMedalStandingHeader");
                    lblMedalStandingHeader.Visible = true;

                    lblMedalStandingHeader.Text = this.Date.Value.ToString("dd MMM yyyy");
                }
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.CssClass = "bottom-line-2px";

                if (this.SportID.HasValue)
                {
                    e.Row.Cells[1].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(0);
                }
            }
        }

        protected void dgMedalStanding_PreRender(object sender, EventArgs e)
        {
            dgMedalStanding.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void dgMedalStandingCountry_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].ColumnSpan = 4;
                //e.Row.Cells.RemoveAt(3);
                //e.Row.Cells.RemoveAt(2);
                //e.Row.Cells.RemoveAt(1);
                e.Row.Cells[0].ColumnSpan = 5;
                e.Row.Cells.RemoveAt(4);
                e.Row.Cells.RemoveAt(3);
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.RemoveAt(1);

                CompetitionDS.CountryDataTable medalStandingsHeaderDT = new CompetitionDS.CountryDataTable();
                medalStandingsHeaderDT = (CompetitionDS.CountryDataTable)ViewState[WebBase.VS_MEDALSTANDINGS_HEADER_DS];

                if (medalStandingsHeaderDT.Rows.Count > 0)
                {                    
                    Label lblHeaderCountry = (Label)e.Row.FindControl("lblHeaderCountry");
                    lblHeaderCountry.Visible = true;

                    if (!medalStandingsHeaderDT[0].IsCountryNameNull())
                    {
                        lblHeaderCountry.Text = medalStandingsHeaderDT[0].CountryName;
                    }
                    else
                    {
                        lblHeaderCountry.Text = string.Empty;
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.CssClass = "bottom-line-2px";
            }
        }

        protected void dgMedalStandingCountry_PreRender(object sender, EventArgs e)
        {
            dgMedalStandingCountry.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}