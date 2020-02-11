IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetEmailAttachment' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetEmailAttachment
END
GO

/*************************************************************************
* Name				: SP_S_GetEmailAttachment
* Author			: Ramani Ganason
* Create date		: 03-Aug-2015
* Description		: Return all the attachment for the email.
*************************************************************************/
CREATE PROCEDURE [SP_S_GetEmailAttachment]
(
	@n_EmailID			int
)
AS
BEGIN

	SELECT	EmailAttachmentID
		  ,EmailAttachmentLocation
		  ,EmailAttachmentType
	FROM	T_EmailAttachment
	WHERE	EmailID  = @n_EmailID		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetEmailAttachment] TO USER
GO*/