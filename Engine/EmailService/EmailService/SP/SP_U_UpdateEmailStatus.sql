IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateEmailStatus' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateEmailStatus
END
GO

/*************************************************************************
* Name				: SP_U_UpdateEmailStatus
* Author			: Ramani Ganason
* Create date		: 07-Aug-2015
* Description		: Update email status
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateEmailStatus]
(
	@n_EmailID			int,
	@n_StatusCode			int,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Email
	Set EmailStatus = @n_StatusCode,
		ModifiedBy = @n_ModifiedBy,
		ModifiedDateTime = @d_ModifiedDateTime,
		AttemptCount = AttemptCount + 1
	WHERE EmailID = @n_EmailID	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateEmailStatus] TO USER
GO*/