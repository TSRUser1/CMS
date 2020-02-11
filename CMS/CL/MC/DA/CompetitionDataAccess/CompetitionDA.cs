using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MC.DS.CompetitionDataSet;
using System.Data.Common;
using System.Data;

namespace SEM.CMS.CL.MC.DA.CompetitionDataAccess
{
    public class CompetitionDA : AppBase
    {
        string code = "", message = "";

        #region InsertScheduleDetail
        public CompetitionDS InsertScheduleDetail(CompetitionDS.ScheduleDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertScheduleDetail");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsScheduleNameNull())
                {
                    db.AddInParameter(dbCommand, "s_ScheduleName", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScheduleName", DbType.String, inputRow.ScheduleName);
                }

                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_ScheduleDateTime", DbType.DateTime, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_ScheduleDateTime", DbType.DateTime, inputRow.ScheduleDateTime);
                }

                if (inputRow.IsVenueNull())
                {
                    db.AddInParameter(dbCommand, "s_Venue", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Venue", DbType.String, inputRow.Venue);
                }

                if (inputRow.IsLocationNull())
                {
                    db.AddInParameter(dbCommand, "s_Location", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Location", DbType.String, inputRow.Location);
                }

                if (inputRow.IsRoundNameNull())
                {
                    db.AddInParameter(dbCommand, "s_RoundName", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RoundName", DbType.String, inputRow.RoundName);
                }

                if (inputRow.IsMatchNumberNull())
                {
                    db.AddInParameter(dbCommand, "n_MatchNumber", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MatchNumber", DbType.Int32, inputRow.MatchNumber);
                }

                if (inputRow.IsCompetitionStageNull())
                {
                    db.AddInParameter(dbCommand, "n_CompetitionStage", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CompetitionStage", DbType.Int32, inputRow.CompetitionStage);
                }

                if (inputRow.IsTotalParticipantNull())
                {
                    db.AddInParameter(dbCommand, "n_TotalParticipant", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TotalParticipant", DbType.Int32, inputRow.TotalParticipant);
                }

                if (inputRow.IsPlayFormatIDNull())
                {
                    db.AddInParameter(dbCommand, "n_PlayFormatID", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_PlayFormatID", DbType.Int32, inputRow.PlayFormatID);
                }

                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, inputRow.GroupCode);
                }

                if (inputRow.IsStatusCodeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_StatusCodeID", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_StatusCodeID", DbType.String, inputRow.StatusCodeID);
                }

                if (inputRow.IsHeadToHeadNull())
                {
                    db.AddInParameter(dbCommand, "b_HeadToHead", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_HeadToHead", DbType.Boolean, inputRow.HeadToHead);
                }

                if (inputRow.IsIsMedalGameNull())
                {
                    db.AddInParameter(dbCommand, "b_IsMedalGame", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsMedalGame", DbType.Boolean, inputRow.IsMedalGame);
                }

                if (inputRow.IsIsPublishStartListNull())
                {
                    db.AddInParameter(dbCommand, "b_IsPublishStartList", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsPublishStartList", DbType.Boolean, inputRow.IsPublishStartList);
                }

                if (inputRow.IsIsOfficialNull())
                {
                    db.AddInParameter(dbCommand, "b_IsOfficial", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsOfficial", DbType.Boolean, inputRow.IsOfficial);
                }

                if (inputRow.IsIsPublishScheduleNull())
                {
                    db.AddInParameter(dbCommand, "b_IsPublishSchedule", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsPublishSchedule", DbType.Boolean, inputRow.IsPublishSchedule);
                }

                if (inputRow.IsIsGenerateLeagueSummaryNull())
                {
                    db.AddInParameter(dbCommand, "b_IsGenerateLeagueSummary", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsGenerateLeagueSummary", DbType.Boolean, inputRow.IsGenerateLeagueSummary);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScheduleDetail
        public CompetitionDS UpdateScheduleDetail(CompetitionDS.ScheduleDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateScheduleDetail");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);

                if (inputRow.IsScheduleNameNull())
                {
                    db.AddInParameter(dbCommand, "s_ScheduleName", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScheduleName", DbType.String, inputRow.ScheduleName);
                }

                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_ScheduleDateTime", DbType.DateTime, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_ScheduleDateTime", DbType.DateTime, inputRow.ScheduleDateTime);
                }

                if (inputRow.IsVenueNull())
                {
                    db.AddInParameter(dbCommand, "s_Venue", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Venue", DbType.String, inputRow.Venue);
                }

                if (inputRow.IsLocationNull())
                {
                    db.AddInParameter(dbCommand, "s_Location", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Location", DbType.String, inputRow.Location);
                }

                if (inputRow.IsRoundNameNull())
                {
                    db.AddInParameter(dbCommand, "s_RoundName", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RoundName", DbType.String, inputRow.RoundName);
                }

                if (inputRow.IsMatchNumberNull())
                {
                    db.AddInParameter(dbCommand, "n_MatchNumber", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MatchNumber", DbType.Int32, inputRow.MatchNumber);
                }

                if (inputRow.IsMatchNumberNull())
                {
                    db.AddInParameter(dbCommand, "n_CompetitionStage", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CompetitionStage", DbType.Int32, inputRow.CompetitionStage);
                }

                if (inputRow.IsTotalParticipantNull())
                {
                    db.AddInParameter(dbCommand, "n_TotalParticipant", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TotalParticipant", DbType.Int32, inputRow.TotalParticipant);
                }

                if (inputRow.IsPlayFormatIDNull())
                {
                    db.AddInParameter(dbCommand, "n_PlayFormatID", DbType.Int32, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_PlayFormatID", DbType.Int32, inputRow.PlayFormatID);
                }

                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, inputRow.GroupCode);
                }

                if (inputRow.IsMatchNumberNull())
                {
                    db.AddInParameter(dbCommand, "n_StatusCodeID", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_StatusCodeID", DbType.String, inputRow.StatusCodeID);
                }

                if (inputRow.IsMatchNumberNull())
                {
                    db.AddInParameter(dbCommand, "b_HeadToHead", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_HeadToHead", DbType.Boolean, inputRow.HeadToHead);
                }

                if (inputRow.IsIsMedalGameNull())
                {
                    db.AddInParameter(dbCommand, "b_IsMedalGame", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsMedalGame", DbType.Boolean, inputRow.IsMedalGame);
                }
                if (inputRow.IsIsPublishStartListNull())
                {
                    db.AddInParameter(dbCommand, "b_IsPublishStartList", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsPublishStartList", DbType.Boolean, inputRow.IsPublishStartList);
                }

                if (inputRow.IsIsOfficialNull())
                {
                    db.AddInParameter(dbCommand, "b_IsOfficial", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsOfficial", DbType.Boolean, inputRow.IsOfficial);
                }

                if (inputRow.IsIsPublishScheduleNull())
                {
                    db.AddInParameter(dbCommand, "b_IsPublishSchedule", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsPublishSchedule", DbType.Boolean, inputRow.IsPublishSchedule);
                }

                if (inputRow.IsIsGenerateLeagueSummaryNull())
                {
                    db.AddInParameter(dbCommand, "b_IsGenerateLeagueSummary", DbType.Boolean, null);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsGenerateLeagueSummary", DbType.Boolean, inputRow.IsGenerateLeagueSummary);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScheduleExtraDetail
        public CompetitionDS UpdateScheduleExtraDetail(CompetitionDS.SportEventScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateScheduleExtraDetail");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsEventFooterNoteNull())
                {
                    db.AddInParameter(dbCommand, "s_ScheduleFooterNote", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScheduleFooterNote", DbType.String, inputRow.ScheduleFooterNote);
                }

                if (inputRow.IsEventFooterNoteNull())
                {
                    db.AddInParameter(dbCommand, "s_EventFooterNote", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_EventFooterNote", DbType.String, inputRow.EventFooterNote);
                }

                if (inputRow.IsStartListFooterNull())
                {
                    db.AddInParameter(dbCommand, "s_StartListFooter", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListFooter", DbType.String, inputRow.StartListFooter);
                }

                if (inputRow.IsIsTogleHtmlModeNull())
                {
                    db.AddInParameter(dbCommand, "b_IsTogleHtmlMode", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsTogleHtmlMode", DbType.Boolean, inputRow.IsTogleHtmlMode);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.SportEventSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteSchedule
        public CompetitionDS DeleteSchedule(CompetitionDS.ScheduleDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteSchedule");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSchedule
        public CompetitionDS GetSchedule(CompetitionDS.ScheduleDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetSchedule");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetXMLSchedule
        public CompetitionDS GetXMLSchedule(CompetitionDS.ScheduleDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetXMLSchedule");

                #region Parameters Initialization
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "@d_ScheduleDateTime", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@d_ScheduleDateTime", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetXMLMedalStanding
        public CompetitionDS GetXMLMedalStanding()
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetXMLMedalStanding");

                #region Parameters Initialization
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.MedalStandings.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetXMLLatestMedalist
        public CompetitionDS GetXMLLatestMedalist()
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetXMLLatestMedalist");

                #region Parameters Initialization
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.LatestMedalist.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEventList
        public CompetitionDS GetEventList(CompetitionDS.EventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetEventList");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsEventNameNull())
                {
                    db.AddInParameter(dbCommand, "s_EventName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_EventName", DbType.String, inputRow.EventName);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Event.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateEvent
        public CompetitionDS UpdateEvent(CompetitionDS.EventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateEvent");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                db.AddInParameter(dbCommand, "s_EventName", DbType.String, inputRow.EventName);
                db.AddInParameter(dbCommand, "s_EventCode", DbType.String, inputRow.EventCode);
                if(inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                db.AddInParameter(dbCommand, "n_GenderID", DbType.Int32, inputRow.GenderID);
                db.AddInParameter(dbCommand, "n_PlayFormatID", DbType.Int32, inputRow.PlayFormatID);
                db.AddInParameter(dbCommand, "n_EventTypeID", DbType.Int32, inputRow.EventTypeID);

                db.AddInParameter(dbCommand, "b_IsShowResult", DbType.Boolean, inputRow.IsShowResult);
                db.AddInParameter(dbCommand, "b_IsShowMedal", DbType.Boolean, inputRow.IsShowMedal);
                db.AddInParameter(dbCommand, "b_IsShowAthelete", DbType.Boolean, inputRow.IsShowAthelete);
                db.AddInParameter(dbCommand, "b_IsShowReport", DbType.Boolean, inputRow.IsShowReport);
                db.AddInParameter(dbCommand, "b_IsShowRecord", DbType.Boolean, inputRow.IsShowRecord);
                db.AddInParameter(dbCommand, "b_IsShowSummary", DbType.Boolean, inputRow.IsShowSummary);

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Event.TableName);

                code = SystemMessage.Generic_Success_Code;
                message = SystemMessage.Generic_Success_Msg;
                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteEvent
        public CompetitionDS DeleteEvent(CompetitionDS.EventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteEvent");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Event.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertEvent
        public CompetitionDS InsertEvent(CompetitionDS.EventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                int eventID = 0;
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertEvent");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_EventName", DbType.String, inputRow.EventName);
                db.AddInParameter(dbCommand, "s_EventCode", DbType.String, inputRow.EventCode);
                db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                db.AddInParameter(dbCommand, "n_GenderID", DbType.Int32, inputRow.GenderID);
                db.AddInParameter(dbCommand, "n_PlayFormatID", DbType.Int32, inputRow.PlayFormatID);
                db.AddInParameter(dbCommand, "n_EventTypeID", DbType.Int32, inputRow.EventTypeID);

                db.AddInParameter(dbCommand, "b_IsShowResult", DbType.Boolean, inputRow.IsShowResult);
                db.AddInParameter(dbCommand, "b_IsShowMedal", DbType.Boolean, inputRow.IsShowMedal);
                db.AddInParameter(dbCommand, "b_IsShowAthelete", DbType.Boolean, inputRow.IsShowAthelete);
                db.AddInParameter(dbCommand, "b_IsShowReport", DbType.Boolean, inputRow.IsShowReport);
                db.AddInParameter(dbCommand, "b_IsShowRecord", DbType.Boolean, inputRow.IsShowRecord);
                db.AddInParameter(dbCommand, "b_IsShowSummary", DbType.Boolean, inputRow.IsShowSummary);

                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                db.AddOutParameter(dbCommand, "n_EventID", DbType.Int32, eventID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Event.TableName);
                CompetitionDS.EventRow row = resDS.Event.NewEventRow();
                row.EventID = Convert.ToInt32(db.GetParameterValue(dbCommand, "n_EventID"));
                resDS.Event.AddEventRow(row);

                code = SystemMessage.Generic_Success_Code;
                message = SystemMessage.Generic_Success_Msg;
                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEventDetails
        public CompetitionDS GetEventDetails(CompetitionDS.EventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetEventDetails");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }

                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Event.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertParticipantDetail
        public CompetitionDS InsertParticipantDetail(CompetitionDS.ParticipantDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                int participantID = 0;
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertParticipantDetail");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_FullName", DbType.String, inputRow.FullName);
                db.AddInParameter(dbCommand, "s_FamilyName", DbType.String, inputRow.FamilyName);
                db.AddInParameter(dbCommand, "s_GivenName", DbType.String, inputRow.GivenName);
                if(inputRow.IsHeightNull())
                {
                    db.AddInParameter(dbCommand, "n_Height", DbType.Decimal, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Height", DbType.Decimal, inputRow.Height);
                }
                if(inputRow.IsWeightNull())
                {
                    db.AddInParameter(dbCommand, "n_Weight", DbType.Decimal, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Weight", DbType.Decimal, inputRow.Weight);
                }
                db.AddInParameter(dbCommand, "s_AccreditationNumber", DbType.String, inputRow.AccreditationNumber);
                if(inputRow.IsDateOfBirthNull())
                {
                    db.AddInParameter(dbCommand, "d_DateOfBirth", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_DateOfBirth", DbType.DateTime, inputRow.DateOfBirth);
                }
                db.AddInParameter(dbCommand, "s_IPCNo", DbType.String, inputRow.IPCNo);
                db.AddInParameter(dbCommand, "n_GenderID", DbType.Int32, inputRow.GenderID);
                db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                db.AddInParameter(dbCommand, "s_PassportNumber", DbType.String, inputRow.PassportNumber);
                if (inputRow.IsMainCategoryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_MainCategoryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MainCategoryID", DbType.Int32, inputRow.MainCategoryID);
                }
                if (inputRow.IsCardPhotoPathNull())
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPath", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPath", DbType.String, inputRow.CardPhotoPath);
                }
                if (inputRow.IsCardPhotoPathThumbnailNull())
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathThumbnail", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathThumbnail", DbType.String, inputRow.CardPhotoPathThumbnail);
                }
                if (inputRow.IsCardPhotoPathExternalNull())
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathExternal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathExternal", DbType.String, inputRow.CardPhotoPathExternal);
                }
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                db.AddOutParameter(dbCommand, "n_ParticipantID", DbType.Int32, participantID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateParticipantDetail
        public CompetitionDS UpdateParticipantDetail(CompetitionDS.ParticipantDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateParticipantDetail");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                if(inputRow.IsFullNameNull())
                {
                    db.AddInParameter(dbCommand, "s_FullName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_FullName", DbType.String, inputRow.FullName);
                }
                if(inputRow.IsFamilyNameNull())
                {
                    db.AddInParameter(dbCommand, "s_FamilyName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_FamilyName", DbType.String, inputRow.FamilyName);
                }
                if(inputRow.IsGivenNameNull())
                {
                    db.AddInParameter(dbCommand, "s_GivenName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GivenName", DbType.String, inputRow.GivenName);
                }
                if (inputRow.IsHeightNull())
                {
                    db.AddInParameter(dbCommand, "n_Height", DbType.Decimal, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Height", DbType.Decimal, inputRow.Height);
                }
                if (inputRow.IsWeightNull())
                {
                    db.AddInParameter(dbCommand, "n_Weight", DbType.Decimal, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Weight", DbType.Decimal, inputRow.Weight);
                }
                if (inputRow.IsAccreditationNumberNull())
                {
                    db.AddInParameter(dbCommand, "s_AccreditationNumber", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_AccreditationNumber", DbType.String, inputRow.AccreditationNumber);
                }
                if (inputRow.IsDateOfBirthNull())
                {
                    db.AddInParameter(dbCommand, "d_DateOfBirth", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_DateOfBirth", DbType.DateTime, inputRow.DateOfBirth);
                }
                if (inputRow.IsIPCNoNull())
                {
                    db.AddInParameter(dbCommand, "s_IPCNo", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_IPCNo", DbType.String, inputRow.IPCNo);
                }
                if(inputRow.IsGenderIDNull())
                {
                    db.AddInParameter(dbCommand, "n_GenderID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_GenderID", DbType.Int32, inputRow.GenderID);
                }
                if(inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if(inputRow.IsPassportNumberNull())
                {
                    db.AddInParameter(dbCommand, "s_PassportNumber", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_PassportNumber", DbType.String, inputRow.PassportNumber);
                }
                if (inputRow.IsMainCategoryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_MainCategoryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MainCategoryID", DbType.Int32, inputRow.MainCategoryID);
                }
                if(inputRow.IsCardPhotoPathNull())
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPath", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPath", DbType.String, inputRow.CardPhotoPath);
                }
                if (inputRow.IsCardPhotoPathThumbnailNull())
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathThumbnail", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathThumbnail", DbType.String, inputRow.CardPhotoPathThumbnail);
                }
                if (inputRow.IsCardPhotoPathExternalNull())
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathExternal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CardPhotoPathExternal", DbType.String, inputRow.CardPhotoPathExternal);
                }
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteParticipant
        public CompetitionDS DeleteParticipant(CompetitionDS.ParticipantDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteParticipant");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetGeneralSchedule
        public CompetitionDS GetGeneralSchedule(CompetitionDS.GeneralScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetGeneralSchedule");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.GeneralSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStartListParticipantList
        public CompetitionDS GetStartListParticipantList(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetStartListParticipantList");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStartList
        public CompetitionDS InsertStartList(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertStartList");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);

                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }


                if (inputRow.IsParticipantTypeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantTypeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantTypeID", DbType.Int32, inputRow.ParticipantTypeID);
                }

                if (inputRow.IsStartList1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList1", DbType.String, inputRow.StartList1);
                }

                if (inputRow.IsStartList2Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList2", DbType.String, inputRow.StartList2);
                }

                if (inputRow.IsStartList3Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList3", DbType.String, inputRow.StartList3);
                }

                if (inputRow.IsStartList4Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList4", DbType.String, inputRow.StartList4);
                }

                if (inputRow.IsStartList5Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList5", DbType.String, inputRow.StartList5);
                }

                if (inputRow.IsStartList6Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList6", DbType.String, inputRow.StartList6);
                }

                if (inputRow.IsStartList7Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList7", DbType.String, inputRow.StartList7);
                }

                if (inputRow.IsStartList8Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList8", DbType.String, inputRow.StartList8);
                }

                if (inputRow.IsStartList9Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList9", DbType.String, inputRow.StartList9);
                }

                if (inputRow.IsStartList10Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList10", DbType.String, inputRow.StartList10);
                }

                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStartListMaintenance
        public CompetitionDS GetStartListMaintenance(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetStartListMaintenance");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartList
        public CompetitionDS UpdateStartList(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateStartList");

                #region Parameters Initialization
                if (inputRow.IsParticipantInScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, inputRow.ParticipantInScheduleID);
                }
                
                if (inputRow.IsParticipantTypeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantTypeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantTypeID", DbType.Int32, inputRow.ParticipantTypeID);
                }

                if (inputRow.IsStartList1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList1", DbType.String, inputRow.StartList1);
                }

                if (inputRow.IsStartList2Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList2", DbType.String, inputRow.StartList2);
                }

                if (inputRow.IsStartList3Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList3", DbType.String, inputRow.StartList3);
                }

                if (inputRow.IsStartList4Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList4", DbType.String, inputRow.StartList4);
                }

                if (inputRow.IsStartList5Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList5", DbType.String, inputRow.StartList5);
                }

                if (inputRow.IsStartList6Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList6", DbType.String, inputRow.StartList6);
                }

                if (inputRow.IsStartList7Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList7", DbType.String, inputRow.StartList7);
                }

                if (inputRow.IsStartList8Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList8", DbType.String, inputRow.StartList8);
                }

                if (inputRow.IsStartList9Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList9", DbType.String, inputRow.StartList9);
                }

                if (inputRow.IsStartList10Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList10", DbType.String, inputRow.StartList10);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListAssignTeam
        public CompetitionDS UpdateStartListAssignTeam(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateStartListAssignTeam");

                #region Parameters Initialization
                if (inputRow.IsParticipantInScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, inputRow.ParticipantInScheduleID);
                }
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListPosition
        public CompetitionDS UpdateStartListPosition(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateStartListPosition");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }
                if (inputRow.IsSortIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SortID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SortID", DbType.Int32, inputRow.SortID);
                }
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListByScheduleIDAndParticipantID
        public CompetitionDS UpdateStartListByScheduleIDAndParticipantID(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateStartListByScheduleIDAndParticipantID");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }

                if (inputRow.IsParticipantTypeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantTypeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantTypeID", DbType.Int32, inputRow.ParticipantTypeID);
                }

                if (inputRow.IsStartList1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList1", DbType.String, inputRow.StartList1);
                }

                if (inputRow.IsStartList2Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList2", DbType.String, inputRow.StartList2);
                }

                if (inputRow.IsStartList3Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList3", DbType.String, inputRow.StartList3);
                }

                if (inputRow.IsStartList4Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList4", DbType.String, inputRow.StartList4);
                }

                if (inputRow.IsStartList5Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList5", DbType.String, inputRow.StartList5);
                }

                if (inputRow.IsStartList6Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList6", DbType.String, inputRow.StartList6);
                }

                if (inputRow.IsStartList7Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList7", DbType.String, inputRow.StartList7);
                }

                if (inputRow.IsStartList8Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList8", DbType.String, inputRow.StartList8);
                }

                if (inputRow.IsStartList9Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList9", DbType.String, inputRow.StartList9);
                }

                if (inputRow.IsStartList10Null())
                {
                    db.AddInParameter(dbCommand, "s_StartList10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartList10", DbType.String, inputRow.StartList10);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteStartListParticipant
        public CompetitionDS DeleteStartListParticipant(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteStartListParticipant");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, inputRow.ParticipantInScheduleID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteStartListByScheduleIDAndParticipantID
        public CompetitionDS DeleteStartListByScheduleIDAndParticipantID(CompetitionDS.ParticipantInScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteStartListByScheduleIDAndPArticipantID");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleHeaderGroupedBySportFilteredByDate
        public CompetitionDS GetScheduleHeaderGroupedBySportFilteredByDate(CompetitionDS.ScheduleHeaderSportRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetScheduleHeaderGroupedBySportFilteredByDate");

                #region Parameters Initialization
                if (inputRow.IsDateNull())
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, inputRow.Date);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleHeaderSport.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleHeaderGroupedByDateFilteredBySport
        public CompetitionDS GetScheduleHeaderGroupedByDateFilteredBySport(CompetitionDS.ScheduleHeaderDateRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetScheduleHeaderGroupedByDateFilteredBySport");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleHeaderDate.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleHeaderGroupedByDateFilteredByCountry
        public CompetitionDS GetScheduleHeaderGroupedByDateFilteredByCountry(CompetitionDS.ScheduleHeaderDateRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetScheduleHeaderGroupedByDateFilteredByCountry");

                #region Parameters Initialization
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleHeaderDate.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleList
        public CompetitionDS GetScheduleList(CompetitionDS.ScheduleListRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetScheduleList");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                if (inputRow.IsParticipantID1Null())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID1);
                }
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                if (inputRow.IsIsEndStateNull())
                {
                    db.AddInParameter(dbCommand, "b_IsEndState", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsEndState", DbType.Boolean, inputRow.IsEndState);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleList.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLiveSchedule
        public CompetitionDS GetLiveSchedule(CompetitionDS.ScheduleListRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetLiveSchedule");

                #region Parameters Initialization
                if (inputRow.IsStartDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_StartDateTime", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_StartDateTime", DbType.DateTime, inputRow.StartDateTime);
                }

                if (inputRow.IsEndDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_EndDateTime", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_EndDateTime", DbType.DateTime, inputRow.EndDateTime);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleList.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetCountry
        public CompetitionDS GetCountry(CompetitionDS.CountryRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetCountry");

                #region Parameters Initialization
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Country.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSport
        public CompetitionDS GetSport(CompetitionDS.SportRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetSport");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Sport.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSportClass
        public CompetitionDS GetSportClass(CompetitionDS.SportClassRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetSportClass");

                #region Parameters Initialization
                if (inputRow.IsSportClassIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportClassID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportClassID", DbType.Int32, inputRow.SportClassID);
                }
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.SportClass.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantList
        public CompetitionDS GetParticipantList(CompetitionDS.ParticipantListRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantList");

                #region Parameters Initialization
                if (inputRow.IsFullNameNull())
                {
                    db.AddInParameter(dbCommand, "s_FullName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_FullName", DbType.String, inputRow.FullName);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantList.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantDetail
        public CompetitionDS GetParticipantDetail(CompetitionDS.ParticipantDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipant");

                #region Parameters Initialization
                if (inputRow.IsFullNameNull())
                {
                    db.AddInParameter(dbCommand, "s_FullName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_FullName", DbType.String, inputRow.FullName);
                }

                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }

                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }

                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsPassportNumberNull())
                {
                    db.AddInParameter(dbCommand, "s_PassportNumber", DbType.String, string.Empty);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_PassportNumber", DbType.String, inputRow.PassportNumber);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantInTeam
        public CompetitionDS GetParticipantInTeam(CompetitionDS.ParticipantInEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantInTeam");

                #region Parameters Initialization
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantInEventForTeam
        public CompetitionDS GetParticipantInEventForTeam(CompetitionDS.ParticipantDetailRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantInEventForTeam");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantResult
        public CompetitionDS GetParticipantResult(CompetitionDS.ParticipantResultRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantResult");

                #region Parameters Initialization
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantResult.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetPartcipantAndScore
        public CompetitionDS GetPartcipantAndScore(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetPartcipantAndScore");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeamAndScore
        public CompetitionDS GetTeamAndScore(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetTeamAndScore");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScore
        public CompetitionDS UpdateScore(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateScore");

                #region Parameters Initialization
                if (inputRow.IsScoreIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScoreID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScoreID", DbType.Int32, inputRow.ScoreID);
                }

                if (inputRow.IsScore1Null())
                {
                    db.AddInParameter(dbCommand, "s_Score1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score1", DbType.String, inputRow.Score1);
                }

                if (inputRow.IsScore2Null())
                {
                    db.AddInParameter(dbCommand, "s_Score2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score2", DbType.String, inputRow.Score2);
                }

                if (inputRow.IsScore3Null())
                {
                    db.AddInParameter(dbCommand, "s_Score3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score3", DbType.String, inputRow.Score3);
                }

                if (inputRow.IsScore4Null())
                {
                    db.AddInParameter(dbCommand, "s_Score4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score4", DbType.String, inputRow.Score4);
                }

                if (inputRow.IsScore5Null())
                {
                    db.AddInParameter(dbCommand, "s_Score5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score5", DbType.String, inputRow.Score5);
                }

                if (inputRow.IsScore6Null())
                {
                    db.AddInParameter(dbCommand, "s_Score6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score6", DbType.String, inputRow.Score6);
                }

                if (inputRow.IsScore7Null())
                {
                    db.AddInParameter(dbCommand, "s_Score7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score7", DbType.String, inputRow.Score7);
                }

                if (inputRow.IsScore8Null())
                {
                    db.AddInParameter(dbCommand, "s_Score8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score8", DbType.String, inputRow.Score8);
                }

                if (inputRow.IsScore9Null())
                {
                    db.AddInParameter(dbCommand, "s_Score9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score9", DbType.String, inputRow.Score9);
                }

                if (inputRow.IsScore10Null())
                {
                    db.AddInParameter(dbCommand, "s_Score10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score10", DbType.String, inputRow.Score10);
                }


                if (inputRow.IsScore11Null())
                {
                    db.AddInParameter(dbCommand, "s_Score11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score11", DbType.String, inputRow.Score11);
                }

                if (inputRow.IsScore12Null())
                {
                    db.AddInParameter(dbCommand, "s_Score12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score12", DbType.String, inputRow.Score12);
                }

                if (inputRow.IsScore13Null())
                {
                    db.AddInParameter(dbCommand, "s_Score13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score13", DbType.String, inputRow.Score13);
                }

                if (inputRow.IsScore14Null())
                {
                    db.AddInParameter(dbCommand, "s_Score14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score14", DbType.String, inputRow.Score14);
                }

                if (inputRow.IsScore15Null())
                {
                    db.AddInParameter(dbCommand, "s_Score15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score15", DbType.String, inputRow.Score15);
                }

                if (inputRow.IsScore16Null())
                {
                    db.AddInParameter(dbCommand, "s_Score16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score16", DbType.String, inputRow.Score16);
                }

                if (inputRow.IsScore17Null())
                {
                    db.AddInParameter(dbCommand, "s_Score17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score17", DbType.String, inputRow.Score17);
                }

                if (inputRow.IsScore18Null())
                {
                    db.AddInParameter(dbCommand, "s_Score18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score18", DbType.String, inputRow.Score18);
                }

                if (inputRow.IsScore19Null())
                {
                    db.AddInParameter(dbCommand, "s_Score19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score19", DbType.String, inputRow.Score19);
                }

                if (inputRow.IsScore20Null())
                {
                    db.AddInParameter(dbCommand, "s_Score20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score20", DbType.String, inputRow.Score20);
                }

                if (inputRow.IsScoreFinalNull())
                {
                    db.AddInParameter(dbCommand, "s_ScoreFinal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreFinal", DbType.String, inputRow.ScoreFinal);
                }

                if (inputRow.IsBreakRecordNull())
                {
                    db.AddInParameter(dbCommand, "s_BreakRecord", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_BreakRecord", DbType.String, inputRow.BreakRecord);
                }

                if (inputRow.IsMedalIDNull())
                {
                    db.AddInParameter(dbCommand, "n_MedalID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MedalID", DbType.Int32, inputRow.MedalID);
                }

                if (inputRow.IsResultPositionNull())
                {
                    db.AddInParameter(dbCommand, "n_ResultPosition", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ResultPosition", DbType.Int32, inputRow.ResultPosition);
                }

                if (inputRow.IsRemarksNull())
                {
                    db.AddInParameter(dbCommand, "s_Remarks", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Remarks", DbType.String, inputRow.Remarks);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertScoreForParticipantInSchedule
        public CompetitionDS InsertScoreForParticipantInSchedule(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertScoreForParticipantInSchedule");

                #region Parameters Initialization
                if (inputRow.IsParticipantInScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, inputRow.ParticipantInScheduleID);
                }

                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                if (inputRow.IsScore1Null())
                {
                    db.AddInParameter(dbCommand, "s_Score1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score1", DbType.String, inputRow.Score1);
                }

                if (inputRow.IsScore2Null())
                {
                    db.AddInParameter(dbCommand, "s_Score2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score2", DbType.String, inputRow.Score2);
                }

                if (inputRow.IsScore3Null())
                {
                    db.AddInParameter(dbCommand, "s_Score3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score3", DbType.String, inputRow.Score3);
                }

                if (inputRow.IsScore4Null())
                {
                    db.AddInParameter(dbCommand, "s_Score4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score4", DbType.String, inputRow.Score4);
                }

                if (inputRow.IsScore5Null())
                {
                    db.AddInParameter(dbCommand, "s_Score5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score5", DbType.String, inputRow.Score5);
                }

                if (inputRow.IsScore6Null())
                {
                    db.AddInParameter(dbCommand, "s_Score6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score6", DbType.String, inputRow.Score6);
                }

                if (inputRow.IsScore7Null())
                {
                    db.AddInParameter(dbCommand, "s_Score7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score7", DbType.String, inputRow.Score7);
                }

                if (inputRow.IsScore8Null())
                {
                    db.AddInParameter(dbCommand, "s_Score8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score8", DbType.String, inputRow.Score8);
                }

                if (inputRow.IsScore9Null())
                {
                    db.AddInParameter(dbCommand, "s_Score9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score9", DbType.String, inputRow.Score9);
                }

                if (inputRow.IsScore10Null())
                {
                    db.AddInParameter(dbCommand, "s_Score10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score10", DbType.String, inputRow.Score10);
                }


                if (inputRow.IsScore11Null())
                {
                    db.AddInParameter(dbCommand, "s_Score11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score11", DbType.String, inputRow.Score11);
                }

                if (inputRow.IsScore12Null())
                {
                    db.AddInParameter(dbCommand, "s_Score12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score12", DbType.String, inputRow.Score12);
                }

                if (inputRow.IsScore13Null())
                {
                    db.AddInParameter(dbCommand, "s_Score13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score13", DbType.String, inputRow.Score13);
                }

                if (inputRow.IsScore14Null())
                {
                    db.AddInParameter(dbCommand, "s_Score14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score14", DbType.String, inputRow.Score14);
                }

                if (inputRow.IsScore15Null())
                {
                    db.AddInParameter(dbCommand, "s_Score15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score15", DbType.String, inputRow.Score15);
                }

                if (inputRow.IsScore16Null())
                {
                    db.AddInParameter(dbCommand, "s_Score16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score16", DbType.String, inputRow.Score16);
                }

                if (inputRow.IsScore17Null())
                {
                    db.AddInParameter(dbCommand, "s_Score17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score17", DbType.String, inputRow.Score17);
                }

                if (inputRow.IsScore18Null())
                {
                    db.AddInParameter(dbCommand, "s_Score18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score18", DbType.String, inputRow.Score18);
                }

                if (inputRow.IsScore19Null())
                {
                    db.AddInParameter(dbCommand, "s_Score19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score19", DbType.String, inputRow.Score19);
                }

                if (inputRow.IsScore20Null())
                {
                    db.AddInParameter(dbCommand, "s_Score20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score20", DbType.String, inputRow.Score20);
                }

                if (inputRow.IsScoreFinalNull())
                {
                    db.AddInParameter(dbCommand, "s_ScoreFinal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreFinal", DbType.String, inputRow.ScoreFinal);
                }

                if (inputRow.IsBreakRecordNull())
                {
                    db.AddInParameter(dbCommand, "s_BreakRecord", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_BreakRecord", DbType.String, inputRow.BreakRecord);
                }

                if (inputRow.IsMedalIDNull())
                {
                    db.AddInParameter(dbCommand, "n_MedalID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MedalID", DbType.Int32, inputRow.MedalID);
                }

                if (inputRow.IsResultPositionNull())
                {
                    db.AddInParameter(dbCommand, "n_ResultPosition", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ResultPosition", DbType.Int32, inputRow.ResultPosition);
                }

                if (inputRow.IsRemarksNull())
                {
                    db.AddInParameter(dbCommand, "s_Remarks", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Remarks", DbType.String, inputRow.Remarks);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertScoreForTeamInSchedule
        public CompetitionDS InsertScoreForTeamInSchedule(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertScoreForTeamInSchedule");

                #region Parameters Initialization
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }

                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                if (inputRow.IsScore1Null())
                {
                    db.AddInParameter(dbCommand, "s_Score1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score1", DbType.String, inputRow.Score1);
                }

                if (inputRow.IsScore2Null())
                {
                    db.AddInParameter(dbCommand, "s_Score2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score2", DbType.String, inputRow.Score2);
                }

                if (inputRow.IsScore3Null())
                {
                    db.AddInParameter(dbCommand, "s_Score3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score3", DbType.String, inputRow.Score3);
                }

                if (inputRow.IsScore4Null())
                {
                    db.AddInParameter(dbCommand, "s_Score4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score4", DbType.String, inputRow.Score4);
                }

                if (inputRow.IsScore5Null())
                {
                    db.AddInParameter(dbCommand, "s_Score5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score5", DbType.String, inputRow.Score5);
                }

                if (inputRow.IsScore6Null())
                {
                    db.AddInParameter(dbCommand, "s_Score6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score6", DbType.String, inputRow.Score6);
                }

                if (inputRow.IsScore7Null())
                {
                    db.AddInParameter(dbCommand, "s_Score7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score7", DbType.String, inputRow.Score7);
                }

                if (inputRow.IsScore8Null())
                {
                    db.AddInParameter(dbCommand, "s_Score8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score8", DbType.String, inputRow.Score8);
                }

                if (inputRow.IsScore9Null())
                {
                    db.AddInParameter(dbCommand, "s_Score9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score9", DbType.String, inputRow.Score9);
                }

                if (inputRow.IsScore10Null())
                {
                    db.AddInParameter(dbCommand, "s_Score10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score10", DbType.String, inputRow.Score10);
                }


                if (inputRow.IsScore11Null())
                {
                    db.AddInParameter(dbCommand, "s_Score11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score11", DbType.String, inputRow.Score11);
                }

                if (inputRow.IsScore12Null())
                {
                    db.AddInParameter(dbCommand, "s_Score12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score12", DbType.String, inputRow.Score12);
                }

                if (inputRow.IsScore13Null())
                {
                    db.AddInParameter(dbCommand, "s_Score13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score13", DbType.String, inputRow.Score13);
                }

                if (inputRow.IsScore14Null())
                {
                    db.AddInParameter(dbCommand, "s_Score14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score14", DbType.String, inputRow.Score14);
                }

                if (inputRow.IsScore15Null())
                {
                    db.AddInParameter(dbCommand, "s_Score15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score15", DbType.String, inputRow.Score15);
                }

                if (inputRow.IsScore16Null())
                {
                    db.AddInParameter(dbCommand, "s_Score16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score16", DbType.String, inputRow.Score16);
                }

                if (inputRow.IsScore17Null())
                {
                    db.AddInParameter(dbCommand, "s_Score17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score17", DbType.String, inputRow.Score17);
                }

                if (inputRow.IsScore18Null())
                {
                    db.AddInParameter(dbCommand, "s_Score18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score18", DbType.String, inputRow.Score18);
                }

                if (inputRow.IsScore19Null())
                {
                    db.AddInParameter(dbCommand, "s_Score19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score19", DbType.String, inputRow.Score19);
                }

                if (inputRow.IsScore20Null())
                {
                    db.AddInParameter(dbCommand, "s_Score20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Score20", DbType.String, inputRow.Score20);
                }

                if (inputRow.IsScoreFinalNull())
                {
                    db.AddInParameter(dbCommand, "s_ScoreFinal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreFinal", DbType.String, inputRow.ScoreFinal);
                }

                if (inputRow.IsBreakRecordNull())
                {
                    db.AddInParameter(dbCommand, "s_BreakRecord", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_BreakRecord", DbType.String, inputRow.BreakRecord);
                }

                if (inputRow.IsMedalIDNull())
                {
                    db.AddInParameter(dbCommand, "n_MedalID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_MedalID", DbType.Int32, inputRow.MedalID);
                }

                if (inputRow.IsResultPositionNull())
                {
                    db.AddInParameter(dbCommand, "n_ResultPosition", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ResultPosition", DbType.Int32, inputRow.ResultPosition);
                }

                if (inputRow.IsRemarksNull())
                {
                    db.AddInParameter(dbCommand, "s_Remarks", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Remarks", DbType.String, inputRow.Remarks);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteScore
        public CompetitionDS DeleteScore(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteScore");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScoreID", DbType.Int32, inputRow.ScoreID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteScoreByScheduleIDAndTeamID
        public CompetitionDS DeleteScoreByScheduleIDAndTeamID(CompetitionDS.ScoreRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteScoreByScheduleIDAndTeamID");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Score.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetPartcipantAndStatistic
        public CompetitionDS GetPartcipantAndStatistic(CompetitionDS.StatisticRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetPartcipantAndStatistic");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Statistic.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStatisticForParticipantInSchedule
        public CompetitionDS InsertStatisticForParticipantInSchedule(CompetitionDS.StatisticRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertStatisticForParticipantInSchedule");

                #region Parameters Initialization
                if (inputRow.IsParticipantInScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInScheduleID", DbType.Int32, inputRow.ParticipantInScheduleID);
                }

                if (inputRow.IsStatistic1Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic1", DbType.String, inputRow.Statistic1);
                }

                if (inputRow.IsStatistic2Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic2", DbType.String, inputRow.Statistic2);
                }

                if (inputRow.IsStatistic3Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic3", DbType.String, inputRow.Statistic3);
                }

                if (inputRow.IsStatistic4Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic4", DbType.String, inputRow.Statistic4);
                }

                if (inputRow.IsStatistic5Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic5", DbType.String, inputRow.Statistic5);
                }

                if (inputRow.IsStatistic6Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic6", DbType.String, inputRow.Statistic6);
                }

                if (inputRow.IsStatistic7Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic7", DbType.String, inputRow.Statistic7);
                }

                if (inputRow.IsStatistic8Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic8", DbType.String, inputRow.Statistic8);
                }

                if (inputRow.IsStatistic9Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic9", DbType.String, inputRow.Statistic9);
                }

                if (inputRow.IsStatistic10Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic10", DbType.String, inputRow.Statistic10);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Statistic.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStatistic
        public CompetitionDS UpdateStatistic(CompetitionDS.StatisticRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateStatistic");

                #region Parameters Initialization
                if (inputRow.IsStatisticIDNull())
                {
                    db.AddInParameter(dbCommand, "n_StatisticID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_StatisticID", DbType.Int32, inputRow.StatisticID);
                }

                if (inputRow.IsStatistic1Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic1", DbType.String, inputRow.Statistic1);
                }

                if (inputRow.IsStatistic2Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic2", DbType.String, inputRow.Statistic2);
                }

                if (inputRow.IsStatistic3Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic3", DbType.String, inputRow.Statistic3);
                }

                if (inputRow.IsStatistic4Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic4", DbType.String, inputRow.Statistic4);
                }

                if (inputRow.IsStatistic5Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic5", DbType.String, inputRow.Statistic5);
                }

                if (inputRow.IsStatistic6Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic6", DbType.String, inputRow.Statistic6);
                }

                if (inputRow.IsStatistic7Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic7", DbType.String, inputRow.Statistic7);
                }

                if (inputRow.IsStatistic8Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic8", DbType.String, inputRow.Statistic8);
                }

                if (inputRow.IsStatistic9Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic9", DbType.String, inputRow.Statistic9);
                }

                if (inputRow.IsStatistic10Null())
                {
                    db.AddInParameter(dbCommand, "s_Statistic10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Statistic10", DbType.String, inputRow.Statistic10);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Statistic.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScoreName
        public CompetitionDS GetScoreName(CompetitionDS.ScoreNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetScoreName");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScoreName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateScoreName
        public CompetitionDS UpdateScoreName(CompetitionDS.ScoreNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateScoreName");

                #region Parameters Initialization
                if (inputRow.IsScoreNameIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScoreNameID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScoreNameID", DbType.Int32, inputRow.ScoreNameID);
                }

                if (inputRow.IsScoreName1Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName1", DbType.String, inputRow.ScoreName1);
                }

                if (inputRow.IsScoreName2Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName2", DbType.String, inputRow.ScoreName2);
                }

                if (inputRow.IsScoreName3Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName3", DbType.String, inputRow.ScoreName3);
                }

                if (inputRow.IsScoreName4Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName4", DbType.String, inputRow.ScoreName4);
                }

                if (inputRow.IsScoreName5Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName5", DbType.String, inputRow.ScoreName5);
                }

                if (inputRow.IsScoreName6Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName6", DbType.String, inputRow.ScoreName6);
                }

                if (inputRow.IsScoreName7Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName7", DbType.String, inputRow.ScoreName7);
                }

                if (inputRow.IsScoreName8Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName8", DbType.String, inputRow.ScoreName8);
                }

                if (inputRow.IsScoreName9Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName9", DbType.String, inputRow.ScoreName9);
                }

                if (inputRow.IsScoreName10Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName10", DbType.String, inputRow.ScoreName10);
                }


                if (inputRow.IsScoreName11Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName11", DbType.String, inputRow.ScoreName11);
                }

                if (inputRow.IsScoreName12Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName12", DbType.String, inputRow.ScoreName12);
                }

                if (inputRow.IsScoreName13Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName13", DbType.String, inputRow.ScoreName13);
                }

                if (inputRow.IsScoreName14Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName14", DbType.String, inputRow.ScoreName14);
                }

                if (inputRow.IsScoreName15Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName15", DbType.String, inputRow.ScoreName15);
                }

                if (inputRow.IsScoreName16Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName16", DbType.String, inputRow.ScoreName16);
                }

                if (inputRow.IsScoreName17Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName17", DbType.String, inputRow.ScoreName17);
                }

                if (inputRow.IsScoreName18Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName18", DbType.String, inputRow.ScoreName18);
                }

                if (inputRow.IsScoreName19Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName19", DbType.String, inputRow.ScoreName19);
                }

                if (inputRow.IsScoreName20Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName20", DbType.String, inputRow.ScoreName20);
                }

                if (inputRow.IsScoreNameFinalNull())
                {
                    db.AddInParameter(dbCommand, "s_ScoreNameFinal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreNameFinal", DbType.String, inputRow.ScoreNameFinal);
                }

                if (inputRow.IsIsVisible1Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible1", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible1", DbType.Boolean, inputRow.IsVisible1);
                }

                if (inputRow.IsIsVisible2Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible2", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible2", DbType.Boolean, inputRow.IsVisible2);
                }

                if (inputRow.IsIsVisible3Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible3", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible3", DbType.Boolean, inputRow.IsVisible3);
                }

                if (inputRow.IsIsVisible4Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible4", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible4", DbType.Boolean, inputRow.IsVisible4);
                }

                if (inputRow.IsIsVisible5Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible5", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible5", DbType.Boolean, inputRow.IsVisible5);
                }

                if (inputRow.IsIsVisible6Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible6", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible6", DbType.Boolean, inputRow.IsVisible6);
                }

                if (inputRow.IsIsVisible7Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible7", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible7", DbType.Boolean, inputRow.IsVisible7);
                }

                if (inputRow.IsIsVisible8Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible8", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible8", DbType.Boolean, inputRow.IsVisible8);
                }

                if (inputRow.IsIsVisible9Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible9", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible9", DbType.Boolean, inputRow.IsVisible9);
                }

                if (inputRow.IsIsVisible10Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible10", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible10", DbType.Boolean, inputRow.IsVisible10);
                }

                if (inputRow.IsIsVisible11Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible11", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible11", DbType.Boolean, inputRow.IsVisible11);
                }

                if (inputRow.IsIsVisible12Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible12", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible12", DbType.Boolean, inputRow.IsVisible12);
                }

                if (inputRow.IsIsVisible13Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible13", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible13", DbType.Boolean, inputRow.IsVisible13);
                }

                if (inputRow.IsIsVisible14Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible14", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible14", DbType.Boolean, inputRow.IsVisible14);
                }

                if (inputRow.IsIsVisible15Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible15", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible15", DbType.Boolean, inputRow.IsVisible15);
                }

                if (inputRow.IsIsVisible16Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible16", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible16", DbType.Boolean, inputRow.IsVisible16);
                }

                if (inputRow.IsIsVisible17Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible17", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible17", DbType.Boolean, inputRow.IsVisible17);
                }

                if (inputRow.IsIsVisible18Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible18", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible18", DbType.Boolean, inputRow.IsVisible18);
                }

                if (inputRow.IsIsVisible19Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible19", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible19", DbType.Boolean, inputRow.IsVisible19);
                }

                if (inputRow.IsIsVisible20Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible20", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible20", DbType.Boolean, inputRow.IsVisible20);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScoreName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertScoreName
        public CompetitionDS InsertScoreName(CompetitionDS.ScoreNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertScoreName");

                #region Parameters Initialization
                if (inputRow.IsScoreName1Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName1", DbType.String, inputRow.ScoreName1);
                }

                if (inputRow.IsScoreName2Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName2", DbType.String, inputRow.ScoreName2);
                }

                if (inputRow.IsScoreName3Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName3", DbType.String, inputRow.ScoreName3);
                }

                if (inputRow.IsScoreName4Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName4", DbType.String, inputRow.ScoreName4);
                }

                if (inputRow.IsScoreName5Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName5", DbType.String, inputRow.ScoreName5);
                }

                if (inputRow.IsScoreName6Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName6", DbType.String, inputRow.ScoreName6);
                }

                if (inputRow.IsScoreName7Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName7", DbType.String, inputRow.ScoreName7);
                }

                if (inputRow.IsScoreName8Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName8", DbType.String, inputRow.ScoreName8);
                }

                if (inputRow.IsScoreName9Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName9", DbType.String, inputRow.ScoreName9);
                }

                if (inputRow.IsScoreName10Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName10", DbType.String, inputRow.ScoreName10);
                }


                if (inputRow.IsScoreName11Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName11", DbType.String, inputRow.ScoreName11);
                }

                if (inputRow.IsScoreName12Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName12", DbType.String, inputRow.ScoreName12);
                }

                if (inputRow.IsScoreName13Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName13", DbType.String, inputRow.ScoreName13);
                }

                if (inputRow.IsScoreName14Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName14", DbType.String, inputRow.ScoreName14);
                }

                if (inputRow.IsScoreName15Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName15", DbType.String, inputRow.ScoreName15);
                }

                if (inputRow.IsScoreName16Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName16", DbType.String, inputRow.ScoreName16);
                }

                if (inputRow.IsScoreName17Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName17", DbType.String, inputRow.ScoreName17);
                }

                if (inputRow.IsScoreName18Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName18", DbType.String, inputRow.ScoreName18);
                }

                if (inputRow.IsScoreName19Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName19", DbType.String, inputRow.ScoreName19);
                }

                if (inputRow.IsScoreName20Null())
                {
                    db.AddInParameter(dbCommand, "s_ScoreName20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreName20", DbType.String, inputRow.ScoreName20);
                }
                
                if (inputRow.IsScoreNameFinalNull())
                {
                    db.AddInParameter(dbCommand, "s_ScoreNameFinal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_ScoreNameFinal", DbType.String, inputRow.ScoreNameFinal);
                }

                if (inputRow.IsIsVisible1Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible1", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible1", DbType.Boolean, inputRow.IsVisible1);
                }

                if (inputRow.IsIsVisible2Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible2", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible2", DbType.Boolean, inputRow.IsVisible2);
                }

                if (inputRow.IsIsVisible3Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible3", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible3", DbType.Boolean, inputRow.IsVisible3);
                }

                if (inputRow.IsIsVisible4Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible4", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible4", DbType.Boolean, inputRow.IsVisible4);
                }

                if (inputRow.IsIsVisible5Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible5", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible5", DbType.Boolean, inputRow.IsVisible5);
                }

                if (inputRow.IsIsVisible6Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible6", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible6", DbType.Boolean, inputRow.IsVisible6);
                }

                if (inputRow.IsIsVisible7Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible7", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible7", DbType.Boolean, inputRow.IsVisible7);
                }

                if (inputRow.IsIsVisible8Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible8", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible8", DbType.Boolean, inputRow.IsVisible8);
                }

                if (inputRow.IsIsVisible9Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible9", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible9", DbType.Boolean, inputRow.IsVisible9);
                }

                if (inputRow.IsIsVisible10Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible10", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible10", DbType.Boolean, inputRow.IsVisible10);
                }

                if (inputRow.IsIsVisible11Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible11", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible11", DbType.Boolean, inputRow.IsVisible11);
                }

                if (inputRow.IsIsVisible12Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible12", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible12", DbType.Boolean, inputRow.IsVisible12);
                }

                if (inputRow.IsIsVisible13Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible13", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible13", DbType.Boolean, inputRow.IsVisible13);
                }

                if (inputRow.IsIsVisible14Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible14", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible14", DbType.Boolean, inputRow.IsVisible14);
                }

                if (inputRow.IsIsVisible15Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible15", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible15", DbType.Boolean, inputRow.IsVisible15);
                }

                if (inputRow.IsIsVisible16Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible16", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible16", DbType.Boolean, inputRow.IsVisible16);
                }

                if (inputRow.IsIsVisible17Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible17", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible17", DbType.Boolean, inputRow.IsVisible17);
                }

                if (inputRow.IsIsVisible18Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible18", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible18", DbType.Boolean, inputRow.IsVisible18);
                }

                if (inputRow.IsIsVisible19Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible19", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible19", DbType.Boolean, inputRow.IsVisible19);
                }

                if (inputRow.IsIsVisible20Null())
                {
                    db.AddInParameter(dbCommand, "z_IsVisible20", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "z_IsVisible20", DbType.Boolean, inputRow.IsVisible20);
                }

                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScoreName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteScoreName
        public CompetitionDS DeleteScoreName(CompetitionDS.ScoreNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteScoreName");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ScoreNameID", DbType.Int32, inputRow.ScoreNameID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScoreName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStatisticName
        public CompetitionDS GetStatisticName(CompetitionDS.StatisticNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetStatisticName");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.StatisticName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStatisticName
        public CompetitionDS InsertStatisticName(CompetitionDS.StatisticNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertStatisticName");

                #region Parameters Initialization
                if (inputRow.IsStatisticName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName1", DbType.String, inputRow.StatisticName1);
                }

                if (inputRow.IsStatisticName2Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName2", DbType.String, inputRow.StatisticName2);
                }

                if (inputRow.IsStatisticName3Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName3", DbType.String, inputRow.StatisticName3);
                }

                if (inputRow.IsStatisticName4Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName4", DbType.String, inputRow.StatisticName4);
                }

                if (inputRow.IsStatisticName5Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName5", DbType.String, inputRow.StatisticName5);
                }

                if (inputRow.IsStatisticName6Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName6", DbType.String, inputRow.StatisticName6);
                }

                if (inputRow.IsStatisticName7Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName7", DbType.String, inputRow.StatisticName7);
                }

                if (inputRow.IsStatisticName8Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName8", DbType.String, inputRow.StatisticName8);
                }

                if (inputRow.IsStatisticName9Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName9", DbType.String, inputRow.StatisticName9);
                }

                if (inputRow.IsStatisticName10Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName10", DbType.String, inputRow.StatisticName10);
                }

                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.StatisticName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStatisticName
        public CompetitionDS UpdateStatisticName(CompetitionDS.StatisticNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateStatisticName");

                #region Parameters Initialization
                if (inputRow.IsStatisticNameIDNull())
                {
                    db.AddInParameter(dbCommand, "n_StatisticNameID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_StatisticNameID", DbType.Int32, inputRow.StatisticNameID);
                }

                if (inputRow.IsStatisticName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName1", DbType.String, inputRow.StatisticName1);
                }

                if (inputRow.IsStatisticName2Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName2", DbType.String, inputRow.StatisticName2);
                }

                if (inputRow.IsStatisticName3Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName3", DbType.String, inputRow.StatisticName3);
                }

                if (inputRow.IsStatisticName4Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName4", DbType.String, inputRow.StatisticName4);
                }

                if (inputRow.IsStatisticName5Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName5", DbType.String, inputRow.StatisticName5);
                }

                if (inputRow.IsStatisticName6Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName6", DbType.String, inputRow.StatisticName6);
                }

                if (inputRow.IsStatisticName7Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName7", DbType.String, inputRow.StatisticName7);
                }

                if (inputRow.IsStatisticName8Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName8", DbType.String, inputRow.StatisticName8);
                }

                if (inputRow.IsStatisticName9Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName9", DbType.String, inputRow.StatisticName9);
                }

                if (inputRow.IsStatisticName10Null())
                {
                    db.AddInParameter(dbCommand, "s_StatisticName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StatisticName10", DbType.String, inputRow.StatisticName10);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScoreName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertFile
        public CompetitionDS InsertFile(CompetitionDS.FileRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                int FileID = 0;
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertFile");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_FileName", DbType.String, inputRow.FileName);
                db.AddInParameter(dbCommand, "s_FilePath", DbType.String, inputRow.FilePath);
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                db.AddOutParameter(dbCommand, "n_FileID", DbType.Int32, FileID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.File.TableName);
                CompetitionDS.FileRow row = resDS.File.NewFileRow();
                row.FileID = Convert.ToInt32(db.GetParameterValue(dbCommand, "n_FileID"));
                resDS.File.AddFileRow(row);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetFileInEvent
        public CompetitionDS GetFileInEvent(CompetitionDS.FileInEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetFileInEvent");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.FileInEvent.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertFileInEvent
        public CompetitionDS InsertFileInEvent(CompetitionDS.FileInEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertFileInEvent");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_FileID", DbType.Int32, inputRow.FileID);
                db.AddInParameter(dbCommand, "n_EventID", DbType.String, inputRow.EventID);
                db.AddInParameter(dbCommand, "n_FileGroupID", DbType.String, inputRow.FileGroupID);
                db.AddInParameter(dbCommand, "b_IsLinkedToSport", DbType.Boolean, inputRow.IsLinkedToSport);
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.File.TableName);

                code = SystemMessage.Generic_Success_Code;
                message = SystemMessage.Generic_Success_Msg;
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
        public CompetitionDS DeleteFileInEvent(CompetitionDS.FileInEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteFileInEvent");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_FileID", DbType.Int32, inputRow.FileID);
                db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleDetail.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetFinalRankings
        public CompetitionDS GetFinalRankings(CompetitionDS.FinalRankingsRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetMedalAndFinalRanking");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.FinalRankings.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEventAthletes
        public CompetitionDS GetEventAthletes(CompetitionDS.EventAthletesRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetEventAthletes");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.EventAthletes.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetScheduleListForBanner
        public CompetitionDS GetScheduleListForBanner(CompetitionDS.ScheduleListRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetScheduleListForBanner");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ScheduleList.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSportDetails
        public CompetitionDS GetSportDetails(CompetitionDS.SportDetailsRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetSportDetails");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.SportDetails.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLatestMedalist
        public CompetitionDS GetLatestMedalist(CompetitionDS.LatestMedalistRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetLatestMedalist");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "@n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "@n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "@d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@d_Date", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.LatestMedalist.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMedalStandings
        public CompetitionDS GetMedalStandings(CompetitionDS.MedalStandingsRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetMedalStandings");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "@n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "@n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "@d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@d_Date", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.MedalStandings.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMedalStandingsByCountry
        public CompetitionDS GetMedalStandingsByCountry(CompetitionDS.MedalStandingsCountryRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetMedalStandingsByCountry");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "@n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "@n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "@d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "@d_Date", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.MedalStandingsCountry.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetSportEventSchedule
        public CompetitionDS GetSportEventSchedule(CompetitionDS.SportEventScheduleRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetSportEventSchedule");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.SportEventSchedule.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetReferee
        public CompetitionDS GetReferee(CompetitionDS.RefereeRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetReferee");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Referee.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertReferee
        public CompetitionDS InsertReferee(CompetitionDS.RefereeRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertReferee");

                #region Parameters Initialization
                if (inputRow.IsRefereeName1Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName1", DbType.String, inputRow.RefereeName1);
                }

                if (inputRow.IsRefereeName2Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName2", DbType.String, inputRow.RefereeName2);
                }

                if (inputRow.IsRefereeName3Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName3", DbType.String, inputRow.RefereeName3);
                }

                if (inputRow.IsRefereeName4Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName4", DbType.String, inputRow.RefereeName4);
                }

                if (inputRow.IsRefereeName5Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName5", DbType.String, inputRow.RefereeName5);
                }

                if (inputRow.IsRefereeName6Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName6", DbType.String, inputRow.RefereeName6);
                }

                if (inputRow.IsRefereeName7Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName7", DbType.String, inputRow.RefereeName7);
                }

                if (inputRow.IsRefereeName8Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName8", DbType.String, inputRow.RefereeName8);
                }

                if (inputRow.IsRefereeName9Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName9", DbType.String, inputRow.RefereeName9);
                }

                if (inputRow.IsRefereeName10Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName10", DbType.String, inputRow.RefereeName10);
                }

                if (inputRow.IsRefereeTitle1Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle1", DbType.String, inputRow.RefereeTitle1);
                }

                if (inputRow.IsRefereeTitle2Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle2", DbType.String, inputRow.RefereeTitle2);
                }

                if (inputRow.IsRefereeTitle3Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle3", DbType.String, inputRow.RefereeTitle3);
                }

                if (inputRow.IsRefereeTitle4Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle4", DbType.String, inputRow.RefereeTitle4);
                }

                if (inputRow.IsRefereeTitle5Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle5", DbType.String, inputRow.RefereeTitle5);
                }

                if (inputRow.IsRefereeTitle6Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle6", DbType.String, inputRow.RefereeTitle6);
                }

                if (inputRow.IsRefereeTitle7Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle7", DbType.String, inputRow.RefereeTitle7);
                }

                if (inputRow.IsRefereeTitle8Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle8", DbType.String, inputRow.RefereeTitle8);
                }

                if (inputRow.IsRefereeTitle9Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle9", DbType.String, inputRow.RefereeTitle9);
                }

                if (inputRow.IsRefereeTitle10Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle10", DbType.String, inputRow.RefereeTitle10);
                }

                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Referee.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateReferee
        public CompetitionDS UpdateReferee(CompetitionDS.RefereeRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateReferee");

                #region Parameters Initialization
                if (inputRow.IsRefereeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_RefereeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_RefereeID", DbType.Int32, inputRow.RefereeID);
                }

                if (inputRow.IsRefereeName1Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName1", DbType.String, inputRow.RefereeName1);
                }

                if (inputRow.IsRefereeName2Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName2", DbType.String, inputRow.RefereeName2);
                }

                if (inputRow.IsRefereeName3Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName3", DbType.String, inputRow.RefereeName3);
                }

                if (inputRow.IsRefereeName4Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName4", DbType.String, inputRow.RefereeName4);
                }

                if (inputRow.IsRefereeName5Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName5", DbType.String, inputRow.RefereeName5);
                }

                if (inputRow.IsRefereeName6Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName6", DbType.String, inputRow.RefereeName6);
                }

                if (inputRow.IsRefereeName7Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName7", DbType.String, inputRow.RefereeName7);
                }

                if (inputRow.IsRefereeName8Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName8", DbType.String, inputRow.RefereeName8);
                }

                if (inputRow.IsRefereeName9Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName9", DbType.String, inputRow.RefereeName9);
                }

                if (inputRow.IsRefereeName10Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeName10", DbType.String, inputRow.RefereeName10);
                }

                if (inputRow.IsRefereeTitle1Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle1", DbType.String, inputRow.RefereeTitle1);
                }

                if (inputRow.IsRefereeTitle2Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle2", DbType.String, inputRow.RefereeTitle2);
                }

                if (inputRow.IsRefereeTitle3Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle3", DbType.String, inputRow.RefereeTitle3);
                }

                if (inputRow.IsRefereeTitle4Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle4", DbType.String, inputRow.RefereeTitle4);
                }

                if (inputRow.IsRefereeTitle5Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle5", DbType.String, inputRow.RefereeTitle5);
                }

                if (inputRow.IsRefereeTitle6Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle6", DbType.String, inputRow.RefereeTitle6);
                }

                if (inputRow.IsRefereeTitle7Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle7", DbType.String, inputRow.RefereeTitle7);
                }

                if (inputRow.IsRefereeTitle8Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle8", DbType.String, inputRow.RefereeTitle8);
                }

                if (inputRow.IsRefereeTitle9Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle9", DbType.String, inputRow.RefereeTitle9);
                }

                if (inputRow.IsRefereeTitle10Null())
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_RefereeTitle10", DbType.String, inputRow.RefereeTitle10);
                }

                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Referee.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantBiography
        public CompetitionDS GetParticipantBiography(CompetitionDS.ParticipantBiographyRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantBiography");

                #region Parameters Initialization
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantBiography.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeamBiography
        public CompetitionDS GetTeamBiography(CompetitionDS.TeamBiographyRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetTeamBiography");

                #region Parameters Initialization
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.TeamBiography.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantInEvent
        public CompetitionDS GetParticipantInEvent(CompetitionDS.ParticipantInEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantInEvent");

                #region Parameters Initialization
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantInEvent.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateParticipantInEvent
        public CompetitionDS UpdateParticipantInEvent(CompetitionDS.ParticipantInEventRow inputRow, int participantID)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateParticipantInEvent");

                #region Parameters Initialization
                if(inputRow.IsParticipantInEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInEventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInEventID", DbType.Int32, inputRow.ParticipantInEventID);
                }
                if (participantID == 0)
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, participantID);
                }
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                if (inputRow.IsSportClassIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportClassID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportClassID", DbType.Int32, inputRow.SportClassID);
                }
                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "n_GroupCode", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_GroupCode", DbType.String, inputRow.GroupCode);
                }
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());

                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantDetail.TableName);

            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMedallist
        public CompetitionDS GetMedallist(CompetitionDS.MedallistRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetMedallist");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                if (inputRow.IsMedalCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_Medal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Medal", DbType.String, inputRow.MedalCode);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Medallist.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetMultiMedallist
        public CompetitionDS GetMultiMedallist(CompetitionDS.MultiMedallistRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetMultiMedallist");

                #region Parameters Initialization
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsCountryIDNull())
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_CountryID", DbType.Int32, inputRow.CountryID);
                }
                if (inputRow.IsScheduleDateTimeNull())
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "d_Date", DbType.DateTime, inputRow.ScheduleDateTime);
                }
                if (inputRow.IsMedalCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_Medal", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Medal", DbType.String, inputRow.MedalCode);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.MultiMedallist.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetKnockoutSummary
        public CompetitionDS GetKnockoutSummary(CompetitionDS.KnockoutSummaryRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetKnockoutSummary");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.KnockoutSummary.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetKnockoutSummaryForTeam
        public CompetitionDS GetKnockoutSummaryForTeam(CompetitionDS.KnockoutSummaryRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetKnockoutSummaryForTeam");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.KnockoutSummary.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueSummary
        public CompetitionDS GetLeagueSummary(CompetitionDS.LeagueSummaryRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetLeagueSummary");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.LeagueSummary.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueSummaryForTeam
        public CompetitionDS GetLeagueSummaryForTeam(CompetitionDS.LeagueSummaryRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetLeagueSummaryForTeam");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.LeagueSummary.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetBrokenRecord
        public CompetitionDS GetBrokenRecord(CompetitionDS.BrokenRecordRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetBrokenRecord");


                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.BrokenRecord.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueForIndividual
        public CompetitionDS GetLeagueForIndividual(CompetitionDS.LeagueRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetLeagueForIndividual");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, inputRow.GroupCode);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.League.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetLeagueForTeam
        public CompetitionDS GetLeagueForTeam(CompetitionDS.LeagueRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetLeagueForTeam");

                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, inputRow.GroupCode);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.League.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertLeagueForTeam
        public CompetitionDS InsertLeagueForTeam(CompetitionDS.LeagueRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertLeagueForTeam");
                
                #region Parameters Initialization
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }

                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, inputRow.GroupCode);
                }

                if (inputRow.IsRankNull())
                {
                    db.AddInParameter(dbCommand, "n_Rank", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Rank", DbType.Int32, inputRow.Rank);
                }

                if (inputRow.IsLeague1Null())
                {
                    db.AddInParameter(dbCommand, "s_League1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League1", DbType.String, inputRow.League1);
                }

                if (inputRow.IsLeague2Null())
                {
                    db.AddInParameter(dbCommand, "s_League2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League2", DbType.String, inputRow.League2);
                }

                if (inputRow.IsLeague3Null())
                {
                    db.AddInParameter(dbCommand, "s_League3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League3", DbType.String, inputRow.League3);
                }

                if (inputRow.IsLeague4Null())
                {
                    db.AddInParameter(dbCommand, "s_League4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League4", DbType.String, inputRow.League4);
                }

                if (inputRow.IsLeague5Null())
                {
                    db.AddInParameter(dbCommand, "s_League5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League5", DbType.String, inputRow.League5);
                }

                if (inputRow.IsLeague6Null())
                {
                    db.AddInParameter(dbCommand, "s_League6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League6", DbType.String, inputRow.League6);
                }

                if (inputRow.IsLeague7Null())
                {
                    db.AddInParameter(dbCommand, "s_League7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League7", DbType.String, inputRow.League7);
                }

                if (inputRow.IsLeague8Null())
                {
                    db.AddInParameter(dbCommand, "s_League8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League8", DbType.String, inputRow.League8);
                }

                if (inputRow.IsLeague9Null())
                {
                    db.AddInParameter(dbCommand, "s_League9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League9", DbType.String, inputRow.League9);
                }

                if (inputRow.IsLeague10Null())
                {
                    db.AddInParameter(dbCommand, "s_League10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League10", DbType.String, inputRow.League10);
                }


                if (inputRow.IsLeague11Null())
                {
                    db.AddInParameter(dbCommand, "s_League11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League11", DbType.String, inputRow.League11);
                }

                if (inputRow.IsLeague12Null())
                {
                    db.AddInParameter(dbCommand, "s_League12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League12", DbType.String, inputRow.League12);
                }

                if (inputRow.IsLeague13Null())
                {
                    db.AddInParameter(dbCommand, "s_League13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League13", DbType.String, inputRow.League13);
                }

                if (inputRow.IsLeague14Null())
                {
                    db.AddInParameter(dbCommand, "s_League14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League14", DbType.String, inputRow.League14);
                }

                if (inputRow.IsLeague15Null())
                {
                    db.AddInParameter(dbCommand, "s_League15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League15", DbType.String, inputRow.League15);
                }

                if (inputRow.IsLeague16Null())
                {
                    db.AddInParameter(dbCommand, "s_League16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League16", DbType.String, inputRow.League16);
                }

                if (inputRow.IsLeague17Null())
                {
                    db.AddInParameter(dbCommand, "s_League17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League17", DbType.String, inputRow.League17);
                }

                if (inputRow.IsLeague18Null())
                {
                    db.AddInParameter(dbCommand, "s_League18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League18", DbType.String, inputRow.League18);
                }

                if (inputRow.IsLeague19Null())
                {
                    db.AddInParameter(dbCommand, "s_League19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League19", DbType.String, inputRow.League19);
                }

                if (inputRow.IsLeague20Null())
                {
                    db.AddInParameter(dbCommand, "s_League20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League20", DbType.String, inputRow.League20);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.League.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertLeagueForIndividual
        public CompetitionDS InsertLeagueForIndividual(CompetitionDS.LeagueRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertLeagueForIndividual");

                #region Parameters Initialization
                if (inputRow.IsParticipantInEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInEventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantInEventID", DbType.Int32, inputRow.ParticipantInEventID);
                }

                if (inputRow.IsGroupCodeNull())
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_GroupCode", DbType.String, inputRow.GroupCode);
                }

                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }

                if (inputRow.IsRankNull())
                {
                    db.AddInParameter(dbCommand, "n_Rank", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Rank", DbType.Int32, inputRow.Rank);
                }

                if (inputRow.IsLeague1Null())
                {
                    db.AddInParameter(dbCommand, "s_League1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League1", DbType.String, inputRow.League1);
                }

                if (inputRow.IsLeague2Null())
                {
                    db.AddInParameter(dbCommand, "s_League2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League2", DbType.String, inputRow.League2);
                }

                if (inputRow.IsLeague3Null())
                {
                    db.AddInParameter(dbCommand, "s_League3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League3", DbType.String, inputRow.League3);
                }

                if (inputRow.IsLeague4Null())
                {
                    db.AddInParameter(dbCommand, "s_League4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League4", DbType.String, inputRow.League4);
                }

                if (inputRow.IsLeague5Null())
                {
                    db.AddInParameter(dbCommand, "s_League5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League5", DbType.String, inputRow.League5);
                }

                if (inputRow.IsLeague6Null())
                {
                    db.AddInParameter(dbCommand, "s_League6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League6", DbType.String, inputRow.League6);
                }

                if (inputRow.IsLeague7Null())
                {
                    db.AddInParameter(dbCommand, "s_League7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League7", DbType.String, inputRow.League7);
                }

                if (inputRow.IsLeague8Null())
                {
                    db.AddInParameter(dbCommand, "s_League8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League8", DbType.String, inputRow.League8);
                }

                if (inputRow.IsLeague9Null())
                {
                    db.AddInParameter(dbCommand, "s_League9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League9", DbType.String, inputRow.League9);
                }

                if (inputRow.IsLeague10Null())
                {
                    db.AddInParameter(dbCommand, "s_League10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League10", DbType.String, inputRow.League10);
                }


                if (inputRow.IsLeague11Null())
                {
                    db.AddInParameter(dbCommand, "s_League11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League11", DbType.String, inputRow.League11);
                }

                if (inputRow.IsLeague12Null())
                {
                    db.AddInParameter(dbCommand, "s_League12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League12", DbType.String, inputRow.League12);
                }

                if (inputRow.IsLeague13Null())
                {
                    db.AddInParameter(dbCommand, "s_League13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League13", DbType.String, inputRow.League13);
                }

                if (inputRow.IsLeague14Null())
                {
                    db.AddInParameter(dbCommand, "s_League14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League14", DbType.String, inputRow.League14);
                }

                if (inputRow.IsLeague15Null())
                {
                    db.AddInParameter(dbCommand, "s_League15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League15", DbType.String, inputRow.League15);
                }

                if (inputRow.IsLeague16Null())
                {
                    db.AddInParameter(dbCommand, "s_League16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League16", DbType.String, inputRow.League16);
                }

                if (inputRow.IsLeague17Null())
                {
                    db.AddInParameter(dbCommand, "s_League17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League17", DbType.String, inputRow.League17);
                }

                if (inputRow.IsLeague18Null())
                {
                    db.AddInParameter(dbCommand, "s_League18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League18", DbType.String, inputRow.League18);
                }

                if (inputRow.IsLeague19Null())
                {
                    db.AddInParameter(dbCommand, "s_League19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League19", DbType.String, inputRow.League19);
                }

                if (inputRow.IsLeague20Null())
                {
                    db.AddInParameter(dbCommand, "s_League20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League20", DbType.String, inputRow.League20);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.League.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateLeague
        public CompetitionDS UpdateLeague(CompetitionDS.LeagueRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateLeague");

                #region Parameters Initialization
                if(inputRow.IsLeagueIDNull())
                {
                    db.AddInParameter(dbCommand, "n_LeagueID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_LeagueID", DbType.Int32, inputRow.LeagueID);
                }

                if (inputRow.IsRankNull())
                {
                    db.AddInParameter(dbCommand, "n_Rank", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_Rank", DbType.Int32, inputRow.Rank);
                }

                if (inputRow.IsLeague1Null())
                {
                    db.AddInParameter(dbCommand, "s_League1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League1", DbType.String, inputRow.League1);
                }

                if (inputRow.IsLeague2Null())
                {
                    db.AddInParameter(dbCommand, "s_League2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League2", DbType.String, inputRow.League2);
                }

                if (inputRow.IsLeague3Null())
                {
                    db.AddInParameter(dbCommand, "s_League3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League3", DbType.String, inputRow.League3);
                }

                if (inputRow.IsLeague4Null())
                {
                    db.AddInParameter(dbCommand, "s_League4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League4", DbType.String, inputRow.League4);
                }

                if (inputRow.IsLeague5Null())
                {
                    db.AddInParameter(dbCommand, "s_League5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League5", DbType.String, inputRow.League5);
                }

                if (inputRow.IsLeague6Null())
                {
                    db.AddInParameter(dbCommand, "s_League6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League6", DbType.String, inputRow.League6);
                }

                if (inputRow.IsLeague7Null())
                {
                    db.AddInParameter(dbCommand, "s_League7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League7", DbType.String, inputRow.League7);
                }

                if (inputRow.IsLeague8Null())
                {
                    db.AddInParameter(dbCommand, "s_League8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League8", DbType.String, inputRow.League8);
                }

                if (inputRow.IsLeague9Null())
                {
                    db.AddInParameter(dbCommand, "s_League9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League9", DbType.String, inputRow.League9);
                }

                if (inputRow.IsLeague10Null())
                {
                    db.AddInParameter(dbCommand, "s_League10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League10", DbType.String, inputRow.League10);
                }


                if (inputRow.IsLeague11Null())
                {
                    db.AddInParameter(dbCommand, "s_League11", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League11", DbType.String, inputRow.League11);
                }

                if (inputRow.IsLeague12Null())
                {
                    db.AddInParameter(dbCommand, "s_League12", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League12", DbType.String, inputRow.League12);
                }

                if (inputRow.IsLeague13Null())
                {
                    db.AddInParameter(dbCommand, "s_League13", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League13", DbType.String, inputRow.League13);
                }

                if (inputRow.IsLeague14Null())
                {
                    db.AddInParameter(dbCommand, "s_League14", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League14", DbType.String, inputRow.League14);
                }

                if (inputRow.IsLeague15Null())
                {
                    db.AddInParameter(dbCommand, "s_League15", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League15", DbType.String, inputRow.League15);
                }

                if (inputRow.IsLeague16Null())
                {
                    db.AddInParameter(dbCommand, "s_League16", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League16", DbType.String, inputRow.League16);
                }

                if (inputRow.IsLeague17Null())
                {
                    db.AddInParameter(dbCommand, "s_League17", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League17", DbType.String, inputRow.League17);
                }

                if (inputRow.IsLeague18Null())
                {
                    db.AddInParameter(dbCommand, "s_League18", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League18", DbType.String, inputRow.League18);
                }

                if (inputRow.IsLeague19Null())
                {
                    db.AddInParameter(dbCommand, "s_League19", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League19", DbType.String, inputRow.League19);
                }

                if (inputRow.IsLeague20Null())
                {
                    db.AddInParameter(dbCommand, "s_League20", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_League20", DbType.String, inputRow.League20);
                }
                
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.League.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeam
        public CompetitionDS GetTeam(CompetitionDS.TeamRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetTeam");

                #region Parameters Initialization
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                if (inputRow.IsSportIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SportID", DbType.Int32, inputRow.SportID);
                }
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                if (inputRow.IsTeamNameNull())
                {
                    db.AddInParameter(dbCommand, "s_TeamName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_TeamName", DbType.String, inputRow.EventName);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Team.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateTeam
        public CompetitionDS UpdateTeam(CompetitionDS.TeamRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateTeam");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                db.AddInParameter(dbCommand, "s_TeamName", DbType.String, inputRow.TeamName);
                db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Team.TableName);

                code = SystemMessage.Generic_Success_Code;
                message = SystemMessage.Generic_Success_Msg;
                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteTeam
        public CompetitionDS DeleteTeam(CompetitionDS.TeamRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteTeam");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Team.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertTeam
        public CompetitionDS InsertTeam(CompetitionDS.TeamRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                int teamID = 0;
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertTeam");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_TeamName", DbType.String, inputRow.TeamName);
                db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                db.AddOutParameter(dbCommand, "n_TeamID", DbType.Int32, teamID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Team.TableName);
                CompetitionDS.TeamRow row = resDS.Team.NewTeamRow();
                row.TeamID = Convert.ToInt32(db.GetParameterValue(dbCommand, "n_TeamID"));
                resDS.Team.AddTeamRow(row);

                code = SystemMessage.Generic_Success_Code;
                message = SystemMessage.Generic_Success_Msg;
                resDS.Response.AddResponseRow("", code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetParticipantEvent
        public CompetitionDS GetParticipantEvent(CompetitionDS.ParticipantEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetParticipantEvent");

                #region Parameters Initialization
                if (inputRow.IsParticipantIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ParticipantID", DbType.Int32, inputRow.ParticipantID);
                }
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantEvent.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetTeamEvent
        public CompetitionDS GetTeamEvent(CompetitionDS.ParticipantEventRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetTeamEvent");

                #region Parameters Initialization
                if (inputRow.IsTeamIDNull())
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_TeamID", DbType.Int32, inputRow.TeamID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ParticipantEvent.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertStartListName
        public CompetitionDS InsertStartListName(CompetitionDS.StartlistNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_I_InsertStartListName");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName1", DbType.String, inputRow.StartListName1);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName2", DbType.String, inputRow.StartListName2);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName3", DbType.String, inputRow.StartListName3);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName4", DbType.String, inputRow.StartListName4);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName5", DbType.String, inputRow.StartListName5);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName6", DbType.String, inputRow.StartListName6);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName7", DbType.String, inputRow.StartListName7);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName8", DbType.String, inputRow.StartListName8);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName9", DbType.String, inputRow.StartListName9);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName10", DbType.String, inputRow.StartListName10);
                }

                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, true);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.CreatedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.StartlistName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateStartListName
        public CompetitionDS UpdateStartListName(CompetitionDS.StartlistNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_U_UpdateStartListName");

                #region Parameters Initialization
                if (inputRow.IsStartListNameIDNull())
                {
                    db.AddInParameter(dbCommand, "n_StartListNameID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_StartListNameID", DbType.Int32, inputRow.StartListNameID);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName1", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName1", DbType.String, inputRow.StartListName1);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName2", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName2", DbType.String, inputRow.StartListName2);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName3", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName3", DbType.String, inputRow.StartListName3);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName4", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName4", DbType.String, inputRow.StartListName4);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName5", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName5", DbType.String, inputRow.StartListName5);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName6", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName6", DbType.String, inputRow.StartListName6);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName7", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName7", DbType.String, inputRow.StartListName7);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName8", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName8", DbType.String, inputRow.StartListName8);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName9", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName9", DbType.String, inputRow.StartListName9);
                }

                if (inputRow.IsStartListName1Null())
                {
                    db.AddInParameter(dbCommand, "s_StartListName10", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_StartListName10", DbType.String, inputRow.StartListName10);
                }
                
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.StartlistName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetStartListName
        public CompetitionDS GetStartListName(CompetitionDS.StartlistNameRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_S_GetStartListName");

                #region Parameters Initialization
                if (inputRow.IsScheduleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ScheduleID", DbType.Int32, inputRow.ScheduleID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.StartlistName.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetInitialRecord
        public CompetitionDS GetInitialRecord(CompetitionDS.InitialRecordRow inputRow)
        {
            CompetitionDS resDS = new CompetitionDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_S_GetInitialRecord");


                #region Parameters Initialization
                if (inputRow.IsEventIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EventID", DbType.Int32, inputRow.EventID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.InitialRecord.TableName);
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
