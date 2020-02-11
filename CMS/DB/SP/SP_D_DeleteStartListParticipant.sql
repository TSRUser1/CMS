IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteStartListParticipant' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteStartListParticipant
END
GO

/*************************************************************************
* Name				: SP_D_DeleteStartListParticipant
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Delete participant in Start List
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteStartListParticipant]
(
	@n_ParticipantInScheduleID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_ParticipantInSchedule
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ParticipantInScheduleID = @n_ParticipantInScheduleID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteStartListParticipant] TO USER
GO*/