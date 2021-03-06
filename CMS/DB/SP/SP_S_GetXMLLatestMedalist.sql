IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetXMLLatestMedalist' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetXMLLatestMedalist
END
GO

/*************************************************************************
* Name				: SP_S_GetXMLLatestMedalist
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: Return schedule header (by date/sport)
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetXMLLatestMedalist]
AS
BEGIN
	SELECT TOP 5
		ParticipantOrTeamID AS ParticipantID,
		TGender.ReferenceCode,
		ParticipantOrTeamName AS FullName,
		SP.SportCode,
		SP.SportID,
		SP.SportName,
		SP.ImageFilePath AS [SportImageFilePath],
		CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS ScheduleDate,
		SC.ScheduleDateTime,
		EV.EventID,
		EV.EventName,
		C.ISOCode3,
		TMedal.ReferenceName AS [Medal],
		TMedal.ReferenceCode AS [MedalCode],
		CASE TMedal.ReferenceCode 
			WHEN 'GOLD' THEN '~/img/medal/gold.png'
			WHEN 'SILVER' THEN '~/img/medal/silver.png'
			WHEN 'BRONZE' THEN '~/img/medal/bronze.png'
		ELSE NULL
		END AS [MedalIconFilePath],
		MedalTable.*
	FROM
	(
		--get team game info + medal
		SELECT
			vwTIS.ScheduleID,
			vwTIS.IsIndividualGame,
			vwTIS.TeamID AS ParticipantOrTeamID,
			vwTIS.TeamName AS ParticipantOrTeamName,
			vwTIS.CountryID,
			vwTIS.CountryName,
			'' AS ParticipantImageFilePath,
			vwTIS.IconFilePath AS ParticipantCountryImageFilePath,
			tableTeamMedal.MedalID
		FROM vw_TeamInSchedule vwTIS 
		INNER JOIN 
		(	
			--get team game medal result
			SELECT *, MedalID AS ResultPosition
			FROM 
			(
				--get team game medal result
				SELECT DISTINCT
					PTIE.TeamID,
					MAX(TS.MedalID) AS MedalID
				FROM T_ParticipantInSchedule PTIS
				INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS
				ON PTIS.TeamID = SIPIS.TeamID
				INNER JOIN T_Score TS
				ON SIPIS.ScoreID = TS.ScoreID
					AND TS.IsActive = 1
				INNER JOIN T_Schedule SC
				ON PTIS.ScheduleID = SC.ScheduleID
					AND SC.IsActive = 1
				INNER JOIN T_ParticipantInEvent PTIE
				ON PTIS.ParticipantID = PTIE.ParticipantID
					AND SC.EventID = PTIE.EventID
					AND PTIE.IsActive = 1
				WHERE PTIS.IsActive = 1
				GROUp BY PTIE.TeamID ) teamMedal
		) tableTeamMedal
		ON vwTIS.TeamID = tableTeamMedal.TeamID
			AND vwTIS.IsIndividualGame = 0
		UNION
		--get individual game info + medal
		SELECT
			vwTIS.ScheduleID,
			vwTIS.IsIndividualGame,
			PT.ParticipantID AS ParticipantOrTeamID,
			PT.FullName AS ParticipantOrTeamName,
			vwTIS.CountryID,
			vwTIS.CountryName,
			--todo: replace NULL player image at line below
			ISNULL(NULL, '~/img/player/avatar-big.jpg') AS ParticipantImageFilePath,
			vwTIS.IconFilePath AS ParticipantCountryImageFilePath,
			tableIndividualMedal.MedalID
		FROM vw_TeamInSchedule vwTIS
		INNER JOIN 
		(
			--get individual game medal result
			SELECT DISTINCT
				PTIS.ParticipantID,
				TS.MedalID,
				TS.ResultPosition,
				TS.ScoreID
			FROM T_ParticipantInSchedule PTIS
			INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS
			ON PTIS.ParticipantInScheduleID = SIPIS.ParticipantInScheduleID
			INNER JOIN T_Score TS
			ON SIPIS.ScoreID = TS.ScoreID
				AND TS.IsActive = 1
			INNER JOIN T_Schedule SC
			ON PTIS.ScheduleID = SC.ScheduleID
				AND SC.IsActive = 1
			INNER JOIN T_ParticipantInEvent PTIE
			ON PTIS.ParticipantID = PTIE.ParticipantID
				AND SC.EventID = PTIE.EventID
				AND PTIE.IsActive = 1
			WHERE PTIS.IsActive = 1
		) tableIndividualMedal
		ON vwTIS.ParticipantID = tableIndividualMedal.ParticipantID
			AND vwTIS.IsIndividualGame = 1
		INNER JOIN T_Participant PT
		ON vwTIS.ParticipantID = PT.ParticipantID
			AND PT.IsActive = 1
	) MedalTable
	INNER JOIN T_Schedule SC
	ON MedalTable.ScheduleID = SC.ScheduleID
		AND SC.IsMedalGame = 1
		AND SC.IsActive = 1
	INNER JOIN T_Event EV
	ON SC.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Reference AS TGender
	ON TGender.ReferenceInternalID = EV.GenderID
	AND TGender.ReferenceCategoryID = 2
	AND TGender.IsActive = 1
	INNER JOIN T_Sport SP
	ON EV.SportID = SP.SportID
		AND SP.IsActive = 1
	INNER JOIN T_Reference TMedal
	ON MedalTable.MedalID = TMedal.ReferenceInternalID
		AND TMedal.ReferenceCategoryID = 6
		AND TMedal.IsActive = 1
	INNER JOIN T_Country AS C
	ON C.CountryID = MedalTable.CountryID
	WHERE TMedal.ReferenceCode = 'GOLD'
	ORDER BY SP.SportName, EV.EventName, 
	CASE	WHEN TMedal.[ReferenceCode] = 'GOLD' THEN 0
			WHEN TMedal.[ReferenceCode] = 'SILVER' THEN 1
			WHEN TMedal.[ReferenceCode] = 'BRONZE' THEN 2
			ELSE 4 END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetXMLLatestMedalist] TO USER
GO*/