IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetEventList' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetEventList
END
GO

/*************************************************************************
* Name				: SP_S_GetEventList
* Author			: Ramani Ganason
* Create date		: 26-Jul-2015
* Description		: Return event list according to SportID
*************************************************************************/
CREATE PROCEDURE [SP_S_GetEventList]
(
	@n_SportID			int,
	@s_EventName		nvarchar(max)
)
AS
BEGIN
SELECT	TE.EventID
		  ,TS.SportName
		  ,TE.EventName
		  ,TE.EventCode
		  ,TE.SportID
		  ,TE.GenderID
		  ,TRG.ReferenceName AS GenderName
		  ,TE.PlayFormatID
		  ,TRP.ReferenceName AS PlayFormatName
		  ,TE.EventTypeID
		  ,TRE.ReferenceName AS EventTypeName
		  ,'<img src="../images/start.gif" height="15" width="15" border="0"> Schedule' AS ScheduleText
		  ,TE.CreatedBy
		  ,TE.CreatedDateTime
		  ,TE.ModifiedBy
		  ,TE.ModifiedDateTime
	FROM	T_Event AS TE
	LEFT JOIN  T_Reference AS TRG ON TE.GenderID = TRG.ReferenceInternalID AND TRG.ReferenceCategoryID = 2
	LEFT JOIN  T_Reference AS TRP ON TE.PlayFormatID = TRP.ReferenceInternalID AND TRP.ReferenceCategoryID = 3
	LEFT JOIN  T_Reference AS TRE ON TE.EventTypeID = TRE.ReferenceInternalID AND TRE.ReferenceCategoryID = 4
	LEFT JOIN T_Sport AS TS ON TS.SportID = TE.SportID
	WHERE	TE.SportID = @n_SportID
	AND		(TE.EventName LIKE ('%' +@s_EventName + '%') OR @s_EventName IS NULL)
	AND TE.IsActive = 1
	ORDER BY TE.EventName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetEventList] TO USER
GO*/