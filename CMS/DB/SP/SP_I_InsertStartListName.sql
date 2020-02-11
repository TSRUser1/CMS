IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertStartListName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertStartListName
END
GO

/*************************************************************************
* Name				: SP_I_InsertStartListName
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Insert StartListName Name
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertStartListName]
(
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
    @n_ScheduleID			 int,
    @n_IsActive			 	 int,
    @d_CreatedDateTime	 	 datetime,
    @n_CreatedBy		 	 int
)
AS
BEGIN
INSERT INTO T_StartListName
           (StartListName1
           ,StartListName2
           ,StartListName3
           ,StartListName4
           ,StartListName5
           ,StartListName6
           ,StartListName7
           ,StartListName8
           ,StartListName9
           ,StartListName10
           ,ScheduleID
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_StartListName1
           ,@s_StartListName2
           ,@s_StartListName3
           ,@s_StartListName4
           ,@s_StartListName5
           ,@s_StartListName6
           ,@s_StartListName7
           ,@s_StartListName8
           ,@s_StartListName9
           ,@s_StartListName10
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
GRANT EXEC ON [dbo].[SP_I_InsertStartListName] TO USER
GO*/