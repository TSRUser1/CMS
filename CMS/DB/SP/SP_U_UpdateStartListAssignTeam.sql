IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateStartListAssignTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateStartListAssignTeam
END
GO

/*************************************************************************
* Name				: SP_U_UpdateStartListAssignTeam
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Update Start List with assign team
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateStartListAssignTeam]
(
	@n_ParticipantInScheduleID   	INT,
	@n_TeamID     					INT,
	@n_ModifiedBy					INT,
	@d_ModifiedDateTime				DATETIME
)
AS
BEGIN



	UPDATE T_ParticipantInSchedule
	Set TeamID            = @n_TeamID,
	    SortID            = 0,
		ModifiedDateTime  = @d_ModifiedDateTime,
		ModifiedBy        = @n_ModifiedBy		
	WHERE ParticipantInScheduleID = @n_ParticipantInScheduleID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateStartListAssignTeam] TO USER
GO*/