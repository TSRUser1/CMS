using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.Athletes
{
    public partial class Biography : System.Web.UI.Page
    {

        #region protected methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetLookupData();
                this.BindCountryData();
                this.BindSportData();

                this.SetSearchPanelVisible(true);
                this.SetSearchResultVisible(false);
                this.BindLinkCollapseSearchPanel();

                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                    {
                        int countryID = Convert.ToInt32(Request.QueryString[WebBase.QS_COUNTRYID]);
                        this.BindSelectedCountry(countryID);
                    }

                    if (Request.QueryString[WebBase.QS_ATHLETEID] != null)
                    {
                        int participantID = Convert.ToInt32(Request.QueryString[WebBase.QS_ATHLETEID]);
                        hidSelectedParticipantID.Value = participantID.ToString();
                        this.GetParticipantDetailAndResult(participantID);
                        this.BindParticipantDetailData();
                        this.BindParticipantEventAndScheduleData();
                        this.SetSearchPanelVisible(false);
                        this.SetSearchResultVisible(false);
                        this.SetParticipantDetailVisible(true);
                        this.SetParticipantDetailBorderVisible(false);

                        this.BindResponseHeader();
                    }
                    else if (Request.QueryString[WebBase.QS_COUNTRYID] != null)
                    {
                        if (Convert.ToInt32(ddlCountry.SelectedValue) > 0)
                        {
                            this.GetParticipantList();
                            this.BindParticipantSearchResultData();
                            this.SetSearchPanelVisible(true);
                            this.SetSearchResultVisible(true);
                        }
                    }
                }

            }
        }
        protected void dgParticipantEvent_PreRender(object sender, EventArgs e)
        {
            dgParticipantEvent.HeaderRow.TableSection = TableRowSection.TableHeader;

            int[] excludedColumns = { 3, 4 };
            WebBase.MergeRows(dgParticipantEvent, excludedColumns);
        }

        protected void rptEvent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink linkCollapse = (HyperLink)e.Item.FindControl("linkCollapse");
                Panel panelEvent = (Panel)e.Item.FindControl("panelEvent");
                linkCollapse.Attributes.Add("data-panel-id", panelEvent.ClientID);

                CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
                scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

                HiddenField hidScheduleDate = (HiddenField)e.Item.FindControl("hidScheduleDate");
                GridView grid = (GridView)e.Item.FindControl("dgParticipantSchedule");

                DataRow[] rows = scheduleListDT.Where(a => a.ScheduleDate.Equals(hidScheduleDate.Value)).ToArray();

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
        protected void listParticipant_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            listParticipant.SelectedIndex = e.Item.DataItemIndex;
            int participantID = Convert.ToInt32(((HiddenField)listParticipant.Items[listParticipant.SelectedIndex].FindControl("hidParticipantID")).Value);
            hidSelectedParticipantID.Value = participantID.ToString();
            this.GetParticipantDetailAndResult(participantID);
            this.BindParticipantDetailData();
            this.BindParticipantEventAndScheduleData();
            this.SetParticipantDetailVisible(true);
            this.SetParticipantDetailBorderVisible(true);
        }

        protected void dgParticipantSchedule_DataBound(object sender, EventArgs e)
        {
            if (((GridView)sender).HeaderRow != null)
            {
                ((GridView)sender).HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        #endregion

        #region private methods
        private void GetLookupData()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.CountryRow countryRow = requestDS.Country.NewCountryRow();

            requestDS.Country.AddCountryRow(countryRow);

            #region GetCountry
            responseDS = svc.GetCountry(requestDS);

            ViewState[WebBase.VS_COUNTRY_DS] = responseDS.Country;
            #endregion

            CompetitionDS.SportRow sportRow = requestDS.Sport.NewSportRow();

            requestDS.Sport.AddSportRow(sportRow);

            #region GetSport
            responseDS = svc.GetSport(requestDS);

            ViewState[WebBase.VS_SPORT_DS] = responseDS.Sport;
            #endregion
        }

        private void GetParticipantList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantListRow row = requestDS.ParticipantList.NewParticipantListRow();

            string fullName = txtName.Text.Trim();
            int selectedCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            int selectedSportID = Convert.ToInt32(ddlDiscipline.SelectedValue);

            if (!string.IsNullOrEmpty(fullName))
            {
                row.FullName = fullName;
            }
            if (selectedCountryID > 0)
            {
                row.CountryID = selectedCountryID;
            }
            if (selectedSportID > 0)
            {
                row.SportID = selectedSportID;
            }

            requestDS.ParticipantList.AddParticipantListRow(row);

            #region GetParticipantList
            responseDS = svc.GetParticipantList(requestDS);

            ViewState[WebBase.VS_PARTICIPANTLIST_DS] = responseDS.ParticipantList;
            lblSearchCount.Text = "(" + responseDS.ParticipantList.Rows.Count.ToString() + ")";
            #endregion
        }

        private void GetParticipantDetailAndResult(int participantID)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantBiographyRow participantBiographyRow = requestDS.ParticipantBiography.NewParticipantBiographyRow();

            participantBiographyRow.ParticipantID = participantID;

            requestDS.ParticipantBiography.AddParticipantBiographyRow(participantBiographyRow);

            #region GetParticipantDetail
            responseDS = svc.GetParticipantBiography(requestDS);

            ViewState[WebBase.VS_PARTICIPANTDETAIL_DS] = responseDS.ParticipantBiography;
            #endregion

            CompetitionDS.ParticipantEventRow participantEventRow = requestDS.ParticipantEvent.NewParticipantEventRow();

            participantEventRow.ParticipantID = participantID;

            requestDS.ParticipantEvent.AddParticipantEventRow(participantEventRow);

            #region GetParticipantEvent
            responseDS = svc.GetParticipantEvent(requestDS);

            ViewState[WebBase.VS_PARTICIPANTEVENT_DS] = responseDS.ParticipantEvent;
            #endregion

            CompetitionDS.ScheduleListRow scheduleListRow = requestDS.ScheduleList.NewScheduleListRow();
            scheduleListRow.ParticipantID1 = participantID;

            requestDS.ScheduleList.AddScheduleListRow(scheduleListRow);

            #region GetScheduleList
            responseDS = svc.GetScheduleList(requestDS);

            ViewState[WebBase.VS_SCHEDULELIST_DS] = responseDS.ScheduleList;
            #endregion
        }

        private void BindCountryData()
        {
            CompetitionDS.CountryDataTable countryDT = new CompetitionDS.CountryDataTable();
            countryDT = (CompetitionDS.CountryDataTable)ViewState[WebBase.VS_COUNTRY_DS];

            ddlCountry.ClearSelection();
            ddlCountry.Items.Clear();
            ddlCountry.DataTextField = WebBase.DROPDOWNLIST_COUNTRY_TEXTFIELD;
            ddlCountry.DataValueField = WebBase.DROPDOWNLIST_COUNTRY_DATAFIELD;
            ddlCountry.DataSource = countryDT.OrderBy(a => a.CountryName);
            ddlCountry.DataBind();

            ddlCountry.Items.Insert(0, new ListItem(WebBase.DROPDOWNLIST_COUNTRY_ALL, Convert.ToInt32(WebBase.DROPDOWNLISTVALUES.All).ToString()));
        }

        private void BindSportData()
        {
            CompetitionDS.SportDataTable sportDT = new CompetitionDS.SportDataTable();
            sportDT = (CompetitionDS.SportDataTable)ViewState[WebBase.VS_SPORT_DS];

            ddlDiscipline.ClearSelection();
            ddlDiscipline.Items.Clear();
            ddlDiscipline.DataTextField = WebBase.DROPDOWNLIST_SPORT_TEXTFIELD;
            ddlDiscipline.DataValueField = WebBase.DROPDOWNLIST_SPORT_DATAFIELD;
            ddlDiscipline.DataSource = sportDT.OrderBy(a => a.SportName);
            ddlDiscipline.DataBind();

            ddlDiscipline.Items.Insert(0, new ListItem(WebBase.DROPDOWNLIST_SPORT_ALL, Convert.ToInt32(WebBase.DROPDOWNLISTVALUES.All).ToString()));
        }

        private void BindParticipantSearchResultData()
        {
            CompetitionDS.ParticipantListDataTable participantListDT = new CompetitionDS.ParticipantListDataTable();
            participantListDT = (CompetitionDS.ParticipantListDataTable)ViewState[WebBase.VS_PARTICIPANTLIST_DS];

            DataRow[] rows;

            //ordering of the if else below is important!
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                rows = participantListDT.OrderBy(a => a.FullName).ThenBy(b => b.CountryName).ThenBy(c => c.SportName).ToArray();
            }
            else if (!ddlCountry.SelectedValue.Equals(Convert.ToInt32(WebBase.DROPDOWNLISTVALUES.All).ToString()) || !ddlDiscipline.SelectedValue.Equals(Convert.ToInt32(WebBase.DROPDOWNLISTVALUES.All).ToString()))
            {
                rows = participantListDT.OrderBy(a => a.CountryName).ThenBy(b => b.SportName).ThenBy(c => c.FullName).ToArray();
            }
            else
            {
                rows = participantListDT.OrderBy(a => a.FullName).ThenBy(b => b.CountryName).ThenBy(c => c.SportName).ToArray();
            }

            if (rows.Length > 0)
            {
                listParticipant.DataSource = rows.CopyToDataTable();
            }
            else
            {
                listParticipant.DataSource = rows;
            }

            listParticipant.DataBind();
        }

        private void BindParticipantDetailData()
        {
            CompetitionDS.ParticipantBiographyDataTable participantBiographyDT = new CompetitionDS.ParticipantBiographyDataTable();
            participantBiographyDT = (CompetitionDS.ParticipantBiographyDataTable)ViewState[WebBase.VS_PARTICIPANTDETAIL_DS];

            if (participantBiographyDT.Rows.Count > 0)
            {
                CompetitionDS.ParticipantBiographyRow row = participantBiographyDT[0];

                hidSelectedParticipantID.Value = row.ParticipantID.ToString();

                if (row.IsFullNameNull())
                {
                    lblName.Text = String.Empty;
                }
                else
                {
                    lblName.Text = row.FullName;
                    hidSelectedParticipantName.Value = row.FullName;
                }
                if (row.IsCountryIDNull())
                {
                    linkCountryImage.Enabled = false;
                    linkCountryLabel.Enabled = false;
                }
                else
                {
                    linkCountryImage.Enabled = true;
                    linkCountryImage.NavigateUrl = "~/Schedule/ScheduleCountry.aspx?CountryID=" + row.CountryID.ToString();
                    linkCountryLabel.Enabled = true;
                    linkCountryLabel.NavigateUrl = "~/Schedule/ScheduleCountry.aspx?CountryID=" + row.CountryID.ToString();
                }
                if (row.IsFlagImageFilePathNull())
                {
                    imgCountry.ImageUrl = "";
                }
                else
                {
                    imgCountry.ImageUrl = row.FlagImageFilePath;
                }
                if (row.IsCountryNameNull())
                {
                    lblNPC.Text = "-";
                    imgCountry.AlternateText = String.Empty;
                    imgCountry.ToolTip = String.Empty;
                }
                else
                {
                    lblNPC.Text = row.CountryName;
                    imgCountry.AlternateText = row.CountryName;
                    imgCountry.ToolTip = row.CountryName;
                }
                if (row.IsDateOfBirthNull())
                {
                    lblDateOfBirth.Text = "-";
                    lblAge.Text = "-";
                }
                else
                {
                    lblDateOfBirth.Text = String.Format(WebBase.DATE_dd_MMM_yyyy_FORMAT, row.DateOfBirth);

                    //calculate age
                    DateTime today = DateTime.Today;
                    int age = today.Year - row.DateOfBirth.Year;
                    if (row.DateOfBirth > today.AddYears(-age))
                    {
                        age -= 1;
                    }

                    lblAge.Text = age.ToString();

                }
                if (row.IsGenderNull())
                {
                    lblGender.Text = "-";
                }
                else
                {
                    lblGender.Text = row.Gender;
                }
                if (!row.IsHeightNull() && row.Height > 0)
                {
                    lblHeight.Text = row.Height.ToString();
                }
                else
                {
                    lblHeight.Text = "-";
                }
                if (!row.IsWeightNull() && row.Weight > 0)
                {
                    lblWeight.Text = row.Weight.ToString();
                }
                else
                {
                    lblWeight.Text = "-";
                }
                if (row.IsParticipantImageFilePathNull())
                {
                    imgParticipant.ImageUrl = "~/img/player/avatar-big.jpg";
                }
                else
                {
                    imgParticipant.ImageUrl = row.ParticipantImageFilePath;
                }

            }
        }

        private void SetSearchPanelVisible(bool isVisible)
        {
            panelSearch.Visible = isVisible;
        }

        private void SetSearchResultVisible(bool isVisible)
        {
            panelSearchResult.Visible = isVisible;
        }

        private void SetParticipantDetailVisible(bool isVisible)
        {
            panelParticipantDetail.Visible = isVisible;
        }

        private void SetParticipantDetailBorderVisible(bool isVisible)
        {
            panelAthletesProfileBorder.Visible = isVisible;
        }

        private void BindLinkCollapseSearchPanel()
        {
            linkCollapseSearch.Attributes.Add("data-panel-id", panelSearchResultList.ClientID);
        }

        private void BindParticipantEventAndScheduleData()
        {
            CompetitionDS.ParticipantEventDataTable participantEventDT = new CompetitionDS.ParticipantEventDataTable();
            participantEventDT = (CompetitionDS.ParticipantEventDataTable)ViewState[WebBase.VS_PARTICIPANTEVENT_DS];

            dgParticipantEvent.DataSource = participantEventDT;
            dgParticipantEvent.DataBind();

            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];

            DataRow[] rows = scheduleListDT.GroupBy(a => a.ScheduleDate).Select(b => b.First()).ToArray();

            if (rows.Length > 0)
            {
                rptEvent.DataSource = rows.CopyToDataTable();
            }
            else
            {
                rptEvent.DataSource = rows;
            }

            rptEvent.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.GetParticipantList();
            this.BindParticipantSearchResultData();
            this.SetSearchResultVisible(true);
            this.SetParticipantDetailVisible(false);
            this.SetParticipantDetailBorderVisible(false);
        }


        private void BindResponseHeader()
        {
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_ATHLETEID] != null)
                {
                    CompetitionDS.ParticipantBiographyDataTable participantBiographyDT = new CompetitionDS.ParticipantBiographyDataTable();
                    participantBiographyDT = (CompetitionDS.ParticipantBiographyDataTable)ViewState[WebBase.VS_PARTICIPANTDETAIL_DS];

                    if (participantBiographyDT.Rows.Count > 0)
                    {
                        CompetitionDS.ParticipantBiographyRow row = participantBiographyDT[0];

                        if (!row.IsFullNameNull())
                        {
                            HtmlMeta metaOGTitle = new HtmlMeta();
                            metaOGTitle.Attributes.Add("property", "og:title");
                            metaOGTitle.Content = row.FullName;
                            this.Page.Master.FindControl("head").Controls.Add(metaOGTitle);
                        }

                        HtmlMeta metaOGImage = new HtmlMeta();
                        metaOGImage.Attributes.Add("property", "og:image");

                        if (!row.IsParticipantImageFilePathNull())
                        {
                            metaOGImage.Content = row.ParticipantImageFilePath;
                        }
                        else
                        {
                            metaOGImage.Content = "~/img/header/apg_main_logo.png";
                        }

                        this.Page.Master.FindControl("head").Controls.Add(metaOGImage);
                    }
                }
            }

            HtmlMeta metaOGURL = new HtmlMeta();
            metaOGURL.Attributes.Add("property", "og:url");
            metaOGURL.Content = HttpContext.Current.Request.Url.ToString();
            this.Page.Master.FindControl("head").Controls.Add(metaOGURL);
        }
        private void BindSelectedCountry(int countryID)
        {
            ddlCountry.SelectedValue = countryID.ToString();
        }

        #endregion
    }
}