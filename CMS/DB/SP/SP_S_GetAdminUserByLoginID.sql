IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAdminUserByLoginID' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAdminUserByLoginID
END
GO

/*************************************************************************
* Name				: SP_S_GetAdminUserByLoginID
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return module
*************************************************************************/
CREATE PROCEDURE [SP_S_GetAdminUserByLoginID]
(
	@s_LoginID			nvarchar(100)
)
AS
BEGIN

	SELECT *
	FROM T_AdminUser
	WHERE LoginID = @s_LoginID

	SELECT ModuleName,
		PageName,
		FunctionName 
	FROM T_ModuleInRole AS MR
	INNER JOIN T_AdminUserInRole AS AR
	ON AR.RoleID = MR.RoleID
	AND MR.IsActive = 1
	AND AR.IsActive = 1
	INNER JOIN T_Module AS M
	ON M.ModuleID = MR.ModuleID
	INNER JOIN T_AdminUser AS A
	ON A.AdminUserID = AR.AdminUserID
	WHERE A.LoginID = @s_LoginID	
	AND MR.IsReadWrite = 'true'
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAdminUserByLoginID] TO USER
GO*/