IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateScheduleExtraDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateScheduleExtraDetail
END
GO

/*************************************************************************
* Name				: SSP_U_UpdateScheduleExtraDetail
* Author			: DEV001
* Create date		: 22-Aug-2015
* Description		: Update Schedule detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateScheduleExtraDetail]
(
	@n_ScheduleID			int,
	@n_EventID				int,
	@s_ScheduleFooterNote	nvarchar(MAX),
	@s_EventFooterNote		nvarchar(MAX),
	@s_StartListFooter		nvarchar(MAX),
	@b_IsTogleHtmlMode		bit,
	@n_ModifiedBy			int,
	@d_ModifiedDateTime		datetime
)
AS
BEGIN
IF @s_ScheduleFooterNote IS NOT NULL 
BEGIN
    UPDATE dbo.T_Schedule
	   SET ScheduleFooterNote = @s_ScheduleFooterNote
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
	 WHERE ScheduleID = @n_ScheduleID
END

IF @s_StartListFooter IS NOT NULL 
BEGIN
    UPDATE dbo.T_Schedule
	   SET StartListFooter = @s_StartListFooter
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
	 WHERE ScheduleID = @n_ScheduleID
END

IF @s_EventFooterNote IS NOT NULL 
BEGIN
    UPDATE dbo.T_Event
	   SET EventFooterNote = @s_EventFooterNote
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
	 WHERE EventID = @n_EventID
END

BEGIN
    UPDATE dbo.T_Event
	   SET IsTogleHtmlMode = @b_IsTogleHtmlMode
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
	 WHERE EventID = @n_EventID
END

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateScheduleExtraDetail] TO USER
GO*/