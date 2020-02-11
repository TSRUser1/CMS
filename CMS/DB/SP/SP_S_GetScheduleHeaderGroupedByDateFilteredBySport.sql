IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetScheduleHeaderGroupedByDateFilteredBySport' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetScheduleHeaderGroupedByDateFilteredBySport
END
GO

/*************************************************************************
* Name				: SP_S_GetScheduleHeaderGroupedByDateFilteredBySport
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: Return schedule header group by date filtered by sport
*************************************************************************/
CREATE PROCEDURE SP_S_GetScheduleHeaderGroupedByDateFilteredBySport
(
	@n_SportID			int
)
AS
BEGIN
	SELECT 
		CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS [Date],
		IIF(SUM(SC.IsMedalGame) > 0, 1 ,0) AS [IsMedalDate]
	FROM T_Schedule SC
	INNER JOIN T_Event EV
	ON SC.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport SP
	ON SP.SportID = EV.SportID
		AND SP.IsActive = 1
	WHERE SC.IsActive = 1
	AND (SP.SportID = @n_SportID OR @n_SportID IS NULL)
	AND SC.ScheduleDateTime IS NOT NULL
	AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
	GROUP BY CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10))
	ORDER BY [Date]
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetScheduleHeaderGroupedByDateFilteredBySport] TO USER
GO*/