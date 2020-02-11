IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertRole
END
GO

/*************************************************************************
* Name				: SP_I_InsertRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Insert admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertRole]
(
	@s_RoleName			nvarchar(200),
	@s_RoleDescription	nvarchar(MAX),
	@n_CreatedBy		int,
	@d_CreatedDateTime	datetime
)
AS
BEGIN
INSERT INTO dbo.T_Role
           (RoleName
           ,RoleDescription
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_RoleName
           ,@s_RoleDescription
           ,1
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

SELECT SCOPE_IDENTITY() AS RoleID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertRole] TO USER
GO*/