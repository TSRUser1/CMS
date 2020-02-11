using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Medal
{
    public partial class MultiMedallist : System.Web.UI.Page
    {
        private static int medalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                medalCount = 0;
                this.GetMultiMedallist();
                this.BindData();
                this.BindUIControl();
            }
        }
        protected void GetMultiMedallist()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.MultiMedallistRow row = requestDS.MultiMedallist.NewMultiMedallistRow();
            CompetitionDS.MedallistRow medalRow = requestDS.Medallist.NewMedallistRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null && Request.QueryString[WebBase.QS_SPORTID] != "")
                {
                    row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                    medalRow.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                }

                if (Request.QueryString[WebBase.QS_DATE] != null && Request.QueryString[WebBase.QS_DATE] != "")
                {
                    row.ScheduleDateTime = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                    medalRow.ScheduleDateTime = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                }

                if (Request.QueryString[WebBase.QS_COUNTRYID] != null && Request.QueryString[WebBase.QS_COUNTRYID] != "")
                {
                    row.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                    medalRow.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                }

                if (Request.QueryString[WebBase.QS_MEDAL] != null)
                {
                    row.MedalCode = Request.QueryString[WebBase.QS_MEDAL].ToString();
                    medalRow.MedalCode = Request.QueryString[WebBase.QS_MEDAL].ToString();
                }

                if (Request.QueryString[WebBase.QS_ISMULTI] != null && Request.QueryString[WebBase.QS_ISMULTI] != "")
                {
                    if(Convert.ToBoolean(Request.QueryString[WebBase.QS_ISMULTI]))
                    {
                        medalCount = 1;
                        lblMedallist.Text = "Multi-Medallists";
                    }
                }
            }

            #region GetMultiMedallist


            requestDS.MultiMedallist.AddMultiMedallistRow(row);
            responseDS = svc.GetMultiMedallist(requestDS);
            ViewState[WebBase.VS_MULTIMEDALLIST_DS] = responseDS.MultiMedallist;

            //if( medalCount > 0 )
            //{
            //    requestDS.MultiMedallist.AddMultiMedallistRow(row);
            //    responseDS = svc.GetMultiMedallist(requestDS);
            //    ViewState[WebBase.VS_MULTIMEDALLIST_DS] = responseDS.MultiMedallist;
            //}
            //else
            //{
            //    requestDS.Medallist.AddMedallistRow(medalRow);
            //    responseDS = svc.GetMedallist(requestDS);
            //    ViewState[WebBase.VS_MULTIMEDALLIST_DS] = responseDS.Medallist;
            //}
            #endregion
        }

        protected void BindData()
        {
            DataRow[] rows;

            CompetitionDS.MultiMedallistDataTable multiMedallistDT = new CompetitionDS.MultiMedallistDataTable();
            multiMedallistDT = (CompetitionDS.MultiMedallistDataTable)ViewState[WebBase.VS_MULTIMEDALLIST_DS];
            rows = multiMedallistDT.Where(a => a.Total > medalCount).OrderBy(b => b.Rank).ThenBy(c => c.FullName).ToArray();

            //if (medalCount > 0)
            //{
            //    CompetitionDS.MultiMedallistDataTable multiMedallistDT = new CompetitionDS.MultiMedallistDataTable();
            //    multiMedallistDT = (CompetitionDS.MultiMedallistDataTable)ViewState[WebBase.VS_MULTIMEDALLIST_DS];
            //    rows = multiMedallistDT.Where(a => a.Total > medalCount).OrderBy(b => b.Rank).ThenBy(c => c.FullName).ToArray();
            //}
            //else
            //{
            //    CompetitionDS.MedallistDataTable medallistDT = new CompetitionDS.MedallistDataTable();
            //    medallistDT = (CompetitionDS.MedallistDataTable)ViewState[WebBase.VS_MULTIMEDALLIST_DS];
            //    rows = medallistDT.OrderBy(c => c.ParticipantOrTeamName).ToArray();
            //}

            if (rows.Length > 0)
            {
                dgMedalStanding.DataSource = rows.CopyToDataTable();
            }
            else
            {
                dgMedalStanding.DataSource = rows;
            }
            
            dgMedalStanding.DataBind();
        }

        protected void dgMedalStanding_DataBound(object sender, EventArgs e)
        {
            dgMedalStanding.HeaderRow.TableSection = TableRowSection.TableHeader;

            for (int i = dgMedalStanding.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = dgMedalStanding.Rows[i];
                GridViewRow previousRow = dgMedalStanding.Rows[i - 1];

                HiddenField hidParticipantID = (HiddenField)row.Cells[1].FindControl("hidParticipantID");
                HiddenField previousHidParticipantID = (HiddenField)previousRow.Cells[1].FindControl("hidParticipantID");

                if (hidParticipantID.Value.Equals(previousHidParticipantID.Value))
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                            previousRow.Cells[1].RowSpan += 2;
                            previousRow.Cells[5].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                            previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                        row.Cells[1].Visible = false;
                        row.Cells[5].Visible = false;
                    }
                }
            }
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
        
    }
}