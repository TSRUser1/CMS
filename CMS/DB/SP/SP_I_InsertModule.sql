IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertModule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertModule
END
GO

/*************************************************************************
* Name				: SP_I_InsertModule
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Insert module
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertModule]
(
	@s_ModuleName		nvarchar(200),
	@s_PageName			nvarchar(200),
	@s_FunctionName		nvarchar(200),
	@n_CreatedBy		int,
	@d_CreatedDateTime	datetime
)
AS
BEGIN
INSERT INTO [dbo].[T_Module]
           ([ModuleName]
           ,[PageName]
           ,[FunctionName]
           ,[IsActive]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[ModifiedDateTime]
           ,[ModifiedBy])
     VALUES
           (@s_ModuleName
           ,@s_PageName
           ,@s_FunctionName
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
GRANT EXEC ON [dbo].[SP_I_InsertModule] TO USER
GO*/