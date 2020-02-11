IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteEvent
END
GO

/*************************************************************************
* Name				: SP_D_DeleteEvent
* Author			: Ramani
* Create date		: 22-Aug-2015
* Description		: Delete event by setting IsActive to 0
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteEvent]
(
	@n_EventID				int,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Event
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE EventID = @n_EventID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteEvent] TO USER
GO*/