IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetKnockoutSummary' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetKnockoutSummary
END
GO

/*************************************************************************
* Name				: SP_S_GetKnockoutSummary
* Author			: Ramani
* Create date		: 10-Oct-2015
* Description		: Return KnockOut Summary
*************************************************************************/
CREATE PROCEDURE SP_S_GetKnockoutSummary
(
	@n_EventID				int
)
AS
BEGIN
	SELECT 
		T_Schedule.ScheduleID
		,T_Schedule.EventID
		,T_Schedule.ScheduleName
		,T_Schedule.ScheduleDateTime
		,T_Schedule.RoundName
		,T_Schedule.TotalParticipant
		,T_Schedule.CompetitionStage
		,T_Schedule.MatchNumber
		,T_Schedule.IsMedalGame
		,UPPER(T_Participant.FullName) AS FullName
		,T_Score.ScoreFinal
		,T_Score.MedalID
		,TRM.ReferenceName AS MedalType
		,CASE T_Score.MedalID 
					WHEN 1 THEN '~/img/medal/gold_img.png'
					WHEN 2 THEN '~/img/medal/silver_img.png'
					WHEN 3 THEN '~/img/medal/bronze_img.png'
				ELSE NULL
				END AS [MedalIconFilePath]
		,T_Country.CountryName
		,T_Country.IconFilePath AS IconFilePath
		,T_ParticipantInSchedule.SortID
	FROM 
		T_Schedule WITH (NOLOCK)
		LEFT JOIN T_ParticipantInSchedule WITH (NOLOCK) ON T_Schedule.ScheduleID = T_ParticipantInSchedule.ScheduleID
		LEFT JOIN T_ScoreInParticipantInSchedule WITH (NOLOCK) ON T_ParticipantInSchedule.ParticipantInScheduleID = T_ScoreInParticipantInSchedule.ParticipantInScheduleID
		LEFT JOIN T_Participant WITH (NOLOCK) ON T_ParticipantInSchedule.ParticipantID = T_Participant.ParticipantID
		LEFT JOIN T_Country WITH (NOLOCK) ON T_Country.CountryID = T_Participant.CountryID
		LEFT JOIN T_Score WITH (NOLOCK) ON T_ScoreInParticipantInSchedule.ScoreID = T_Score.ScoreID
		LEFT JOIN T_Reference AS TRM WITH (NOLOCK) ON T_Score.MedalID = TRM.ReferenceInternalID AND TRM.ReferenceCategoryID = 6
	WHERE 
		T_Schedule.EventID = @n_EventID
		AND T_ParticipantInSchedule.IsActive = 1
		AND T_Schedule.IsActive = 1 
		AND T_Schedule.PlayFormatID = 1 
	ORDER BY 
		T_Schedule.CompetitionStage
		,T_Schedule.MatchNumber
		,T_ParticipantInSchedule.SortID ASC
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetKnockoutSummary] TO USER
GO*/

