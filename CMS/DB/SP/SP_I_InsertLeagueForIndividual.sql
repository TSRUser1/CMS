IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertLeagueForIndividual' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertLeagueForIndividual
END
GO

/*************************************************************************
* Name				: SP_I_InsertLeagueForIndividual
* Author			: Ramani Ganason
* Create date		: 30-Aug-2015
* Description		: Insert League Details for Event
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertLeagueForIndividual]
(
	@n_ParticipantInEventID		int,
	@n_Rank						int,
	@n_EventID						int,
	@s_GroupCode				nvarchar(100),
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
	@n_IsActive			 		int,
    @d_CreatedDateTime	 		datetime,
    @n_CreatedBy		 		int
)
AS
BEGIN
INSERT INTO T_League
           (Rank
           ,League1	   	
           ,League2	   	
           ,League3	   	
           ,League4	   	
           ,League5	   	
           ,League6	   	
           ,League7	   	
           ,League8	   	
           ,League9	   	
           ,League10	   	
           ,League11	   	
           ,League12	   	
           ,League13	   	
           ,League14	   	
           ,League15	   	
		   ,League16	   	
           ,League17	   	
           ,League18	   	
           ,League19	   	
           ,League20
		   ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@n_Rank	
           ,@s_League1	   	
           ,@s_League2	   	
           ,@s_League3	   	
           ,@s_League4	   	
           ,@s_League5	   	
           ,@s_League6	   	
           ,@s_League7	   	
           ,@s_League8	   	
           ,@s_League9	   	
           ,@s_League10	   	
           ,@s_League11	   	
           ,@s_League12	   	
           ,@s_League13	   	
           ,@s_League14	   	
           ,@s_League15	   	
		   ,@s_League16	   	
           ,@s_League17	   	
           ,@s_League18	   	
           ,@s_League19	   	
           ,@s_League20	   	
		   ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)


INSERT INTO
	T_LeagueInParticipantInEvent
           (LeagueID
		   ,EventID
		   ,ParticipantInEventID
		   ,GroupCode)
     VALUES
           (SCOPE_IDENTITY()
		   ,@n_EventID
		   ,@n_ParticipantInEventID
		   ,@s_GroupCode
		   )

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertLeagueForIndividual] TO USER
GO*/