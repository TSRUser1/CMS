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

namespace SEM.CMS.Result.Web
{
    public partial class RWeb : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region CssActiveControl
                switch (Path.GetFileNameWithoutExtension(Request.Path))
                {
                    case "Athletes":
                    case "FinalRankings":
                    case "Report":
                    case "Results":
                    //case "Schedule":
                    case "Record":
                    case "Summary":
                    //case "Standing": --conditional visible
                        divEventMenu.Attributes["style"] = "";
                        break;
                    default:
                        divEventMenu.Attributes["style"] = "display:none";
                        break;
                }
                #endregion

                #region MenuCssActiveControl
                switch (Path.GetFileNameWithoutExtension(Request.Path))
                {
                    case "Athletes":
                    case "FinalRankings":
                    case "Report":
                    case "Results":
                    case "Record":
                    case "Summary":
                    case "General":
                    case "Live":
                    case "Schedule":
                    case "ScheduleCountry":
                        liSchedule.Attributes["class"] = "selected";
                        break;
                    case "BySport":
                        liSports.Attributes["class"] = "selected";
                        break;
                    case "Country":
                    case "Date":
                    case "Medallist":
                    case "MultiMedallist":
                    case "Standing":
                        liMedals.Attributes["class"] = "selected";
                        break;
                    case "Biography":
                    case "TeamBiography":
                        liEntries.Attributes["class"] = "selected";
                        break;
                    case "ByNPC":
                        liNPC.Attributes["class"] = "selected";
                        break;
                    default:
                        liSchedule.Attributes["class"] = "selected";
                        break;
                }
                #endregion
            }
        }

        public void ControlVisible(string sControlName, bool bIsVisible = true)
        {
            switch (sControlName)
            {
                case "divEventMenu":
                    if (bIsVisible)
                    {
                        divEventMenu.Attributes["style"] = "";
                    }
                    else
                    {
                        divEventMenu.Attributes["style"] = "display:none";
                    }
                    break;
                default:
                    //
                    break;
            }
        }
    }
}