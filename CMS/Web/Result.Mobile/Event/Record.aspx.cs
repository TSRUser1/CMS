using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.Event
{
    public partial class Record : System.Web.UI.Page
    {
        #region protected methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetRecord();
                tab1.CssClass = "tab-pane active";
                tab2.CssClass = "tab-pane";
                liBroken.Attributes.Add("class", "active");
            }
        }

        protected void GetRecord()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseBrokenDS = new CompetitionDS();

            CompetitionDS requestBrokenDS = new CompetitionDS();
            CompetitionDS.BrokenRecordRow rowBroken = requestBrokenDS.BrokenRecord.NewBrokenRecordRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    rowBroken.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
            }
            requestBrokenDS.BrokenRecord.AddBrokenRecordRow(rowBroken);

            CompetitionDS responseInitialDS = new CompetitionDS();

            CompetitionDS requestInitialDS = new CompetitionDS();
            CompetitionDS.InitialRecordRow rowInitial = requestInitialDS.InitialRecord.NewInitialRecordRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    rowInitial.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
            }
            requestInitialDS.InitialRecord.AddInitialRecordRow(rowInitial);

            #region GetBrokenRecord
            responseBrokenDS = svc.GetBrokenRecord(requestBrokenDS);
            #endregion

            #region GetInitialRecord
            responseInitialDS = svc.GetInitialRecord(requestInitialDS);
            #endregion

            var resultBroken = from tb in responseBrokenDS.BrokenRecord
                               select new { tb.EventID, tb.EventName };

            var resultInitial = from tb in responseInitialDS.InitialRecord
                                select new { tb.EventID, tb.EventName };

            CompetitionDS responseDS = new CompetitionDS();
            responseDS.BrokenRecord.Merge(responseBrokenDS.BrokenRecord);
            responseDS.InitialRecord.Merge(responseInitialDS.InitialRecord);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
            dgBrokenRecord.DataSource = resultBroken.Distinct();
            dgBrokenRecord.DataBind();
            dgInitialRecord.DataSource = resultInitial.Distinct();
            dgInitialRecord.DataBind();

        }

        protected void dgBrokenRecord_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CompetitionDS responseDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
                GridView dgParticipantBrokenRecord = e.Row.FindControl("dgParticipantBrokenRecord") as GridView;
                var result = from row in responseDS.BrokenRecord
                             where row.EventID == Convert.ToInt32(dgBrokenRecord.DataKeys[e.Row.RowIndex].Values[responseDS.BrokenRecord.EventIDColumn.ColumnName])
                             select row;
                dgParticipantBrokenRecord.DataSource = result;
                dgParticipantBrokenRecord.DataBind();
            }
        }

        protected void dgInitialRecord_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CompetitionDS responseDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
                GridView dgParticipantInitialRecord = e.Row.FindControl("dgParticipantInitialRecord") as GridView;
                var result = from row in responseDS.InitialRecord
                             where row.EventID == Convert.ToInt32(dgInitialRecord.DataKeys[e.Row.RowIndex].Values[responseDS.InitialRecord.EventIDColumn.ColumnName])
                             select row;
                dgParticipantInitialRecord.DataSource = result;
                dgParticipantInitialRecord.DataBind();
            }
        }
        #endregion
    }
}