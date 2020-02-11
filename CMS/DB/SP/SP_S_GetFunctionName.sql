IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetFunctionName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetFunctionName
END
GO

/*************************************************************************
* Name				: SP_S_GetFunctionName
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return module
*************************************************************************/
CREATE PROCEDURE [SP_S_GetFunctionName]
AS
BEGIN

	SELECT	Distinct FunctionName
	FROM	T_Module
	WHERE	IsActive = 1	
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetFunctionName] TO USER
GO*/