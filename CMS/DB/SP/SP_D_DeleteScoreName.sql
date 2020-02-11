IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteScoreName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteScoreName
END
GO

/*************************************************************************
* Name				: SP_D_DeleteScoreName
* Author			: Ramani Ganason
* Create date		: 26-Aug-2015
* Description		: Delete Score Name
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteScoreName]
(
	@n_ScoreNameID			int,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_ScoreName
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ScoreNameID = @n_ScoreNameID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteScoreName] TO USER
GO*/