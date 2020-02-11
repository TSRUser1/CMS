IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteRole
END
GO

/*************************************************************************
* Name				: SP_D_DeleteRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Delete role
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteRole]
(
	@n_RoleID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Role
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE RoleID = @n_RoleID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteRole] TO USER
GO*/