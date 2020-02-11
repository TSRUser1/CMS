IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetTeam
END
GO

/*************************************************************************
* Name				: SP_S_GetTeam
* Author			: Edwind Tay Chee Hou
* Create date		: 19-Oct-2015
* Description		: Return team detail
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetTeam]
(
	@n_TeamID			int,
	@n_SportID			int,
	@n_EventID			int,
	@s_TeamName			nvarchar(100)

)
AS
BEGIN

	SELECT
		TT.TeamID,
		TT.TeamName,
		SP.SportID,
		SP.SportName,
		EV.EventID,
		EV.EventName,
		TT.IsActive,
		TT.CreatedBy,
		TT.CreatedDateTime,
		TT.ModifiedBy,
		TT.ModifiedDateTime
	FROM T_Team TT
	INNER JOIN T_Event EV
	ON TT.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport SP
	ON EV.SportID = sp.SportID
		AND SP.IsActive = 1
	WHERE TT.IsActive = 1
	AND (TT.TeamID = @n_TeamID OR @n_TeamID IS NULL)
	AND (TT.TeamName LIKE '%' + @s_TeamName + '%' OR @s_TeamName IS NULL)
    AND (EV.EventID = @n_EventID OR @n_EventID IS NULL)
    AND (SP.SportID = @n_SportID OR @n_SportID IS NULL)

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetTeam] TO USER
GO*/


