IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantInEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantInEvent
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantInEvent
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return participant in event
*************************************************************************/
CREATE PROCEDURE [SP_S_GetParticipantInEvent]
(
	@n_ParticipantID			int
)
AS
BEGIN
	SELECT ParticipantInEventID,
			ParticipantID,
			TS.SportID,
			PIE.SportClassID,
			SC.SportClassCode,
			pie.TeamID,
			TT.TeamName,
			e.EventID,
			e.EventName,
			TS.SportName,
			pie.IsActive,
			pie.ModifiedBy
    FROM dbo.T_ParticipantInEvent pie
	INNER JOIN dbo.T_Event e ON pie.EventID = e.EventID
	LEFT JOIN T_Sport TS ON TS.SportID = e.SportID
	LEFT JOIN T_Team TT ON TT.TeamID = pie.TeamID AND TT.IsActive = 1
	LEFT JOIN T_SportClass SC ON SC.SportClassID = PIE.SportClassID
	WHERE pie.IsActive = 1
	AND e.Isactive = 1
	AND (pie.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantInEvent] TO USER
GO*/