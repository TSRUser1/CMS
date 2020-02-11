using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MC.DA.CompetitionDataAccess;
using SEM.CMS.CL.MC.DS.CompetitionDataSet;
using System.IO;

namespace SEM.CMS.CL.MC.BF.CompetitionFacade
{
    public class CompetitionBF : AppBase
    {
        string code = "", message = "", result = "";

        #region InsertScheduleDetail
        public CompetitionDS InsertScheduleDetail(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();

                foreach(CompetitionDS.ScheduleDetailRow row in inputDS.ScheduleDetail)
                {
                    resDS = da.InsertScheduleDetail(row);
                }

                if (resDS != null && resDS.ScheduleDetail.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.ScheduleDetail[0].ScheduleID.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScheduleDetail
        public CompetitionDS UpdateScheduleDetail(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateScheduleDetail(inputDS.ScheduleDetail[0]);

                if (resDS != null && resDS.ScheduleDetail.Rows.Count > 0)
                {
                    if (resDS.ScheduleDetail[0].UpdatedRow > 0)
                    {
                        result = resDS.ScheduleDetail[0].UpdatedRow.ToString();
                        code = SystemMessage.Generic_Success_Code;
                        message = SystemMessage.Generic_Success_Msg;
                    }
                    else
                    {
                        code = SystemMessage.Generic_Record_Not_Found_Code;
                        message = SystemMessage.Generic_Record_Not_Found_Msg;
                    }
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Fail_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScheduleExtraDetail
        public CompetitionDS UpdateScheduleExtraDetail(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateScheduleExtraDetail(inputDS.SportEventSchedule[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSchedule
        public CompetitionDS GetSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetSchedule(inputDS.ScheduleDetail[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetXMLSchedule
        public CompetitionDS GetXMLSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetXMLSchedule(inputDS.ScheduleDetail[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetXMLMedalStanding
        public CompetitionDS GetXMLMedalStanding(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetXMLMedalStanding();

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetXMLLatestMedalist
        public CompetitionDS GetXMLLatestMedalist(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetXMLLatestMedalist();

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteSchedule
        public CompetitionDS DeleteSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteSchedule(inputDS.ScheduleDetail[0]);

                if (resDS != null && resDS.ScheduleDetail.Rows.Count > 0)
                {
                    if (resDS.ScheduleDetail[0].UpdatedRow > 0)
                    {
                        result = resDS.ScheduleDetail[0].UpdatedRow.ToString();
                        code = SystemMessage.Generic_Success_Code;
                        message = SystemMessage.Generic_Success_Msg;
                    }
                    else
                    {
                        code = SystemMessage.Generic_Record_Not_Found_Code;
                        message = SystemMessage.Generic_Record_Not_Found_Msg;
                    }
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Fail_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEventList
        public CompetitionDS GetEventList(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetEventList(inputDS.Event[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateEvent
        public CompetitionDS UpdateEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateEvent(inputDS.Event[0]);

                if (resDS.Response.Count == 0)
                {
                    code = SystemMessage.Generic_Fail_Code;
                    message = SystemMessage.Generic_Fail_Msg;
                    resDS.Response.AddResponseRow("", code, message);
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteEvent
        public CompetitionDS DeleteEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteEvent(inputDS.Event[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertEvent
        public CompetitionDS InsertEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertEvent(inputDS.Event[0]);

                if (resDS.Response.Count == 0)
                {
                    code = SystemMessage.Generic_Fail_Code;
                    message = SystemMessage.Generic_Fail_Msg;
                    resDS.Response.AddResponseRow("", code, message);
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEventDetails
        public CompetitionDS GetEventDetails(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetEventDetails(inputDS.Event[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertParticipantDetail
        public CompetitionDS InsertParticipantDetail(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertParticipantDetail(inputDS.ParticipantDetail[0]);

                if (resDS != null && resDS.ParticipantDetail.Rows.Count > 1)
                {
                    code = SystemMessage.User_Exist_Code;
                    message = SystemMessage.User_Exist_Msg;
                }
                else
                {
                    foreach (CompetitionDS.ParticipantInEventRow row in inputDS.ParticipantInEvent)
                    {
                        resDS = da.UpdateParticipantInEvent(row, resDS.ParticipantDetail[0].ParticipantID);
                    }

                    if (resDS != null && resDS.ParticipantInEvent.Rows.Count > 0)
                    {
                        code = SystemMessage.User_Exist_Code;
                        message = SystemMessage.User_Exist_Msg;
                    }
                    else
                    {
                        code = SystemMessage.Generic_Success_Code;
                        message = SystemMessage.Generic_Success_Msg;
                    }
                }

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteParticipant
        public CompetitionDS DeleteParticipant(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteParticipant(inputDS.ParticipantDetail[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateParticipantDetail
        public CompetitionDS UpdateParticipantDetail(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();

                if (inputDS.ParticipantDetail.Rows.Count > 0)
                {
                    resDS = da.UpdateParticipantDetail(inputDS.ParticipantDetail[0]);
                }

                if (resDS != null && resDS.ParticipantDetail.Rows.Count > 0)
                {
                    code = SystemMessage.User_Exist_Code;
                    message = SystemMessage.User_Exist_Msg;
                }
                else
                {
                    int participantID = 0;
                    if (inputDS != null && inputDS.ParticipantDetail.Rows.Count > 0)
                    {
                        participantID = inputDS.ParticipantDetail[0].ParticipantID;
                    }
                    foreach(CompetitionDS.ParticipantInEventRow row in inputDS.ParticipantInEvent)
                    {

                        resDS = da.UpdateParticipantInEvent(row, participantID);
                    }

                    if (resDS != null && resDS.ParticipantInEvent.Rows.Count > 0)
                    {
                        code = SystemMessage.User_Exist_Code;
                        message = SystemMessage.User_Exist_Msg;
                    }
                    else
                    {
                        code = SystemMessage.Generic_Success_Code;
                        message = SystemMessage.Generic_Success_Msg;
                    }
                }

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetGeneralSchedule
        public CompetitionDS GetGeneralSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetGeneralSchedule(inputDS.GeneralSchedule[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStartListParticipantList
        public CompetitionDS GetStartListParticipantList(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetStartListParticipantList(inputDS.ParticipantInSchedule[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStartList
        public CompetitionDS InsertStartList(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertStartList(inputDS.ParticipantInSchedule[0]);

                if (resDS != null && resDS.ParticipantInSchedule.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.ParticipantInSchedule[0].ParticipantInScheduleID.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStartListMaintenance
        public CompetitionDS GetStartListMaintenance(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetStartListMaintenance(inputDS.ParticipantInSchedule[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartList
        public CompetitionDS UpdateStartList(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStartList(inputDS.ParticipantInSchedule[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListAssignTeam
        public CompetitionDS UpdateStartListAssignTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStartListAssignTeam(inputDS.ParticipantInSchedule[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListPosition
        public CompetitionDS UpdateStartListPosition(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStartListPosition(inputDS.ParticipantInSchedule[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListByScheduleIDAndParticipantID
        public CompetitionDS UpdateStartListByScheduleIDAndParticipantID(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStartListByScheduleIDAndParticipantID(inputDS.ParticipantInSchedule[0]);

                if (resDS != null && resDS.ParticipantInSchedule.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.ParticipantInSchedule[0].UpdatedRow.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteStartListParticipant
        public CompetitionDS DeleteStartListParticipant(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteStartListParticipant(inputDS.ParticipantInSchedule[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteStartListByScheduleIDAndParticipantID
        public CompetitionDS DeleteStartListByScheduleIDAndParticipantID(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteStartListByScheduleIDAndParticipantID(inputDS.ParticipantInSchedule[0]);

                if (resDS != null && resDS.ParticipantInSchedule.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.ParticipantInSchedule[0].UpdatedRow.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleHeaderGroupedBySportFilteredByDate
        public CompetitionDS GetScheduleHeaderGroupedBySportFilteredByDate(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetScheduleHeaderGroupedBySportFilteredByDate(inputDS.ScheduleHeaderSport[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleHeaderGroupedByDateFilteredBySport
        public CompetitionDS GetScheduleHeaderGroupedByDateFilteredBySport(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetScheduleHeaderGroupedByDateFilteredBySport(inputDS.ScheduleHeaderDate[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleHeaderGroupedByDateFilteredByCountry
        public CompetitionDS GetScheduleHeaderGroupedByDateFilteredByCountry(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetScheduleHeaderGroupedByDateFilteredByCountry(inputDS.ScheduleHeaderDate[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleList
        public CompetitionDS GetScheduleList(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetScheduleList(inputDS.ScheduleList[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLiveSchedule
        public CompetitionDS GetLiveSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetLiveSchedule(inputDS.ScheduleList[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetCountry
        public CompetitionDS GetCountry(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetCountry(inputDS.Country[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSport
        public CompetitionDS GetSport(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetSport(inputDS.Sport[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSportClass
        public CompetitionDS GetSportClass(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetSportClass(inputDS.SportClass[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantList
        public CompetitionDS GetParticipantList(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantList(inputDS.ParticipantList[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantDetail
        public CompetitionDS GetParticipantDetail(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantDetail(inputDS.ParticipantDetail[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantInTeam
        public CompetitionDS GetParticipantInTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantInTeam(inputDS.ParticipantInEvent[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantInEventForTeam
        public CompetitionDS GetParticipantInEventForTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantInEventForTeam(inputDS.ParticipantDetail[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantResult
        public CompetitionDS GetParticipantResult(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantResult(inputDS.ParticipantResult[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetPartcipantAndScore
        public CompetitionDS GetPartcipantAndScore(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetPartcipantAndScore(inputDS.Score[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeamAndScore
        public CompetitionDS GetTeamAndScore(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetTeamAndScore(inputDS.Score[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScore
        public CompetitionDS UpdateScore(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateScore(inputDS.Score[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertScoreForParticipantInSchedule
        public CompetitionDS InsertScoreForParticipantInSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertScoreForParticipantInSchedule(inputDS.Score[0]);

                if (resDS != null && resDS.Score.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.Score[0].UpdatedRow.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertScoreForTeamInSchedule
        public CompetitionDS InsertScoreForTeamInSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertScoreForTeamInSchedule(inputDS.Score[0]);

                if (resDS != null && resDS.Score.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.Score[0].UpdatedRow.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteScore
        public CompetitionDS DeleteScore(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteScore(inputDS.Score[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteScoreByScheduleIDAndTeamID
        public CompetitionDS DeleteScoreByScheduleIDAndTeamID(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteScoreByScheduleIDAndTeamID(inputDS.Score[0]);

                if (resDS != null && resDS.Score.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.Score[0].UpdatedRow.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetPartcipantAndStatistic
        public CompetitionDS GetPartcipantAndStatistic(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetPartcipantAndStatistic(inputDS.Statistic[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStatisticForParticipantInSchedule
        public CompetitionDS InsertStatisticForParticipantInSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertStatisticForParticipantInSchedule(inputDS.Statistic[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStatistic
        public CompetitionDS UpdateStatistic(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStatistic(inputDS.Statistic[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScoreName
        public CompetitionDS GetScoreName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetScoreName(inputDS.ScoreName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScoreName
        public CompetitionDS UpdateScoreName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateScoreName(inputDS.ScoreName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertScoreName
        public CompetitionDS InsertScoreName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertScoreName(inputDS.ScoreName[0]);

                if (resDS != null && resDS.ScoreName.Rows.Count > 0)
                {
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;
                    result = resDS.ScoreName[0].ScoreNameID.ToString();
                }
                else
                {
                    code = SystemMessage.Generic_Failed_Code;
                    message = SystemMessage.Generic_Failed_Msg;
                }

                resDS.Response.AddResponseRow(result, code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteScoreName
        public CompetitionDS DeleteScoreName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteScoreName(inputDS.ScoreName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStatisticName
        public CompetitionDS GetStatisticName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetStatisticName(inputDS.StatisticName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStatisticName
        public CompetitionDS InsertStatisticName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertStatisticName(inputDS.StatisticName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStatisticName
        public CompetitionDS UpdateStatisticName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStatisticName(inputDS.StatisticName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertFile
        public CompetitionDS InsertFile(CompetitionDS inputDS, byte[] sourcebyte)
        {
            Stream source = new MemoryStream(sourcebyte);
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                string filename = Guid.NewGuid().ToString() + ".pdf";
                string uploadPath = ConfigurationManager.AppSettings[AppBase.AS_FILEPATH];
                string pathString = System.IO.Path.Combine(uploadPath, inputDS.FileInEvent[0].EventID.ToString());
                System.IO.Directory.CreateDirectory(pathString);

                string filePath= System.IO.Path.Combine(pathString, filename);

                inputDS.File[0].FilePath = filePath;
                inputDS.FileInEvent[0].FilePath = filePath;

                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertFile(inputDS.File[0]);

                if (resDS != null && resDS.File.Rows.Count > 0)
                {
                    if (!resDS.File[0].IsFileIDNull())
                    {
                        inputDS.FileInEvent[0].FileID = resDS.File[0].FileID;
                        resDS = da.InsertFileInEvent(inputDS.FileInEvent[0]);
                        using (source)
                        {
                            using (FileStream destination = File.Create(inputDS.FileInEvent[0].FilePath))
                            {
                                source.CopyTo(destination);
                            }
                        }
                        if (resDS != null && resDS.File.Rows.Count > 0)
                        {
                            code = SystemMessage.User_Exist_Code;
                            message = SystemMessage.User_Exist_Msg;
                        }

                        if (resDS.Response.Count == 0)
                        {
                            code = SystemMessage.Generic_Fail_Code;
                            message = SystemMessage.Generic_Fail_Msg;
                            resDS.Response.AddResponseRow("", code, message);
                        }
                    }
                }

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetFileInEvent
        public CompetitionDS GetFileInEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetFileInEvent(inputDS.FileInEvent[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteFileInEvent
        public CompetitionDS DeleteFileInEvent(CompetitionDS inputDS, string path, string fileName)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteFileInEvent(inputDS.FileInEvent[0]);
                var filepath = Directory.GetFiles(Path.GetDirectoryName(path));
                foreach (var file in filepath)
                {
                    if (Path.GetFileName(file) == fileName)
                    {
                        File.Delete(file);
                    }
                }
                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DownloadFile
        public byte[] DownloadFile(string path)
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                string fileName = Path.GetFileName(path);
                // check if exists
                if (fileInfo.Exists)
                {
                    // open stream
                    System.IO.FileStream fileStream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    memoryStream.SetLength(fileStream.Length);
                    fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);

                    memoryStream.Flush();
                    fileStream.Close();
                    memoryStream.Close();
                }
                else
                {
                    throw new System.IO.FileNotFoundException("File not found", fileName);
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return memoryStream.ToArray();
        }
        #endregion

        #region GetFinalRankings
        public CompetitionDS GetFinalRankings(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetFinalRankings(inputDS.FinalRankings[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEventAthletes
        public CompetitionDS GetEventAthletes(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetEventAthletes(inputDS.EventAthletes[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleListForBanner
        public CompetitionDS GetScheduleListForBanner(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetScheduleListForBanner(inputDS.ScheduleList[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSportDetails
        public CompetitionDS GetSportDetails(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetSportDetails(inputDS.SportDetails[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLatestMedalist
        public CompetitionDS GetLatestMedalist(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetLatestMedalist(inputDS.LatestMedalist[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMedalStandings
        public CompetitionDS GetMedalStandings(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetMedalStandings(inputDS.MedalStandings[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMedalStandingsByCountry
        public CompetitionDS GetMedalStandingsByCountry(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetMedalStandingsByCountry(inputDS.MedalStandingsCountry[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSportEventSchedule
        public CompetitionDS GetSportEventSchedule(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetSportEventSchedule(inputDS.SportEventSchedule[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetReferee
        public CompetitionDS GetReferee(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetReferee(inputDS.Referee[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateReferee
        public CompetitionDS UpdateReferee(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateReferee(inputDS.Referee[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertReferee
        public CompetitionDS InsertReferee(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertReferee(inputDS.Referee[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantBiography
        public CompetitionDS GetParticipantBiography(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantBiography(inputDS.ParticipantBiography[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeamBiography
        public CompetitionDS GetTeamBiography(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetTeamBiography(inputDS.TeamBiography[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantInEvent
        public CompetitionDS GetParticipantInEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantInEvent(inputDS.ParticipantInEvent[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMedallist
        public CompetitionDS GetMedallist(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetMedallist(inputDS.Medallist[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMultiMedallist
        public CompetitionDS GetMultiMedallist(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetMultiMedallist(inputDS.MultiMedallist[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetKnockoutSummary
        public CompetitionDS GetKnockoutSummary(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetKnockoutSummary(inputDS.KnockoutSummary[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetKnockoutSummaryForTeam
        public CompetitionDS GetKnockoutSummaryForTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetKnockoutSummaryForTeam(inputDS.KnockoutSummary[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueSummary
        public CompetitionDS GetLeagueSummary(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetLeagueSummary(inputDS.LeagueSummary[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueSummaryForTeam
        public CompetitionDS GetLeagueSummaryForTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetLeagueSummaryForTeam(inputDS.LeagueSummary[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetBrokenRecord
        public CompetitionDS GetBrokenRecord(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetBrokenRecord(inputDS.BrokenRecord[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueForIndividual
        public CompetitionDS GetLeagueForIndividual(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetLeagueForIndividual(inputDS.League[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueForTeam
        public CompetitionDS GetLeagueForTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetLeagueForTeam(inputDS.League[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertLeagueForTeam
        public CompetitionDS InsertLeagueForTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertLeagueForTeam(inputDS.League[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertLeagueForIndividual
        public CompetitionDS InsertLeagueForIndividual(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertLeagueForIndividual(inputDS.League[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateLeague
        public CompetitionDS UpdateLeague(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateLeague(inputDS.League[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeam
        public CompetitionDS GetTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetTeam(inputDS.Team[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateTeam
        public CompetitionDS UpdateTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateTeam(inputDS.Team[0]);

                if (resDS.Response.Count == 0)
                {
                    code = SystemMessage.Generic_Fail_Code;
                    message = SystemMessage.Generic_Fail_Msg;
                    resDS.Response.AddResponseRow("", code, message);
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteTeam
        public CompetitionDS DeleteTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.DeleteTeam(inputDS.Team[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertTeam
        public CompetitionDS InsertTeam(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertTeam(inputDS.Team[0]);

                if (resDS.Response.Count == 0)
                {
                    code = SystemMessage.Generic_Fail_Code;
                    message = SystemMessage.Generic_Fail_Msg;
                    resDS.Response.AddResponseRow("", code, message);
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantEvent
        public CompetitionDS GetParticipantEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetParticipantEvent(inputDS.ParticipantEvent[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeamEvent
        public CompetitionDS GetTeamEvent(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetTeamEvent(inputDS.ParticipantEvent[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStartListName
        public CompetitionDS InsertStartListName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.InsertStartListName(inputDS.StartlistName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListName
        public CompetitionDS UpdateStartListName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.UpdateStartListName(inputDS.StartlistName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStartListName
        public CompetitionDS GetStartListName(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetStartListName(inputDS.StartlistName[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetInitialRecord
        public CompetitionDS GetInitialRecord(CompetitionDS inputDS)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                CompetitionDA da = new CompetitionDA();
                resDS = da.GetInitialRecord(inputDS.InitialRecord[0]);

                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion
    }
}
