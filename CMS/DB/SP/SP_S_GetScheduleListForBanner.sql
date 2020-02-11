IF EXISTS 
(
SELECT	* 
FROM	sys.objects 
WHERE	type = 'P' 
		AND	name = 'SP_S_GetScheduleListForBanner' 
		AND schema_name(schema_id) = 'dbo'
)
BEGIN
DROP  PROCEDURE  SP_S_GetScheduleListForBanner
END
GO

/*************************************************************************
* Name				: SP_S_GetScheduleListForBanner
* Author			: Ramani
* Create date		: 20-Aug-2015
* Description		: Return schedule list for banner
*************************************************************************/
CREATE PROCEDURE [SP_S_GetScheduleListForBanner]
(
	@n_EventID				int
)
AS
BEGIN

SELECT DISTINCT TSC.ScheduleID,
            TSC.EventID,
            TSC.ScheduleName,
            TSC.RoundName,
            TSC.IsMedalGame,
            TSC.ScheduleDateTime,
            TRS.ReferenceName AS StatusName,
            TSP.SportName,
            IIF(TSC.HeadToHead = 1, (STUFF((SELECT CAST(', ' + TTC.CountryName AS VARCHAR(MAX))
                        FROM T_Country AS TTC
						RIGHT JOIN (SELECT DISTINCT TTP.CountryID, ISNULL(TTPS.TeamID,TTPS.ParticipantInScheduleID) AS TeamID, TTPS.SortID
                            FROM T_Schedule AS TTSC
                            LEFT JOIN T_ParticipantInSchedule AS TTPS ON TTSC.ScheduleID = TTPS.ScheduleID AND TTPS.IsActive = 1
                            LEFT JOIN T_Participant AS TTP ON TTPS.ParticipantID = TTP.ParticipantID
							--LEFT JOIN T_ParticipantInEvent AS TPIE ON TPIE.ParticipantID = TTPS.ParticipantID AND TPIE.EventID = TTSC.EventID
                            WHERE TTSC.ScheduleID = TSC.ScheduleID  AND TTSC.IsActive = 1) as temp ON temp.CountryID = TTC.CountryID ORDER BY SortID
                        FOR XML PATH ('')), 1, 2, '')), NULL) AS CountryName,
            IIF(TSC.HeadToHead = 1, (STUFF((SELECT CAST(',' + TTC.IconFilePath AS VARCHAR(MAX))
                        FROM T_Country AS TTC
                        RIGHT JOIN (SELECT DISTINCT TTP.CountryID, ISNULL(TTPS.TeamID,TTPS.ParticipantInScheduleID) AS TeamID, TTPS.SortID
                            FROM T_Schedule AS TTSC
                            LEFT JOIN T_ParticipantInSchedule AS TTPS ON TTSC.ScheduleID = TTPS.ScheduleID AND TTPS.IsActive = 1
                            LEFT JOIN T_Participant AS TTP ON TTPS.ParticipantID = TTP.ParticipantID
							--LEFT JOIN T_ParticipantInEvent AS TPIE ON TPIE.ParticipantID = TTPS.ParticipantID AND TPIE.EventID = TTSC.EventID
                            WHERE TTSC.ScheduleID = TSC.ScheduleID  AND TTSC.IsActive = 1) as temp ON temp.CountryID = TTC.CountryID ORDER BY SortID
                        FOR XML PATH ('')), 1, 2, '')), NULL) AS FlagImageFilePath
	FROM T_Schedule AS TSC
	LEFT JOIN T_ParticipantInSchedule AS TPS ON TSC.ScheduleID = TPS.ScheduleID
	AND TPS.IsActive = 1
	LEFT JOIN T_Participant AS TP ON TPS.ParticipantID = TP.ParticipantID
	LEFT JOIN T_Country AS TC ON TP.CountryID = TC.CountryID
	LEFT JOIN T_Event AS TE ON TSC.EventID = TE.EventID
	AND TSC.IsActive = 1
	LEFT JOIN T_Sport AS TSP ON TE.SportID = TSP.SportID
	LEFT JOIN T_Reference AS TRS ON TSC.StatusCodeID = TRS.ReferenceInternalID
	AND TRS.ReferenceCategoryID = 5
	WHERE TSC.EventID = @n_EventID
	AND TSC.IsActive = 1
	AND (TSC.IsPublishSchedule <> 0 OR TSC.IsPublishSchedule IS NULL)
	ORDER BY TSC.ScheduleDateTime, TSC.ScheduleName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetScheduleListForBanner] TO USER
GO*/