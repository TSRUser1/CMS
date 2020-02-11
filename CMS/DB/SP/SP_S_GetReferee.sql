IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetReferee' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetReferee
END
GO

/*************************************************************************
* Name				: SP_S_GetReferee
* Author			: Ramani Ganason
* Create date		: 02-Oct-2015
* Description		: Return Referee for Schedule
*************************************************************************/
CREATE PROCEDURE [SP_S_GetReferee]
(
	@n_ScheduleID			int
)
AS
BEGIN

	SELECT	*
	FROM	T_Referee
	WHERE	ScheduleID = @n_ScheduleID
			and IsActive = 1			
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetReferee] TO USER
GO*/