IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetModuleInRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetModuleInRole
END
GO

/*************************************************************************
* Name				: SP_S_GetModuleInRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return module
*************************************************************************/
CREATE PROCEDURE [SP_S_GetModuleInRole]
(
	@n_RoleID			int
)
AS
BEGIN

	SELECT	*
	FROM	T_ModuleInRole
	WHERE	(RoleID = @n_RoleID or @n_RoleID is null)
			and IsActive = 1
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetModuleInRole] TO USER
GO*/