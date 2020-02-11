IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteReferenceCategory' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteReferenceCategory
END
GO

/*************************************************************************
* Name				: SP_D_DeleteReferenceCategory
* Author			: DEV001
* Create date		: 28-Jul-2015
* Description		: Delete reference category
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteReferenceCategory]
(
	@n_ReferenceCategoryID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_ReferenceCategory
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ReferenceCategoryID = @n_ReferenceCategoryID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteReferenceCategory] TO USER
GO*/