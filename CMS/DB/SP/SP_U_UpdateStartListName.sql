IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateStartListName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateStartListName
END
GO

/*************************************************************************
* Name				: SP_U_UpdateStartListName
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Update StartList Name
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateStartListName]
(
	@n_StartListNameID		 int,
	@s_StartListName1	   	 nvarchar(100),
    @s_StartListName2	   	 nvarchar(100),
    @s_StartListName3	   	 nvarchar(100),
    @s_StartListName4	   	 nvarchar(100),
    @s_StartListName5	   	 nvarchar(100),
    @s_StartListName6	   	 nvarchar(100),
    @s_StartListName7	   	 nvarchar(100),
    @s_StartListName8	   	 nvarchar(100),
    @s_StartListName9	   	 nvarchar(100),
    @s_StartListName10	   	 nvarchar(100),
	@n_ModifiedBy			 int,
	@d_ModifiedDateTime		 datetime
)
AS
BEGIN
	UPDATE T_StartListName
	   SET	StartListName1 =  	@s_StartListName1
			,StartListName2 = 	@s_StartListName2
			,StartListName3 = 	@s_StartListName3
			,StartListName4 = 	@s_StartListName4
			,StartListName5 = 	@s_StartListName5
			,StartListName6 = 	@s_StartListName6
			,StartListName7 = 	@s_StartListName7
			,StartListName8 = 	@s_StartListName8
			,StartListName9 = 	@s_StartListName9
			,StartListName10 = 	@s_StartListName10
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE StartListNameID = @n_StartListNameID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateStartListName] TO USER
GO*/