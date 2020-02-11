IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateStartListPosition' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateStartListPosition
END
GO

/*************************************************************************
* Name				: SP_U_UpdateStartListPosition
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Update Start List with sorting the team position
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateStartListPosition]
(
	@n_ScheduleID   	            INT,
	@n_TeamID     					INT,
	@n_ParticipantID				INT,
	@n_SortID     					INT,
	@n_ModifiedBy					INT,
	@d_ModifiedDateTime				DATETIME
)
AS
BEGIN



	UPDATE T_ParticipantInSchedule
	Set SortID            = @n_SortID,
		ModifiedDateTime  = @d_ModifiedDateTime,
		ModifiedBy        = @n_ModifiedBy		
	WHERE ScheduleID = @n_ScheduleID
	AND   
	(
	       (TeamID = @n_TeamID AND @n_ParticipantID is null)
		   OR
		   (ParticipantID = @n_ParticipantID AND @n_TeamID is null)
	)

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateStartListPosition] TO USER
GO*/