IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteTeam
END
GO

/*************************************************************************
* Name				: SP_D_DeleteTeam
* Author			: Edwind Tay Chee Hou
* Create date		: 19-Oct-2015
* Description		: Delete team
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteTeam]
(
	@n_TeamID				INT,
	@n_ModifiedBy			INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Team
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE TeamID = @n_TeamID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteTeam] TO USER
GO*/