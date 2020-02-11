IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertModuleInRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertModuleInRole
END
GO

/*************************************************************************
* Name				: SP_I_InsertModuleInRole
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Insert module
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertModuleInRole]
(
	@n_ModuleID			int,
	@n_RoleID			int,
	@b_IsReadWrite		bit,
	@b_IsReadOnly		bit,
	@n_CreatedBy		int,
	@d_CreatedDateTime	datetime
)
AS
BEGIN
INSERT INTO [dbo].[T_ModuleInRole]
           ([ModuleID]
           ,[RoleID]
           ,[IsReadWrite]
           ,[IsReadOnly]
           ,[IsActive]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[ModifiedDateTime]
           ,[ModifiedBy])
     VALUES
           (@n_ModuleID
           ,@n_RoleID
           ,@b_IsReadWrite
           ,@b_IsReadOnly
           ,1
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
GRANT EXEC ON [dbo].[SP_I_InsertModuleInRole] TO USER
GO*/