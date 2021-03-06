IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetTeamAndScore' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetTeamAndScore
END
GO

/*************************************************************************
* Name				: SP_S_GetTeamAndScore
* Author			: Ramani Ganason
* Create date		: 27-Aug-2015
* Description		: Return Team And Score for Schedule
*************************************************************************/
CREATE PROCEDURE [SP_S_GetTeamAndScore]
(
	@n_ScheduleID			int
)
AS
BEGIN
		SELECT DISTINCT 
		TS.ScoreID
		,TPIS.ScheduleID
		,TPIS.TeamID
		,TT.TeamName
		,TC.CountryID
		,TC.CountryNameShort AS CountryName
		,TC.IconFilePath AS CountryImage
		,TS.Score1
		,TS.Score2
		,TS.Score3
		,TS.Score4
		,TS.Score5
		,TS.Score6
		,TS.Score7
		,TS.Score8
		,TS.Score9
		,TS.Score10
		,TS.Score11
		,TS.Score12
		,TS.Score13
		,TS.Score14
		,TS.Score15
		,TS.Score16
		,TS.Score17
		,TS.Score18
		,TS.Score19
		,TS.Score20
		,TS.ScoreFinal
		,TS.BreakRecord
		,TS.Remarks
		,TS.MedalID
		,TRM.ReferenceName AS MedalType
		,CASE TS.MedalID 
					WHEN 1 THEN '~/img/medal/gold.png'
					WHEN 2 THEN '~/img/medal/silver.png'
					WHEN 3 THEN '~/img/medal/bronze.png'
				ELSE NULL
				END AS [MedalIconFilePath]
		,CASE WHEN TS.ResultPosition = 0 THEN NULL ELSE TS.ResultPosition END AS ResultPosition
		,CASE WHEN TS.ResultPosition > 0 THEN 0 ELSE 1 END AS Ordering
		,TPIS.SortID
		FROM T_ParticipantInSchedule AS TPIS WITH (NOLOCK)
		LEFT JOIN T_ScoreInParticipantInSchedule AS SIPIC WITH (NOLOCK) ON TPIS.TeamID = SIPIC.TeamID AND TPIS.ScheduleID = SIPIC.ScheduleID
		LEFT JOIN T_Schedule AS S WITH (NOLOCK) ON S.ScheduleID = TPIS.ScheduleID
		LEFT JOIN T_Score AS TS WITH (NOLOCK) ON SIPIC.ScoreID = TS.ScoreID AND TS.IsActive = 1
		LEFT JOIN  T_Reference AS TRM WITH (NOLOCK) ON TS.MedalID = TRM.ReferenceInternalID AND TRM.ReferenceCategoryID = 6
		LEFT JOIN T_Participant AS TP WITH (NOLOCK) ON TPIS.ParticipantID = TP.ParticipantID
		--LEFT JOIN T_ParticipantInEvent AS TPIE ON TPIE.ParticipantID = TP.ParticipantID AND TPIE.EventID = S.EventID AND TPIE.IsActive = 1
		LEFT JOIN T_Team AS TT WITH (NOLOCK) ON TT.TeamID = TPIS.TeamID
		LEFT JOIN T_Country AS TC WITH (NOLOCK) ON TP.CountryID = TC.CountryID
		WHERE TPIS.ScheduleID = @n_ScheduleID AND TPIS.IsActive = 1
		ORDER BY TPIS.SortID ASC
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetTeamAndScore] TO USER
GO*/