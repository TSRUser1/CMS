IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateAdminLoginSessionGUID' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateAdminLoginSessionGUID
END
GO

/*************************************************************************
* Name				: SP_U_UpdateAdminLoginSessionGUID
* Author			: DEV001
* Create date		: 23-Sep-2015
* Description		: update admin login session guid
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateAdminLoginSessionGUID]
(
	@n_AdminUserID int,
	@s_LoginSessionGUID nvarchar(50),
	@n_ModifiedBy int,
	@d_ModifiedDateTime datetime
)
AS
BEGIN

	UPDATE T_AdminUser
	SET LoginSessionGUID = @s_LoginSessionGUID,
		ModifiedBy = @n_ModifiedBy,
		ModifiedDateTime = @d_ModifiedDateTime
	WHERE	AdminUserID = @n_AdminUserID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateAdminLoginSessionGUID] TO USER
GO*/