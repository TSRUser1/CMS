IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantResult' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantResult
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantResult
* Author			: Edwind
* Create date		: 1-Sep-2015
* Description		: Return participant results by participantid, scheduleid
*************************************************************************/
CREATE PROCEDURE SP_S_GetParticipantResult
(
	@n_ParticipantID			int,
	@n_ScheduleID				int,
	@n_TeamID					int
)
AS
BEGIN
	
	SELECT 
		PT.ParticipantID,
		SC.ScheduleID,
		SC.ScheduleDateTime,
		CONVERT(NVARCHAR(12), SC.ScheduleDateTime, 107) AS ScheduleDate,
		CONVERT(NVARCHAR(5), SC.ScheduleDateTime, 108) AS ScheduleTime,
		EV.EventName,
		TS.ResultPosition,
		(SELECT GETDATE()) AS Result,
		CONVERT(NVARCHAR(8), GETDATE(), 108) AS ResultTime
	FROM T_Participant PT WITH (NOLOCK)
	INNER JOIN T_Country TC WITH (NOLOCK)
	ON PT.CountryID = TC.CountryID
		AND TC.IsActive = 1
	INNER JOIN T_ParticipantInSchedule  PTIS WITH (NOLOCK)
	ON PT.ParticipantID = PTIS.ParticipantID
		AND PTIS.IsActive = 1
	INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
	ON SIPIS.ParticipantInScheduleID = PTIS.ParticipantInScheduleID
	LEFT JOIN T_Score TS WITH (NOLOCK)
	ON SIPIS.ScoreID = TS.ScoreID
		AND TS.IsActive = 1
	INNER JOIN T_Schedule  SC WITH (NOLOCK)
	ON PTIS.ScheduleID = SC.ScheduleID
		AND SC.IsActive = 1
	INNER JOIN T_Event EV WITH (NOLOCK)
	ON SC.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport  SP WITH (NOLOCK)
	ON EV.SportID = SP.SportID
		AND SC.IsActive = 1
	WHERE PT.IsActive = 1
	AND (PT.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
	AND (PTIS.TeamID = @n_TeamID OR @n_TeamID IS NULL)
	AND (PTIS.ScheduleID = @n_ScheduleID OR @n_ScheduleID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantDetail] TO USER
GO*/