IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAdminUserList' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAdminUserList
END
GO

/*************************************************************************
* Name				: SP_S_GetAdminUserList
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return admin user list
*************************************************************************/
CREATE PROCEDURE [SP_S_GetAdminUserList]
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
	WHERE	AU.IsActive = 1			
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAdminUserList] TO USER
GO*/