IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAdminUser' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAdminUser
END
GO

/*************************************************************************
* Name				: SP_S_GetAdminUser
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_S_GetAdminUser]
(
	@n_AdminUserID			int,
	@s_LoginID				nvarchar(100)
)
AS
BEGIN

	SELECT	AdminUserID
		  ,AU.Password
		  ,LoginID
		  ,FullName
		  ,Designation
		  ,IsActive
		  ,CreatedBy
		  ,CreatedDateTime
		  ,ModifiedBy
		  ,ModifiedDateTime
	FROM	T_AdminUser AS AU
	WHERE	(AU.AdminUserID = @n_AdminUserID or @n_AdminUserID is null)
			and (AU.LoginID = @s_LoginID or @s_LoginID is null )
			and AU.IsActive = 1		
			
	SELECT *,
	'true' AS HasRole
	FROM T_AdminUserInRole AS AR
	INNER JOIN T_AdminUser AS AU
	ON AR.AdminUserID = AU.AdminUserID
	WHERE	(AU.AdminUserID = @n_AdminUserID or @n_AdminUserID is null)
			and (AU.LoginID = @s_LoginID or @s_LoginID is null )
			and AU.IsActive = 1		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAdminUser] TO USER
GO*/