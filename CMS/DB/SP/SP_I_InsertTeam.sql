IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertTeam
END
GO

/*************************************************************************
* Name				: SP_I_InsertTeam
* Author			: Edwind Tay Chee Hou
* Create date		: 19-Oct-2015
* Description		: Insert Team
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertTeam]
(
	@s_TeamName	  		nvarchar(100),
	@n_EventID			int,
    @n_IsActive			int,
    @d_CreatedDateTime	datetime,
    @n_CreatedBy		int,
	@n_TeamID			int output
)
AS
BEGIN
INSERT INTO dbo.T_Team
           (TeamName
           ,EventID
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_TeamName
           ,@n_EventID
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

	SET @n_TeamID = @@IDENTITY
	RETURN @n_TeamID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertTeam] TO USER
GO*/