IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAdminLoginSession' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAdminLoginSession
END
GO

/*************************************************************************
* Name				: SP_S_GetAdminLoginSession
* Author			: DEV001
* Create date		: 23-Sep-2015
* Description		: Return admin login session GUID
*************************************************************************/
CREATE PROCEDURE [SP_S_GetAdminLoginSession]
(
	@n_AdminUserID int
)
AS
BEGIN

	SELECT	LoginSessionGUID
	FROM	T_AdminUser
	WHERE	AdminUserID = @n_AdminUserID
			AND	IsActive = 1
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAdminLoginSession] TO USER
GO*/