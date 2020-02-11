IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertScheduleDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertScheduleDetail
END
GO

/*************************************************************************
* Name				: SP_I_InsertScheduleDetail
* Author			: DEV001
* Create date		: 26-Aug-2015
* Description		: Insert Schedule detail
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertScheduleDetail]
(
	@n_EventID					int,
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
	@d_CreatedDateTime			datetime,
	@n_CreatedBy				int
)
AS
BEGIN
INSERT INTO dbo.T_Schedule
           (   EventID
			  ,ScheduleName
			  ,ScheduleDateTime
			  ,Venue
			  ,Location
			  ,RoundName
			  ,MatchNumber
			  ,CompetitionStage
			  ,TotalParticipant
			  ,PlayFormatID
			  ,GroupCode
			  ,StatusCodeID
			  ,HeadToHead
			  ,IsMedalGame
			  ,IsPublishStartList
			  ,IsOfficial
			  ,IsPublishSchedule
			  ,IsGenerateLeagueSummary
			  ,IsActive
			  ,CreatedDateTime
			  ,CreatedBy
			  ,ModifiedDateTime
			  ,ModifiedBy)
     VALUES
           (
			@n_EventID	
		   ,@s_ScheduleName
		   ,@d_ScheduleDateTime
		   ,@s_Venue
		   ,@s_Location
		   ,@s_RoundName
		   ,@n_MatchNumber
		   ,@n_CompetitionStage
		   ,@n_TotalParticipant
		   ,@n_PlayFormatID
		   ,@s_GroupCode
		   ,@n_StatusCodeID		
		   ,@b_HeadToHead
		   ,@b_IsMedalGame
		   ,@b_IsPublishStartList
		   ,@b_IsOfficial
		   ,@b_IsPublishSchedule
		   ,@b_IsGenerateLeagueSummary
		   ,@n_IsActive				
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)	
END

SELECT SCOPE_IDENTITY() AS ScheduleID

UPDATE T_Schedule
SET IsGenerateLeagueSummary = @b_IsGenerateLeagueSummary
WHERE EventID = @n_EventID AND GroupCode = @s_GroupCode

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertScheduleDetail] TO USER
GO*/