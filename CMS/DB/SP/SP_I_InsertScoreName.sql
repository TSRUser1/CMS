IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertScoreName' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertScoreName
END
GO

/*************************************************************************
* Name				: SP_I_InsertScoreName
* Author			: Ramani Ganason
* Create date		: 29-Aug-2015
* Description		: Insert Score Name
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertScoreName]
(
    @s_ScoreName1	   	 nvarchar(100),
    @s_ScoreName2	   	 nvarchar(100),
    @s_ScoreName3	   	 nvarchar(100),
    @s_ScoreName4	   	 nvarchar(100),
    @s_ScoreName5	   	 nvarchar(100),
    @s_ScoreName6	   	 nvarchar(100),
    @s_ScoreName7	   	 nvarchar(100),
    @s_ScoreName8	   	 nvarchar(100),
    @s_ScoreName9	   	 nvarchar(100),
    @s_ScoreName10	   	 nvarchar(100),
    @s_ScoreName11	   	 nvarchar(100),
    @s_ScoreName12	   	 nvarchar(100),
    @s_ScoreName13	   	 nvarchar(100),
    @s_ScoreName14	   	 nvarchar(100),
    @s_ScoreName15	   	 nvarchar(100),
    @s_ScoreName16	   	 nvarchar(100),
    @s_ScoreName17	   	 nvarchar(100),
    @s_ScoreName18	   	 nvarchar(100),
    @s_ScoreName19	   	 nvarchar(100),
    @s_ScoreName20	   	 nvarchar(100),
	@s_ScoreNameFinal	 nvarchar(100),
	@z_IsVisible1		 bit,
	@z_IsVisible2		 bit,
	@z_IsVisible3		 bit,
	@z_IsVisible4		 bit,
	@z_IsVisible5		 bit,
	@z_IsVisible6		 bit,
	@z_IsVisible7		 bit,
	@z_IsVisible8		 bit,
	@z_IsVisible9		 bit,
	@z_IsVisible10		 bit,
	@z_IsVisible11		 bit,
	@z_IsVisible12		 bit,
	@z_IsVisible13		 bit,
	@z_IsVisible14		 bit,
	@z_IsVisible15		 bit,
	@z_IsVisible16		 bit,
	@z_IsVisible17		 bit,
	@z_IsVisible18		 bit,
	@z_IsVisible19		 bit,
	@z_IsVisible20		 bit,
    @n_ScheduleID			 int,
    @n_IsActive			 int,
    @d_CreatedDateTime	 datetime,
    @n_CreatedBy		 int
)
AS
BEGIN

/****************************************************************************************************
* If ScoreName with same ScheduleID exist in DB, then set the old record to INACTIVE by default.
*****************************************************************************************************/
UPDATE T_ScoreName
	SET IsActive = 0
		,ModifiedDateTime = @d_CreatedDateTime
		,ModifiedBy = @n_CreatedBy
	WHERE ScheduleID = @n_ScheduleID
	AND IsActive = 1

INSERT INTO dbo.T_ScoreName
           (ScoreName1
           ,ScoreName2
           ,ScoreName3
           ,ScoreName4
           ,ScoreName5
           ,ScoreName6
           ,ScoreName7
           ,ScoreName8
           ,ScoreName9
           ,ScoreName10
           ,ScoreName11
           ,ScoreName12
           ,ScoreName13
           ,ScoreName14
           ,ScoreName15
           ,ScoreName16
           ,ScoreName17
           ,ScoreName18
           ,ScoreName19
           ,ScoreName20
		   ,ScoreNameFinal
		   ,IsVisible1
		   ,IsVisible2
		   ,IsVisible3
		   ,IsVisible4
		   ,IsVisible5
		   ,IsVisible6
		   ,IsVisible7
		   ,IsVisible8
		   ,IsVisible9
		   ,IsVisible10
		   ,IsVisible11
		   ,IsVisible12
		   ,IsVisible13
		   ,IsVisible14
		   ,IsVisible15
		   ,IsVisible16
		   ,IsVisible17
		   ,IsVisible18
		   ,IsVisible19
		   ,IsVisible20
           ,ScheduleID
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_ScoreName1
           ,@s_ScoreName2
           ,@s_ScoreName3
           ,@s_ScoreName4
           ,@s_ScoreName5
           ,@s_ScoreName6
           ,@s_ScoreName7
           ,@s_ScoreName8
           ,@s_ScoreName9
           ,@s_ScoreName10
           ,@s_ScoreName11
           ,@s_ScoreName12
           ,@s_ScoreName13
           ,@s_ScoreName14
           ,@s_ScoreName15
           ,@s_ScoreName16
           ,@s_ScoreName17
           ,@s_ScoreName18
           ,@s_ScoreName19
           ,@s_ScoreName20
           ,@s_ScoreNameFinal
		   ,@z_IsVisible1
           ,@z_IsVisible2
           ,@z_IsVisible3
           ,@z_IsVisible4
           ,@z_IsVisible5
           ,@z_IsVisible6
           ,@z_IsVisible7
           ,@z_IsVisible8
           ,@z_IsVisible9
           ,@z_IsVisible10
           ,@z_IsVisible11
           ,@z_IsVisible12
           ,@z_IsVisible13
           ,@z_IsVisible14
           ,@z_IsVisible15
           ,@z_IsVisible16
           ,@z_IsVisible17
           ,@z_IsVisible18
           ,@z_IsVisible19
           ,@z_IsVisible20
           ,@n_ScheduleID
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)
		   
    SELECT SCOPE_IDENTITY() AS ScoreNameID

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertScoreName] TO USER
GO*/