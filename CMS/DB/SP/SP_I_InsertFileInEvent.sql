IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertFileInEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertFileInEvent
END
GO

/*************************************************************************
* Name				: SP_I_InsertFileInEvent
* Author			: DEV001
* Create date		: 11-SEP-2015
* Description		: Insert File
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertFileInEvent]
(
	@n_FileID			 int,
	@n_EventID			 int,
	@n_FileGroupID		 int,
	@b_IsLinkedToSport	 bit,
    @n_IsActive			 int,
    @d_CreatedDateTime	 datetime,
    @n_CreatedBy		 int
)
AS
BEGIN
INSERT INTO dbo.T_FileInEvent
           (FileID
           ,EventID
           ,FileGroupID
           ,IsLinkedToSport
           ,IsActive
           ,CreatedBy
           ,CreatedDateTime
           ,ModifiedBy
           ,ModifiedDateTime)
     VALUES
           (
			 @n_FileID
			 ,@n_EventID
			 ,@n_FileGroupID
             ,@b_IsLinkedToSport
			 ,@n_IsActive
			 ,@n_CreatedBy
			 ,@d_CreatedDateTime
			 ,@n_CreatedBy
			 ,@d_CreatedDateTime
		   )
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertFileInEvent] TO USER
GO*/