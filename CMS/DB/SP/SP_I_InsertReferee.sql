IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertReferee' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertReferee
END
GO

/*************************************************************************
* Name				: SP_I_InsertReferee
* Author			: Ramani Ganason
* Create date		: 02-Oct-2015
* Description		: Insert Referee List
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertReferee]
(
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
    @n_ScheduleID			 int,
    @n_IsActive			 int,
    @d_CreatedDateTime	 datetime,
    @n_CreatedBy		 int
)
AS
BEGIN
INSERT INTO T_Referee
           (RefereeName1
           ,RefereeName2
           ,RefereeName3
           ,RefereeName4
           ,RefereeName5
           ,RefereeName6
           ,RefereeName7
           ,RefereeName8
           ,RefereeName9
           ,RefereeName10
		   ,RefereeTitle1
           ,RefereeTitle2
           ,RefereeTitle3
           ,RefereeTitle4
           ,RefereeTitle5
           ,RefereeTitle6
           ,RefereeTitle7
           ,RefereeTitle8
           ,RefereeTitle9
           ,RefereeTitle10
           ,ScheduleID
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_RefereeName1
           ,@s_RefereeName2
           ,@s_RefereeName3
           ,@s_RefereeName4
           ,@s_RefereeName5
           ,@s_RefereeName6
           ,@s_RefereeName7
           ,@s_RefereeName8
           ,@s_RefereeName9
           ,@s_RefereeName10
		   ,@s_RefereeTitle1
           ,@s_RefereeTitle2
           ,@s_RefereeTitle3
           ,@s_RefereeTitle4
           ,@s_RefereeTitle5
           ,@s_RefereeTitle6
           ,@s_RefereeTitle7
           ,@s_RefereeTitle8
           ,@s_RefereeTitle9
           ,@s_RefereeTitle10
           ,@n_ScheduleID
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertReferee] TO USER
GO*/