IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateStatisticName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateStatisticName
END
GO

/*************************************************************************
* Name				: SP_U_UpdateStatisticName
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Update Statistic Name
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateStatisticName]
(
	@n_StatisticNameID		 int,
	@s_StatisticName1	   	 nvarchar(100),
    @s_StatisticName2	   	 nvarchar(100),
    @s_StatisticName3	   	 nvarchar(100),
    @s_StatisticName4	   	 nvarchar(100),
    @s_StatisticName5	   	 nvarchar(100),
    @s_StatisticName6	   	 nvarchar(100),
    @s_StatisticName7	   	 nvarchar(100),
    @s_StatisticName8	   	 nvarchar(100),
    @s_StatisticName9	   	 nvarchar(100),
    @s_StatisticName10	   	 nvarchar(100),
	@n_ModifiedBy			 int,
	@d_ModifiedDateTime		 datetime
)
AS
BEGIN
	UPDATE T_StatisticName
	   SET	StatisticName1 =  	@s_StatisticName1
			,StatisticName2 = 	@s_StatisticName2
			,StatisticName3 = 	@s_StatisticName3
			,StatisticName4 = 	@s_StatisticName4
			,StatisticName5 = 	@s_StatisticName5
			,StatisticName6 = 	@s_StatisticName6
			,StatisticName7 = 	@s_StatisticName7
			,StatisticName8 = 	@s_StatisticName8
			,StatisticName9 = 	@s_StatisticName9
			,StatisticName10 = 	@s_StatisticName10
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE StatisticNameID = @n_StatisticNameID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateStatisticName] TO USER
GO*/