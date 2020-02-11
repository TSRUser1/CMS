IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteScore' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteScore
END
GO

/*************************************************************************
* Name				: SP_D_DeleteScore
* Author			: Ramani Ganason
* Create date		: 26-Aug-2015
* Description		: Delete Score
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteScore]
(
	@n_ScoreID			int,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Score
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ScoreID = @n_ScoreID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteScore] TO USER
GO*/