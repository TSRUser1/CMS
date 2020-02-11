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
    public partial class UpdateStartList : System.Web.UI.Page
    {
        //use webbase class for these values, name the parameters accordingly
        private const string REQUEST_PARAMETER_ScheduleID = "ScheduleID";
        private const string REQUEST_PARAMETER_ParticipantID = "ParticipantID";
        private const string REQUEST_PARAMETER_ParticipantType = "ParticipantType";
        private const string REQUEST_PARAMETER_StartListName1 = "StartListName1";
        private const string REQUEST_PARAMETER_StartListName2 = "StartListName2";
        private const string REQUEST_PARAMETER_StartListName3 = "StartListName3";
        private const string REQUEST_PARAMETER_StartListName4 = "StartListName4";
        private const string REQUEST_PARAMETER_StartListName5 = "StartListName5";
        private const string REQUEST_PARAMETER_StartListName6 = "StartListName6";
        private const string REQUEST_PARAMETER_StartListName7 = "StartListName7";
        private const string REQUEST_PARAMETER_StartListName8 = "StartListName8";
        private const string REQUEST_PARAMETER_StartListName9 = "StartListName9";
        private const string REQUEST_PARAMETER_StartListName10 = "StartListName10";
        private const string REQUEST_PARAMETER_StartList1 = "StartList1";
        private const string REQUEST_PARAMETER_StartList2 = "StartList2";
        private const string REQUEST_PARAMETER_StartList3 = "StartList3";
        private const string REQUEST_PARAMETER_StartList4 = "StartList4";
        private const string REQUEST_PARAMETER_StartList5 = "StartList5";
        private const string REQUEST_PARAMETER_StartList6 = "StartList6";
        private const string REQUEST_PARAMETER_StartList7 = "StartList7";
        private const string REQUEST_PARAMETER_StartList8 = "StartList8";
        private const string REQUEST_PARAMETER_StartList9 = "StartList9";
        private const string REQUEST_PARAMETER_StartList10 = "StartList10";
        private const string REQUEST_PARAMETER_IsDelete = "IsDelete";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ProcessRequest(); // put breakpoint here when debug
        }

        public void ProcessRequest()
        {
            string query = Request.Form.ToString();
            try
            {
                CompetitionClient competitionSVC = new CompetitionClient();


                CompetitionDS startlistNameRequestDS = new CompetitionDS();
                CompetitionDS startlistNameResponseDS = new CompetitionDS();
                CompetitionDS requestDS = new CompetitionDS();
                var values = HttpUtility.ParseQueryString(query);

                CompetitionDS.StartlistNameRow startListNameRow = startlistNameRequestDS.StartlistName.NewStartlistNameRow();
                if (query.Length > 0)
                {
                    #region StarlistName
                    startListNameRow.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    startListNameRow.StartListName1 = values.Get(REQUEST_PARAMETER_StartListName1);
                    startListNameRow.StartListName2 = values.Get(REQUEST_PARAMETER_StartListName2);
                    startListNameRow.StartListName3 = values.Get(REQUEST_PARAMETER_StartListName3);
                    startListNameRow.StartListName4 = values.Get(REQUEST_PARAMETER_StartListName4);
                    startListNameRow.StartListName5 = values.Get(REQUEST_PARAMETER_StartListName5);
                    startListNameRow.StartListName6 = values.Get(REQUEST_PARAMETER_StartListName6);
                    startListNameRow.StartListName7 = values.Get(REQUEST_PARAMETER_StartListName7);
                    startListNameRow.StartListName8 = values.Get(REQUEST_PARAMETER_StartListName8);
                    startListNameRow.StartListName9 = values.Get(REQUEST_PARAMETER_StartListName9);
                    startListNameRow.StartListName10 = values.Get(REQUEST_PARAMETER_StartListName10);

                    CompetitionDS startlistaNameDS = GetStartListName(Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID)));
                    if (startlistaNameDS != null && startlistaNameDS.StartlistName != null && startlistaNameDS.StartlistName.Count > 0)
                    {
                        startListNameRow.StartListNameID = startlistaNameDS.StartlistName[0].StartListNameID;
                        startListNameRow.ModifiedBy = 99;
                        startlistNameRequestDS.StartlistName.AddStartlistNameRow(startListNameRow);
                        competitionSVC.UpdateStartListName(startlistNameRequestDS);
                    }
                    else
                    {
                        startListNameRow.CreatedBy = 99;
                        startlistNameRequestDS.StartlistName.AddStartlistNameRow(startListNameRow);
                        competitionSVC.InsertStartListName(startlistNameRequestDS);
                    }

                    #endregion

                    #region assignValues
                    CompetitionDS.ParticipantInScheduleRow row = requestDS.ParticipantInSchedule.NewParticipantInScheduleRow();

                    row.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    row.ParticipantID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ParticipantID));
                    row.ParticipantTypeID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ParticipantType));
                    row.StartList1 = values.Get(REQUEST_PARAMETER_StartList1);
                    row.StartList2 = values.Get(REQUEST_PARAMETER_StartList2);
                    row.StartList3 = values.Get(REQUEST_PARAMETER_StartList3);
                    row.StartList4 = values.Get(REQUEST_PARAMETER_StartList4);
                    row.StartList5 = values.Get(REQUEST_PARAMETER_StartList5);
                    row.StartList6 = values.Get(REQUEST_PARAMETER_StartList6);
                    row.StartList7 = values.Get(REQUEST_PARAMETER_StartList7);
                    row.StartList8 = values.Get(REQUEST_PARAMETER_StartList8);
                    row.StartList9 = values.Get(REQUEST_PARAMETER_StartList9);
                    row.StartList10 = values.Get(REQUEST_PARAMETER_StartList10);
                    row.ModifiedBy = 99;

                    requestDS.ParticipantInSchedule.AddParticipantInScheduleRow(row);

                    #endregion

                }
                #region Process
                CompetitionDS responseDS = new CompetitionDS();



                if (Convert.ToBoolean(values.Get(REQUEST_PARAMETER_IsDelete)))
                {
                    responseDS = competitionSVC.DeleteStartListByScheduleIDAndParticipantID(requestDS);
                }
                else
                {
                    responseDS = competitionSVC.UpdateStartListByScheduleIDAndParticipantID(requestDS);
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

                AppBase.BusinessErrorHandling(ex, "SEM.CMS.Web.InsertResult");
            }
            Response.End();
        }

        public CompetitionDS GetStartListName(int scheduleID)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.StartlistNameRow row = requestDS.StartlistName.NewStartlistNameRow();

            // Get ScheduleID
            row.ScheduleID = scheduleID;

            requestDS.StartlistName.AddStartlistNameRow(row);

            #region GetStartListName
            responseDS = svc.GetStartListName(requestDS);
            #endregion

            return responseDS;
        }
    }
}