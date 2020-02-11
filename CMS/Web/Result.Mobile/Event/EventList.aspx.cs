using SEM.CMS.Result.Mobile.WCFCompetition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using System.Data;
using System.Globalization;

namespace SEM.CMS.Result.Mobile.Event
{
    public partial class EventList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSportEventSchedule();
                BindData();
            }
        }

        protected void GetSportEventSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportEventScheduleRow row = requestDS.SportEventSchedule.NewSportEventScheduleRow();

            requestDS.SportEventSchedule.AddSportEventScheduleRow(row);

            #region GetSportEventSchedule
            responseDS = svc.GetSportEventSchedule(requestDS);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
            
            dlSportList.DataSource = competitionDS.SportEventSchedule.DefaultView.ToTable(true, competitionDS.SportEventSchedule.SportIDColumn.ColumnName, competitionDS.SportEventSchedule.SportNameColumn.ColumnName);
            dlSportList.DataBind();
        }

        protected void dlSportList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label txtSport = (Label)e.Item.FindControl("txtSport");

            DataList dlEventListMen = (DataList)e.Item.FindControl("dlEventListMen");
            DataList dlEventListWomen = (DataList)e.Item.FindControl("dlEventListWomen");
            DataList dlEventListMix = (DataList)e.Item.FindControl("dlEventListMix");

            CompetitionDS.SportEventScheduleDataTable eventTableMen = new CompetitionDS.SportEventScheduleDataTable();
            CompetitionDS.SportEventScheduleDataTable eventTableWomen = new CompetitionDS.SportEventScheduleDataTable();
            CompetitionDS.SportEventScheduleDataTable eventTableMix = new CompetitionDS.SportEventScheduleDataTable();

            string sportName = txtSport.Text;
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];

            foreach (CompetitionDS.SportEventScheduleRow row in competitionDS.SportEventSchedule)
            {
                if (row.SportName == sportName && !row.IsIsPublishScheduleNull() && row.IsPublishSchedule && !row.IsScheduleIDNull())
                {
                    switch ((ReferenceNum.Gender)row.GenderID)
                    {
                        case ReferenceNum.Gender.Men:
                            eventTableMen.ImportRow(row);
                            break;
                        case ReferenceNum.Gender.Women:
                            eventTableWomen.ImportRow(row);
                            break;
                        case ReferenceNum.Gender.Mixed:
                            eventTableMix.ImportRow(row);
                            break;
                    }
                }
            }

            dlEventListMen.DataSource = eventTableMen.DefaultView.ToTable(true, "EventName", "EventID", "SportID");
            dlEventListMen.DataBind();

            dlEventListWomen.DataSource = eventTableWomen.DefaultView.ToTable(true, "EventName", "EventID", "SportID");
            dlEventListWomen.DataBind();

            dlEventListMix.DataSource = eventTableMix.DefaultView.ToTable(true, "EventName", "EventID", "SportID");
            dlEventListMix.DataBind();
        }
    }
}