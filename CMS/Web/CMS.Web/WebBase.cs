using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFAdministration;
using SEM.CMS.Web.WCFCompetition;
using SEM.CMS.Web.WCFSystemMaintenance;

namespace SEM.CMS.Web
{
    public class WebBase : System.Web.UI.Page
    {
        #region Public Variables

        #region Session string
        public const string SESSION_ADMINID = "AdminID";
        public const string SESSION_ADMINUSERNAME = "AdminUsername";
        public const string SESSION_ADMINDS = "AdminDS";
        public const string SESSION_ADMIN_SESSION_GUIDID = "SessionAdminSessionGUID";
        public const string SESSION_ACCESSSPORTS = "AccessSports";
        public const string SESSION_ACCESSPAGES = "AccessPages";
        public const string SESSION_CAPTCHACODE_LOGIN = "CaptchaCodeLogin";
        #endregion

        #region Query string
        public const string QS_SAMPLE_ID = "SampleID";
        public const string QS_PAGE_MODE = "PageMode";
        public const string QS_ADMINUSERID = "AdminUserID";
        public const string QS_ROLEID = "RoleID";
        public const string QS_SPORTID = "SportID";
        public const string QS_EVENTID = "EventID";
        public const string QS_SCHEDULEID = "ScheduleID";
        public const string QS_PARTICIPANTID = "ParticipantID";
        public const string QS_TEAMID = "TeamID";
        public const string QS_FILEPATH = "FilePath";
        public const string QS_ACTION = "Action";
        #endregion

        #region View states
        public const string VS_USERNAME = "ViewStateUsername";
        public const string VS_SPORTID = "ViewStateSportID";
        public const string VS_ADMIN_DS = "ViewStateAdminDS";
        public const string VS_EVENT_DS = "ViewStateEventDS";
        public const string VS_EVENTID = "ViewStateEventID";
        public const string VS_TEAMID = "ViewStateTeamID";
        public const string VS_SCHEDULEID = "ViewStateScheduleID";
        public const string VS_COMPETITION_DS = "ViewStateCompetitionDS";
        public const string VS_SYSTEMMAINTENANCE_DS = "ViewStateSystemMaintenanceDS";
        public const string VS_STARTLIST_DS = "ViewStateStartListDS";
        public const string VS_STARTLISTPARTICIPANT_DS = "ViewStateStartListParticipantDS";
        public const string VS_SCORE_DS = "ViewStateScoreDS";
        public const string VS_STATISTIC_DS = "ViewStateStatisticDS";
        public const string VS_SCORENAME_DS = "ViewStateScoreNameDS";
        public const string VS_STATISTICNAME_DS = "ViewStateStatisticNameDS";
        public const string VS_REDIRECTURL = "ViewStateRedirectUrl";
        public const string VS_SCHEDULEDETAIL_DS = "ViewStateScheduleDetailDS";
        public const string VS_REFEREE_DS = "ViewStateRefereeDS";
        public const string VS_PARTICIPANTINEVENT_DS = "ViewStateParticipantInEventDS";
        public const string VS_LEAGUE_DS = "ViewStateLeagueDS";
        public const string VS_FILEINEVENT_DT = "ViewStateFileInEventDT";
        public const string VS_PARTICIPANTINTEAM_DT = "ViewStateParticipantInTeamDT";
        public const string VS_PARTICIPANTINEVENT_DT = "ViewStateParticipantInEventDT";
        public const string VS_SPORTCLASS_DT = "ViewStateSportClassDT";
        #endregion

        #region Constants
        public const string DATETIME_FORMAT = "dd/MM/yyyy hh:mm tt";
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string TIME_FORMAT_HRS24 = "HH:mm";
        #endregion

        #region Cookies
        public const string CS_COUNTRYCOOKIES = "CS_COUNTRYCOOKIES";
        #endregion

        #region AppSetting
        public const string AS_TIMEZONE = "TimeZone";
        #endregion

