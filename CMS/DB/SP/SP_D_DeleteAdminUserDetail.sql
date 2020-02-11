IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteAdminUserDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteAdminUserDetail
END
GO

/*************************************************************************
* Name				: SP_D_DeleteAdminUserDetail
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Update admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteAdminUserDetail]
(
	@n_AdminUserID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_AdminUser
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE AdminUserID = @n_AdminUserID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteAdminUserDetail] TO USER
GO*/