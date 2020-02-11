IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetScheduleHeaderGroupedBySportFilteredByDate' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetScheduleHeaderGroupedBySportFilteredByDate
END
GO

/*************************************************************************
* Name				: SP_S_GetScheduleHeaderGroupedBySportFilteredByDate
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: Return schedule header grouped by sport filtered by date
*************************************************************************/
CREATE PROCEDURE SP_S_GetScheduleHeaderGroupedBySportFilteredByDate
(
	@d_Date				datetime
)
AS
BEGIN
	SELECT DISTINCT 
		SP.SportID,
		SP.SportName,
		SP.ImageFilePath
	FROM T_Schedule SC
	INNER JOIN T_Event EV
	ON SC.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport SP
	ON SP.SportID = EV.SportID
		AND SP.IsActive = 1
	WHERE SC.IsActive = 1
	--AND (CAST(SC.ScheduleDateTime AS DATE) = CAST(@d_Date AS DATE) OR @d_Date IS NULL)
	AND ((SC.ScheduleDateTime BETWEEN @d_Date AND DATEADD (day , 1 , @d_Date )) OR @d_Date IS NULL)
	AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
	ORDER BY SP.SportName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetScheduleHeaderGroupedBySportFilteredByDate] TO USER
GO*/