        #region FilePath
        public const string PATH_XML_WEBPAGEINFO = "~/xml/WebPageInfo.xml";
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
                            if (row.ColumnWidth >= 0)
                            {
                                boundField.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            if (!row.IsNull("CssClass"))
                            {
                                boundField.ItemStyle.CssClass = row.CssClass; //##NOTE## CssClass cannot co-exist with other itemStyle attributes, CSS takes precedence
                                if (row.CssClass == "hide")
                                {
                                    boundField.HeaderStyle.CssClass = row.CssClass;
                                }
                            }
                            else
                            {
                                row.CssClass = "odd gradeX";
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
                            if (row.ColumnWidth >= 0)
                            {
                                hyperlink.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            if (!row.IsNull("CssClass"))
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
                            if (row.ColumnWidth >= 0)
                            {
                                checkbox.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            if (!row.IsNull("CssClass"))
                            {
                                checkbox.ItemStyle.CssClass = row.CssClass; //##NOTE## CssClass cannot co-exist with other itemStyle attributes, CSS takes precedence
                            }
                            grid.Columns.Add(checkbox);
                            break;
                        case ReferenceNum.DataColumnType.TextBox:
                            TemplateField textboxField = new TemplateField();
                            textboxField.HeaderText = row.HeaderText;
                            
                            if (row.ColumnWidth >= 0)
                            {
                                textboxField.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            if (!row.IsNull("CssClass"))
                            {
                                textboxField.ItemStyle.CssClass = row.CssClass;
                            }

                            grid.Columns.Add(textboxField);
                            break;
                        case ReferenceNum.DataColumnType.DropDown:
                            TemplateField dropdownField = new TemplateField();
                            dropdownField.HeaderText = row.HeaderText;

                            if (row.ColumnWidth >= 0)
                            {
                                dropdownField.ItemStyle.Width = Unit.Pixel(row.ColumnWidth);
                            }
                            if (!row.IsNull("CssClass"))
                            {
                                dropdownField.ItemStyle.CssClass = row.CssClass;
                            }

                            grid.Columns.Add(dropdownField);
                            break;
                    }
                }
            }
            #endregion
        }

        static void tb1_DataBinding(object sender, EventArgs e)
        {
            TextBox txtdata = (TextBox)sender;
            GridViewRow container = (GridViewRow)txtdata.NamingContainer;
            object dataValue = DataBinder.Eval(container.DataItem, txtdata.Text);
            if (dataValue != DBNull.Value)
            {
                txtdata.Text = dataValue.ToString();
            }
        }
        #endregion

        #region Admin_IsValidLoginSession
        public bool Admin_IsValidLoginSession(AdministrationDS reqDS)
        {
            bool isValid = false;
            AdministrationClient adminSVC = new AdministrationClient();
            AdministrationDS resDS = new AdministrationDS();
            resDS = adminSVC.GetAdminLoginSession(reqDS);

            if (resDS.AdminUser.Rows.Count != 0)
            {
                if (resDS.AdminUser[0].LoginSessionGUID == Session[SESSION_ADMIN_SESSION_GUIDID].ToString())
                {
                    isValid = true;
                }
            }

            return isValid;
        }
        #endregion

        #region IsValidModule
        public bool IsValidModule(HttpRequest request)
        {
            int sportID = 0, eventID = 0, scheduleID = 0;
            string sAccessSports = Session[WebBase.SESSION_ACCESSSPORTS].ToString();
            string sAccessPages = Session[WebBase.SESSION_ACCESSPAGES].ToString();

            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requesteDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            if (request.QueryString[WebBase.QS_SPORTID] != null)
            {
                sportID = Convert.ToInt32(request.QueryString[WebBase.QS_SPORTID]);
            }
            if (request.QueryString[WebBase.QS_EVENTID] != null)
            {
                eventID = Convert.ToInt32(request.QueryString[WebBase.QS_EVENTID]);
                CompetitionDS.EventRow eventRow = requesteDS.Event.NewEventRow();
                eventRow.EventID = eventID;
                requesteDS.Event.AddEventRow(eventRow);

                responseDS = svc.GetEventDetails(requesteDS);
                if (responseDS != null && responseDS.Event.Rows.Count > 0)
                {
                    sportID = responseDS.Event[0].SportID;
                }
            }
            if (request.QueryString[WebBase.QS_SCHEDULEID] != null)
            {
                scheduleID = Convert.ToInt32(request.QueryString[WebBase.QS_SCHEDULEID]);
                CompetitionDS.ScheduleDetailRow scheduleRow = requesteDS.ScheduleDetail.NewScheduleDetailRow();
                scheduleRow.ScheduleID = scheduleID;
                requesteDS.ScheduleDetail.AddScheduleDetailRow(scheduleRow);

                responseDS = svc.GetSchedule(requesteDS);
                if (responseDS != null && responseDS.ScheduleDetail.Rows.Count > 0)
                {
                    sportID = responseDS.ScheduleDetail[0].SportID;
                }
            }

            if (sportID != 0)
            {
                CompetitionDS.SportRow sportRow = requesteDS.Sport.NewSportRow();
                sportRow.SportID = sportID;
                requesteDS.Sport.AddSportRow(sportRow);

                responseDS = svc.GetSport(requesteDS);

                if (responseDS != null && responseDS.Sport.Rows.Count > 0)
                {
                    if (!sAccessSports.Contains("*") && !sAccessSports.ToUpper().Contains(responseDS.Sport[0].SportName.ToUpper()))
                    {
                        return false;
                    }
                }
            }


            if (request.Path != "/Index.aspx")
            {
                if (!sAccessPages.Contains(request.Path) && !sAccessPages.Contains("*"))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region IsCharacterNSpaceOnly
        public static bool IsCharacterNSpaceOnly(string validString)
        {
            foreach (char c in validString)
            {
                if (!char.IsLetter(c))
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region IsCharacterSpaceNApostropheOnly
        public static bool IsCharacterSpaceNApostropheOnly(string validString)
        {
            char apostrophe = '\'';

            foreach (char c in validString)
            {
                if (!char.IsLetter(c))
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        if (c != apostrophe)
                            return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region IsCharacterNDigitNSpaceOnly
        public static bool IsCharacterNDigitNSpaceOnly(string validString)
        {
            foreach (char c in validString)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region IsCharacterNDigitNPunctuationNSpaceOnly
        public static bool IsCharacterNDigitNPunctuationNSpaceOnly(string validString)
        {
            foreach (char c in validString)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    if (!char.IsPunctuation(c))
                    {
                        if (!char.IsWhiteSpace(c))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region IsDigit
        public static bool IsDigit(string validString)
        {
            foreach (char c in validString)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
            
        #endregion
    }
}