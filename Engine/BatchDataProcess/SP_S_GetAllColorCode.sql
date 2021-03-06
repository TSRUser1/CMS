IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAllColorCode' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAllColorCode
END
GO

/*************************************************************************
* Name				: SP_S_GetAllColorCode
* Author			: Parakop
* Create date		: 13-Sep-2015
* Description		: Return member
*************************************************************************/
CREATE PROCEDURE SP_S_GetAllColorCode
AS
BEGIN
	
	SELECT *
	  FROM ac_ColorCode
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAllColorCode] TO USER
GO*/
