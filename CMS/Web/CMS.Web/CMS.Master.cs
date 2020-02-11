using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Web.Routing;
using System.Xml;
using System.Xml.Linq;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFCompetition;
using SEM.CMS.Web.WCFAdministration;

namespace SEM.CMS.Web
{
    public partial class CMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableBrowserCache();
            if (!IsPostBack)
            {
                if (IsValidSession())
                {
                    #region AdminRoleAccessChecking
                    WebBase webBase = new WebBase();
                    if ( webBase.IsValidModule(Request))
                    {
                        #region ModuleVisibility
                        this.ModuleVisibilityControl();
                        #endregion
                    }
                    else
                    {
                        Response.Redirect("~/Index.aspx");
                    }
                    #endregion

                    #region WebpageTitle
                    string WebpageName = Path.GetFileNameWithoutExtension(Request.Path);
                    string sSideCategory = "";
                    string sSideCategoryDesc = "";
                    string sCurrentPage = "";

                    this.GetPageInfoFromXml(WebpageName, out sSideCategory, out sSideCategoryDesc, out sCurrentPage);

                    lblSideCategory.Text = sSideCategory;
                    lblSideCategoryDesc.Text = sSideCategoryDesc;
                    #endregion

                    #region CssActiveControl
                    switch (Path.GetFileNameWithoutExtension(Request.Path))
                    {
                        case "Index":
                            liHome.Attributes["class"] = "active";
                            break;
                        case "ParticipantDetails":
                        case "ParticipantMaintenance":
                            liSportsManager.Attributes["class"] = "has-sub active";
                            liParticipantMaint.Attributes["class"] = "active";
                            break;
                        case "EventDetail":
                        case "EventMaintenance":
                        case "ScheduleDetails":
                        case "ScheduleMaintenance":
                        case "StartList":
                            liSportsManager.Attributes["class"] = "has-sub active";
                            liEventsAndSchedules.Attributes["class"] = "active";
                            break;
                        case "ResultMaintenance":
                            liSportsManager.Attributes["class"] = "has-sub active";
                            //liResultConfig.Attributes["class"] = "active";
                            break;
                        case "TeamMaintenance":
                            liSportsManager.Attributes["class"] = "has-sub active";
                            liTeamMaint.Attributes["class"] = "active";
                            break;
                        case "AdminUserMaintenance":
                            liAdmin.Attributes["class"] = "has-sub active";
                            liUserMaint.Attributes["class"] = "active";
                            break;
                        case "FunctionalModuleMaintenance":
                            liAdmin.Attributes["class"] = "has-sub active";
                            liModuleMaint.Attributes["class"] = "active";
                            break;
                        case "RoleMaintenance":
                            liAdmin.Attributes["class"] = "has-sub active";
                            liRoleMaint.Attributes["class"] = "active";
                            break;
                    }
                    #endregion

                    if (Request.QueryString[WebBase.QS_SPORTID] != null)
                    {
                        ViewState[WebBase.VS_SPORTID] = Request.QueryString[WebBase.QS_SPORTID];
                    }

                    this.GetSportList();

                    lblUserID.Text = Convert.ToString(Session[WebBase.SESSION_ADMINUSERNAME]);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        private bool IsValidSession()
        {
            if (Session[WebBase.SESSION_ADMINID] != null)
            {
                WebBase webBase = new WebBase();
                AdministrationDS reqDS = new AdministrationDS();
                AdministrationDS.AdminUserRow reqRow = reqDS.AdminUser.NewAdminUserRow();
                reqRow.AdminUserID = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                reqDS.AdminUser.AddAdminUserRow(reqRow);
                return webBase.Admin_IsValidLoginSession(reqDS);
            }
            else
            {
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                return false;
            }
        }

        protected void btnTestAjax_Click(object sender, EventArgs e)
        {
            updPnl_Info.Update();
            modalPopupEx_Info.Show();
        }

        public void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            if (sRedirect != "")
            {
                lblSuccess.Text = sMessage;

                updPnlSuccess.Update();
                modalPopupExSuccess.Show();

                ViewState[WebBase.VS_REDIRECTURL] = sRedirect;
            }
            else
            {
                lblPopupMessage.Text = sMessage;

                updPnl_Info.Update();
                modalPopupEx_Info.Show();
            }
        }

        protected void btn_OkSuccess_Click(object sender, EventArgs e)
        {
            string sRedirect = Convert.ToString(ViewState[WebBase.VS_REDIRECTURL]);
            Response.Redirect(sRedirect);
        }

        public void GetPageInfoFromXml(string iWebFormName, out string oSideCategory, out string oSideCategoryDesc, out string oCurrentPage)
        {
            oSideCategory = "";
            oSideCategoryDesc = "";
            oCurrentPage = "";

            XDocument xmlDoc = XDocument.Load(Server.MapPath(WebBase.PATH_XML_WEBPAGEINFO));

            var items = from item in xmlDoc.Elements("Pages").Elements("Info")
                        where item != null && (item.Attribute("type").Value == iWebFormName)
                        select item;

            foreach (var itemKeyword in items)
            {
                //assign value to the textbox
                oSideCategory = itemKeyword.Element("SideCategory").Value;
                oSideCategoryDesc = itemKeyword.Element("SideCategoryDesc").Value;
            }
        }

        public void GetSportList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportRow row = requestDS.Sport.NewSportRow();

            // Get User ID
            //if (ViewState[WebBase.VS_SPORTID] != null && ViewState[WebBase.VS_SPORTID].ToString() != string.Empty)
            //{
            //    row.SportID = Convert.ToInt32(ViewState[WebBase.VS_SPORTID]);
            //}

            requestDS.Sport.AddSportRow(row);

            #region GetSport
            responseDS = svc.GetSport(requestDS);

            if (responseDS.Sport.Rows.Count != 0)
            {
                string sAccessSports = Session[WebBase.SESSION_ACCESSSPORTS].ToString();

                sAccessSports = (sAccessSports == "") ? "'" + sAccessSports + "'" : sAccessSports;

                if (sAccessSports == "'*'")
                {
                    responseDS.Sport.DefaultView.RowFilter = "";
                }
                else
                {
                    responseDS.Sport.DefaultView.RowFilter = "SportName in(" + sAccessSports + ")";
                }
                responseDS.Sport.DefaultView.Sort = "SportName";
                ListViewSportList.DataSource = responseDS.Sport.DefaultView;
                ListViewSportList.DataBind();
            }
            #endregion

        }

