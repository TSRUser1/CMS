using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

using SVC.Web.WCFAdministration;
using SVC.Web.WCFCompetition;
using SVC.Web.WCFSystemMaintenance;

using SEM.CMS.CL.AR.Common;

namespace SVC.Web
{
    public partial class UpdateSchedule : System.Web.UI.Page
    {
        //use webbase class for these values, name the parameters accordingly
        private const string REQUEST_PARAMETER_ScheduleID = "ScheduleID";
        private const string REQUEST_PARAMETER_ScheduleName = "ScheduleName";
        private const string REQUEST_PARAMETER_ScheduleDateTime = "ScheduleDateTime";
        private const string REQUEST_PARAMETER_Venue = "Venue";
        private const string REQUEST_PARAMETER_Location = "Location";
        private const string REQUEST_PARAMETER_RoundName = "RoundName";
        private const string REQUEST_PARAMETER_MatchNumber = "MatchNumber";
        private const string REQUEST_PARAMETER_CompetitionStage = "CompetitionStage";
        private const string REQUEST_PARAMETER_TotalParticipant = "TotalParticipant";
        private const string REQUEST_PARAMETER_PlayFormatID = "PlayFormatID";
        private const string REQUEST_PARAMETER_GroupCode = "GroupCode";
        private const string REQUEST_PARAMETER_StatusCodeID = "StatusCodeID";
        private const string REQUEST_PARAMETER_HeadToHead = "HeadToHead";
        private const string REQUEST_PARAMETER_IsMedalGame = "IsMedalGame";
        private const string REQUEST_PARAMETER_IsPublishGame = "IsPublishGame";
        private const string REQUEST_PARAMETER_IsOfficial = "IsOfficial";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ProcessRequest(); // put breakpoint here when debug
        }

        public void ProcessRequest()
        {
            string query = Request.Form.ToString();

            try
            {
                HttpContext context = HttpContext.Current;

                bool hasRequest = false;

                #region assignValues
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS responseDS = new CompetitionDS();
                CompetitionClient competitionSVC = new CompetitionClient();
                CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
                if (query.Length > 0)
                {
                    hasRequest = true;
                    var values = HttpUtility.ParseQueryString(query);

                    row.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    row.ScheduleName = Convert.ToString(values.Get(REQUEST_PARAMETER_ScheduleName));
                    row.ScheduleDateTime = DateTime.ParseExact(values.Get(REQUEST_PARAMETER_ScheduleDateTime), "yyyyMMdd HHmmss", null);
                    row.Venue = Convert.ToString(values.Get(REQUEST_PARAMETER_Venue));
                    row.Location = Convert.ToString(values.Get(REQUEST_PARAMETER_Location));
                    row.RoundName = Convert.ToString(values.Get(REQUEST_PARAMETER_RoundName));
                    row.MatchNumber = Convert.ToInt32(values.Get(REQUEST_PARAMETER_MatchNumber));
                    row.CompetitionStage = Convert.ToInt32(values.Get(REQUEST_PARAMETER_CompetitionStage));
                    row.TotalParticipant = Convert.ToInt32(values.Get(REQUEST_PARAMETER_TotalParticipant));
                    row.PlayFormatID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_PlayFormatID));
                    row.GroupCode = Convert.ToString(values.Get(REQUEST_PARAMETER_GroupCode));
                    row.StatusCodeID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_StatusCodeID));
                    row.HeadToHead = Convert.ToBoolean(values.Get(REQUEST_PARAMETER_HeadToHead));
                    row.IsMedalGame = Convert.ToBoolean(values.Get(REQUEST_PARAMETER_IsMedalGame));
                    row.IsPublishStartList = Convert.ToBoolean(values.Get(REQUEST_PARAMETER_IsPublishGame));
                    row.IsOfficial = Convert.ToBoolean(values.Get(REQUEST_PARAMETER_IsOfficial));
                    row.IsActive = 1;

                    row.ModifiedBy = 99;
                }

                requestDS.ScheduleDetail.AddScheduleDetailRow(row);
                #endregion

                #region Process
                if (hasRequest)
                {
                    responseDS = competitionSVC.UpdateScheduleDetail(requestDS);
                }
                else
                {
                    responseDS.Response.AddResponseRow("", "99999", "No request found.");
                }
                #endregion

                #region response

                MemoryStream str = new MemoryStream();
                responseDS.Response.WriteXml(str, true);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                string xmlstr;
                xmlstr = sr.ReadToEnd();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlstr);

                Response.ContentType = "text/xml"; //Must be 'text/xml'
                Response.ContentEncoding = System.Text.Encoding.UTF8; //We'd like UTF-8
                doc.Save(Response.Output); //Save to the text-writer
                #endregion

            }
            catch (Exception ex)
            {
                Response.Write(query
                    + "\n"
                    + "--------------------------------------------------------------------"
                    + ex.ToString());

                AppBase.BusinessErrorHandling(ex, "SEM.CMS.Web.UpdateSchedule");
            }
            Response.End();
        }
    }
}