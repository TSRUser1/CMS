using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Schedule
{
    public partial class Live : System.Web.UI.Page
    {
        #region protected methods
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetSchedule();
                this.BindData();
                this.BindUIControl();
            }
        }
        
        protected void GetSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleListRow row = requestDS.ScheduleList.NewScheduleListRow();
            
            TimeZoneInfo singaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById(WebBase.TIMEZONE_SINGAPORE);
            DateTime singaporeDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, singaporeTimeZone);
            row.ScheduleDateTime = singaporeDateTime;
            
#if(DEBUG)
            row.ScheduleDateTime = Convert.ToDateTime("2015-12-5");
#endif

            row.IsEndState = false;

            requestDS.ScheduleList.AddScheduleListRow(row);

            #region GetScheduleList
            responseDS = svc.GetScheduleList(requestDS);

            ViewState[WebBase.VS_SCHEDULELIST_DS] = responseDS.ScheduleList;
            #endregion
        }
        protected void dgSchedule_DataBound(object sender, EventArgs e)
        {
            dgSchedule.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion

        #region private methods

        private void BindData()
        {
            CompetitionDS.ScheduleListDataTable scheduleListDT = new CompetitionDS.ScheduleListDataTable();
            scheduleListDT = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_SCHEDULELIST_DS];
            
            DataRow[] rows = scheduleListDT.OrderBy(a => a.ScheduleDateTime).ThenBy(b => b.SportName).ThenBy(c => c.EventName).ToArray();

            if (rows.Length > 0)
            {
                dgSchedule.DataSource = rows.CopyToDataTable();
            }
            else
            {
                dgSchedule.DataSource = rows;
            }
            dgSchedule.DataBind();
        }

        private void BindUIControl()
        {
            TimeZoneInfo singaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById(WebBase.TIMEZONE_SINGAPORE);
            DateTime singaporeDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, singaporeTimeZone);
            showDate.Text = "(" + singaporeDateTime.ToString("dd MMM yyyy") + ")";

#if(DEBUG)
            showDate.Text = "(" + "05 Dec 2015" + ")";
#endif
        }
        #endregion
    }
}