IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetXMLSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetXMLSchedule
END
GO

/*************************************************************************
* Name				: SP_S_GetXMLSchedule
* Author			: Edwind
* Create date		: 29-Aug-2015
* Description		: Return schedule header (by date/sport)
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetXMLSchedule]
(
	@d_ScheduleDateTime		datetime
)
AS
BEGIN

	DECLARE @l_d_ScheduleDateTime DATETIME
	SET @l_d_ScheduleDateTime = @d_ScheduleDateTime

	SELECT  
		SC.ScheduleID,
		SC.IsMedalGame,
		SP.SportID,
		SP.SportCode,
		SP.SportName,
		SP.ImageFilePath as SportImageFilePath,
		CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS ScheduleDate,
		SC.ScheduleDateTime,
		SC.Venue,
		SC.Location,
		EV.EventID,
		EV.EventName,
		EV.GenderID,
		GenderTable.ReferenceName AS [Gender],
		GenderTable.ReferenceCode AS [GenderName],
		SC.ScheduleName,
		SC.RoundName,
		SC.HeadToHead,
		CASE WHEN EV.EventTypeID = 1 THEN 1 ELSE 0 END AS IsIndividualGame,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN CASE WHEN h2hCTE.ScoreFinal1 > h2hCTE.ScoreFinal2 THEN 'true' ELSE 'false' END ELSE CASE WHEN LEN(nonH2hResultTable.ScoreFinal)>0 THEN 'true' ELSE 'false' END END) ELSE 'false' END AS Winner1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.CountryID1 ELSE nonH2hResultTable.CountryID END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.CountryID1 ELSE NULL END) END AS CountryID1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.CountryCode1 ELSE nonH2hResultTable.ISOCode3 END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.CountryCode1 ELSE NULL END) END AS CountryName1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.FlagImageFilePath1 ELSE nonH2hResultTable.SmallIconFilePath END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.FlagImageFilePath1 ELSE NULL END) END AS FlagImageFilePath1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.TeamID1 ELSE nonH2hResultTable.TeamID END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.TeamID1 ELSE NULL END) END AS TeamID1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.TeamName1 ELSE nonH2hResultTable.TeamName END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.TeamName1 ELSE NULL END) END AS TeamName1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.ParticipantID1 ELSE nonH2hResultTable.ParticipantID END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.ParticipantID1 ELSE NULL END) END AS ParticipantID1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN UPPER(h2hCTE.FullName1) ELSE UPPER(nonH2hResultTable.FullName) END) ELSE (CASE WHEN SC.HeadToHead = 1 THEN UPPER(h2hCTE.FullName1) ELSE NULL END) END AS FullName1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.ScoreFinal1 ELSE nonH2hResultTable.ScoreFinal END) ELSE NULL END AS ScoreFinal1,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN CASE WHEN h2hCTE.ScoreFinal1 < h2hCTE.ScoreFinal2 THEN 'true' ELSE 'false' END ELSE NULL END) ELSE 'false' END AS Winner2,
		CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.CountryID2 ELSE NULL END AS CountryID2,
		CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.CountryCode2 ELSE NULL END AS CountryName2,
		CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.FlagImageFilePath2 ELSE NULL END AS FlagImageFilePath2,
		CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.TeamID2 ELSE NULL END AS TeamID2,
		CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.TeamName2 ELSE NULL END AS TeamName2,
		CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.ParticipantID2 ELSE NULL END AS ParticipantID2,
		CASE WHEN SC.HeadToHead = 1 THEN UPPER(h2hCTE.FullName2) ELSE NULL END AS FullName2,
		CASE WHEN SC.IsOfficial = 1 THEN (CASE WHEN SC.HeadToHead = 1 THEN h2hCTE.ScoreFinal2 ELSE NULL END) ELSE NULL END AS ScoreFinal2,
		CASE WHEN SC.IsOfficial = 1 THEN nonH2hResultTable.BreakRecord ELSE NULL END AS BreakRecord,
		SC.StatusCodeID,
		TRS.ReferenceName AS [ScheduleStatus]
	FROM T_Schedule SC WITH (NOLOCK)
	INNER JOIN T_Event EV WITH (NOLOCK)
	ON SC.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Reference GenderTable WITH (NOLOCK)
	ON EV.GenderID = GenderTable.ReferenceInternalID
		AND GenderTable.ReferenceCategoryID = 2
		AND GenderTable.IsActive = 1
	INNER JOIN T_Sport SP WITH (NOLOCK)
	ON SP.SportID = EV.SportID
		AND SP.IsActive = 1
	LEFT JOIN 
	(
		--get distinct schedule 
		--filtered by country if n_CountryID is not null
		SELECT DISTINCT 
			PIS.ScheduleID
		FROM T_ParticipantInSchedule PIS WITH (NOLOCK)
		INNER JOIN T_Participant PT WITH (NOLOCK)
		ON PT.ParticipantID = PIS.ParticipantID
			AND PT.IsActive = 1
		INNER JOIN T_Country TC WITH (NOLOCK)
		ON TC.CountryID = PT.CountryID
			AND TC.IsActive = 1
		INNER JOIN T_Schedule SC WITH (NOLOCK)
		ON PIS.ScheduleID = SC.ScheduleID
			AND SC.IsActive = 1
		WHERE PIS.IsActive = 1
		AND ((SC.ScheduleDateTime BETWEEN @l_d_ScheduleDateTime AND DATEADD (day , 1 , @l_d_ScheduleDateTime )) OR @l_d_ScheduleDateTime IS NULL)
		--AND (TC.CountryID = @n_CountryID OR @n_CountryID IS NULL)
		--AND (PT.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
		--AND (PTIE.TeamID = @n_TeamID OR @n_TeamID IS NULL)
	)  TSC
	ON SC.ScheduleID = TSC.ScheduleID
	LEFT JOIN T_Reference TRS WITH (NOLOCK)
	ON SC.StatusCodeID = TRS.ReferenceInternalID
		AND TRS.ReferenceCategoryID = 5
		AND TRS.IsActive = 1
	LEFT JOIN vw_TeamVersus h2hCTE WITH (NOLOCK)
	ON SC.ScheduleID = h2hCTE.ScheduleID
	LEFT JOIN vw_TeamInSchedule nonH2hResultTable WITH (NOLOCK)
	ON SC.ScheduleID = nonH2hResultTable.ScheduleID
		AND nonH2hResultTable.ScoreFinal IS NOT NULL
		AND nonH2hResultTable.ResultPosition = 1
		AND nonH2hResultTable.NoOfWinners < 2
	WHERE SC.IsActive = 1
	AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
	--AND (SP.SportID = @n_SportID OR @n_SportID IS NULL)
	AND ((SC.ScheduleDateTime BETWEEN @l_d_ScheduleDateTime AND DATEADD (day , 1 , @l_d_ScheduleDateTime )) OR @l_d_ScheduleDateTime IS NULL)
	--AND ((@n_CountryID IS NOT NULL AND TSC.ScheduleID IS NOT NULL) OR @n_CountryID IS NULL)
	--AND ((@n_ParticipantID IS NOT NULL AND TSC.ScheduleID IS NOT NULL) OR @n_ParticipantID IS NULL)
	--AND ((@n_TeamID IS NOT NULL AND TSC.ScheduleID IS NOT NULL) OR @n_TeamID IS NULL)
	--AND (@b_IsEndState IS NULL OR (@b_IsEndState = 1 AND (TRS.ReferenceCode = 'CN' OR TRS.ReferenceCode = 'CP')) OR (@b_IsEndState = 0 AND TRS.ReferenceCode <> 'CN' AND TRS.ReferenceCode <> 'CP'))
	ORDER BY ScheduleDate, SP.SportName, EV.EventName, SC.ScheduleName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetXMLSchedule] TO USER
GO*/