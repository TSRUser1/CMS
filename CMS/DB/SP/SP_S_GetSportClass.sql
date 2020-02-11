IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetSportClass' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetSportClass
END
GO

/*************************************************************************
* Name				: SP_S_GetSportClass
* Author			: Wilson
* Create date		: 17-Oct-2015
* Description		: Return sport class
*************************************************************************/
CREATE PROCEDURE SP_S_GetSportClass
(
	@n_SportClassID				int,
	@n_SportID				int
)
AS
BEGIN
	
	
	SELECT	
		SportClassID,
		SportID,
		SportClassCode,
		SportClassGroupCode,
		IsActive,
		CreatedBy,
		CreatedDateTime,
		ModifiedBy,
		ModifiedDateTime
	FROM	T_SportClass TSC
	WHERE	IsActive = 1
	AND (SportClassID = @n_SportClassID or @n_SportClassID IS NULL)
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
