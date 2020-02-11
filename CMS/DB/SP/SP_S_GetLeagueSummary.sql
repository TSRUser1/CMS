IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetLeagueSummary' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetLeagueSummary
END
GO

/*************************************************************************
* Name				: SP_S_GetLeagueSummary
* Author			: Ramani
* Create date		: 15-Oct-2015
* Description		: Return League Summary
*************************************************************************/
CREATE PROCEDURE SP_S_GetLeagueSummary
(
	@n_EventID				int
)
AS
BEGIN
	SELECT DISTINCT
		TS.ScheduleID
		,TS.EventID
		,T_Event.EventName
		,TS.ScheduleName
		,TS.ScheduleDateTime
		,TS.GroupCode
		,TS.IsMedalGame
		,TS.CompetitionStage
		,TS.IsGenerateLeagueSummary
		,UPPER(T_Participant.FullName) AS TeamName
		,T_Participant.ParticipantID AS TeamID
		,T_Score.ScoreFinal
		,T_Score.MedalID
		,TRM.ReferenceName AS MedalType
		,T_Participant.FullName AS CountryName
		,T_Country.IconFilePath AS IconFilePath
	FROM 
		T_Event WITH (NOLOCK)
		LEFT JOIN T_Schedule AS TS WITH (NOLOCK) ON T_Event.EventID = TS.EventID
		LEFT JOIN T_ParticipantInSchedule WITH (NOLOCK) ON TS.ScheduleID = T_ParticipantInSchedule.ScheduleID
		LEFT JOIN T_Participant WITH (NOLOCK) ON T_ParticipantInSchedule.ParticipantID = T_Participant.ParticipantID
		LEFT JOIN T_Country WITH (NOLOCK) ON T_Country.CountryID = T_Participant.CountryID
		LEFT JOIN T_ScoreInParticipantInSchedule WITH (NOLOCK) ON T_ScoreInParticipantInSchedule.ParticipantInScheduleID = T_ParticipantInSchedule.ParticipantInScheduleID
		LEFT JOIN T_Score WITH (NOLOCK) ON T_ScoreInParticipantInSchedule.ScoreID = T_Score.ScoreID
		LEFT JOIN T_Reference AS TRM WITH (NOLOCK) ON T_Score.MedalID = TRM.ReferenceInternalID AND TRM.ReferenceCategoryID = 6
	WHERE 
		T_Event.EventID = @n_EventID
		AND T_ParticipantInSchedule.IsActive = 1
		AND TS.IsActive = 1 
		AND TS.PlayFormatID = 2
	ORDER BY 
		TS.GroupCode,
		TeamName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetLeagueSummary] TO USER
GO*/
