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
    public partial class UpdateResult : System.Web.UI.Page
    {
        //use webbase class for these values, name the parameters accordingly
        private const string REQUEST_PARAMETER_ScheduleID = "ScheduleID";
        private const string REQUEST_PARAMETER_TeamID = "TeamOrParticipantID";
        private const string REQUEST_PARAMETER_Score1 = "Score1";
        private const string REQUEST_PARAMETER_Score2 = "Score2";
        private const string REQUEST_PARAMETER_Score3 = "Score3";
        private const string REQUEST_PARAMETER_Score4 = "Score4";
        private const string REQUEST_PARAMETER_Score5 = "Score5";
        private const string REQUEST_PARAMETER_Score6 = "Score6";
        private const string REQUEST_PARAMETER_Score7 = "Score7";
        private const string REQUEST_PARAMETER_Score8 = "Score8";
        private const string REQUEST_PARAMETER_Score9 = "Score9";
        private const string REQUEST_PARAMETER_Score10 = "Score10";
        private const string REQUEST_PARAMETER_Score11 = "Score11";
        private const string REQUEST_PARAMETER_Score12 = "Score12";
        private const string REQUEST_PARAMETER_Score13 = "Score13";
        private const string REQUEST_PARAMETER_Score14 = "Score14";
        private const string REQUEST_PARAMETER_Score15 = "Score15";
        private const string REQUEST_PARAMETER_Score16 = "Score16";
        private const string REQUEST_PARAMETER_Score17 = "Score17";
        private const string REQUEST_PARAMETER_Score18 = "Score18";
        private const string REQUEST_PARAMETER_Score19 = "Score19";
        private const string REQUEST_PARAMETER_Score20 = "Score20";
        private const string REQUEST_PARAMETER_ScoreFinal = "ScoreFinal";
        private const string REQUEST_PARAMETER_ScoreName1 = "ScoreName1";
        private const string REQUEST_PARAMETER_ScoreName2 = "ScoreName2";
        private const string REQUEST_PARAMETER_ScoreName3 = "ScoreName3";
        private const string REQUEST_PARAMETER_ScoreName4 = "ScoreName4";
        private const string REQUEST_PARAMETER_ScoreName5 = "ScoreName5";
        private const string REQUEST_PARAMETER_ScoreName6 = "ScoreName6";
        private const string REQUEST_PARAMETER_ScoreName7 = "ScoreName7";
        private const string REQUEST_PARAMETER_ScoreName8 = "ScoreName8";
        private const string REQUEST_PARAMETER_ScoreName9 = "ScoreName9";
        private const string REQUEST_PARAMETER_ScoreName10 = "ScoreName10";
        private const string REQUEST_PARAMETER_ScoreName11 = "ScoreName11";
        private const string REQUEST_PARAMETER_ScoreName12 = "ScoreName12";
        private const string REQUEST_PARAMETER_ScoreName13 = "ScoreName13";
        private const string REQUEST_PARAMETER_ScoreName14 = "ScoreName14";
        private const string REQUEST_PARAMETER_ScoreName15 = "ScoreName15";
        private const string REQUEST_PARAMETER_ScoreName16 = "ScoreName16";
        private const string REQUEST_PARAMETER_ScoreName17 = "ScoreName17";
        private const string REQUEST_PARAMETER_ScoreName18 = "ScoreName18";
        private const string REQUEST_PARAMETER_ScoreName19 = "ScoreName19";
        private const string REQUEST_PARAMETER_ScoreName20 = "ScoreName20";
        private const string REQUEST_PARAMETER_ScoreNameFinal = "ScoreFinalName";
        private const string REQUEST_PARAMETER_BreakRecord = "BreakRecord";
        private const string REQUEST_PARAMETER_MedalID = "MedalID";
        private const string REQUEST_PARAMETER_ResultPosition = "ResultPosition";
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
                #region assignValues
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS.ScoreRow scoreRow = requestDS.Score.NewScoreRow();
                var values = HttpUtility.ParseQueryString(query);

                if (query.Length > 0)
                {
                    scoreRow.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    scoreRow.TeamID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_TeamID));

                    scoreRow.Score1 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score1));
                    scoreRow.Score2 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score2));
                    scoreRow.Score3 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score3));
                    scoreRow.Score4 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score4));
                    scoreRow.Score5 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score5));
                    scoreRow.Score6 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score6));
                    scoreRow.Score7 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score7));
                    scoreRow.Score8 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score8));
                    scoreRow.Score9 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score9));
                    scoreRow.Score10 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score10));
                    scoreRow.Score11 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score11));
                    scoreRow.Score12 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score12));
                    scoreRow.Score13 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score13));
                    scoreRow.Score14 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score14));
                    scoreRow.Score15 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score15));
                    scoreRow.Score16 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score16));
                    scoreRow.Score17 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score17));
                    scoreRow.Score18 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score18));
                    scoreRow.Score19 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score19));
                    scoreRow.Score20 = Convert.ToString(values.Get(REQUEST_PARAMETER_Score20));

                    scoreRow.ScoreFinal = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreFinal));
                    scoreRow.BreakRecord = Convert.ToString(values.Get(REQUEST_PARAMETER_BreakRecord));
                    scoreRow.MedalID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_MedalID));
                    scoreRow.ResultPosition = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ResultPosition));

                    scoreRow.CreatedBy = 99;
                }
                requestDS.Score.AddScoreRow(scoreRow);
                #endregion

                #region Process
                CompetitionDS responseDS = new CompetitionDS();
                CompetitionClient competitionSVC = new CompetitionClient();

                CompetitionDS.ScheduleDetailRow scheduleRow = requestDS.ScheduleDetail.NewScheduleDetailRow();
                scheduleRow.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                requestDS.ScheduleDetail.AddScheduleDetailRow(scheduleRow);

                responseDS = competitionSVC.GetSchedule(requestDS);

                bool IsTeamGame = true;
                if (responseDS != null && responseDS.ScheduleDetail.Rows.Count > 0)
                {
                    IsTeamGame = responseDS.ScheduleDetail[0].EventTypeID != Convert.ToInt32(ReferenceNum.EventType.Individual);
                }

                if (IsTeamGame)
                {
                    requestDS.Score[0].TeamID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_TeamID));
                    responseDS = competitionSVC.InsertScoreForTeamInSchedule(requestDS);
                }
                else
                {
                    requestDS.Score[0].ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));
                    requestDS.Score[0].ParticipantID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_TeamID));
                    responseDS = competitionSVC.GetPartcipantAndScore(requestDS);

                    if (responseDS != null && responseDS.Score.Rows.Count > 0)
                    {
                        requestDS.Score[0].ParticipantInScheduleID = responseDS.Score[0].ParticipantInScheduleID;
                    }

                    responseDS = competitionSVC.InsertScoreForParticipantInSchedule(requestDS);
                }
                #endregion

                #region responseOfScoreInsert
                //SystemMessage.Generic_Success_Code;
                string sSystemMsg = "";
                if (responseDS.Response.Rows.Count != 0)
                {
                    if (responseDS.Response[0].ResponseCode == SystemMessage.Generic_Success_Code)
                    {
                        //Insert Score Succesful. Proceed to insert ScoreName
                        #region assignValuesOfScoreName
                        CompetitionDS requestDS_SN = new CompetitionDS();
                        CompetitionDS.ScoreNameRow scoreNameRow = requestDS_SN.ScoreName.NewScoreNameRow();

                        scoreNameRow.ScheduleID = Convert.ToInt32(values.Get(REQUEST_PARAMETER_ScheduleID));

                        scoreNameRow.ScoreName1 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName1));
                        scoreNameRow.ScoreName2 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName2));
                        scoreNameRow.ScoreName3 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName3));
                        scoreNameRow.ScoreName4 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName4));
                        scoreNameRow.ScoreName5 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName5));
                        scoreNameRow.ScoreName6 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName6));
                        scoreNameRow.ScoreName7 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName7));
                        scoreNameRow.ScoreName8 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName8));
                        scoreNameRow.ScoreName9 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName9));
                        scoreNameRow.ScoreName10 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName10));
                        scoreNameRow.ScoreName11 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName11));
                        scoreNameRow.ScoreName12 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName12));
                        scoreNameRow.ScoreName13 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName13));
                        scoreNameRow.ScoreName14 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName14));
                        scoreNameRow.ScoreName15 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName15));
                        scoreNameRow.ScoreName16 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName16));
                        scoreNameRow.ScoreName17 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName17));
                        scoreNameRow.ScoreName18 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName18));
                        scoreNameRow.ScoreName19 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName19));
                        scoreNameRow.ScoreName20 = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreName20));

                        scoreNameRow.ScoreNameFinal = Convert.ToString(values.Get(REQUEST_PARAMETER_ScoreNameFinal));

                        scoreNameRow.CreatedBy = 99;

                        requestDS_SN.ScoreName.AddScoreNameRow(scoreNameRow);
                        #endregion

                        #region ProcessInsertScoreName
                        CompetitionDS responseDS_SN = new CompetitionDS();
                        CompetitionClient competitionSVC_SN = new CompetitionClient();
                        responseDS_SN = competitionSVC_SN.InsertScoreName(requestDS_SN);
                        #endregion
                    }
                    else
                    {
                        //Insert Score Failed
                        sSystemMsg = responseDS.Response[0].ResponseMessage;
                    }
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

                AppBase.BusinessErrorHandling(ex, "SEM.CMS.Web.UpdateResult");
            }
            Response.End();
        }
    }
}