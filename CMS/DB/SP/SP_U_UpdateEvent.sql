IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateEvent
END
GO

/*************************************************************************
* Name				: SP_U_UpdateEvent
* Author			: Ramani
* Create date		: 22-Aug-2015
* Description		: Update Event Details
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateEvent]
(
	@n_EventID				int,
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
	@n_ModifiedBy			INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Event
	Set EventName = ISNULL( @s_EventName, EventName ),
		EventCode = ISNULL( @s_EventCode, EventCode ),
		SportID = ISNULL( @n_SportID, SportID ),
		GenderID = ISNULL( @n_GenderID, GenderID ),
		PlayFormatID = ISNULL( @n_PlayFormatID, PlayFormatID ),
		EventTypeID = ISNULL( @n_EventTypeID, EventTypeID ),
		IsShowResult = @b_IsShowResult,
		IsShowMedal = @b_IsShowMedal,
		IsShowAthelete = @b_IsShowAthelete,
		IsShowReport = @b_IsShowReport,
		IsShowRecord = @b_IsShowRecord,
		IsShowSummary = @b_IsShowSummary,
		ModifiedBy = @n_ModifiedBy,
		ModifiedDateTime = @d_ModifiedDateTime
	WHERE EventID = @n_EventID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateEvent] TO USER
GO*/