IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetPageName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetPageName
END
GO

/*************************************************************************
* Name				: SP_S_GetPageName
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return module
*************************************************************************/
CREATE PROCEDURE [SP_S_GetPageName]
AS
BEGIN

	SELECT	Distinct PageName
	FROM	T_Module
	WHERE	IsActive = 1	
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetPageName] TO USER
GO*/