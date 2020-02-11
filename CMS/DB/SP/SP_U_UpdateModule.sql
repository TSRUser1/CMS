IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateModule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateModule
END
GO

/*************************************************************************
* Name				: SP_U_UpdateModule
* Author			: DEV001
* Create date		: 26-Aug-2015
* Description		: Update role detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateModule]
(
	@n_ModuleID				int,
	@s_ModuleName			NVARCHAR(200),
	@s_PageName				NVARCHAR(200),
	@s_FunctionName			NVARCHAR(200),
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE [dbo].[T_Module]
	   SET	ModuleName = @s_ModuleName
			,PageName = @s_PageName
			,FunctionName = @s_FunctionName
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE ModuleID = @n_ModuleID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateModule] TO USER
GO*/