IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertReferenceCategory' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertReferenceCategory
END
GO

/*************************************************************************
* Name				: SP_I_InsertReferenceCategory
* Author			: DEV001
* Create date		: 28-Jul-2015
* Description		: Insert reference category
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertReferenceCategory]
(
	@s_ReferenceCategoryCode	nvarchar(100),
	@s_Description			nvarchar(MAX),
	@n_ModifiedBy		int,
	@d_ModifiedDateTime	datetime
)
AS
BEGIN
INSERT INTO dbo.T_ReferenceCategory
           ([ReferenceCategoryCode]
			,[ReferenceCategoryDescription]
			,[IsActive]
			,[CreatedBy]
			,[CreatedDateTime]
			,[ModifiedBy]
			,[ModifiedDateTime])
     VALUES
           (@s_ReferenceCategoryCode
           ,@s_Description
           ,1
           ,@n_ModifiedBy
           ,@d_ModifiedDateTime
           ,@n_ModifiedBy
           ,@d_ModifiedDateTime)

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertReferenceCategory] TO USER
GO*/