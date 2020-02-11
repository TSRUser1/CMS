IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateReferee' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateReferee
END
GO

/*************************************************************************
* Name				: SP_U_UpdateReferee
* Author			: Ramani Ganason
* Create date		: 02-Oct-2015
* Description		: Update Referee
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateReferee]
(
	@n_RefereeID		 	int,
	@s_RefereeName1	   	 	nvarchar(100),
    @s_RefereeName2	   	 	nvarchar(100),
    @s_RefereeName3	   	 	nvarchar(100),
    @s_RefereeName4	   	 	nvarchar(100),
    @s_RefereeName5	   	 	nvarchar(100),
    @s_RefereeName6	   	 	nvarchar(100),
    @s_RefereeName7	   	 	nvarchar(100),
    @s_RefereeName8	   	 	nvarchar(100),
    @s_RefereeName9	   	 	nvarchar(100),
    @s_RefereeName10	   	nvarchar(100),
    @s_RefereeTitle1	   	nvarchar(100),
    @s_RefereeTitle2	   	nvarchar(100),
    @s_RefereeTitle3	   	nvarchar(100),
    @s_RefereeTitle4	   	nvarchar(100),
    @s_RefereeTitle5	   	nvarchar(100),
    @s_RefereeTitle6	   	nvarchar(100),
    @s_RefereeTitle7	   	nvarchar(100),
    @s_RefereeTitle8	   	nvarchar(100),
    @s_RefereeTitle9	   	nvarchar(100),
    @s_RefereeTitle10	   	nvarchar(100),
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
	UPDATE T_Referee
	   SET   RefereeName1	= @s_RefereeName1	 
			,RefereeName2	= @s_RefereeName2	 
			,RefereeName3	= @s_RefereeName3	 
			,RefereeName4	= @s_RefereeName4	 
			,RefereeName5	= @s_RefereeName5	 
			,RefereeName6	= @s_RefereeName6	 
			,RefereeName7	= @s_RefereeName7	 
			,RefereeName8	= @s_RefereeName8	 
			,RefereeName9	= @s_RefereeName9	 
			,RefereeName10 	= @s_RefereeName10
			,RefereeTitle1 	= @s_RefereeTitle1
			,RefereeTitle2 	= @s_RefereeTitle2
			,RefereeTitle3 	= @s_RefereeTitle3
			,RefereeTitle4 	= @s_RefereeTitle4
			,RefereeTitle5 	= @s_RefereeTitle5
			,RefereeTitle6 	= @s_RefereeTitle6
			,RefereeTitle7 	= @s_RefereeTitle7
			,RefereeTitle8 	= @s_RefereeTitle8
			,RefereeTitle9 	= @s_RefereeTitle9
			,RefereeTitle10 = @s_RefereeTitle10
			,ModifiedDateTime = @d_ModifiedDateTime
			,ModifiedBy = @n_ModifiedBy
	 WHERE RefereeID = @n_RefereeID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateReferee] TO USER
GO*/