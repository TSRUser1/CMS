IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'V' 
			AND	name = 'vw_TeamVersus' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP VIEW vw_TeamVersus
END
GO

/*************************************************************************
* Name				: vw_TeamVersus
* Author			: Alan Goh
* Create date		: 29-Aug-2015
* Description		: view to get team A vs team B in schedule
*************************************************************************/

CREATE VIEW [dbo].[vw_TeamVersus] --WITH SCHEMABINDING 
AS
(
	SELECT 
			tmpTeamInSchedule.ScheduleID,
			tmpTeamInSchedule.[IsIndividualGame],
			tmpTeamInSchedule.CountryID AS [CountryID1],
			tmpTeamInSchedule.CountryName AS [CountryName1],
			tmpTeamInSchedule.ISOCode3 AS [CountryCode1],
			tmpTeamInSchedule.SmallIconFilePath AS [FlagImageFilePath1],
			tmpTeamInSchedule.TeamID AS [TeamID1],
			tmpTeamInSchedule.TeamName AS [TeamName1],
			tmpTeamInSchedule.ParticipantID AS [ParticipantID1],
			tmpTeamInSchedule.FullName AS [FullName1],
			tmpTeamInSchedule.ScoreFinal AS [ScoreFinal1],
			tmpTeamInSchedule2.CountryID AS [CountryID2],
			tmpTeamInSchedule2.CountryName AS [CountryName2],
			tmpTeamInSchedule2.ISOCode3 AS [CountryCode2],
			tmpTeamInSchedule2.SmallIconFilePath AS [FlagImageFilePath2],
			tmpTeamInSchedule2.TeamID AS [TeamID2],
			tmpTeamInSchedule2.TeamName AS [TeamName2],
			tmpTeamInSchedule2.ParticipantID AS [ParticipantID2],
			tmpTeamInSchedule2.FullName AS [FullName2],
			tmpTeamInSchedule2.ScoreFinal AS [ScoreFinal2]
		FROM
		(
			SELECT
				vw_TeamInSchedule.[ScheduleID]
				,vw_TeamInSchedule.[EventType]
				,vw_TeamInSchedule.[IsIndividualGame]
				,vw_TeamInSchedule.[ParticipantID]
				,vw_TeamInSchedule.[FullName]
				,vw_TeamInSchedule.[TeamID]
				,vw_TeamInSchedule.[TeamName]
				,vw_TeamInSchedule.[CountryID]
				,vw_TeamInSchedule.[CountryName]
				,vw_TeamInSchedule.[ISOCode3]
				,vw_TeamInSchedule.[IconFilePath]
				,vw_TeamInSchedule.[SmallIconFilePath]
				,vw_TeamInSchedule.[ScoreFinal]
				,vw_TeamInSchedule.[ResultPosition]
				,vw_TeamInSchedule.[BreakRecord]
				,vw_TeamInSchedule.[Ranking]
				,RANK() OVER (PARTITION BY ScheduleID ORDER BY SortID ASC, TeamID ASC, ParticipantID, CountryID ASC) AS RowNum
			FROM vw_TeamInSchedule
		) AS tmpTeamInSchedule
		INNER JOIN vw_TeamInSchedule tmpTeamInSchedule2
		ON tmpTeamInSchedule.ScheduleID = tmpTeamInSchedule2.ScheduleID
			AND 
			(
				--if individual game, then participantid must be different
				(tmpTeamInSchedule.[IsIndividualGame] = 1 AND tmpTeamInSchedule.ParticipantID <> tmpTeamInSchedule2.ParticipantID)
				OR
				--else if team game, then teamid must be different
				(tmpTeamInSchedule.[IsIndividualGame] = 0 AND tmpTeamInSchedule.TeamID <> tmpTeamInSchedule2.TeamID)
			)
			AND tmpTeamInSchedule.RowNum = 1
		INNER JOIN T_Schedule SC WITH (NOLOCK)
		ON tmpTeamInSchedule.ScheduleID = SC.ScheduleID
			AND SC.HeadToHead = 1
			AND SC.IsActive = 1
)
GO
