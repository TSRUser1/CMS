IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertScoreForTeamInSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertScoreForTeamInSchedule
END
GO

/*************************************************************************
* Name				: SP_I_InsertScoreForTeamInSchedule
* Author			: Ramani Ganason
* Create date		: 30-Aug-2015
* Description		: Insert Score for Team
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertScoreForTeamInSchedule]
(
	@n_TeamID					int,
	@n_ScheduleID				int,
    @s_Score1	   	 			nvarchar(100),
    @s_Score2	   	 			nvarchar(100),
    @s_Score3	   	 			nvarchar(100),
    @s_Score4	   	 			nvarchar(100),
    @s_Score5	   	 			nvarchar(100),
    @s_Score6	   	 			nvarchar(100),
    @s_Score7	   	 			nvarchar(100),
    @s_Score8	   	 			nvarchar(100),
    @s_Score9	   	 			nvarchar(100),
    @s_Score10	   	 			nvarchar(100),
    @s_Score11	   	 			nvarchar(100),
    @s_Score12	   	 			nvarchar(100),
    @s_Score13	   	 			nvarchar(100),
    @s_Score14	   	 			nvarchar(100),
    @s_Score15	   	 			nvarchar(100),
    @s_Score16	   	 			nvarchar(100),
    @s_Score17	   	 			nvarchar(100),
    @s_Score18	   	 			nvarchar(100),
    @s_Score19	   	 			nvarchar(100),
    @s_Score20	   	 			nvarchar(100),
	@s_ScoreFinal				nvarchar(100),
	@s_BreakRecord	   	 		nvarchar(100),
    @n_MedalID					int,
    @n_ResultPosition			int,
	@s_Remarks					nvarchar(100),
    @n_IsActive			 		int,
    @d_CreatedDateTime	 		datetime,
    @n_CreatedBy		 		int
)
AS
BEGIN

/****************************************************************************************************
* If ScoreInParticipantInSchedule with same ScheduleID and TeamID exist in DB, then set the old record to EMPTY by default.
*****************************************************************************************************/
UPDATE T_ScoreInParticipantInSchedule
	SET TeamID = null
	WHERE ScheduleID = @n_ScheduleID
	AND TeamID = @n_TeamID

INSERT INTO dbo.T_Score
           (Score1
           ,Score2
           ,Score3
           ,Score4
           ,Score5
           ,Score6
           ,Score7
           ,Score8
           ,Score9
           ,Score10
           ,Score11
           ,Score12
           ,Score13
           ,Score14
           ,Score15
           ,Score16
           ,Score17
           ,Score18
           ,Score19
           ,Score20
		   ,ScoreFinal
           ,BreakRecord
           ,MedalID
           ,ResultPosition
		   ,Remarks
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_Score1
           ,@s_Score2
           ,@s_Score3
           ,@s_Score4
           ,@s_Score5
           ,@s_Score6
           ,@s_Score7
           ,@s_Score8
           ,@s_Score9
           ,@s_Score10
           ,@s_Score11
           ,@s_Score12
           ,@s_Score13
           ,@s_Score14
           ,@s_Score15
           ,@s_Score16
           ,@s_Score17
           ,@s_Score18
           ,@s_Score19
           ,@s_Score20
		   ,@s_ScoreFinal
           ,@s_BreakRecord
           ,@n_MedalID
           ,@n_ResultPosition
		   ,@s_Remarks
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

INSERT INTO
	T_ScoreInParticipantInSchedule
	(ScheduleID
	,ScoreID
	,TeamID)
	VALUES
	(@n_ScheduleID
	,SCOPE_IDENTITY()
	,@n_TeamID)
	
SELECT @@ROWCOUNT AS UpdatedRow

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertScoreForTeamInSchedule] TO USER
GO*/