IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertDataGridColumn' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertDataGridColumn
END
GO

/*************************************************************************
* Name				: SP_I_InsertDataGridColumn
* Author			: DEV001
* Create date		: 28-Jul-2015
* Description		: Insert reference category
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertDataGridColumn]
(
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
INSERT INTO dbo.T_DataGridColumn
           (DataGridName
           ,HeaderText
           ,DataField
           ,NavigateURL
           ,NavigateURLDataField
           ,SortID
           ,ColumnTypeID
		   ,EnumTypeID
           ,ColumnWidth
           ,CSSClass
           ,IsReadOnly
           ,IsAllowHTMLEncode
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_DataGridName
           ,@s_HeaderText
           ,@s_DataField
           ,@s_NavigateURL
           ,@s_NavigateURLDataField
           ,@n_SortID
           ,@n_ColumnTypeID
		   ,@n_EnumTypeID
           ,@n_ColumnWidth
           ,@s_CssClass
           ,@b_IsReadOnly
           ,@b_IsAllowHTMLEncode
           ,1
           ,@d_ModifiedDateTime
           ,@n_ModifiedBy
           ,@d_ModifiedDateTime
           ,@n_ModifiedBy)

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertDataGridColumn] TO USER
GO*/