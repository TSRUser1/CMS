IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetScheduleHeaderGroupedByDateFilteredByCountry' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetScheduleHeaderGroupedByDateFilteredByCountry
END
GO

/*************************************************************************
* Name				: SP_S_GetScheduleHeaderGroupedByDateFilteredByCountry
* Author			: Edwind
* Create date		: 8-Sep-2015
* Description		: Return participant details by participantid
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetScheduleHeaderGroupedByDateFilteredByCountry]
(
	@n_CountryID			int
)
AS
BEGIN
	SELECT  
		CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS [Date],
		IIF(SUM(SC.IsMedalGame) > 0, 1 ,0) AS [IsMedalDate]
	FROM T_Schedule SC
	INNER JOIN T_ParticipantInSchedule PTIS
	ON SC.ScheduleID = PTIS.ScheduleID
		AND PTIS.IsActive = 1
	INNER JOIN T_Participant PT
	ON PTIS.ParticipantID = PT.ParticipantID
		AND PT.IsActive = 1
	INNER JOIN T_Country TC
	ON PT.CountryID = TC.CountryID
		AND TC.IsActive = 1
	WHERE SC.IsActive = 1
	AND (TC.CountryID = @n_CountryID OR @n_CountryID IS NULL)
	AND SC.ScheduleDateTime IS NOT NULL
	AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
	GROUP BY CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10))
	ORDER BY [Date]
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetScheduleHeaderGroupedByDateFilteredByCountry] TO USER
GO*/
