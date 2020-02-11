IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetBulkEmail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetBulkEmail
END
GO

/*************************************************************************
* Name				: SP_S_GetBulkEmail
* Author			: Ramani Ganason
* Create date		: 03-Aug-2015
* Description		: Return all the emails to send out.
*************************************************************************/
CREATE PROCEDURE [SP_S_GetBulkEmail]
(
	@n_maxRetryCount			int
)
AS
BEGIN

	SELECT	EmailID
		  ,EmailSubject
		  ,ReceiverEmail
		  ,ReceiverEmail_CC
		  ,ReceiverEmail_BCC
		  ,EmailContent
		  ,EmailStatus 
		  ,CreatedBy
		  ,CreatedDateTime
		  ,ModifiedBy
		  ,ModifiedDateTime
	FROM	T_Email
	WHERE	EmailStatus <> 250
	AND		AttemptCount < @n_maxRetryCount
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetBulkEmail] TO USER
GO*/