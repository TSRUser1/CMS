using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFCompetition;
using System.Configuration;
using System.IO;

namespace SEM.CMS.Web
{
    public partial class EventDetail : System.Web.UI.Page
    {
        protected string qs_NEW = "New";
        protected string qs_EDIT = "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUIControl();
                if (Request.QueryString.Count > 0 && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
                {
                    this.GetEventDetails();
                    this.BindData();
                    this.GetFileInEvent();
                }
            }
        }

        protected void BindData()
        {
            CompetitionDS outputDS = new CompetitionDS();
            outputDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];

            if (outputDS.Event.Rows.Count > 0)
            {
                CompetitionDS.EventRow row = outputDS.Event[0];
                txtEventCode.Text = row.IsEventCodeNull() ? "" : row.EventCode;
                txtEventName.Text = row.EventName;

                ddlEventType.SelectedValue = row.EventTypeID.ToString();
                ddlGender.SelectedValue = row.GenderID.ToString();
                ddlPlayFormat.SelectedValue = row.PlayFormatID.ToString();

                chkShowResult.Checked = row.IsIsShowResultNull() ? true : row.IsShowResult;
                chkShowAthelete.Checked = row.IsIsShowAtheleteNull() ? true : row.IsShowAthelete;
                chkShowMedal.Checked = row.IsIsShowMedalNull() ? true : row.IsShowMedal;
                chkShowReport.Checked = row.IsIsShowReportNull() ? true : row.IsShowReport;
                chkShowRecord.Checked = row.IsIsShowRecordNull() ? true : row.IsShowRecord;
                chkShowSummary.Checked = row.IsIsShowSummaryNull() ? true : row.IsShowSummary;
            }
            else
            {
                AjaxPopupMessage("Event not found", "Index.aspx");
            }
        }

        protected void BindUIControl()
        {
            DGFileUpload();
            BindGenderType();
            BindPlayFormat();
            BindEventType();
            BindFileGroupType();

            if (Request.QueryString.Count > 0 && Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                lblPageMode.Text = "Edit";
                btnInsert.Text = "Update Event";
            }
        }

        protected void BindGenderType()
        {
            // Bind data column type
            foreach (ReferenceNum.Gender item in Enum.GetValues(typeof(ReferenceNum.Gender)).Cast<ReferenceNum.Gender>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.Gender)Enum.Parse(typeof(ReferenceNum.Gender), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlGender.Items.Add(listItem);
            }
        }

        protected void BindPlayFormat()
        {
            // Bind data column type
            foreach (ReferenceNum.CompetitionFormatType item in Enum.GetValues(typeof(ReferenceNum.CompetitionFormatType)).Cast<ReferenceNum.CompetitionFormatType>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.CompetitionFormatType)Enum.Parse(typeof(ReferenceNum.CompetitionFormatType), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlPlayFormat.Items.Add(listItem);
            }
        }

        protected void BindEventType()
        {
            // Bind data column type
            foreach (ReferenceNum.EventType item in Enum.GetValues(typeof(ReferenceNum.EventType)).Cast<ReferenceNum.EventType>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.EventType)Enum.Parse(typeof(ReferenceNum.EventType), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlEventType.Items.Add(listItem);
            }
        }

        protected void BindFileGroupType()
        {
            // Bind data column type
            foreach (ReferenceNum.FileGroupType item in Enum.GetValues(typeof(ReferenceNum.FileGroupType)).Cast<ReferenceNum.FileGroupType>())
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToInt32((ReferenceNum.FileGroupType)Enum.Parse(typeof(ReferenceNum.FileGroupType), item.ToString())).ToString();
                listItem.Text = item.ToString();
                ddlFileGroupType.Items.Add(listItem);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //redirect back to previous page
            Response.Redirect("EventMaintenance.aspx?SportID=" + Request.QueryString[WebBase.QS_SPORTID]);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEventCode.Text = string.Empty;
            txtEventName.Text = string.Empty;

            ddlEventType.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlPlayFormat.SelectedIndex = 0;

            chkShowResult.Checked = true;
            chkShowAthelete.Checked = true;
            chkShowMedal.Checked = true;
            chkShowReport.Checked = true;
            chkShowRecord.Checked = true;
            chkShowSummary.Checked = true;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            WebBase webBase = new WebBase();
            if (!webBase.IsValidModule(Request))
            {
                int id = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);

                ReferenceNum.Sport sport = (ReferenceNum.Sport)Enum.ToObject(typeof(ReferenceNum.Sport), id);
                string sportName = ReferenceNum.ToEnumString<ReferenceNum.Sport>(sport);
                AjaxPopupMessage("Insufficient rights. Attempt to edit value for " + sportName + " is prohibited.");
                return;
            }
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();

            row.EventCode = txtEventCode.Text;
            row.EventName = txtEventName.Text;
            row.EventTypeID = Convert.ToInt32(ddlEventType.SelectedItem.Value);
            row.GenderID = Convert.ToInt32(ddlGender.SelectedItem.Value);
            row.PlayFormatID = Convert.ToInt32(ddlPlayFormat.SelectedItem.Value);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

            row.IsShowResult = chkShowResult.Checked;
            row.IsShowAthelete = chkShowAthelete.Checked;
            row.IsShowMedal = chkShowMedal.Checked;
            row.IsShowReport = chkShowReport.Checked;
            row.IsShowRecord = chkShowRecord.Checked;
            row.IsShowSummary = chkShowSummary.Checked;

            CompetitionClient competitionSVC = new CompetitionClient();
            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                requestDS.Event.AddEventRow(row);
                responseDS = competitionSVC.UpdateEvent(requestDS);
            }
            else
            {
                row.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
                row.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                requestDS.Event.AddEventRow(row);
                responseDS = competitionSVC.InsertEvent(requestDS);
                ViewState[WebBase.VS_EVENTID] = responseDS.Event[0].EventID;
            }

            if (responseDS.Response.Count > 0)
            {
                if (responseDS.Response[0].ResponseCode == SystemMessage.Generic_Success_Code)
                {
                    AjaxPopupMessage("Record Event Saved ...!");
                }
                else
                {
                    AjaxPopupMessage("Save Record Failed ...!");
                }
            }
            else
            {
                AjaxPopupMessage("Save Record Failed ...!");
            }
        }

        private static readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };

        public static bool IsPDFMIME(byte[] file)
        {
            //http://stackoverflow.com/questions/29211263/how-to-identify-doc-docx-pdf-xls-and-xlsx-based-on-file-header
            return file.Take(7).SequenceEqual(PDF);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string extension = string.Empty;
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient competitionSVC = new CompetitionClient();
            int eventID = 0;

            if (Request.QueryString[WebBase.QS_PAGE_MODE].ToString() == qs_EDIT)
            {
                eventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
            }
            else
            {
                eventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            if (!string.IsNullOrEmpty(fuuploadControl.FileName))
            {
                CompetitionDS.FileInEventDataTable fileInEventDT = new CompetitionDS.FileInEventDataTable();
                fileInEventDT = (CompetitionDS.FileInEventDataTable)ViewState[WebBase.VS_FILEINEVENT_DT];

                if(fileInEventDT != null)
                {
                    var fileinEvent = from tb in fileInEventDT
                                      where tb.FileName == Path.GetFileNameWithoutExtension(fuuploadControl.FileName)
                                      && tb.FileGroupID == Convert.ToInt32(ddlFileGroupType.SelectedValue)
                                      select tb;

                    if(fileinEvent.Count() > 0)
                    {
                        AjaxPopupMessage("File with the same name found. Please rename the file and upload again.");
                        return;
                    }
                }

                extension = Path.GetExtension(fuuploadControl.FileName);
                if (extension == ".pdf")
                {
                    requestDS = new CompetitionDS();

                    CompetitionDS.FileRow rowF = requestDS.File.NewFileRow();
                    rowF.FileName = Path.GetFileNameWithoutExtension(fuuploadControl.FileName);
                    rowF.IsActive = 1;
                    rowF.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                    requestDS.File.AddFileRow(rowF);

                    CompetitionDS.FileInEventRow rowFIE = requestDS.FileInEvent.NewFileInEventRow();
                    rowFIE.EventID = eventID;
                    rowFIE.FileGroupID = Convert.ToInt32(ddlFileGroupType.SelectedValue);
                    rowFIE.IsLinkedToSport = chkLinkToSport.Checked;
                    rowFIE.IsActive = 1;
                    rowFIE.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                    requestDS.FileInEvent.AddFileInEventRow(rowFIE);
                    Stream source = fuuploadControl.FileContent;
                    byte[] sourceByte = ReadFully(source);

                    if (!IsPDFMIME(sourceByte))
                    {
                        AjaxPopupMessage("Selected file is not a valid pdf format.");
                        return;
                    }
                                        
                    responseDS = competitionSVC.InsertFile(requestDS, sourceByte);

                    if (responseDS.Response.Count > 0)
                    {
                        if (responseDS.Response[0].ResponseCode == SystemMessage.Generic_Success_Code)
                        {
                            AjaxPopupMessage("File Saved ...!");
                        }
                        else
                        {
                            AjaxPopupMessage("Save File Failed ...!");
                        }
                    }
                    else
                    {
                        AjaxPopupMessage("Save File Failed ...!");
                    }

                    GetFileInEvent();
                }
                else
                {
                    AjaxPopupMessage("Selected file is not a valid pdf format.");
                }
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        protected void GetEventDetails()
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS.EventRow inputRow = requestDS.Event.NewEventRow();
            inputRow.SportID = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);
            inputRow.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);

            requestDS.Event.AddEventRow(inputRow);

            CompetitionClient adminSVC = new CompetitionClient();
            responseDS = adminSVC.GetEventDetails(requestDS);

            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
        }

        protected void DGFileUpload()
        {
            WebBase.BindColumn("dgFileUpload", dgFileUpload);
        }

        protected void GetFileInEvent()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.FileInEventRow row = requestDS.FileInEvent.NewFileInEventRow();
    
            if (ViewState[WebBase.VS_EVENTID] != null)
            {
                row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            if (Request.QueryString[WebBase.QS_EVENTID] != null)
            {
                row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
            }

            requestDS.FileInEvent.AddFileInEventRow(row);

            #region GetFileInEvent
            responseDS = svc.GetFileInEvent(requestDS);
            dgFileUpload.DataSource = responseDS.FileInEvent;
            dgFileUpload.DataBind();
            ViewState[WebBase.VS_FILEINEVENT_DT] = responseDS.FileInEvent;
            #endregion
        }

        protected void DGFileUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string uploadPath = ConfigurationManager.AppSettings[WebBase.QS_FILEPATH];
            string fileName = Path.GetFileName(e.Values[2].ToString());
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.FileInEventRow row = requestDS.FileInEvent.NewFileInEventRow();
            row.FileID = Convert.ToInt32(dgFileUpload.DataKeys[e.RowIndex].Values[requestDS.FileInEvent.FileIDColumn.ColumnName]);
            row.EventID = Convert.ToInt32(dgFileUpload.DataKeys[e.RowIndex].Values[requestDS.FileInEvent.EventIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.FileInEvent.AddFileInEventRow(row);

            CompetitionClient svc = new CompetitionClient();
            try
            { 
                svc.DeleteFileInEvent(requestDS,uploadPath,fileName);
            }
            catch(Exception ex)
            {

            }

            GetFileInEvent();
        }

        protected void DGFileUpload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgFileUpload.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            GetFileInEvent();
        }

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }
    }
}