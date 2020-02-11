IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteParticipant' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteParticipant
END
GO

/*************************************************************************
* Name				: SP_D_DeleteParticipant
* Author			: DEV001
* Create date		: 30-Aug-2015
* Description		: Delete Participant
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteParticipant]
(
	@n_ParticipantID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_Participant
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE ParticipantID = @n_ParticipantID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteParticipant] TO USER
GO*/