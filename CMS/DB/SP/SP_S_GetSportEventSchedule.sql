IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetSportEventSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetSportEventSchedule
END
GO

/*************************************************************************
* Name				: SP_S_GetSportEventSchedule
* Author			: Ramani
* Create date		: 01-Oct-2015
* Description		: Return Sport , Event and Schedule Details
*************************************************************************/
CREATE PROCEDURE [SP_S_GetSportEventSchedule]
(
	@n_ScheduleID			int
	,@n_EventID			int
	,@n_SportID			int
)
AS
BEGIN

	SELECT	SC.*,
	TE.EventID,
	TE.EventCode,
	TE.EventName,
	TE.GenderID,
	TRG.ReferenceName AS GenderName,
	TE.EventTypeID,
	TE.ExternalEventID,
	TE.ExternalEventCode,
	TE.EventFooterNote,
	TE.IsTogleHtmlMode,
	TE.IsShowResult,
	TE.IsShowMedal,
	TE.IsShowAthelete,
	TE.IsShowReport,
	TE.IsShowRecord,
	TE.IsShowSummary,
	TS.SportID,
	TS.ExternalSportID,
	TS.ExternalSportCode,
	TS.SportName,
	TS.SportCode,
	TS.ImageFilePath,
	TS.HasRecord,
	(SELECT IIF(COUNT(ScheduleID) = 0, 0, 1)
		FROM T_Schedule
		WHERE PlayFormatID = 2 AND EventID = TE.EventID) AS IsLeague,
	(SELECT IIF(COUNT(ScheduleID) = 0, 0, 1)
		FROM T_Schedule
		WHERE PlayFormatID = 1 AND EventID = TE.EventID) AS IsKnockout,
	(SELECT IIF(COUNT(ScheduleID) = 0, 0, 1)
		FROM T_Schedule
		WHERE PlayFormatID = 3 AND EventID = TE.EventID) AS IsTimeDistancePoints
	FROM	T_Schedule AS SC
	INNER JOIN T_Event AS TE ON SC.EventID = TE.EventID
	INNER JOIN T_Sport AS TS ON TE.SportID = TS.SportID
	LEFT JOIN  T_Reference AS TRG ON TE.GenderID = TRG.ReferenceInternalID AND TRG.ReferenceCategoryID = 2
	WHERE	(SC.ScheduleID = @n_ScheduleID or @n_ScheduleID IS NULL)
	AND (TE.EventID = @n_EventID or @n_EventID IS NULL)
	AND (TS.SportID = @n_SportID or @n_SportID IS NULL)
	AND SC.IsActive = 1	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetSportEventSchedule] TO USER
GO*/