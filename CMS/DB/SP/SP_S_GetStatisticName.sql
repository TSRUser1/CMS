IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetStatisticName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetStatisticName
END
GO

/*************************************************************************
* Name				: SP_S_GetStatisticName
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Return Statistic Name for Schedule
*************************************************************************/
CREATE PROCEDURE [SP_S_GetStatisticName]
(
	@n_ScheduleID			int
)
AS
BEGIN

	SELECT	*
	FROM	T_StatisticName
	WHERE	ScheduleID = @n_ScheduleID
			and IsActive = 1			
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetStatisticName] TO USER
GO*/