IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAllZoneAccessColorCode' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAllZoneAccessColorCode
END
GO

/*************************************************************************
* Name				: SP_S_GetAllZoneAccessColorCode
* Author			: Parakop
* Create date		: 13-Sep-2015
* Description		: Return member
*************************************************************************/
CREATE PROCEDURE SP_S_GetAllZoneAccessColorCode
AS
BEGIN
	
	SELECT *
	  FROM ac_ZoneAccess
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAllZoneAccessColorCode] TO USER
GO*/
