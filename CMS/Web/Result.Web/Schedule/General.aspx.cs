using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Web.WCFCompetition;

namespace SEM.CMS.Result.Web.Schedule
{
    public partial class General : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetGeneralSchedule();
                this.BindData();
            }
        }

        protected void GetGeneralSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.GeneralScheduleRow row = requestDS.GeneralSchedule.NewGeneralScheduleRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                }
            }
            requestDS.GeneralSchedule.AddGeneralScheduleRow(row);

            #region GetGeneralSchedule
            responseDS = svc.GetGeneralSchedule(requestDS);

            ViewState[WebBase.VS_GENERALSCHEDULE_DS] = responseDS.GeneralSchedule;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS.GeneralScheduleDataTable generalScheduleDT = new CompetitionDS.GeneralScheduleDataTable();
            generalScheduleDT = (CompetitionDS.GeneralScheduleDataTable)ViewState[WebBase.VS_GENERALSCHEDULE_DS];
            dgGeneralSchedule.DataSource = generalScheduleDT;
            dgGeneralSchedule.DataBind();

            CompetitionDS.GeneralScheduleDataTable fixedHeaderDS = new CompetitionDS.GeneralScheduleDataTable();
            CompetitionDS.GeneralScheduleRow dummyRow = fixedHeaderDS.NewGeneralScheduleRow();
            fixedHeaderDS.AddGeneralScheduleRow(dummyRow);

            dgFixedGeneralSchedule.DataSource = fixedHeaderDS;
            dgFixedGeneralSchedule.DataBind();
            dgFixedGeneralSchedule.Rows[0].Visible = false;
        }

        protected void dgGeneralSchedule_DataBound(object sender, EventArgs e)
        {
            dgGeneralSchedule.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}