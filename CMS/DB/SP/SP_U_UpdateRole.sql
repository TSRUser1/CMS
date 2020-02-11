IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateRole
END
GO

/*************************************************************************
* Name				: SP_U_UpdateRole
* Author			: DEV001
* Create date		: 26-Aug-2015
* Description		: Update role detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateRole]
(
	@n_RoleID				int,
	@s_RoleName				NVARCHAR(200),
	@s_RoleDescription		NVARCHAR(MAX),
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE [dbo].[T_Role]
	   SET	RoleName = @s_RoleName
			, RoleDescription = @s_RoleDescription
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE RoleID = @n_RoleID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateRole] TO USER
GO*/