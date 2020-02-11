IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetSingleAdminUser' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetSingleAdminUser
END
GO

/*************************************************************************
* Name				: SP_S_GetSingleAdminUser
* Author			: Ramani Ganason
* Create date		: 26-Jul-2015
* Description		: Return admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_S_GetSingleAdminUser]
(
	@n_AdminUserID			int
)
AS
BEGIN

	SELECT	AdminUserID
		  ,LoginID
		  ,FullName
		  ,Designation
		  ,IsActive
		  ,CreatedBy
		  ,CreatedDateTime
		  ,ModifiedBy
		  ,ModifiedDateTime
	FROM	T_AdminUser AS AU
	WHERE	AU.AdminUserID = @n_AdminUserID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetSingleAdminUser] TO USER
GO*/