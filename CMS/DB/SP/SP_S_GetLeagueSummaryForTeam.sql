IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetLeagueSummaryForTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetLeagueSummaryForTeam
END
GO

/*************************************************************************
* Name				: SP_S_GetLeagueSummaryForTeam
* Author			: Ramani
* Create date		: 15-Oct-2015
* Description		: Return League Summary for Team
*************************************************************************/
CREATE PROCEDURE SP_S_GetLeagueSummaryForTeam
(
	@n_EventID				int
)
AS
BEGIN
	SELECT DISTINCT
		S.ScheduleID
		,S.EventID
		,E.EventName
		,S.ScheduleName
		,S.ScheduleDateTime
		,S.GroupCode
		,S.IsMedalGame
		,S.CompetitionStage
		,S.IsGenerateLeagueSummary
		,TT.TeamName
		,ISNULL(SIPIS.TeamID, PIS.TeamID) AS TeamID
		,SC.ScoreFinal
		,SC.MedalID
		,TRM.ReferenceName AS MedalType
		,C.CountryName
		,C.IconFilePath AS IconFilePath
	FROM 
		T_Event AS E WITH (NOLOCK)
		LEFT JOIN T_Schedule AS S WITH (NOLOCK) ON E.EventID = S.EventID
		LEFT JOIN T_ParticipantInSchedule AS PIS WITH (NOLOCK) ON S.ScheduleID = PIS.ScheduleID
		LEFT JOIN T_Participant AS P WITH (NOLOCK) ON PIS.ParticipantID = P.ParticipantID
		--LEFT JOIN T_ParticipantInEvent AS PIE ON PIE.ParticipantID = P.ParticipantID
		LEFT JOIN T_Country AS C WITH (NOLOCK) ON C.CountryID = P.CountryID
		LEFT JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK) ON SIPIS.ScheduleID = S.ScheduleID AND SIPIS.TeamID = PIS.TeamID
		LEFT JOIN T_Score AS SC WITH (NOLOCK) ON SIPIS.ScoreID = SC.ScoreID
		LEFT JOIN T_Team AS TT WITH (NOLOCK) ON TT.TeamID = PIS.TeamID
		LEFT JOIN T_Reference AS TRM WITH (NOLOCK) ON SC.MedalID = TRM.ReferenceInternalID AND TRM.ReferenceCategoryID = 6
	WHERE 
		E.EventID = @n_EventID
		AND S.EventID = @n_EventID
		AND PIS.IsActive = 1
		AND S.IsActive = 1 
		AND S.PlayFormatID = 2
		AND TT.IsActive = 1
	ORDER BY 
		S.GroupCode,
		TT.TeamName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetLeagueSummaryForTeam] TO USER
GO*/
