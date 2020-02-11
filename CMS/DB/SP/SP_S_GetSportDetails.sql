IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetSportDetails' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetSportDetails
END
GO

/*************************************************************************
* Name				: SP_S_GetSportDetails
* Author			: Ramani
* Create date		: 27-Sep-2015
* Description		: Return Sport Details
*************************************************************************/
CREATE PROCEDURE SP_S_GetSportDetails
(
	@n_SportID				int,
	@n_ScheduleID			int,
	@n_EventID				int
)
AS
BEGIN
	IF  @n_EventID IS NULL
	BEGIN
	SET @n_EventID = (SELECT TOP 1 T_Schedule.EventID FROM T_Schedule WHERE T_Schedule.ScheduleID = @n_ScheduleID)
	END

	IF  @n_SportID IS NULL
	BEGIN
	SET @n_SportID = (SELECT TOP 1 T_Event.SportID FROM T_Event WHERE T_Event.EventID = @n_EventID)
	END

	SELECT T_Sport.SportID, T_Sport.SportName, T_Sport.ImageFilePath, 
		MIN(T_Schedule.ScheduleDateTime) AS StartEvent, 
		MAX(T_Schedule.ScheduleDateTime) AS EndEvent,
		(SELECT COUNT(PIE.ParticipantInEventID) FROM T_ParticipantInEvent AS PIE INNER JOIN T_Participant AS PT ON PIE.ParticipantID = PT.ParticipantID WHERE PIE.EventID = @n_EventID AND PT.MainCategoryId = 19 AND PIE.IsActive = 1 AND PT.IsActive = 1) AS ParticipantCount
	FROM T_Sport
	LEFT JOIN T_Event ON T_Event.SportID = T_Sport.SportID AND T_Event.IsActive = 1
	LEFT JOIN T_Schedule ON T_Schedule.EventID = T_Event.EventID AND T_Schedule.IsActive = 1
	WHERE T_Sport.IsActive = 1
	AND T_Sport.SportID = @n_SportID
	GROUP BY T_Sport.SportID, T_Sport.SportName, T_Sport.ImageFilePath
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetSportDetails] TO USER
GO*/
