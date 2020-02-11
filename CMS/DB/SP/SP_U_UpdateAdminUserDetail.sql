IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateAdminUserDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateAdminUserDetail
END
GO

/*************************************************************************
* Name				: SP_U_UpdateAdminUserDetail
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Update admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateAdminUserDetail]
(
	@n_AdminUserID			int,
	@s_Password				nvarchar(MAX),
	@s_Fullname				nvarchar(200),
	@s_Designation			nvarchar(200),
	@n_ModifiedBy			INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_AdminUser
	Set Password = ISNULL( @s_Password, Password ),
		Designation = ISNULL( @s_Designation, Designation ),
		Fullname = ISNULL( @s_Fullname, FullName ),
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
GRANT EXEC ON [dbo].[SP_U_UpdateAdminUserDetail] TO USER
GO*/