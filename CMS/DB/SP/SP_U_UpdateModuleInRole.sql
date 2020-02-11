IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateModuleInRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateModuleInRole
END
GO

/*************************************************************************
* Name				: SP_U_UpdateModuleInRole
* Author			: DEV001
* Create date		: 22-Aug-2015
* Description		: Update module in role
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateModuleInRole]
(
	@n_ModuleID				int,
	@n_RoleID				int,
	@b_IsReadOnly			bit,
	@b_IsReadWrite			bit,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	IF EXISTS(	SELECT * 
				FROM T_ModuleInRole 
				WHERE RoleID = @n_RoleID 
				AND ModuleID = @n_ModuleID)
	BEGIN
		UPDATE T_ModuleInRole
		SET IsReadOnly = @b_IsReadOnly,
			IsReadWrite = @b_IsReadWrite,
			IsActive = 1
		WHERE RoleID = @n_RoleID 
		AND ModuleID = @n_ModuleID
	END
	ELSE
	BEGIN
		INSERT INTO dbo.T_ModuleInRole
			   (ModuleID
			   ,RoleID
			   ,IsReadWrite
			   ,IsReadOnly
			   ,IsActive
			   ,CreatedDateTime
			   ,CreatedBy
			   ,ModifiedDateTime
			   ,ModifiedBy)
		 VALUES
			   (@n_ModuleID
			   ,@n_RoleID
			   ,@b_IsReadWrite
			   ,@b_IsReadOnly
			   ,1
			   ,@d_ModifiedDateTime
			   ,@n_ModifiedBy
			   ,@d_ModifiedDateTime
			   ,@n_ModifiedBy)
	END

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateModuleInRole] TO USER
GO*/