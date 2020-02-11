IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetSport' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetSport
END
GO

/*************************************************************************
* Name				: SP_S_GetSport
* Author			: Edwind
* Create date		: 1-Sep-2015
* Description		: Return sport
*************************************************************************/
CREATE PROCEDURE SP_S_GetSport
(
	@n_SportID				int
)
AS
BEGIN
	
	
	SELECT	
		SportID,
		ExternalSportID,
		SportName,
		SportCode,
		IsActive,
		CreatedBy,
		CreatedDateTime,
		ModifiedBy,
		ModifiedDateTime
	FROM	T_Sport TS
	WHERE	IsActive = 1
  AND (SportID = @n_SportID or @n_SportID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetSport] TO USER
GO*/
