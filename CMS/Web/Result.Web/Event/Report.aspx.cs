using SEM.CMS.Result.Web.WCFCompetition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Result.Web.Event
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFile();
            }
        }

        protected void GetFile()
        {
            int eventID = 0;
            string fileName = string.Empty;
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    eventID = Convert.ToInt32(Request.QueryString[WebBase.QS_EVENTID]);
                }
                if (Request.QueryString[WebBase.QS_FILENAME] != null)
                {
                    fileName = Request.QueryString[WebBase.QS_FILENAME].ToString();
                }
            }
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS.FileInEventRow row = requestDS.FileInEvent.NewFileInEventRow();
            row.EventID = eventID;
            requestDS.FileInEvent.AddFileInEventRow(row);
            responseDS = svc.GetFileInEvent(requestDS);

            IEnumerable<CompetitionDS.FileInEventRow> fileInEvent = responseDS.FileInEvent;
            //if (eventID != 0)
            //{
            //    fileInEvent = from tb in fileInEvent
            //                where tb.FileGroupID == eventID
            //                select tb;
            //}

            var entry = from tb in fileInEvent
                           where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.Entry)
                           select tb;
            var schedule = from tb in fileInEvent
                            where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.Schedule)
                            select tb;
            var startlist = from tb in fileInEvent
                            where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.Startlist)
                            select tb;
            var result = from tb in fileInEvent
                         where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.Result)
                         select tb;
            var medal = from tb in fileInEvent
                         where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.Medal)
                         select tb;
            var summary = from tb in fileInEvent
                         where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.Summary)
                          select tb;
            var offComm = from tb in fileInEvent
                          where tb.FileGroupID == Convert.ToInt32(ReferenceNum.FileGroupType.OffcialCommunication)
                          select tb;

            dlSchedule.DataSource = schedule;
            dlSchedule.DataBind();
            dlStartList.DataSource = startlist;
            dlStartList.DataBind();
            dlResult.DataSource = result;
            dlResult.DataBind();
            dlEntry.DataSource = entry;
            dlEntry.DataBind();
            dlMedal.DataSource = medal;
            dlMedal.DataBind();
            dlSummary.DataSource = summary;
            dlSummary.DataBind();
            dlOffComm.DataSource = offComm;
            dlOffComm.DataBind();

            if (!string.IsNullOrEmpty(fileName) && eventID > 0)
            {
                var resultFile = from tb in fileInEvent
                                 where tb.EventID == eventID && tb.FileName == fileName
                                 select tb;

                if (resultFile.Count() == 1)
                {
                    CompetitionClient ccsvc = new CompetitionClient();
                    byte[] byteArray = ccsvc.DownloadFile(resultFile.FirstOrDefault().FilePath);
                    Response.Clear();
                    Response.BinaryWrite(byteArray);
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
                    Response.AddHeader("Content-Length", byteArray.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.End();
                    Response.Close();
                }
            }
        }

        protected void ButtonDownloadContent(object sender, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                string path = e.CommandArgument.ToString();
                string filename = ((LinkButton)e.Item.FindControl("ButtonDownload")).Text + ".pdf";

                CompetitionClient svc = new CompetitionClient();
                byte[] byteArray = svc.DownloadFile(path);
                Response.Clear();
                Response.BinaryWrite(byteArray);
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.AddHeader("Content-Length", byteArray.Length.ToString());
                Response.ContentType = "application/octet-stream";
            }
        }
    }
}