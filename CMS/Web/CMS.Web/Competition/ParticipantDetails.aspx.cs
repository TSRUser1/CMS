using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFCompetition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Web.Competition
{
    public partial class ParticipantDetails : System.Web.UI.Page
    {
        const string qs_EDIT = "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSportClass();
                BindUIControl();
                if (Request.QueryString[WebBase.QS_PAGE_MODE] != null && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    BindData();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();
            var Id = 0;
            if (ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] != null)
            {
                requestDS = (CompetitionDS)ViewState[WebBase.VS_PARTICIPANTINEVENT_DS];
            }

            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();
            row.FullName = txtFullName.Text;
            row.FamilyName = txtFamilyName.Text;
            row.GivenName = txtGivenName.Text;
            row.IPCNo = txtIPCNo.Text;
            row.GenderID = Convert.ToInt32(ddlGender.SelectedValue);
            row.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            row.PassportNumber = txtPassportNo.Text;
            row.MainCategoryID = Convert.ToInt32(ddlMainCategory.SelectedValue);
            row.CardPhotoPath = txtCardPhotoPath.Text;
            row.CardPhotoPathThumbnail = txtCardPhotoPathThumbnail.Text;
            row.CardPhotoPathExternal = txtCardPhotoPathExternal.Text;
            if (!string.IsNullOrEmpty(txtHeight.Text))
            {
                row.Height = Convert.ToDecimal(txtHeight.Text);
            }
            if (!string.IsNullOrEmpty(txtWeight.Text))
            {
                row.Weight = Convert.ToDecimal(txtWeight.Text);
            }
            row.AccreditationNumber = txtAccreditationNo.Text;
            if (!string.IsNullOrEmpty(txtDOB.Text))
            {
                row.DateOfBirth = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            row.IsActive = 1;
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                row.ParticipantID = Convert.ToInt32(Request.QueryString[1]);
                requestDS.ParticipantDetail.AddParticipantDetailRow(row);
                svc.UpdateParticipantDetail(requestDS);
            }
            else
            {
                requestDS.ParticipantDetail.AddParticipantDetailRow(row);
                svc.InsertParticipantDetail(requestDS);
            }

            btnBack_Click(sender, e);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Text = "";
            txtFamilyName.Text = "";
            ddlGender.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            txtPassportNo.Text = "";
            ddlMainCategory.SelectedIndex = 0;
            txtCardPhotoPath.Text = "";
            txtCardPhotoPathThumbnail.Text = "";
            txtCardPhotoPathExternal.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Competition/ParticipantMaintenance.aspx?");
        }

        protected void BindEventList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();


            if (string.IsNullOrEmpty(ddlSport.SelectedValue))
                return;

            row.SportID = Convert.ToInt32(ddlSport.SelectedValue);

            requestDS.Event.AddEventRow(row);

            #region GetEventList
            responseDS = svc.GetEventList(requestDS);
            #endregion

            ddlEvent.DataSource = responseDS.Event;
            ddlEvent.DataTextField = responseDS.Event.EventNameColumn.ColumnName;
            ddlEvent.DataValueField = responseDS.Event.EventIDColumn.ColumnName; ;
            ddlEvent.DataBind();

            ViewState[WebBase.VS_EVENT_DS] = responseDS;

            BindTeam();
        }

        protected void BindSportList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportRow row = requestDS.Sport.NewSportRow();

            requestDS.Sport.AddSportRow(row);

            #region GetSport
            responseDS = svc.GetSport(requestDS);
            #endregion

            ddlSport.DataSource = responseDS.Sport;
            ddlSport.DataTextField = responseDS.Sport.SportNameColumn.ColumnName;
            ddlSport.DataValueField = responseDS.Sport.SportIDColumn.ColumnName; ;
            ddlSport.DataBind();

            BindEventList();
        }

        protected void BindGenderType()
        {
            foreach (ReferenceNum.Gender item in Enum.GetValues(typeof(ReferenceNum.Gender)).Cast<ReferenceNum.Gender>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.Gender)Enum.Parse(typeof(ReferenceNum.Gender), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlGender.Items.Add(listItem);
            }
        }

        protected void BindMainCategory()
        {
            foreach (ReferenceNum.MainCategory item in Enum.GetValues(typeof(ReferenceNum.MainCategory)).Cast<ReferenceNum.MainCategory>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.MainCategory)Enum.Parse(typeof(ReferenceNum.MainCategory), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlMainCategory.Items.Add(listItem);
            }
        }

        protected void BindCountryType()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.CountryRow countryRow = requestDS.Country.NewCountryRow();

            requestDS.Country.AddCountryRow(countryRow);

            #region GetCountry
            responseDS = svc.GetCountry(requestDS);
            #endregion

            ddlCountry.DataSource = responseDS.Country;
            ddlCountry.DataTextField = responseDS.Country.CountryNameColumn.ColumnName;
            ddlCountry.DataValueField = responseDS.Country.CountryIDColumn.ColumnName; ;
            ddlCountry.DataBind();
        }

        protected void DGParticipantInEvent()
        {
            WebBase.BindColumn("dgParticipantInEvent", dgParticipantInEvent);
        }

        protected void BindParticipantInEvent()
        {
            CompetitionDS OutputDS = new CompetitionDS();
            OutputDS = (CompetitionDS)ViewState[WebBase.VS_PARTICIPANTINEVENT_DS];
            dgParticipantInEvent.DataSource = OutputDS.ParticipantInEvent;
            dgParticipantInEvent.DataBind();
        }

        protected void BindUIControl()
        {
            BindGenderType();
            BindCountryType();
            BindMainCategory();
            BindSportList();
            BindSportClassList();
            DGParticipantInEvent();
        }

        protected void BindData()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();
            row.ParticipantID = Convert.ToInt32(Request.QueryString[1]);
            requestDS.ParticipantDetail.AddParticipantDetailRow(row);

            #region GetParticipantDetail
            responseDS = svc.GetParticipantDetail(requestDS);
            #endregion
            lblPageMode.Text = "Update";

            if (!responseDS.ParticipantDetail[0].IsFullNameNull())
            {
                txtFullName.Text = responseDS.ParticipantDetail[0].FullName;
            }
            if (!responseDS.ParticipantDetail[0].IsFamilyNameNull())
            {
                txtFamilyName.Text = responseDS.ParticipantDetail[0].FamilyName;
            }
            if (!responseDS.ParticipantDetail[0].IsGenderIDNull())
            {
                ddlGender.SelectedValue = Convert.ToString(responseDS.ParticipantDetail[0].GenderID);
            }
            if (!responseDS.ParticipantDetail[0].IsCountryIDNull())
            {
                ddlCountry.SelectedValue = Convert.ToString(responseDS.ParticipantDetail[0].CountryID);
            }
            if (!responseDS.ParticipantDetail[0].IsPassportNumberNull())
            {
                txtPassportNo.Text = Convert.ToString(responseDS.ParticipantDetail[0].PassportNumber);
            }
            if (!responseDS.ParticipantDetail[0].IsMainCategoryIDNull())
            {
                ddlMainCategory.SelectedValue = Convert.ToString(responseDS.ParticipantDetail[0].MainCategoryID);
            }
            if (!responseDS.ParticipantDetail[0].IsCardPhotoPathNull())
            {
                txtCardPhotoPath.Text = Convert.ToString(responseDS.ParticipantDetail[0].CardPhotoPath);
            }
            if (!responseDS.ParticipantDetail[0].IsCardPhotoPathThumbnailNull())
            {
                txtCardPhotoPathThumbnail.Text = Convert.ToString(responseDS.ParticipantDetail[0].CardPhotoPathThumbnail);
            }
            if (!responseDS.ParticipantDetail[0].IsCardPhotoPathExternalNull())
            {
                txtCardPhotoPathExternal.Text = Convert.ToString(responseDS.ParticipantDetail[0].CardPhotoPathExternal);
            }
            if (!responseDS.ParticipantDetail[0].IsGivenNameNull())
            {
                txtGivenName.Text = Convert.ToString(responseDS.ParticipantDetail[0].GivenName);
            }
            if (!responseDS.ParticipantDetail[0].IsIPCNoNull())
            {
                txtIPCNo.Text = Convert.ToString(responseDS.ParticipantDetail[0].IPCNo);
            }
            if (!responseDS.ParticipantDetail[0].IsHeightNull())
            {
                txtHeight.Text = Convert.ToString(responseDS.ParticipantDetail[0].Height);
            }
            if (!responseDS.ParticipantDetail[0].IsWeightNull())
            {
                txtWeight.Text = Convert.ToString(responseDS.ParticipantDetail[0].Weight);
            }
            if (!responseDS.ParticipantDetail[0].IsAccreditationNumberNull())
            {
                txtAccreditationNo.Text = Convert.ToString(responseDS.ParticipantDetail[0].AccreditationNumber);
            }
            if (!responseDS.ParticipantDetail[0].IsDateOfBirthNull())
            {
                txtDOB.Text = responseDS.ParticipantDetail[0].DateOfBirth.ToString(WebBase.DATE_FORMAT);
            }

            CompetitionDS responseParticipantInEventDS = new CompetitionDS();
            CompetitionDS requestParticipantInEventDS = new CompetitionDS();
            CompetitionDS.ParticipantInEventRow rowPie = requestParticipantInEventDS.ParticipantInEvent.NewParticipantInEventRow();
            rowPie.ParticipantID = Convert.ToInt32(Request.QueryString[1]);
            requestParticipantInEventDS.ParticipantInEvent.AddParticipantInEventRow(rowPie);

            #region GetParticipantInEvent
            responseParticipantInEventDS = svc.GetParticipantInEvent(requestParticipantInEventDS);
            dgParticipantInEvent.DataSource = responseParticipantInEventDS.ParticipantInEvent;
            dgParticipantInEvent.DataBind();

            if (responseParticipantInEventDS.ParticipantInEvent.Rows.Count > 0 && !responseParticipantInEventDS.ParticipantInEvent[0].IsSportClassIDNull())
            {
                ddlSportClass.SelectedValue = responseParticipantInEventDS.ParticipantInEvent[0].SportClassID.ToString();
            }

            ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] = responseParticipantInEventDS;
            #endregion
        }

        private void GetSportClass()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportClassRow row = requestDS.SportClass.NewSportClassRow();
            
            requestDS.SportClass.AddSportClassRow(row);

            #region GetSportClassList
            responseDS = svc.GetSportClass(requestDS);
            ViewState[WebBase.VS_SPORTCLASS_DT] = responseDS.SportClass;
            #endregion
        }

        protected void ddlSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEventList();
            BindSportClassList();
        }

        protected void DGParticipantInEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgParticipantInEvent.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindParticipantInEvent();
        }

        protected void DGParticipantInEvent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] != null)
            {
                CompetitionDS requestDS = (CompetitionDS)ViewState[WebBase.VS_PARTICIPANTINEVENT_DS];
                foreach (CompetitionDS.ParticipantInEventRow row in requestDS.ParticipantInEvent)
                {
                    if (row.ParticipantInEventID == 0)
                    {
                        row.Delete();
                        break;
                    }
                    else
                    {
                        if (row.ParticipantInEventID == Convert.ToInt32(dgParticipantInEvent.DataKeys[e.RowIndex].Values[requestDS.ParticipantInEvent.ParticipantInEventIDColumn.ColumnName]))
                        {
                            row.IsActive = 0;
                            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                        }
                    }
                }
                ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] = requestDS;
                BindParticipantInEvent();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Reset the edit index.
            dgParticipantInEvent.EditIndex = -1;

            CompetitionDS requestDS;
            if (ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] == null)
            {
                requestDS = new CompetitionDS();
            }
            else
            {
                requestDS = (CompetitionDS)ViewState[WebBase.VS_PARTICIPANTINEVENT_DS];
            }
            CompetitionDS.ParticipantInEventRow row = requestDS.ParticipantInEvent.NewParticipantInEventRow();
            row.ParticipantInEventID = 0;
            row.EventID = Convert.ToInt32(ddlEvent.SelectedValue);
            row.EventName = ddlEvent.SelectedItem.Text;
            row.SportID = Convert.ToInt32(ddlSport.SelectedValue);
            row.SportName = ddlSport.SelectedItem.Text;
            row.SportClassID = Convert.ToInt32(ddlSportClass.SelectedValue);
            row.SportClassCode = ddlSportClass.SelectedItem.Text;

            //if (ddlTeam.Enabled)
            //{
            //    row.TeamID = Convert.ToInt32(ddlTeam.SelectedValue);
            //}
            
            
            if (!string.IsNullOrEmpty(ddlSportClass.SelectedValue.ToString()))
            {
                row.SportClassID = Convert.ToInt32(ddlSportClass.SelectedValue);
            }
                
            row.IsActive = 1;
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            row.CreatedDateTime = DateTime.Now;
            requestDS.ParticipantInEvent.AddParticipantInEventRow(row);

            dgParticipantInEvent.DataSource = requestDS.ParticipantInEvent;
            dgParticipantInEvent.DataBind();

            ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] = requestDS;
        }

        protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindTeam();
        }

        protected void BindSportClassList()
        {
            if (string.IsNullOrEmpty(ddlSport.SelectedValue))
                return;

            CompetitionDS.SportClassDataTable sportClassDT = new CompetitionDS.SportClassDataTable();
            sportClassDT = (CompetitionDS.SportClassDataTable)ViewState[WebBase.VS_SPORTCLASS_DT];

            ddlSportClass.DataSource = sportClassDT.Where(item => item.SportID == Convert.ToInt32(ddlSport.SelectedValue));
            ddlSportClass.DataTextField = sportClassDT.SportClassCodeColumn.ColumnName;
            ddlSportClass.DataValueField = sportClassDT.SportClassIDColumn.ColumnName;
            ddlSportClass.DataBind();
        }

        protected void BindTeam()
        {
            //CompetitionClient svc = new CompetitionClient();
            //CompetitionDS requestDS = new CompetitionDS();
            //CompetitionDS responseDS = new CompetitionDS();

            //CompetitionDS.TeamRow row = requestDS.Team.NewTeamRow();

            //if (string.IsNullOrEmpty(ddlEvent.SelectedValue))
            //{
            //    return;
            //}

            //CompetitionDS eventDS = (CompetitionDS)ViewState[WebBase.VS_EVENT_DS];

            //if (eventDS.Event != null && eventDS.Event.Count > 0)
            //{
            //    CompetitionDS.EventRow[] eventRow = (CompetitionDS.EventRow[])eventDS.Event.Select("EventID=" + ddlEvent.SelectedValue);

            //    if (eventRow.Length > 0)
            //    {
            //        if ((ReferenceNum.EventType)eventRow[0].EventTypeID == ReferenceNum.EventType.Individual)
            //        {
            //            reqDdlTeam.Enabled = false;
            //            ddlTeam.Enabled = false;
            //            return;
            //        }
            //        else
            //        {
            //            reqDdlTeam.Enabled = true;
            //            ddlTeam.Enabled = true;
            //        }
            //    }
            //}


            //row.EventID = Convert.ToInt32(ddlEvent.SelectedValue);

            //requestDS.Team.AddTeamRow(row);

            //#region GetTeam
            //responseDS = svc.GetTeam(requestDS);
            //#endregion
            
            //ddlTeam.DataSource = responseDS.Team;
            //ddlTeam.DataTextField = responseDS.Team.TeamNameColumn.ColumnName;
            //ddlTeam.DataValueField = responseDS.Team.TeamIDColumn.ColumnName;
            //ddlTeam.DataBind();
        }

        protected void dgParticipantInEvent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var value = DataBinder.Eval(e.Row.DataItem, "IsActive");
            if (value != null && value.ToString() != string.Empty)
            {
                if (value.ToString() != "1")
                {
                    e.Row.Visible = false;
                }
                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow && ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit)))
                    {
                        int index = -1;
                        foreach (DataControlField col in dgParticipantInEvent.Columns)
                        {
                            if (col.HeaderText.ToLower().Trim() == "sport class")
                            {
                                //add 1 because 1st column is the edit/delete column
                                index = dgParticipantInEvent.Columns.IndexOf(col) + 1;
                                break;
                            }
                        }

                        if (index > -1)
                        {
                            DropDownList gridDDLSportClassCode = (DropDownList)e.Row.Cells[index].FindControl("gridDDLSportClassCode");
                            CompetitionDS.SportClassDataTable sportClassDT = new CompetitionDS.SportClassDataTable();
                            sportClassDT = (CompetitionDS.SportClassDataTable)ViewState[WebBase.VS_SPORTCLASS_DT];

                            gridDDLSportClassCode.DataSource = sportClassDT.Where(item => item.SportID == Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SportID")));
                            gridDDLSportClassCode.DataTextField = sportClassDT.SportClassCodeColumn.ColumnName;
                            gridDDLSportClassCode.DataValueField = sportClassDT.SportClassIDColumn.ColumnName;
                            gridDDLSportClassCode.DataBind();

                            gridDDLSportClassCode.SelectedValue = DataBinder.Eval(e.Row.DataItem, "SportClassID").ToString();
                        }
                    }
                }
            }
        }

        protected void dgParticipantInEvent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            dgParticipantInEvent.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindParticipantInEvent();
        }

        protected void dgParticipantInEvent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            dgParticipantInEvent.EditIndex = -1;
            //Bind data to the GridView control.
            BindParticipantInEvent();
        }

        protected void dgParticipantInEvent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CompetitionDS requestDS = (CompetitionDS)ViewState[WebBase.VS_PARTICIPANTINEVENT_DS];
            CompetitionDS.ParticipantInEventRow row;

            int participantInEventID  = Convert.ToInt32(dgParticipantInEvent.DataKeys[e.RowIndex].Values[requestDS.ParticipantInEvent.ParticipantInEventIDColumn.ColumnName]);
            DateTime createdDateTime;

            if (participantInEventID == 0)
            {
                createdDateTime = Convert.ToDateTime(dgParticipantInEvent.DataKeys[e.RowIndex].Values[requestDS.ParticipantInEvent.CreatedDateTimeColumn.ColumnName]);
                row = requestDS.ParticipantInEvent.Where(item => item.ParticipantInEventID == 0).Where(item => item.CreatedDateTime == createdDateTime).FirstOrDefault();
            }
            else
            {
                row = requestDS.ParticipantInEvent.Where(item => item.ParticipantInEventID == participantInEventID).FirstOrDefault();
            }

            int index = -1;
            foreach (DataControlField col in dgParticipantInEvent.Columns)
            {
                if (col.HeaderText.ToLower().Trim() == "sport class")
                {
                    //add 1 because 1st column is the edit/delete column
                    index = dgParticipantInEvent.Columns.IndexOf(col) + 1;
                    break;
                }
            }

            if (index > -1)
            {
                DropDownList gridDDLSportClassCode = (DropDownList)dgParticipantInEvent.Rows[e.RowIndex].FindControl("gridDDLSportClassCode");
                row.SportClassCode = gridDDLSportClassCode.SelectedItem.Text;
                row.SportClassID = Convert.ToInt32(gridDDLSportClassCode.SelectedValue);
            }
            else
            {
                //column not found, do nothing
                return;
            }

            ViewState[WebBase.VS_PARTICIPANTINEVENT_DS] = requestDS;

            ////Reset the edit index.
            dgParticipantInEvent.EditIndex = -1;

            //Bind data to the GridView control.
            BindParticipantInEvent();
        }
    }
}