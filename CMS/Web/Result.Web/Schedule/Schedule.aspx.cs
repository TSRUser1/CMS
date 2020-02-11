using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Schedule
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_SPORTID] != null)
                    {
                        this.GetPageHeader();
                        uscMedalStandings.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                    }
                    else if (Request.QueryString[WebBase.QS_DATE] != null)
                    {
                        uscMedalStandings.Date = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                    }
                }
                this.BindPageHeader();
                this.GetScheduleHeader();
            }

            //the menu is dynamically created during run time
            //hence needs to be called at every postback
            this.BindMenuHeader();

            if (!IsPostBack)
            {
                this.SetInitialSelectedMenuItem();
                this.GetSchedule();
                this.BindData();
                this.SetActiveMenu();
                this.BindGender();
            }
        }

        protected void GetPageHeader()
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
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS.SportDetails;
            #endregion
        }

        protected void GetScheduleHeader()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleHeaderSportRow sportRow = requestDS.ScheduleHeaderSport.NewScheduleHeaderSportRow();
            CompetitionDS.ScheduleHeaderDateRow dateRow = requestDS.ScheduleHeaderDate.NewScheduleHeaderDateRow();

            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    dateRow.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                    //set header type as sport
                    ViewState[WebBase.VS_SCHEDULEHEADERTYPE] = WebBase.SCHEDULEHEADERTYPE.Date;
                }
                else if (Request.QueryString[WebBase.QS_DATE] != null)
                {
                    sportRow.Date = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                    //set header type to date
                    ViewState[WebBase.VS_SCHEDULEHEADERTYPE] = WebBase.SCHEDULEHEADERTYPE.Sport;
                }
            }

            #region GetScheduleHeader
            if (ViewState[WebBase.VS_SCHEDULEHEADERTYPE] != null)
            {
                switch ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]))
                {
                    case WebBase.SCHEDULEHEADERTYPE.Date:
                        requestDS.ScheduleHeaderDate.AddScheduleHeaderDateRow(dateRow);
                        responseDS = svc.GetScheduleHeaderGroupedByDateFilteredBySport(requestDS);

                        ViewState[WebBase.VS_SCHEDULEHEADER_DS] = responseDS.ScheduleHeaderDate;
                        break;
                    case WebBase.SCHEDULEHEADERTYPE.Sport:
                        requestDS.ScheduleHeaderSport.AddScheduleHeaderSportRow(sportRow);
                        responseDS = svc.GetScheduleHeaderGroupedBySportFilteredByDate(requestDS);

                        ViewState[WebBase.VS_SCHEDULEHEADER_DS] = responseDS.ScheduleHeaderSport;
                        break;
                }
            }
            #endregion
        }

        protected void BindPageHeader()
        {
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    panelSport.Visible = true;

                    CompetitionDS.SportDetailsDataTable sportDetailsDT = new CompetitionDS.SportDetailsDataTable();
                    sportDetailsDT = (CompetitionDS.SportDetailsDataTable)ViewState[WebBase.VS_COMPETITION_DS];

                    if (sportDetailsDT.Count > 0)
                    {
                        CompetitionDS.SportDetailsRow row = sportDetailsDT[0];
                        lblHeader.Text = row.SportName;
                        imgSport.AlternateText = row.SportName;
                        imgSport.ToolTip = row.SportName;

                        if (!row.IsImageFilePathNull())
                        {
                            imgSport.ImageUrl = row.ImageFilePath.Replace(".png", "_small.png");
                        }
                        else
                        {
                            imgSport.ImageUrl = string.Empty;
                        }
                    }
                }
                else if (Request.QueryString[WebBase.QS_DATE] != null)
                {
                    lblHeader.Text = "Schedule (" + Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]).ToString("dd MMM yyyy") + ")";
                }
            }
        }

        protected void GetSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleListRow row = requestDS.ScheduleList.NewScheduleListRow();
            if (ViewState[WebBase.VS_SCHEDULEHEADERTYPE] != null && ViewState[WebBase.VS_SELECTEDITEM] != null)
            {
                switch ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]))
                {
                    case WebBase.SCHEDULEHEADERTYPE.Date:
                        DateTime date;

                        if (DateTime.TryParse(ViewState[WebBase.VS_SELECTEDITEM].ToString(), out date))
                        {
                            row.ScheduleDateTime = date;
                        }
                        row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                        break;
                    case WebBase.SCHEDULEHEADERTYPE.Sport:
                        int sportID;

                        if (Int32.TryParse(ViewState[WebBase.VS_SELECTEDITEM].ToString(), out sportID))
                        {
                            row.SportID = sportID;
                        }
                        row.ScheduleDateTime = Convert.ToDateTime(Request.QueryString[WebBase.QS_DATE]);
                        break;
                }

                requestDS.ScheduleList.AddScheduleListRow(row);

                #region GetScheduleList
                responseDS = svc.GetScheduleList(requestDS);
                ViewState[WebBase.VS_SCHEDULELIST_DS] = responseDS.ScheduleList;
                #endregion
            }
            else
            {
                ViewState[WebBase.VS_SCHEDULELIST_DS] = responseDS.ScheduleList;
            }
        }

        protected void BindMenuHeader()
        {
            if (ViewState[WebBase.VS_SCHEDULEHEADERTYPE] != null)
            {
                switch ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]))
                {
                    case WebBase.SCHEDULEHEADERTYPE.Date:

                        lblScheduleHeader.Visible = false;
                        section.Attributes.Add("class", "sport-overview");
                        navTabs.Controls.Clear();

                        CompetitionDS.ScheduleHeaderDateDataTable scheduleHeaderDateDT = new CompetitionDS.ScheduleHeaderDateDataTable();
                        scheduleHeaderDateDT = (CompetitionDS.ScheduleHeaderDateDataTable)ViewState[WebBase.VS_SCHEDULEHEADER_DS];

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
                            //newLink.CommandArgument = row.Date;
                            newLink.NavigateUrl = String.Format("../Schedule/Schedule.aspx?sportid={0}&date={1}", Request.QueryString[WebBase.QS_SPORTID], Convert.ToDateTime(row.Date).ToString("yyyy-MM-dd"));

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
                            //newLink.CommandArgument = WebBase.ALL;
                            //newLink.Click += menu_Click;
                            newLink.NavigateUrl = String.Format("../Schedule/Schedule.aspx?sportid={0}&date={1}", Request.QueryString[WebBase.QS_SPORTID], "All");


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

                        break;
                    case WebBase.SCHEDULEHEADERTYPE.Sport:
                        section.Attributes.Add("class", "sport-overview-tab2");
                        //SelectedGame.Visible = false;
                        navTabs.Controls.Clear();

                        CompetitionDS.ScheduleHeaderSportDataTable scheduleHeaderSportDT = new CompetitionDS.ScheduleHeaderSportDataTable();
                        scheduleHeaderSportDT = (CompetitionDS.ScheduleHeaderSportDataTable)ViewState[WebBase.VS_SCHEDULEHEADER_DS];

                        foreach (CompetitionDS.ScheduleHeaderSportRow row in scheduleHeaderSportDT)
                        {
                            HtmlGenericControl newItem = new HtmlGenericControl("li");
                            newItem.Attributes.Add("role", "presentation");

                            HyperLink newLink = new HyperLink();
                            newLink.ID = "lb" + row.SportID;
                            newLink.CssClass = "link-sport";
                            //newLink.Text = row.SportName.Substring(0, 2);
                            //newLink.CommandArgument = row.SportID.ToString();
                            //newLink.Click += menu_Click;
                            newLink.NavigateUrl = String.Format("../Schedule/Schedule.aspx?date={0}&selectedsportid={1}", Request.QueryString[WebBase.QS_DATE], row.SportID);



                            //AsyncPostBackTrigger newTrigger = new AsyncPostBackTrigger();
                            //newTrigger.ControlID = newLink.ID;
                            //newTrigger.EventName = "Click";
                            //updatePanelContent.Triggers.Add(newTrigger);

                            Image imgSport = new Image();
                            //imgSport.ImageUrl = row.ImageFilePath.Replace(".png", "_small.png");
                            imgSport.ImageUrl = row.ImageFilePath.Replace("_small.png", ".png");
                            imgSport.AlternateText = row.SportName;
                            imgSport.ToolTip = row.SportName;
                            imgSport.CssClass = "menu-sport";

                            newLink.Controls.Add(imgSport);
                            newItem.Controls.Add(newLink);
                            navTabs.Controls.Add(newItem);
                        }


                        if (navTabs.Controls.Count > 0)
                        {
                            HtmlGenericControl newItem = new HtmlGenericControl("li");
                            newItem.Attributes.Add("role", "presentation");

                            HyperLink newLink = new HyperLink();
                            newLink.ID = "lbAll";
                            newLink.Text = "All";
                            newLink.CssClass = "link-sport-all";
                            //newLink.CommandArgument = WebBase.ALL;
                            //newLink.Click += menu_Click;
                            newLink.NavigateUrl = String.Format("../Schedule/Schedule.aspx?date={0}&selectedsportid={1}", Request.QueryString[WebBase.QS_DATE], "All");


                            AsyncPostBackTrigger newTrigger = new AsyncPostBackTrigger();
                            newTrigger.ControlID = newLink.ID;
                            newTrigger.EventName = "Click";
                            //updatePanelContent.Triggers.Add(newTrigger);

                            newItem.Controls.Add(newLink);
                            navTabs.Controls.Add(newItem);
                        }

                        break;
                }
            }
        }

        protected void SetInitialSelectedMenuItem()
        {
            if (ViewState[WebBase.VS_SCHEDULEHEADERTYPE] != null)
            {
                switch ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]))
                {
                    case WebBase.SCHEDULEHEADERTYPE.Date:

                        CompetitionDS.ScheduleHeaderDateDataTable scheduleHeaderDateDT = new CompetitionDS.ScheduleHeaderDateDataTable();
                        scheduleHeaderDateDT = (CompetitionDS.ScheduleHeaderDateDataTable)ViewState[WebBase.VS_SCHEDULEHEADER_DS];

                        //if header is by date, and date is passed as querystring,
                        //set selected date = date passed by querystring
                        //if date passed by querystring is not in the header, get local time in sg and set selected date as sg current date
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
                                else if (scheduleHeaderDateDT.Rows.Count > 0)
                                {
                                    CompetitionDS.ScheduleHeaderDateRow row = scheduleHeaderDateDT.FirstOrDefault(x => x.Date.Equals(qsDate));

                                    if (row != null)
                                    {
                                        ViewState[WebBase.VS_SELECTEDITEM] = row.Date;
                                        return;
                                    }
                                }
                            }
                        }

                        TimeZoneInfo singaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById(WebBase.TIMEZONE_SINGAPORE);
                        DateTime singaporeDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, singaporeTimeZone);
                        string time = String.Format(WebBase.DATE_yyyy_MM_dd_FORMAT, singaporeDateTime);

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
                        break;
                    case WebBase.SCHEDULEHEADERTYPE.Sport:

                        CompetitionDS.ScheduleHeaderSportDataTable scheduleHeaderSportDT = new CompetitionDS.ScheduleHeaderSportDataTable();
                        scheduleHeaderSportDT = (CompetitionDS.ScheduleHeaderSportDataTable)ViewState[WebBase.VS_SCHEDULEHEADER_DS];


                        if (Request.QueryString["selectedsportid"] != null)
                        {
                            ViewState[WebBase.VS_SELECTEDITEM] = Request.QueryString["selectedsportid"].ToString();
                        }
                        else if (scheduleHeaderSportDT.Rows.Count > 0)
                        {
                            ViewState[WebBase.VS_SELECTEDITEM] = WebBase.ALL;
                        }
                        break;
                }
            }
        }

        protected void BindData()
        {
            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

            if (ViewState[WebBase.VS_SELECTEDITEM] != null && ViewState[WebBase.VS_SELECTEDITEM].ToString().Equals(WebBase.ALL))
            {
                if ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]) == WebBase.SCHEDULEHEADERTYPE.Sport)
                {
                    repeaterPanel.Visible = true;
                    dgSchedule.Visible = false;
                    repeaterPanel.DataSource = scheduleListDT.GroupBy(a => a.SportID).Select(b => b.First()).OrderBy(c => c.SportName);
                    repeaterPanel.DataBind();
                }
                else if ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]) == WebBase.SCHEDULEHEADERTYPE.Date)
                {
                    repeaterPanel.Visible = true;
                    dgSchedule.Visible = false;
                    repeaterPanel.DataSource = scheduleListDT.GroupBy(a => a.ScheduleDate).Select(b => b.First()).OrderBy(c => c.ScheduleDate);
                    repeaterPanel.DataBind();
                }
            }
            else if (scheduleListDT != null)
            {
                repeaterPanel.Visible = false;
                dgSchedule.Visible = true;
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    scheduleListDT.DefaultView.RowFilter = "EventID=" + Request.QueryString[WebBase.QS_EVENTID];
                    lblScheduleHeader.Text = scheduleListDT.FirstOrDefault().SportName;
                    dgSchedule.DataSource = scheduleListDT.DefaultView;
                }
                else
                {
                    lblScheduleHeader.Text = scheduleListDT.FirstOrDefault().SportName;
                    dgSchedule.DataSource = scheduleListDT;
                }

                dgSchedule.DataBind();
            }
        }

        protected void BindGender()
        {
            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

            DataView view = new DataView(scheduleListDT);
            DataTable distinctValues = view.ToTable(true, "GenderID", "Gender", "GenderCode");

            foreach(DataRow row in distinctValues.Rows)
            {
                int genderID = Convert.ToInt32(row["GenderID"]);
                switch(genderID)
                {
                    case 1:
                        row["GenderCode"] = "men";
                        break;
                    case 2:
                        row["GenderCode"] = "women";
                        break;
                    case 3:
                        row["GenderCode"] = "mixed";
                        row["Gender"] = "Mixed/Open";
                        break;
                }
            }

            if(distinctValues.Rows.Count > 1)
            {
                DataRow row = distinctValues.NewRow();
                row["GenderID"] = "0";
                row["Gender"] = "All";
                row["GenderCode"] = "all";
                distinctValues.Rows.Add(row);
            }

            distinctValues.DefaultView.Sort = "GenderID";

            ddlGender.DataTextField = "Gender";
            ddlGender.DataValueField = "GenderCode";
            ddlGender.DataSource = distinctValues.DefaultView;
            ddlGender.DataBind();
        }
        protected void dgSchedule_DataBound(object sender, EventArgs e)
        {
            dgSchedule.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void repeaterPanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
                scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

                Label lblSubHeader = (Label)e.Item.FindControl("lblSubHeader");

                HyperLink linkCollapse = (HyperLink)e.Item.FindControl("linkCollapse");
                Panel pnlCollapsible = (Panel)e.Item.FindControl("pnlCollapsible");
                linkCollapse.Attributes.Add("data-panel-id", pnlCollapsible.ClientID);

                GridView grid = (GridView)e.Item.FindControl("dgScheduleAll");

                if ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]) == WebBase.SCHEDULEHEADERTYPE.Sport)
                {
                    HiddenField hidSportID = (HiddenField)e.Item.FindControl("hidSportID");
                    lblSubHeader.Text = scheduleListDT.Where(a => a.SportID == Convert.ToInt32(hidSportID.Value)).First().SportName;

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
                else if ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]) == WebBase.SCHEDULEHEADERTYPE.Date)
                {
                    HiddenField hidScheduleDate = (HiddenField)e.Item.FindControl("hidScheduleDate");
                    lblSubHeader.Text = Convert.ToDateTime(hidScheduleDate.Value).ToString(WebBase.DATETIME_dd_MMM_yyyy_FORMAT);

                    DataRow[] rows;

                    if (Request.QueryString[WebBase.QS_EVENTID] != null)
                    {
                        rows = scheduleListDT.Where(a => a.ScheduleDate.Equals(hidScheduleDate.Value) && a.EventID == Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID])).OrderBy(b => b.ScheduleDateTime).ThenBy(c => c.SportName).ToArray();
                    }
                    else
                    {
                        rows = scheduleListDT.Where(a => a.ScheduleDate.Equals(hidScheduleDate.Value)).OrderBy(b => b.ScheduleDateTime).ThenBy(c => c.SportName).ToArray();
                    }


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
        }

        protected void dgScheduleAll_DataBound(object sender, EventArgs e)
        {
            if (((GridView)sender).HeaderRow != null)
            {
                ((GridView)sender).HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void menu_Click(object sender, EventArgs e)
        {
            ViewState[WebBase.VS_SELECTEDITEM] = ((LinkButton)sender).CommandArgument;
            this.GetSchedule();
            this.BindData();
            this.SetActiveMenu();
        }

        protected void dgSchedule_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ViewState[WebBase.VS_SCHEDULEHEADERTYPE] != null)
                {
                    switch ((WebBase.SCHEDULEHEADERTYPE)(ViewState[WebBase.VS_SCHEDULEHEADERTYPE]))
                    {
                        case WebBase.SCHEDULEHEADERTYPE.Date:
                            string gender = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Gender"));

                            if (gender.Equals(WebBase.GENDER.Men.ToString()))
                            {
                                e.Row.CssClass = "men";
                            }
                            else if (gender.Equals(WebBase.GENDER.Women.ToString()))
                            {
                                e.Row.CssClass = "women";
                            }
                            else if (gender.Equals(WebBase.GENDER.Mixed.ToString()))
                            {
                                e.Row.CssClass = "mixed";
                            }
                            break;
                    }
                }
            }
        }

        private void SetActiveMenu()
        {
            if (ViewState[WebBase.VS_SCHEDULEHEADERTYPE] != null && ViewState[WebBase.VS_SELECTEDITEM] != null)
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
    }
}