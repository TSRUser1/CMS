IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateTeam
END
GO

/*************************************************************************
* Name				: SP_U_UpdateTeam
* Author			: Edwind Tay Chee Hou
* Create date		: 29-Oct-2015
* Description		: Update Team
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateTeam]
(
	@n_TeamID				int,
	@s_TeamName				nvarchar(200),
	@n_EventID				int,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE T_Team
	   SET TeamName = @s_TeamName
		  ,EventID = @n_EventID
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
	 WHERE TeamID = @n_TeamID

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateTeam] TO USER
GO*/