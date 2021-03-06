IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetMedalAndFinalRanking' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetMedalAndFinalRanking
END
GO

/*************************************************************************
* Name				: SP_S_GetMedalAndFinalRanking
* Author			: Edwind
* Create date		: 8-Sep-2015
* Description		: Return medal and final ranking by eventid
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetMedalAndFinalRanking]
(
	@n_EventID			int
)
AS
BEGIN
	DECLARE @l_n_EventID INT

	SET @l_n_EventID = @n_EventID
	
	SELECT
		CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS ScheduleDate,
		SC.ScheduleDateTime,
		EV.EventID,
		EV.EventName,
		EV.EventTypeID,
		TMedal.ReferenceName AS [Medal],
		TMedal.ReferenceCode AS [MedalCode],
		CASE TMedal.ReferenceCode 
			WHEN 'GOLD' THEN '~/img/medal/gold.png'
			WHEN 'SILVER' THEN '~/img/medal/silver.png'
			WHEN 'BRONZE' THEN '~/img/medal/bronze.png'
		ELSE NULL
		END AS [MedalIconFilePath],
		MedalTable.*,
		ParticipantOrTeamID AS ParticipantID,
		ParticipantOrTeamName AS FullName,
		CountryID,
		CountryName,
		ParticipantCountryImageFilePath AS IconFilePath
	FROM
	(
		--get team game info + medal
		SELECT
			vwTIS.ScheduleID,
			vwTIS.IsIndividualGame,
			vwTIS.TeamID AS ParticipantOrTeamID,
			UPPER(vwTIS.TeamName) AS ParticipantOrTeamName,
			vwTIS.CountryID,
			vwTIS.CountryName,
			NULL AS ParticipantImageFilePath,
			vwTIS.IconFilePath AS ParticipantCountryImageFilePath,
			tableTeamMedal.MedalID,
			tableTeamMedal.ResultPosition
		FROM vw_TeamInSchedule vwTIS WITH (NOLOCK)
		INNER JOIN 
		(	
			SELECT *, MedalID AS ResultPosition
			FROM 
			(
				--get team game medal result
				SELECT DISTINCT
					SC.ScheduleID, 
					PTIS.TeamID,
					MAX(TS.MedalID) AS MedalID
				FROM T_ParticipantInSchedule PTIS WITH (NOLOCK)
				INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
				ON PTIS.TeamID = SIPIS.TeamID 
				AND PTIS.ScheduleID = SIPIS.ScheduleID
				INNER JOIN T_Score TS WITH (NOLOCK)
				ON SIPIS.ScoreID = TS.ScoreID
					AND TS.IsActive = 1
				INNER JOIN T_Schedule SC WITH (NOLOCK)
				ON PTIS.ScheduleID = SC.ScheduleID
					AND SC.IsActive = 1
				WHERE PTIS.IsActive = 1
				AND PTIS.TeamID IS NOT NULL
				AND (SC.EventID = @l_n_EventID OR @l_n_EventID IS NULL)
				GROUP BY SC.ScheduleID, PTIS.TeamID ) teamMedal
		) tableTeamMedal
		ON vwTIS.TeamID = tableTeamMedal.TeamID
			AND vwTIS.ScheduleID = tableTeamMedal.ScheduleID
			AND vwTIS.IsIndividualGame = 0
		UNION
		--get individual game info + medal
		SELECT
			vwTIS.ScheduleID,
			vwTIS.IsIndividualGame,
			PT.ParticipantID AS ParticipantOrTeamID,
			UPPER(PT.FullName) AS ParticipantOrTeamName,
			vwTIS.CountryID,
			vwTIS.CountryName,
			ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar-big.jpg') AS ParticipantImageFilePath,
			vwTIS.IconFilePath AS ParticipantCountryImageFilePath,
			tableIndividualMedal.MedalID,
			tableIndividualMedal.ResultPosition
		FROM vw_TeamInSchedule vwTIS WITH (NOLOCK)
		INNER JOIN 
		(
			--get individual game medal result
			SELECT DISTINCT
				SC.ScheduleID,
				PTIS.ParticipantID,
				TS.MedalID,
				TS.ResultPosition,
				TS.ScoreID
			FROM T_ParticipantInSchedule PTIS WITH (NOLOCK)
			INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
			ON PTIS.ParticipantInScheduleID = SIPIS.ParticipantInScheduleID
			INNER JOIN T_Score TS WITH (NOLOCK)
			ON SIPIS.ScoreID = TS.ScoreID
				AND TS.IsActive = 1
			INNER JOIN T_Schedule SC WITH (NOLOCK)
			ON PTIS.ScheduleID = SC.ScheduleID
				AND SC.IsActive = 1
			WHERE PTIS.IsActive = 1
			AND (SC.EventID = @l_n_EventID OR @l_n_EventID IS NULL)
		) tableIndividualMedal
		ON vwTIS.ParticipantID = tableIndividualMedal.ParticipantID
			AND vwTIS.ScheduleID = tableIndividualMedal.ScheduleID
			AND vwTIS.IsIndividualGame = 1
		INNER JOIN T_Participant PT WITH (NOLOCK)
		ON vwTIS.ParticipantID = PT.ParticipantID
			AND PT.IsActive = 1
	) MedalTable
	INNER JOIN T_Schedule SC WITH (NOLOCK)
	ON MedalTable.ScheduleID = SC.ScheduleID
		AND SC.IsMedalGame = 1
		AND SC.IsActive = 1
	INNER JOIN T_Event EV WITH (NOLOCK)
	ON SC.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Reference TMedal WITH (NOLOCK)
	ON MedalTable.MedalID = TMedal.ReferenceInternalID
		AND TMedal.ReferenceCategoryID = 6
		AND TMedal.IsActive = 1
	WHERE (EV.EventID = @l_n_EventID OR @l_n_EventID IS NULL)
	ORDER BY 
	CASE	WHEN TMedal.[ReferenceCode] = 'GOLD' THEN 0
			WHEN TMedal.[ReferenceCode] = 'SILVER' THEN 1
			WHEN TMedal.[ReferenceCode] = 'BRONZE' THEN 2
			ELSE 4 END,
	MedalTable.ResultPosition ASC
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetMedalAndFinalRanking] TO USER
GO*/
