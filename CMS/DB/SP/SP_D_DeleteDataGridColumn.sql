IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_D_DeleteDataGridColumn' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_D_DeleteDataGridColumn
END
GO

/*************************************************************************
* Name				: SP_D_DeleteDataGridColumn
* Author			: DEV001
* Create date		: 29-Jul-2015
* Description		: Delete datagrid column
*************************************************************************/
CREATE PROCEDURE [SP_D_DeleteDataGridColumn]
(
	@n_DataGridColumnID			int,
	@n_ModifiedBy		INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN
	UPDATE T_DataGridColumn
	Set IsActive = 0,
	ModifiedBy = @n_ModifiedBy,
	ModifiedDateTime = @d_ModifiedDateTime
	WHERE DataGridColumnID = @n_DataGridColumnID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_D_DeleteDataGridColumn] TO USER
GO*/