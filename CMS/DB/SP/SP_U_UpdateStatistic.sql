IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateStatistic' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateStatistic
END
GO

/*************************************************************************
* Name				: SP_U_UpdateStatistic
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Update Statistic
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateStatistic]
(
	@n_StatisticID		 	int,
	@s_Statistic1	   	 	nvarchar(100),
    @s_Statistic2	   	 	nvarchar(100),
    @s_Statistic3	   	 	nvarchar(100),
    @s_Statistic4	   	 	nvarchar(100),
    @s_Statistic5	   	 	nvarchar(100),
    @s_Statistic6	   	 	nvarchar(100),
    @s_Statistic7	   	 	nvarchar(100),
    @s_Statistic8	   	 	nvarchar(100),
    @s_Statistic9	   	 	nvarchar(100),
    @s_Statistic10	   	 	nvarchar(100),
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE T_Statistic
	   SET	Statistic1 = @s_Statistic1
			,Statistic2 = @s_Statistic2
			,Statistic3 = @s_Statistic3
			,Statistic4 = @s_Statistic4
			,Statistic5 = @s_Statistic5
			,Statistic6 = @s_Statistic6
			,Statistic7 = @s_Statistic7
			,Statistic8 = @s_Statistic8
			,Statistic9 = @s_Statistic9
			,Statistic10 = @s_Statistic10
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE StatisticID = @n_StatisticID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateStatistic] TO USER
GO*/