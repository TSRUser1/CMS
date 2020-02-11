IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetDataColumnName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetDataColumnName
END
GO

/*************************************************************************
* Name				: SP_S_GetDataColumnName
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return reference
*************************************************************************/
CREATE PROCEDURE [SP_S_GetDataColumnName]
AS
BEGIN

	SELECT	DISTINCT DataGridName
	FROM	T_DataGridColumn
	WHERE IsActive = 1
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetDataColumnName] TO USER
GO*/