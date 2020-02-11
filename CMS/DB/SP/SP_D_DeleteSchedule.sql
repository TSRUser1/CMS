IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteSchedule
END
GO

/*************************************************************************
* Name				: SP_D_DeleteSchedule
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Update schedule
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteSchedule]
(
	@n_ScheduleID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Schedule
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ScheduleID = @n_ScheduleID

SELECT @@ROWCOUNT AS UpdatedRow
	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteSchedule] TO USER
GO*/