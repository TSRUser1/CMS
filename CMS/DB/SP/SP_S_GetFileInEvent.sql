IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetFileInEvent' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetFileInEvent
END
GO

/*************************************************************************
* Name				: SP_S_GetFileInEvent
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return File detail
*************************************************************************/
/*************************************************************************
* Name				: SP_S_GetFileInEvent
* Author			: Reese
* Create date		: 29-Aug-2015
* Description		: Handle StartListDetail
*************************************************************************/
CREATE PROCEDURE [SP_S_GetFileInEvent]
(
	@n_EventID				int
)
AS
BEGIN

	DECLARE @n_SportID	int

	SELECT @n_SportID = SportID
	FROM T_Event WHERE EventID = @n_EventID

	   SELECT FileGroupID
			,ref.ReferenceName
			,fie.EventID
			,fie.FileID
			,fie.IsLinkedToSport
			,[FileName]
			,FilePath
			,f.CreatedDateTime
	  FROM dbo.T_File as f
	  INNER JOIN dbo.T_FileInEvent as fie
	  ON f.FileID = fie.FileID
	  INNER JOIN dbo.T_Reference as ref
	  ON fie.FileGroupID = ref.ReferenceInternalID
	  INNER JOIN dbo.T_Event e
	  ON fie.EventID = e.EventID
	  WHERE(
		(@n_EventID IS NULL OR fie.EventID = @n_EventID)
		OR
		(@n_SportID IS NULL AND fie.IsLinkedToSport = 1)
		OR 
		(e.SportID = @n_SportID AND fie.IsLinkedToSport = 1)
		)
	  AND ref.ReferenceCategoryID = 8
	  AND f.IsActive = 1			
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetFileInEvent] TO USER
GO*/