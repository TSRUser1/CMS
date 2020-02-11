IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertStatisticForParticipantInSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertStatisticForParticipantInSchedule
END
GO

/*************************************************************************
* Name				: SP_I_InsertStatisticForParticipantInSchedule
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Insert Statistic for Participant
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertStatisticForParticipantInSchedule]
(
	@n_ParticipantInScheduleID	int,
    @s_Statistic1	   	 			nvarchar(100),
    @s_Statistic2	   	 			nvarchar(100),
    @s_Statistic3	   	 			nvarchar(100),
    @s_Statistic4	   	 			nvarchar(100),
    @s_Statistic5	   	 			nvarchar(100),
    @s_Statistic6	   	 			nvarchar(100),
    @s_Statistic7	   	 			nvarchar(100),
    @s_Statistic8	   	 			nvarchar(100),
    @s_Statistic9	   	 			nvarchar(100),
    @s_Statistic10	   	 			nvarchar(100),
    @n_IsActive			 		int,
    @d_CreatedDateTime	 		datetime,
    @n_CreatedBy		 		int
)
AS
BEGIN
INSERT INTO T_Statistic
           (Statistic1
           ,Statistic2
           ,Statistic3
           ,Statistic4
           ,Statistic5
           ,Statistic6
           ,Statistic7
           ,Statistic8
           ,Statistic9
           ,Statistic10
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_Statistic1
           ,@s_Statistic2
           ,@s_Statistic3
           ,@s_Statistic4
           ,@s_Statistic5
           ,@s_Statistic6
           ,@s_Statistic7
           ,@s_Statistic8
           ,@s_Statistic9
           ,@s_Statistic10
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

UPDATE T_ParticipantInSchedule
	SET StatisticID = SCOPE_IDENTITY()
		,ModifiedDateTime = @d_CreatedDateTime
		,ModifiedBy = @n_CreatedBy
	WHERE ParticipantInScheduleID = @n_ParticipantInScheduleID

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertStatisticForParticipantInSchedule] TO USER
GO*/