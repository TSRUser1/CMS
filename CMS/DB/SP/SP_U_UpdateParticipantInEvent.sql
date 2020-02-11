IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateParticipantInEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateParticipantInEvent
END
GO

/*************************************************************************
* Name				: SP_U_UpdateParticipantInEvent
* Author			: DEV001
* Create date		: 22-Aug-2015
* Description		: Update Schedule detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateParticipantInEvent]
(
	@n_ParticipantInEventID	int,
	@n_ParticipantID		int,
	@n_EventID				int,
	@n_TeamID				int,
	@n_SportClassID			int,
	@n_GroupCode			nvarchar(100),
    @n_IsActive				int,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
 
 IF(@n_ParticipantInEventID = 0)
 BEGIN
	INSERT INTO dbo.T_ParticipantInEvent
           (ParticipantID
           ,EventID
		   ,TeamID
		   ,SportClassID
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@n_ParticipantID
           ,@n_EventID
		   ,@n_TeamID
		   ,@n_SportClassID
           ,@n_IsActive
           ,@d_ModifiedDateTime
           ,@n_ModifiedBy
           ,@d_ModifiedDateTime
           ,@n_ModifiedBy)
 END
 ELSE
 BEGIN
	UPDATE dbo.T_ParticipantInEvent
	   SET ParticipantID = ISNULL(@n_ParticipantID, ParticipantID)
		  ,EventID = ISNULL(@n_EventID, EventID)
		  ,TeamID = ISNULL(@n_TeamID, TeamID)
		  ,SportClassID = ISNULL(@n_SportClassID, SportClassID)
		  ,IsActive = ISNULL(@n_IsActive, IsActive)
		  ,ModifiedDateTime = ISNULL(@d_ModifiedDateTime, ModifiedDateTime)
		  ,ModifiedBy = ISNULL(@n_ModifiedBy, ModifiedBy)
	 WHERE ParticipantInEventID = @n_ParticipantInEventID
 END
	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateParticipantInEvent] TO USER
GO*/