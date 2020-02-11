IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAdminUserInRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAdminUserInRole
END
GO

/*************************************************************************
* Name				: SP_S_GetAdminUserInRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return module
*************************************************************************/
CREATE PROCEDURE [SP_S_GetAdminUserInRole]
(
	@n_ModuleID			int,
	@s_PageName			nvarchar(200)
)
AS
BEGIN

	SELECT	*
	FROM	T_Module
	WHERE	(ModuleID = @n_ModuleID or @n_ModuleID is null)
			and (PageName = @s_PageName or @s_PageName is null or @s_PageName = '' )
			and IsActive = 1	
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAdminUserInRole] TO USER
GO*/