IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetEventDetails' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetEventDetails
END
GO

/*************************************************************************
* Name				: SP_S_GetEventDetails
* Author			: Ramani Ganason
* Create date		: 26-Jul-2015
* Description		: Return event details according to SportID and EventID
*************************************************************************/
CREATE PROCEDURE [SP_S_GetEventDetails]
(
	@n_SportID			int,
	@n_EventID			int
)
AS
BEGIN
SELECT	TE.*
	FROM	T_Event AS TE
	WHERE	(TE.SportID = @n_SportID or @n_SportID is null)
	AND (TE.EventID = @n_EventID or @n_EventID is null)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetEventDetails] TO USER
GO*/