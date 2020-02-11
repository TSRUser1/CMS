IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetDataColumnByDataGridName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetDataColumnByDataGridName
END
GO

/*************************************************************************
* Name				: SP_S_GetDataColumnByDataGridName
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return reference
*************************************************************************/
CREATE PROCEDURE [SP_S_GetDataColumnByDataGridName]
(
	@s_DataGridName			nvarchar(100)
)
AS
BEGIN

	SELECT	*
	FROM	T_DataGridColumn
	WHERE	DataGridName = @s_DataGridName
	and IsActive = 1
	ORDER BY SortID
		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetDataColumnByDataGridName] TO USER
GO*/