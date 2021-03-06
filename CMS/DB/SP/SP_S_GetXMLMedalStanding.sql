IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetXMLMedalStanding' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetXMLMedalStanding
END
GO

/*************************************************************************
* Name				: SP_S_GetXMLMedalStanding
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: Return schedule header (by date/sport)
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetXMLMedalStanding]
AS
BEGIN
	SELECT 
		RANK() OVER (ORDER BY TMedalRankings.GoldMedal DESC, TMedalRankings.SilverMedal DESC, TMedalRankings.BronzeMedal DESC) AS [Rank],
		TC.CountryID,
		TC.ISOCode3 AS CountryName,
		TC.SmallIconFilePath,
		TC.IconFilePath,
		ISNULL(TMedalRankings.GoldMedal, 0) AS GoldMedal,
		ISNULL(TMedalRankings.SilverMedal, 0) AS SilverMedal,
		ISNULL(TMedalRankings.BronzeMedal, 0) AS BronzeMedal,
		ISNULL(TMedalRankings.GoldMedal + TMedalRankings.SilverMedal + TMedalRankings.BronzeMedal, 0) AS [Total]
	FROM T_Country TC WITH (NOLOCK)
	LEFT JOIN
	(
		SELECT 
			TResult.CountryID,
			COUNT(CASE TMedal.ReferenceCode WHEN 'GOLD' THEN 1 ELSE NULL END) AS GoldMedal,
			COUNT(CASE TMedal.ReferenceCode WHEN 'SILVER' THEN 1 ELSE NULL END) AS SilverMedal,
			COUNT(CASE TMedal.ReferenceCode WHEN 'BRONZE' THEN 1 ELSE NULL END) AS BronzeMedal
		FROM
		(
			SELECT DISTINCT	
					CASE WHEN EV.EventTypeID = 1 THEN PT.ParticipantID ELSE PIS.TeamID END AS ParticipantOrTeamID,
					PIS.ScheduleID,
					TC.CountryID,
					TS.MedalID
			FROM T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
			INNER JOIN T_Score AS TS WITH (NOLOCK)
			ON TS.ScoreID = SIPIS.ScoreID
			INNER JOIN T_ParticipantInSchedule AS PIS WITH (NOLOCK)
			ON 
			(
				PIS.ParticipantInScheduleID = SIPIS.ParticipantInScheduleID
				OR (PIS.TeamID = SIPIS.TeamID AND PIS.ScheduleID = SIPIS.ScheduleID)
			)
			AND PIS.IsActive = 1
			INNER JOIN T_Schedule SC WITH (NOLOCK)
			ON PIS.ScheduleID = SC.ScheduleID
				AND SC.IsMedalGame = 1
				AND SC.IsActive = 1
			INNER JOIN T_Event EV WITH (NOLOCK)
			ON SC.EventID = EV.EventID
				AND EV.IsActive = 1
			INNER JOIN T_Participant PT WITH (NOLOCK)
			ON PIS.ParticipantID = PT.ParticipantID
				AND PT.IsActive = 1
			INNER JOIN T_Country TC WITH (NOLOCK)
			ON PT.CountryID = TC.CountryID
				AND TC.IsActive = 1
			WHERE TS.IsActive = 1	
			AND PIS.IsActive = 1
		) TResult
		INNER JOIN T_Reference TMedal WITH (NOLOCK)
		ON TResult.MedalID = TMedal.ReferenceInternalID
			AND TMedal.ReferenceCategoryID = 6
			AND TMedal.IsActive = 1
		GROUP BY TResult.CountryID
	) TMedalRankings
	ON TC.CountryID = TMedalRankings.CountryID
	WHERE TC.IsActive = 1
	ORDER BY [Rank] ASC, TC.CountryName ASC
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetXMLMedalStanding] TO USER
GO*/