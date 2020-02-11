IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'V' 
			AND	name = 'vw_TeamInSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP VIEW vw_TeamInSchedule
END
GO

/*************************************************************************
* Name				: vw_TeamInSchedule
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: view to get distinct team in schedule
*************************************************************************/

CREATE VIEW [dbo].[vw_TeamInSchedule] --WITH SCHEMABINDING
AS
(
	SELECT DISTINCT
		tempTable.ScheduleID,
		tempTable.SortID,
		tempTable.EventType,
		tempTable.IsIndividualGame,
		tempTable.ParticipantID,
		tempTable.FullName,
		tempTable.TeamID,
		tempTable.TeamName,
		tempTable.CountryID,
		tempTable.CountryName,
		tempTable.ISOCode3,
		tempTable.IconFilePath,
		tempTable.SmallIconFilePath,
		tempTable.ScoreFinal,
		tempTable.ResultPosition,
		tempTable.BreakRecord,
		RANK() OVER (PARTITION BY tempTable.ScheduleID ORDER BY CASE WHEN tempTable.ResultPosition > 0 THEN 0 ELSE 1 END, tempTable.ResultPosition ASC, tempTable.TeamID ASC, tempTable.ParticipantID ASC) AS [Ranking],
		COUNT(CASE WHEN tempTable.ResultPosition = 1 THEN 1 ELSE NULL END) OVER (PARTITION BY tempTable.ScheduleID)/ (CASE WHEN tempTable.IsIndividualGame = 1 THEN 1 ELSE tempTable.[NoOfPeopleInTeam] END) AS [NoOfWinners]
	FROM
	(
		SELECT
			SC.ScheduleID,
			PTIS.SortID,
			EventTypeTable.ReferenceCode AS EventType,
			CASE WHEN EventTypeTable.ReferenceCode = 'INDIVIDUAL' THEN 1 ELSE 0 END AS [IsIndividualGame],
			CASE WHEN EventTypeTable.ReferenceCode = 'INDIVIDUAL' THEN PT.ParticipantID ELSE NULL END AS [ParticipantID],
			CASE WHEN EventTypeTable.ReferenceCode = 'INDIVIDUAL' THEN PT.FullName ELSE NULL END AS [FullName],
			CASE WHEN EventTypeTable.ReferenceCode <> 'INDIVIDUAL' THEN TT.TeamID ELSE NULL END AS [TeamID],
			CASE WHEN EventTypeTable.ReferenceCode <> 'INDIVIDUAL' THEN TT.TeamName ELSE NULL END AS [TeamName],
			TC.CountryID,
			TC.CountryName,
			TC.ISOCode3,
			TC.IconFilePath,
			TC.SmallIconFilePath,
			TS.ScoreFinal,
			TS.ResultPosition,
			TS.BreakRecord,
			COUNT(*) OVER (PARTITION BY SC.ScheduleID, TT.TeamID) AS [NoOfPeopleInTeam]
		FROM T_ParticipantInSchedule PTIS WITH (NOLOCK) 
		INNER JOIN T_Schedule SC WITH (NOLOCK)
		ON PTIS.ScheduleID = SC.ScheduleID
			AND SC.IsActive = 1
		INNER JOIN T_Event EV WITH (NOLOCK)
		ON SC.EventID = EV.EventID
			AND EV.IsActive = 1
		INNER JOIN T_Participant PT WITH (NOLOCK)
		ON PTIS.ParticipantID = PT.ParticipantID
			AND PT.IsActive = 1
		INNER JOIN T_Country TC WITH (NOLOCK)
		ON PT.CountryID = TC.CountryID
			AND TC.IsActive = 1
		LEFT JOIN T_Team TT WITH (NOLOCK)
		ON PTIS.TeamID = TT.TeamID
			AND TT.IsActive = 1
		LEFT JOIN T_ScoreInParticipantInSchedule SIPIC WITH (NOLOCK)
		ON SIPIC.ScheduleID = PTIS.ScheduleID
			AND 
			(
				(SIPIC.TeamID = PTIS.TeamID)
				OR (SIPIC.ParticipantInScheduleID = PTIS.ParticipantInScheduleID)
			)
		LEFT JOIN T_Score TS WITH (NOLOCK)
		ON SIPIC.ScoreID = TS.ScoreID
			AND TS.IsActive = 1
		INNER JOIN T_Reference EventTypeTable WITH (NOLOCK)
		ON EV.EventTypeID = EventTypeTable.ReferenceInternalID
			AND EventTypeTable.ReferenceCategoryID = 4
			AND EventTypeTable.IsActive = 1
		WHERE PTIS.IsActive = 1
	) tempTable
	--only take records where
	--individual games and have participant id
	--team games and have team id
	WHERE (tempTable.EventType = 'INDIVIDUAL' AND tempTable.ParticipantID IS NOT NULL)
	OR (tempTable.EventType <> 'INDIVIDUAL' AND tempTable.TeamID IS NOT NULL)
)
GO