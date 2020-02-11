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
    public partial class DeleteResult : System.Web.UI.Page
    {
        //use webbase class for these values, name the parameters accordingly
        private const string REQUEST_PARAMETER_ScheduleID = "ScheduleID";
        private const string REQUEST_PARAMETER_TeamID = "TeamID";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ProcessRequest();
        }

        public void ProcessRequest()
        {
            string query = Request.Form.ToString();

            try
            {
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS.ScoreRow scoreRow = requestDS.Score.NewScoreRow();
                var values = HttpUtility.ParseQueryString(query);

                #region assignValues
                if (query.Length > 0)
                {
                    scoreRow.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    scoreRow.TeamID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_TeamID));
                    scoreRow.ModifiedBy = 99;
                }
                requestDS.Score.AddScoreRow(scoreRow);
                #endregion

                #region Process
                CompetitionDS responseDS = new CompetitionDS();
                CompetitionClient competitionSVC = new CompetitionClient();
                responseDS = competitionSVC.DeleteScoreByScheduleIDAndTeamID(requestDS);
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
            catch(Exception ex)
            {
                Response.Write(query
                    + "\n"
                    + "--------------------------------------------------------------------"
                    + ex.ToString());

                AppBase.BusinessErrorHandling(ex, "SEM.CMS.Web.DeleteResult");
            }
            Response.End();
        }
    }
}