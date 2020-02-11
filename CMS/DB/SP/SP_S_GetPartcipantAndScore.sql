IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetPartcipantAndScore' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetPartcipantAndScore
END
GO

/*************************************************************************
* Name				: SP_S_GetPartcipantAndScore
* Author			: Ramani Ganason
* Create date		: 27-Aug-2015
* Description		: Return Single Participant And Score for Schedule
*************************************************************************/
CREATE PROCEDURE [SP_S_GetPartcipantAndScore]
(
	@n_ScheduleID			int,
	@n_ParticipantID		int
)
AS
BEGIN
		SELECT	PIC.ParticipantInScheduleID
			  ,PIC.ScheduleID
			  ,PIC.TeamID
			  ,PIC.ParticipantID
			  ,PIC.ParticipantPosition
			  ,PIC.ParticipantTypeID
			  ,PIC.StartList1
			  ,PIC.StartList2
			  ,PIC.StartList3
			  ,PIC.StartList4
			  ,PIC.StartList5
			  ,PIC.StartList6
			  ,PIC.StartList7
			  ,PIC.StartList8
			  ,PIC.StartList9
			  ,PIC.StartList10
			  ,TRPT.ReferenceName AS ParticipantType
			  ,UPPER(TP.FullName) AS FullName
			  ,TP.FamilyName
			  ,TP.AccreditationNumber
			  ,TP.DateOfBirth
			  ,TC.CountryID
			  ,TC.CountryNameShort AS CountryName
			  ,TC.IconFilePath AS CountryImage
			  ,TS.ScoreID
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
			  ,PIC.SortID
			  ,PIC.IsActive
			  ,PIC.CreatedBy
			  ,PIC.CreatedDateTime
			  ,PIC.ModifiedBy
			  ,PIC.ModifiedDateTime
		FROM	T_ParticipantInSchedule AS PIC
		LEFT JOIN T_Participant AS TP WITH (NOLOCK) ON PIC.ParticipantID = TP.ParticipantID
		LEFT JOIN T_Country AS TC WITH (NOLOCK) ON TP.CountryID = TC.CountryID
		LEFT JOIN T_ScoreInParticipantInSchedule AS SIPIC WITH (NOLOCK) ON PIC.ParticipantInScheduleID = SIPIC.ParticipantInScheduleID
		LEFT JOIN T_Score AS TS WITH (NOLOCK) ON TS.ScoreID = SIPIC.ScoreID
		LEFT JOIN  T_Reference AS TRM WITH (NOLOCK) ON TS.MedalID = TRM.ReferenceInternalID AND TRM.ReferenceCategoryID = 6
		LEFT JOIN  T_Reference AS TRPT WITH (NOLOCK) ON PIC.ParticipantTypeID = TRPT.ReferenceInternalID AND TRPT.ReferenceCategoryID = 9
		INNER JOIN T_Schedule AS TSC WITH (NOLOCK) ON PIC.ScheduleID = TSC.ScheduleID
		INNER JOIN T_Event AS TE WITH (NOLOCK) ON TSC.EventID = TE.EventID
		INNER JOIN T_Sport AS TSP WITH (NOLOCK) ON TE.SportID = TSP.SportID
		WHERE	PIC.ScheduleID = @n_ScheduleID and PIC.IsActive = 1
		AND (TP.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
		AND TSC.IsPublishStartList = 1
		ORDER BY PIC.SortID, TC.CountryNameShort, PIC.ParticipantTypeID,
		CASE WHEN 
			TSP.SportCode = 'FT' OR 
			TSP.SportCode = 'FB' OR 
			TSP.SportCode = 'GB' OR 
			TSP.SportCode = 'WB' OR 
			(TSP.SportCode = 'AT' AND TE.EventTypeID = 3 ) OR
			(TSP.SportCode = 'SW' AND TE.EventTypeID = 3 ) 
		THEN right('0000000000'+ rtrim(StartList1), 8) END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetPartcipantAndScore] TO USER
GO*/