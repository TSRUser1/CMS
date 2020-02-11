IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'V' 
			AND	name = 'vw_CountryInSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP VIEW vw_CountryInSchedule
END
GO

/*************************************************************************
* Name				: vw_CountryInSchedule
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: view to get distinct country in head to head schedule
*************************************************************************/

CREATE VIEW [dbo].[vw_CountryInSchedule]
AS
(
	SELECT DISTINCT
		tempTable.ScheduleID,
		tempTable.TeamID,
		tempTable.CountryID,
		tempTable.CountryName,
		tempTable.IconFilePath,
		CASE WHEN [TotalParticipantsInTeam] = 1 THEN 1 ELSE 0 END AS [IsIndividualGame],
		CASE WHEN [TotalParticipantsInTeam] = 1 THEN tempTable.ParticipantID ELSE NULL END AS [ParticipantID],
		CASE WHEN [TotalParticipantsInTeam] = 1 THEN tempTable.FullName ELSE NULL END AS [FullName]
	FROM
	(
		SELECT 
			SC.ScheduleID,
			PTIS.TeamID,
			TC.CountryID,
			TC.CountryName,
			TC.ISOCode3 AS CountryCode,
			TC.IconFilePath,
			PT.ParticipantID,
			PT.FullName,
			COUNT(*) OVER (PARTITION BY SC.ScheduleID, PTIS.TeamID, TC.CountryID) AS [TotalParticipantsInTeam]
		FROM T_ParticipantInSchedule PTIS
		INNER JOIN T_Schedule SC
		ON PTIS.ScheduleID = SC.ScheduleID
			AND SC.IsActive = 1
		INNER JOIN T_Participant PT
		ON PTIS.ParticipantID = PT.ParticipantID
			AND PT.IsActive = 1
		INNER JOIN T_Country TC
		ON PT.CountryID = TC.CountryID
			AND TC.IsActive = 1
		WHERE PTIS.IsActive = 1
	) tempTable
)
GO


