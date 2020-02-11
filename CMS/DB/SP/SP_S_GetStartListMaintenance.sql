IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetStartListMaintenance' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetStartListMaintenance
END
GO

/*************************************************************************
* Name				: SP_S_GetStartListMaintenance
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Return details for StartList according to ScheduleID
*************************************************************************/
CREATE PROCEDURE [SP_S_GetStartListMaintenance]
(
	@n_ScheduleID      int
)
AS
BEGIN
SELECT	TPIS.ParticipantInScheduleID
		  ,TPIS.ParticipantID
		  ,TP.FullName ParticipantName
		  ,TPIS.TeamID
		  ,TPIS.ParticipantPosition
		  ,TPIS.ParticipantTypeID
		  ,TPIS.StartList1
		  ,TPIS.StartList2
		  ,TPIS.StartList3
		  ,TPIS.StartList4
		  ,TPIS.StartList5
		  ,TPIS.StartList6
		  ,TPIS.StartList7
		  ,TPIS.StartList8
		  ,TPIS.StartList9
		  ,TPIS.StartList10
		  ,TC.CountryID
		  ,TC.CountryName
		  ,TP.PassportNumber
		  ,TP.GenderID
		  ,TRG.ReferenceName AS GenderName
		  ,TPIS.SortID
		  ,Convert(varchar,TPIS.SortID) + '. <a href="javascript:void(0)" onclick="Up(' + ISNULL(CAST(TPIS.TeamID AS NVARCHAR), '''''') + ', ' + Convert(varchar,TPIS.ParticipantID) + ', ' + Convert(varchar,TPIS.ScheduleID) + ', ' + Convert(varchar,TPIS.SortID) + ');">UP</a> | <a href="javascript:void(0)" onclick="Down(' + ISNULL(CAST(TPIS.TeamID AS NVARCHAR), '''''') + ', ' + Convert(varchar,TPIS.ParticipantID) + ', ' + Convert(varchar,TPIS.ScheduleID) + ', ' + Convert(varchar,TPIS.SortID) + ');">DOWN</a>' AS HtmlEncodeSort
	FROM	T_ParticipantInSchedule AS TPIS
	LEFT JOIN  T_Participant AS TP ON TP.ParticipantID = TPIS.ParticipantID
	LEFT JOIN  T_Country AS TC ON TC.CountryID = TP.CountryID  
	LEFT JOIN  T_Reference AS TRG ON TRG.ReferenceInternalID = TP.GenderID AND TRG.ReferenceCategoryID = 2
	WHERE	(TPIS.ScheduleID = @n_ScheduleID or @n_ScheduleID is null)
	AND TPIS.IsActive = 1	
	ORDER BY TPIS.SortID, TPIS.TeamID, TPIS.ParticipantID 		
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetStartListMaintenance] TO USER
GO*/