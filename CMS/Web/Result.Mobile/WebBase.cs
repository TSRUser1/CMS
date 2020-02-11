using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Result.Mobile.WCFSystemMaintenance;

namespace SEM.CMS.Result.Mobile
{
    public class WebBase
    {
        #region Public Variables

        #region Session string
        public const string SESSION_ADMINID = "AdminID";
        public const string SESSION_ADMINDS = "AdminDS";
        #endregion

        #region Query string
        public const string QS_SAMPLE_ID = "SampleID";
        public const string QS_PAGE_MODE = "PageMode";
        public const string QS_ADMINUSERID = "AdminUserID";
        public const string QS_SPORTID = "SportID";
        public const string QS_EVENTID = "EventID";
        public const string QS_FILENAME = "FileName";
        public const string QS_SCHEDULEID = "ScheduleID";
        public const string QS_ATHLETEID = "AthleteID";
        public const string QS_DATE = "Date";
        public const string QS_COUNTRYID = "CountryID";
        public const string QS_MEDAL = "Medal";
        public const string QS_ISMULTI = "IsMulti";
        public const string QS_TEAMID = "TeamID";
        #endregion

        #region View states
        public const string VS_USERNAME = "ViewStateUsername";
        public const string VS_SPORTID = "ViewStateSportID";
        public const string VS_SCHEDULEID = "ViewStateScheduleID";
        public const string VS_EVENTID = "ViewStateEventID";
        public const string VS_GENDERID = "ViewStateGenderID";
        public const string VS_ADMIN_DS = "ViewStateAdminDS";
        public const string VS_EVENT_DS = "ViewStateEventDS";
        public const string VS_COMPETITION_DS = "ViewStateCompetitionDS";
        public const string VS_SYSTEMMAINTENANCE_DS = "ViewStateSystemMaintenanceDS";
        public const string VS_GENERALSCHEDULE_DS = "ViewStateGeneralScheduleDS";
        public const string VS_SCHEDULEHEADER_DS = "ViewStateScheduleHeaderDS";
        public const string VS_SCHEDULELIST_DS = "ViewStateScheduleListDS";
        public const string VS_LIVESCHEDULELIST_DS = "ViewStateLiveScheduleListDS";
        public const string VS_SCHEDULEHEADERTYPE = "ViewStateScheduleHeaderType";
        public const string VS_SELECTEDITEM = "ViewStateSelectedItem";
        public const string VS_COUNTRY_DS = "ViewStateCountryDS";
        public const string VS_SPORT_DS = "ViewStateSportDS";
        public const string VS_PARTICIPANTLIST_DS = "ViewStateParticipantListDS";
        public const string VS_PARTICIPANTDETAIL_DS = "ViewStateParticipantDetailDS";
        public const string VS_PARTICIPANTRESULT_DS = "ViewStateParticipantResultDS";
        public const string VS_PARTICIPANTEVENT_DS = "ViewStateParticipantEventDS";
        public const string VS_PARTICIPANTSCHEDULE_DS = "ViewStateParticipantScheduleDS";
        public const string VS_FINALRANKINGS_DS = "ViewStateFinalRankingsDS";
        public const string VS_EVENTATHLETES_DS = "ViewStateEventAthletesDS";
        public const string VS_MEDALSTANDINGS_DS = "ViewStateMedalStandingDS";
        public const string VS_MEDALSTANDINGS_HEADER_DS = "ViewStateMedalStandingHeaderDS";
        public const string VS_MEDALSTANDINGS_TOTAL = "ViewStateMedalStandingTotal";
        public const string VS_MEDALLIST_DS = "ViewStateMedallistDS";
        public const string VS_MULTIMEDALLIST_DS = "ViewStateMultiMedallistDS";
        public const string VS_STARTLIST_DS = "ViewStateStartListDS";
        public const string VS_SCORE_DS = "ViewStateScoreDS";
        public const string VS_TEAMSCORE_DS = "ViewStateTeamScoreDS";
        public const string VS_SCORENAME_DS = "ViewStateScoreNameDS";
        public const string VS_STARTLISTNAME_DS = "ViewStateStartListNameDS";
        public const string VS_LATESTMEDALLIST_DS = "ViewStateLatestMedallistDS";
        public const string VS_REFEREE_DS = "ViewStateRefereeDS";
        public const string VS_STATISTICNAME_DS = "ViewStateStatisticNameDS";
        public const string VS_STATISTIC_DS = "ViewStateStatisticDS";
        public const string VS_KNOCKOUTSUMMARY_DS = "ViewStateKnockoutSummaryDS";
        public const string VS_LEAGUESUMMARY_DS = "ViewStateLeagueSummaryDS";
        public const string VS_LEAGUE_DS = "ViewStateLeagueDS";
        public const string VS_SPORTEVENTSCHEDULE_DS = "ViewStateSportEventScheduleDS";
        public const string VS_DATE = "ViewStateDate";
        #endregion

