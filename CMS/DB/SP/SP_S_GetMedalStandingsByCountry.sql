IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetMedalStandingsByCountry' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetMedalStandingsByCountry
END
GO

/*************************************************************************
* Name				: SP_S_GetMedalStandingsByCountry
* Author			: Edwind
* Create date		: 30-Sep-2015
* Description		: Return medal standings by country
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetMedalStandingsByCountry]
(
	@n_SportID			int,
	@n_CountryID		int,
	@d_Date				datetime
)
AS
BEGIN

	DECLARE	@l_n_SportID		int,
			@l_n_CountryID		int,
			@l_d_Date			datetime

	SET @l_n_SportID = @n_SportID
	SET @l_n_CountryID = @n_CountryID
	SET @l_d_Date = @d_Date

	SELECT 
		RANK() OVER (ORDER BY TMedalRankings.GoldMedal DESC, TMedalRankings.SilverMedal DESC, TMedalRankings.BronzeMedal DESC, SP.SportName ASC) AS [Rank],
		@l_n_CountryID AS [CountryID],
		SP.SportID,
		SP.SportName,
		SP.ImageFilePath AS [SportImageFilePath],
		ISNULL(TMedalRankings.GoldMedal, 0) AS GoldMedal,
		ISNULL(TMedalRankings.SilverMedal, 0) AS SilverMedal,
		ISNULL(TMedalRankings.BronzeMedal, 0) AS BronzeMedal,
		ISNULL(TMedalRankings.GoldMedal + TMedalRankings.SilverMedal + TMedalRankings.BronzeMedal, 0) AS [Total]
	FROM T_Sport SP
	LEFT JOIN
	(
		SELECT 
			TResult.SportID,
			COUNT(CASE TMedal.ReferenceCode WHEN 'GOLD' THEN 1 ELSE NULL END) AS GoldMedal,
			COUNT(CASE TMedal.ReferenceCode WHEN 'SILVER' THEN 1 ELSE NULL END) AS SilverMedal,
			COUNT(CASE TMedal.ReferenceCode WHEN 'BRONZE' THEN 1 ELSE NULL END) AS BronzeMedal
		FROM
		(
			SELECT DISTINCT
				EV.SportID,
				CASE WHEN EV.EventTypeID = 1 THEN 1 ELSE 0 END AS [IsIndividualGame],
				CASE WHEN EV.EventTypeID = 1 THEN PT.ParticipantID ELSE PTIS.TeamID END AS ParticipantOrTeamID,
				PTIS.ScheduleID,
				TC.CountryID,
				TC.CountryName,
				MAX(TS.MedalID) AS MedalID
			FROM T_Score TS WITH (NOLOCK)
			INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
			ON SIPIS.ScoreID = TS.ScoreID
			INNER JOIN T_ParticipantInSchedule PTIS WITH (NOLOCK)
			ON 
			(
				SIPIS.ParticipantInScheduleID = PTIS.ParticipantInScheduleID
				OR (SIPIS.TeamID = PTIS.TeamID AND SIPIS.ScheduleID = PTIS.ScheduleID)
			) AND PTIS.IsActive = 1
			INNER JOIN T_Schedule SC WITH (NOLOCK)
			ON PTIS.ScheduleID = SC.ScheduleID
				AND SC.IsMedalGame = 1
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
			WHERE TS.IsActive = 1
			AND (EV.SportID = @l_n_SportID OR @l_n_SportID IS NULL)
			AND (CAST(SC.ScheduleDateTime AS DATE) = CAST(@l_d_Date AS DATE) OR @l_d_Date IS NULL)
			AND (TC.CountryID = @l_n_CountryID OR @l_n_CountryID IS NULL)
			GROUP BY EV.SportID,
				PT.ParticipantID,
				PTIS.TeamID,
				PTIS.ScheduleID,
				TC.CountryID,
				TC.CountryName,
				EV.EventTypeID 
		) TResult
		INNER JOIN T_Reference TMedal WITH (NOLOCK)
		ON TResult.MedalID = TMedal.ReferenceInternalID
			AND TMedal.ReferenceCategoryID = 6
			AND TMedal.IsActive = 1
		GROUP BY TResult.SportID
	) TMedalRankings
	ON SP.SportID = TMedalRankings.SportID
	WHERE SP.IsActive = 1
	ORDER BY SP.SportName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetMedalStandingsByCountry] TO USER
GO*/