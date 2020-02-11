IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertStartList' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertStartList
END
GO

/*************************************************************************
* Name				: SP_I_InsertStartList
* Author			: Reese
* Create date		: 25-Aug-2015
* Description		: Insert Start List
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertStartList]
(
	@n_ScheduleID					int,
	@n_ParticipantID				int,
	@n_TeamID						int,
	@n_ParticipantTypeID			int,
	@s_StartList1					nvarchar(100),
	@s_StartList2					nvarchar(100),
	@s_StartList3					nvarchar(100),
	@s_StartList4					nvarchar(100),
	@s_StartList5					nvarchar(100),
	@s_StartList6					nvarchar(100),
	@s_StartList7					nvarchar(100),
	@s_StartList8					nvarchar(100),
	@s_StartList9					nvarchar(100),
	@s_StartList10					nvarchar(100),
	@n_CreatedBy					int,
	@d_CreatedDateTime				datetime
)
AS
BEGIN

DECLARE @SortID INT

SELECT @SortID = SortID
FROM T_ParticipantInSchedule
WHERE TeamID = @n_TeamID
AND ScheduleID = @n_ScheduleID
AND IsActive = 1

IF(@SortID IS NULL)
BEGIN
SELECT @SortID=MAX(ISNULL(SortId,0))+1
FROM T_ParticipantInSchedule
WHERE ScheduleID = @n_ScheduleID
AND IsActive = 1
GROUP BY ScheduleID
END


INSERT INTO dbo.[T_ParticipantInSchedule]
           ([ScheduleID]
           ,[ParticipantID]
           ,[TeamID]
           ,[SortID]
		   ,[ParticipantTypeID]
		   ,[StartList1]
		   ,[StartList2]
		   ,[StartList3]
		   ,[StartList4]
		   ,[StartList5]
		   ,[StartList6]
		   ,[StartList7]
		   ,[StartList8]
		   ,[StartList9]
		   ,[StartList10]
           ,[IsActive]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[ModifiedDateTime]
           ,[ModifiedBy])
     VALUES
           (@n_ScheduleID
		   ,@n_ParticipantID
		   ,@n_TeamID
		   ,ISNULL(@SortID,0)
		   ,@n_ParticipantTypeID
		   ,@s_StartList1
		   ,@s_StartList2
		   ,@s_StartList3
		   ,@s_StartList4
		   ,@s_StartList5
		   ,@s_StartList6
		   ,@s_StartList7
		   ,@s_StartList8
		   ,@s_StartList9
		   ,@s_StartList10
           ,1
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

	
END

SELECT SCOPE_IDENTITY() AS ParticipantInScheduleID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertStartList] TO USER
GO*/