IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetStartListParticipantList' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetStartListParticipantList
END
GO

/*************************************************************************
* Name				: SP_S_GetStartListParticipantList
* Author			: Reese
* Create date		: 23-Aug-2015
* Description		: Return particapant list for AddStartList according to EventID
*************************************************************************/
CREATE PROCEDURE [SP_S_GetStartListParticipantList]
(
	@n_EventID			int
    ,@n_ScheduleID      int
)
AS
BEGIN
SELECT	ROW_NUMBER() 
        OVER (ORDER BY TC.CountryName, TP.FullName) AS RowOrder
		  ,TPIE.ParticipantInEventID
		  ,TPIE.ParticipantID
		  ,TPIE.TeamID
		  ,UPPER(TP.FullName) ParticipantName
		  ,TC.CountryID
		  ,TC.CountryName
		  ,TP.PassportNumber
		  ,TP.GenderID
		  ,TRG.ReferenceName AS GenderName
	FROM	T_ParticipantInEvent AS TPIE
	LEFT JOIN  T_Participant AS TP ON TP.ParticipantID = TPIE.ParticipantID
	LEFT JOIN  T_Country AS TC ON TC.CountryID = TP.CountryID  
	LEFT JOIN  T_Reference AS TRG ON TRG.ReferenceInternalID = TP.GenderID AND TRG.ReferenceCategoryID = 2
	WHERE	(TPIE.EventID = @n_EventID or @n_EventID is null)
	AND TPIE.ParticipantID NOT IN (select TPIS.ParticipantID from T_ParticipantInSchedule AS TPIS where (TPIS.ScheduleID = @n_ScheduleID or @n_ScheduleID is null) and TPIS.IsActive = 1)
	AND (TPIE.TeamID IS NULL OR TPIE.TeamID IN (SELECT TeamID FROM T_Team AS T WHERE T.IsActive = 1))
	AND TPIE.IsActive = 1	

ORDER BY rowOrder, TC.CountryName, TP.FullName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetStartListParticipantList] TO USER
GO*/