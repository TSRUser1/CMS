IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetInitialRecord' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetInitialRecord
END
GO

/*************************************************************************
* Name				: SP_S_GetInitialRecord
* Author			: Jonathan.Goh
* Create date		: 12-Nov-2015
* Description		: Return Initial Record
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetInitialRecord]
(
	@n_EventID AS int
)
AS
BEGIN
	SELECT IR.[EventID]
		  ,E.[EventName] 
		  ,UPPER([FullName]) AS FullName
		  ,ISNULL(Result, '') AS Result
		  ,ISNULL(Record, '') AS Record
		  ,[Date]
		  ,([City] + ', ' + [Country]) AS Location
	  FROM [dbo].[T_InitialRecord] IR
	  INNER JOIN [dbo].[T_Event] E
	  ON E.EventID = IR.EventID
	  WHERE IR.EventID = @n_EventID OR @n_EventID IS NULL
	  AND (Result IS NOT NULL OR Record IS NOT NULL)
	  AND IR.IsActive = 1
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetInitialRecord] TO USER
GO*/