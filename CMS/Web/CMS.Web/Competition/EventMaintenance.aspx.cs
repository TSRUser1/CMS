using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;  
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

using SEM.CMS.Web.WCFCompetition;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Web
{
    public partial class EventMaintenance : System.Web.UI.Page
    {
        public int sportID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sAccessSports = Session[WebBase.SESSION_ACCESSSPORTS].ToString();
            if (!sAccessSports.Contains("*"))
            {
                divfileUpload.Visible = false;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString[WebBase.QS_SPORTID] != null)
                {
                    ViewState[WebBase.VS_SPORTID] = Request.QueryString[WebBase.QS_SPORTID];
                }

                this.GetEventList();
                this.DGEventDetail();
            }
        }

        protected void GetEventList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();

            // Get Sport ID
            if (ViewState[WebBase.VS_SPORTID] != null && ViewState[WebBase.VS_SPORTID].ToString() != string.Empty)
            {
                row.SportID = Convert.ToInt32(ViewState[WebBase.VS_SPORTID]);
                btnNew.Visible = true;
                btnSearch.Visible = true;
                fieldSetSearch.Visible = true;
            }

            if (!String.IsNullOrEmpty(txtEvent.Text))
            {
                row.EventName = txtEvent.Text;
            }

            requestDS.Event.AddEventRow(row);

            #region GetEventList
            responseDS = svc.GetEventList(requestDS);

            ViewState[WebBase.VS_EVENT_DS] = responseDS;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS eventOutputDS = new CompetitionDS();
            eventOutputDS = (CompetitionDS)ViewState[WebBase.VS_EVENT_DS];
            dgEventDetail.DataSource = eventOutputDS.Event;
            dgEventDetail.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.GetEventList();
            BindData();
        }
        
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string redirectUrl;

            redirectUrl = "~/Competition/EventDetail.aspx?PageMode=New";

            if (ViewState[WebBase.VS_SPORTID] != null && ViewState[WebBase.VS_SPORTID].ToString() != string.Empty)
            {
                redirectUrl += "&SportID=" + ViewState[WebBase.VS_SPORTID].ToString();
            }

            Response.Redirect(redirectUrl);
        }


        protected void btnLoadFromCsv_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = string.Empty;
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionClient svc = new CompetitionClient();

                if (!string.IsNullOrEmpty(btnFileUpload.FileName))
                {
                    extension = Path.GetExtension(btnFileUpload.FileName);
                    if (extension == ".csv")
                    {
                        StreamReader strReader = new StreamReader(btnFileUpload.FileContent);
                        while (!strReader.EndOfStream)
                        {
                            if (!WebBase.IsCharacterNDigitNPunctuationNSpaceOnly(strReader.ReadLine()))
                            {
                                Master.AjaxPopupMessage("Uploaded file contains invalid characters. $, +, <, =, >, ^, `, |, ~ are prohibited in the system.");
                                return;
                            }
                        }
                        Stream fs = btnFileUpload.PostedFile.InputStream;
                        fs.Position = 0;

                        StreamReader sr = new StreamReader(btnFileUpload.FileContent);
                        int rowcount = 0;
                        while (!sr.EndOfStream)
                        {
                            //string[] csvRow = sr.ReadLine().Split(',');
                            string[] csvRow = new string[] { };
                            byte[] byteArray = Encoding.UTF8.GetBytes(sr.ReadLine());
                            MemoryStream stream = new MemoryStream(byteArray);

                            if (rowcount > 0)
                            {
                                using (var parser = new TextFieldParser(stream))
                                {
                                    parser.TextFieldType = FieldType.Delimited;
                                    parser.SetDelimiters(",");
                                    while (!parser.EndOfData)
                                    {
                                        csvRow = parser.ReadFields();
                                    }
                                }

                                CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
                                row.EventID = Convert.ToInt32(csvRow[0]);
                                row.ScheduleName = csvRow[1];
                                if (csvRow[2] != "")
                                {
                                    row.ScheduleDateTime = DateTime.ParseExact(csvRow[2], "d/MM/yyyy H:mm", System.Globalization.CultureInfo.InvariantCulture);
                                }

                                row.Venue = csvRow[3];
                                row.Location = csvRow[4];
                                row.RoundName = csvRow[5];

                                if (csvRow[6] != "")
                                {
                                    row.MatchNumber = Convert.ToInt32(csvRow[6]);
                                }

                                if (csvRow[7] != "")
                                {
                                    row.CompetitionStage = Convert.ToInt32(csvRow[7]);
                                }

                                if (csvRow[8] != "")
                                {
                                    row.TotalParticipant = Convert.ToInt32(csvRow[8]);
                                }

                                if (csvRow[9] != "")
                                {
                                    row.PlayFormatID = Convert.ToInt32(csvRow[9]);
                                }

                                row.GroupCode = csvRow[10]; ;

                                if (csvRow[11] != "")
                                {
                                    row.StatusCodeID = Convert.ToInt32(csvRow[11]);
                                }

                                if (csvRow[12] != "" && Convert.ToInt32(csvRow[12]) == 1)
                                {
                                    row.HeadToHead = true;
                                }
                                else
                                {
                                    row.HeadToHead = false;
                                }

                                if (csvRow[13] != "" && Convert.ToInt32(csvRow[13]) == 1)
                                {
                                    row.IsMedalGame = true;
                                }
                                else
                                {
                                    row.IsMedalGame = false;
                                }

                                if (csvRow[14] != "" && Convert.ToInt32(csvRow[14]) == 1)
                                {
                                    row.IsPublishStartList = true;
                                }
                                else
                                {
                                    row.IsPublishStartList = false;
                                }

                                row.IsActive = 1;
                                row.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                                requestDS.ScheduleDetail.AddScheduleDetailRow(row);
                            }

                            rowcount++;
                        }
                        svc.InsertScheduleDetail(requestDS);
                        AjaxPopupMessage("File upload completed", "");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please select CSV file.');</script>");
                }

            }
            catch(Exception ex)
            {
                AppBase.BusinessErrorHandling(ex, WebBase.GetCurrentMethod());
                AjaxPopupMessage("There was an error in attempt to upload the file. Please check the file format.", "");
            }
        }

        protected void DGEventDetail()
        {
            WebBase.BindColumn("dgEventDetail", dgEventDetail);
            BindData();
        }

        protected void DGEventDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.EventRow row = requestDS.Event.NewEventRow();
            row.EventID = Convert.ToInt32(dgEventDetail.DataKeys[e.RowIndex].Values[requestDS.Event.EventIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.Event.AddEventRow(row);

            CompetitionClient svc = new CompetitionClient();
            svc.DeleteEvent(requestDS);

            GetEventList();
            BindData();
        }

        protected void DGEventDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgEventDetail.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }
    }
}