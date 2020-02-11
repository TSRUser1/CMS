IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertStatisticName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertStatisticName
END
GO

/*************************************************************************
* Name				: SP_I_InsertStatisticName
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Insert Statistic Name
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertStatisticName]
(
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
    @n_ScheduleID			 int,
    @n_IsActive			 	 int,
    @d_CreatedDateTime	 	 datetime,
    @n_CreatedBy		 	 int
)
AS
BEGIN
INSERT INTO dbo.T_StatisticName
           (StatisticName1
           ,StatisticName2
           ,StatisticName3
           ,StatisticName4
           ,StatisticName5
           ,StatisticName6
           ,StatisticName7
           ,StatisticName8
           ,StatisticName9
           ,StatisticName10
           ,ScheduleID
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_StatisticName1
           ,@s_StatisticName2
           ,@s_StatisticName3
           ,@s_StatisticName4
           ,@s_StatisticName5
           ,@s_StatisticName6
           ,@s_StatisticName7
           ,@s_StatisticName8
           ,@s_StatisticName9
           ,@s_StatisticName10
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
GRANT EXEC ON [dbo].[SP_I_InsertStatisticName] TO USER
GO*/