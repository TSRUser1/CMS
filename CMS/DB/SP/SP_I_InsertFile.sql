IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertFile' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertFile
END
GO

/*************************************************************************
* Name				: SP_I_InsertFile
* Author			: DEV001
* Create date		: 11-SEP-2015
* Description		: Insert File
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertFile]
(
	@s_FileName	  		 nvarchar(255),
    @s_FilePath	   	 nvarchar(100),
    @n_IsActive			 int,
    @d_CreatedDateTime	 datetime,
    @n_CreatedBy		 int,
	@n_FileID			 int output
)
AS
BEGIN
INSERT INTO dbo.T_File
           (FileName
           ,FilePath
           ,IsActive
           ,CreatedBy
           ,CreatedDateTime
           ,ModifiedBy
           ,ModifiedDateTime)
     VALUES
           (
			 @s_FileName	  		
			,@s_FilePath	   	 
			,@n_IsActive	
			,@n_CreatedBy		
			,@d_CreatedDateTime
			,@n_CreatedBy		
			,@d_CreatedDateTime	
		   )
	
	SET @n_FileID = @@IDENTITY
	RETURN @n_FileID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertFile] TO USER
GO*/