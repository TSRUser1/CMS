IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateAdminUserInRole' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateAdminUserInRole
END
GO

/*************************************************************************
* Name				: SP_U_UpdateAdminUserInRole
* Author			: DEV001
* Create date		: 22-Aug-2015
* Description		: Update admin in role
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateAdminUserInRole]
(
	@n_AdminUserID			INT,
	@n_RoleID				INT,
	@n_IsActive				INT,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	IF EXISTS(	SELECT * 
				FROM T_AdminUserInRole 
				WHERE RoleID = @n_RoleID 
				AND AdminUserID = @n_AdminUserID)
	BEGIN
		UPDATE T_AdminUserInRole
		SET IsActive = @n_IsActive
		WHERE RoleID = @n_RoleID 
		AND AdminUserID = @n_AdminUserID
	END
	ELSE
	BEGIN
		INSERT INTO dbo.T_AdminUserInRole
					(AdminUserID
					,RoleID
					,IsActive
					,CreatedDateTime
					,CreatedBy
					,ModifiedDateTime
					,ModifiedBy)
		VALUES
					(@n_AdminUserID
					,@n_RoleID
					,@n_IsActive
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
GRANT EXEC ON [dbo].[SP_U_UpdateAdminUserInRole] TO USER
GO*/