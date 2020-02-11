IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateScheduleDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateScheduleDetail
END
GO

/*************************************************************************
* Name				: SSP_U_UpdateScheduleDetail
* Author			: DEV001
* Create date		: 22-Aug-2015
* Description		: Update Schedule detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateScheduleDetail]
(
	@n_ScheduleID				int,
	@s_ScheduleName				nvarchar(200),
	@d_ScheduleDateTime			datetime,
	@s_Venue					nvarchar(max),
	@s_Location					nvarchar(max),
	@s_RoundName				nvarchar(200),
	@n_MatchNumber				int,
	@n_CompetitionStage			int,
	@n_TotalParticipant			int,
	@n_PlayFormatID				int,
	@s_GroupCode				nvarchar(100),
	@n_StatusCodeID				int,
	@b_HeadToHead				bit,
	@b_IsMedalGame				bit,
	@b_IsPublishStartList		bit,
	@b_IsOfficial				bit,
	@b_IsPublishSchedule		bit,
	@b_IsGenerateLeagueSummary	bit,
	@n_IsActive					int,
	@n_ModifiedBy				int,
	@d_ModifiedDateTime			datetime
)
AS
BEGIN
	UPDATE dbo.T_Schedule
	   SET ScheduleName = @s_ScheduleName
		  ,ScheduleDateTime = @d_ScheduleDateTime
		  ,Venue = @s_Venue
		  ,Location = @s_Location
		  ,RoundName = @s_RoundName
		  ,MatchNumber = @n_MatchNumber
		  ,CompetitionStage = @n_CompetitionStage
		  ,TotalParticipant = @n_TotalParticipant
		  ,PlayFormatID = @n_PlayFormatID
		  ,GroupCode = @s_GroupCode
		  ,StatusCodeID = @n_StatusCodeID
		  ,HeadToHead = @b_HeadToHead
		  ,IsMedalGame = @b_IsMedalGame
		  ,IsPublishStartList = @b_IsPublishStartList
		  ,IsOfficial = @b_IsOfficial
		  ,IsPublishSchedule = @b_IsPublishSchedule
		  ,IsGenerateLeagueSummary = @b_IsGenerateLeagueSummary
		  ,IsActive = @n_IsActive
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
	 WHERE ScheduleID = @n_ScheduleID

SELECT @@ROWCOUNT AS UpdatedRow

UPDATE T_Schedule
SET IsGenerateLeagueSummary = @b_IsGenerateLeagueSummary
WHERE EventID = (SELECT TOP 1 EventID FROM T_Schedule WHERE ScheduleID = @n_ScheduleID)  
AND GroupCode = @s_GroupCode

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateScheduleDetail] TO USER
GO*/