IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateLeague' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateLeague
END
GO

/*************************************************************************
* Name				: SP_U_UpdateLeague
* Author			: Ramani Ganason
* Create date		: 30-Aug-2015
* Description		: Update Score
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateLeague]
(
	@n_LeagueID					int,
	@n_Rank						int,
    @s_League1	   	 			nvarchar(100),
    @s_League2	   	 			nvarchar(100),
    @s_League3	   	 			nvarchar(100),
    @s_League4	   	 			nvarchar(100),
    @s_League5	   	 			nvarchar(100),
    @s_League6	   	 			nvarchar(100),
    @s_League7	   	 			nvarchar(100),
    @s_League8	   	 			nvarchar(100),
    @s_League9	   	 			nvarchar(100),
    @s_League10	   	 			nvarchar(100),
    @s_League11	   	 			nvarchar(100),
    @s_League12	   	 			nvarchar(100),
    @s_League13	   	 			nvarchar(100),
    @s_League14	   	 			nvarchar(100),
    @s_League15	   	 			nvarchar(100),
    @s_League16	   	 			nvarchar(100),
    @s_League17	   	 			nvarchar(100),
    @s_League18	   	 			nvarchar(100),
    @s_League19	   	 			nvarchar(100),
    @s_League20	   	 			nvarchar(100),
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE T_League
	   SET	Rank = @n_Rank
			,League1  = @s_League1	
			,League2  = @s_League2	
			,League3  = @s_League3	
			,League4  = @s_League4	
			,League5  = @s_League5	
			,League6  = @s_League6	
			,League7  = @s_League7	
			,League8  = @s_League8	
			,League9  = @s_League9	
			,League10 = @s_League10
			,League11 = @s_League11
			,League12 = @s_League12
			,League13 = @s_League13
			,League14 = @s_League14
			,League15 = @s_League15
			,League16 = @s_League16
			,League17 = @s_League17
			,League18 = @s_League18
			,League19 = @s_League19
			,League20 = @s_League20
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE LeagueID = @n_LeagueID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateLeague] TO USER
GO*/