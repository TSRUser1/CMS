IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetKnockoutSummaryForTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetKnockoutSummaryForTeam
END
GO

/*************************************************************************
* Name				: SP_S_GetKnockoutSummaryForTeam
* Author			: Ramani
* Create date		: 14-Oct-2015
* Description		: Return KnockOut Summary for Team
*************************************************************************/
CREATE PROCEDURE SP_S_GetKnockoutSummaryForTeam
(
	@n_EventID				int
)
AS
BEGIN
		SELECT DISTINCT
		T_Schedule.ScheduleID
		,T_Schedule.EventID
		,T_Schedule.ScheduleName
		,T_Schedule.ScheduleDateTime
		,T_Schedule.RoundName
		,T_Schedule.TotalParticipant
		,T_Schedule.CompetitionStage
		,T_Schedule.MatchNumber
		,T_Schedule.IsMedalGame
		,IIF(T_Schedule.HeadToHead = 1, (STUFF((SELECT CAST('/ ' + UPPER(TP.FullName) AS VARCHAR(MAX))
                        FROM 
							T_ParticipantInSchedule AS TPIS
							LEFT JOIN T_Participant AS TP ON TPIS.ParticipantID = TP.ParticipantID
							WHERE TPIS.ScheduleID = T_Schedule.ScheduleID
							AND TPIS.TeamID = T_ParticipantInSchedule.TeamID
							AND TPIS.IsActive = 1
                        FOR XML PATH ('')), 1, 2, '')), NULL) AS ParticipantList
		,T_ParticipantInSchedule.TeamID
		,T_Team.TeamName
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
		LEFT JOIN T_Team WITH (NOLOCK) ON T_Team.TeamID = T_ParticipantInSchedule.TeamID
		LEFT JOIN T_ScoreInParticipantInSchedule WITH (NOLOCK) ON T_ScoreInParticipantInSchedule.TeamID = T_ParticipantInSchedule.TeamID
		AND T_ScoreInParticipantInSchedule.ScheduleID = T_Schedule.ScheduleID
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
		,T_ParticipantInSchedule.SortID
		,T_ParticipantInSchedule.TeamID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetKnockoutSummaryForTeam] TO USER
GO*/