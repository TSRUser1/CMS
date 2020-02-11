using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.UserControls
{
    public partial class uscLiveSchedule : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetLiveSchedule();
            }
            this.BindData();
        }

        protected void GetLiveSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleListRow row = requestDS.ScheduleList.NewScheduleListRow();

            TimeZoneInfo singaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById(WebBase.TIMEZONE_SINGAPORE);
            DateTime singaporeDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, singaporeTimeZone);

            row.StartDateTime = new DateTime(singaporeDateTime.Year, singaporeDateTime.Month, singaporeDateTime.Day, 0, 0, 1);
            row.EndDateTime = new DateTime(singaporeDateTime.Year, singaporeDateTime.Month, singaporeDateTime.Day, 23, 59, 59);

#if(DEBUG)
            // row.StartDateTime = new DateTime(2015, 12, 5, 0, 0, 0);
            // row.EndDateTime = new DateTime(2015, 12, 5, 23, 59, 59);
#endif

            requestDS.ScheduleList.AddScheduleListRow(row);

            #region GetLiveSchedule
            responseDS = svc.GetLiveSchedule(requestDS);

            ViewState[WebBase.VS_LIVESCHEDULELIST_DS] = responseDS.ScheduleList;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_LIVESCHEDULELIST_DS];
            listLiveSchedule.DataSource = scheduleListDT.Take(3);;
            listLiveSchedule.DataBind();
        }
        
        public void Bind()
        {
            this.GetLiveSchedule();
            this.BindData();
        }

        protected void dgLiveSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'; this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
            }
        }

        protected void listLiveSchedule_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("rowLiveSchedule");
                row.Attributes.Add("onmouseover", "this.style.cursor='pointer'; this.style.backgroundColor='#ceedfc'");
                row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
            }
        }
    }
}