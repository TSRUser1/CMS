IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertAdminUserInRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertAdminUserInRole
END
GO

/*************************************************************************
* Name				: SP_I_InsertAdminUserInRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Insert admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertAdminUserInRole]
(
	@n_AdminUserID		int,
	@n_RoleID			int,
	@n_IsActive			int,
	@n_CreatedBy		int,
	@d_CreatedDateTime	datetime
)
AS
BEGIN

INSERT INTO [dbo].[T_AdminUserInRole]
           ([AdminUserID]
           ,[RoleID]
           ,[IsActive]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[ModifiedDateTime]
           ,[ModifiedBy])
     VALUES
           (@n_AdminUserID
           ,@n_RoleID
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertAdminUserInRole] TO USER
GO*/