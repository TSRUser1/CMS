IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetRole
END
GO

/*************************************************************************
* Name				: SP_S_GetRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return role
*************************************************************************/
CREATE PROCEDURE [SP_S_GetRole]
(
	@n_RoleID			int
)
AS
BEGIN

	SELECT	*
	FROM	T_Role
	WHERE	(RoleID = @n_RoleID or @n_RoleID is null)
			and IsActive = 1
			
	SELECT M.*, ISNULL(MIR.IsReadWrite, 'False') AS IsReadWrite
	FROM T_Module AS M
	LEFT JOIN T_ModuleInRole AS MIR
	ON M.ModuleID = MIR.ModuleID
	AND (RoleID = @n_RoleID)
	AND MIR.IsActive = 1	
	WHERE  M.IsActive = 1		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetRole] TO USER
GO*/