IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteStartListByScheduleIDAndParticipantID' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteStartListByScheduleIDAndParticipantID
END
GO

/*************************************************************************
* Name				: SP_D_DeleteStartListByScheduleIDAndParticipantID
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Delete participant in Start List
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteStartListByScheduleIDAndParticipantID]
(
	@n_ScheduleID			int,
	@n_ParticipantID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_ParticipantInSchedule
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ScheduleID = @n_ScheduleID
	AND ParticipantID = @n_ParticipantID

	SELECT @@ROWCOUNT AS UpdatedRow
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteStartListByScheduleIDAndParticipantID] TO USER
GO*/