        #region Formats
        public const string DATETIME_FORMAT = "dd/MM/yyyy hh:mm tt";
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string DATETIME_dd_MMM_yyyy_FORMAT = "dd MMM yyyy";
        public const string DATETIME_yyyy_MM_dd_FORMAT = "yyyy-MM-dd";
        public const string DATETIME_dd_MMM_yyyy_hh_mm_FORMAT = "dd MMM yyyy HH:mm";
        public const string DATEMONTH_STRINGFORMAT = "{0:dd MMM}";
        public const string DATE_yyyy_MM_dd_FORMAT = "{0:yyyy-MM-dd}";
        public const string DATE_dd_MMM_yyyy_FORMAT = "{0:dd MMM yyyy}";
        #endregion

        #region TimeZone
        public const string TIMEZONE_SINGAPORE = "Singapore Standard Time";
        #endregion

        #region
        public const string ALL = "All";

        public const string DROPDOWNLIST_COUNTRY_ALL = "All Countries";
        public const string DROPDOWNLIST_COUNTRY_DATAFIELD = "CountryID";
        public const string DROPDOWNLIST_COUNTRY_TEXTFIELD = "CountryName";
        
        public const string DROPDOWNLIST_SPORT_ALL = "All Sports";
        public const string DROPDOWNLIST_SPORT_DATAFIELD = "SportID";
        public const string DROPDOWNLIST_SPORT_TEXTFIELD = "SportName";
        #endregion

        #region Cookies
        public const string CS_COUNTRYCOOKIES = "CS_COUNTRYCOOKIES";
        #endregion

        #region AppSetting
        public const string AS_TIMEZONE = "TimeZone";
        #endregion

        #region enums

        #region Schedule Header Type Enum
        public enum SCHEDULEHEADERTYPE
        {
            Sport = 1,
            Date = 2
        };
        #endregion

        #region Gender Enum
        public enum GENDER
        {
            Men = 1,
            Women = 2,
            Mixed = 3
        };
        #endregion


        #region drop down list values
        public enum DROPDOWNLISTVALUES
        {
            All = -1
        };

        #endregion

        #endregion

        #endregion

        #region Public Methods

        #region GetCurrentMethod
        [MethodImpl(MethodImplOptions.NoInlining)]
        static public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
        #endregion

        #region BindColumn
        static public void BindColumn(string dataGridName, GridView grid)
        {
            #region BoundColumn
            //Get data grid from DB
            SystemMaintenanceClient systemMaintenanceSVC = new SystemMaintenanceClient();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();

            ds = systemMaintenanceSVC.GetDataColumnByDataGridName(dataGridName);

            if (ds != null)
            {
                foreach (SystemMaintenanceDS.DataGridColumnRow row in ds.DataGridColumn)
                {
                    switch ((ReferenceNum.DataColumnType)Enum.Parse(typeof(ReferenceNum.DataColumnType), row.ColumnTypeID.ToString()))
                    {
                        case ReferenceNum.DataColumnType.Text:
                            BoundField boundField = new BoundField();
                            boundField.HeaderText = row.HeaderText;
                            boundField.DataField = row.DataField;
                            boundField.HtmlEncode = row.IsAllowHTMLEncode;
                            if (row.ColumnWidth != 0)
                            {
                                boundField.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            else
                            {
                                boundField.ItemStyle.CssClass = row.CssClass; //##NOTE## CssClass cannot co-exist with other itemStyle attributes, CSS takes precedence
                            }
                            if (row.IsReadOnly)
                            {
                                boundField.ReadOnly = true;
                            }
                            grid.Columns.Add(boundField);
                            break;
                        case ReferenceNum.DataColumnType.Hyperlink:
                            HyperLinkField hyperlink = new HyperLinkField();
                            hyperlink.HeaderText = row.HeaderText;
                            hyperlink.DataTextField = row.DataField;
                            if (row.ColumnWidth != 0)
                            {
                                hyperlink.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            else
                            {
                                hyperlink.ItemStyle.CssClass = row.CssClass; //##NOTE## CssClass cannot co-exist with other itemStyle attributes, CSS takes precedence
                            }
                            
                            string[] separator = { "," };
                            string[] urlFields = row.NavigateURLDataField.Split(separator, StringSplitOptions.None);
                            hyperlink.DataNavigateUrlFields = urlFields;
                            hyperlink.DataNavigateUrlFormatString = row.NavigateURL;
                            grid.Columns.Add(hyperlink);
                            break;
                        case ReferenceNum.DataColumnType.CheckBox:
                            CheckBoxField checkbox = new CheckBoxField();
                            checkbox.HeaderText = row.HeaderText;
                            checkbox.DataField = row.DataField;
                            if (row.ColumnWidth != 0)
                            {
                                checkbox.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            else
                            {
                                checkbox.ItemStyle.CssClass = row.CssClass; //##NOTE## CssClass cannot co-exist with other itemStyle attributes, CSS takes precedence
                            }
                            grid.Columns.Add(checkbox);
                            break;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region GridViewMergeRow
        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }
        public static void MergeRows(GridView gridView, int[] excludedColumns)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (excludedColumns.Contains(i))
                    {
                        continue;
                    }

                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}