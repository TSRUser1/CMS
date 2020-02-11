using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Medal
{
    public partial class Medallist : System.Web.UI.Page
    {
        private string currentSportName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_PAGE_MODE] != null)
                    {
                        if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString().Equals("Daily"))
                        {
                            lblHeader.Text = "Daily Medallists";
                            panelDate.Visible = true;
                            this.BindSelectedDate();
                        }
                    }
                }
                this.GetMedallist();
                this.BindData();
            }
        }

        private void GetMedallist()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.MedallistRow row = requestDS.Medallist.NewMedallistRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                }

                if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                {
                    row.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                }

                if (Request.QueryString[WebBase.QS_MEDAL] != null)
                {
                    row.MedalCode = Request.QueryString[WebBase.QS_MEDAL].ToString();
                }

                if (Request.QueryString[WebBase.QS_PAGE_MODE] != null)
                {
                    if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString().Equals("Daily"))
                    {
                        //pagetype = daily, take date from dropdownlist
                        if (!String.IsNullOrEmpty(ddlDate.SelectedItem.Text))
                        {
                            row.ScheduleDateTime = Convert.ToDateTime(ddlDate.SelectedItem.Text);
                        }
                    }
                }
                else
                {
                    //pagetype != daily, and date is passed in query string
                    if (Request.QueryString[WebBase.QS_DATE] != null)
                    {
                        row.ScheduleDateTime = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                    }
                }
            }

            #region GetMedallist
            requestDS.Medallist.AddMedallistRow(row);
            responseDS = svc.GetMedallist(requestDS);
            ViewState[WebBase.VS_MEDALLIST_DS] = responseDS.Medallist;
            #endregion
        }
        private void BindSelectedDate()
        {
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_DATE] != null)
                {
                    DateTime date;
                    if (DateTime.TryParse(Request.QueryString[WebBase.QS_DATE], out date))
                    {
                        ddlDate.SelectedValue = date.ToString(WebBase.DATETIME_yyyy_MM_dd_FORMAT);
                    }
                }
            }
        }

        private void BindData()
        {
            CompetitionDS.MedallistDataTable medallistDT = new CompetitionDS.MedallistDataTable();
            medallistDT = (CompetitionDS.MedallistDataTable)ViewState[WebBase.VS_MEDALLIST_DS];
            dgMedalStanding.DataSource = medallistDT;
            dgMedalStanding.DataBind();
        }

        protected void dgMedalStanding_DataBound(object sender, EventArgs e)
        {
            dgMedalStanding.HeaderRow.TableSection = TableRowSection.TableHeader;

            for (int i = dgMedalStanding.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = dgMedalStanding.Rows[i];
                GridViewRow previousRow = dgMedalStanding.Rows[i - 1];

                HiddenField hidEventID = (HiddenField)row.Cells[0].FindControl("hidEventID");
                HiddenField previousHidEventID = (HiddenField)previousRow.Cells[0].FindControl("hidEventID");

                if (hidEventID.Value.Equals(previousHidEventID.Value))
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }

            if (Request.QueryString[WebBase.QS_PAGE_MODE] != null)
            {
                if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString().Equals("Daily"))
                {
                    for (int i = 0; i < dgMedalStanding.Rows.Count; i++)
                    {
                        GridViewRow row = dgMedalStanding.Rows[i];
                        row.Cells[1].Visible = false;
                        row.Cells[2].ColumnSpan = 2;
                    }

                    dgMedalStanding.HeaderRow.Cells[1].Visible = false;
                    dgMedalStanding.HeaderRow.Cells[2].ColumnSpan = 2;
                }
            }
        }

        protected void dgMedalStanding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (currentSportName != dr["SportName"].ToString())
                {
                    currentSportName = dr["SportName"].ToString();

                    Table tbl = e.Row.Parent as Table;
                    if (tbl != null)
                    {
                        GridViewRow row = new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);
                        TableHeaderCell cell = new TableHeaderCell();

                        // Span the row across all of the columns in the Gridview
                        cell.ColumnSpan = this.dgMedalStanding.Columns.Count;

                        cell.Width = Unit.Percentage(100);
                        
                        Image sportImage = new Image();
                        sportImage.ImageUrl = dr["SportImageFilePath"].ToString().Replace(".png", "_small.png");
                        sportImage.AlternateText = currentSportName;
                        sportImage.ToolTip = currentSportName;
                        sportImage.CssClass = "sport-img";

                        cell.Controls.Add(sportImage);

                        HtmlGenericControl span = new HtmlGenericControl("span");
                        span.InnerHtml = currentSportName;

                        cell.Controls.Add(span);

                        row.Cells.Add(cell);

                        tbl.Rows.AddAt(tbl.Rows.Count - 1, row);
                    }
                }
            }
        }

        protected void dgMedalStanding_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;

                if (dr != null)
                { 
                    if (dr["ParticipantImageFilePath"] != DBNull.Value)
                    { 
                        e.Row.CssClass = "has-player-photo";
                    }
                }
            }
        }

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetMedallist();
            this.BindData();
        }
    }
}