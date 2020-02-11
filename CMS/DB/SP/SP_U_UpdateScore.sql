IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateScore' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateScore
END
GO

/*************************************************************************
* Name				: SP_U_UpdateScore
* Author			: Ramani Ganason
* Create date		: 30-Aug-2015
* Description		: Update Score
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateScore]
(
	@n_ScoreID		 	int,
	@s_Score1	   	 	nvarchar(100),
    @s_Score2	   	 	nvarchar(100),
    @s_Score3	   	 	nvarchar(100),
    @s_Score4	   	 	nvarchar(100),
    @s_Score5	   	 	nvarchar(100),
    @s_Score6	   	 	nvarchar(100),
    @s_Score7	   	 	nvarchar(100),
    @s_Score8	   	 	nvarchar(100),
    @s_Score9	   	 	nvarchar(100),
    @s_Score10	   	 	nvarchar(100),
    @s_Score11	   	 	nvarchar(100),
    @s_Score12	   	 	nvarchar(100),
    @s_Score13	   	 	nvarchar(100),
    @s_Score14	   	 	nvarchar(100),
    @s_Score15	   	 	nvarchar(100),
    @s_Score16	   	 	nvarchar(100),
    @s_Score17	   	 	nvarchar(100),
    @s_Score18	   	 	nvarchar(100),
    @s_Score19	   	 	nvarchar(100),
    @s_Score20	   	 	nvarchar(100),
	@s_ScoreFinal		nvarchar(100),
	@s_BreakRecord	 	nvarchar(100),
    @n_MedalID		 	int,
    @n_ResultPosition	int,
	@s_Remarks			nvarchar(100),
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE T_Score
	   SET	Score1 = @s_Score1
			,Score2 = @s_Score2
			,Score3 = @s_Score3
			,Score4 = @s_Score4
			,Score5 = @s_Score5
			,Score6 = @s_Score6
			,Score7 = @s_Score7
			,Score8 = @s_Score8
			,Score9 = @s_Score9
			,Score10 = @s_Score10
			,Score11 = @s_Score11
			,Score12 = @s_Score12
			,Score13 = @s_Score13
			,Score14 = @s_Score14
			,Score15 = @s_Score15
			,Score16 = @s_Score16
			,Score17 = @s_Score17
			,Score18 = @s_Score18
			,Score19 = @s_Score19
			,Score20 = @s_Score20
			,ScoreFinal = @s_ScoreFinal
			,BreakRecord = @s_BreakRecord
			,MedalID = @n_MedalID
			,ResultPosition = @n_ResultPosition
			,Remarks = @s_Remarks
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE ScoreID = @n_ScoreID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateScore] TO USER
GO*/