using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

using SEM.CMS.Web.WCFCompetition;
using System.IO;

namespace SEM.CMS.Web.Schedule
{
    public partial class ScheduleMaintainance : System.Web.UI.Page
    {
        protected CompetitionDS.SportEventScheduleRow sportEventScheduleRow;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetSportEventSchedule();
                this.GetSchedule();
                this.DGScheduleDetail();
            }
        }

        protected void GetSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
                {
                    row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
                }
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
            }
            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            #region GetSchedule
            responseDS = svc.GetSchedule(requestDS);

            ViewState[WebBase.VS_COMPETITION_DS] = responseDS;
            #endregion
        }

        protected void GetSportEventSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportEventScheduleRow row = requestDS.SportEventSchedule.NewSportEventScheduleRow();

            // Get Event ID
            if (Request.QueryString[WebBase.QS_EVENTID] != null)
            {
                row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
            }

            requestDS.SportEventSchedule.AddSportEventScheduleRow(row);

            #region GetSchedule
            responseDS = svc.GetSportEventSchedule(requestDS);
            if (responseDS.SportEventSchedule.Count > 0)
            {
                sportEventScheduleRow = responseDS.SportEventSchedule[0];
            }
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_COMPETITION_DS];
            dgScheduleDetail.DataSource = competitionDS.ScheduleDetail;
            dgScheduleDetail.DataBind();

            #region Bind Schedule Details
            if (sportEventScheduleRow != null)
            {
                lblEventDetails.Text = sportEventScheduleRow.SportName.ToUpper() + " - " + sportEventScheduleRow.EventName;
                imgSportImage.ImageUrl = sportEventScheduleRow.ImageFilePath;
            }
            else
            {
                lblEventDetails.Visible = false;
                imgSportImage.Visible = false;
            }
            #endregion
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string eventID = "";
            if (Request.QueryString[WebBase.QS_EVENTID] != null)
            {
                eventID = Request.QueryString[WebBase.QS_EVENTID];
            }

            Response.Redirect("~/Competition/ScheduleDetails.aspx?PageMode=New&EventID=" + eventID);
        }

        protected void DGScheduleDetail()
        {
            WebBase.BindColumn("dgScheduleDetail", dgScheduleDetail);
            BindData();
        }

        protected void DGScheduleDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
            row.ScheduleID = Convert.ToInt32(dgScheduleDetail.DataKeys[e.RowIndex].Values[requestDS.ScheduleDetail.ScheduleIDColumn.ColumnName]);
            row.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            CompetitionClient svc = new CompetitionClient();
            svc.DeleteSchedule(requestDS);

            GetSchedule();
            BindData();
        }

        protected void DGScheduleDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgScheduleDetail.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
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
                                row.EventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                                row.ScheduleName = csvRow[0];
                                if (csvRow[1] != "")
                                {
                                    row.ScheduleDateTime = DateTime.ParseExact(csvRow[1], "d/MM/yyyy H:mm", System.Globalization.CultureInfo.InvariantCulture);
                                }

                                row.Venue = csvRow[2];
                                row.Location = csvRow[3];
                                row.RoundName = csvRow[4];

                                if (csvRow[5] != "")
                                {
                                    row.MatchNumber = Convert.ToInt32(csvRow[5]);
                                }

                                if (csvRow[6] != "")
                                {
                                    row.CompetitionStage = Convert.ToInt32(csvRow[6]);
                                }

                                if (csvRow[7] != "")
                                {
                                    row.TotalParticipant = Convert.ToInt32(csvRow[7]);
                                }

                                if (csvRow[8] != "")
                                {
                                    row.PlayFormatID = Convert.ToInt32(csvRow[8]);
                                }

                                row.GroupCode = csvRow[9]; ;

                                if (csvRow[10] != "")
                                {
                                    row.StatusCodeID = Convert.ToInt32(csvRow[10]);
                                }

                                if (csvRow[11] != "" && Convert.ToInt32(csvRow[11]) == 1)
                                {
                                    row.HeadToHead = true;
                                }
                                else
                                {
                                    row.HeadToHead = false;
                                }

                                if (csvRow[12] != "" && Convert.ToInt32(csvRow[12]) == 1)
                                {
                                    row.IsMedalGame = true;
                                }
                                else
                                {
                                    row.IsMedalGame = false;
                                }

                                if (csvRow[13] != "" && Convert.ToInt32(csvRow[13]) == 1)
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
                        GetSchedule();
                        BindData();
                        AjaxPopupMessage("File upload completed", "");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please select CSV file.');</script>");
                }
            }
            catch (Exception ex)
            {
                AjaxPopupMessage("There was an error in attempt to upload the file. Please check the file format.", "");
            }
        }

        protected void AjaxPopupMessage(string sMessage, string sRedirect = "")
        {
            Master.AjaxPopupMessage(sMessage, sRedirect);
        }
    }
}