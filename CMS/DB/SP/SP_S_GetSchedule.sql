IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetSchedule
END
GO

/*************************************************************************
* Name				: SP_S_GetSchedule
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return schedule detail
*************************************************************************/
/*************************************************************************
* Name				: SP_S_GetSchedule
* Author			: Reese
* Create date		: 29-Aug-2015
* Description		: Handle StartListDetail
*************************************************************************/
CREATE PROCEDURE [SP_S_GetSchedule]
(
	@n_ScheduleID			int,
	@n_EventID				int
)
AS
BEGIN

	DECLARE @l_n_ScheduleID DATETIME,
			@l_n_EventID INT
	SET @l_n_ScheduleID = @n_ScheduleID
	SET @l_n_EventID = @n_EventID

	SELECT	SC.*
			,SCS.ReferenceCode AS StatusCode
			,PF.ReferenceCode As PlayFormat
	        ,'<img src="../images/start.gif" height="15" width="15" border="0"> StartList' AS StartListDetail
			,'<img src="../images/start.gif" height="15" width="15" border="0"> Result' AS ResultLink
			, E.SportID
			, EventTypeID
	FROM	T_Schedule AS SC  WITH (NOLOCK)
	INNER JOIN T_Event AS E  WITH (NOLOCK)
	ON E.EventID = SC.EventID
	INNER JOIN T_Reference AS SCS  WITH (NOLOCK)
	ON SCS.ReferenceInternalID = SC.StatusCodeID
	AND SCS.ReferenceCategoryID = 5
	INNER JOIN T_Reference AS PF  WITH (NOLOCK)
	ON PF.ReferenceInternalID = SC.PlayFormatID
	AND PF.ReferenceCategoryID = 3
	WHERE	(SC.ScheduleID = @l_n_ScheduleID or @l_n_ScheduleID is null)
			and (SC.EventID = @l_n_EventID or @l_n_EventID is null) 
			and SC.IsActive = 1
	ORDER BY SC.ScheduleDateTime, SC.ScheduleName ASC
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetSchedule] TO USER
GO*/