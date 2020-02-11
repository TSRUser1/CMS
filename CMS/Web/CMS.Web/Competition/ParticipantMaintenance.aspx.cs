using SEM.CMS.Web.WCFCompetition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Web.Competition
{
    public partial class ParticipantMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillSportDdl();
                this.GetParticipant();
                this.DGParticipant();
            }
        }

        protected void DGParticipant_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgParticipant.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void DGParticipant_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();
            row.ParticipantID = Convert.ToInt32(dgParticipant.DataKeys[e.RowIndex].Values[requestDS.ParticipantDetail.ParticipantIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.ParticipantDetail.AddParticipantDetailRow(row);

            CompetitionClient svc = new CompetitionClient();
            svc.DeleteParticipant(requestDS);

            GetParticipant();
            BindData();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Competition/ParticipantDetails.aspx?PageMode=New");
        }

        protected void BindData()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
            dgParticipant.DataSource = competitionDS.ParticipantDetail;
            dgParticipant.DataBind();
        }

        protected void DGParticipant()
        {
            WebBase.BindColumn("dgParticipant", dgParticipant);
            //BindData(); //Do not show participant list on page first load. Only show after search.
        }

        protected void GetParticipant()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_PARTICIPANTID] != null)
                {
                    row.ParticipantID = Convert.ToInt32(Request.QueryString[WebBase.QS_PARTICIPANTID]);
                }
            }
            requestDS.ParticipantDetail.AddParticipantDetailRow(row);

            #region GetParticipant
            responseDS = svc.GetParticipantDetail(requestDS);

            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
            #endregion
        }

        public void FillSportDdl()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS.SportRow row = requestDS.Sport.NewSportRow();
            requestDS.Sport.AddSportRow(row);

            responseDS = svc.GetSport(requestDS);

            ddlSport.Items.Add(new ListItem() { Text = string.Empty, Value = string.Empty });

            foreach (var dr in responseDS.Sport)
            {
                ddlSport.Items.Add(new ListItem() { Text = dr.SportName.Trim(), Value = dr.SportID.ToString() });
            }
        }

        public void FillEventDdl()
        {
            ddlEvent.Items.Clear();

            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();
            if (!string.IsNullOrEmpty(ddlSport.SelectedValue))
            {
                row.SportID = Convert.ToInt32(ddlSport.SelectedValue);
            }

            requestDS.Event.AddEventRow(row);

            #region GetEventList
            responseDS = svc.GetEventList(requestDS);
            #endregion

            ddlEvent.DataSource = responseDS.Event;
            ddlEvent.DataTextField = responseDS.Event.EventNameColumn.ColumnName;
            ddlEvent.DataValueField = responseDS.Event.EventIDColumn.ColumnName; ;
            ddlEvent.DataBind();

            //foreach (var dr in responseDS.Event)
            //{
            //    ddlEvent.Items.Add(new ListItem() { Text = dr.EventName.Trim(), Value = dr.EventID.ToString() });
            //}
        }

        protected void ddlSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillEventDdl();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();

            row.FullName = txtName.Text;
            row.PassportNumber = txtPassport.Text;

            if (!string.IsNullOrEmpty(ddlEvent.SelectedValue))
                row.EventID = Convert.ToInt32(ddlEvent.SelectedValue);

            if (!string.IsNullOrEmpty(ddlSport.SelectedValue))
                row.SportID = Convert.ToInt32(ddlSport.SelectedValue);

            requestDS.ParticipantDetail.AddParticipantDetailRow(row);
            responseDS = svc.GetParticipantDetail(requestDS);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;

            BindData();
        }
    }
}