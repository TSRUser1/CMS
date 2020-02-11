IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetBrokenRecord' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetBrokenRecord
END
GO

/*************************************************************************
* Name				: SP_S_GetBrokenRecord
* Author			: Jonathan.Goh
* Create date		: 17-Oct-2015
* Description		: Return Broken Record
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetBrokenRecord]
(
	@n_EventID AS int
)
AS
BEGIN
	SELECT UPPER(P.[FullName]) AS FullName
		  ,P.[ParticipantID]
		  ,EV.[EventID]
		  ,EV.[EventName]
		  ,TS.Location
		  ,TS.[ScheduleDateTime] AS [Date]
		  ,SC.[BreakRecord]
		  ,SC.[ScoreFinal]
	  FROM T_Score AS SC WITH (NOLOCK)
	  INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
	  ON SC.ScoreID = SIPIS.ScoreID
	  INNER JOIN T_ParticipantInSchedule AS PIS WITH (NOLOCK)
	  ON SIPIS.ParticipantInScheduleID = PIS.ParticipantInScheduleID
	  AND PIS.IsActive = 1
	  INNER JOIN T_Schedule AS TS WITH (NOLOCK)
	  ON TS.ScheduleID = PIS.ScheduleID
	  AND TS.IsActive = 1
	  INNER JOIN T_Event AS EV WITH (NOLOCK)
	  ON EV.EventID = TS.EventID
	  AND EV.IsActive = 1
	  INNER JOIN T_Participant AS P WITH (NOLOCK)
	  ON P.ParticipantID = PIS.ParticipantID
	  AND P.IsActive = 1
	  WHERE Sc.BreakRecord IS NOT NULL AND Sc.BreakRecord <> '' AND SC.BreakRecord <> 'PB'
	  AND SC.IsActive = 1
	  AND (EV.EventID = @n_EventID OR @n_EventID IS NULL)
	  GROUP BY P.[ParticipantID]
			  ,P.[FullName]
			  ,EV.[EventID]
			  ,EV.[EventName]
			  ,TS.Location
			  ,TS.[ScheduleDateTime]
			  ,SC.[BreakRecord]
			  ,SC.[ScoreFinal]
	   ORDER BY EV.[EventID]
	   	  
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetBrokenRecord] TO USER
GO*/