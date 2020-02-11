IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteModule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteModule
END
GO

/*************************************************************************
* Name				: SP_D_DeleteModule
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: delete module
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteModule]
(
	@n_ModuleID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Module
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ModuleID = @n_ModuleID
	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteModule] TO USER
GO*/