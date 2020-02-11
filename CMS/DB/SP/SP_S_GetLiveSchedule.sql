SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
GO

IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetLiveSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetLiveSchedule
END
GO

/*************************************************************************
* Name				: SP_S_GetLiveSchedule
* Author			: Ramani
* Create date		: 12-Dec-2015
* Description		: Return live schedule list based on date
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetLiveSchedule]
(
	@d_StartDateTime	datetime,
	@d_EndDateTime		datetime
)
AS
BEGIN
	
	DECLARE @l_d_StartDateTime DATETIME, @l_d_EndDateTime DATETIME
			
	SET @l_d_StartDateTime = @d_StartDateTime
	SET @l_d_EndDateTime = @d_EndDateTime
	
	SELECT 
		TS.ScheduleID,
		TS.ScheduleName,
		TS.Location,
		TS.Venue,
		TS.EventID,
		TE.EventName,
		TS.ScheduleDateTime,
		TSP.ImageFilePath AS SportImageFilePath,
		TS.StatusCodeID
FROM 
	T_Schedule TS
	RIGHT JOIN T_Event TE ON TE.EventID = TS.EventID
	RIGHT JOIN T_Sport TSP ON TSP.SportID = TE.SportID
WHERE 
	TS.ScheduleDateTime BETWEEN @l_d_StartDateTime AND @l_d_EndDateTime
	AND TS.StatusCodeID < 7
	AND TS.IsActive <> 0
	AND TE.IsActive <> 0
	AND TS.IsPublishSchedule = 1
ORDER BY 
	TS.ScheduleDateTime, TSP.SportName, TE.EventName, TS.ScheduleName
END
GO

COMMIT TRANSACTION
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetLiveSchedule] TO USER
GO*/
