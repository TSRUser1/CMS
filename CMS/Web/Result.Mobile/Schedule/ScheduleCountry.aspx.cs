using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.Schedule
{
    public partial class ScheduleCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetScheduleHeader();
            }

            //the menu is dynamically created during run time
            //hence needs to be called at every postback
            this.BindMenuHeader();

            if (!IsPostBack)
            {
                this.SetInitialSelectedMenuItem();
                this.GetCountry();
                this.GetSchedule();
                this.BindUIControl();
                this.BindData();
                this.SetActiveMenu();

                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                    {
                        uscMedalStandings.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                    }
                }
            }
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

        protected void GetScheduleHeader()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleHeaderDateRow row = requestDS.ScheduleHeaderDate.NewScheduleHeaderDateRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                {
                    row.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                }
            }

            #region GetScheduleHeader

            requestDS.ScheduleHeaderDate.AddScheduleHeaderDateRow(row);
            responseDS = svc.GetScheduleHeaderGroupedByDateFilteredByCountry(requestDS);

            ViewState[WebBase.VS_SCHEDULEHEADER_DS] = responseDS.ScheduleHeaderDate;
            #endregion
        }

        protected void GetSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleListRow row = requestDS.ScheduleList.NewScheduleListRow();
            if (ViewState[WebBase.VS_SELECTEDITEM] != null)
            {
                if (!ViewState[WebBase.VS_SELECTEDITEM].ToString().Equals(WebBase.ALL))
                {
                    row.ScheduleDateTime = Convert.ToDateTime(ViewState[WebBase.VS_SELECTEDITEM]);
                }
            }

            if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
            {
                row.CountryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
            }
            
            requestDS.ScheduleList.AddScheduleListRow(row);

            #region GetScheduleList
            responseDS = svc.GetScheduleList(requestDS);

            ViewState[WebBase.VS_SCHEDULELIST_DS] = responseDS.ScheduleList;
            #endregion
        }

        protected void BindUIControl()
        {
            CompetitionDS.CountryDataTable countryDT = new CompetitionDS.CountryDataTable();
            countryDT = (CompetitionDS.CountryDataTable)ViewState[WebBase.VS_COUNTRY_DS];
            
            if (countryDT.Count > 0)
            {
                CompetitionDS.CountryRow row = countryDT.First();

                lblCountry.Text = row.CountryName;

                if (!row.IsIconFilePathNull())
                {
                    imgCountry.Visible = true;
                    imgCountry.ToolTip = row.CountryName;
                    imgCountry.AlternateText = row.CountryName;
                    imgCountry.ImageUrl = row.IconFilePath;
                }
                else
                {
                    imgCountry.Visible = false;
                }
            }
        }

        protected void BindMenuHeader()
        {
            CompetitionDS.ScheduleHeaderDateDataTable scheduleHeaderDateDT = new CompetitionDS.ScheduleHeaderDateDataTable();
            scheduleHeaderDateDT = (CompetitionDS.ScheduleHeaderDateDataTable)ViewState[WebBase.VS_SCHEDULEHEADER_DS];

            navTabs.Controls.Clear();

            foreach (CompetitionDS.ScheduleHeaderDateRow row in scheduleHeaderDateDT)
            {
                HtmlGenericControl newItem = new HtmlGenericControl("li");
                newItem.Attributes.Add("role", "presentation");

                if (row.IsMedalDate)
                {
                    newItem.Attributes.Add("data-is-highlight", "highlight");
                }

                HyperLink newLink = new HyperLink();
                newLink.ID = "lb" + row.Date;
                newLink.NavigateUrl = String.Format("../Schedule/ScheduleCountry.aspx?countryid={0}&date={1}", Request.QueryString[WebBase.QS_COUNTRYID], Convert.ToDateTime(row.Date).ToString("yyyy-MM-dd"));


                //newLink.CommandArgument = row.Date;
                //newLink.Click += menu_Click;

                //AsyncPostBackTrigger newTrigger = new AsyncPostBackTrigger();
                //newTrigger.ControlID = newLink.ID;
                //newTrigger.EventName = "Click";
                //updatePanelContent.Triggers.Add(newTrigger);

                HtmlGenericControl newSpanDay = new HtmlGenericControl("span");
                newSpanDay.Attributes.Add("class", "day");
                newSpanDay.InnerText = Convert.ToDateTime(row.Date).ToString("dd");

                HtmlGenericControl newSpanMonth = new HtmlGenericControl("span");
                newSpanMonth.Attributes.Add("class", "month");
                newSpanMonth.InnerText = Convert.ToDateTime(row.Date).ToString("MMM");

                newLink.Controls.Add(newSpanDay);
                newLink.Controls.Add(newSpanMonth);
                newItem.Controls.Add(newLink);
                navTabs.Controls.Add(newItem);
            }

            if (navTabs.Controls.Count > 0)
            {
                HtmlGenericControl newItem = new HtmlGenericControl("li");
                newItem.Attributes.Add("role", "presentation");

                HyperLink newLink = new HyperLink();
                newLink.ID = "lbAll";
                newLink.NavigateUrl = String.Format("../Schedule/ScheduleCountry.aspx?countryid={0}&date={1}", Request.QueryString[WebBase.QS_COUNTRYID], "All");
                //newLink.CommandArgument = WebBase.ALL;
                //newLink.Click += menu_Click;

                //AsyncPostBackTrigger newTrigger = new AsyncPostBackTrigger();
                //newTrigger.ControlID = newLink.ID;
                //newTrigger.EventName = "Click";
                //updatePanelContent.Triggers.Add(newTrigger);

                HtmlGenericControl newSpanDay = new HtmlGenericControl("span");
                newSpanDay.Attributes.Add("class", "day");
                newSpanDay.InnerText = "All";

                HtmlGenericControl newSpanMonth = new HtmlGenericControl("span");
                newSpanMonth.Attributes.Add("class", "month");
                newSpanMonth.InnerText = "Days";

                newLink.Controls.Add(newSpanDay);
                newLink.Controls.Add(newSpanMonth);
                newItem.Controls.Add(newLink);
                navTabs.Controls.Add(newItem);
            }

        }

        protected void SetInitialSelectedMenuItem()
        {
            CompetitionDS.ScheduleHeaderDateDataTable scheduleHeaderDateDT = new CompetitionDS.ScheduleHeaderDateDataTable();
            scheduleHeaderDateDT = (CompetitionDS.ScheduleHeaderDateDataTable)ViewState[WebBase.VS_SCHEDULEHEADER_DS];

            TimeZoneInfo singaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById(WebBase.TIMEZONE_SINGAPORE);
            DateTime singaporeDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, singaporeTimeZone);
            string time = String.Format(WebBase.DATE_yyyy_MM_dd_FORMAT, singaporeDateTime);

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_DATE] != null)
                {
                    string qsDate = Request.QueryString[WebBase.QS_DATE].ToString();

                    if (qsDate == "All")
                    {
                        ViewState[WebBase.VS_SELECTEDITEM] = WebBase.ALL;
                        return;
                    }
                    if (qsDate != string.Empty)
                    {
                        ViewState[WebBase.VS_SELECTEDITEM] = qsDate;
                        return;
                    }
                }
            }
                    
            if (scheduleHeaderDateDT.Rows.Count > 0)
            {
                CompetitionDS.ScheduleHeaderDateRow row = scheduleHeaderDateDT.FirstOrDefault(x => x.Date.Equals(time));

                if (row != null)
                {
                    ViewState[WebBase.VS_SELECTEDITEM] = row.Date;
                    return;
                }
            }

            if (scheduleHeaderDateDT.Rows.Count > 0)
            {
                ViewState[WebBase.VS_SELECTEDITEM] = WebBase.ALL;
            }
        }

        protected void BindData()
        {
            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];
            repeaterPanel.DataSource = scheduleListDT.GroupBy(a => a.SportID).Select(b => b.First()).OrderBy(c => c.SportName);
            repeaterPanel.DataBind();
        }

        protected void repeaterPanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
                scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

                HyperLink linkCollapse = (HyperLink)e.Item.FindControl("linkCollapse");
                Panel pnlCollapsible = (Panel)e.Item.FindControl("pnlCollapsible");
                linkCollapse.Attributes.Add("data-panel-id", pnlCollapsible.ClientID);

                HiddenField hidSportID = (HiddenField)e.Item.FindControl("hidSportID");

                GridView grid = (GridView)e.Item.FindControl("dgSchedule");

                DataRow[] rows = scheduleListDT.Where(a => a.SportID == Convert.ToInt32(hidSportID.Value)).OrderBy(b => b.ScheduleDateTime).ToArray();

                if (rows.Length > 0)
                {
                    grid.DataSource = rows.CopyToDataTable();
                }
                else
                {
                    grid.DataSource = rows;
                }
                grid.DataBind();
            }
        }

        protected void menu_Click(object sender, EventArgs e)
        {
            ViewState[WebBase.VS_SELECTEDITEM] = ((LinkButton)sender).CommandArgument;
            this.GetSchedule();
            this.BindData();
            this.SetActiveMenu();
        }

        private void SetActiveMenu()
        {
            if (ViewState[WebBase.VS_SELECTEDITEM] != null)
            {
                foreach (Control control in navTabs.Controls)
                {
                    HtmlGenericControl childControl = (HtmlGenericControl)control;
                    childControl.Attributes.Remove("class");

                    if (childControl.Attributes["data-is-highlight"] != null)
                    {
                        childControl.Attributes.Add("class", "highlight");
                    }
                }

                Control selectedItem = navTabs.FindControl("lb" + ViewState[WebBase.VS_SELECTEDITEM].ToString());

                if (selectedItem != null)
                {
                    HtmlGenericControl selectedParent = (HtmlGenericControl)selectedItem.Parent;
                    string cssClass = string.Empty;

                    if (selectedParent.Attributes["class"] != null)
                    {
                        cssClass = selectedParent.Attributes["class"].ToString();
                    }

                    selectedParent.Attributes.Add("class", String.IsNullOrEmpty(cssClass) ? "active" : cssClass + " active");
                }
            }
        }

        protected void dgSchedule_DataBound(object sender, EventArgs e)
        {
            if (((GridView)sender).HeaderRow != null)
            {
                ((GridView)sender).HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}