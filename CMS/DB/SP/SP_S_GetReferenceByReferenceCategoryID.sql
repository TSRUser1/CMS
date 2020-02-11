IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetReferenceByReferenceCategoryID' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetReferenceByReferenceCategoryID
END
GO

/*************************************************************************
* Name				: SP_S_GetReferenceByReferenceCategoryID
* Author			: DEV001
* Create date		: 28-Jul-2015
* Description		: Return reference list
*************************************************************************/
CREATE PROCEDURE [SP_S_GetReferenceByReferenceCategoryID]
(
	@n_ReferenceCategoryID	INT,
	@n_LanguageID INT,
	@n_ReferenceInternalID INT
)
AS
BEGIN

	SELECT  ReferenceInternalID,
			ReferenceCategoryID,
			ReferenceCode,
			ReferenceContent,
			ReferenceDescription
			FROM T_Reference
			WHERE ReferenceCategoryID = @n_ReferenceCategoryID
			AND (LanguageID = @n_LanguageID OR @n_LanguageID is null)
			AND (ReferenceInternalID = @n_ReferenceInternalID OR @n_ReferenceInternalID is null)
			AND IsActive = 1
			ORDER BY ReferenceContent

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetReferenceByReferenceCategoryID] TO USER
GO*/