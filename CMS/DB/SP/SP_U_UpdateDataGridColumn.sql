IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateDataGridColumn' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateDataGridColumn
END
GO

/*************************************************************************
* Name				: SP_U_UpdateDataGridColumn
* Author			: DEV001
* Create date		: 29-Jul-2015
* Description		: Update data grid column
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateDataGridColumn]
(
	@n_DataGridColumnID		INT,
	@s_DataGridName			NVARCHAR(200),
	@s_HeaderText			NVARCHAR(100),
	@s_DataField			NVARCHAR(100),
	@n_SortID				INT,
	@n_ColumnTypeID			INT,
	@n_EnumTypeID			INT,
	@s_NavigateURL			NVARCHAR(MAX),
	@s_NavigateURLDataField	NVARCHAR(200),
	@n_ColumnWidth			INT,
	@s_CssClass				NVARCHAR(MAX),
	@b_IsReadOnly			BIT,
	@b_IsAllowHTMLEncode	BIT,
	@n_ModifiedBy			INT,
	@d_ModifiedDateTime		DATETIME
)
AS
BEGIN



	UPDATE T_DataGridColumn
	Set DataGridName      = @s_DataGridName,
		HeaderText        = @s_HeaderText,
		DataField         = @s_DataField,
		NavigateURL       = @s_NavigateURL,
		NavigateURLDataField       = @s_NavigateURLDataField,
		SortID            = @n_SortID,
		ColumnTypeID      = @n_ColumnTypeID,
		EnumTypeID		  = @n_EnumTypeID,
		ColumnWidth       = @n_ColumnWidth,
		CSSClass          = @s_CssClass,
		IsReadOnly        = @b_IsReadOnly,
		IsAllowHTMLEncode = @b_IsAllowHTMLEncode,
		ModifiedDateTime  = @d_ModifiedDateTime,
		ModifiedBy        = @n_ModifiedBy		
	WHERE DataGridColumnID = @n_DataGridColumnID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateDataGridColumn] TO USER
GO*/