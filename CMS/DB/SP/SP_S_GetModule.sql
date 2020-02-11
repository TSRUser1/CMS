IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetModule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetModule
END
GO

/*************************************************************************
* Name				: SP_S_GetModule
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return module
*************************************************************************/
CREATE PROCEDURE [SP_S_GetModule]
(
	@n_ModuleID			int,
	@s_PageName			nvarchar(200),
	@s_FunctionName		nvarchar(200)
)
AS
BEGIN

	SELECT	*
	FROM	T_Module
	WHERE	(ModuleID = @n_ModuleID or @n_ModuleID is null)
			and (PageName = @s_PageName or @s_PageName is null or @s_PageName = '' )
			and (FunctionName = @s_FunctionName or @s_FunctionName is null or @s_FunctionName = '' )
			and IsActive = 1		
			
	SELECT *
	FROM T_AdminUserInRole
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetModule] TO USER
GO*/