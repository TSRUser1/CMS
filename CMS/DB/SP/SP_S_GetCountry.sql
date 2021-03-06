IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetCountry' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetCountry
END
GO

/*************************************************************************
* Name				: SP_S_GetCountry
* Author			: Edwind
* Create date		: 1-Sep-2015
* Description		: Return country
*************************************************************************/
CREATE PROCEDURE SP_S_GetCountry
(
	@n_CountryID				int
)
AS
BEGIN
	
	SELECT 
		CountryID,
		CountryName,
		ISOCode2,
		ISOCode3,
		FlagImageFilePath,
		IconFilePath,
		SmallIconFilePath,
		RegionID,
		IsActive,
		CreatedDateTime,
		CreatedBy,
		ModifiedDateTime,
		ModifiedBy
  FROM T_Country TC
  WHERE IsActive = 1
  AND (CountryID = @n_CountryID or @n_CountryID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetCountry] TO USER
GO*/
