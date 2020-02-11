IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetScoreName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetScoreName
END
GO

/*************************************************************************
* Name				: SP_S_GetScoreName
* Author			: Ramani Ganason
* Create date		: 28-Aug-2015
* Description		: Return ScoreName for Schedule
*************************************************************************/
CREATE PROCEDURE [SP_S_GetScoreName]
(
	@n_ScheduleID			int
)
AS
BEGIN

	SELECT	*
	FROM	T_ScoreName
	WHERE	ScheduleID = @n_ScheduleID
			and IsActive = 1			
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetScoreName] TO USER
GO*/