IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertAdminUserDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertAdminUserDetail
END
GO

/*************************************************************************
* Name				: SP_I_InsertAdminUserDetail
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Insert admin user detail
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertAdminUserDetail]
(
	@s_Password			nvarchar(MAX),
	@s_LoginID			nvarchar(100),
	@s_FullName			nvarchar(200),
	@s_Designation		nvarchar(200),
	@n_CreatedBy		int,
	@d_CreatedDateTime	datetime
)
AS
BEGIN
INSERT INTO dbo.T_AdminUser
           ([Password]
			,[LoginID]
			,[FullName]
			,[Designation]
			,[IsActive]
			,[CreatedBy]
			,[CreatedDateTime]
			,[ModifiedBy]
			,[ModifiedDateTime])
     VALUES
           (@s_Password
           ,@s_LoginID
           ,@s_FullName
           ,@s_Designation
           ,1
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime)

SELECT SCOPE_IDENTITY() AS AdminUserID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertAdminUserDetail] TO USER
GO*/