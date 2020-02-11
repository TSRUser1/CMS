IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateStartListByScheduleIDAndParticipantID' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateStartListByScheduleIDAndParticipantID
END
GO

/*************************************************************************
* Name				: SP_U_UpdateStartListByScheduleIDAndParticipantID
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Update Start List
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateStartListByScheduleIDAndParticipantID]
(
	@n_ScheduleID               int,
	@n_ParticipantID            int,
	@n_ParticipantTypeID		int,
	@s_StartList1				nvarchar(100),
	@s_StartList2				nvarchar(100),
	@s_StartList3				nvarchar(100),
	@s_StartList4				nvarchar(100),
	@s_StartList5				nvarchar(100),
	@s_StartList6				nvarchar(100),
	@s_StartList7				nvarchar(100),
	@s_StartList8				nvarchar(100),
	@s_StartList9				nvarchar(100),
	@s_StartList10				nvarchar(100),
	@n_ModifiedBy               INT,
	@d_ModifiedDateTime         DATETIME
)
AS
BEGIN

	UPDATE T_ParticipantInSchedule
	Set ParticipantTypeID	= @n_ParticipantTypeID,
		StartList1			= @s_StartList1,
		StartList2			= @s_StartList2,
		StartList3			= @s_StartList3,
		StartList4			= @s_StartList4,
		StartList5			= @s_StartList5,
		StartList6			= @s_StartList6,
		StartList7			= @s_StartList7,
		StartList8			= @s_StartList8,
		StartList9			= @s_StartList9,
		StartList10			= @s_StartList10,
		ModifiedDateTime  = @d_ModifiedDateTime,
		ModifiedBy        = @n_ModifiedBy		
	WHERE ScheduleID = @n_ScheduleID
	AND ParticipantID = @n_ParticipantID
	AND IsActive = 1

	SELECT @@ROWCOUNT AS UpdatedRow
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateStartListByScheduleIDAndParticipantID] TO USER
GO*/