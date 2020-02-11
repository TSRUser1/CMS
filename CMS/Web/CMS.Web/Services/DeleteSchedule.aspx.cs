using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using SEM.CMS.Web.WCFAdministration;
using SEM.CMS.Web.WCFCompetition;
using SEM.CMS.Web.WCFSystemMaintenance;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Web.Services
{
    public partial class DeleteSchedule : System.Web.UI.Page
    {
        //use webbase class for these values, name the parameters accordingly
        private const string REQUEST_PARAMETER_ScheduleID = "ScheduleID";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ProcessRequest(); // put breakpoint here when debug
        }

        public void ProcessRequest()
        {
            string query = Request.Form.ToString();

            try
            {
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
                var values = HttpUtility.ParseQueryString(query);

                #region assignValues
                if (query.Length > 0)
                {
                    row.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    row.ModifiedBy = 99;
                }
                requestDS.ScheduleDetail.AddScheduleDetailRow(row);
                #endregion

                #region Process
                CompetitionDS responseDS = new CompetitionDS();
                CompetitionClient competitionSVC = new CompetitionClient();
                responseDS = competitionSVC.DeleteSchedule(requestDS);
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

                AppBase.BusinessErrorHandling(ex, "SEM.CMS.Web.DeleteSchedule");
            }
            Response.End();
        }
    }
}