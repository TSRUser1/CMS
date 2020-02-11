IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetReferenceCategory' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetReferenceCategory
END
GO

/*************************************************************************
* Name				: SP_S_GetReferenceCategory
* Author			: DEV001
* Create date		: 28-Jul-2015
* Description		: Return reference
*************************************************************************/
CREATE PROCEDURE [SP_S_GetReferenceCategory]
AS
BEGIN

	SELECT	*
	FROM	T_ReferenceCategory
	WHERE	IsActive = 1
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetReferenceCategory] TO USER
GO*/