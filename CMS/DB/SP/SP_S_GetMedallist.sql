IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetMedallist' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetMedallist
END
GO

/*************************************************************************
* Name				: SP_S_GetMedallist
* Author			: Edwind
* Create date		: 8-Oct-2015
* Description		: Return medallist
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetMedallist]
(
	@n_SportID			int,
	@n_CountryID		int,
	@d_Date				datetime,
	@s_Medal			nvarchar(max)
)
AS
BEGIN
	DECLARE
	@l_n_SportID		int = @n_SportID,
	@l_n_CountryID		int = @n_CountryID,
	@l_d_Date			datetime = @d_Date,
	@l_s_Medal			nvarchar(max) = @s_Medal
	
	SELECT
		SP.SportID,
		SP.SportName,
		SP.ImageFilePath AS [SportImageFilePath],
		CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS ScheduleDate,
		SC.ScheduleDateTime,
		EV.EventID,
		EV.EventName,
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
			UPPER(vwTIS.TeamName) AS ParticipantOrTeamName,
			vwTIS.CountryID,
			vwTIS.CountryName,
			'' AS ParticipantImageFilePath,
			vwTIS.IconFilePath AS ParticipantCountryImageFilePath,
			tableTeamMedal.MedalID
		FROM vw_TeamInSchedule vwTIS WITH (NOLOCK)
		INNER JOIN 
		(	
			--get team game medal result
			SELECT *, MedalID AS ResultPosition
			FROM 
			(
				--get team game medal result
				SELECT DISTINCT
					SC.ScheduleID,
					PTIE.TeamID,
					MAX(TS.MedalID) AS MedalID
				FROM T_ParticipantInSchedule PTIS WITH (NOLOCK)
				INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
				ON PTIS.TeamID = SIPIS.TeamID
					AND (PTIS.ScheduleID = SIPIS.ScheduleID)
				INNER JOIN T_Score TS WITH (NOLOCK)
				ON SIPIS.ScoreID = TS.ScoreID
					AND TS.IsActive = 1
				INNER JOIN T_Schedule SC WITH (NOLOCK)
				ON PTIS.ScheduleID = SC.ScheduleID
					AND SC.IsActive = 1
				INNER JOIN T_ParticipantInEvent PTIE WITH (NOLOCK)
				ON PTIS.ParticipantID = PTIE.ParticipantID
					AND SC.EventID = PTIE.EventID
					AND PTIE.IsActive = 1
				WHERE PTIS.IsActive = 1
				GROUp BY SC.ScheduleID, PTIE.TeamID ) teamMedal
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
			ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar.png') AS ParticipantImageFilePath,
			vwTIS.IconFilePath AS ParticipantCountryImageFilePath,
			tableIndividualMedal.MedalID
		FROM vw_TeamInSchedule vwTIS WITH (NOLOCK)
		INNER JOIN 
		(
			--get individual game medal result
			SELECT DISTINCT
				PTIS.ParticipantID,
				PTIS.ScheduleID,
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
			INNER JOIN T_ParticipantInEvent PTIE WITH (NOLOCK)
			ON PTIS.ParticipantID = PTIE.ParticipantID
				AND SC.EventID = PTIE.EventID
				AND PTIE.IsActive = 1
			WHERE PTIS.IsActive = 1
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
	INNER JOIN T_Sport SP WITH (NOLOCK)
	ON EV.SportID = SP.SportID
		AND SP.IsActive = 1
	INNER JOIN T_Reference TMedal WITH (NOLOCK)
	ON MedalTable.MedalID = TMedal.ReferenceInternalID
		AND TMedal.ReferenceCategoryID = 6
		AND TMedal.IsActive = 1
	WHERE (SP.SportID = @l_n_SportID OR @l_n_SportID IS NULL)
	AND (CAST(SC.ScheduleDateTime AS DATE) = CAST(@l_d_Date AS DATE) OR @l_d_Date IS NULL)
	AND (MedalTable.CountryID = @l_n_CountryID OR @l_n_CountryID IS NULL)
	AND (TMedal.ReferenceCode = @l_s_Medal OR @l_s_Medal IS NULL)
	ORDER BY SP.SportName, EV.EventName, 
	CASE	WHEN TMedal.[ReferenceCode] = 'GOLD' THEN 0
			WHEN TMedal.[ReferenceCode] = 'SILVER' THEN 1
			WHEN TMedal.[ReferenceCode] = 'BRONZE' THEN 2
			ELSE 4
	END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetMedallist] TO USER
GO*/