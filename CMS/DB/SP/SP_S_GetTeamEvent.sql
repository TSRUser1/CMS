IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetTeamEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetTeamEvent
END
GO

/*************************************************************************
* Name				: SP_S_GetTeamEvent
* Author			: Jonathan.Goh
* Create date		: 28-Oct-2015
* Description		: Return team event
*************************************************************************/
CREATE PROCEDURE SP_S_GetTeamEvent
(
	@n_TeamID					int
)
AS
BEGIN
	SELECT DISTINCT
		EV.EventID,
		EV.EventName,
		SP.SportName,
		ISNUll(tableResult.ResultPosition, 0 ) AS ResultPosition,
		tableResult.BreakRecord,
		tableResult.ReferenceName AS [Medal],
		CASE tableResult.ReferenceCode 
			WHEN 'GOLD' THEN '~/img/medal/gold.png'
			WHEN 'SILVER' THEN '~/img/medal/silver.png'
			WHEN 'BRONZE' THEN '~/img/medal/bronze.png'
		ELSE NULL
		END AS [MedalImageFilePath],
		tableResult.CountryID,
		tableResult.CountryName
	FROM T_Team PT WITH (NOLOCK)
	INNER JOIN T_Event EV WITH (NOLOCK)
	ON PT.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport  SP WITH (NOLOCK)
	ON EV.SportID = SP.SportID
		AND SP.IsActive = 1
	LEFT JOIN 
	(
		SELECT DISTINCT 
			T.TeamID,
			TS.ScoreID,
			T.EventID,
			TS.ResultPosition,
			TS.BreakRecord,
			TMedal.ReferenceName,
			TMedal.ReferenceCode,
			SIPIS.ScheduleID,
			(SELECT CountryID FROM T_Country WHERE CountryID = P.CountryID) AS CountryID,
			(SELECT CountryName FROM T_Country WHERE CountryID = P.CountryID) AS CountryName
		FROM T_Team T WITH (NOLOCK)
		INNER JOIN T_ScoreInParticipantInSchedule SIPIS WITH (NOLOCK)
		ON T.TeamID = SIPIS.TeamID
		INNER JOIN T_ParticipantInSchedule PIS WITH (NOLOCK)
		ON SIPIS.ScheduleID = PIS.ScheduleID
		AND PIS.TeamID =  SIPIS.TeamID
		INNER JOIN T_Participant P WITH (NOLOCK)
		ON P.ParticipantID = PIS.ParticipantID
		INNER JOIN T_Score TS WITH (NOLOCK)
		ON SIPIS.ScoreID = TS.ScoreID
			AND TS.IsActive = 1
		LEFT JOIN T_Reference TMedal WITH (NOLOCK)
		ON TS.MedalID = TMedal.ReferenceInternalID
			AND TMedal.ReferenceCategoryID = 6
			AND TMedal.IsActive = 1
		WHERE T.IsActive = 1
		AND (T.TeamID = @n_TeamID OR @n_TeamID IS NULL)
	) tableResult
	ON EV.EventID = tableResult.EventID
		AND PT.TeamID = tableResult.TeamID
	WHERE PT.IsActive = 1
	AND (PT.TeamID = @n_TeamID OR @n_TeamID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetTeamEvent] TO USER
GO*/


