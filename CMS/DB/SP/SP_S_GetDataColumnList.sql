IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetDataColumnList' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetDataColumnList
END
GO

/*************************************************************************
* Name				: SP_S_GetDataColumnList
* Author			: DEV001
* Create date		: 29-Jul-2015
* Description		: Return list of data grid column
*************************************************************************/
CREATE PROCEDURE [SP_S_GetDataColumnList]
(
	@s_DataGridName			nvarchar(100)
)
AS
BEGIN

	SELECT	*
	FROM	T_DataGridColumn
	WHERE	(DataGridName = @s_DataGridName or @s_DataGridName = '')
	AND IsActive = 1
	ORDER BY SortID
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetDataColumnList] TO USER
GO*/