        public string GetSportUrlBySportID(object obj)
        {
            string sSportId = Convert.ToString(obj);
            string sSportUrl = "/Competition/EventMaintenance.aspx?" + WebBase.QS_SPORTID + "=" + sSportId;

            return sSportUrl;
        }

        public string GetCssClassBySportID(object obj)
        {
            string sSportId = Convert.ToString(obj);
            string sCssClass = "text-info";
            string sRequestedSportId = "";

            if (ViewState[WebBase.VS_SPORTID] != null && ViewState[WebBase.VS_SPORTID].ToString() != string.Empty)
            {
                sRequestedSportId = Convert.ToString(ViewState[WebBase.VS_SPORTID]);
            }

            if (sSportId == sRequestedSportId)
            { sCssClass = "text-warning"; }

            return sCssClass;
        }

        public void ModuleVisibilityControl()
        {
            string sAccessPages = Session[WebBase.SESSION_ACCESSPAGES].ToString();

            //SPORT MANAGER
            if (sAccessPages.Contains("/Competition/ParticipantMaintenance.aspx") || sAccessPages.Contains("*"))
            {
                liParticipantMaint.Attributes["style"] = "";
            }
            else
            {
                liParticipantMaint.Attributes["style"] = "display:none";
            }

            if (sAccessPages.Contains("/Competition/EventMaintenance.aspx") || sAccessPages.Contains("*"))
            {
                liEventsAndSchedules.Attributes["style"] = "";
            }
            else
            {
                liEventsAndSchedules.Attributes["style"] = "display:none";
            }

            //if (sAccessPages.Contains("/Competition/ResultMaintenance.aspx") || sAccessPages.Contains("*"))
            //{
            //    liResultConfig.Attributes["style"] = "";
            //}
            //else
            //{
            //    liResultConfig.Attributes["style"] = "display:none";
            //}

            if (sAccessPages.Contains("/Competition/TeamMaintenance.aspx") || sAccessPages.Contains("*"))
            {
                liTeamMaint.Attributes["style"] = "";
            }
            else
            {
                liTeamMaint.Attributes["style"] = "display:none";
            }

            //ADMIN
            if (sAccessPages.Contains("/Admin/AdminUserMaintenance.aspx") || sAccessPages.Contains("*"))
            {
                liUserMaint.Attributes["style"] = "";
            }
            else
            {
                liUserMaint.Attributes["style"] = "display:none";
            }

            if (sAccessPages.Contains("/Admin/FunctionalModuleMaintenance.aspx") || sAccessPages.Contains("*"))
            {
                liModuleMaint.Attributes["style"] = "";
            }
            else
            {
                liModuleMaint.Attributes["style"] = "display:none";
            }

            if (sAccessPages.Contains("/Admin/RoleMaintenance.aspx") || sAccessPages.Contains("*"))
            {
                liRoleMaint.Attributes["style"] = "";
            }
            else
            {
                liRoleMaint.Attributes["style"] = "display:none";
            }

            //IT DEV
            if (sAccessPages.Contains("*"))
            {
                liIT.Attributes["style"] = "";
            }
            else
            {
                liIT.Attributes["style"] = "display:none";
            }
        }

        public static void DisableBrowserCache()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Cache.SetExpires(new DateTime(1995, 5, 6, 12, 0, 0, DateTimeKind.Utc));
                HttpContext.Current.Response.Cache.SetNoStore(); // Stop Caching in Firefox
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache); // Stop Caching in IE
                HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                HttpContext.Current.Response.Cache.AppendCacheExtension("post-check=0,pre-check=0");
                HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(true); // to avoid history to store an entry for each request of the same page            
            }
        }
    }
}