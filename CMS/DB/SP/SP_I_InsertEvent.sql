IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertEvent
END
GO

/*************************************************************************
* Name				: SP_I_InsertEvent
* Author			: Ramani
* Create date		: 22-Aug-2015
* Description		: Insert Event Details
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertEvent]
(
	@s_EventName			nvarchar(200),
	@s_EventCode			nvarchar(100),
	@n_SportID				int,
	@n_GenderID				int,
	@n_PlayFormatID			int,
	@n_EventTypeID			int,
	@b_IsShowResult			bit,
	@b_IsShowMedal			bit,
	@b_IsShowAthelete		bit,
	@b_IsShowReport			bit,
	@b_IsShowRecord			bit,
	@b_IsShowSummary		bit,
	@n_CreatedBy			int,
	@d_CreatedDateTime		datetime,
	@n_EventID				int output 
)
AS
BEGIN
INSERT INTO dbo.T_Event
           ([EventName]
			,[EventCode]
			,[SportID]
			,[GenderID]
			,[PlayFormatID]
			,[EventTypeID]
			,[IsShowResult]
			,[IsShowMedal]
			,[IsShowAthelete]
			,[IsShowReport]
			,[IsShowRecord]
			,[IsShowSummary]
			,[IsActive]
			,[CreatedBy]
			,[CreatedDateTime]
			,[ModifiedBy]
			,[ModifiedDateTime])
     VALUES
           (@s_EventName
           ,@s_EventCode
           ,@n_SportID
           ,@n_GenderID
		   ,@n_PlayFormatID
		   ,@n_EventTypeID
		   ,@b_IsShowResult
		   ,@b_IsShowMedal
		   ,@b_IsShowAthelete
		   ,@b_IsShowReport
		   ,@b_IsShowRecord
		   ,@b_IsShowSummary
           ,1
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime)

	SET @n_EventID = @@IDENTITY
	RETURN @n_EventID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertEvent] TO USER
GO*/