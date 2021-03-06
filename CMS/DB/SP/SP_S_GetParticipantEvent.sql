IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantEvent
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantEvent
* Author			: Edwind
* Create date		: 10-Oct-2015
* Description		: Return participant event and results by participantid, eventid
*************************************************************************/
CREATE PROCEDURE SP_S_GetParticipantEvent
(
	@n_ParticipantID			int,
	@n_EventID					int
)
AS
BEGIN
	SELECT 
		PT.ParticipantID,
		SP.SportName,
		EV.EventID,
		EV.EventName,
		tableResult.ScheduleID,
		PTIE.SportClassID,
		TSC.SportClassCode,
		tableResult.ResultPosition,
		tableResult.BreakRecord,
		tableResult.ReferenceName AS [Medal],
		CASE tableResult.ReferenceCode 
			WHEN 'GOLD' THEN '~/img/medal/gold.png'
			WHEN 'SILVER' THEN '~/img/medal/silver.png'
			WHEN 'BRONZE' THEN '~/img/medal/bronze.png'
		ELSE NULL
		END AS [MedalImageFilePath],
		TC.CountryID,
		TC.CountryName,
		TC.IconFilePath AS [FlagImageFilePath]
	FROM T_Participant PT WITH (NOLOCK)
	INNER JOIN T_Country TC WITH (NOLOCK)
	ON PT.CountryID = TC.CountryID
		AND TC.IsActive = 1
	INNER JOIN T_ParticipantInEvent PTIE WITH (NOLOCK)
	ON PT.ParticipantID = PTIE.ParticipantID
		AND PTIE.IsActive = 1
	LEFT JOIN T_SportClass TSC WITH (NOLOCK)
	ON PTIE.SportClassID = TSC.SportClassID
		AND TSC.IsActive = 1
	INNER JOIN T_Event EV WITH (NOLOCK)
	ON PTIE.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport  SP WITH (NOLOCK)
	ON EV.SportID = SP.SportID
		AND SP.IsActive = 1
	LEFT JOIN 
	(
		SELECT DISTINCT 
			SC.EventID,
			SC.ScheduleID,
			PTIS.ParticipantID,
			TS.ResultPosition,
			TS.BreakRecord,
			TMedal.ReferenceName,
			TMedal.ReferenceCode
		FROM T_ParticipantInSchedule  PTIS WITH (NOLOCK)
		INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
		ON ( SIPIS.ParticipantInScheduleID = PTIS.ParticipantInScheduleID
				OR PTIS.TeamID = SIPIS.TeamID )
		INNER JOIN T_Score TS WITH (NOLOCK)
		ON SIPIS.ScoreID = TS.ScoreID
			AND TS.IsActive = 1
		LEFT JOIN T_Reference TMedal WITH (NOLOCK)
		ON TS.MedalID = TMedal.ReferenceInternalID
			AND TMedal.ReferenceCategoryID = 6
			AND TMedal.IsActive = 1
		INNER JOIN T_Schedule  SC WITH (NOLOCK)
		ON PTIS.ScheduleID = SC.ScheduleID
			AND SC.IsActive = 1
			AND SC.IsMedalGame = 1
		WHERE PTIS.IsActive = 1
	) tableResult
	ON EV.EventID = tableResult.EventID
		AND PT.ParticipantID = tableResult.ParticipantID
	WHERE PT.IsActive = 1
	AND (PT.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
	AND (EV.EventID = @n_EventID OR @n_EventID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantEvent] TO USER
GO*/



